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
            this.Insert(subject.ObjectList);
        }




    }
}
