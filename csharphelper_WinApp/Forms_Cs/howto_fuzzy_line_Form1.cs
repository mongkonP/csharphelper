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
     public partial class howto_fuzzy_line_Form1:Form
  { 


        public howto_fuzzy_line_Form1()
        {
            InitializeComponent();
        }

        private void howto_fuzzy_line_Form1_Load(object sender, EventArgs e)
        {
            ArrangeControls();
        }
        private void howto_fuzzy_line_Form1_Resize(object sender, EventArgs e)
        {
            ArrangeControls();
        }
        private void ArrangeControls()
        {
            int margin = picThin.Left;
            int width = (ClientSize.Width - 3 * margin) / 2;
            if (width < 10) width = 10;
            int height = ClientSize.Height - 2 * margin;
            if (height < 10) height = 10;

            picThin.Size = new Size(width, height);
            picFuzzy.Location = new Point(picThin.Right + margin, picThin.Top);
            picFuzzy.Size = new Size(width, height);

            picThin.Refresh();
            picFuzzy.Refresh();
        }

        // Return a GraphicsPath representing a smiley face.
        private GraphicsPath MakeSmileyPath(Size size)
        {
            GraphicsPath path = new GraphicsPath();

            // Head.
            RectangleF rect;
            rect = new RectangleF(
                size.Width * 0.1f,
                size.Height * 0.1f,
                size.Width * 0.8f,
                size.Height * 0.8f);
            path.AddEllipse(rect);

            // Smile.
            rect = new RectangleF(
                size.Width * 0.25f,
                size.Height * 0.25f,
                size.Width * 0.5f,
                size.Height * 0.5f);
            path.AddArc(rect, 20, 140);

            // Nose.
            rect = new RectangleF(
                size.Width * 0.45f,
                size.Height * 0.4f,
                size.Width * 0.1f,
                size.Height * 0.2f);
            path.AddEllipse(rect);

            // Left eye.
            rect = new RectangleF(
                size.Width * 0.3f,
                size.Height * 0.3f,
                size.Width * 0.1f,
                size.Height * 0.2f);
            path.AddEllipse(rect);
            rect.Width /= 2;
            rect.Height /= 2;
            rect.X += rect.Width;
            rect.Y += rect.Height / 2;
            path.AddEllipse(rect);

            // Right eye.
            rect = new RectangleF(
                size.Width * 0.6f,
                size.Height * 0.3f,
                size.Width * 0.1f,
                size.Height * 0.2f);
            path.AddEllipse(rect);
            rect.Width /= 2;
            rect.Height /= 2;
            rect.X += rect.Width;
            rect.Y += rect.Height / 2;
            path.AddEllipse(rect);

            return path;
        }

        // Draw a smiley with a thin line shadow.
        private void picThin_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            DrawBackground(e.Graphics, picThin.ClientSize);

            // Make the smiley path.
            using (GraphicsPath path = MakeSmileyPath(picThin.ClientSize))
            {
                // Draw the shadow.
                e.Graphics.TranslateTransform(6, 6);
                Color color = Color.FromArgb(64, 0, 0, 0);
                using (Pen thick_pen = new Pen(color, 5))
                {
                    e.Graphics.DrawPath(thick_pen, path);
                }
                e.Graphics.ResetTransform();

                // Draw the face.
                using (Pen thick_pen = new Pen(Color.Black, 3))
                {
                    e.Graphics.DrawPath(thick_pen, path);
                }
            }
        }

        // Draw a smiley with a fuzzy line shadow.
        private void picFuzzy_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            DrawBackground(e.Graphics, picFuzzy.ClientSize);

            // Make the smiley path.
            using (GraphicsPath path = MakeSmileyPath(picThin.ClientSize))
            {
                // Draw the shadow.
                e.Graphics.TranslateTransform(6, 6);
                DrawPathWithFuzzyLine(path, e.Graphics, Color.Black, 200, 20, 2);
                e.Graphics.ResetTransform();

                // Draw the face.
                using (Pen thick_pen = new Pen(Color.Black, 3))
                {
                    e.Graphics.DrawPath(thick_pen, path);
                }
            }
        }

        // Use a series of pens with decreasing widths and
        // increasing opacity to draw a GraphicsPath.
        private void DrawPathWithFuzzyLine(GraphicsPath path, Graphics gr, Color base_color, int max_opacity, int width, int opaque_width)
        {
            int num_steps = width - opaque_width + 1;       // Number of pens we will use.
            float delta = (float)max_opacity / num_steps / num_steps;   // Change in alpha between pens.
            float alpha = delta;                            // Initial alpha.
            for (int thickness = width; thickness >= opaque_width; thickness--)
            {
                Color color = Color.FromArgb(
                    (int)alpha,
                    base_color.R,
                    base_color.G,
                    base_color.B);
                using (Pen pen = new Pen(color, thickness))
                {
                    pen.EndCap = LineCap.Round;
                    pen.StartCap = LineCap.Round;
                    gr.DrawPath(pen, path);
                }
                alpha += delta;
            }
        }

        // Draw a backgkround grid.
        private void DrawBackground(Graphics gr, Size size)
        {
            float width = size.Width / 4;
            float height = size.Height / 4;
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if ((i + j) % 2 == 0)
                    {
                        gr.FillRectangle(Brushes.Red, i * width, j * height, width, height);
                    }
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
            this.picFuzzy = new System.Windows.Forms.PictureBox();
            this.picThin = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picFuzzy)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picThin)).BeginInit();
            this.SuspendLayout();
            // 
            // picFuzzy
            // 
            this.picFuzzy.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.picFuzzy.Location = new System.Drawing.Point(168, 12);
            this.picFuzzy.Name = "picFuzzy";
            this.picFuzzy.Size = new System.Drawing.Size(150, 150);
            this.picFuzzy.TabIndex = 3;
            this.picFuzzy.TabStop = false;
            this.picFuzzy.Paint += new System.Windows.Forms.PaintEventHandler(this.picFuzzy_Paint);
            // 
            // picThin
            // 
            this.picThin.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.picThin.Location = new System.Drawing.Point(12, 12);
            this.picThin.Name = "picThin";
            this.picThin.Size = new System.Drawing.Size(150, 150);
            this.picThin.TabIndex = 2;
            this.picThin.TabStop = false;
            this.picThin.Paint += new System.Windows.Forms.PaintEventHandler(this.picThin_Paint);
            // 
            // howto_fuzzy_line_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(329, 171);
            this.Controls.Add(this.picFuzzy);
            this.Controls.Add(this.picThin);
            this.Name = "howto_fuzzy_line_Form1";
            this.Text = "howto_fuzzy_line";
            this.Load += new System.EventHandler(this.howto_fuzzy_line_Form1_Load);
            this.Resize += new System.EventHandler(this.howto_fuzzy_line_Form1_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.picFuzzy)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picThin)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox picFuzzy;
        private System.Windows.Forms.PictureBox picThin;
    }
}

