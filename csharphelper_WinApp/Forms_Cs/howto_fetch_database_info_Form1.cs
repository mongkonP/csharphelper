using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Data.OleDb;

// Add the database to the project and set its
// "Copy to Output Directory" property to "Copy if Newer."

 

namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_fetch_database_info_Form1:Form
  { 


        public howto_fetch_database_info_Form1()
        {
            InitializeComponent();
        }

        // The database connection.
        private OleDbConnection Conn;

        // Display a list of titles.
        private void howto_fetch_database_info_Form1_Load(object sender, EventArgs e)
        {
            // Compose the database file name.
            // This assumes it's in the executable's directory.
            string db_name = Application.StartupPath + "\\Books.mdb";

            // Connect to the database
            Conn = new OleDbConnection(
                "Provider=Microsoft.ACE.OLEDB.12.0;" +
                "Data Source=" + db_name + ";" +
                "Mode=Share Deny None");

            // Get the titles.
            OleDbCommand cmd = new OleDbCommand(
                "SELECT Title FROM Books ORDER BY Title",
                Conn);
            Conn.Open();
            OleDbDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                lstTitles.Items.Add(reader.GetValue(0));
            }
            reader.Close();
            Conn.Close();
        }

        // Display information about the selected title.
        private void lstTitles_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstTitles.SelectedIndex < 0) return;

            // Make a command object to get information about the title.
            string title = lstTitles.SelectedItem.ToString().Replace("'", "''");
            OleDbCommand cmd = new OleDbCommand(
                "SELECT * FROM Books WHERE Title='" +
                title + "'",
                Conn);

            // Execute the command.
            cmd.Connection = Conn;
            Conn.Open();
            OleDbDataReader reader = cmd.ExecuteReader();
            reader.Read();

            // Display the text data.
            txtURL.Text = reader["URL"].ToString();
            txtYear.Text = reader["Year"].ToString();
            txtISBN.Text = reader["ISBN"].ToString();
            txtPages.Text = reader["Pages"].ToString();

            // Clean up.
            reader.Close();
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
            this.txtPages = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtISBN = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtYear = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtURL = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lstTitles = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // txtPages
            // 
            this.txtPages.Location = new System.Drawing.Point(58, 178);
            this.txtPages.Name = "txtPages";
            this.txtPages.Size = new System.Drawing.Size(111, 20);
            this.txtPages.TabIndex = 26;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 181);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 13);
            this.label4.TabIndex = 25;
            this.label4.Text = "Pages:";
            // 
            // txtISBN
            // 
            this.txtISBN.Location = new System.Drawing.Point(58, 152);
            this.txtISBN.Name = "txtISBN";
            this.txtISBN.Size = new System.Drawing.Size(111, 20);
            this.txtISBN.TabIndex = 24;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 155);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 23;
            this.label3.Text = "ISBN:";
            // 
            // txtYear
            // 
            this.txtYear.Location = new System.Drawing.Point(58, 126);
            this.txtYear.Name = "txtYear";
            this.txtYear.Size = new System.Drawing.Size(111, 20);
            this.txtYear.TabIndex = 22;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 129);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 21;
            this.label2.Text = "Year:";
            // 
            // txtURL
            // 
            this.txtURL.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtURL.Location = new System.Drawing.Point(58, 100);
            this.txtURL.Name = "txtURL";
            this.txtURL.Size = new System.Drawing.Size(385, 20);
            this.txtURL.TabIndex = 20;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 103);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 19;
            this.label1.Text = "URL:";
            // 
            // lstTitles
            // 
            this.lstTitles.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lstTitles.FormattingEnabled = true;
            this.lstTitles.Location = new System.Drawing.Point(12, 12);
            this.lstTitles.Name = "lstTitles";
            this.lstTitles.Size = new System.Drawing.Size(431, 82);
            this.lstTitles.TabIndex = 18;
            this.lstTitles.SelectedIndexChanged += new System.EventHandler(this.lstTitles_SelectedIndexChanged);
            // 
            // howto_fetch_database_info_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(455, 211);
            this.Controls.Add(this.txtPages);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtISBN);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtYear);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtURL);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lstTitles);
            this.Name = "howto_fetch_database_info_Form1";
            this.Text = "howto_fetch_database_info";
            this.Load += new System.EventHandler(this.howto_fetch_database_info_Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtPages;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtISBN;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtYear;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtURL;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox lstTitles;
    }
}

