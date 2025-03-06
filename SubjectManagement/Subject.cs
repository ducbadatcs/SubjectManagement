using System.Collections.Generic;
using System.Text;

namespace SubjectManagement
{
    public class Subject
    {
        private List<string> _requiredSubjects;

        public Subject()
        { }

        public Subject(
            string id,
            string name,
            int numberOfCredits = 0,
            int requiredCredits = 0,
            List<string> requiredSubjects = null
                      )
        {
            this.Id = id;
            this.Name = name;
            this.NumberOfCredits = numberOfCredits;
            this.RequiredNumberOfCredits = requiredCredits;
            this._requiredSubjects = requiredSubjects ?? new List<string>();
        }

        public string Id { get; set; }

        public string Name { get; set; }

        public int NumberOfCredits { get; set; }

        public int RequiredNumberOfCredits { get; set; }

        //public List<string> RequiredSubjects { get; set; }

        public string RequiredSubjectsIDs
        {
            get
            {
                StringBuilder stringBuilder = new StringBuilder();

                foreach (string subjectId in this._requiredSubjects)
                {
                    stringBuilder.Append($"{subjectId} ");
                }
                return stringBuilder.ToString();
            }
        }
    }
}