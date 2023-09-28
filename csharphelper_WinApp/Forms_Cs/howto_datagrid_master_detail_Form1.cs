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
     public partial class howto_datagrid_master_detail_Form1:Form
  { 


        public howto_datagrid_master_detail_Form1()
        {
            InitializeComponent();
        }

        // Data adapters for loading data.
        private OleDbDataAdapter DaAddresses, DaTestScores;
    
        // The DataSet to hold the data.
        private DataSet StudentDataSet;

        // Load the data.
        private void howto_datagrid_master_detail_Form1_Load(object sender, EventArgs e)
        {
            // Compose the connection string.
            string connect_string =
                "Provider=Microsoft.ACE.OLEDB.12.0;" +
                "Data Source=Contacts.mdb;" +
                "Mode=Share Deny None";

            // Create a DataAdapter to load the Addresses table.
            DaAddresses = new OleDbDataAdapter(
                "SELECT * FROM Addresses", connect_string);

            // Create a DataAdapter to load the Addresses table.
            DaTestScores = new OleDbDataAdapter(
                "SELECT * FROM TestScores", connect_string);

            // Create and fill the DataSet.
            StudentDataSet = new DataSet();
            DaAddresses.Fill(StudentDataSet, "Addresses");
            DaTestScores.Fill(StudentDataSet, "TestScores");

            // Define the relationship between the tables.
            DataRelation data_relation = new DataRelation(
                "Addresses_TestScores",
                StudentDataSet.Tables["Addresses"].Columns["ContactID"],
                StudentDataSet.Tables["TestScores"].Columns["ContactID"]);
            StudentDataSet.Relations.Add(data_relation);

            // Bind the DataGrid to the DataSet.
            dgContacts.DataSource = StudentDataSet;
        }

        // Save changes to the data.
        private void howto_datagrid_master_detail_Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Use a CommandBuilder to make the INSERT,
            // UPDATE, and DELETE commands as needed.
            OleDbCommandBuilder cb_addresses = new OleDbCommandBuilder(DaAddresses);
            OleDbCommandBuilder cb_testscores = new OleDbCommandBuilder(DaTestScores);

            // Update the database.
            try
            {
                DaAddresses.Update(StudentDataSet, "Addresses");
                DaTestScores.Update(StudentDataSet, "TestScores");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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
            this.dgContacts = new System.Windows.Forms.DataGrid();
            ((System.ComponentModel.ISupportInitialize)(this.dgContacts)).BeginInit();
            this.SuspendLayout();
            // 
            // dgContacts
            // 
            this.dgContacts.DataMember = "";
            this.dgContacts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgContacts.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dgContacts.Location = new System.Drawing.Point(0, 0);
            this.dgContacts.Name = "dgContacts";
            this.dgContacts.Size = new System.Drawing.Size(560, 255);
            this.dgContacts.TabIndex = 1;
            // 
            // howto_datagrid_master_detail_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(560, 255);
            this.Controls.Add(this.dgContacts);
            this.Name = "howto_datagrid_master_detail_Form1";
            this.Text = "howto_datagrid_master_detail";
            this.Load += new System.EventHandler(this.howto_datagrid_master_detail_Form1_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.howto_datagrid_master_detail_Form1_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.dgContacts)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.DataGrid dgContacts;
    }
}

