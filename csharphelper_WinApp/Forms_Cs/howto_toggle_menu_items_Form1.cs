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
     public partial class howto_toggle_menu_items_Form1:Form
  { 


        public howto_toggle_menu_items_Form1()
        {
            InitializeComponent();
        }

        // Toggle the Inverted Colors feature.
        private void mnuAppearanceInverted_Click(object sender, EventArgs e)
        {
            if (mnuAppearanceInverted.Checked)
            {
                this.BackColor = SystemColors.ControlText;
                this.ForeColor = SystemColors.Control;
            }
            else
            {
                this.BackColor = SystemColors.Control;
                this.ForeColor = SystemColors.ControlText;
            }

            // The GroupBox doesn't automatically inherit ForeColor.
            groupBox1.ForeColor = this.ForeColor;
        }

        // Toggle the Bold feature.
        private void mnuAppearanceBold_Click(object sender, EventArgs e)
        {
            if (mnuAppearanceBold.Checked)
            {
                this.Font = new Font(this.Font, FontStyle.Bold);
            }
            else
            {
                this.Font = new Font(this.Font, FontStyle.Regular);
            }
        }

        // Toggle the Mistral feature.
        private void mnuAppearanceMistral_Click(object sender, EventArgs e)
        {
            if (mnuAppearanceMistral.Checked)
            {
                this.Font = new Font("Mistral", this.Font.Size, this.Font.Style);
            }
            else
            {
                this.Font = new Font("Microsoft Sans Serif", this.Font.Size, this.Font.Style);
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.appearanceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuAppearanceInverted = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuAppearanceBold = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuAppearanceMistral = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.appearanceToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(9, 3, 0, 3);
            this.menuStrip1.Size = new System.Drawing.Size(327, 25);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // appearanceToolStripMenuItem
            // 
            this.appearanceToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuAppearanceInverted,
            this.mnuAppearanceBold,
            this.mnuAppearanceMistral});
            this.appearanceToolStripMenuItem.Name = "appearanceToolStripMenuItem";
            this.appearanceToolStripMenuItem.Size = new System.Drawing.Size(82, 19);
            this.appearanceToolStripMenuItem.Text = "Appearance";
            // 
            // mnuAppearanceInverted
            // 
            this.mnuAppearanceInverted.CheckOnClick = true;
            this.mnuAppearanceInverted.Name = "mnuAppearanceInverted";
            this.mnuAppearanceInverted.Size = new System.Drawing.Size(154, 22);
            this.mnuAppearanceInverted.Text = "Inverted Colors";
            this.mnuAppearanceInverted.Click += new System.EventHandler(this.mnuAppearanceInverted_Click);
            // 
            // mnuAppearanceBold
            // 
            this.mnuAppearanceBold.CheckOnClick = true;
            this.mnuAppearanceBold.Name = "mnuAppearanceBold";
            this.mnuAppearanceBold.Size = new System.Drawing.Size(154, 22);
            this.mnuAppearanceBold.Text = "Bold";
            this.mnuAppearanceBold.Click += new System.EventHandler(this.mnuAppearanceBold_Click);
            // 
            // mnuAppearanceMistral
            // 
            this.mnuAppearanceMistral.CheckOnClick = true;
            this.mnuAppearanceMistral.Name = "mnuAppearanceMistral";
            this.mnuAppearanceMistral.Size = new System.Drawing.Size(154, 22);
            this.mnuAppearanceMistral.Text = "Mistral";
            this.mnuAppearanceMistral.Click += new System.EventHandler(this.mnuAppearanceMistral_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(13, 30);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Size = new System.Drawing.Size(300, 154);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(50, 48);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Blah, blah, blah";
            // 
            // howto_toggle_menu_items_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(327, 198);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "howto_toggle_menu_items_Form1";
            this.Text = "howto_toggle_menu_items";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem appearanceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuAppearanceInverted;
        private System.Windows.Forms.ToolStripMenuItem mnuAppearanceBold;
        private System.Windows.Forms.ToolStripMenuItem mnuAppearanceMistral;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
    }
}

