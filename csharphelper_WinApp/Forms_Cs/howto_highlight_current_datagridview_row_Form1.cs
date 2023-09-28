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
     public partial class howto_highlight_current_datagridview_row_Form1:Form
  { 


        public howto_highlight_current_datagridview_row_Form1()
        {
            InitializeComponent();
        }

        // The style to use when the mouse is over a row.
        private DataGridViewCellStyle HighlightStyle;

        private void howto_highlight_current_datagridview_row_Form1_Load(object sender, EventArgs e)
        {
            // Define the highlight style.
            HighlightStyle = new DataGridViewCellStyle();
            HighlightStyle.ForeColor = Color.Red;
            HighlightStyle.BackColor = Color.Yellow;
            HighlightStyle.Font = new Font(dgvValues.Font, FontStyle.Bold);

            // Make some data items.
            dgvValues.Rows.Add(new object[] { "Interview Puzzles Dissected", 15.95m, 1 });
            dgvValues.Rows.Add(new object[] { "C# 24-Hour Trainer", 45.00m, 2 });
            dgvValues.Rows.Add(new object[] { "Beginning Software Engineering", 45.00m, 5 });
            dgvValues.Rows.Add(new object[] { "Essential Algorithms", 60.00m, 3 });
            dgvValues.Rows.Add(new object[] { "C# 5.0 Programmer's Reference", 49.99m, 1 });
            dgvValues.Rows.Add(new object[] { "Beginning Database Design Solutions", 44.99m, 2 });

            // Calculate totals.
            CalculateTotals();
        }

        // Calculate the total costs.
        private void CalculateTotals()
        {
            // Calculate the total costs.
            foreach (DataGridViewRow row in dgvValues.Rows)
            {
                // Calculate total cost.
                decimal total_cost =
                    (decimal)row.Cells["PriceEach"].Value *
                    (int)row.Cells["Quantity"].Value;

                // Display the value.
                row.Cells["Total"].Value = total_cost;
            }
        }

        // Set the cell Styles in the given row.
        private void SetRowStyle(DataGridViewRow row, DataGridViewCellStyle style)
        {
            foreach (DataGridViewCell cell in row.Cells)
            {
                cell.Style = style;
            }
        }

        // The currently highlighted cell.
        private int HighlightedRowIndex = -1;

        // Highlight this cell's row.
        private void dgvValues_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == HighlightedRowIndex) return;

            // Unhighlight the previously highlighted row.
            if (HighlightedRowIndex >= 0)
            {
                SetRowStyle(dgvValues.Rows[HighlightedRowIndex], null);
            }

            // Highlight the row holding the mouse.
            HighlightedRowIndex = e.RowIndex;
            if (HighlightedRowIndex >= 0)
            {
                SetRowStyle(dgvValues.Rows[HighlightedRowIndex], HighlightStyle);
            }
        }

        // Unhighlight the currently highlighted row.
        private void dgvValues_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (HighlightedRowIndex >= 0)
            {
                SetRowStyle(dgvValues.Rows[HighlightedRowIndex], null);
                HighlightedRowIndex = -1;
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            this.Quantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvValues = new System.Windows.Forms.DataGridView();
            this.Item = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PriceEach = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Total = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvValues)).BeginInit();
            this.SuspendLayout();
            // 
            // Quantity
            // 
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle9.Format = "N0";
            dataGridViewCellStyle9.NullValue = null;
            this.Quantity.DefaultCellStyle = dataGridViewCellStyle9;
            this.Quantity.HeaderText = "Quantity";
            this.Quantity.Name = "Quantity";
            this.Quantity.ReadOnly = true;
            // 
            // dgvValues
            // 
            this.dgvValues.AllowUserToAddRows = false;
            this.dgvValues.AllowUserToDeleteRows = false;
            this.dgvValues.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvValues.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Item,
            this.PriceEach,
            this.Quantity,
            this.Total});
            this.dgvValues.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvValues.Location = new System.Drawing.Point(0, 0);
            this.dgvValues.Name = "dgvValues";
            this.dgvValues.ReadOnly = true;
            this.dgvValues.Size = new System.Drawing.Size(565, 179);
            this.dgvValues.TabIndex = 26;
            this.dgvValues.CellMouseLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvValues_CellMouseLeave);
            this.dgvValues.CellMouseEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvValues_CellMouseEnter);
            // 
            // Item
            // 
            dataGridViewCellStyle10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.Color.DarkBlue;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.Color.Red;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.Color.Yellow;
            this.Item.DefaultCellStyle = dataGridViewCellStyle10;
            this.Item.HeaderText = "Item";
            this.Item.Name = "Item";
            this.Item.ReadOnly = true;
            this.Item.Width = 200;
            // 
            // PriceEach
            // 
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle11.Format = "C2";
            dataGridViewCellStyle11.NullValue = null;
            this.PriceEach.DefaultCellStyle = dataGridViewCellStyle11;
            this.PriceEach.HeaderText = "Price Each";
            this.PriceEach.Name = "PriceEach";
            this.PriceEach.ReadOnly = true;
            // 
            // Total
            // 
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle12.Format = "C2";
            dataGridViewCellStyle12.NullValue = null;
            this.Total.DefaultCellStyle = dataGridViewCellStyle12;
            this.Total.HeaderText = "Total";
            this.Total.Name = "Total";
            this.Total.ReadOnly = true;
            // 
            // howto_highlight_current_datagridview_row_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(565, 179);
            this.Controls.Add(this.dgvValues);
            this.Name = "howto_highlight_current_datagridview_row_Form1";
            this.Text = "howto_highlight_current_datagridview_row";
            this.Load += new System.EventHandler(this.howto_highlight_current_datagridview_row_Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvValues)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridViewTextBoxColumn Quantity;
        internal System.Windows.Forms.DataGridView dgvValues;
        private System.Windows.Forms.DataGridViewTextBoxColumn Item;
        private System.Windows.Forms.DataGridViewTextBoxColumn PriceEach;
        private System.Windows.Forms.DataGridViewTextBoxColumn Total;
    }
}

