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
     public partial class howto_initialize_list_from_db_Form1:Form
  { 


        public howto_initialize_list_from_db_Form1()
        {
            InitializeComponent();
        }

        // The database connection.
        private OleDbConnection Conn;

        // Display a list of titles.
        private void howto_initialize_list_from_db_Form1_Load(object sender, EventArgs e)
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
                lstTitles.Items.Add(reader["Title"]);
            }
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
            this.lstTitles = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // lstTitles
            // 
            this.lstTitles.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lstTitles.FormattingEnabled = true;
            this.lstTitles.IntegralHeight = false;
            this.lstTitles.Location = new System.Drawing.Point(12, 12);
            this.lstTitles.Name = "lstTitles";
            this.lstTitles.Size = new System.Drawing.Size(410, 187);
            this.lstTitles.TabIndex = 1;
            // 
            // howto_initialize_list_from_db_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(434, 211);
            this.Controls.Add(this.lstTitles);
            this.Name = "howto_initialize_list_from_db_Form1";
            this.Text = "howto_initialize_list_from_db";
            this.Load += new System.EventHandler(this.howto_initialize_list_from_db_Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lstTitles;
    }
}

