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
     public partial class howto_run_ado_ad_hoc_queries_Form1:Form
  { 


        public howto_run_ado_ad_hoc_queries_Form1()
        {
            InitializeComponent();
        }

        // The connection object.
        private OleDbConnection Conn;

        // Prepare the database connection.
        private void howto_run_ado_ad_hoc_queries_Form1_Load(object sender, EventArgs e)
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

        private void cboSamples_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cboSamples.Text)
            {
                case "Select":
                    txtQuery.Text = "SELECT * FROM BookInfo";
                    break;
                case "Sort":
                    txtQuery.Text = "SELECT * FROM BookInfo\r\n" +
                        "ORDER BY PubYear";
                    break;
                case "Condition":
                    txtQuery.Text = "SELECT * FROM BookInfo\r\n" +
                        "WHERE PubYear >= 2000\r\n" + 
                        "ORDER BY PubYear DESC";
                    break;
                case "Join":
                    txtQuery.Text = "SELECT FirstName, LastName, TestNumber, Score\r\n" +
                        "FROM Pupils, TestScores\r\n" +
                        "WHERE Pupils.StudentId = TestScores.StudentId\r\n" +
                        "ORDER BY FirstName, LastName, TestNumber";
                    break;
            }
        }

        // Execute the query.
        private void btnExecute_Click(object sender, EventArgs e)
        {
            // Make a command object to represent the command.
            OleDbCommand cmd = new OleDbCommand();
            cmd.Connection = Conn;
            cmd.CommandText = txtQuery.Text;

            // Open the connection and execute the command.
            try
            {
                // Open the connection.
                Conn.Open();

                // Execute the query. The reader gives access to the results.
                OleDbDataReader reader = cmd.ExecuteReader();

                // Prepare the DataGridView.
                dgvResults.Columns.Clear();
                dgvResults.Rows.Clear();
                if (reader.HasRows)
                {
                    // Get field information.
                    DataTable schema = reader.GetSchemaTable();
                    int field_num = 0;
                    foreach (DataRow schema_row in schema.Rows)
                    {
                        // Create the column.
                        int col_num = dgvResults.Columns.Add(
                            "col" + field_num.ToString(),
                            schema_row.Field<string>("ColumnName"));
                        field_num++;
                        
                        // Make the column size to fit its data.
                        dgvResults.Columns[col_num].AutoSizeMode = 
                            DataGridViewAutoSizeColumnMode.AllCells;
                    }

                    // Make room to hold a row's values.
                    object[] values = new object[reader.FieldCount];

                    // Loop while the reader has unread data.
                    while (reader.Read())
                    {
                        // Add this row to the DataGridView.
                        reader.GetValues(values);
                        dgvResults.Rows.Add(values);
                    }
                }
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
            this.label1 = new System.Windows.Forms.Label();
            this.cboSamples = new System.Windows.Forms.ComboBox();
            this.txtQuery = new System.Windows.Forms.TextBox();
            this.btnExecute = new System.Windows.Forms.Button();
            this.dgvResults = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResults)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Sample Queries:";
            // 
            // cboSamples
            // 
            this.cboSamples.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cboSamples.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSamples.FormattingEnabled = true;
            this.cboSamples.Items.AddRange(new object[] {
            "Select",
            "Sort",
            "Condition",
            "Join"});
            this.cboSamples.Location = new System.Drawing.Point(102, 12);
            this.cboSamples.Name = "cboSamples";
            this.cboSamples.Size = new System.Drawing.Size(592, 21);
            this.cboSamples.TabIndex = 1;
            this.cboSamples.SelectedIndexChanged += new System.EventHandler(this.cboSamples_SelectedIndexChanged);
            // 
            // txtQuery
            // 
            this.txtQuery.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtQuery.Location = new System.Drawing.Point(12, 39);
            this.txtQuery.Multiline = true;
            this.txtQuery.Name = "txtQuery";
            this.txtQuery.Size = new System.Drawing.Size(682, 64);
            this.txtQuery.TabIndex = 2;
            // 
            // btnExecute
            // 
            this.btnExecute.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnExecute.Location = new System.Drawing.Point(316, 109);
            this.btnExecute.Name = "btnExecute";
            this.btnExecute.Size = new System.Drawing.Size(75, 23);
            this.btnExecute.TabIndex = 3;
            this.btnExecute.Text = "Execute";
            this.btnExecute.UseVisualStyleBackColor = true;
            this.btnExecute.Click += new System.EventHandler(this.btnExecute_Click);
            // 
            // dgvResults
            // 
            this.dgvResults.AllowUserToAddRows = false;
            this.dgvResults.AllowUserToDeleteRows = false;
            this.dgvResults.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvResults.Location = new System.Drawing.Point(12, 138);
            this.dgvResults.Name = "dgvResults";
            this.dgvResults.ReadOnly = true;
            this.dgvResults.Size = new System.Drawing.Size(682, 206);
            this.dgvResults.TabIndex = 4;
            // 
            // howto_run_ado_ad_hoc_queries_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(706, 356);
            this.Controls.Add(this.dgvResults);
            this.Controls.Add(this.btnExecute);
            this.Controls.Add(this.txtQuery);
            this.Controls.Add(this.cboSamples);
            this.Controls.Add(this.label1);
            this.Name = "howto_run_ado_ad_hoc_queries_Form1";
            this.Text = "howto_run_ado_ad_hoc_queries";
            this.Load += new System.EventHandler(this.howto_run_ado_ad_hoc_queries_Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvResults)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboSamples;
        private System.Windows.Forms.TextBox txtQuery;
        private System.Windows.Forms.Button btnExecute;
        private System.Windows.Forms.DataGridView dgvResults;
    }
}

