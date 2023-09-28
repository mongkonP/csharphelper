using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

 

namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_save_serialized_images_Form1:Form
  { 


        public howto_save_serialized_images_Form1()
        {
            InitializeComponent();
        }

        // Save a serialization of the images.
        private void mnuFileSave_Click(object sender, EventArgs e)
        {
            // Get the serialization file name.
            if (sfdSerialization.ShowDialog() == DialogResult.OK)
            {
                // Add the files to a list.
                List<Image> input_images = new List<Image>();
                input_images.Add((Bitmap)picSource1.Image);
                input_images.Add((Bitmap)picSource2.Image);
                input_images.Add((Bitmap)picSource3.Image);

                // Serialize.
                using (FileStream fs = new FileStream(
                    sfdSerialization.FileName, FileMode.Create))
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    formatter.Serialize(fs, input_images);
                }
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
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
            this.picSource3 = new System.Windows.Forms.PictureBox();
            this.picSource2 = new System.Windows.Forms.PictureBox();
            this.picSource1 = new System.Windows.Forms.PictureBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.sfdSerialization = new System.Windows.Forms.SaveFileDialog();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFileSave = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.picSource3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picSource2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picSource1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // picSource3
            // 
            this.picSource3.Image = Properties.Resources.interview_puzzles_dissected;
            this.picSource3.Location = new System.Drawing.Point(345, 27);
            this.picSource3.Name = "picSource3";
            this.picSource3.Size = new System.Drawing.Size(161, 200);
            this.picSource3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picSource3.TabIndex = 5;
            this.picSource3.TabStop = false;
            // 
            // picSource2
            // 
            this.picSource2.Image = Properties.Resources.wpf3d;
            this.picSource2.Location = new System.Drawing.Point(176, 27);
            this.picSource2.Name = "picSource2";
            this.picSource2.Size = new System.Drawing.Size(163, 200);
            this.picSource2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picSource2.TabIndex = 4;
            this.picSource2.TabStop = false;
            // 
            // picSource1
            // 
            this.picSource1.Image = Properties.Resources.essential_algorithms2e;
            this.picSource1.Location = new System.Drawing.Point(12, 27);
            this.picSource1.Name = "picSource1";
            this.picSource1.Size = new System.Drawing.Size(158, 200);
            this.picSource1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picSource1.TabIndex = 3;
            this.picSource1.TabStop = false;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(518, 24);
            this.menuStrip1.TabIndex = 6;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // sfdSerialization
            // 
            this.sfdSerialization.DefaultExt = "dat";
            this.sfdSerialization.FileName = "Images.dat";
            this.sfdSerialization.Filter = "data FIles|*.dat|All FIles|*.*";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFileSave,
            this.toolStripMenuItem1,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // mnuFileSave
            // 
            this.mnuFileSave.Name = "mnuFileSave";
            this.mnuFileSave.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.mnuFileSave.Size = new System.Drawing.Size(221, 22);
            this.mnuFileSave.Text = "&Save Serialization...";
            this.mnuFileSave.Click += new System.EventHandler(this.mnuFileSave_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(210, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(213, 22);
            this.exitToolStripMenuItem.Text = "E&xit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // howto_save_serialized_images_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(518, 241);
            this.Controls.Add(this.picSource3);
            this.Controls.Add(this.picSource2);
            this.Controls.Add(this.picSource1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "howto_save_serialized_images_Form1";
            this.Text = "howto_save_serialized_images";
            ((System.ComponentModel.ISupportInitialize)(this.picSource3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picSource2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picSource1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picSource3;
        private System.Windows.Forms.PictureBox picSource2;
        private System.Windows.Forms.PictureBox picSource1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuFileSave;
        private System.Windows.Forms.SaveFileDialog sfdSerialization;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
    }
}

