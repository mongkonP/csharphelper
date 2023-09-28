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
     public partial class howto_bmp_to_ico_Form1:Form
  { 


        public howto_bmp_to_ico_Form1()
        {
            InitializeComponent();
        }

        // Convert the bitmap resource to an icon and use it.
        private void howto_bmp_to_ico_Form1_Load(object sender, EventArgs e)
        {
            // Get the bitmap.
            Bitmap bm = new Bitmap(Properties.Resources.Spiral);

            // Convert to an icon and use for the form's icon.
            this.Icon = Icon.FromHandle(bm.GetHicon());
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
            // howto_bmp_to_ico_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 61);
            this.Name = "howto_bmp_to_ico_Form1";
            this.Text = "howto_bmp_to_ico";
            this.Load += new System.EventHandler(this.howto_bmp_to_ico_Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion
    }
}

