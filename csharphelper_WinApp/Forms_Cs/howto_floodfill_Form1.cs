using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

 

using howto_floodfill;
namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_floodfill_Form1:Form
  { 


        public howto_floodfill_Form1()
        {
            InitializeComponent();
        }

        // The background image.
        private Bitmap bm;
        private Bitmap32 bm32;

        // Make some random circles.
        private void howto_floodfill_Form1_Load(object sender, EventArgs e)
        {
            bm = new Bitmap(ClientSize.Width, ClientSize.Height);
            using (Graphics gr = Graphics.FromImage(bm))
            {
                gr.Clear(Color.Silver);

                Random rnd = new Random();
                int max_r = Math.Min(ClientRectangle.Width, ClientRectangle.Height) / 3;
                int min_r = max_r / 4;
                for (int i = 0; i < 15; i++)
                {
                    int r = rnd.Next(min_r, max_r);
                    int x = rnd.Next(min_r, ClientRectangle.Width - min_r);
                    int y = rnd.Next(min_r, ClientRectangle.Height - min_r);
                    gr.DrawEllipse(Pens.Black, x - r, y - r, 2 * r, 2 * r);
                }
            }

            bm32 = new Bitmap32(bm);

            this.BackgroundImage = bm;
        }

        // Flood the clicked point with a random color.
        private void howto_floodfill_Form1_MouseClick(object sender, MouseEventArgs e)
        {
            // Skip it if it's a black pixel.
            Color old_color = bm.GetPixel(e.X, e.Y);
            if ((old_color.R == 0) && (old_color.G == 0) &&
                (old_color.B == 0)) return;

            // Flood at the pixel.
            bm32.LockBitmap();
            bm32.FloodFill(e.X, e.Y, RandomColor());
            bm32.UnlockBitmap();
            Refresh();
        }

        // Initialize the colors.
        private Color[] colors = 
        {
            Color.Red,
            Color.Orange,
            Color.Yellow,
            Color.Lime,
            Color.Cyan,
            Color.Blue,
            Color.Green,
            Color.Blue,
            Color.LightBlue,
            Color.LightGreen,
            Color.White
        };
        private Random random = new Random();
        private Color RandomColor()
        {
            return colors[random.Next(0, colors.Length)];
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
            // howto_floodfill_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 264);
            this.Name = "howto_floodfill_Form1";
            this.Text = "howto_floodfill";
            this.Load += new System.EventHandler(this.howto_floodfill_Form1_Load);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.howto_floodfill_Form1_MouseClick);
            this.ResumeLayout(false);

        }

        #endregion
    }
}

