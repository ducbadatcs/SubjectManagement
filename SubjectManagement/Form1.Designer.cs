using System;

namespace SubjectManagement
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonShowSubjects = new System.Windows.Forms.Button();
            this.dataGridSubjects = new System.Windows.Forms.DataGridView();
            this.buttonClearTable = new System.Windows.Forms.Button();
            this.textBoxSubject = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonSearchSubject = new System.Windows.Forms.Button();
            this.buttonOpenCrashLog = new System.Windows.Forms.Button();
            this.buttonAddNewSubject = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.dataGridViewStudentSubjects = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxSignUpSubject = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.buttonSignUpForSubject = new System.Windows.Forms.Button();
            this.buttonRemoveSubjectFromDatabase = new System.Windows.Forms.Button();
            this.buttonShowSubjectsSignedUp = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridSubjects)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewStudentSubjects)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonShowSubjects
            // 
            this.buttonShowSubjects.Location = new System.Drawing.Point(12, 14);
            this.buttonShowSubjects.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonShowSubjects.Name = "buttonShowSubjects";
            this.buttonShowSubjects.Size = new System.Drawing.Size(119, 62);
            this.buttonShowSubjects.TabIndex = 0;
            this.buttonShowSubjects.Text = "Show Subjects";
            this.buttonShowSubjects.UseVisualStyleBackColor = true;
            this.buttonShowSubjects.Click += new System.EventHandler(this.buttonShowSubjects_Click);
            // 
            // dataGridSubjects
            // 
            this.dataGridSubjects.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridSubjects.Location = new System.Drawing.Point(237, 57);
            this.dataGridSubjects.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridSubjects.Name = "dataGridSubjects";
            this.dataGridSubjects.RowHeadersWidth = 51;
            this.dataGridSubjects.RowTemplate.Height = 24;
            this.dataGridSubjects.Size = new System.Drawing.Size(684, 206);
            this.dataGridSubjects.TabIndex = 1;
            // 
            // buttonClearTable
            // 
            this.buttonClearTable.Location = new System.Drawing.Point(12, 106);
            this.buttonClearTable.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonClearTable.Name = "buttonClearTable";
            this.buttonClearTable.Size = new System.Drawing.Size(119, 62);
            this.buttonClearTable.TabIndex = 2;
            this.buttonClearTable.Text = "Clear Table";
            this.buttonClearTable.UseVisualStyleBackColor = true;
            this.buttonClearTable.Click += new System.EventHandler(this.buttonClearTable_Click);
            // 
            // textBoxSubject
            // 
            this.textBoxSubject.Location = new System.Drawing.Point(12, 240);
            this.textBoxSubject.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxSubject.Name = "textBoxSubject";
            this.textBoxSubject.Size = new System.Drawing.Size(201, 22);
            this.textBoxSubject.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 206);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(118, 16);
            this.label1.TabIndex = 4;
            this.label1.Text = "Find Subject via ID";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // buttonSearchSubject
            // 
            this.buttonSearchSubject.Location = new System.Drawing.Point(12, 295);
            this.buttonSearchSubject.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonSearchSubject.Name = "buttonSearchSubject";
            this.buttonSearchSubject.Size = new System.Drawing.Size(119, 62);
            this.buttonSearchSubject.TabIndex = 5;
            this.buttonSearchSubject.Text = "Search Subject";
            this.buttonSearchSubject.UseVisualStyleBackColor = true;
            this.buttonSearchSubject.Click += new System.EventHandler(this.buttonSearchSubject_Click);
            // 
            // buttonOpenCrashLog
            // 
            this.buttonOpenCrashLog.Location = new System.Drawing.Point(12, 558);
            this.buttonOpenCrashLog.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonOpenCrashLog.Name = "buttonOpenCrashLog";
            this.buttonOpenCrashLog.Size = new System.Drawing.Size(119, 62);
            this.buttonOpenCrashLog.TabIndex = 6;
            this.buttonOpenCrashLog.Text = "Open Notepad (for no reason)";
            this.buttonOpenCrashLog.UseVisualStyleBackColor = true;
            this.buttonOpenCrashLog.Click += new System.EventHandler(this.buttonOpenCrashLog_Click);
            // 
            // buttonAddNewSubject
            // 
            this.buttonAddNewSubject.Location = new System.Drawing.Point(1019, 57);
            this.buttonAddNewSubject.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonAddNewSubject.Name = "buttonAddNewSubject";
            this.buttonAddNewSubject.Size = new System.Drawing.Size(119, 62);
            this.buttonAddNewSubject.TabIndex = 7;
            this.buttonAddNewSubject.Text = "Add Subject To Database";
            this.buttonAddNewSubject.UseVisualStyleBackColor = true;
            this.buttonAddNewSubject.Click += new System.EventHandler(this.buttonAddNewSubject_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(235, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(119, 16);
            this.label2.TabIndex = 8;
            this.label2.Text = "Available Subjects";
            // 
            // dataGridViewStudentSubjects
            // 
            this.dataGridViewStudentSubjects.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewStudentSubjects.Location = new System.Drawing.Point(237, 390);
            this.dataGridViewStudentSubjects.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridViewStudentSubjects.Name = "dataGridViewStudentSubjects";
            this.dataGridViewStudentSubjects.RowHeadersWidth = 51;
            this.dataGridViewStudentSubjects.RowTemplate.Height = 24;
            this.dataGridViewStudentSubjects.Size = new System.Drawing.Size(684, 228);
            this.dataGridViewStudentSubjects.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(235, 357);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 16);
            this.label3.TabIndex = 10;
            this.label3.Text = "Your Subjects";
            // 
            // textBoxSignUpSubject
            // 
            this.textBoxSignUpSubject.Location = new System.Drawing.Point(1019, 416);
            this.textBoxSignUpSubject.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxSignUpSubject.Name = "textBoxSignUpSubject";
            this.textBoxSignUpSubject.Size = new System.Drawing.Size(232, 22);
            this.textBoxSignUpSubject.TabIndex = 11;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(1019, 390);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(167, 16);
            this.label4.TabIndex = 12;
            this.label4.Text = "Sign Up For Subject with ID";
            // 
            // buttonSignUpForSubject
            // 
            this.buttonSignUpForSubject.Location = new System.Drawing.Point(1019, 466);
            this.buttonSignUpForSubject.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonSignUpForSubject.Name = "buttonSignUpForSubject";
            this.buttonSignUpForSubject.Size = new System.Drawing.Size(119, 62);
            this.buttonSignUpForSubject.TabIndex = 13;
            this.buttonSignUpForSubject.Text = "Sign Up For Subject";
            this.buttonSignUpForSubject.UseVisualStyleBackColor = true;
            this.buttonSignUpForSubject.Click += new System.EventHandler(this.buttonSignUpForSubject_Click);
            // 
            // buttonRemoveSubjectFromDatabase
            // 
            this.buttonRemoveSubjectFromDatabase.Location = new System.Drawing.Point(12, 390);
            this.buttonRemoveSubjectFromDatabase.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonRemoveSubjectFromDatabase.Name = "buttonRemoveSubjectFromDatabase";
            this.buttonRemoveSubjectFromDatabase.Size = new System.Drawing.Size(119, 62);
            this.buttonRemoveSubjectFromDatabase.TabIndex = 14;
            this.buttonRemoveSubjectFromDatabase.Text = "Remove Subject From Database";
            this.buttonRemoveSubjectFromDatabase.UseVisualStyleBackColor = true;
            this.buttonRemoveSubjectFromDatabase.Click += new System.EventHandler(this.buttonRemoveSubjectFromDatabase_Click);
            // 
            // buttonShowSubjectsSignedUp
            // 
            this.buttonShowSubjectsSignedUp.Location = new System.Drawing.Point(1019, 556);
            this.buttonShowSubjectsSignedUp.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonShowSubjectsSignedUp.Name = "buttonShowSubjectsSignedUp";
            this.buttonShowSubjectsSignedUp.Size = new System.Drawing.Size(119, 62);
            this.buttonShowSubjectsSignedUp.TabIndex = 15;
            this.buttonShowSubjectsSignedUp.Text = "Show Subjects Signed Up";
            this.buttonShowSubjectsSignedUp.UseVisualStyleBackColor = true;
            this.buttonShowSubjectsSignedUp.Click += new System.EventHandler(this.buttonShowSubjectsSignedUp_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1285, 630);
            this.Controls.Add(this.buttonShowSubjectsSignedUp);
            this.Controls.Add(this.buttonRemoveSubjectFromDatabase);
            this.Controls.Add(this.buttonSignUpForSubject);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBoxSignUpSubject);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dataGridViewStudentSubjects);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.buttonAddNewSubject);
            this.Controls.Add(this.buttonOpenCrashLog);
            this.Controls.Add(this.buttonSearchSubject);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxSubject);
            this.Controls.Add(this.buttonClearTable);
            this.Controls.Add(this.dataGridSubjects);
            this.Controls.Add(this.buttonShowSubjects);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridSubjects)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewStudentSubjects)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            buttonShowSubjects_Click(sender, e);
            buttonShowSubjectsSignedUp_Click(sender, e);
        }

        #endregion

        private System.Windows.Forms.Button buttonShowSubjects;
        private System.Windows.Forms.DataGridView dataGridSubjects;
        private System.Windows.Forms.Button buttonClearTable;
        private System.Windows.Forms.TextBox textBoxSubject;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonSearchSubject;
        private System.Windows.Forms.Button buttonOpenCrashLog;
        private System.Windows.Forms.Button buttonAddNewSubject;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dataGridViewStudentSubjects;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxSignUpSubject;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button buttonSignUpForSubject;
        private System.Windows.Forms.Button buttonRemoveSubjectFromDatabase;
        private System.Windows.Forms.Button buttonShowSubjectsSignedUp;
    }
}

