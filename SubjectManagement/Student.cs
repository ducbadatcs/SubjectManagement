using System.Collections.Generic;

namespace SubjectManagement
{
    public class Student
    {
        private string _name;
        //private double _finishedCredits;

        private List<Subject> _finishedSubjects;

        public Student(string name, List<Subject> finishedSubjects)
        {
            this._name = name;
            //this._finishedCredits = finishedCredits;
            this._finishedSubjects = finishedSubjects;

        }

        public string Name
        {
            get { return this._name; }
            set { this._name = value; }
        }

        public List<Subject> FinishedSubjects
        {
            get { return this._finishedSubjects; }
            set { this._finishedSubjects = value; }
        }

        public double NumberOfCreditsFinished
        {
            get
            {
                double totalCredits = 0.0;
                foreach (Subject subject in this._finishedSubjects)
                {
                    totalCredits += subject.NumberOfCredits;
                }
                return totalCredits;
            }
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
            return this.NumberOfCreditsFinished >= subject.RequiredNumberOfCredits;
        }
    }
}
