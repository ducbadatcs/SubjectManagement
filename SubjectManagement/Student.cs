using System.Collections.Generic;

namespace SubjectManagement
{
    public class Student
    {
        public Student(string name, List<Subject> finishedSubjects)
        {
            this.Name = name;

            this.FinishedSubjects = finishedSubjects;
        }

        public string Name { get; set; }

        public List<Subject> FinishedSubjects { get; set; }

        public double NumberOfCreditsFinished
        {
            get
            {
                double totalCredits = 0.0;
                foreach (Subject subject in this.FinishedSubjects)
                {
                    totalCredits += subject.NumberOfCredits;
                }
                return totalCredits;
            }
        }

        public bool IsEligibleFor(Subject subject)
        {
            foreach (Subject s in this.FinishedSubjects)
            {
                if (!this.FinishedSubjects.Contains(s))
                {
                    return false;
                }
            }
            return this.NumberOfCreditsFinished >= subject.RequiredNumberOfCredits;
        }
    }
}