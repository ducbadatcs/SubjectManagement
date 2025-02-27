using System.Collections.Generic;

namespace SubjectManagement
{
    public class Subject
    {
        public Subject() { }

        public Subject(
            string id,
            string name,
            int numberOfCredits = 0,
            int requiredCredits = 0,
            List<Subject> requiredSubjects = null
        )
        {
            this.Id = id;
            this.Name = name;
            this.NumberOfCredits = numberOfCredits;
            this.RequiredNumberOfCredits = requiredCredits;
            this.RequiredSubjects = requiredSubjects ?? new List<Subject>();
        }

        public string Id { get; set; }

        public string Name { get; set; }

        public int NumberOfCredits { get; set; }

        public int RequiredNumberOfCredits { get; set; }

        public List<Subject> RequiredSubjects { get; set; }

        public string RequiredSubjectsIDs
        {
            get
            {
                string x = "";
                foreach (Subject subject in this.RequiredSubjects)
                {
                    x += subject.Id + " ";
                }
                return x;
            }
        }

        /// <summary>
        /// why
        /// </summary>
        public Dictionary<string, object> ObjectList
        {
            get
            {
                Dictionary<string, object> dict = new Dictionary<string, object>();
                var properties = this.GetType().GetProperties();
                foreach (var property in properties)
                {
                    dict[property.Name] = property.GetValue(this);
                }
                return dict;
            }
        }
    }
}
