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
     public partial class howto_sql_injection_Form1:Form
  { 


        public howto_sql_injection_Form1()
        {
            InitializeComponent();
        }

        // The connection object.
        private OleDbConnection Conn;

        // Create the connection object.
        private void howto_sql_injection_Form1_Load(object sender, EventArgs e)
        {
            const string db_name = "Employees.mdb";
            Conn = new OleDbConnection(
                "Provider=Microsoft.ACE.OLEDB.12.0;" +
                "Data Source=" + db_name + ";" +
                "Mode=Share Deny None");
        }

        // Log in by using a composed query.
        private void btnQuery_Click(object sender, EventArgs e)
        {
            string user_name = txtUsername.Text;
            string password = txtPassword.Text;
            string query =
                "SELECT COUNT (*) FROM Employees WHERE " +
                "UserName='" + user_name +
                "' AND Password='" + password + "'";
            txtQuery.Text = query;
            OleDbCommand cmd = new OleDbCommand(query, Conn);
            Conn.Open();

            int count = 0;
            try
            {
                count = (int)cmd.ExecuteScalar();
            }
            catch (Exception)
            {
                count = 0;
            }

            Conn.Close();
            if (count != 0)
            {
                MessageBox.Show("Welcome " + txtUsername.Text);
            }
            else
            {
                MessageBox.Show("Invalid User Name/Password");
            }
        }

        // Use a query removing quotes within the fields.
        private void btnRemoveQuotes_Click(object sender, EventArgs e)
        {
            string user_name = txtUsername.Text.Replace("'", "");
            user_name = user_name.Replace("\"", "");
            string password = txtPassword.Text.Replace("'", "");
            password = password.Replace("\"", "");
            string query =
                "SELECT COUNT (*) FROM Employees WHERE " +
                "UserName='" + user_name +
                "' AND Password='" + password + "'";
            txtQuery.Text = query;
            OleDbCommand cmd = new OleDbCommand(query, Conn);
            Conn.Open();

            int count = 0;
            try
            {
                count = (int)cmd.ExecuteScalar();
            }
            catch (Exception)
            {
                count = 0;
            }

            Conn.Close();
            if (count != 0)
            {
                MessageBox.Show("Welcome " + txtUsername.Text);
            }
            else
            {
                MessageBox.Show("Invalid User Name/Password");
            }
        }

        // Use command parameters.
        private void btnParameters_Click(object sender, EventArgs e)
        {
            string user_name = txtUsername.Text;
            string password = txtPassword.Text;
            string query = "SELECT UserName, Password FROM Employees " +
                "WHERE UserName=? AND Password=?";
            txtQuery.Clear();

            OleDbCommand cmd = new OleDbCommand(query, Conn);
            cmd.Parameters.AddWithValue("UserName", user_name);
            cmd.Parameters.AddWithValue("Password", password);
            Conn.Open();

            bool login_ok = false;
            try
            {
                // Execute the command.
                OleDbDataReader reader  = cmd.ExecuteReader();

                // Read the first record.
                if (reader.Read())
                {
                    // Make sure the user name and password match.
                    if ((reader.GetValue(0).ToString() == user_name) &&
                        (reader.GetValue(1).ToString() == password))
                            login_ok = true;

                    // Make sure there's only one matching record.
                    if (reader.Read()) login_ok = false;
                }
            }
            catch (Exception)
            {
                login_ok = false;
            }

            Conn.Close();
            if (login_ok)
            {
                MessageBox.Show("Welcome " + txtUsername.Text);
            }
            else
            {
                MessageBox.Show("Invalid User Name/Password");
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnQuery = new System.Windows.Forms.Button();
            this.btnRemoveQuotes = new System.Windows.Forms.Button();
            this.btnParameters = new System.Windows.Forms.Button();
            this.txtQuery = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Username:";
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(76, 12);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(122, 20);
            this.txtUsername.TabIndex = 1;
            this.txtUsername.Text = "BadGuy";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(76, 38);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(122, 20);
            this.txtPassword.TabIndex = 3;
            this.txtPassword.Text = "AAA\' OR \'X\'=\'X";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Password:";
            // 
            // btnQuery
            // 
            this.btnQuery.Location = new System.Drawing.Point(15, 86);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(122, 23);
            this.btnQuery.TabIndex = 4;
            this.btnQuery.Text = "Query";
            this.btnQuery.UseVisualStyleBackColor = true;
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // btnRemoveQuotes
            // 
            this.btnRemoveQuotes.Location = new System.Drawing.Point(15, 115);
            this.btnRemoveQuotes.Name = "btnRemoveQuotes";
            this.btnRemoveQuotes.Size = new System.Drawing.Size(122, 23);
            this.btnRemoveQuotes.TabIndex = 5;
            this.btnRemoveQuotes.Text = "Remove Quotes";
            this.btnRemoveQuotes.UseVisualStyleBackColor = true;
            this.btnRemoveQuotes.Click += new System.EventHandler(this.btnRemoveQuotes_Click);
            // 
            // btnParameters
            // 
            this.btnParameters.Location = new System.Drawing.Point(15, 176);
            this.btnParameters.Name = "btnParameters";
            this.btnParameters.Size = new System.Drawing.Size(122, 23);
            this.btnParameters.TabIndex = 6;
            this.btnParameters.Text = "Parameters";
            this.btnParameters.UseVisualStyleBackColor = true;
            this.btnParameters.Click += new System.EventHandler(this.btnParameters_Click);
            // 
            // txtQuery
            // 
            this.txtQuery.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtQuery.Location = new System.Drawing.Point(12, 144);
            this.txtQuery.Name = "txtQuery";
            this.txtQuery.ReadOnly = true;
            this.txtQuery.Size = new System.Drawing.Size(250, 20);
            this.txtQuery.TabIndex = 7;
            this.txtQuery.TabStop = false;
            // 
            // howto_sql_injection_Form1
            // 
            this.AcceptButton = this.btnQuery;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(274, 206);
            this.Controls.Add(this.txtQuery);
            this.Controls.Add(this.btnParameters);
            this.Controls.Add(this.btnRemoveQuotes);
            this.Controls.Add(this.btnQuery);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.label1);
            this.Name = "howto_sql_injection_Form1";
            this.Text = "howto_sql_injection";
            this.Load += new System.EventHandler(this.howto_sql_injection_Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnQuery;
        private System.Windows.Forms.Button btnRemoveQuotes;
        private System.Windows.Forms.Button btnParameters;
        private System.Windows.Forms.TextBox txtQuery;
    }
}

