using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

 

using howto_show_uac_shields;
namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_show_uac_shields_Form1:Form
  { 


        public howto_show_uac_shields_Form1()
        {
            InitializeComponent();
        }

        private void howto_show_uac_shields_Form1_Load(object sender, EventArgs e)
        {
            // Add the shield to a button.
            UacStuff.AddShieldToButton(btnClickMe);

            // Add the shield to a menu item.
            mnuFileFormatHardDrive.ImageScaling = ToolStripItemImageScaling.None;
            mnuFileFormatHardDrive.Image = UacStuff.GetUacShieldImage();

            // Add the shield to a PictureBox and
            // move a LinkLabel next to it.
            picShield.Image = UacStuff.GetUacShieldImage();
            int y = ClientSize.Height - 8 - picShield.Height;
            llblDangerous.Location = new Point(
                btnClickMe.Right - llblDangerous.Width, y);
            picShield.Location = new Point(
                llblDangerous.Left - picShield.Width, y);
        }

        private void mnuFileExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void JustKidding(object sender, EventArgs e)
        {
            MessageBox.Show("Just kidding!", "Just Kidding", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            this.picShield = new System.Windows.Forms.PictureBox();
            this.llblDangerous = new System.Windows.Forms.LinkLabel();
            this.btnClickMe = new System.Windows.Forms.Button();
            this.MenuStrip1 = new System.Windows.Forms.MenuStrip();
            this.FileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFileFormatHardDrive = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFileExit = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.picShield)).BeginInit();
            this.MenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // picShield
            // 
            this.picShield.Location = new System.Drawing.Point(22, 61);
            this.picShield.Name = "picShield";
            this.picShield.Size = new System.Drawing.Size(32, 40);
            this.picShield.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picShield.TabIndex = 7;
            this.picShield.TabStop = false;
            // 
            // llblDangerous
            // 
            this.llblDangerous.AutoSize = true;
            this.llblDangerous.Location = new System.Drawing.Point(60, 74);
            this.llblDangerous.Name = "llblDangerous";
            this.llblDangerous.Size = new System.Drawing.Size(125, 13);
            this.llblDangerous.TabIndex = 6;
            this.llblDangerous.TabStop = true;
            this.llblDangerous.Text = "Do something dangerous";
            this.llblDangerous.Click += new System.EventHandler(this.JustKidding);
            // 
            // btnClickMe
            // 
            this.btnClickMe.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClickMe.Location = new System.Drawing.Point(201, 27);
            this.btnClickMe.Name = "btnClickMe";
            this.btnClickMe.Size = new System.Drawing.Size(88, 40);
            this.btnClickMe.TabIndex = 4;
            this.btnClickMe.Text = "Click Me";
            this.btnClickMe.UseVisualStyleBackColor = true;
            this.btnClickMe.Click += new System.EventHandler(this.JustKidding);
            // 
            // MenuStrip1
            // 
            this.MenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FileToolStripMenuItem});
            this.MenuStrip1.Location = new System.Drawing.Point(0, 0);
            this.MenuStrip1.Name = "MenuStrip1";
            this.MenuStrip1.Size = new System.Drawing.Size(301, 24);
            this.MenuStrip1.TabIndex = 5;
            this.MenuStrip1.Text = "MenuStrip1";
            // 
            // FileToolStripMenuItem
            // 
            this.FileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFileFormatHardDrive,
            this.mnuFileExit});
            this.FileToolStripMenuItem.Name = "FileToolStripMenuItem";
            this.FileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.FileToolStripMenuItem.Text = "&File";
            // 
            // mnuFileFormatHardDrive
            // 
            this.mnuFileFormatHardDrive.Name = "mnuFileFormatHardDrive";
            this.mnuFileFormatHardDrive.Size = new System.Drawing.Size(171, 22);
            this.mnuFileFormatHardDrive.Text = "&Format Hard Drive";
            this.mnuFileFormatHardDrive.Click += new System.EventHandler(this.JustKidding);
            // 
            // mnuFileExit
            // 
            this.mnuFileExit.Name = "mnuFileExit";
            this.mnuFileExit.Size = new System.Drawing.Size(171, 22);
            this.mnuFileExit.Text = "E&xit";
            this.mnuFileExit.Click += new System.EventHandler(this.mnuFileExit_Click);
            // 
            // howto_show_uac_shields_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(301, 114);
            this.Controls.Add(this.picShield);
            this.Controls.Add(this.llblDangerous);
            this.Controls.Add(this.btnClickMe);
            this.Controls.Add(this.MenuStrip1);
            this.Name = "howto_show_uac_shields_Form1";
            this.Text = "howto_show_uac_shields";
            this.Load += new System.EventHandler(this.howto_show_uac_shields_Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picShield)).EndInit();
            this.MenuStrip1.ResumeLayout(false);
            this.MenuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.PictureBox picShield;
        internal System.Windows.Forms.LinkLabel llblDangerous;
        internal System.Windows.Forms.Button btnClickMe;
        internal System.Windows.Forms.MenuStrip MenuStrip1;
        internal System.Windows.Forms.ToolStripMenuItem FileToolStripMenuItem;
        internal System.Windows.Forms.ToolStripMenuItem mnuFileFormatHardDrive;
        internal System.Windows.Forms.ToolStripMenuItem mnuFileExit;
    }
}

