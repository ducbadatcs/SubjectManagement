using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SubjectManagement
{
    public partial class FormAddSubject: Form
    {
        public FormAddSubject()
        {
            InitializeComponent();
        }

        private void FormAddSubject_Load(object sender, EventArgs e)
        {

        }

        private void buttonAddSubject_Click(object sender, EventArgs e)
        {
            // get the text from all the form, and try to construct the Subject with that
            // first we check the numeric types:

            float numberOfCredits = 0.0f;
            float requiredNumberOfCredits = 0.0f;
            try
            {
                numberOfCredits = float.Parse(subjectNumberOfCreditsTextBox.Text);
                requiredNumberOfCredits = float.Parse(subjectRequiredNumberOfCreditsTextBox.Text);
            }
            catch (Exception ex)
            {
                UtilityFunctions.ShowException(ex);
            }

            var dummy = subjectRequiredSubjectsTextBox.Text.Split('\n');

            // reconstruct because splitting is stupid
            List<string> requiredSubjects = new List<string>();
            foreach (string subjectId in dummy)
            {
                if (subjectId.Length > 0)
                {
                    requiredSubjects.Add(subjectId);
                }
            }

            SubjectTable subjectTable = new SubjectTable();

            
                foreach (string subjectId in requiredSubjects)
                {
                    if (!subjectTable.AllSubjectsIDs.Contains(subjectId))
                    {
                        MessageBox.Show($"The subject with ID {subjectId} is not available!");
                        return;
                    }
                }
            

            
            subjectTable.InsertSubject(new Subject(
                subjectIDTextBox.Text,
                subjectNameTextBox.Text,
                numberOfCredits,
                requiredNumberOfCredits,
                requiredSubjects.ToList<string>()
                ));

            this.Close();
        }
    }
}
