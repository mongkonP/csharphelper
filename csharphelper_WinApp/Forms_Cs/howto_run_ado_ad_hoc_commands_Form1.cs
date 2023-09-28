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
     public partial class howto_run_ado_ad_hoc_commands_Form1:Form
  { 


        public howto_run_ado_ad_hoc_commands_Form1()
        {
            InitializeComponent();
        }

        // The connection object.
        private OleDbConnection Conn;

        // Prepare the database connection.
        private void howto_run_ado_ad_hoc_commands_Form1_Load(object sender, EventArgs e)
        {
            // Compose the database file name.
            // This assumes it's in the executable's directory.
            string file_name = Application.StartupPath + "\\Books.accdb";

            // Connect.
            Conn = new OleDbConnection(
                "Provider=Microsoft.ACE.OLEDB.12.0;" +
                "Data Source=" + file_name + ";" +
                "Mode=Share Deny None");

            // Select the first sample command.
            cboSamples.SelectedIndex = 0;
        }

        // Display a sample command.
        private void cboSamples_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cboSamples.Text)
            {
                case "CREATE TABLE":
                    txtCommand.Text = "CREATE TABLE Employees(\n" +
                        "  FirstName TEXT(50),\n" +
                        "  LastName TEXT(50),\n" +
                        "  EmployeeId INTEGER PRIMARY KEY\n" +
                        ")";
                    break;
                case "INSERT INTO":
                    txtCommand.Text = "INSERT INTO Employees\n" +
                        "  (FirstName, LastName, EmployeeId)\n" +
                        "VALUES\n" +
                        "  ('Alice', 'Archer', 1001)";
                    break;
                case "DROP TABLE":
                    txtCommand.Text = "DROP TABLE Employees";
                    break;
            }
        }

        // Execute the command.
        private void btnExecute_Click(object sender, EventArgs e)
        {
            // Make a command object to represent the command.
            OleDbCommand cmd = new OleDbCommand();
            cmd.Connection = Conn;
            cmd.CommandText = txtCommand.Text;

            // Open the connection and execute the command.
            try
            {
                Conn.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Done");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error executing command.\n" + ex.Message);
            }
            finally
            {
                // Be sure to close the connection whether we succeed or fail.
                Conn.Close();
            }
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
            this.btnExecute = new System.Windows.Forms.Button();
            this.txtCommand = new System.Windows.Forms.TextBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.cboSamples = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // btnExecute
            // 
            this.btnExecute.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnExecute.Location = new System.Drawing.Point(150, 150);
            this.btnExecute.Name = "btnExecute";
            this.btnExecute.Size = new System.Drawing.Size(75, 23);
            this.btnExecute.TabIndex = 11;
            this.btnExecute.Text = "Execute";
            this.btnExecute.UseVisualStyleBackColor = true;
            this.btnExecute.Click += new System.EventHandler(this.btnExecute_Click);
            // 
            // txtCommand
            // 
            this.txtCommand.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCommand.Location = new System.Drawing.Point(15, 40);
            this.txtCommand.Multiline = true;
            this.txtCommand.Name = "txtCommand";
            this.txtCommand.Size = new System.Drawing.Size(347, 89);
            this.txtCommand.TabIndex = 10;
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(12, 16);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(100, 13);
            this.Label1.TabIndex = 9;
            this.Label1.Text = "Sample Commands:";
            // 
            // cboSamples
            // 
            this.cboSamples.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cboSamples.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSamples.FormattingEnabled = true;
            this.cboSamples.Items.AddRange(new object[] {
            "CREATE TABLE",
            "INSERT INTO",
            "DROP TABLE"});
            this.cboSamples.Location = new System.Drawing.Point(118, 13);
            this.cboSamples.Name = "cboSamples";
            this.cboSamples.Size = new System.Drawing.Size(244, 21);
            this.cboSamples.TabIndex = 8;
            this.cboSamples.SelectedIndexChanged += new System.EventHandler(this.cboSamples_SelectedIndexChanged);
            // 
            // howto_run_ado_ad_hoc_commands_Form1
            // 
            this.AcceptButton = this.btnExecute;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(374, 186);
            this.Controls.Add(this.btnExecute);
            this.Controls.Add(this.txtCommand);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.cboSamples);
            this.Name = "howto_run_ado_ad_hoc_commands_Form1";
            this.Text = "howto_run_ado_ad_hoc_commands";
            this.Load += new System.EventHandler(this.howto_run_ado_ad_hoc_commands_Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Button btnExecute;
        internal System.Windows.Forms.TextBox txtCommand;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.ComboBox cboSamples;
    }
}

