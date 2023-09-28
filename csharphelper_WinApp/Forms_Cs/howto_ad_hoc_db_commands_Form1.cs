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
     public partial class howto_ad_hoc_db_commands_Form1:Form
  { 


        public howto_ad_hoc_db_commands_Form1()
        {
            InitializeComponent();
        }

        // The connection object.
        private OleDbConnection Conn;

        // Prepare the connection to open later.
        private void howto_ad_hoc_db_commands_Form1_Load(object sender, EventArgs e)
        {
            // Compose the database file name.
            // This assumes it's in the executable's directory.
            string file_name = Application.StartupPath + "\\Books.mdb";

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
                    txtCommand.Text = "CREATE TABLE Employees(\r\n" +
                        "  FirstName TEXT(50),\r\n" +
                        "  LastName TEXT(50),\r\n" +
                        "  EmployeeId INTEGER\r\n" +
                        ")";
                    break;
                case "INSERT":
                    txtCommand.Text = "INSERT INTO Employees\r\n" +
                        "  (FirstName, LastName, EmployeeId)\r\n" +
                        "VALUES\r\n" +
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
            OleDbCommand cmd = new OleDbCommand();
            cmd.Connection = Conn;
            cmd.CommandText = txtCommand.Text;

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
            this.cboSamples = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCommand = new System.Windows.Forms.TextBox();
            this.btnExecute = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cboSamples
            // 
            this.cboSamples.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cboSamples.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSamples.FormattingEnabled = true;
            this.cboSamples.Items.AddRange(new object[] {
            "CREATE TABLE",
            "INSERT",
            "DROP TABLE"});
            this.cboSamples.Location = new System.Drawing.Point(118, 12);
            this.cboSamples.Name = "cboSamples";
            this.cboSamples.Size = new System.Drawing.Size(212, 21);
            this.cboSamples.TabIndex = 0;
            this.cboSamples.SelectedIndexChanged += new System.EventHandler(this.cboSamples_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Sample Commands:";
            // 
            // txtCommand
            // 
            this.txtCommand.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCommand.Location = new System.Drawing.Point(11, 48);
            this.txtCommand.Multiline = true;
            this.txtCommand.Name = "txtCommand";
            this.txtCommand.Size = new System.Drawing.Size(319, 79);
            this.txtCommand.TabIndex = 2;
            // 
            // btnExecute
            // 
            this.btnExecute.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnExecute.Location = new System.Drawing.Point(134, 143);
            this.btnExecute.Name = "btnExecute";
            this.btnExecute.Size = new System.Drawing.Size(75, 23);
            this.btnExecute.TabIndex = 3;
            this.btnExecute.Text = "Execute";
            this.btnExecute.UseVisualStyleBackColor = true;
            this.btnExecute.Click += new System.EventHandler(this.btnExecute_Click);
            // 
            // howto_ad_hoc_db_commands_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(343, 178);
            this.Controls.Add(this.btnExecute);
            this.Controls.Add(this.txtCommand);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cboSamples);
            this.Name = "howto_ad_hoc_db_commands_Form1";
            this.Text = "howto_ad_hoc_db_commands";
            this.Load += new System.EventHandler(this.howto_ad_hoc_db_commands_Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cboSamples;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCommand;
        private System.Windows.Forms.Button btnExecute;
    }
}

