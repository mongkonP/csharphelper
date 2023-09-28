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
     public partial class howto_transparent_form_Form1:Form
  { 


        public howto_transparent_form_Form1()
        {
            InitializeComponent();
        }
        
        // Set the form's TransparencyKey and BackColor
        // to the image's transparent color.

        // On mouse down, start moving the form.
        private void howto_transparent_form_Form1_MouseDown(object sender, MouseEventArgs e)
        {
            const int WM_NCLBUTTONDOWN = 0xA1;
            const int HT_CAPTION = 0x2;
            this.Capture = false;
            Message msg = Message.Create(this.Handle,
                WM_NCLBUTTONDOWN, (IntPtr)HT_CAPTION, IntPtr.Zero);
            WndProc(ref msg);
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
            // howto_transparent_form_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = Properties.Resources.Smiley;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(309, 310);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "howto_transparent_form_Form1";
            this.Text = "howto_transparent_form_Form1";
            this.TransparencyKey = System.Drawing.Color.White;
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.howto_transparent_form_Form1_MouseDown);
            this.ResumeLayout(false);

        }

        #endregion
    }
}

