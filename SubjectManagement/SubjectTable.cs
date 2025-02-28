using System.Collections.Generic;
using System.Linq;

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
            this.Insert(subject.ObjectList.Values.ToList());
        }

        public void DeleteSubject(Subject subject)
        {
            this.Delete(new List<string>() { $"ID = {subject.Id}" });
        }


        public Subject SelectSingleSubject(Subject subject)
        {
            var selectResult = this.Select(conditions: new List<string>() { $"ID LIKE '%{subject.Id}%' " });

        }
    }
}
