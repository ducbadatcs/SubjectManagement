using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Windows.Forms;

namespace SubjectManagement
{
    public partial class Form1 : Form
    {
        public Student student = new Student("Hoàng Minh Đức", new SubjectTable());
        
        public Form1()
        {
            MessageBox.Show($"Hello, student {student.Name}!");
            InitializeComponent();
        }

        private void buttonShowSubjects_Click(object sender, EventArgs e)
        {
            SubjectTable subjectTable = new SubjectTable();
            dataGridSubjects.DataSource = subjectTable.AllSubjects();

            dataGridSubjects.Refresh();
        }

        private void buttonClearTable_Click(object sender, EventArgs e)
        {
            SubjectTable subjectTable = new SubjectTable();

            try
            {
                subjectTable.Delete();
            }
            catch (Exception ex)
            {
                UtilityFunctions.ShowException(ex);
            }

            dataGridSubjects.DataSource = null; // ah yes
            //dataGridSubjects.Rows.Clear();
            dataGridSubjects.Refresh();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("why are you clicking this nonsense you fucking dumbass", "you just got MEMED!");
        }

        private void buttonSearchSubject_Click(object sender, EventArgs e)
        {
            string id = textBoxSubject.Text;

            dataGridSubjects.DataSource = (new SubjectTable()).FindSubjectById(id);
            dataGridSubjects.Refresh();
        }

        private void buttonOpenCrashLog_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("notepad");
        }

        private void buttonAddNewSubject_Click(object sender, EventArgs e)
        {
            var formAddSubject = new FormAddSubject();
            formAddSubject.ShowDialog();
            buttonShowSubjects_Click(sender, e);
        }
    }
}