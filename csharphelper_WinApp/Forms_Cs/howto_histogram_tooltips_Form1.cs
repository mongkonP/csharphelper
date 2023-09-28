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
     public partial class howto_histogram_tooltips_Form1:Form
  { 


        public howto_histogram_tooltips_Form1()
        {
            InitializeComponent();
        }

        private const int MIN_VALUE = 0;
        private const int MAX_VALUE = 100;

        private float[] DataValues = new float[10];

        // Make some random data.
        private void howto_histogram_tooltips_Form1_Load(object sender, EventArgs e)
        {
            Random rnd = new Random();

            // Create data.
            for (int i = 0; i < DataValues.Length; i++)
                DataValues[i] = rnd.Next(MIN_VALUE + 5, MAX_VALUE - 5);
        }

        // Draw the histogram.
        private void picHisto_Paint(object sender, PaintEventArgs e)
        {
            DrawHistogram(e.Graphics, picHisto.BackColor, DataValues,
                picHisto.ClientSize.Width, picHisto.ClientSize.Height);
        }

        // Redraw.
        private void picHisto_Resize(object sender, EventArgs e)
        {
            picHisto.Refresh();
        }

        // Draw a histogram.
        private Matrix Transformation;
        private void DrawHistogram(Graphics gr, Color back_color, float[] values, int width, int height)
        {
            Color[] Colors = new Color[] {
                Color.Red, Color.LightGreen, Color.Blue,
                Color.Pink, Color.Green, Color.LightBlue,
                Color.Orange, Color.Yellow, Color.Purple
            };

            gr.Clear(back_color);

            // Make a transformation to the PictureBox.
            RectangleF data_bounds = new RectangleF(0, 0, values.Length, MAX_VALUE);
            PointF[] points =
            {
                new PointF(0, height),
                new PointF(width, height),
                new PointF(0, 0)
            };
            Transformation = new Matrix(data_bounds, points);
            gr.Transform = Transformation;

            // Draw the histogram.
            using (Pen thin_pen = new Pen(Color.Black, 0))
            {
                for (int i = 0; i < values.Length; i++)
                {
                    RectangleF rect = new RectangleF(i, 0, 1, values[i]);
                    using (Brush the_brush = new SolidBrush(Colors[i % Colors.Length]))
                    {
                        gr.FillRectangle(the_brush, rect);
                        gr.DrawRectangle(thin_pen, rect.X, rect.Y, rect.Width, rect.Height);
                    }
                }
            }

            gr.ResetTransform();
            gr.DrawRectangle(Pens.Black, 0, 0, width - 1, height - 1);
        }

        // Record the mouse position.
        private string TipText;
        private void picHisto_MouseMove(object sender, MouseEventArgs e)
        {
            // Determine which data value is under the mouse.
            float bar_wid = picHisto.ClientSize.Width / (int)DataValues.Length;
            int bar_number = (int)(e.X / bar_wid);
            if (bar_number >= DataValues.Length) return;

            // Get the coordinates of the top of the bar.
            PointF[] points =
                { new PointF(0, DataValues[bar_number]) };
            Transformation.TransformPoints(points);

            // See if the mouse is over the bar and not the space above it.
            string tip = "";
            if (e.Y >= points[0].Y) tip =
                "Item " + (bar_number + 1) + " has value " +
                DataValues[bar_number];

            // Update the tooltip if it has changed.
            if (TipText != tip)
            {
                TipText = tip;
                tipBar.SetToolTip(picHisto, tip);
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
            this.components = new System.ComponentModel.Container();
            this.picHisto = new System.Windows.Forms.PictureBox();
            this.tipBar = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.picHisto)).BeginInit();
            this.SuspendLayout();
            // 
            // picHisto
            // 
            this.picHisto.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.picHisto.BackColor = System.Drawing.Color.White;
            this.picHisto.Cursor = System.Windows.Forms.Cursors.Default;
            this.picHisto.Location = new System.Drawing.Point(8, 6);
            this.picHisto.Name = "picHisto";
            this.picHisto.Size = new System.Drawing.Size(392, 192);
            this.picHisto.TabIndex = 2;
            this.picHisto.TabStop = false;
            this.picHisto.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picHisto_MouseMove);
            this.picHisto.Resize += new System.EventHandler(this.picHisto_Resize);
            this.picHisto.Paint += new System.Windows.Forms.PaintEventHandler(this.picHisto_Paint);
            // 
            // howto_histogram_tooltips_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(408, 205);
            this.Controls.Add(this.picHisto);
            this.Name = "howto_histogram_tooltips_Form1";
            this.Text = "howto_histogram_tooltips";
            this.Load += new System.EventHandler(this.howto_histogram_tooltips_Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picHisto)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.PictureBox picHisto;
        private System.Windows.Forms.ToolTip tipBar;
    }
}

