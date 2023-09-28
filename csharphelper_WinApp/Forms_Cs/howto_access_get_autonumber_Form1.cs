using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Data.OleDb;

 

namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_access_get_autonumber_Form1:Form
  { 


        public howto_access_get_autonumber_Form1()
        {
            InitializeComponent();
        }

        // The connection object.
        private OleDbConnection Conn;

        // Make the database connection.
        private void howto_access_get_autonumber_Form1_Load(object sender, EventArgs e)
        {
            // Make the connection object.
            const string db_name = "Students.mdb";
            Conn = new OleDbConnection(
                "Provider=Microsoft.ACE.OLEDB.12.0;" +
                "Data Source=" + db_name + ";" +
                "Mode=Share Deny None");
        }

        // Create a new Students record.
        private void btnCreate_Click(object sender, EventArgs e)
        {
            // Create the command.
            OleDbCommand cmd = new OleDbCommand(
                "INSERT INTO Students(FirstName, LastName) VALUES (?, ?)",
                Conn);
            cmd.Parameters.Add(new OleDbParameter("FirstName", txtFirstName.Text));
            cmd.Parameters.Add(new OleDbParameter("LastName", txtLastName.Text));

            // Execute the command.
            Conn.Open();
            cmd.ExecuteNonQuery();

            // Get the auto-number value.
            cmd = new OleDbCommand("SELECT @@IDENTITY", Conn);
            OleDbDataReader reader = cmd.ExecuteReader();

            // Read the value.
            if (!reader.Read())
            {
                MessageBox.Show("Error reading the auto-number value");
            }
            else
            {
                // Display the StudentID and other values.
                txtFirstNameResult.Text = txtFirstName.Text;
                txtLastNameResult.Text = txtLastName.Text;
                txtStudentId.Text = reader.GetValue(0).ToString();

                // Clear the input fields.
                txtFirstName.Clear();
                txtLastName.Clear();
            }

            // Close the connection.
            cmd.Dispose();
            Conn.Close();
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
            this.txtStudentId = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnCreate = new System.Windows.Forms.Button();
            this.txtLastName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtFirstName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtLastNameResult = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtFirstNameResult = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtStudentId
            // 
            this.txtStudentId.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtStudentId.Location = new System.Drawing.Point(164, 165);
            this.txtStudentId.Name = "txtStudentId";
            this.txtStudentId.ReadOnly = true;
            this.txtStudentId.Size = new System.Drawing.Size(100, 20);
            this.txtStudentId.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(97, 168);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 13);
            this.label5.TabIndex = 16;
            this.label5.Text = "Student ID:";
            // 
            // btnCreate
            // 
            this.btnCreate.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnCreate.Location = new System.Drawing.Point(143, 84);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(75, 23);
            this.btnCreate.TabIndex = 2;
            this.btnCreate.Text = "Create";
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // txtLastName
            // 
            this.txtLastName.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtLastName.Location = new System.Drawing.Point(164, 58);
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Size = new System.Drawing.Size(100, 20);
            this.txtLastName.TabIndex = 1;
            this.txtLastName.Text = "Stephens";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(97, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "Last Name:";
            // 
            // txtFirstName
            // 
            this.txtFirstName.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtFirstName.Location = new System.Drawing.Point(164, 32);
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Size = new System.Drawing.Size(100, 20);
            this.txtFirstName.TabIndex = 0;
            this.txtFirstName.Text = "Rod";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(97, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "First Name:";
            // 
            // txtLastNameResult
            // 
            this.txtLastNameResult.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtLastNameResult.Location = new System.Drawing.Point(164, 139);
            this.txtLastNameResult.Name = "txtLastNameResult";
            this.txtLastNameResult.ReadOnly = true;
            this.txtLastNameResult.Size = new System.Drawing.Size(100, 20);
            this.txtLastNameResult.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(97, 142);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 13);
            this.label3.TabIndex = 20;
            this.label3.Text = "Last Name:";
            // 
            // txtFirstNameResult
            // 
            this.txtFirstNameResult.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtFirstNameResult.Location = new System.Drawing.Point(164, 113);
            this.txtFirstNameResult.Name = "txtFirstNameResult";
            this.txtFirstNameResult.ReadOnly = true;
            this.txtFirstNameResult.Size = new System.Drawing.Size(100, 20);
            this.txtFirstNameResult.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(97, 116);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 13);
            this.label4.TabIndex = 18;
            this.label4.Text = "First Name:";
            // 
            // howto_access_get_autonumber_Form1
            // 
            this.AcceptButton = this.btnCreate;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(361, 216);
            this.Controls.Add(this.txtLastNameResult);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtFirstNameResult);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtStudentId);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnCreate);
            this.Controls.Add(this.txtLastName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtFirstName);
            this.Controls.Add(this.label1);
            this.Name = "howto_access_get_autonumber_Form1";
            this.Text = "howto_access_get_autonumber";
            this.Load += new System.EventHandler(this.howto_access_get_autonumber_Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtStudentId;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.TextBox txtLastName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtFirstName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtLastNameResult;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtFirstNameResult;
        private System.Windows.Forms.Label label4;
    }
}

