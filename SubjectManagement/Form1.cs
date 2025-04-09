using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Windows.Forms;

namespace SubjectManagement
{
    public partial class Form1 : Form
    {
        public Student student = new Student("Hoàng Minh Đức", new SubjectTable("student"));
        
        public Form1()
        {
            //MessageBox.Show($"Hello, student {student.Name}!");
            InitializeComponent();
        }

        private void buttonShowSubjects_Click(object sender, EventArgs e)
        {
            SubjectTable subjectTable = new SubjectTable("subjects");
            dataGridSubjects.DataSource = subjectTable.AllSubjects();

            dataGridSubjects.Refresh();
        }

        private void buttonClearTable_Click(object sender, EventArgs e)
        {
            SubjectTable subjectTable = new SubjectTable("subjects");

            try
            {
                subjectTable.Delete();
            }
            catch (Exception ex)
            {
                UtilityFunctions.ShowException(ex);
            }

            dataGridSubjects.DataSource = null; // ah yes
            //dataGridSubjects.Rows.Clear();
            dataGridSubjects.Refresh();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("why are you clicking this", "you just got MEMED!");
        }

        private void buttonSearchSubject_Click(object sender, EventArgs e)
        {
            string id = textBoxSubject.Text;
            SubjectTable subjectTable = new SubjectTable("subjects");
            dataGridSubjects.DataSource = new List<Subject>() { subjectTable.FindSubjectById(id) };
            dataGridSubjects.Refresh();
        }

        private void buttonOpenCrashLog_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("notepad");
        }

        private void buttonAddNewSubject_Click(object sender, EventArgs e)
        {
            var formAddSubject = new FormAddSubject();
            formAddSubject.ShowDialog();
            buttonShowSubjects_Click(sender, e);
        }

        private void buttonRemoveSubjectFromDatabase_Click(object sender, EventArgs e)
        {
            string id = textBoxSubject.Text;
            SubjectTable subjectTable = new SubjectTable("subjects");
            subjectTable.Delete(conditions: new List<string>() { $"ID LIKE '%{id}%' "});
            buttonShowSubjects_Click(sender, e);
        }

        private void buttonSignUpForSubject_Click(object sender, EventArgs e)
        {
            try
            {
                // Get the subject ID from the text box
                string subjectId = textBoxSignUpSubject.Text.Trim();
                if (string.IsNullOrEmpty(subjectId))
                {
                    MessageBox.Show("Please enter a subject ID.");
                    return;
                }

                // First, clone the subject instead of deleting it right away
                SubjectTable subjectTable = new SubjectTable("subjects");
                Subject subject = subjectTable.FindSubjectById(subjectId);

                if (subject == null)
                {
                    MessageBox.Show("Subject not found in the database!");
                    return;
                }

                // Create a clone of the subject to insert into student's table
                Subject subjectClone = new Subject(
                    subject.Id,
                    subject.Name,
                    subject.NumberOfCredits,
                    subject.RequiredNumberOfCredits,
                    subject.RequiredSubjectsIDs?.Split(',').ToList()
                );

                // Check if student already has this subject
                bool alreadySignedUp = false;
                foreach (var s in student.FinishedSubjects.AllSubjects())
                {
                    if (s.Id == subject.Id)
                    {
                        alreadySignedUp = true;
                        break;
                    }
                }

                if (alreadySignedUp)
                {
                    MessageBox.Show("You already signed up for this subject!");
                    return;
                }

                // Use a transaction for the insert operation
                using (var connection = new SQLiteConnection($"Data Source=student.db"))
                {
                    connection.Open();

                    using (var transaction = connection.BeginTransaction())
                    {
                        try
                        {
                            // Directly insert the subject via SQL to avoid connection issues
                            string insertSql = $@"
                        INSERT INTO student (ID, NAME, NUMBER_OF_CREDITS, REQUIRED_NUMBER_OF_CREDITS, REQUIRED_SUBJECTS_IDS) 
                        VALUES (@Id, @Name, @Credits, @RequiredCredits, @RequiredSubjects)";

                            using (var cmd = new SQLiteCommand(insertSql, connection, transaction))
                            {
                                cmd.Parameters.AddWithValue("@Id", subjectClone.Id);
                                cmd.Parameters.AddWithValue("@Name", subjectClone.Name);
                                cmd.Parameters.AddWithValue("@Credits", subjectClone.NumberOfCredits);
                                cmd.Parameters.AddWithValue("@RequiredCredits", subjectClone.RequiredNumberOfCredits);
                                cmd.Parameters.AddWithValue("@RequiredSubjects", subjectClone.RequiredSubjectsIDs ?? "");

                                cmd.ExecuteNonQuery();
                            }

                            transaction.Commit();
                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback();
                            throw new Exception($"Failed to add subject: {ex.Message}", ex);
                        }
                    }

                    connection.Close();
                }

                // Now handle the deletion from the subjects table
                using (var connection = new SQLiteConnection($"Data Source=subjects.db"))
                {
                    connection.Open();

                    using (var transaction = connection.BeginTransaction())
                    {
                        try
                        {
                            string deleteSql = $"DELETE FROM subjects WHERE ID = @Id";

                            using (var cmd = new SQLiteCommand(deleteSql, connection, transaction))
                            {
                                cmd.Parameters.AddWithValue("@Id", subject.Id);
                                cmd.ExecuteNonQuery();
                            }

                            transaction.Commit();
                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback();
                            throw new Exception($"Failed to delete subject: {ex.Message}", ex);
                        }
                    }

                    connection.Close();
                }

                // Update the UI
                buttonShowSubjects_Click(sender, e);
                buttonShowSubjectsSignedUp_Click(sender, e);

                MessageBox.Show($"Successfully signed up for {subject.Name} ({subject.Id})");
            }
            catch (Exception ex)
            {
                UtilityFunctions.ShowException(ex);
            }
        }



        private void buttonShowSubjectsSignedUp_Click(object sender, EventArgs e)
        {
            dataGridViewStudentSubjects.DataSource = student.FinishedSubjects.AllSubjects();
            dataGridViewStudentSubjects.Refresh();
        }
    }
}