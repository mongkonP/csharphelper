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
     public partial class howto_copy_file_with_executable_Form1:Form
  { 


        public howto_copy_file_with_executable_Form1()
        {
            InitializeComponent();
        }

        // Load the picture from the startup directory.
        private void howto_copy_file_with_executable_Form1_Load(object sender, EventArgs e)
        {
            BackgroundImage = new Bitmap("essential_algs_m.jpg");
            ClientSize = BackgroundImage.Size;
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
            this.SuspendLayout();
            // 
            // howto_copy_file_with_executable_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(318, 264);
            this.Name = "howto_copy_file_with_executable_Form1";
            this.Text = "howto_copy_file_with_executable";
            this.Load += new System.EventHandler(this.howto_copy_file_with_executable_Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion
    }
}

