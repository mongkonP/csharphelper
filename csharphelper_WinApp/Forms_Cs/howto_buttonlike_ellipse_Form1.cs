using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Drawing.Drawing2D;

 

namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_buttonlike_ellipse_Form1:Form
  { 


        public howto_buttonlike_ellipse_Form1()
        {
            InitializeComponent();
        }

        // Redraw on resize.
        private void howto_buttonlike_ellipse_Form1_Load(object sender, EventArgs e)
        {
            this.ResizeRedraw = true;
        }

        // Draw the button-like ellipse.
        private void howto_buttonlike_ellipse_Form1_Paint(object sender, PaintEventArgs e)
        {
            // Clear.
            e.Graphics.Clear(this.BackColor);
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            // Get the area we will fill.
            Rectangle rect = new Rectangle(30, 30,
                this.ClientSize.Width - 60,
                this.ClientSize.Height - 60);

            // Fill the ellipse.
            using (LinearGradientBrush br =
                new LinearGradientBrush(rect,
                    Color.Lime, Color.DarkGreen, 225f))
            {
                e.Graphics.FillEllipse(br, rect);
            }

            // Outline the ellipse.
            using (LinearGradientBrush br =
                new LinearGradientBrush(rect,
                    Color.Lime, Color.DarkGreen, 45f))
            {
                using (Pen pen = new Pen(br, 20f))
                {
                    // e.Graphics.DrawRectangle(Pens.Red, rect);
                    rect.X += 10;
                    rect.Y += 10;
                    rect.Width -= 20;
                    rect.Height -= 20;

                    e.Graphics.DrawEllipse(pen, rect);
                }
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
            this.SuspendLayout();
            // 
            // howto_buttonlike_ellipse_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(300, 190);
            this.Name = "howto_buttonlike_ellipse_Form1";
            this.Text = "howto_buttonlike_ellipse";
            this.Load += new System.EventHandler(this.howto_buttonlike_ellipse_Form1_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.howto_buttonlike_ellipse_Form1_Paint);
            this.ResumeLayout(false);

        }

        #endregion
    }
}

