using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Windows.Forms;

namespace SubjectManagement
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            using (var connection = new SQLiteConnection("Data Source=subjects.db"))
            {
                // assign source for the grid

                dataGridSubjects.DataSource = connection;

                connection.Open();

                SubjectTable subjectTable = new SubjectTable();

                List<Subject> ls = new List<Subject>()
                {
                    new Subject("COS10004", "Computer System"),
                    new Subject("COS10009", "Introduction to Programming"),
                    new Subject("COS10026", "Computing Technology something project"),
                    new Subject("COS20031", "suffering", requiredSubjects: new List<string>()
                    {
                        "COS10009"
                    }),
                    new Subject("COS20007", "OOP", requiredSubjects: new List<string>()
                    {
                        "COS10009"
                    }),
                };

                foreach (Subject subject in ls)
                {
                    try
                    {
                        subjectTable.InsertSubject(subject);
                    }
                    catch (Exception ex)
                    {
                        UtilityFunctions.ShowException(
                            ex,
                            subjectTable.InsertCommand(ObjectFunctions.ObjectPropertyValues(subject)));
                    }
                }
                connection.Close();
            }
        }

        private void buttonShowSubjects_Click(object sender, EventArgs e)
        {
            SubjectTable subjectTable = new SubjectTable();
            using (var connection = new SQLiteConnection("Data Source=subjects.db"))
            {
                dataGridSubjects.DataSource = subjectTable.AllSubjects;
                dataGridSubjects.Refresh();
            }
        }

        private void buttonClearTable_Click(object sender, EventArgs e)
        {
            SubjectTable subjectTable = new SubjectTable();

            try
            {
                subjectTable.Delete();
            }
            catch (Exception ex)
            {
                UtilityFunctions.ShowException(ex, subjectTable.CreateCommand);
            }

            dataGridSubjects.DataSource = null; // ah yes
            dataGridSubjects.Rows.Clear();
            dataGridSubjects.Refresh();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("why are you clicking this nonsense you fucking dumbass", "you just got MEMED!");
        }

        private void buttonSearchSubject_Click(object sender, EventArgs e)
        {
            string id = textBoxSubject.Text;
            SubjectTable subjectTable = new SubjectTable();
            var foundSubjects = subjectTable.FindSubjectById(id);

            dataGridSubjects.DataSource = new List<Subject>() { foundSubjects };
            dataGridSubjects.Refresh();
        }
    }
}