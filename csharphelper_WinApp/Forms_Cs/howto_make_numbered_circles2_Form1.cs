using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

 

namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_make_numbered_circles2_Form1:Form
  { 


        public howto_make_numbered_circles2_Form1()
        {
            InitializeComponent();
        }

        // Display a sample.
        private void ShowSample()
        {
            // Display a sample.
            picSample.Image = MakeNumberBitmap((int)nudWidth.Value,
                picBackground.BackColor, picForeground.BackColor,
                (int)nudBorderWidth.Value, lblFontSample.Font,
                nudMax.Value.ToString());
            SizeForm();
        }

        // Make a bitmap containing the indicated text.
        private Bitmap MakeNumberBitmap(int width, Color bg_color, Color fg_color, int border_width, Font fg_font, string txt)
        {
            // Size the bitmap.
            Bitmap bm = new Bitmap(width, width);
            using (Graphics gr = Graphics.FromImage(bm))
            {
                gr.SmoothingMode = SmoothingMode.AntiAlias;
                gr.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;

                // Make the background transparent.
                gr.Clear(Color.Transparent);

                // Fill the background.
                const int margin = 2;
                int rect_width = width - 2 * margin;
                if (rect_width < 1) rect_width = 1;
                Rectangle outer_rect = new Rectangle(margin, margin,
                    rect_width, rect_width);
                using (LinearGradientBrush bg_brush = new LinearGradientBrush(
                    outer_rect, Color.White, bg_color, LinearGradientMode.BackwardDiagonal))
                {
                    gr.FillEllipse(bg_brush, outer_rect);
                }

                rect_width = width - 2 * (margin + border_width);
                if (rect_width < 1) rect_width = 1;
                Rectangle inner_rect = new Rectangle(
                    margin + border_width, margin + border_width,
                    rect_width, rect_width);
                using (LinearGradientBrush bg_brush = new LinearGradientBrush(
                    inner_rect, bg_color, Color.White, LinearGradientMode.BackwardDiagonal))
                {
                    gr.FillEllipse(bg_brush, inner_rect);
                }

                // Draw the sample text.
                using (StringFormat string_format = new StringFormat())
                {
                    string_format.Alignment = StringAlignment.Center;
                    string_format.LineAlignment = StringAlignment.Center;
                    using (Brush fg_brush = new SolidBrush(fg_color))
                    {
                        gr.DrawString(txt, fg_font, fg_brush, outer_rect, string_format);
                    }
                }
            }

            return bm;
        }

        // Set some defaults and show an initial sample.
        private void howto_make_numbered_circles2_Form1_Load(object sender, EventArgs e)
        {
            picBackground.BackColor = Color.Blue;
            picForeground.BackColor = Color.Black;
            lblFontSample.Text = lblFontSample.Font.Name + ", " +
                lblFontSample.Font.Size.ToString() + "pt";

            ShowSample();
        }

        // Make the form fit the controls.
        private void SizeForm()
        {
            ClientSize = new Size(
                lblFontSample.Right + picBackground.Left,
                Math.Max(
                    nudMin.Bottom + picBackground.Left,
                    picSample.Bottom + picBackground.Left));
        }

        // Let the user select a new background color.
        private void picBackground_Click(object sender, EventArgs e)
        {
            cdColor.Color = picBackground.BackColor;
            if (cdColor.ShowDialog() == DialogResult.OK)
            {
                picBackground.BackColor = cdColor.Color;
                ShowSample();
            }
        }

        // Let the user select a new foreground color.
        private void picForeground_Click(object sender, EventArgs e)
        {
            cdColor.Color = picForeground.ForeColor;
            if (cdColor.ShowDialog() == DialogResult.OK)
            {
                picForeground.BackColor = cdColor.Color;
                ShowSample();
            }
        }

        // Let the user select a font.
        private void lblFontSample_Click(object sender, EventArgs e)
        {
            fdFont.Font = lblFontSample.Font;
            if (fdFont.ShowDialog() == DialogResult.OK)
            {
                lblFontSample.Font = fdFont.Font;
                lblFontSample.Text = lblFontSample.Font.Name + ", " +
                    lblFontSample.Font.Size.ToString() + "pt";
                ShowSample();
            }
        }

        // Display a sample with the new values.
        private void nud_ValueChanged(object sender, EventArgs e)
        {
            ShowSample();
        }
        private void nud_Scroll(object sender, ScrollEventArgs e)
        {
            ShowSample();
        }
        private void nud_KeyUp(object sender, KeyEventArgs e)
        {
            ShowSample();
        }

        // Make the files.
        private void btnMakeFiles_Click(object sender, EventArgs e)
        {
            // Make the files.
            for (decimal i = nudMin.Value; i <= nudMax.Value; i++)
            {
                // Make the file.
                Bitmap bm = MakeNumberBitmap((int)nudWidth.Value,
                    picBackground.BackColor, picForeground.BackColor,
                    (int)nudBorderWidth.Value, lblFontSample.Font,
                    i.ToString());

                // Save the file.
                bm.Save("Number" + i.ToString() + ".png", ImageFormat.Png);
            }

            MessageBox.Show("Done", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            this.nudWidth = new System.Windows.Forms.NumericUpDown();
            this.fdFont = new System.Windows.Forms.FontDialog();
            this.label8 = new System.Windows.Forms.Label();
            this.cdColor = new System.Windows.Forms.ColorDialog();
            this.nudBorderWidth = new System.Windows.Forms.NumericUpDown();
            this.nudMax = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.nudMin = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnMakeFiles = new System.Windows.Forms.Button();
            this.picBackground = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.picForeground = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblFontSample = new System.Windows.Forms.Label();
            this.picSample = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.nudWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudBorderWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBackground)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picForeground)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picSample)).BeginInit();
            this.SuspendLayout();
            // 
            // nudWidth
            // 
            this.nudWidth.Location = new System.Drawing.Point(249, 25);
            this.nudWidth.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.nudWidth.Name = "nudWidth";
            this.nudWidth.Size = new System.Drawing.Size(46, 20);
            this.nudWidth.TabIndex = 34;
            this.nudWidth.Value = new decimal(new int[] {
            40,
            0,
            0,
            0});
            this.nudWidth.ValueChanged += new System.EventHandler(this.nud_ValueChanged);
            this.nudWidth.Scroll += new System.Windows.Forms.ScrollEventHandler(this.nud_Scroll);
            this.nudWidth.KeyUp += new System.Windows.Forms.KeyEventHandler(this.nud_KeyUp);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(162, 9);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(69, 13);
            this.label8.TabIndex = 32;
            this.label8.Text = "Border Width";
            // 
            // nudBorderWidth
            // 
            this.nudBorderWidth.Location = new System.Drawing.Point(165, 25);
            this.nudBorderWidth.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudBorderWidth.Name = "nudBorderWidth";
            this.nudBorderWidth.Size = new System.Drawing.Size(46, 20);
            this.nudBorderWidth.TabIndex = 33;
            this.nudBorderWidth.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.nudBorderWidth.ValueChanged += new System.EventHandler(this.nud_ValueChanged);
            this.nudBorderWidth.Scroll += new System.Windows.Forms.ScrollEventHandler(this.nud_Scroll);
            this.nudBorderWidth.KeyUp += new System.Windows.Forms.KeyEventHandler(this.nud_KeyUp);
            // 
            // nudMax
            // 
            this.nudMax.Location = new System.Drawing.Point(183, 100);
            this.nudMax.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudMax.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            -2147483648});
            this.nudMax.Name = "nudMax";
            this.nudMax.Size = new System.Drawing.Size(46, 20);
            this.nudMax.TabIndex = 24;
            this.nudMax.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nudMax.ValueChanged += new System.EventHandler(this.nud_ValueChanged);
            this.nudMax.Scroll += new System.Windows.Forms.ScrollEventHandler(this.nud_Scroll);
            this.nudMax.KeyUp += new System.Windows.Forms.KeyEventHandler(this.nud_KeyUp);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(180, 82);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(37, 13);
            this.label7.TabIndex = 31;
            this.label7.Text = "Last #";
            // 
            // nudMin
            // 
            this.nudMin.Location = new System.Drawing.Point(114, 100);
            this.nudMin.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudMin.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            -2147483648});
            this.nudMin.Name = "nudMin";
            this.nudMin.Size = new System.Drawing.Size(46, 20);
            this.nudMin.TabIndex = 21;
            this.nudMin.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudMin.ValueChanged += new System.EventHandler(this.nud_ValueChanged);
            this.nudMin.Scroll += new System.Windows.Forms.ScrollEventHandler(this.nud_Scroll);
            this.nudMin.KeyUp += new System.Windows.Forms.KeyEventHandler(this.nud_KeyUp);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(111, 82);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(36, 13);
            this.label6.TabIndex = 30;
            this.label6.Text = "First #";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(246, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(71, 13);
            this.label5.TabIndex = 29;
            this.label5.Text = "Width/Height";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 82);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 13);
            this.label4.TabIndex = 28;
            this.label4.Text = "Sample";
            // 
            // btnMakeFiles
            // 
            this.btnMakeFiles.Location = new System.Drawing.Point(245, 90);
            this.btnMakeFiles.Name = "btnMakeFiles";
            this.btnMakeFiles.Size = new System.Drawing.Size(75, 23);
            this.btnMakeFiles.TabIndex = 25;
            this.btnMakeFiles.Text = "Make Files";
            this.btnMakeFiles.UseVisualStyleBackColor = true;
            this.btnMakeFiles.Click += new System.EventHandler(this.btnMakeFiles_Click);
            // 
            // picBackground
            // 
            this.picBackground.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.picBackground.Location = new System.Drawing.Point(15, 25);
            this.picBackground.Name = "picBackground";
            this.picBackground.Size = new System.Drawing.Size(32, 32);
            this.picBackground.TabIndex = 27;
            this.picBackground.TabStop = false;
            this.picBackground.Click += new System.EventHandler(this.picBackground_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 13);
            this.label3.TabIndex = 26;
            this.label3.Text = "Background";
            // 
            // picForeground
            // 
            this.picForeground.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.picForeground.Location = new System.Drawing.Point(89, 25);
            this.picForeground.Name = "picForeground";
            this.picForeground.Size = new System.Drawing.Size(32, 32);
            this.picForeground.TabIndex = 23;
            this.picForeground.TabStop = false;
            this.picForeground.Click += new System.EventHandler(this.picForeground_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(86, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 22;
            this.label2.Text = "Foreground";
            // 
            // lblFontSample
            // 
            this.lblFontSample.AutoSize = true;
            this.lblFontSample.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblFontSample.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFontSample.Location = new System.Drawing.Point(335, 25);
            this.lblFontSample.Name = "lblFontSample";
            this.lblFontSample.Size = new System.Drawing.Size(19, 21);
            this.lblFontSample.TabIndex = 20;
            this.lblFontSample.Text = "8";
            this.lblFontSample.Click += new System.EventHandler(this.lblFontSample_Click);
            // 
            // picSample
            // 
            this.picSample.Location = new System.Drawing.Point(15, 98);
            this.picSample.Name = "picSample";
            this.picSample.Size = new System.Drawing.Size(49, 50);
            this.picSample.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picSample.TabIndex = 19;
            this.picSample.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(332, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(28, 13);
            this.label1.TabIndex = 18;
            this.label1.Text = "Font";
            // 
            // howto_make_numbered_circles2_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(492, 147);
            this.Controls.Add(this.nudWidth);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.nudBorderWidth);
            this.Controls.Add(this.nudMax);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.nudMin);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnMakeFiles);
            this.Controls.Add(this.picBackground);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.picForeground);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblFontSample);
            this.Controls.Add(this.picSample);
            this.Controls.Add(this.label1);
            this.Name = "howto_make_numbered_circles2_Form1";
            this.Text = "howto_make_numbered_circles2";
            this.Load += new System.EventHandler(this.howto_make_numbered_circles2_Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nudWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudBorderWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBackground)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picForeground)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picSample)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown nudWidth;
        private System.Windows.Forms.FontDialog fdFont;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ColorDialog cdColor;
        private System.Windows.Forms.NumericUpDown nudBorderWidth;
        private System.Windows.Forms.NumericUpDown nudMax;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown nudMin;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnMakeFiles;
        private System.Windows.Forms.PictureBox picBackground;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox picForeground;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblFontSample;
        private System.Windows.Forms.PictureBox picSample;
        private System.Windows.Forms.Label label1;
    }
}

