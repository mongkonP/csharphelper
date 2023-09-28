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
     public partial class howto_arrange_listbox_Form1:Form
  { 


        public howto_arrange_listbox_Form1()
        {
            InitializeComponent();
        }

        // Enable and disable the appropriate buttons.
        private void lstAnimals_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnUp.Enabled = (lstAnimals.SelectedIndex > 0);
            btnToTop.Enabled = btnUp.Enabled;
            btnDown.Enabled = (lstAnimals.SelectedIndex < lstAnimals.Items.Count - 1);
            btnToBottom.Enabled = btnDown.Enabled;
        }

        // Move the selected item to the top of the list (index 0).
        private void btnToTop_Click(object sender, EventArgs e)
        {
            object item = lstAnimals.SelectedItem;
            lstAnimals.Items.RemoveAt(lstAnimals.SelectedIndex);
            lstAnimals.Items.Insert(0, item);
            lstAnimals.SelectedIndex = 0;
        }

        // Move the selected item up one position.
        private void btnUp_Click(object sender, EventArgs e)
        {
            int index = lstAnimals.SelectedIndex;
            object item = lstAnimals.SelectedItem;
            lstAnimals.Items.RemoveAt(lstAnimals.SelectedIndex);
            lstAnimals.Items.Insert(index - 1, item);
            lstAnimals.SelectedIndex = index - 1;
        }

        // Move the selected item down one position.
        private void btnDown_Click(object sender, EventArgs e)
        {
            int index = lstAnimals.SelectedIndex;
            object item = lstAnimals.SelectedItem;
            lstAnimals.Items.RemoveAt(lstAnimals.SelectedIndex);
            lstAnimals.Items.Insert(index + 1, item);
            lstAnimals.SelectedIndex = index + 1;
        }

        // Move the selected item to the end of the list.
        private void btnToBottom_Click(object sender, EventArgs e)
        {
            object item = lstAnimals.SelectedItem;
            lstAnimals.Items.RemoveAt(lstAnimals.SelectedIndex);
            lstAnimals.Items.Add(item);
            lstAnimals.SelectedIndex = lstAnimals.Items.Count - 1;
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
            this.lstAnimals = new System.Windows.Forms.ListBox();
            this.btnUp = new System.Windows.Forms.Button();
            this.btnDown = new System.Windows.Forms.Button();
            this.btnToBottom = new System.Windows.Forms.Button();
            this.btnToTop = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lstAnimals
            // 
            this.lstAnimals.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lstAnimals.FormattingEnabled = true;
            this.lstAnimals.IntegralHeight = false;
            this.lstAnimals.Items.AddRange(new object[] {
            "Aardvark",
            "Binturong",
            "Cuttlefish",
            "Dugong",
            "Emu",
            "Frigatebird",
            "Gharial",
            "Hare",
            "Indri",
            "Jackal",
            "Kakapo",
            "Liger",
            "Mandrill",
            "Numbat",
            "Okapi",
            "Platypus",
            "Quetzal",
            "Rhinoceros",
            "Serval",
            "Toucan",
            "Uakari",
            "Vulture",
            "Warthog",
            "Xolmis",
            "Yak",
            "Zonkey"});
            this.lstAnimals.Location = new System.Drawing.Point(12, 12);
            this.lstAnimals.Name = "lstAnimals";
            this.lstAnimals.Size = new System.Drawing.Size(224, 237);
            this.lstAnimals.TabIndex = 0;
            this.lstAnimals.SelectedIndexChanged += new System.EventHandler(this.lstAnimals_SelectedIndexChanged);
            // 
            // btnUp
            // 
            this.btnUp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUp.Enabled = false;
            this.btnUp.Image = Properties.Resources.Up;
            this.btnUp.Location = new System.Drawing.Point(242, 48);
            this.btnUp.Name = "btnUp";
            this.btnUp.Size = new System.Drawing.Size(40, 30);
            this.btnUp.TabIndex = 2;
            this.btnUp.UseVisualStyleBackColor = true;
            this.btnUp.Click += new System.EventHandler(this.btnUp_Click);
            // 
            // btnDown
            // 
            this.btnDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDown.Enabled = false;
            this.btnDown.Image = Properties.Resources.Down;
            this.btnDown.Location = new System.Drawing.Point(242, 84);
            this.btnDown.Name = "btnDown";
            this.btnDown.Size = new System.Drawing.Size(40, 30);
            this.btnDown.TabIndex = 3;
            this.btnDown.UseVisualStyleBackColor = true;
            this.btnDown.Click += new System.EventHandler(this.btnDown_Click);
            // 
            // btnToBottom
            // 
            this.btnToBottom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnToBottom.Enabled = false;
            this.btnToBottom.Image = Properties.Resources.to_bottom;
            this.btnToBottom.Location = new System.Drawing.Point(242, 120);
            this.btnToBottom.Name = "btnToBottom";
            this.btnToBottom.Size = new System.Drawing.Size(40, 30);
            this.btnToBottom.TabIndex = 4;
            this.btnToBottom.UseVisualStyleBackColor = true;
            this.btnToBottom.Click += new System.EventHandler(this.btnToBottom_Click);
            // 
            // btnToTop
            // 
            this.btnToTop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnToTop.Enabled = false;
            this.btnToTop.Image = Properties.Resources.to_top;
            this.btnToTop.Location = new System.Drawing.Point(242, 12);
            this.btnToTop.Name = "btnToTop";
            this.btnToTop.Size = new System.Drawing.Size(40, 30);
            this.btnToTop.TabIndex = 1;
            this.btnToTop.UseVisualStyleBackColor = true;
            this.btnToTop.Click += new System.EventHandler(this.btnToTop_Click);
            // 
            // howto_arrange_listbox_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(294, 261);
            this.Controls.Add(this.btnToBottom);
            this.Controls.Add(this.btnDown);
            this.Controls.Add(this.btnUp);
            this.Controls.Add(this.btnToTop);
            this.Controls.Add(this.lstAnimals);
            this.Name = "howto_arrange_listbox_Form1";
            this.Text = "howto_arrange_listbox";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lstAnimals;
        private System.Windows.Forms.Button btnToTop;
        private System.Windows.Forms.Button btnUp;
        private System.Windows.Forms.Button btnDown;
        private System.Windows.Forms.Button btnToBottom;
    }
}

