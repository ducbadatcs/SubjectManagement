using System.Collections.Generic;

namespace SubjectManagement
{
    public class Student
    {
        public Student(string name, SubjectTable finishedSubjects)
        {
            this.Name = name;

            this.FinishedSubjects = finishedSubjects;
        }

        public string Name { get; set; }

        public SubjectTable FinishedSubjects { get; set; }

        public double NumberOfCreditsFinished
        {
            get
            {
                double totalCredits = 0.0;
                foreach (Subject subject in this.FinishedSubjects.AllSubjects)
                {
                    totalCredits += subject.NumberOfCredits;
                }
                return totalCredits;
            }
        }

        public bool IsEligibleFor(Subject subject)
        {
            foreach (Subject s in this.FinishedSubjects.AllSubjects)
            {
                if (!this.FinishedSubjects.AllSubjects.Contains(s))
                {
                    return false;
                }
            }
            return this.NumberOfCreditsFinished >= subject.RequiredNumberOfCredits;
        }
    }
}