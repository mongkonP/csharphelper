using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

 

namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_drag_picture_Form1:Form
  { 


        public howto_drag_picture_Form1()
        {
            InitializeComponent();
        }

        // The smiley image.
        private Bitmap Smiley;

        // The smiley image's location.
        private Rectangle SmileyLocation;

        private void howto_drag_picture_Form1_Load(object sender, EventArgs e)
        {
            // Make the white pixels in the smiley transparent.
            Smiley = new Bitmap(Properties.Resources.smile);
            Smiley.MakeTransparent(Color.White);

            // Set the smiley's initial location.
            SmileyLocation = new Rectangle(10, 10,
                Smiley.Width, Smiley.Height);
        }

        // Draw the picture over the background.
        private void picBackground_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawImage(Smiley, SmileyLocation);
        }

        // True when we are dragging.
        private bool Dragging = false;

        // The offset from the mouse's down position
        // and the picture's upper left corner.
        private int OffsetX, OffsetY;

        // Start dragging the picture.
        private void picBackground_MouseDown(object sender, MouseEventArgs e)
        {
            // See if we're over the picture.
            if (PointIsOverPicture(e.X, e.Y))
            {
                // Start dragging.
                Dragging = true;

                // Save the offset from the mouse to the picture's origin.
                OffsetX = SmileyLocation.X - e.X;
                OffsetY = SmileyLocation.Y - e.Y;
            }
        }

        // Continue dragging the picture.
        private void picBackground_MouseMove(object sender, MouseEventArgs e)
        {
            // See if we're dragging.
            if (Dragging)
            {
                // We're dragging the image. Move it.
                SmileyLocation.X = e.X + OffsetX;
                SmileyLocation.Y = e.Y + OffsetY;

                // Redraw.
                picBackground.Invalidate();
            }
            else
            {
                // We're not dragging the image. See if we're over it.
                Cursor new_cursor = Cursors.Default;
                if (PointIsOverPicture(e.X, e.Y))
                {
                    new_cursor = Cursors.Hand;
                }
                if (picBackground.Cursor != new_cursor)
                    picBackground.Cursor = new_cursor;
            }
        }

        // Stop dragging the picture.
        private void picBackground_MouseUp(object sender, MouseEventArgs e)
        {
            Dragging = false;
        }

        // Return true if the point is over the picture's current location.
        private bool PointIsOverPicture(int x, int y)
        {
            // See if it's over the picture's bounding rectangle.
            if ((x < SmileyLocation.Left) || (x >= SmileyLocation.Right) ||
                (y < SmileyLocation.Top) || (y >= SmileyLocation.Bottom))
                return false;

            // See if the point is above a non-transparent pixel.
            int i = x - SmileyLocation.X;
            int j = y - SmileyLocation.Y;
            return (Smiley.GetPixel(i, j).A > 0);
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
            this.picBackground = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picBackground)).BeginInit();
            this.SuspendLayout();
            // 
            // picBackground
            // 
            this.picBackground.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.picBackground.Image = Properties.Resources.Flatirons1;
            this.picBackground.Location = new System.Drawing.Point(12, 12);
            this.picBackground.Name = "picBackground";
            this.picBackground.Size = new System.Drawing.Size(404, 304);
            this.picBackground.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picBackground.TabIndex = 0;
            this.picBackground.TabStop = false;
            this.picBackground.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picBackground_MouseMove);
            this.picBackground.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picBackground_MouseDown);
            this.picBackground.Paint += new System.Windows.Forms.PaintEventHandler(this.picBackground_Paint);
            this.picBackground.MouseUp += new System.Windows.Forms.MouseEventHandler(this.picBackground_MouseUp);
            // 
            // howto_drag_picture_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(427, 327);
            this.Controls.Add(this.picBackground);
            this.Name = "howto_drag_picture_Form1";
            this.Text = "howto_drag_picture";
            this.Load += new System.EventHandler(this.howto_drag_picture_Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picBackground)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picBackground;
    }
}

