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
     public partial class howto_select_image_rectangle_Form1:Form
  { 


        public howto_select_image_rectangle_Form1()
        {
            InitializeComponent();
        }

        // The original image.
        private Bitmap OriginalImage;

        // True when we're selecting a rectangle.
        private bool IsSelecting = false;

        // The area we are selecting.
        private int X0, Y0, X1, Y1;

        // Save the original image.
        private void howto_select_image_rectangle_Form1_Load(object sender, EventArgs e)
        {
            OriginalImage = new Bitmap(picOriginal.Image);
        }

        // Start selecting the rectangle.
        private void picOriginal_MouseDown(object sender, MouseEventArgs e)
        {
            IsSelecting = true;

            // Save the start point.
            X0 = e.X;
            Y0 = e.Y;
        }
        
        // Continue selecting.
        private void picOriginal_MouseMove(object sender, MouseEventArgs e)
        {
            // Do nothing it we're not selecting an area.
            if (!IsSelecting) return;

            // Save the new point.
            X1 = e.X;
            Y1 = e.Y;

            // Make a Bitmap to display the selection rectangle.
            Bitmap bm = new Bitmap(OriginalImage);

            // Draw the rectangle.
            using (Graphics gr = Graphics.FromImage(bm))
            {
                gr.DrawRectangle(Pens.Red,
                    Math.Min(X0, X1), Math.Min(Y0, Y1),
                    Math.Abs(X0 - X1), Math.Abs(Y0 - Y1));
            }

            // Display the temporary bitmap.
            picOriginal.Image = bm;
        }

        // Finish selecting the area.
        private void picOriginal_MouseUp(object sender, MouseEventArgs e)
        {
            // Do nothing it we're not selecting an area.
            if (!IsSelecting) return;
            IsSelecting = false;

            // Display the original image.
            picOriginal.Image = OriginalImage;

            // Copy the selected part of the image.
            int wid = Math.Abs(X0 - X1);
            int hgt = Math.Abs(Y0 - Y1);
            if ((wid < 1) || (hgt < 1)) return;

            Bitmap area = new Bitmap(wid, hgt);
            using (Graphics gr = Graphics.FromImage(area))
            {
                Rectangle source_rectangle = 
                    new Rectangle(Math.Min(X0, X1), Math.Min(Y0, Y1), wid, hgt);
                Rectangle dest_rectangle = 
                    new Rectangle(0, 0, wid, hgt);
                gr.DrawImage(OriginalImage, dest_rectangle, 
                    source_rectangle, GraphicsUnit.Pixel);
            }

            // Display the result.
            picResult.Image = area;
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
            this.picOriginal = new System.Windows.Forms.PictureBox();
            this.picResult = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picOriginal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picResult)).BeginInit();
            this.SuspendLayout();
            // 
            // picOriginal
            // 
            this.picOriginal.Cursor = System.Windows.Forms.Cursors.Cross;
            this.picOriginal.Image = Properties.Resources.cows;
            this.picOriginal.Location = new System.Drawing.Point(0, 0);
            this.picOriginal.Name = "picOriginal";
            this.picOriginal.Size = new System.Drawing.Size(479, 328);
            this.picOriginal.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picOriginal.TabIndex = 0;
            this.picOriginal.TabStop = false;
            this.picOriginal.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picOriginal_MouseMove);
            this.picOriginal.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picOriginal_MouseDown);
            this.picOriginal.MouseUp += new System.Windows.Forms.MouseEventHandler(this.picOriginal_MouseUp);
            // 
            // picResult
            // 
            this.picResult.Location = new System.Drawing.Point(485, 0);
            this.picResult.Name = "picResult";
            this.picResult.Size = new System.Drawing.Size(57, 66);
            this.picResult.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picResult.TabIndex = 1;
            this.picResult.TabStop = false;
            // 
            // howto_select_image_rectangle_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(763, 328);
            this.Controls.Add(this.picResult);
            this.Controls.Add(this.picOriginal);
            this.Name = "howto_select_image_rectangle_Form1";
            this.Text = "howto_select_image_rectangle";
            this.Load += new System.EventHandler(this.howto_select_image_rectangle_Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picOriginal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picResult)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picOriginal;
        private System.Windows.Forms.PictureBox picResult;
    }
}

