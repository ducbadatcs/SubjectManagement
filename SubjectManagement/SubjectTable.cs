using System.Collections.Generic;
using System.Data.SQLite;

namespace SubjectManagement
{
    public class SubjectTable : Table
    {
        public SubjectTable() : base(
            "subjects",
            new Dictionary<string, string>() {
                    {"ID", "TEXT PRIMARY KEY"},
                    {"NAME", "TEXT"},
                    {"NUMBER_OF_CREDITS", "REAL" },
                    {"REQUIRED_NUMBER_OF_CREDITS", "REAL" },
                    {"REQUIRED_SUBJECTS_IDS", "TEXT" }
            })
        { }

        public void AddSubject(Subject subject)
        {
            using (var connection = new SQLiteConnection($"Data Source={this.Name}.db"))
            {
                connection.Open();

                var insertCommand = connection.CreateCommand();

                insertCommand.CommandText = this.InsertIntoTableCommand;
                //string s = insertCommand.CommandText;
                insertCommand.Parameters.AddWithValue("$id", subject.Id);
                insertCommand.Parameters.AddWithValue("$name", subject.Name);
                insertCommand.Parameters.AddWithValue("$number_of_credits", subject.NumberOfCredits.ToString());
                insertCommand.Parameters.AddWithValue("$required_number_of_credits", subject.RequiredNumberOfCredits.ToString());
                insertCommand.Parameters.AddWithValue("$required_subjects_ids", subject.RequiredSubjectsIDs);

                string s = insertCommand.CommandText;

                insertCommand.ExecuteScalar();

                connection.Close();
            }
        }


    }
}
