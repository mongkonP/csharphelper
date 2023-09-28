using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

 

using howto_add_graphics_methods;
namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_add_graphics_methods_Form1:Form
  { 


        public howto_add_graphics_methods_Form1()
        {
            InitializeComponent();
        }

        // Draw a rectangle.
        private void howto_add_graphics_methods_Form1_Paint(object sender, PaintEventArgs e)
        {
            RectangleF rectf = new RectangleF(10, 10,
                ClientSize.Width - 20, ClientSize.Height - 20);
            e.Graphics.DrawRectangle(Pens.Red, rectf);
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
            // howto_add_graphics_methods_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(334, 161);
            this.Name = "howto_add_graphics_methods_Form1";
            this.Text = "howto_add_graphics_methods";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.howto_add_graphics_methods_Form1_Paint);
            this.ResumeLayout(false);

        }

        #endregion
    }
}

