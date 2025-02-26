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
            this.dataGridSubjects.Location = new System.Drawing.Point(466, 13);
            this.dataGridSubjects.Name = "dataGridSubjects";
            this.dataGridSubjects.RowHeadersWidth = 51;
            this.dataGridSubjects.RowTemplate.Height = 24;
            this.dataGridSubjects.Size = new System.Drawing.Size(570, 562);
            this.dataGridSubjects.TabIndex = 1;
            this.dataGridSubjects.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridSubjects_CellContentClick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1048, 587);
            this.Controls.Add(this.dataGridSubjects);
            this.Controls.Add(this.buttonShowSubjects);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridSubjects)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonShowSubjects;
        private System.Windows.Forms.DataGridView dataGridSubjects;
    }
}

