using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.IO;//@
using System.Drawing.Imaging;//@

 

using howto_animate_rainbow_colors;
namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_animate_rainbow_colors_Form1:Form
  { 


        public howto_animate_rainbow_colors_Form1()
        {
            InitializeComponent();
        }

        // The currently selected color and its number.
        private Color SelectedColor;
        private float SelectedRainbowNumber;

        // The animation parameters.
        private const float ColorDelta = 0.02f;
        private int Interval = 20;

        // Start with red selected.
        private void howto_animate_rainbow_colors_Form1_Load(object sender, EventArgs e)
        {
            tmrMoveSample.Interval = Interval;
            SelectedColor = Color.Red;
            SelectedRainbowNumber = 0;
        }

        // Redraw the controls.
        private void picRainbow_Resize(object sender, EventArgs e)
        {
            picRainbow.Refresh();
        }
        private void picSample_Resize(object sender, EventArgs e)
        {
            picSample.Refresh();
        }

        // Draw the rainbow and the selected number.
        private void picRainbow_Paint(object sender, PaintEventArgs e)
        {
            // Draw the rainbow.
            using (Brush rainbow_brush = Rainbow.RainbowBrush(
                new Point(0, 0),
                new Point(picRainbow.ClientSize.Width, picRainbow.ClientSize.Height)))
            {
                e.Graphics.FillRectangle(rainbow_brush, picRainbow.ClientRectangle);
            }

            // Get and draw the selected location.
            int x = (int)(SelectedRainbowNumber * picRainbow.ClientSize.Width);
            Point[] pts =
            {
                new Point(x - 5, 0),
                new Point(x, 5),
                new Point(x + 5, 0)
            };
            e.Graphics.FillPolygon(Brushes.Black, pts);
        }

        // Draw the sample color.
        private void picSample_Paint(object sender, PaintEventArgs e)
        {
            picSample.BackColor = SelectedColor;
        }

        // Start or stop animating the rainbow colors.
        private void picRainbow_MouseClick(object sender, MouseEventArgs e)
        {
            // See if we should start or stop.
            if (tmrMoveSample.Enabled)
            {
                // Stop animating.
                tmrMoveSample.Enabled = false;
                return;
            }
            
            // Get the mouse position as a fraction
            // of the width of the PictureBox.
            float rainbow_color = e.X / (float)picRainbow.ClientSize.Width;

            // Convert into the corresponding color.
            SelectedColor = Rainbow.RainbowNumberToColor(rainbow_color);

            // Convert back into the corresponding number.
            SelectedRainbowNumber = Rainbow.ColorToRainbowNumber(SelectedColor);

            // Redraw.
            picRainbow.Refresh();
            picSample.Refresh();

            // Start animating.
            tmrMoveSample.Enabled = true;
        }

        // Continue animating the rainbow colors.
        private void tmrMoveSample_Tick(object sender, EventArgs e)
        {
            // Update the current color.
            SelectedRainbowNumber += ColorDelta;
            if (SelectedRainbowNumber > 1f)
                SelectedRainbowNumber = 0f;
            SelectedColor =
                Rainbow.RainbowNumberToColor(SelectedRainbowNumber);
           
            // Draw the new color.
            picRainbow.Refresh();
            picSample.Refresh();
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
            this.picSample = new System.Windows.Forms.PictureBox();
            this.picRainbow = new System.Windows.Forms.PictureBox();
            this.tmrMoveSample = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.picSample)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picRainbow)).BeginInit();
            this.SuspendLayout();
            // 
            // picSample
            // 
            this.picSample.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.picSample.Location = new System.Drawing.Point(129, 43);
            this.picSample.Name = "picSample";
            this.picSample.Size = new System.Drawing.Size(100, 50);
            this.picSample.TabIndex = 7;
            this.picSample.TabStop = false;
            this.picSample.Resize += new System.EventHandler(this.picSample_Resize);
            this.picSample.Paint += new System.Windows.Forms.PaintEventHandler(this.picSample_Paint);
            // 
            // picRainbow
            // 
            this.picRainbow.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.picRainbow.Location = new System.Drawing.Point(12, 12);
            this.picRainbow.Name = "picRainbow";
            this.picRainbow.Size = new System.Drawing.Size(335, 25);
            this.picRainbow.TabIndex = 6;
            this.picRainbow.TabStop = false;
            this.picRainbow.Resize += new System.EventHandler(this.picRainbow_Resize);
            this.picRainbow.MouseClick += new System.Windows.Forms.MouseEventHandler(this.picRainbow_MouseClick);
            this.picRainbow.Paint += new System.Windows.Forms.PaintEventHandler(this.picRainbow_Paint);
            // 
            // tmrMoveSample
            // 
            this.tmrMoveSample.Tick += new System.EventHandler(this.tmrMoveSample_Tick);
            // 
            // howto_animate_rainbow_colors_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(359, 105);
            this.Controls.Add(this.picSample);
            this.Controls.Add(this.picRainbow);
            this.Name = "howto_animate_rainbow_colors_Form1";
            this.Text = "howto_animate_rainbow_colors";
            this.Load += new System.EventHandler(this.howto_animate_rainbow_colors_Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picSample)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picRainbow)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox picSample;
        private System.Windows.Forms.PictureBox picRainbow;
        private System.Windows.Forms.Timer tmrMoveSample;
    }
}

