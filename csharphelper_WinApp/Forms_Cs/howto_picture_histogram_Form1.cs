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
     public partial class howto_picture_histogram_Form1:Form
  { 


        public howto_picture_histogram_Form1()
        {
            InitializeComponent();
        }

        private const int MIN_VALUE = 0;
        private const int MAX_VALUE = 100;
        private float[] DataValues = new float[6];

        // Make some random data.
        private void howto_picture_histogram_Form1_Load(object sender, EventArgs e)
        {
            Random rnd = new Random();

            // Create data.
            for (int i = 0; i < DataValues.Length; i++)
            {
                DataValues[i] = rnd.Next(MIN_VALUE + 5, MAX_VALUE - 5);
                Console.WriteLine(DataValues[i]);//@
            }

            // Size to make each column 64 pixels wide to match the images.
            int pic_wid = 64 * DataValues.Length;
            picHisto.ClientSize = new Size(pic_wid, picHisto.ClientSize.Height);
            int wid = ClientSize.Width - picHisto.Width + pic_wid;
            ClientSize = new Size(wid, ClientSize.Height);
        }

        // Redraw.
        private void howto_picture_histogram_Form1_Resize(object sender, EventArgs e)
        {
            picHisto.Refresh();

        }

        // Draw the histogram.
        private void picHisto_Paint(object sender, PaintEventArgs e)
        {
            // Calculate a transformation to map
            // data values onto the PictureBox.
            float xscale = picHisto.ClientSize.Width / (float)DataValues.Length;
            float yscale = picHisto.ClientSize.Height / (float)(MAX_VALUE - MIN_VALUE);

            DrawHistogram(e.Graphics, picHisto.BackColor, DataValues,
                picHisto.ClientSize.Width, picHisto.ClientSize.Height,
                xscale, yscale);
        }

        // Draw a histogram.
        private void DrawHistogram(Graphics gr, Color back_color,
            float[] values, int width, int height,
            float xscale, float yscale)
        {
            gr.Clear(back_color);

            // The images we will use to fill the rectangles.
            Image[] images =
            {
                Properties.Resources.apple,
                Properties.Resources.banana,
                Properties.Resources.grapes,
                Properties.Resources.pear,
                Properties.Resources.strawberry,
                Properties.Resources.tomato,
            };

            // Draw the histograms.
            for (int i = 0; i < values.Length; i++)
            {
                // Get the rectangle's bounds in device coordinates.
                float rect_wid = xscale;
                float rect_hgt = yscale * values[i];
                float rect_x = i * xscale;
                float rect_y = height - rect_hgt;

                // Make the rectangle.
                RectangleF rect = new RectangleF(
                    rect_x, rect_y, rect_wid, rect_hgt);

                // Fill the rectangle.
                TileRectangle(gr, rect, images[i]);

                // Outline the rectangle.
                gr.DrawRectangle(Pens.Black,
                    rect_x, rect_y, rect_wid, rect_hgt);
            }
        }

        // Display the value clicked.
        private void picHisto_MouseDown(object sender, MouseEventArgs e)
        {
            // Determine which data value was clicked.
            float bar_wid = picHisto.ClientSize.Width / (int)DataValues.Length;
            int i = (int)(e.X / bar_wid);
            MessageBox.Show("Item " + i + " has value " + DataValues[i],
                "Value", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // Tile an area from the bottom left corner up.
        private void TileRectangle(Graphics gr, RectangleF rect, Image picture)
        {
            using (TextureBrush brush = new TextureBrush(picture))
            {
                // Move the brush so it starts in the
                // recrangle's lower left corner.
                brush.TranslateTransform(rect.Left, rect.Bottom);

                // Fill.
                gr.FillRectangle(brush, rect);
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
            this.picHisto = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picHisto)).BeginInit();
            this.SuspendLayout();
            // 
            // picHisto
            // 
            this.picHisto.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.picHisto.BackColor = System.Drawing.Color.White;
            this.picHisto.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.picHisto.Cursor = System.Windows.Forms.Cursors.Cross;
            this.picHisto.Location = new System.Drawing.Point(12, 12);
            this.picHisto.Name = "picHisto";
            this.picHisto.Size = new System.Drawing.Size(384, 235);
            this.picHisto.TabIndex = 2;
            this.picHisto.TabStop = false;
            this.picHisto.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picHisto_MouseDown);
            this.picHisto.Paint += new System.Windows.Forms.PaintEventHandler(this.picHisto_Paint);
            // 
            // howto_picture_histogram_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(408, 259);
            this.Controls.Add(this.picHisto);
            this.Name = "howto_picture_histogram_Form1";
            this.Text = "howto_picture_histogram";
            this.Load += new System.EventHandler(this.howto_picture_histogram_Form1_Load);
            this.Resize += new System.EventHandler(this.howto_picture_histogram_Form1_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.picHisto)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.PictureBox picHisto;
    }
}

