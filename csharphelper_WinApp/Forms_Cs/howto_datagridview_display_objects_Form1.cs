using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

 

using howto_datagridview_display_objects;
namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_datagridview_display_objects_Form1:Form
  { 


        public howto_datagridview_display_objects_Form1()
        {
            InitializeComponent();
        }

        private void howto_datagridview_display_objects_Form1_Load(object sender, EventArgs e)
        {
            // Make some data items.
            OrderItem[] order_items = 
            {
                new OrderItem("Pencils, dozen", 1.24m, 4),
                new OrderItem("Cookies, box", 2.17m, 1),
                new OrderItem("Notebook", 1.95m, 2),
                new OrderItem("Paper, ream", 3.75m, 3),
                new OrderItem("Pencil sharpener", 12.95m, 1),
                new OrderItem("Paper clips, 100", 0.75m, 1),
            };

            // Add the items to the DataGridView.
            AddOrderItems(order_items);
 
            // Define a column style at run time.
            DataGridViewCellStyle cell_style = new DataGridViewCellStyle();
            cell_style.BackColor = Color.LightGreen;
            cell_style.Alignment = DataGridViewContentAlignment.MiddleRight;
            cell_style.Format = "C2";
            dgvValues.Columns[3].DefaultCellStyle = cell_style;
        }

        // Add the items to the DataGridView.
        private void AddOrderItems(OrderItem[] order_items)
        {
            foreach (OrderItem item in order_items)
            {
                dgvValues.Rows.Add(new object[]
                    {
                        item.Description,
                        item.UnitPrice,
                        item.Quantity,
                        item.TotalCost
                    }
                );
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
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.Color.DarkBlue;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.Red;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.Yellow;
            this.Item.DefaultCellStyle = dataGridViewCellStyle9;
            this.Item.HeaderText = "Item";
            this.Item.Name = "Item";
            this.Item.ReadOnly = true;
            this.Item.Width = 200;
            // 
            // PriceEach
            // 
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle10.Format = "C2";
            dataGridViewCellStyle10.NullValue = null;
            this.PriceEach.DefaultCellStyle = dataGridViewCellStyle10;
            this.PriceEach.HeaderText = "Price Each";
            this.PriceEach.Name = "PriceEach";
            this.PriceEach.ReadOnly = true;
            // 
            // Quantity
            // 
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle11.Format = "N0";
            dataGridViewCellStyle11.NullValue = null;
            this.Quantity.DefaultCellStyle = dataGridViewCellStyle11;
            this.Quantity.HeaderText = "Quantity";
            this.Quantity.Name = "Quantity";
            this.Quantity.ReadOnly = true;
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
            // howto_datagridview_display_objects_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(565, 179);
            this.Controls.Add(this.dgvValues);
            this.Name = "howto_datagridview_display_objects_Form1";
            this.Text = "howto_datagridview_display_objects";
            this.Load += new System.EventHandler(this.howto_datagridview_display_objects_Form1_Load);
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

