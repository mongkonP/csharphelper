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
     public partial class howto_convert_rectangles_Form1:Form
  { 


        public howto_convert_rectangles_Form1()
        {
            InitializeComponent();
        }

        private void howto_convert_rectangles_Form1_Load(object sender, EventArgs e)
        {
            this.ResizeRedraw = true;
        }

        private void howto_convert_rectangles_Form1_Paint(object sender, PaintEventArgs e)
        {
            // Make a rectangle.
            Rectangle rect1 = new Rectangle(20, 20,
                this.ClientSize.Width - 40,
                this.ClientSize.Height - 40);

            // Convert to RectangleF.
            RectangleF rectf = rect1;

            // Convert back to Rectangle.
            Rectangle rect2 = Rectangle.Round(rectf);
            //Rectangle rect2 = Rectangle.Truncate(rectf);

            // Draw them.
            using (Pen the_pen = new Pen(Color.Red, 20))
            {
                e.Graphics.DrawRectangle(the_pen, rect1);

                the_pen.Color = Color.Lime;
                the_pen.Width = 10;
                e.Graphics.DrawRectangle(the_pen,
                    rectf.X, rectf.Y, rectf.Width, rectf.Height);

                the_pen.Color = Color.Blue;
                the_pen.Width = 1;
                e.Graphics.DrawRectangle(the_pen, rect2);
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
            // howto_convert_rectangles_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(334, 161);
            this.Name = "howto_convert_rectangles_Form1";
            this.Text = "howto_convert_rectangles";
            this.Load += new System.EventHandler(this.howto_convert_rectangles_Form1_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.howto_convert_rectangles_Form1_Paint);
            this.ResumeLayout(false);

        }

        #endregion
    }
}

