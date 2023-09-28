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
     public partial class howto_edit_datagridview_Form1:Form
  { 


        public howto_edit_datagridview_Form1()
        {
            InitializeComponent();
        }

        private void howto_edit_datagridview_Form1_Load(object sender, EventArgs e)
        {
            // Make the DataTable object.
            DataTable dt = new DataTable("Books");

            // Add columns to the DataTable.
            dt.Columns.Add("Title",
                System.Type.GetType("System.String"));
            dt.Columns.Add("Has Download",
                System.Type.GetType("System.Boolean"));
            dt.Columns.Add("Year",
                System.Type.GetType("System.Int32"));
            dt.Columns.Add("URL",
                System.Type.GetType("System.String"));
                        
            // Add items to the table.
            dt.Rows.Add(new object[] { "Essential Algorithms", true, "2019", "http://www.csharphelper.com/algorithms2e.html" });
            dt.Rows.Add(new object[] { "WPF 3d", true, "2018", "http://www.csharphelper.com/wpf3d.html" });
            dt.Rows.Add(new object[] { "The C# Helper Top 100", true, "2017", "http://csharphelper.com/top100.htm" });
            dt.Rows.Add(new object[] { "Interview Puzzles Dissected", false, "2016", "http://www.csharphelper.com/puzzles.htm" });

            // Make the DataGridView use the DataTable as its data source.
            dgvBooks.DataSource = dt;

            // Draw URLs in a blue, underlined font.
            dgvBooks.Columns["URL"].DefaultCellStyle.Font =
                new Font(dgvBooks.Font, FontStyle.Underline);
            dgvBooks.Columns["URL"].DefaultCellStyle.ForeColor =
                Color.Blue;

            // Set column widths.
            dgvBooks.AutoResizeColumns();

            // Do not allow automatic editing.
            dgvBooks.EditMode = DataGridViewEditMode.EditProgrammatically;
            dgvBooks.AllowUserToAddRows = false;
            dgvBooks.AllowUserToDeleteRows = false;
        }

        // Display an appropriate cursor in the Has Download and URL columns.
        private void dgvBooks_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            int col = e.ColumnIndex;
            if (col == -1) return;

            if (dgvBooks.Columns[col].Name == "Has Download")
                dgvBooks.Cursor = Cursors.Hand;
            else if (dgvBooks.Columns[col].Name == "URL")
                dgvBooks.Cursor = Cursors.UpArrow;
        }

        // Restore the default cursor..
        private void dgvBooks_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvBooks.Cursor != Cursors.Default)
                dgvBooks.Cursor = Cursors.Default;
        }

        // Toggle the Has Download field. Open the URL.
        private void dgvBooks_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int col = e.ColumnIndex;
            if (col == -1) return;

            int row = e.RowIndex;

            // See which column this is.
            if (dgvBooks.Columns[col].Name == "Has Download")
            {
                // Toggle the value.
                bool value = (bool)dgvBooks.Rows[row].Cells[col].Value;
                dgvBooks.Rows[row].Cells[col].Value = !value;
            }
            else if (dgvBooks.Columns[e.ColumnIndex].Name == "URL")
            {
                // Open the URL.
                string url = (string)dgvBooks.Rows[row].Cells[col].Value;
                System.Diagnostics.Process.Start(url);
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
            this.dgvBooks = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBooks)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvBooks
            // 
            this.dgvBooks.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvBooks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBooks.Location = new System.Drawing.Point(12, 12);
            this.dgvBooks.Name = "dgvBooks";
            this.dgvBooks.Size = new System.Drawing.Size(570, 137);
            this.dgvBooks.TabIndex = 0;
            this.dgvBooks.CellMouseLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvBooks_CellMouseLeave);
            this.dgvBooks.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvBooks_CellDoubleClick);
            this.dgvBooks.CellMouseEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvBooks_CellMouseEnter);
            // 
            // howto_edit_datagridview_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(594, 161);
            this.Controls.Add(this.dgvBooks);
            this.Name = "howto_edit_datagridview_Form1";
            this.Text = "howto_edit_datagridview";
            this.Load += new System.EventHandler(this.howto_edit_datagridview_Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBooks)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvBooks;
    }
}

