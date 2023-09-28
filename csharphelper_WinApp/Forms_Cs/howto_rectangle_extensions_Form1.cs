using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Drawing.Drawing2D;

 

using howto_rectangle_extensions;
namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_rectangle_extensions_Form1:Form
  { 


        public howto_rectangle_extensions_Form1()
        {
            InitializeComponent();
        }

        private void howto_rectangle_extensions_Form1_Load(object sender, EventArgs e)
        {
            ResizeRedraw = true;
        }

        private void howto_rectangle_extensions_Form1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            Rectangle rect = new Rectangle(10, 10,
                ClientSize.Width - 20, ClientSize.Height - 20);
            e.Graphics.DrawRectangle(Pens.Red, rect);

            PointF[] points = 
            {
                new PointF(rect.MidX(), rect.Y),
                new PointF(rect.Right, rect.MidY()),
                new PointF(rect.MidX(), rect.Bottom),
                new PointF(rect.Left, rect.MidY()),
            };
            e.Graphics.DrawPolygon(Pens.Blue, points);

            e.Graphics.DrawLine(Pens.Green,
                rect.Center(), new PointF(0, 0));
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
            // howto_rectangle_extensions_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(334, 111);
            this.Name = "howto_rectangle_extensions_Form1";
            this.Text = "howto_rectangle_extensions";
            this.Load += new System.EventHandler(this.howto_rectangle_extensions_Form1_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.howto_rectangle_extensions_Form1_Paint);
            this.ResumeLayout(false);

        }

        #endregion
    }
}

