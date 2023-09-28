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
     public partial class howto_find_file_in_startup_dir_Form1:Form
  { 


        public howto_find_file_in_startup_dir_Form1()
        {
            InitializeComponent();
        }

        private void howto_find_file_in_startup_dir_Form1_Load(object sender, EventArgs e)
        {
            string filename = Path.Combine(
                Application.StartupPath, "Greeting.rtf");
            rchGreeting.LoadFile(filename);
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
            this.rchGreeting = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // rchGreeting
            // 
            this.rchGreeting.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rchGreeting.Location = new System.Drawing.Point(0, 0);
            this.rchGreeting.Name = "rchGreeting";
            this.rchGreeting.Size = new System.Drawing.Size(284, 61);
            this.rchGreeting.TabIndex = 1;
            this.rchGreeting.Text = "";
            // 
            // howto_find_file_in_startup_dir_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 61);
            this.Controls.Add(this.rchGreeting);
            this.Name = "howto_find_file_in_startup_dir_Form1";
            this.Text = "howto_find_file_in_startup_dir";
            this.Load += new System.EventHandler(this.howto_find_file_in_startup_dir_Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox rchGreeting;
    }
}

