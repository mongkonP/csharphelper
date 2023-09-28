using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Drawing.Drawing2D;
using System.Drawing.Text;

 

namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_rotated_text_Form1:Form
  { 


        public howto_rotated_text_Form1()
        {
            InitializeComponent();
        }

        private void howto_rotated_text_Form1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;

            using (Font the_font = new Font("Comic Sans MS", 20))
            {
                const int dx = 50;
                int x = 20, y = 150;
                DrawRotatedTextAt(e.Graphics, -90, "January", x, y, the_font, Brushes.Red);
                x += dx;
                DrawRotatedTextAt(e.Graphics, -90, "February", x, y, the_font, Brushes.Red);
                x += dx;
                DrawRotatedTextAt(e.Graphics, -90, "March", x, y, the_font, Brushes.Red);
                x += dx;
                DrawRotatedTextAt(e.Graphics, -90, "April", x, y, the_font, Brushes.Red);
                x += dx;
                DrawRotatedTextAt(e.Graphics, -90, "May", x, y, the_font, Brushes.Red);
                x += dx;
                DrawRotatedTextAt(e.Graphics, -90, "June", x, y, the_font, Brushes.Red);
                x += dx;
                DrawRotatedTextAt(e.Graphics, -90, "July", x, y, the_font, Brushes.Red);
                x += dx;
                DrawRotatedTextAt(e.Graphics, -90, "August", x, y, the_font, Brushes.Red);
                x += dx;
                DrawRotatedTextAt(e.Graphics, -90, "September", x, y, the_font, Brushes.Red);
                x += dx;
                DrawRotatedTextAt(e.Graphics, -90, "October", x, y, the_font, Brushes.Red);
                x += dx;
                DrawRotatedTextAt(e.Graphics, -90, "November", x, y, the_font, Brushes.Red);
                x += dx;
                DrawRotatedTextAt(e.Graphics, -90, "December", x, y, the_font, Brushes.Red);
            }
        }

        // Draw a rotated string at a particular position.
        private void DrawRotatedTextAt(Graphics gr, float angle, string txt, int x, int y, Font the_font, Brush the_brush)
        {
            // Save the graphics state.
            GraphicsState state = gr.Save();
            gr.ResetTransform();

            // Rotate.
            gr.RotateTransform(angle);

            // Translate to desired position. Be sure to append
            // the rotation so it occurs after the rotation.
            gr.TranslateTransform(x, y, MatrixOrder.Append);

            // Draw the text at the origin.
            gr.DrawString(txt, the_font, the_brush, 0, 0);

            // Restore the graphics state.
            gr.Restore(state);
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
            // howto_rotated_text_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(642, 264);
            this.Name = "howto_rotated_text_Form1";
            this.Text = "howto_rotated_text";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.howto_rotated_text_Form1_Paint);
            this.ResumeLayout(false);

        }

        #endregion
    }
}

