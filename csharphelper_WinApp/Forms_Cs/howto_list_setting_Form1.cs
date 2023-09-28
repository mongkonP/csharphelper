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
     public partial class howto_list_setting_Form1:Form
  { 


        public howto_list_setting_Form1()
        {
            InitializeComponent();
        }

        private void howto_list_setting_Form1_Load(object sender, EventArgs e)
        {
            ListItems();
        }

        // Add an item value.
        private void btnAdd_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Items.Add(txtValue.Text);
            txtValue.Clear();
            txtValue.Focus();
            ListItems();
        }

        // Remove an item value.
        private void btnRemove_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Items.Remove(txtValue.Text);
            txtValue.Clear();
            txtValue.Focus();
            ListItems();
        }

        // List the current items.
        private void ListItems()
        {
            lstItems.DataSource =
                Properties.Settings.Default.Items.Cast<string>().ToArray();
            lstItems.SelectedIndex = -1;
        }

        // Save settings.
        private void howto_list_setting_Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.Save();
        }

        // Display the selected item.
        private void lstItems_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstItems.SelectedItem == null)
                txtValue.Clear();
            else
                txtValue.Text = lstItems.SelectedItem.ToString();
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
            this.lstItems = new System.Windows.Forms.ListBox();
            this.txtValue = new System.Windows.Forms.TextBox();
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lstItems
            // 
            this.lstItems.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lstItems.FormattingEnabled = true;
            this.lstItems.Location = new System.Drawing.Point(12, 41);
            this.lstItems.Name = "lstItems";
            this.lstItems.Size = new System.Drawing.Size(260, 121);
            this.lstItems.TabIndex = 7;
            this.lstItems.SelectedIndexChanged += new System.EventHandler(this.lstItems_SelectedIndexChanged);
            // 
            // txtValue
            // 
            this.txtValue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtValue.Location = new System.Drawing.Point(12, 14);
            this.txtValue.Name = "txtValue";
            this.txtValue.Size = new System.Drawing.Size(98, 20);
            this.txtValue.TabIndex = 4;
            // 
            // btnRemove
            // 
            this.btnRemove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRemove.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnRemove.Location = new System.Drawing.Point(197, 12);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(75, 23);
            this.btnRemove.TabIndex = 6;
            this.btnRemove.Text = "Remove";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnAdd.Location = new System.Drawing.Point(116, 12);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 5;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // howto_list_setting_Form1
            // 
            this.AcceptButton = this.btnAdd;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnRemove;
            this.ClientSize = new System.Drawing.Size(284, 175);
            this.Controls.Add(this.lstItems);
            this.Controls.Add(this.txtValue);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.btnAdd);
            this.Name = "howto_list_setting_Form1";
            this.Text = "howto_list_setting";
            this.Load += new System.EventHandler(this.howto_list_setting_Form1_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.howto_list_setting_Form1_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lstItems;
        internal System.Windows.Forms.TextBox txtValue;
        internal System.Windows.Forms.Button btnRemove;
        internal System.Windows.Forms.Button btnAdd;
    }
}

