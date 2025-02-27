using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Windows.Forms;

namespace SubjectManagement
{
    public partial class Form1 : Form
    {
        public void ShowException(Exception ex, string sqlCommand = "")
        {
            string error = "";

            if (sqlCommand.Length > 0)
            {
                error += "Error while trying to execute SQL Command: " + sqlCommand + "\n\n";
            }
            // this is 1000000 times better than pasting this exact same code everywhere
            error += @"Message:" + ex.Message + "\n\nStack Trace:" + ex.StackTrace;
            MessageBox.Show(
                error, "Error");
            StreamWriter writer = new StreamWriter("error.txt");
            writer.WriteLine(error);
            writer.Close();
            Application.Exit();
        }

        public Form1()
        {
            //SQLitePCL.Batteries_V2.Init();
            InitializeComponent();
            using (var connection = new SQLiteConnection("Data Source=subjects.db"))
            {
                // assign source for the grid

                dataGridSubjects.DataSource = connection;

                connection.Open();

                SubjectTable subjectTable = new SubjectTable();

                var createTableCommand = connection.CreateCommand();
                createTableCommand.CommandText = subjectTable.CreateTableCommand;

                try
                {
                    createTableCommand.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    ShowException(ex, createTableCommand.CommandText);
                }


                var command = connection.CreateCommand();

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
                        subjectTable.AddSubject(subject);
                    }
                    catch (Exception ex)
                    {
                        ShowException(ex, subjectTable.InsertIntoTableCommand);
                    }
                }
                connection.Close();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void buttonShowSubjects_Click(object sender, EventArgs e)
        {
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
                    ShowException(ex);
                }

                dataGridSubjects.DataSource = subjectList;

                // double check


                dataGridSubjects.Refresh();
                connection.Close();
            }
        }

        private void buttonClearTable_Click(object sender, EventArgs e)
        {
            using (var connection = new SQLiteConnection("Data Source=subjects.db"))
            {
                connection.Open();

                SubjectTable subjectTable = new SubjectTable();

                var clearCommand = connection.CreateCommand();
                clearCommand.CommandText = subjectTable.ClearTableCommand;
                try
                {
                    clearCommand.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    ShowException(ex, clearCommand.CommandText);
                }

                connection.Close();
            }

            var temp = dataGridSubjects.DataSource;
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
