using System;
using System.Collections.Generic;
using System.Text;

namespace SubjectManagement
{
    public class Subject
    {
        private List<string> _requiredSubjects = new List<string>();

        public Subject() { }

        public Subject(
            string id,
            string name,
            double numberOfCredits = 0,
            double requiredCredits = 0,
            List<string> requiredSubjects = null
                      )
        {
            this.Id = id;
            this.Name = name;
            this.NumberOfCredits = numberOfCredits;
            this.RequiredNumberOfCredits = requiredCredits;
            this._requiredSubjects = new List<string>() { };
            if (!(requiredSubjects is null))
            {
                foreach (var subject in requiredSubjects)
                {
                    this._requiredSubjects.Add(subject);
                }
            }
        }
        public string Id { get; set; }

        public string Name { get; set; }

        public double NumberOfCredits { get; set; }

        public double RequiredNumberOfCredits { get; set; }

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
            set
            {
                this._requiredSubjects.Clear();
                if (!string.IsNullOrEmpty(value))
                {
                    string[] ids = value.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    foreach (string id in ids)
                    {
                        this._requiredSubjects.Add(id.Trim());
                    }
                }
            }
        }
    }
}