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
     public partial class howto_elliptical_gradient_Form1:Form
  { 


        public howto_elliptical_gradient_Form1()
        {
            InitializeComponent();
        }

        // Redraw on resize.
        private void howto_elliptical_gradient_Form1_Load(object sender, EventArgs e)
        {
            ResizeRedraw = true;
        }

        // Draw the elliptical gradient background.
        private void howto_elliptical_gradient_Form1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            // Make a GraphicsPath to represent the ellipse.
            Rectangle rect = new Rectangle(
                10, 10,
                this.ClientSize.Width - 20,
                this.ClientSize.Height - 20);
            GraphicsPath path = new GraphicsPath();
            path.AddEllipse(rect);

            // Make a PathGradientBrush from the path.
            using (PathGradientBrush br = new PathGradientBrush(path))
            {
                br.CenterColor = Color.Blue;
                br.SurroundColors = new Color[] { this.BackColor };
                e.Graphics.FillEllipse(br, rect);
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
            // howto_elliptical_gradient_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGreen;
            this.ClientSize = new System.Drawing.Size(334, 161);
            this.Name = "howto_elliptical_gradient_Form1";
            this.Text = "howto_elliptical_gradient";
            this.Load += new System.EventHandler(this.howto_elliptical_gradient_Form1_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.howto_elliptical_gradient_Form1_Paint);
            this.ResumeLayout(false);

        }

        #endregion
    }
}

