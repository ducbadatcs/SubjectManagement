using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
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
                    new Subject("COS20031", "suffering", requiredSubjects: new List<Subject>()
                    {
                        new Subject("COS10009", "Introduction to Programming"),
                    }),
                    new Subject("COS20007", "OOP", requiredSubjects: new List<Subject>()
                    {
                        new Subject("COS10009", "Introduction to Programming"),
                    })
                };



                foreach (Subject subject in ls)
                {

                    try
                    {
                        subjectTable.InsertSubject(subject);
                    }
                    catch (Exception ex)
                    {
                        UtilityFunctions.ShowException(ex, subjectTable.InsertCommand(subject.ObjectList.Values.ToList()));
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
                connection.Open();

                var readCommand = connection.CreateCommand();
                readCommand.CommandText =
                @"
                    SELECT * FROM subjects
                ";

                List<Subject> subjectList = new List<Subject>();

                try
                {
                    var reader = readCommand.ExecuteReader();
                    while (reader.Read())
                    {
                        Subject s = new Subject(
                            reader["ID"].ToString(),
                            reader["NAME"].ToString(),
                            int.Parse(reader["NUMBER_OF_CREDITS"].ToString()),
                            int.Parse(reader["REQUIRED_NUMBER_OF_CREDITS"].ToString())
                        // don't worry we construct the list later
                        );
                        subjectList.Add(s);
                    }
                }

                catch (Exception ex)
                {
                    UtilityFunctions.ShowException(ex);
                }

                dataGridSubjects.DataSource = subjectList;

                // double check


                dataGridSubjects.Refresh();
                connection.Close();
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
            MessageBox.Show("why are you clicking this nonsense you fucking dumbass");
        }
    }
}
