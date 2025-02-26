using System.Collections.Generic;

namespace SubjectManagement
{
    public class Student
    {
        private string _name;
        private int _finishedCredits;

        private List<Subject> _finishedSubjects;

        public Student(string name, int finishedCredits)
        {
            this._name = name;
            this._finishedCredits = finishedCredits;
        }

        public string Name
        {
            get { return this._name; }
            set { this._name = value; }
        }

        public int FinishedCredits
        {
            get { return this._finishedCredits; }
            set { this._finishedCredits = value; }
        }

        public List<Subject> FinishedSubjects
        {
            get { return this._finishedSubjects; }
            set { this._finishedSubjects = value; }
        }

        public bool IsEligibleFor(Subject subject)
        {
            foreach (Subject s in _finishedSubjects)
            {
                if (!this._finishedSubjects.Contains(s))
                {
                    return false;
                }
            }
            return this._finishedCredits >= subject.RequiredNumberOfCredits;
        }
    }
}
