using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.IO;

 

namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_create_directory_Form1:Form
  { 


        public howto_create_directory_Form1()
        {
            InitializeComponent();
        }

        // Start with a directory below the startup directory.
        private void howto_create_directory_Form1_Load(object sender, EventArgs e)
        {
            txtDirectory.Text = Path.Combine(Application.StartupPath, "DirA\\DirB\\DirC");
        }

        // Create the directory.
        private void btnCreate_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(txtDirectory.Text))
            {
                MessageBox.Show("This directory already exists.",
                    "Already Exists", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            else
            {
                Directory.CreateDirectory(txtDirectory.Text);
                MessageBox.Show("Directory created.",
                    "Directory Created", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
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
            this.btnCreate = new System.Windows.Forms.Button();
            this.txtDirectory = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnCreate
            // 
            this.btnCreate.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnCreate.Location = new System.Drawing.Point(130, 43);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(75, 23);
            this.btnCreate.TabIndex = 5;
            this.btnCreate.Text = "Create";
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // txtDirectory
            // 
            this.txtDirectory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDirectory.Location = new System.Drawing.Point(70, 12);
            this.txtDirectory.Name = "txtDirectory";
            this.txtDirectory.Size = new System.Drawing.Size(252, 20);
            this.txtDirectory.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Directory:";
            // 
            // howto_create_directory_Form1
            // 
            this.AcceptButton = this.btnCreate;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(334, 78);
            this.Controls.Add(this.btnCreate);
            this.Controls.Add(this.txtDirectory);
            this.Controls.Add(this.label1);
            this.Name = "howto_create_directory_Form1";
            this.Text = "howto_create_directory";
            this.Load += new System.EventHandler(this.howto_create_directory_Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.TextBox txtDirectory;
        private System.Windows.Forms.Label label1;
    }
}

