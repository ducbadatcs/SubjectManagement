using System.Collections.Generic;

namespace SubjectManagement
{
    public class Subject
    {
        private string _id, _name;

        private int _numberOfCredits, _requiredNumberOfCredits;

        private List<Subject> _requiredSubjects;

        public Subject() { }

        public Subject(
            string id,
            string name,
            int numberOfCredits = 0,
            int requiredCredits = 0,
            List<Subject> requiredSubjects = null
        )
        {
            this._id = id;
            this._name = name;
            this._numberOfCredits = numberOfCredits;
            this._requiredNumberOfCredits = requiredCredits;
            this._requiredSubjects = requiredSubjects ?? new List<Subject>();
        }

        public string Id
        {
            get { return this._id; }
            set { this._id = value; }
        }

        public string Name
        {
            get { return this._name; }
            set { this._name = value; }
        }

        public int NumberOfCredits
        {
            get { return this._numberOfCredits; }
            set { this._numberOfCredits = value; }
        }

        public int RequiredNumberOfCredits
        {
            get { return this._requiredNumberOfCredits; }
            set { this._requiredNumberOfCredits = value; }
        }

        public List<Subject> RequiredSubjects
        {
            get { return this._requiredSubjects; }
            set { this._requiredSubjects = value; }
        }

        public string RequiredSubjectsIDs
        {
            get
            {
                string x = "";
                foreach (Subject subject in this._requiredSubjects)
                {
                    x += subject.Name + " ";
                }
                return x;
            }
        }
    }
}
