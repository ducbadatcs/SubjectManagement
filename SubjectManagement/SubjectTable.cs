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

        public string InsertObjectCommand(Subject subject)
        {
            return this.InsertObjectCommand<Subject>(subject);
        }

        public void InsertSubject(Subject subject)
        {
            this.Insert(ObjectFunctions.ObjectPropertyValues(subject));
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
    }
}