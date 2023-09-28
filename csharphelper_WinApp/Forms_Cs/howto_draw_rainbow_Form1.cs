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
     public partial class howto_draw_rainbow_Form1:Form
  { 


        public howto_draw_rainbow_Form1()
        {
            InitializeComponent();
        }

        // Redraw on resize.
        private void howto_draw_rainbow_Form1_Load(object sender, EventArgs e)
        {
            this.ResizeRedraw = true;
        }

        // Draw rainbow colors on the form.
        private void howto_draw_rainbow_Form1_Paint(object sender, PaintEventArgs e)
        {
            int wid = this.ClientSize.Width;
            int hgt = this.ClientSize.Height;
            int hgt2 = (int)(hgt / 2);
            for (int x = 0; x < wid; x++)
            {
                using (Pen the_pen = new Pen(MapRainbowColor(x, 0, wid)))
                {
                    e.Graphics.DrawLine(the_pen, x, 0, x, hgt2);
                }
                using (Pen the_pen = new Pen(MapRainbowColor(x, wid, 0)))
                {
                    e.Graphics.DrawLine(the_pen, x, hgt2, x, hgt);
                }
            }
        }

        // Map a value to a rainbow color.
        private Color MapRainbowColor(float value, float red_value, float blue_value)
        {
            // Convert into a value between 0 and 1023.
            int int_value = (int)(1023 * (value - red_value) / (blue_value - red_value));

            // Map different color bands.
            if (int_value < 256)
            {
                // Red to yellow. (255, 0, 0) to (255, 255, 0).
                return Color.FromArgb(255, int_value, 0);
            }
            else if (int_value < 512)
            {
                // Yellow to green. (255, 255, 0) to (0, 255, 0).
                int_value -= 256;
                return Color.FromArgb(255 - int_value, 255, 0);
            }
            else if (int_value < 768)
            {
                // Green to aqua. (0, 255, 0) to (0, 255, 255).
                int_value -= 512;
                return Color.FromArgb(0, 255, int_value);
            }
            else
            {
                // Aqua to blue. (0, 255, 255) to (0, 0, 255).
                int_value -= 768;
                return Color.FromArgb(0, 255 - int_value, 255);
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
            // howto_draw_rainbow_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 114);
            this.Name = "howto_draw_rainbow_Form1";
            this.Text = "howto_draw_rainbow";
            this.Load += new System.EventHandler(this.howto_draw_rainbow_Form1_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.howto_draw_rainbow_Form1_Paint);
            this.ResumeLayout(false);

        }

        #endregion

    }
}

