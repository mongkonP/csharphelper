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
     public partial class howto_datagridview_calculate_color_column_Form1:Form
  { 


        public howto_datagridview_calculate_color_column_Form1()
        {
            InitializeComponent();
        }

        private void howto_datagridview_calculate_color_column_Form1_Load(object sender, EventArgs e)
        {
            // Make some data items.
            dgvValues.Rows.Add(new object[] { "Pencils, dozen", 1.24m, 4 });
            dgvValues.Rows.Add(new object[] { "Paper, ream", 3.75m, 3 });
            dgvValues.Rows.Add(new object[] { "Cookies, box", 2.17m, 12 });
            dgvValues.Rows.Add(new object[] { "Notebook", 1.95m, 2 });
            dgvValues.Rows.Add(new object[] { "Pencil sharpener", 12.95m, 1 });
            dgvValues.Rows.Add(new object[] { "Paper clips, 100", 0.75m, 1 });

            // Define a column style at run time.
            DataGridViewCellStyle cell_style = new DataGridViewCellStyle();
            cell_style.BackColor = Color.LightGreen;
            cell_style.Alignment = DataGridViewContentAlignment.MiddleRight;
            cell_style.Format = "C2";
            dgvValues.Columns[3].DefaultCellStyle = cell_style;

            // Calculate totals.
            CalculateTotals();
        }

        // Calculate the total costs and highlight totals greater than $9.99.
        private void CalculateTotals()
        {
            // Make a style for values greater than $9.99.
            DataGridViewCellStyle highlight_style = new DataGridViewCellStyle();
            highlight_style.ForeColor = Color.Red;
            highlight_style.BackColor = Color.Yellow;
            highlight_style.Font = new Font(dgvValues.Font, FontStyle.Bold);

            // Calculate the total costs.
            foreach (DataGridViewRow row in dgvValues.Rows)
            {
                // Calculate total cost.
                decimal total_cost =
                    (decimal)row.Cells["PriceEach"].Value *
                    (int)row.Cells["Quantity"].Value;

                // Display the value.
                row.Cells["Total"].Value = total_cost;

                // Highlight the cell if the vcalue is big.
                if (total_cost > 9.99m) row.Cells["Total"].Style = highlight_style;
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvValues = new System.Windows.Forms.DataGridView();
            this.Item = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PriceEach = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Quantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Total = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvValues)).BeginInit();
            this.SuspendLayout();
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
            this.dgvValues.TabIndex = 24;
            // 
            // Item
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.DarkBlue;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Red;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Yellow;
            this.Item.DefaultCellStyle = dataGridViewCellStyle1;
            this.Item.HeaderText = "Item";
            this.Item.Name = "Item";
            this.Item.ReadOnly = true;
            this.Item.Width = 200;
            // 
            // PriceEach
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "C2";
            dataGridViewCellStyle2.NullValue = null;
            this.PriceEach.DefaultCellStyle = dataGridViewCellStyle2;
            this.PriceEach.HeaderText = "Price Each";
            this.PriceEach.Name = "PriceEach";
            this.PriceEach.ReadOnly = true;
            // 
            // Quantity
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N0";
            dataGridViewCellStyle3.NullValue = null;
            this.Quantity.DefaultCellStyle = dataGridViewCellStyle3;
            this.Quantity.HeaderText = "Quantity";
            this.Quantity.Name = "Quantity";
            this.Quantity.ReadOnly = true;
            // 
            // Total
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "C2";
            dataGridViewCellStyle4.NullValue = null;
            this.Total.DefaultCellStyle = dataGridViewCellStyle4;
            this.Total.HeaderText = "Total";
            this.Total.Name = "Total";
            this.Total.ReadOnly = true;
            // 
            // howto_datagridview_calculate_color_column_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(565, 179);
            this.Controls.Add(this.dgvValues);
            this.Name = "howto_datagridview_calculate_color_column_Form1";
            this.Text = "howto_datagridview_calculate_color_column";
            this.Load += new System.EventHandler(this.howto_datagridview_calculate_color_column_Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvValues)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.DataGridView dgvValues;
        private System.Windows.Forms.DataGridViewTextBoxColumn Item;
        private System.Windows.Forms.DataGridViewTextBoxColumn PriceEach;
        private System.Windows.Forms.DataGridViewTextBoxColumn Quantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn Total;
    }
}

