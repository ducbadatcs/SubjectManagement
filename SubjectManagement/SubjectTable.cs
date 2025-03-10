using System.Collections.Generic;

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



        public void InsertSubject(Subject subject)
        {
            this.InsertObject<Subject>(subject);
        }

        public void DeleteSubject(Subject subject)
        {
            this.Delete(new List<string>() { $"ID = {subject.Id}" });
        }

        public Subject FindSubjectById(string id)
        {
            return this.ReadOneObject<Subject>(conditions: new List<string> { $" ID LIKE '%{id}%'" });
        }

        public List<Subject> AllSubjects
        {
            get
            {
                return this.ReadAllObjects<Subject>();
            }
        }

        public List<string> AllSubjectsIDs
        {
            get
            {
                List<string> result = new List<string>();
                foreach (Subject subject in this.AllSubjects)
                {
                    result.Add(subject.Id);
                }
                return result;
            }
        }
    }
}