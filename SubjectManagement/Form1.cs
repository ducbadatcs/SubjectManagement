using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SubjectManagement
{
    public partial class Form1 : Form
    {


        public Form1()
        {
            InitializeComponent();
            using (var connection = new SqliteConnection("Data Source=hello.db"))
            {
                connection.Open();

                var createTableCommand = connection.CreateCommand();
                createTableCommand.CommandText =
                @"
                    CREATE TABLE IF NOT EXISTS subjects(
                        ID TEXT PRIMARY KEY NOT NULL,
                        NAME TEXT NOT NULL,
                        NUMBER_OF_CREDITS INT NOT NULL,
                        REQUIRED_NUMBER_OF_CREDITS INT NOT NULL,
                        REQUIRED_SUBJECTS TEXT NOT NULL
                    );
                ";

                try
                {
                    createTableCommand.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Message:", ex.Message);
                    MessageBox.Show("\nStack Trace:", ex.StackTrace);
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
                insertCommand.CommandText =
                @"
                    INSERT INTO subjects(ID, NAME, NUMBER_OF_CREDITS, REQUIRED_NUMBER_OF_CREDITS, REQUIRED_SUBJECTS)
                    VALUES ($id, $name, $number_of_credits, $required_number_of_credits, $required_subjects_ids)
                ";

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
                        MessageBox.Show("Message:", ex.Message);
                        MessageBox.Show("\nStack Trace:", ex.StackTrace);
                    }
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
