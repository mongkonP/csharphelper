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
     public partial class howto_color_wheel_dialog_ColorWheelDialog:Form
  { 


        public howto_color_wheel_dialog_ColorWheelDialog()
        {
            InitializeComponent();
        }

        // The color wheel bitmap.
        private Bitmap WheelBm = null;

        // The currently selected color.
        private Color selected_color = SystemColors.Control;
        public Color SelectedColor
        {
            get { return selected_color; }
            set
            {
                selected_color = value;
                picSelection.Image = SampleBitmap(value,
                    picSelection.ClientSize.Width,
                    picSelection.ClientSize.Height);
                hscrAlpha.Value = value.A;
                txtAlpha.Text = hscrAlpha.Value.ToString();
            }
        }

        // Draw the initial color wheel.
        private void howto_color_wheel_dialog_ColorWheelDialog_Load(object sender, EventArgs e)
        {
            DrawColorWheel();
        }

        // Draw the color wheel.
        private void DrawColorWheel()
        {
            // Create the color wheel bitmap.
            int width = picWheel.Width;
            int height = picWheel.Height;
            WheelBm = new Bitmap(width, height);
            using (Graphics gr = Graphics.FromImage(WheelBm))
            {
                gr.SmoothingMode = SmoothingMode.AntiAlias;

                // Draw the color wheel.
                DrawColorWheel(gr, Color.White,
                    0, 0, width, height);
            }

            // Create a display bitmap.
            Bitmap bm = new Bitmap(width, height);
            using (Graphics gr = Graphics.FromImage(bm))
            {
                // Fill with a grid.
                gr.SmoothingMode = SmoothingMode.AntiAlias;
                DrawGrid(gr, width, height);

                // Draw the color wheel on top.
                DrawColorWheel(gr, Color.White,
                    0, 0, width, height);
            }

            // Display the result.
            picWheel.Image = bm;
        }

        // Draw a color wheel in the indicated area.
        private void DrawColorWheel(Graphics gr, Color outline_color,
            int xmin, int ymin, int wid, int hgt)
        {
            Rectangle rect = new Rectangle(xmin, ymin, wid, hgt);
            GraphicsPath wheel_path = new GraphicsPath();
            wheel_path.AddEllipse(rect);
            wheel_path.Flatten();

            // Get alpha and saturation.
            int alpha = hscrAlpha.Value;
            int sat = hscrSaturation.Value;

            float num_pts = (wheel_path.PointCount - 1) / 6;
            Color[] surround_colors = new Color[wheel_path.PointCount];

            int index = 0;
            InterpolateColors(surround_colors, ref index,
                1 * num_pts, alpha, sat, 0, 0, alpha, sat, 0, sat);
            InterpolateColors(surround_colors, ref index,
                2 * num_pts, alpha, sat, 0, sat, alpha, 0, 0, sat);
            InterpolateColors(surround_colors, ref index,
                3 * num_pts, alpha, 0, 0, sat, alpha, 0, sat, sat);
            InterpolateColors(surround_colors, ref index,
                4 * num_pts, alpha, 0, sat, sat, alpha, 0, sat, 0);
            InterpolateColors(surround_colors, ref index,
                5 * num_pts, alpha, 0, sat, 0, alpha, sat, sat, 0);
            InterpolateColors(surround_colors, ref index,
                wheel_path.PointCount, alpha, sat, sat, 0, alpha, sat, 0, 0);

            using (PathGradientBrush path_brush =
                new PathGradientBrush(wheel_path))
            {
                path_brush.CenterColor =
                    Color.FromArgb(alpha, 255, 255, 255);
                path_brush.SurroundColors = surround_colors;

                gr.FillPath(path_brush, wheel_path);

                // It looks better if we outline the wheel.
                using (Pen thick_pen = new Pen(outline_color, 2))
                {
                    gr.DrawPath(thick_pen, wheel_path);
                }
            }

            //// Uncomment the following to draw the path's points.
            //for (int i = 0; i < wheel_path.PointCount; i++)
            //{
            //    gr.FillEllipse(Brushes.Black,
            //        wheel_path.PathPoints[i].X - 2,
            //        wheel_path.PathPoints[i].Y - 2,
            //        4, 4);
            //}
        }

        // Fill in colors interpolating between the from and to values.
        private void InterpolateColors(Color[] surround_colors,
            ref int index, float stop_pt,
            int from_a, int from_r, int from_g, int from_b,
            int to_a, int to_r, int to_g, int to_b)
        {
            int num_pts = (int)stop_pt - index;
            float a = from_a, r = from_r, g = from_g, b = from_b;
            float da = (to_a - from_a) / (num_pts - 1);
            float dr = (to_r - from_r) / (num_pts - 1);
            float dg = (to_g - from_g) / (num_pts - 1);
            float db = (to_b - from_b) / (num_pts - 1);

            for (int i = 0; i < num_pts; i++)
            {
                surround_colors[index++] =
                    Color.FromArgb((int)a, (int)r, (int)g, (int)b);
                a += da;
                r += dr;
                g += dg;
                b += db;
            }
        }

        // Update the sample.
        private void picWheel_MouseMove(object sender, MouseEventArgs e)
        {
            picSample.Image = SampleBitmap(
                ColorAt(e.X, e.Y),
                picSample.ClientSize.Width,
                picSample.ClientSize.Height);
        }

        // Update the selection.
        private void picWheel_MouseClick(object sender, MouseEventArgs e)
        {
            SelectedColor = ColorAt(e.X, e.Y);
        }

        // Return a sample bitmap.
        private Bitmap SampleBitmap(Color color, int width, int height)
        {
            Bitmap bm = new Bitmap(width, height);
            using (Graphics gr = Graphics.FromImage(bm))
            {
                // Fill with a grid.
                DrawGrid(gr, width, height);

                // Fill with the sample color.
                using (Brush br = new SolidBrush(color))
                {
                    gr.FillRectangle(br, 0, 0, width, height);
                }
            }
            return bm;
        }

        // Draw a black grid over a white background.
        private void DrawGrid(Graphics gr, int width, int height)
        {
            gr.Clear(Color.White);
            using (Pen pen = new Pen(Color.Black, 2))
            {
                for (int x = 10; x < width; x += 20)
                    gr.DrawLine(pen, x, 0, x, height - 1);
                for (int y = 10; y < height; y += 20)
                    gr.DrawLine(pen, 0, y, width - 1, y);
            }
        }

        // Return the color under the mouse.
        private Color ColorAt(int x, int y)
        {
            // See if the position is over the color wheel.
            int wid = picWheel.Width;
            float cx = wid / 2f;
            float cy = wid / 2f;
            float dx = cx - x;
            float dy = cy - y;
            if (dx * dx + dy * dy > cx * cx) return this.BackColor;

            // Return the color.
            return WheelBm.GetPixel(x, y);
        }

        // Update the color wheel.
        private void hscrAlpha_Scroll(object sender, ScrollEventArgs e)
        {
            txtAlpha.Text = hscrAlpha.Value.ToString();
            DrawColorWheel();
        }
        private void hscrSaturation_Scroll(object sender, ScrollEventArgs e)
        {
            txtSaturation.Text = hscrSaturation.Value.ToString();
            DrawColorWheel();
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
            this.picSelection = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.picWheel = new System.Windows.Forms.PictureBox();
            this.picSample = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.hscrSaturation = new System.Windows.Forms.HScrollBar();
            this.hscrAlpha = new System.Windows.Forms.HScrollBar();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.txtSaturation = new System.Windows.Forms.TextBox();
            this.txtAlpha = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.picSelection)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picWheel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picSample)).BeginInit();
            this.SuspendLayout();
            // 
            // picSelection
            // 
            this.picSelection.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.picSelection.Location = new System.Drawing.Point(222, 130);
            this.picSelection.Name = "picSelection";
            this.picSelection.Size = new System.Drawing.Size(64, 64);
            this.picSelection.TabIndex = 19;
            this.picSelection.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoEllipsis = true;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(221, 114);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 13);
            this.label4.TabIndex = 18;
            this.label4.Text = "Selection:";
            // 
            // picWheel
            // 
            this.picWheel.Location = new System.Drawing.Point(9, 12);
            this.picWheel.Name = "picWheel";
            this.picWheel.Size = new System.Drawing.Size(200, 200);
            this.picWheel.TabIndex = 17;
            this.picWheel.TabStop = false;
            this.picWheel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picWheel_MouseMove);
            this.picWheel.MouseClick += new System.Windows.Forms.MouseEventHandler(this.picWheel_MouseClick);
            // 
            // picSample
            // 
            this.picSample.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.picSample.Location = new System.Drawing.Point(222, 25);
            this.picSample.Name = "picSample";
            this.picSample.Size = new System.Drawing.Size(64, 64);
            this.picSample.TabIndex = 16;
            this.picSample.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(224, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "Sample:";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 250);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "Saturation:";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 224);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "Alpha:";
            // 
            // hscrSaturation
            // 
            this.hscrSaturation.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.hscrSaturation.Location = new System.Drawing.Point(67, 247);
            this.hscrSaturation.Maximum = 264;
            this.hscrSaturation.Name = "hscrSaturation";
            this.hscrSaturation.Size = new System.Drawing.Size(175, 20);
            this.hscrSaturation.TabIndex = 12;
            this.hscrSaturation.Value = 255;
            this.hscrSaturation.Scroll += new System.Windows.Forms.ScrollEventHandler(this.hscrSaturation_Scroll);
            // 
            // hscrAlpha
            // 
            this.hscrAlpha.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.hscrAlpha.Location = new System.Drawing.Point(67, 221);
            this.hscrAlpha.Maximum = 264;
            this.hscrAlpha.Name = "hscrAlpha";
            this.hscrAlpha.Size = new System.Drawing.Size(175, 20);
            this.hscrAlpha.TabIndex = 11;
            this.hscrAlpha.Value = 255;
            this.hscrAlpha.Scroll += new System.Windows.Forms.ScrollEventHandler(this.hscrAlpha_Scroll);
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Location = new System.Drawing.Point(128, 273);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 20;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(209, 273);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 21;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // txtSaturation
            // 
            this.txtSaturation.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSaturation.Location = new System.Drawing.Point(245, 247);
            this.txtSaturation.Name = "txtSaturation";
            this.txtSaturation.ReadOnly = true;
            this.txtSaturation.Size = new System.Drawing.Size(39, 20);
            this.txtSaturation.TabIndex = 22;
            this.txtSaturation.TabStop = false;
            this.txtSaturation.Text = "255";
            this.txtSaturation.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtAlpha
            // 
            this.txtAlpha.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAlpha.Location = new System.Drawing.Point(245, 221);
            this.txtAlpha.Name = "txtAlpha";
            this.txtAlpha.ReadOnly = true;
            this.txtAlpha.Size = new System.Drawing.Size(39, 20);
            this.txtAlpha.TabIndex = 23;
            this.txtAlpha.TabStop = false;
            this.txtAlpha.Text = "255";
            this.txtAlpha.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // howto_color_wheel_dialog_ColorWheelDialog
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(296, 308);
            this.Controls.Add(this.txtAlpha);
            this.Controls.Add(this.txtSaturation);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.picSelection);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.picWheel);
            this.Controls.Add(this.picSample);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.hscrSaturation);
            this.Controls.Add(this.hscrAlpha);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "howto_color_wheel_dialog_ColorWheelDialog";
            this.Text = "howto_color_wheel_dialog_ColorWheelDialog";
            this.Load += new System.EventHandler(this.howto_color_wheel_dialog_ColorWheelDialog_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picSelection)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picWheel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picSample)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picSelection;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox picWheel;
        private System.Windows.Forms.PictureBox picSample;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.HScrollBar hscrSaturation;
        private System.Windows.Forms.HScrollBar hscrAlpha;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TextBox txtSaturation;
        private System.Windows.Forms.TextBox txtAlpha;
    }
}