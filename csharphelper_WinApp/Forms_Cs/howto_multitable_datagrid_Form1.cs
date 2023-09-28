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
     public partial class howto_multitable_datagrid_Form1:Form
  { 


        public howto_multitable_datagrid_Form1()
        {
            InitializeComponent();
        }

        // The DataAdapters and the DataSet.
        private OleDbDataAdapter DaAddresses, DaTestScores;
        private DataSet DsContacts;

        private void howto_multitable_datagrid_Form1_Load(object sender, EventArgs e)
        {
            const string SELECT_ADDRESSES = "SELECT * FROM Addresses";
            const string SELECT_TEST_SCORES = "SELECT * FROM TestScores";

            // Get the database file name.
            // This assumes the database is in the executable directory.
            string db_name = Application.StartupPath + "\\Contacts.mdb";

            // Compose the connection string.
            string connect_string =
                "Provider=Microsoft.ACE.OLEDB.12.0;" +
                "Data Source=" + db_name + ";" +
                "Persist Security Info=False";

            // Create a DataAdapter to load the Addresses table.
            DaAddresses = new OleDbDataAdapter(SELECT_ADDRESSES, connect_string);

            // Create a DataAdapter to load the Addresses table.
            DaTestScores = new OleDbDataAdapter(SELECT_TEST_SCORES, connect_string);

            // Create and fill the DataSet.
            DsContacts = new DataSet("ContactsDataSet");
            DaAddresses.Fill(DsContacts, "Addresses");
            DaTestScores.Fill(DsContacts, "TestScores");

            // Bind the DataGrid to the DataSet.
            dgContacts.DataSource = DsContacts;
        }

        // Save changes to the data.
        private void howto_multitable_datagrid_Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Use a CommandBuilder to make the INSERT,
            // UPDATE, and DELETE commands as needed.
            OleDbCommandBuilder command_builder;
            command_builder = new OleDbCommandBuilder(DaAddresses);
            command_builder = new OleDbCommandBuilder(DaTestScores);

            // Update the database.
            try
            {
                DaAddresses.Update(DsContacts, "Addresses");
                DaTestScores.Update(DsContacts, "TestScores");
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
            this.dgContacts.Size = new System.Drawing.Size(584, 236);
            this.dgContacts.TabIndex = 2;
            // 
            // howto_multitable_datagrid_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 236);
            this.Controls.Add(this.dgContacts);
            this.Name = "howto_multitable_datagrid_Form1";
            this.Text = "howto_multitable_datagrid";
            this.Load += new System.EventHandler(this.howto_multitable_datagrid_Form1_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.howto_multitable_datagrid_Form1_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.dgContacts)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.DataGrid dgContacts;
    }
}

