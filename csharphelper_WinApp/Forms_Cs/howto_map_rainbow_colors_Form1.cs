using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

 

using howto_map_rainbow_colors;
namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_map_rainbow_colors_Form1:Form
  { 


        public howto_map_rainbow_colors_Form1()
        {
            InitializeComponent();
        }

        // The currently selected color and its number.
        private Color SelectedColor;
        private float SelectedRainbowNumber;

        // Start with red selected.
        private void howto_map_rainbow_colors_Form1_Load(object sender, EventArgs e)
        {
            SelectedColor = Color.Red;
            SelectedRainbowNumber = 0;
        }

        // Select this color.
        private void picRainbow_MouseMove(object sender, MouseEventArgs e)
        {
            MouseMoving = true;

            // Get the mouse position as a fraction
            // of the width of the PictureBox.
            float rainbow_color = e.X / (float)picRainbow.ClientSize.Width;

            // Convert into the corresponding color.
            SelectedColor = Rainbow.RainbowNumberToColor(rainbow_color);

            // Convert back into the corresponding number.
            SelectedRainbowNumber = Rainbow.ColorToRainbowNumber(SelectedColor);
            txtValue.Text = SelectedRainbowNumber.ToString("0.00");

            // Redraw.
            picRainbow.Refresh();
            picSample.Refresh();

            MouseMoving = false;
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

        // True if we are updating the color already.
        private bool MouseMoving = false;
        private void txtValue_TextChanged(object sender, EventArgs e)
        {
            if (MouseMoving) return;

            // Try to get the value as a fraction between 0 and 1.
            try
            {
                // Get the value from the text box.
                SelectedRainbowNumber = float.Parse(txtValue.Text);

                // Convert into the corresponding color.
                SelectedColor = Rainbow.RainbowNumberToColor(SelectedRainbowNumber);

                // Redraw.
                picRainbow.Refresh();
                picSample.Refresh();
            }
            catch
            {
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
            this.txtValue = new System.Windows.Forms.TextBox();
            this.picSample = new System.Windows.Forms.PictureBox();
            this.picRainbow = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picSample)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picRainbow)).BeginInit();
            this.SuspendLayout();
            // 
            // txtValue
            // 
            this.txtValue.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtValue.Location = new System.Drawing.Point(111, 99);
            this.txtValue.Name = "txtValue";
            this.txtValue.Size = new System.Drawing.Size(100, 20);
            this.txtValue.TabIndex = 5;
            this.txtValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtValue.TextChanged += new System.EventHandler(this.txtValue_TextChanged);
            // 
            // picSample
            // 
            this.picSample.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.picSample.Location = new System.Drawing.Point(111, 43);
            this.picSample.Name = "picSample";
            this.picSample.Size = new System.Drawing.Size(100, 50);
            this.picSample.TabIndex = 4;
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
            this.picRainbow.Size = new System.Drawing.Size(299, 25);
            this.picRainbow.TabIndex = 3;
            this.picRainbow.TabStop = false;
            this.picRainbow.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picRainbow_MouseMove);
            this.picRainbow.Resize += new System.EventHandler(this.picRainbow_Resize);
            this.picRainbow.Paint += new System.Windows.Forms.PaintEventHandler(this.picRainbow_Paint);
            // 
            // howto_map_rainbow_colors_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(323, 130);
            this.Controls.Add(this.txtValue);
            this.Controls.Add(this.picSample);
            this.Controls.Add(this.picRainbow);
            this.Name = "howto_map_rainbow_colors_Form1";
            this.Text = "howto_map_rainbow_colors";
            this.Load += new System.EventHandler(this.howto_map_rainbow_colors_Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picSample)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picRainbow)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtValue;
        private System.Windows.Forms.PictureBox picSample;
        private System.Windows.Forms.PictureBox picRainbow;
    }
}

