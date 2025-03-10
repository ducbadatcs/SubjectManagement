namespace SubjectManagement
{
    partial class FormAddSubject
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
            this.labelName = new System.Windows.Forms.Label();
            this.subjectIDTextBox = new System.Windows.Forms.TextBox();
            this.subjectNameTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.subjectNumberOfCreditsTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.subjectRequiredNumberOfCreditsTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.subjectRequiredSubjectsTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.buttonAddSubject = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Location = new System.Drawing.Point(318, 53);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(68, 16);
            this.labelName.TabIndex = 0;
            this.labelName.Text = "Subject ID";
            // 
            // subjectIDTextBox
            // 
            this.subjectIDTextBox.Location = new System.Drawing.Point(422, 47);
            this.subjectIDTextBox.Name = "subjectIDTextBox";
            this.subjectIDTextBox.Size = new System.Drawing.Size(119, 22);
            this.subjectIDTextBox.TabIndex = 1;
            // 
            // subjectNameTextBox
            // 
            this.subjectNameTextBox.Location = new System.Drawing.Point(422, 118);
            this.subjectNameTextBox.Name = "subjectNameTextBox";
            this.subjectNameTextBox.Size = new System.Drawing.Size(199, 22);
            this.subjectNameTextBox.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(294, 124);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "Subject Name";
            // 
            // subjectNumberOfCreditsTextBox
            // 
            this.subjectNumberOfCreditsTextBox.Location = new System.Drawing.Point(422, 173);
            this.subjectNumberOfCreditsTextBox.Name = "subjectNumberOfCreditsTextBox";
            this.subjectNumberOfCreditsTextBox.Size = new System.Drawing.Size(119, 22);
            this.subjectNumberOfCreditsTextBox.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(222, 179);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(164, 16);
            this.label2.TabIndex = 4;
            this.label2.Text = "Subject Number Of Credits";
            // 
            // subjectRequiredNumberOfCreditsTextBox
            // 
            this.subjectRequiredNumberOfCreditsTextBox.Location = new System.Drawing.Point(422, 212);
            this.subjectRequiredNumberOfCreditsTextBox.Name = "subjectRequiredNumberOfCreditsTextBox";
            this.subjectRequiredNumberOfCreditsTextBox.Size = new System.Drawing.Size(119, 22);
            this.subjectRequiredNumberOfCreditsTextBox.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(163, 218);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(223, 16);
            this.label3.TabIndex = 6;
            this.label3.Text = "Subject Required Number Of Credits";
            // 
            // subjectRequiredSubjectsTextBox
            // 
            this.subjectRequiredSubjectsTextBox.Location = new System.Drawing.Point(422, 267);
            this.subjectRequiredSubjectsTextBox.Multiline = true;
            this.subjectRequiredSubjectsTextBox.Name = "subjectRequiredSubjectsTextBox";
            this.subjectRequiredSubjectsTextBox.Size = new System.Drawing.Size(199, 149);
            this.subjectRequiredSubjectsTextBox.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(127, 273);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(259, 16);
            this.label4.TabIndex = 8;
            this.label4.Text = "Required Subjects (List by ID, one per line)";
            // 
            // buttonAddSubject
            // 
            this.buttonAddSubject.Location = new System.Drawing.Point(698, 317);
            this.buttonAddSubject.Name = "buttonAddSubject";
            this.buttonAddSubject.Size = new System.Drawing.Size(121, 99);
            this.buttonAddSubject.TabIndex = 10;
            this.buttonAddSubject.Text = "Add Subject";
            this.buttonAddSubject.UseVisualStyleBackColor = true;
            this.buttonAddSubject.Click += new System.EventHandler(this.buttonAddSubject_Click);
            // 
            // FormAddSubject
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(852, 456);
            this.Controls.Add(this.buttonAddSubject);
            this.Controls.Add(this.subjectRequiredSubjectsTextBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.subjectRequiredNumberOfCreditsTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.subjectNumberOfCreditsTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.subjectNameTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.subjectIDTextBox);
            this.Controls.Add(this.labelName);
            this.Name = "FormAddSubject";
            this.Text = "Add Subject";
            this.Load += new System.EventHandler(this.FormAddSubject_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.TextBox subjectIDTextBox;
        private System.Windows.Forms.TextBox subjectNameTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox subjectNumberOfCreditsTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox subjectRequiredNumberOfCreditsTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox subjectRequiredSubjectsTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button buttonAddSubject;
    }
}