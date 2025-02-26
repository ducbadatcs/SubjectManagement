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
        }

        public Form1()
        {
            //SQLitePCL.Batteries_V2.Init();
            InitializeComponent();
            using (var connection = new SQLiteConnection("Data Source=hello.db"))
            {
                // assign source for the grid

                dataGridSubjects.DataSource = connection;

                connection.Open();

                Table subjectTable = new SubjectTable();

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

                var insertCommand = connection.CreateCommand();
                insertCommand.CommandText = subjectTable.InsertIntoTableCommand;

                foreach (Subject subject in ls)
                {
                    insertCommand.Parameters.AddWithValue("$id", subject.Id);
                    insertCommand.Parameters.AddWithValue("$name", subject.Name);
                    insertCommand.Parameters.AddWithValue("$number_of_credits", subject.NumberOfCredits.ToString());
                    insertCommand.Parameters.AddWithValue("$required_number_of_credits", subject.RequiredNumberOfCredits.ToString());
                    insertCommand.Parameters.AddWithValue("$required_subjects_ids", subject.RequiredSubjectsIDs);

                    try
                    {
                        insertCommand.ExecuteScalar();
                    }
                    catch (Exception ex)
                    {
                        ShowException(ex, insertCommand.CommandText);
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
            using (var connection = new SQLiteConnection("Data Source=hello.db"))
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
                        subjectList.Add(new Subject(
                            reader["ID"].ToString(),
                            reader["NAME"].ToString(),
                            int.Parse(reader["NUMBER_OF_CREDITS"].ToString()),
                            int.Parse(reader["REQUIRED_NUMBER_OF_CREDITS"].ToString())
                        // don't worry we construct the list later
                        ));
                    }
                }
                catch (Exception ex)
                {
                    ShowException(ex);
                }

                foreach (Subject subject in subjectList)
                {

                }

                connection.Close();
            }
        }

        private void dataGridSubjects_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
