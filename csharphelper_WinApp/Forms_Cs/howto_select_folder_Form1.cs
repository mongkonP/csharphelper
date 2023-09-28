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
     public partial class howto_select_folder_Form1:Form
  { 


        public howto_select_folder_Form1()
        {
            InitializeComponent();
        }

        // Restore the saved directory.
        private void howto_select_folder_Form1_Load(object sender, EventArgs e)
        {
            txtDirectory.Text = Properties.Settings.Default.Directory;
        }

        // Save the current directory.
        private void howto_select_folder_Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.Directory = txtDirectory.Text;
            Properties.Settings.Default.Save();
        }

        // Display the folder browser dialog.
        private void btnPickDirectory_Click(object sender, EventArgs e)
        {
            fbdDirectory.SelectedPath = txtDirectory.Text;
            if (fbdDirectory.ShowDialog() == DialogResult.OK)
            {
                txtDirectory.Text = fbdDirectory.SelectedPath;
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
            this.btnPickDirectory = new System.Windows.Forms.Button();
            this.fbdDirectory = new System.Windows.Forms.FolderBrowserDialog();
            this.txtDirectory = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnPickDirectory
            // 
            this.btnPickDirectory.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnPickDirectory.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPickDirectory.Image = Properties.Resources.Ellipsis;
            this.btnPickDirectory.Location = new System.Drawing.Point(345, 19);
            this.btnPickDirectory.Name = "btnPickDirectory";
            this.btnPickDirectory.Size = new System.Drawing.Size(27, 23);
            this.btnPickDirectory.TabIndex = 12;
            this.btnPickDirectory.UseVisualStyleBackColor = true;
            this.btnPickDirectory.Click += new System.EventHandler(this.btnPickDirectory_Click);
            // 
            // txtDirectory
            // 
            this.txtDirectory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDirectory.Location = new System.Drawing.Point(70, 21);
            this.txtDirectory.Name = "txtDirectory";
            this.txtDirectory.Size = new System.Drawing.Size(269, 20);
            this.txtDirectory.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Directory:";
            // 
            // howto_select_folder_Form1
            // 
            this.AcceptButton = this.btnPickDirectory;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 61);
            this.Controls.Add(this.btnPickDirectory);
            this.Controls.Add(this.txtDirectory);
            this.Controls.Add(this.label1);
            this.Name = "howto_select_folder_Form1";
            this.Text = "howto_select_folder";
            this.Load += new System.EventHandler(this.howto_select_folder_Form1_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.howto_select_folder_Form1_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnPickDirectory;
        private System.Windows.Forms.FolderBrowserDialog fbdDirectory;
        private System.Windows.Forms.TextBox txtDirectory;
        private System.Windows.Forms.Label label1;
    }
}

