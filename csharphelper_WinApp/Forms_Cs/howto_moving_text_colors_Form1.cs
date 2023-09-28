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
     public partial class howto_moving_text_colors_Form1:Form
  { 


        public howto_moving_text_colors_Form1()
        {
            InitializeComponent();
        }

        private float GradientStart = 0;
        private float Delta = 5f;

        // Make the PictureBox redraw.
        private void tmrRefresh_Tick(object sender, EventArgs e)
        {
            picCanvas.Refresh();
        }

        // Draw the background with text on top.
        private void picCanvas_Paint(object sender, PaintEventArgs e)
        {
            // Clear the background.
            int wid = picCanvas.ClientSize.Width;
            e.Graphics.Clear(Color.White);

            // Make the gradient brush.
            using (LinearGradientBrush brush = new LinearGradientBrush(
                new PointF(GradientStart, 0),
                new PointF(GradientStart + wid, 0),
                Color.Red, Color.Red))
            {
                brush.WrapMode = WrapMode.Tile;
                ColorBlend color_blend = new ColorBlend();
                color_blend.Colors = new Color[]
                {
                    Color.Blue, Color.Blue,
                    Color.White, Color.Blue, Color.Blue
                };
                color_blend.Positions =
                    new float[] { 0, 0.4f, 0.5f, 0.6f, 1 };
                brush.InterpolationColors = color_blend;

                // Use the brush to draw some text.
                using (Font font = new Font("Times New Roman", 16, FontStyle.Bold))
                {
                    using (StringFormat string_format = new StringFormat())
                    {
                        string_format.Alignment = StringAlignment.Center;
                        string_format.LineAlignment = StringAlignment.Center;
                        e.Graphics.DrawString("Moving Text Colors",
                            font, brush,
                            picCanvas.ClientSize.Width / 2,
                            picCanvas.ClientSize.Height / 2,
                            string_format);
                    }
                }
            }

            // Increase the start position.
            GradientStart += Delta;
            if (GradientStart >= wid) GradientStart = 0;
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
            this.tmrRefresh = new System.Windows.Forms.Timer(this.components);
            this.picCanvas = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picCanvas)).BeginInit();
            this.SuspendLayout();
            // 
            // tmrRefresh
            // 
            this.tmrRefresh.Enabled = true;
            this.tmrRefresh.Interval = 10;
            this.tmrRefresh.Tick += new System.EventHandler(this.tmrRefresh_Tick);
            // 
            // picCanvas
            // 
            this.picCanvas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.picCanvas.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.picCanvas.Location = new System.Drawing.Point(12, 12);
            this.picCanvas.Name = "picCanvas";
            this.picCanvas.Size = new System.Drawing.Size(320, 77);
            this.picCanvas.TabIndex = 4;
            this.picCanvas.TabStop = false;
            this.picCanvas.Paint += new System.Windows.Forms.PaintEventHandler(this.picCanvas_Paint);
            // 
            // howto_moving_text_colors_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(344, 101);
            this.Controls.Add(this.picCanvas);
            this.Name = "howto_moving_text_colors_Form1";
            this.Text = "howto_moving_text_colors";
            ((System.ComponentModel.ISupportInitialize)(this.picCanvas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.Timer tmrRefresh;
        internal System.Windows.Forms.PictureBox picCanvas;
    }
}

