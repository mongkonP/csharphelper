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
     public partial class howto_move_between_listboxes_Form1:Form
  { 


        public howto_move_between_listboxes_Form1()
        {
            InitializeComponent();
        }

        // Move selected items to lstSelected.
        private void btnSelect_Click(object sender, EventArgs e)
        {
            MoveSelectedItems(lstUnselected, lstSelected);
        }

        // Move selected items to lstUnselected.
        private void btnDeselect_Click(object sender, EventArgs e)
        {
            MoveSelectedItems(lstSelected, lstUnselected);
        }

        // Move selected items from one ListBox to another.
        private void MoveSelectedItems(ListBox lstFrom, ListBox lstTo)
        {
            while (lstFrom.SelectedItems.Count > 0)
            {
                string item = (string)lstFrom.SelectedItems[0];
                lstTo.Items.Add(item);
                lstFrom.Items.Remove(item);
            }
            SetButtonsEditable();
        }

        // Move all items to lstSelected.
        private void btnSelectAll_Click(object sender, EventArgs e)
        {
            MoveAllItems(lstUnselected, lstSelected);
        }

        // Move all items to lstUnselected.
        private void btnDeselectAll_Click(object sender, EventArgs e)
        {
            MoveAllItems(lstSelected, lstUnselected);
        }

        // Move all items from one ListBox to another.
        private void MoveAllItems(ListBox lstFrom, ListBox lstTo)
        {
            lstTo.Items.AddRange(lstFrom.Items);
            lstFrom.Items.Clear();
            SetButtonsEditable();
        }

        // Enable and disable buttons.
        private void lst_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetButtonsEditable();
        }

        // Enable and disable buttons.
        private void SetButtonsEditable()
        {
            btnSelect.Enabled = (lstUnselected.SelectedItems.Count > 0);
            btnSelectAll.Enabled = (lstUnselected.Items.Count > 0);
            btnDeselect.Enabled = (lstSelected.SelectedItems.Count > 0);
            btnDeselectAll.Enabled = (lstSelected.Items.Count > 0);
        }

        private void howto_move_between_listboxes_Form1_Load(object sender, EventArgs e)
        {
            SetButtonsEditable();
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
            this.lstUnselected = new System.Windows.Forms.ListBox();
            this.lstSelected = new System.Windows.Forms.ListBox();
            this.btnSelect = new System.Windows.Forms.Button();
            this.btnSelectAll = new System.Windows.Forms.Button();
            this.btnDeselectAll = new System.Windows.Forms.Button();
            this.btnDeselect = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lstUnselected
            // 
            this.lstUnselected.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstUnselected.FormattingEnabled = true;
            this.lstUnselected.IntegralHeight = false;
            this.lstUnselected.Items.AddRange(new object[] {
            "Ant",
            "Bear",
            "Cat",
            "Dog",
            "Eagle",
            "Frog",
            "Giraffe"});
            this.lstUnselected.Location = new System.Drawing.Point(3, 3);
            this.lstUnselected.Name = "lstUnselected";
            this.tableLayoutPanel1.SetRowSpan(this.lstUnselected, 4);
            this.lstUnselected.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lstUnselected.Size = new System.Drawing.Size(125, 131);
            this.lstUnselected.TabIndex = 0;
            this.lstUnselected.SelectedIndexChanged += new System.EventHandler(this.lst_SelectedIndexChanged);
            // 
            // lstSelected
            // 
            this.lstSelected.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstSelected.FormattingEnabled = true;
            this.lstSelected.IntegralHeight = false;
            this.lstSelected.Location = new System.Drawing.Point(172, 3);
            this.lstSelected.Name = "lstSelected";
            this.tableLayoutPanel1.SetRowSpan(this.lstSelected, 4);
            this.lstSelected.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lstSelected.Size = new System.Drawing.Size(125, 131);
            this.lstSelected.TabIndex = 1;
            this.lstSelected.SelectedIndexChanged += new System.EventHandler(this.lst_SelectedIndexChanged);
            // 
            // btnSelect
            // 
            this.btnSelect.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnSelect.Location = new System.Drawing.Point(136, 5);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(28, 23);
            this.btnSelect.TabIndex = 2;
            this.btnSelect.Text = ">";
            this.btnSelect.UseVisualStyleBackColor = true;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // btnSelectAll
            // 
            this.btnSelectAll.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnSelectAll.Location = new System.Drawing.Point(136, 39);
            this.btnSelectAll.Name = "btnSelectAll";
            this.btnSelectAll.Size = new System.Drawing.Size(28, 23);
            this.btnSelectAll.TabIndex = 3;
            this.btnSelectAll.Text = ">>";
            this.btnSelectAll.UseVisualStyleBackColor = true;
            this.btnSelectAll.Click += new System.EventHandler(this.btnSelectAll_Click);
            // 
            // btnDeselectAll
            // 
            this.btnDeselectAll.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnDeselectAll.Location = new System.Drawing.Point(136, 73);
            this.btnDeselectAll.Name = "btnDeselectAll";
            this.btnDeselectAll.Size = new System.Drawing.Size(28, 23);
            this.btnDeselectAll.TabIndex = 5;
            this.btnDeselectAll.Text = "<<";
            this.btnDeselectAll.UseVisualStyleBackColor = true;
            this.btnDeselectAll.Click += new System.EventHandler(this.btnDeselectAll_Click);
            // 
            // btnDeselect
            // 
            this.btnDeselect.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnDeselect.Location = new System.Drawing.Point(136, 108);
            this.btnDeselect.Name = "btnDeselect";
            this.btnDeselect.Size = new System.Drawing.Size(28, 23);
            this.btnDeselect.TabIndex = 4;
            this.btnDeselect.Text = "<";
            this.btnDeselect.UseVisualStyleBackColor = true;
            this.btnDeselect.Click += new System.EventHandler(this.btnDeselect_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 38F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.lstUnselected, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lstSelected, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnDeselect, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.btnDeselectAll, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.btnSelect, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnSelectAll, 1, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 12);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(300, 137);
            this.tableLayoutPanel1.TabIndex = 6;
            // 
            // howto_move_between_listboxes_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(324, 161);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "howto_move_between_listboxes_Form1";
            this.Text = "howto_move_between_listboxes";
            this.Load += new System.EventHandler(this.howto_move_between_listboxes_Form1_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lstUnselected;
        private System.Windows.Forms.ListBox lstSelected;
        private System.Windows.Forms.Button btnSelect;
        private System.Windows.Forms.Button btnSelectAll;
        private System.Windows.Forms.Button btnDeselectAll;
        private System.Windows.Forms.Button btnDeselect;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}

