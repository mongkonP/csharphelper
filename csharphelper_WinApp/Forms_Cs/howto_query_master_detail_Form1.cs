using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Data.OleDb;

 

using howto_query_master_detail;
namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_query_master_detail_Form1:Form
  { 


        public howto_query_master_detail_Form1()
        {
            InitializeComponent();
        }

        private OleDbConnection Conn;

        // Build the list of students.
        private void howto_query_master_detail_Form1_Load(object sender, EventArgs e)
        {
            // Prepare the connection.
            string connect_string =
                "Provider=Microsoft.ACE.OLEDB.12.0;" +
                "Data Source=Students.mdb;" +
                "Mode=Share Deny None";
            Conn = new OleDbConnection(connect_string);

            // List the students.
            ListStudents();
        }

        // List the students in cboStudents.
        private void ListStudents()
        {
            string query = "SELECT StudentId, LastName, FirstName " +
                "FROM Addresses " +
                "ORDER BY LastName, FirstName";
            OleDbCommand cmd = new OleDbCommand(query, Conn);

            Conn.Open();
            using (OleDbDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    Student student = new Student(
                        (int)reader.GetValue(0),
                        (string)reader.GetValue(1),
                        (string)reader.GetValue(2));
                    cboStudents.Items.Add(student);
                }
            }
            Conn.Close();            
        }

        // Display the data for the selected student.
        private void cboStudents_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Get the selected student.
            Student student = cboStudents.SelectedItem as Student;

            // Get the rest of the student's address data.
            string address_query = "SELECT Street, City, State, Zip " +
                "FROM Addresses WHERE StudentId=" + student.StudentId;
            OleDbCommand address_cmd = new OleDbCommand(address_query, Conn);

            Conn.Open();
            using (OleDbDataReader reader = address_cmd.ExecuteReader())
            {
                // Get the first (and hopefully last) row.
                if (reader.Read())
                {
                    txtStreet.Text = (string)reader.GetValue(0);
                    txtCity.Text = (string)reader.GetValue(1);
                    txtState.Text = (string)reader.GetValue(2);
                    txtZip.Text = (string)reader.GetValue(3);
                }
            }

            // Get the student's test scores.
            lstScores.Items.Clear();
            string scores_query = "SELECT TestNumber, Score " +
                "FROM TestScores WHERE StudentId=" + student.StudentId + " " +
                "ORDER BY TestNumber";
            OleDbCommand scores_cmd = new OleDbCommand(scores_query, Conn);

            int test_total = 0;
            int num_scores = 0;
            using (OleDbDataReader reader = scores_cmd.ExecuteReader())
            {
                // Get the next row.
                while (reader.Read())
                {
                    lstScores.Items.Add("Test " +
                        (int)reader.GetValue(0) + ": " +
                        (int)reader.GetValue(1));
                    test_total += (int)reader.GetValue(1);
                    num_scores++;
                }
            }
            Conn.Close();

            // Display the calculated average.
            if (num_scores == 0) txtAverage.Text = "0";
            else txtAverage.Text = (test_total / num_scores).ToString("0.0");
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
            this.label1 = new System.Windows.Forms.Label();
            this.cboStudents = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lstScores = new System.Windows.Forms.ListBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtZip = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtState = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtCity = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtStreet = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtAverage = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Student:";
            // 
            // cboStudents
            // 
            this.cboStudents.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cboStudents.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboStudents.FormattingEnabled = true;
            this.cboStudents.Location = new System.Drawing.Point(65, 12);
            this.cboStudents.Name = "cboStudents";
            this.cboStudents.Size = new System.Drawing.Size(250, 21);
            this.cboStudents.TabIndex = 1;
            this.cboStudents.SelectedIndexChanged += new System.EventHandler(this.cboStudents_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.txtAverage);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.lstScores);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtZip);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtState);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtCity);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtStreet);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(12, 39);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(303, 236);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Information";
            // 
            // lstScores
            // 
            this.lstScores.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lstScores.FormattingEnabled = true;
            this.lstScores.IntegralHeight = false;
            this.lstScores.Location = new System.Drawing.Point(26, 123);
            this.lstScores.MultiColumn = true;
            this.lstScores.Name = "lstScores";
            this.lstScores.Size = new System.Drawing.Size(271, 81);
            this.lstScores.TabIndex = 10;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(23, 100);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(67, 13);
            this.label6.TabIndex = 8;
            this.label6.Text = "Test Scores:";
            // 
            // txtZip
            // 
            this.txtZip.Location = new System.Drawing.Point(155, 71);
            this.txtZip.Name = "txtZip";
            this.txtZip.Size = new System.Drawing.Size(74, 20);
            this.txtZip.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(122, 74);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(27, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "ZIP:";
            // 
            // txtState
            // 
            this.txtState.Location = new System.Drawing.Point(67, 71);
            this.txtState.Name = "txtState";
            this.txtState.Size = new System.Drawing.Size(33, 20);
            this.txtState.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(23, 74);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "State:";
            // 
            // txtCity
            // 
            this.txtCity.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCity.Location = new System.Drawing.Point(67, 45);
            this.txtCity.Name = "txtCity";
            this.txtCity.Size = new System.Drawing.Size(230, 20);
            this.txtCity.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(23, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(27, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "City:";
            // 
            // txtStreet
            // 
            this.txtStreet.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtStreet.Location = new System.Drawing.Point(67, 19);
            this.txtStreet.Name = "txtStreet";
            this.txtStreet.Size = new System.Drawing.Size(230, 20);
            this.txtStreet.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Street:";
            // 
            // txtAverage
            // 
            this.txtAverage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtAverage.Location = new System.Drawing.Point(79, 210);
            this.txtAverage.Name = "txtAverage";
            this.txtAverage.Size = new System.Drawing.Size(39, 20);
            this.txtAverage.TabIndex = 12;
            this.txtAverage.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(23, 213);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(50, 13);
            this.label7.TabIndex = 11;
            this.label7.Text = "Average:";
            // 
            // howto_query_master_detail_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(327, 287);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.cboStudents);
            this.Controls.Add(this.label1);
            this.Name = "howto_query_master_detail_Form1";
            this.Text = "howto_query_master_detail";
            this.Load += new System.EventHandler(this.howto_query_master_detail_Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboStudents;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtStreet;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCity;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtState;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListBox lstScores;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtZip;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtAverage;
        private System.Windows.Forms.Label label7;
    }
}

