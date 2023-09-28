using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

 

using howto_default_property;
namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_default_property_Form1:Form
  { 


        public howto_default_property_Form1()
        {
            InitializeComponent();
        }

        // The grades.
        private GradeCollection Grades = new GradeCollection();

        // Create some students.
        private void howto_default_property_Form1_Load(object sender, EventArgs e)
        {
            Grades["Alice"] = 100;
            Grades["Ben"] = 90;
            Grades["Cindy"] = 80;
            Grades["Dan"] = 100;
            Grades["Emma"] = 90;
        }

        // Save or update a student's grade.
        private void btnSet_Click(object sender, EventArgs e)
        {
            try
            {
                Grades[txtStudent.Text] = int.Parse(txtGrade.Text);
                txtStudent.Clear();
                txtGrade.Clear();
                txtStudent.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // Get a student's grade.
        private void btnGet_Click(object sender, EventArgs e)
        {
            try
            {
                txtGrade.Text = Grades[txtStudent.Text].ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // List students with the entered score.
        private void btnList_Click(object sender, EventArgs e)
        {
            int score = int.Parse(txtGrade.Text);
            List<string> students = Grades[score];
            lstStudents.DataSource = students;
        }
    

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
            this.lstStudents = new System.Windows.Forms.ListBox();
            this.btnList = new System.Windows.Forms.Button();
            this.btnGet = new System.Windows.Forms.Button();
            this.txtGrade = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSet = new System.Windows.Forms.Button();
            this.txtStudent = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lstStudents
            // 
            this.lstStudents.FormattingEnabled = true;
            this.lstStudents.Location = new System.Drawing.Point(12, 95);
            this.lstStudents.Name = "lstStudents";
            this.lstStudents.Size = new System.Drawing.Size(153, 95);
            this.lstStudents.TabIndex = 13;
            // 
            // btnList
            // 
            this.btnList.Location = new System.Drawing.Point(12, 66);
            this.btnList.Name = "btnList";
            this.btnList.Size = new System.Drawing.Size(75, 23);
            this.btnList.TabIndex = 12;
            this.btnList.Text = "List";
            this.btnList.UseVisualStyleBackColor = true;
            this.btnList.Click += new System.EventHandler(this.btnList_Click);
            // 
            // btnGet
            // 
            this.btnGet.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGet.Location = new System.Drawing.Point(222, 38);
            this.btnGet.Name = "btnGet";
            this.btnGet.Size = new System.Drawing.Size(75, 23);
            this.btnGet.TabIndex = 10;
            this.btnGet.Text = "Get";
            this.btnGet.UseVisualStyleBackColor = true;
            this.btnGet.Click += new System.EventHandler(this.btnGet_Click);
            // 
            // txtGrade
            // 
            this.txtGrade.Location = new System.Drawing.Point(65, 40);
            this.txtGrade.Name = "txtGrade";
            this.txtGrade.Size = new System.Drawing.Size(100, 20);
            this.txtGrade.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Grade:";
            // 
            // btnSet
            // 
            this.btnSet.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSet.Location = new System.Drawing.Point(222, 12);
            this.btnSet.Name = "btnSet";
            this.btnSet.Size = new System.Drawing.Size(75, 23);
            this.btnSet.TabIndex = 9;
            this.btnSet.Text = "Set";
            this.btnSet.UseVisualStyleBackColor = true;
            this.btnSet.Click += new System.EventHandler(this.btnSet_Click);
            // 
            // txtStudent
            // 
            this.txtStudent.Location = new System.Drawing.Point(65, 14);
            this.txtStudent.Name = "txtStudent";
            this.txtStudent.Size = new System.Drawing.Size(100, 20);
            this.txtStudent.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Student:";
            // 
            // howto_default_property_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(309, 201);
            this.Controls.Add(this.lstStudents);
            this.Controls.Add(this.btnList);
            this.Controls.Add(this.btnGet);
            this.Controls.Add(this.txtGrade);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnSet);
            this.Controls.Add(this.txtStudent);
            this.Controls.Add(this.label1);
            this.Name = "howto_default_property_Form1";
            this.Text = "howto_default_property";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lstStudents;
        private System.Windows.Forms.Button btnList;
        private System.Windows.Forms.Button btnGet;
        private System.Windows.Forms.TextBox txtGrade;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSet;
        private System.Windows.Forms.TextBox txtStudent;
        private System.Windows.Forms.Label label1;
    }
}

