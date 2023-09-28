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
     public partial class howto_use_using_Form1:Form
  { 


        public howto_use_using_Form1()
        {
            InitializeComponent();
        }

        // Redraw on resize.
        private void howto_use_using_Form1_Load(object sender, EventArgs e)
        {
            this.ResizeRedraw = true;
        }

        // Draw a diamond.
        private void howto_use_using_Form1_Paint(object sender, PaintEventArgs e)
        {
            // Clear.
            e.Graphics.Clear(this.BackColor);
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            // Make points to draw a diamond.
            Point[] points =
            {
                new Point((int)(this.ClientSize.Width / 2), 0),
                new Point(this.ClientSize.Width, (int)(this.ClientSize.Height / 2)),
                new Point((int)(this.ClientSize.Width / 2), this.ClientSize.Height),
                new Point(0, (int)(this.ClientSize.Height / 2)),
            };

            // Make the pen.
            using (Pen dashed_pen = new Pen(Color.Red, 10))
            {
                dashed_pen.DashStyle = DashStyle.Dot;
                e.Graphics.DrawPolygon(dashed_pen, points);
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
            // howto_use_using_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 161);
            this.Name = "howto_use_using_Form1";
            this.Text = "howto_use_using";
            this.Load += new System.EventHandler(this.howto_use_using_Form1_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.howto_use_using_Form1_Paint);
            this.ResumeLayout(false);

        }

        #endregion
    }
}

