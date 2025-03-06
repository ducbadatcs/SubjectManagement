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
            ((System.ComponentModel.ISupportInitialize)(this.dataGridSubjects)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonShowSubjects
            // 
            this.buttonShowSubjects.Location = new System.Drawing.Point(12, 13);
            this.buttonShowSubjects.Name = "buttonShowSubjects";
            this.buttonShowSubjects.Size = new System.Drawing.Size(119, 61);
            this.buttonShowSubjects.TabIndex = 0;
            this.buttonShowSubjects.Text = "Show Subjects";
            this.buttonShowSubjects.UseVisualStyleBackColor = true;
            this.buttonShowSubjects.Click += new System.EventHandler(this.buttonShowSubjects_Click);
            // 
            // dataGridSubjects
            // 
            this.dataGridSubjects.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridSubjects.Location = new System.Drawing.Point(293, 12);
            this.dataGridSubjects.Name = "dataGridSubjects";
            this.dataGridSubjects.RowHeadersWidth = 51;
            this.dataGridSubjects.RowTemplate.Height = 24;
            this.dataGridSubjects.Size = new System.Drawing.Size(949, 562);
            this.dataGridSubjects.TabIndex = 1;
            // 
            // buttonClearTable
            // 
            this.buttonClearTable.Location = new System.Drawing.Point(12, 106);
            this.buttonClearTable.Name = "buttonClearTable";
            this.buttonClearTable.Size = new System.Drawing.Size(119, 61);
            this.buttonClearTable.TabIndex = 2;
            this.buttonClearTable.Text = "Clear Table";
            this.buttonClearTable.UseVisualStyleBackColor = true;
            this.buttonClearTable.Click += new System.EventHandler(this.buttonClearTable_Click);
            // 
            // textBoxSubject
            // 
            this.textBoxSubject.Location = new System.Drawing.Point(12, 240);
            this.textBoxSubject.Name = "textBoxSubject";
            this.textBoxSubject.Size = new System.Drawing.Size(201, 22);
            this.textBoxSubject.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 205);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 16);
            this.label1.TabIndex = 4;
            this.label1.Text = "Find Subject by ID";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // buttonSearchSubject
            // 
            this.buttonSearchSubject.Location = new System.Drawing.Point(12, 296);
            this.buttonSearchSubject.Name = "buttonSearchSubject";
            this.buttonSearchSubject.Size = new System.Drawing.Size(119, 61);
            this.buttonSearchSubject.TabIndex = 5;
            this.buttonSearchSubject.Text = "Search Subject";
            this.buttonSearchSubject.UseVisualStyleBackColor = true;
            this.buttonSearchSubject.Click += new System.EventHandler(this.buttonSearchSubject_Click);
            // 
            // buttonOpenCrashLog
            // 
            this.buttonOpenCrashLog.Location = new System.Drawing.Point(12, 513);
            this.buttonOpenCrashLog.Name = "buttonOpenCrashLog";
            this.buttonOpenCrashLog.Size = new System.Drawing.Size(119, 61);
            this.buttonOpenCrashLog.TabIndex = 6;
            this.buttonOpenCrashLog.Text = "Open Crash Log";
            this.buttonOpenCrashLog.UseVisualStyleBackColor = true;
            this.buttonOpenCrashLog.Click += new System.EventHandler(this.buttonOpenCrashLog_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1254, 587);
            this.Controls.Add(this.buttonOpenCrashLog);
            this.Controls.Add(this.buttonSearchSubject);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxSubject);
            this.Controls.Add(this.buttonClearTable);
            this.Controls.Add(this.dataGridSubjects);
            this.Controls.Add(this.buttonShowSubjects);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridSubjects)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
        }

        #endregion

        private System.Windows.Forms.Button buttonShowSubjects;
        private System.Windows.Forms.DataGridView dataGridSubjects;
        private System.Windows.Forms.Button buttonClearTable;
        private System.Windows.Forms.TextBox textBoxSubject;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonSearchSubject;
        private System.Windows.Forms.Button buttonOpenCrashLog;
    }
}

