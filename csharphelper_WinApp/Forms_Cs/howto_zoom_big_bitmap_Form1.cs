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
     public partial class howto_zoom_big_bitmap_Form1:Form
  { 


        public howto_zoom_big_bitmap_Form1()
        {
            InitializeComponent();
        }

        // The Bitmap we display.
        private Bitmap Bm = null;

        // The dimensions of the drawing area in world coordinates.
        private const int WorldWidth = 100;
        private const int WorldHeight = 100;

        // The scale.
        private float PictureScale = 1.0f;

        // Select normal scale.
        private void howto_zoom_big_bitmap_Form1_Load(object sender, EventArgs e)
        {
            cboScale.SelectedIndex = 2;
        }

        // Set the selected scale.
        private void cboScale_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cboScale.SelectedIndex)
            {
                case 0:
                    SetScale(0.25f);
                    break;
                case 1:
                    SetScale(0.5f);
                    break;
                case 2:
                    SetScale(1f);
                    break;
                case 3:
                    SetScale(2f);
                    break;
                case 4:
                    SetScale(4f);
                    break;
                case 5:
                    SetScale(8f);
                    break;
            }
        }

        // Set the scale and redraw.
        private void SetScale(float picture_scale)
        {
            // Set the scale.
            PictureScale = picture_scale;

            // Make a Bitmap of the right size.
            Bm = new Bitmap(
                (int)(PictureScale * WorldWidth),
                (int)(PictureScale * WorldHeight));

            // Make a Graphics object for the Bitmap.
            // (If you need to use this later, you can give it
            // class scope so you don't need to make a new one.)
            using (Graphics gr = Graphics.FromImage(Bm))
            {
                // Use a white background
                // (so you can see where the picture is).
                gr.Clear(Color.White);

                // Draw smoothly.
                gr.SmoothingMode = SmoothingMode.AntiAlias;

                // Scale.
                gr.ScaleTransform(PictureScale, PictureScale);

                // Draw the image.
                DrawImage(gr);
            }

            // Display the result.
            picCanvas.Image = Bm;
        }

        // Draw the image in world coordinates.
        private void DrawImage(Graphics gr)
        {
            Rectangle rect;

            rect = new Rectangle(10, 10, 80, 80);
            gr.FillEllipse(Brushes.LightGreen, rect);
            gr.DrawEllipse(Pens.Green, rect);

            rect = new Rectangle(40, 40, 20, 30);
            gr.FillEllipse(Brushes.LightBlue, rect);
            gr.DrawEllipse(Pens.Blue, rect);

            rect = new Rectangle(25, 30, 50, 50);
            gr.DrawArc(Pens.Red, rect, 20, 140);

            rect = new Rectangle(25, 25, 15, 20);
            gr.FillEllipse(Brushes.White, rect);
            gr.DrawEllipse(Pens.Black, rect);
            rect = new Rectangle(30, 30, 10, 10);
            gr.FillEllipse(Brushes.Black, rect);

            rect = new Rectangle(60, 25, 15, 20);
            gr.FillEllipse(Brushes.White, rect);
            gr.DrawEllipse(Pens.Black, rect);
            rect = new Rectangle(65, 30, 10, 10);
            gr.FillEllipse(Brushes.Black, rect);
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
            this.picCanvas = new System.Windows.Forms.PictureBox();
            this.panWindow = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.cboScale = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.picCanvas)).BeginInit();
            this.panWindow.SuspendLayout();
            this.SuspendLayout();
            // 
            // picCanvas
            // 
            this.picCanvas.Location = new System.Drawing.Point(0, 0);
            this.picCanvas.Name = "picCanvas";
            this.picCanvas.Size = new System.Drawing.Size(100, 50);
            this.picCanvas.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picCanvas.TabIndex = 0;
            this.picCanvas.TabStop = false;
            // 
            // panWindow
            // 
            this.panWindow.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panWindow.AutoScroll = true;
            this.panWindow.Controls.Add(this.picCanvas);
            this.panWindow.Location = new System.Drawing.Point(12, 39);
            this.panWindow.Name = "panWindow";
            this.panWindow.Size = new System.Drawing.Size(260, 213);
            this.panWindow.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Scale:";
            // 
            // cboScale
            // 
            this.cboScale.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboScale.FormattingEnabled = true;
            this.cboScale.Items.AddRange(new object[] {
            "x 1/4",
            "x 1/2",
            "x 1",
            "x 2",
            "x 4",
            "x 8"});
            this.cboScale.Location = new System.Drawing.Point(55, 12);
            this.cboScale.Name = "cboScale";
            this.cboScale.Size = new System.Drawing.Size(57, 21);
            this.cboScale.TabIndex = 2;
            this.cboScale.SelectedIndexChanged += new System.EventHandler(this.cboScale_SelectedIndexChanged);
            // 
            // howto_zoom_big_bitmap_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 264);
            this.Controls.Add(this.cboScale);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panWindow);
            this.Name = "howto_zoom_big_bitmap_Form1";
            this.Text = "howto_zoom_big_bitmap";
            this.Load += new System.EventHandler(this.howto_zoom_big_bitmap_Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picCanvas)).EndInit();
            this.panWindow.ResumeLayout(false);
            this.panWindow.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picCanvas;
        private System.Windows.Forms.Panel panWindow;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboScale;
    }
}

