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
     public partial class howto_datagridview_format_columns_Form1:Form
  { 


        public howto_datagridview_format_columns_Form1()
        {
            InitializeComponent();
        }

        // Add some test data.
        private void howto_datagridview_format_columns_Form1_Load(object sender, EventArgs e)
        {
            dgvValues.Rows.Add("Notebook", 1.17m, 6m, 1.17m * 6m);
            dgvValues.Rows.Add("Cookies", 3.59m, 12m, 3.59m * 12m);
            dgvValues.Rows.Add("AAA Batteries", 4.99m, 1m, 4.99m * 1m);
            dgvValues.Rows.Add("Pencil sharpener", 19.95m, 1m, 19.95m * 1m);
            dgvValues.Rows.Add("Sticky notes", null, 1m, null);
            dgvValues.Rows.Add("Highlighter pens", 1.95m, null, null);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            // Create the new row.
            decimal price_each = decimal.Parse(txtPriceEach.Text);
            decimal quantity = decimal.Parse(txtQuantity.Text);
            decimal total = price_each * quantity;
            dgvValues.Rows.Add(txtItem.Text, price_each, quantity, total);

            // Get ready for the next entry.
            txtItem.Clear();
            txtPriceEach.Clear();
            txtQuantity.Clear();
            txtItem.Focus();
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvValues = new System.Windows.Forms.DataGridView();
            this.Item = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PriceEach = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Quantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Total = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnAdd = new System.Windows.Forms.Button();
            this.txtQuantity = new System.Windows.Forms.TextBox();
            this.Label3 = new System.Windows.Forms.Label();
            this.txtPriceEach = new System.Windows.Forms.TextBox();
            this.Label2 = new System.Windows.Forms.Label();
            this.txtItem = new System.Windows.Forms.TextBox();
            this.Label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvValues)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvValues
            // 
            this.dgvValues.AllowUserToAddRows = false;
            this.dgvValues.AllowUserToDeleteRows = false;
            this.dgvValues.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvValues.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvValues.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Item,
            this.PriceEach,
            this.Quantity,
            this.Total});
            this.dgvValues.Location = new System.Drawing.Point(0, 84);
            this.dgvValues.Name = "dgvValues";
            this.dgvValues.ReadOnly = true;
            this.dgvValues.Size = new System.Drawing.Size(574, 167);
            this.dgvValues.TabIndex = 29;
            // 
            // Item
            // 
            this.Item.HeaderText = "Item";
            this.Item.Name = "Item";
            this.Item.ReadOnly = true;
            this.Item.Width = 200;
            // 
            // PriceEach
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "C2";
            dataGridViewCellStyle4.NullValue = "<Missing>";
            this.PriceEach.DefaultCellStyle = dataGridViewCellStyle4;
            this.PriceEach.HeaderText = "Price Each";
            this.PriceEach.Name = "PriceEach";
            this.PriceEach.ReadOnly = true;
            // 
            // Quantity
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "N0";
            dataGridViewCellStyle5.NullValue = "<Missing>";
            this.Quantity.DefaultCellStyle = dataGridViewCellStyle5;
            this.Quantity.HeaderText = "Quantity";
            this.Quantity.Name = "Quantity";
            this.Quantity.ReadOnly = true;
            // 
            // Total
            // 
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.Format = "C2";
            dataGridViewCellStyle6.NullValue = null;
            this.Total.DefaultCellStyle = dataGridViewCellStyle6;
            this.Total.HeaderText = "Total";
            this.Total.Name = "Total";
            this.Total.ReadOnly = true;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(316, 25);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 27;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // txtQuantity
            // 
            this.txtQuantity.Location = new System.Drawing.Point(74, 58);
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.Size = new System.Drawing.Size(57, 20);
            this.txtQuantity.TabIndex = 25;
            this.txtQuantity.Text = "12";
            this.txtQuantity.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.Location = new System.Drawing.Point(13, 61);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(46, 13);
            this.Label3.TabIndex = 28;
            this.Label3.Text = "Quantity";
            // 
            // txtPriceEach
            // 
            this.txtPriceEach.Location = new System.Drawing.Point(74, 32);
            this.txtPriceEach.Name = "txtPriceEach";
            this.txtPriceEach.Size = new System.Drawing.Size(57, 20);
            this.txtPriceEach.TabIndex = 24;
            this.txtPriceEach.Text = "0.10";
            this.txtPriceEach.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Location = new System.Drawing.Point(13, 35);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(59, 13);
            this.Label2.TabIndex = 26;
            this.Label2.Text = "Price Each";
            // 
            // txtItem
            // 
            this.txtItem.Location = new System.Drawing.Point(74, 6);
            this.txtItem.Name = "txtItem";
            this.txtItem.Size = new System.Drawing.Size(165, 20);
            this.txtItem.TabIndex = 22;
            this.txtItem.Text = "Pencils";
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(13, 9);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(27, 13);
            this.Label1.TabIndex = 23;
            this.Label1.Text = "Item";
            // 
            // howto_datagridview_format_columns_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(574, 251);
            this.Controls.Add(this.dgvValues);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.txtQuantity);
            this.Controls.Add(this.Label3);
            this.Controls.Add(this.txtPriceEach);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.txtItem);
            this.Controls.Add(this.Label1);
            this.Name = "howto_datagridview_format_columns_Form1";
            this.Text = "howto_datagridview_format_columns";
            this.Load += new System.EventHandler(this.howto_datagridview_format_columns_Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvValues)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.DataGridView dgvValues;
        private System.Windows.Forms.DataGridViewTextBoxColumn Item;
        private System.Windows.Forms.DataGridViewTextBoxColumn PriceEach;
        private System.Windows.Forms.DataGridViewTextBoxColumn Quantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn Total;
        internal System.Windows.Forms.Button btnAdd;
        internal System.Windows.Forms.TextBox txtQuantity;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.TextBox txtPriceEach;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.TextBox txtItem;
        internal System.Windows.Forms.Label Label1;
    }
}

