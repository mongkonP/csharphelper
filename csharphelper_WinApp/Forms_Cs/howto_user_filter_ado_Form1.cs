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
     public partial class howto_user_filter_ado_Form1:Form
  { 


        public howto_user_filter_ado_Form1()
        {
            InitializeComponent();
        }

        // The connection object.
        private OleDbConnection Conn;

        // The table's column names.
        private List<string> ColumnNames = new List<string>();
        private string TableName = "";

        // The query controls.
        private ComboBox[] CboField, CboOperator;
        private TextBox[] TxtValue;
        private List<Type> DataTypes = new List<Type>();

        // Make a list of the table's fields.
        private void howto_user_filter_ado_Form1_Load(object sender, EventArgs e)
        {
            // Compose the database file name.
            // This assumes it's in the executable's directory.
            string db_name = Application.StartupPath + "\\Books.accdb";

            // Prepare the form for use.
            PrepareForm(db_name, "BookInfo");
        }

        // Make a list of the table's field names and prepare the first ComboBox.
        private void PrepareForm(string db_name, string table_name)
        {
            TableName = table_name;

            // Make the connection object.
            Conn = new OleDbConnection(
                "Provider=Microsoft.ACE.OLEDB.12.0;" +
                "Data Source=" + db_name + ";" +
                "Mode=Share Deny None");

            // Get the fields in the BookInfo table.
            // Make a command object to represent the command.
            OleDbCommand cmd = new OleDbCommand();
            cmd.Connection = Conn;
            cmd.CommandText = "SELECT TOP 1 * FROM " + table_name;

            // Open the connection and execute the command.
            try
            {
                // Open the connection.
                Conn.Open();

                // Execute the query. The reader gives access to the results.
                OleDbDataReader reader = cmd.ExecuteReader();

                // Get field information.
                DataTable schema = reader.GetSchemaTable();
                foreach (DataRow schema_row in schema.Rows)
                {
                    ColumnNames.Add(schema_row.Field<string>("ColumnName"));
                    DataTypes.Add(schema_row.Field<Type>("DataType"));
                    // Console.WriteLine(schema_row.Field<Type>("DataType").ToString());
                }

                // Initialize the field name ComboBoxes.
                CboField = new ComboBox[] { cboField0, cboField1, cboField2, cboField3 };
                CboOperator = new ComboBox[] { cboOperator0, cboOperator1, cboOperator2, cboOperator3 };
                TxtValue = new TextBox[] { txtValue0, txtValue1, txtValue2, txtValue3 };
                for (int i = 0; i < CboField.Length; i++)
                {
                    CboField[i].Items.Add("");          // Allow a blank field choice.
                    foreach (string field_name in ColumnNames)
                    {
                        CboField[i].Items.Add(field_name);
                    }
                    CboField[i].SelectedIndex = 0;      // Select the blank choice.
                    CboOperator[i].SelectedIndex = 0;   // Select the blank choice.
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error reading " + table_name + " column names.\n" + ex.Message);
            }
            finally
            {
                // Close the connection whether we succeed or fail.
                Conn.Close();
            }
        }

        // Build and execute the appropriate query.
        private void btnQuery_Click(object sender, EventArgs e)
        {
            string where_clause = "";
            for (int i = 0; i < CboField.Length; i++)
            {
                // See if the field and operator are non-blank.
                if ((CboField[i].SelectedIndex <= 0) ||
                    (CboOperator[i].SelectedIndex <= 0))
                {
                    // Don't use this row. Clear it to prevent confusion.
                    CboField[i].SelectedIndex = 0;
                    CboOperator[i].SelectedIndex = 0;
                    TxtValue[i].Clear();
                }
                else
                {
                    // See what delimiter we need for this type of field.
                    string delimiter = "";
                    string value = TxtValue[i].Text;
                    int column_num = CboField[i].SelectedIndex - 1;
                    if (DataTypes[column_num] == typeof(System.String))
                    {
                        delimiter = "'";
                        value = value.Replace("'", "''");
                    }
                    else if (DataTypes[column_num] == typeof(System.DateTime))
                    {
                        // Use # for Access, ' for SQL Server.
                        delimiter = "#";
                    }

                    // Add the constraint to the WHERE clause.
                    where_clause += " AND " +
                        CboField[i].SelectedItem.ToString() + " " +
                        CboOperator[i].SelectedItem.ToString() + " " +
                        delimiter + value + delimiter;
                }   // if field and operator are selected.
            }   // for (int i = 0; i < CboField.Length; i++)

            // If where_clause is non-blank, remove the initial " AND ".
            if (where_clause.Length > 0) where_clause = where_clause.Substring(5);

            // Compose the query.
            string query = "SELECT * FROM " + TableName;
            if (where_clause.Length > 0) query += " WHERE " + where_clause;
            // Console.WriteLine("Query: " + query);

            // Create a DataAdapter to load the data.
            OleDbDataAdapter data_adapter = new OleDbDataAdapter(query, Conn);

            // Create a DataTable.
            DataTable data_table = new DataTable();
            try
            {
                data_adapter.Fill(data_table);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error executing query " + query + "\n" + ex.Message);
            }

            // Bind the DataGridView to the DataTable.
            dgvBookInfo.DataSource = data_table;
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
            this.btnQuery = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cboField0 = new System.Windows.Forms.ComboBox();
            this.cboOperator0 = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtValue0 = new System.Windows.Forms.TextBox();
            this.txtValue1 = new System.Windows.Forms.TextBox();
            this.cboField1 = new System.Windows.Forms.ComboBox();
            this.cboOperator1 = new System.Windows.Forms.ComboBox();
            this.txtValue3 = new System.Windows.Forms.TextBox();
            this.cboField3 = new System.Windows.Forms.ComboBox();
            this.cboOperator3 = new System.Windows.Forms.ComboBox();
            this.txtValue2 = new System.Windows.Forms.TextBox();
            this.cboField2 = new System.Windows.Forms.ComboBox();
            this.cboOperator2 = new System.Windows.Forms.ComboBox();
            this.dgvBookInfo = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBookInfo)).BeginInit();
            this.SuspendLayout();
            // 
            // btnQuery
            // 
            this.btnQuery.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnQuery.Location = new System.Drawing.Point(216, 133);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(75, 23);
            this.btnQuery.TabIndex = 12;
            this.btnQuery.Text = "Query";
            this.btnQuery.UseVisualStyleBackColor = true;
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Field:";
            // 
            // cboField0
            // 
            this.cboField0.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboField0.FormattingEnabled = true;
            this.cboField0.Location = new System.Drawing.Point(15, 25);
            this.cboField0.Name = "cboField0";
            this.cboField0.Size = new System.Drawing.Size(138, 21);
            this.cboField0.TabIndex = 0;
            // 
            // cboOperator0
            // 
            this.cboOperator0.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboOperator0.FormattingEnabled = true;
            this.cboOperator0.Items.AddRange(new object[] {
            "",
            "<",
            ">",
            "=",
            "<=",
            ">=",
            "<>",
            "LIKE"});
            this.cboOperator0.Location = new System.Drawing.Point(159, 25);
            this.cboOperator0.Name = "cboOperator0";
            this.cboOperator0.Size = new System.Drawing.Size(66, 21);
            this.cboOperator0.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(156, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Operator:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(228, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Value:";
            // 
            // txtValue0
            // 
            this.txtValue0.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtValue0.Location = new System.Drawing.Point(231, 26);
            this.txtValue0.Name = "txtValue0";
            this.txtValue0.Size = new System.Drawing.Size(263, 20);
            this.txtValue0.TabIndex = 2;
            // 
            // txtValue1
            // 
            this.txtValue1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtValue1.Location = new System.Drawing.Point(231, 53);
            this.txtValue1.Name = "txtValue1";
            this.txtValue1.Size = new System.Drawing.Size(263, 20);
            this.txtValue1.TabIndex = 5;
            // 
            // cboField1
            // 
            this.cboField1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboField1.FormattingEnabled = true;
            this.cboField1.Location = new System.Drawing.Point(15, 52);
            this.cboField1.Name = "cboField1";
            this.cboField1.Size = new System.Drawing.Size(138, 21);
            this.cboField1.TabIndex = 3;
            // 
            // cboOperator1
            // 
            this.cboOperator1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboOperator1.FormattingEnabled = true;
            this.cboOperator1.Items.AddRange(new object[] {
            "",
            "<",
            ">",
            "=",
            "<=",
            ">=",
            "<>",
            "LIKE"});
            this.cboOperator1.Location = new System.Drawing.Point(159, 52);
            this.cboOperator1.Name = "cboOperator1";
            this.cboOperator1.Size = new System.Drawing.Size(66, 21);
            this.cboOperator1.TabIndex = 4;
            // 
            // txtValue3
            // 
            this.txtValue3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtValue3.Location = new System.Drawing.Point(231, 107);
            this.txtValue3.Name = "txtValue3";
            this.txtValue3.Size = new System.Drawing.Size(263, 20);
            this.txtValue3.TabIndex = 11;
            // 
            // cboField3
            // 
            this.cboField3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboField3.FormattingEnabled = true;
            this.cboField3.Location = new System.Drawing.Point(15, 106);
            this.cboField3.Name = "cboField3";
            this.cboField3.Size = new System.Drawing.Size(138, 21);
            this.cboField3.TabIndex = 9;
            // 
            // cboOperator3
            // 
            this.cboOperator3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboOperator3.FormattingEnabled = true;
            this.cboOperator3.Items.AddRange(new object[] {
            "",
            "<",
            ">",
            "=",
            "<=",
            ">=",
            "<>",
            "LIKE"});
            this.cboOperator3.Location = new System.Drawing.Point(159, 106);
            this.cboOperator3.Name = "cboOperator3";
            this.cboOperator3.Size = new System.Drawing.Size(66, 21);
            this.cboOperator3.TabIndex = 10;
            // 
            // txtValue2
            // 
            this.txtValue2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtValue2.Location = new System.Drawing.Point(231, 80);
            this.txtValue2.Name = "txtValue2";
            this.txtValue2.Size = new System.Drawing.Size(263, 20);
            this.txtValue2.TabIndex = 8;
            // 
            // cboField2
            // 
            this.cboField2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboField2.FormattingEnabled = true;
            this.cboField2.Location = new System.Drawing.Point(15, 79);
            this.cboField2.Name = "cboField2";
            this.cboField2.Size = new System.Drawing.Size(138, 21);
            this.cboField2.TabIndex = 6;
            // 
            // cboOperator2
            // 
            this.cboOperator2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboOperator2.FormattingEnabled = true;
            this.cboOperator2.Items.AddRange(new object[] {
            "",
            "<",
            ">",
            "=",
            "<=",
            ">=",
            "<>",
            "LIKE"});
            this.cboOperator2.Location = new System.Drawing.Point(159, 79);
            this.cboOperator2.Name = "cboOperator2";
            this.cboOperator2.Size = new System.Drawing.Size(66, 21);
            this.cboOperator2.TabIndex = 7;
            // 
            // dgvBookInfo
            // 
            this.dgvBookInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvBookInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBookInfo.Location = new System.Drawing.Point(15, 162);
            this.dgvBookInfo.Name = "dgvBookInfo";
            this.dgvBookInfo.Size = new System.Drawing.Size(479, 203);
            this.dgvBookInfo.TabIndex = 13;
            // 
            // howto_user_filter_ado_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(506, 377);
            this.Controls.Add(this.dgvBookInfo);
            this.Controls.Add(this.txtValue3);
            this.Controls.Add(this.cboField3);
            this.Controls.Add(this.cboOperator3);
            this.Controls.Add(this.txtValue2);
            this.Controls.Add(this.cboField2);
            this.Controls.Add(this.cboOperator2);
            this.Controls.Add(this.txtValue1);
            this.Controls.Add(this.cboField1);
            this.Controls.Add(this.cboOperator1);
            this.Controls.Add(this.txtValue0);
            this.Controls.Add(this.btnQuery);
            this.Controls.Add(this.cboField0);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cboOperator0);
            this.Controls.Add(this.label2);
            this.Name = "howto_user_filter_ado_Form1";
            this.Text = "howto_user_filter_ado";
            this.Load += new System.EventHandler(this.howto_user_filter_ado_Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBookInfo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnQuery;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboOperator0;
        private System.Windows.Forms.ComboBox cboField0;
        private System.Windows.Forms.TextBox txtValue0;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtValue1;
        private System.Windows.Forms.ComboBox cboField1;
        private System.Windows.Forms.ComboBox cboOperator1;
        private System.Windows.Forms.TextBox txtValue3;
        private System.Windows.Forms.ComboBox cboField3;
        private System.Windows.Forms.ComboBox cboOperator3;
        private System.Windows.Forms.TextBox txtValue2;
        private System.Windows.Forms.ComboBox cboField2;
        private System.Windows.Forms.ComboBox cboOperator2;
        private System.Windows.Forms.DataGridView dgvBookInfo;

    }
}

