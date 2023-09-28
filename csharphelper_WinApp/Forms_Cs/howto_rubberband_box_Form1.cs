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
     public partial class howto_rubberband_box_Form1:Form
  { 


        public howto_rubberband_box_Form1()
        {
            InitializeComponent();
        }

        private Bitmap m_OriginalImage = null;
        private int X0, Y0, X1, Y1;
        private bool SelectingArea = false;
        private Bitmap SelectedImage = null;
        private Graphics SelectedGraphics = null;

        // Save the original image.
        private void howto_rubberband_box_Form1_Load(object sender, EventArgs e)
        {
            m_OriginalImage = new Bitmap(picImage.Image);
            this.KeyPreview = true;
        }

        // Start selecting an area.
        private void picImage_MouseDown(object sender, MouseEventArgs e)
        {
            // Save the starting point.
            SelectingArea = true;
            X0 = e.X;
            Y0 = e.Y;

            // Make the selected image.
            SelectedImage = new Bitmap(m_OriginalImage);
            SelectedGraphics = Graphics.FromImage(SelectedImage);
            picImage.Image = SelectedImage;
        }

        // Continue selecting an area.
        private void picImage_MouseMove(object sender, MouseEventArgs e)
        {
            // Do nothing if we're not selecting an area.
            if (!SelectingArea) return;

            // Generate the new image with the selection rectangle.
            X1 = e.X;
            Y1 = e.Y;

            // Copy the original image.
            SelectedGraphics.DrawImage(m_OriginalImage, 0, 0);

            // Draw the selection rectangle.
            using (Pen select_pen = new Pen(Color.Red))
            {
                select_pen.DashStyle = DashStyle.Dash;
                Rectangle rect = MakeRectangle(X0, Y0, X1, Y1);
                SelectedGraphics.DrawRectangle(select_pen, rect);
            }

            picImage.Refresh();
        }

        // Finish selecting the area.
        private void picImage_MouseUp(object sender, MouseEventArgs e)
        {
            if (!SelectingArea) return;
            SelectingArea = false;
            SelectedImage = null;
            SelectedGraphics = null;
            picImage.Image = m_OriginalImage;
            picImage.Refresh();

            // Convert the points into a Rectangle.
            Rectangle rect = MakeRectangle(X0, Y0, X1, Y1);
            if ((rect.Width > 0) && (rect.Height > 0))
            {
                // Display the Rectangle.
                MessageBox.Show(rect.ToString());
            }
        }

        // Return a Rectangle with these points as corners.
        private Rectangle MakeRectangle(int x0, int y0, int x1, int y1)
        {
            return new Rectangle(
                Math.Min(x0, x1),
                Math.Min(y0, y1),
                Math.Abs(x0 - x1),
                Math.Abs(y0 - y1));
        }

        // If the user presses Escape, cancel.
        private void howto_rubberband_box_Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 27)
            {
                if (!SelectingArea) return;
                SelectingArea = false;

                // Stop selecting.
                SelectedImage = null;
                SelectedGraphics = null;
                picImage.Image = m_OriginalImage;
                picImage.Refresh();
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
            this.picImage = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picImage)).BeginInit();
            this.SuspendLayout();
            // 
            // picImage
            // 
            this.picImage.Cursor = System.Windows.Forms.Cursors.Cross;
            this.picImage.Image = Properties.Resources.KenDriving;
            this.picImage.Location = new System.Drawing.Point(12, 12);
            this.picImage.Name = "picImage";
            this.picImage.Size = new System.Drawing.Size(600, 450);
            this.picImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picImage.TabIndex = 0;
            this.picImage.TabStop = false;
            this.picImage.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picImage_MouseMove);
            this.picImage.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picImage_MouseDown);
            this.picImage.MouseUp += new System.Windows.Forms.MouseEventHandler(this.picImage_MouseUp);
            // 
            // howto_rubberband_box_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 475);
            this.Controls.Add(this.picImage);
            this.Name = "howto_rubberband_box_Form1";
            this.Text = "howto_rubberband_box";
            this.Load += new System.EventHandler(this.howto_rubberband_box_Form1_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.howto_rubberband_box_Form1_KeyPress);
            ((System.ComponentModel.ISupportInitialize)(this.picImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picImage;
    }
}

