using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

 

namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_update_datagridview_datatable_Form1:Form
  { 


        public howto_update_datagridview_datatable_Form1()
        {
            InitializeComponent();
        }

        private void howto_update_datagridview_datatable_Form1_Load(object sender, EventArgs e)
        {
            // Make the DataTable object.
            DataTable dt = new DataTable("People");

            // Add columns to the DataTable.
            dt.Columns.Add("First Name", System.Type.GetType("System.String"));
            dt.Columns.Add("Last Name", System.Type.GetType("System.String"));
            dt.Columns.Add("Occupation", System.Type.GetType("System.String"));
            dt.Columns.Add("Salary", System.Type.GetType("System.Int32"));

            // Make all columns required.
            for (int i = 0; i < dt.Columns.Count; i++)
            {
                dt.Columns[i].AllowDBNull = false;
            }

            // Make First Name + Last Name require uniqueness.
            DataColumn[] unique_cols = 
            {
                dt.Columns["First Name"],
                dt.Columns["Last Name"]
            };
            dt.Constraints.Add(new UniqueConstraint(unique_cols));

            // Add items to the table.
            dt.Rows.Add(new object[] { "Rod", "Stephens", "Nerd", 10000 });
            dt.Rows.Add(new object[] { "Sergio", "Aragones", "Cartoonist", 20000 });
            dt.Rows.Add(new object[] { "Eoin", "Colfer", "Author", 30000 });
            dt.Rows.Add(new object[] { "Terry", "Pratchett", "Author", 40000 });

            // Make the DataGridView use the DataTable as its data source.
            dgvPeople.DataSource = dt;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            howto_update_datagridview_datatable_NewItemDialog dlg = new howto_update_datagridview_datatable_NewItemDialog();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                // Make the DataTable object.
                DataTable dt = (DataTable)dgvPeople.DataSource;
                dt.Rows.Add(
                    dlg.txtFirstName.Text,
                    dlg.txtLastName.Text,
                    dlg.txtOccupation.Text,
                    int.Parse(dlg.txtSalary.Text));
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
            this.btnAdd = new System.Windows.Forms.Button();
            this.dgvPeople = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPeople)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnAdd.Location = new System.Drawing.Point(205, 176);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 3;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // dgvPeople
            // 
            this.dgvPeople.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvPeople.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPeople.Location = new System.Drawing.Point(12, 12);
            this.dgvPeople.Name = "dgvPeople";
            this.dgvPeople.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPeople.Size = new System.Drawing.Size(460, 158);
            this.dgvPeople.TabIndex = 2;
            // 
            // howto_update_datagridview_datatable_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 211);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.dgvPeople);
            this.Name = "howto_update_datagridview_datatable_Form1";
            this.Text = "howto_update_datagridview_datatable";
            this.Load += new System.EventHandler(this.howto_update_datagridview_datatable_Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPeople)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.DataGridView dgvPeople;
    }
}

