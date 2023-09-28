using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Drawing.Printing;

 

namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_print_image_Form1:Form
  { 


        public howto_print_image_Form1()
        {
            InitializeComponent();
        }

        // Print an image.
        private void pdocImage_PrintPage(object sender, PrintPageEventArgs e)
        {
            // Print in the upper left corner at its full size.
            e.Graphics.DrawImage(picImage.Image,
                e.MarginBounds.X, e.MarginBounds.Y,
                picImage.Image.Width, picImage.Image.Height);

            // Print in the upper right corner,
            // sized to fit beside the other image.
            int left = e.MarginBounds.Left + picImage.Image.Width;
            int width = e.MarginBounds.Width - picImage.Image.Width;
            float scale = width / (float)picImage.Image.Width;
            int height = (int)(picImage.Image.Height * scale);
            e.Graphics.DrawImage(picImage.Image,
                left, e.MarginBounds.Y, width, height);

            // Print the same size in the lower right corner.
            int top = e.MarginBounds.Bottom - height;
            e.Graphics.DrawImage(picImage.Image,
                left, top, width, height);
        }

        // Display the print preview dialog.
        private void btnPrint_Click(object sender, EventArgs e)
        {
            ppdImage.ShowDialog();
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(howto_print_image_Form1));
            this.btnPrint = new System.Windows.Forms.Button();
            this.ppdImage = new System.Windows.Forms.PrintPreviewDialog();
            this.pdocImage = new System.Drawing.Printing.PrintDocument();
            this.picImage = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picImage)).BeginInit();
            this.SuspendLayout();
            // 
            // btnPrint
            // 
            this.btnPrint.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnPrint.Location = new System.Drawing.Point(105, 46);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(75, 23);
            this.btnPrint.TabIndex = 0;
            this.btnPrint.Text = "Print";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // ppdImage
            // 
            this.ppdImage.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.ppdImage.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.ppdImage.ClientSize = new System.Drawing.Size(400, 300);
            this.ppdImage.Document = this.pdocImage;
            this.ppdImage.Enabled = true;
            this.ppdImage.Icon = ((System.Drawing.Icon)(resources.GetObject("ppdImage.Icon")));
            this.ppdImage.Name = "ppdImage";
            this.ppdImage.Visible = false;
            // 
            // pdocImage
            // 
            this.pdocImage.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.pdocImage_PrintPage);
            // 
            // pictureBox1
            // 
            this.picImage.Image = Properties.Resources._24hour;
            this.picImage.Location = new System.Drawing.Point(196, 12);
            this.picImage.Name = "pictureBox1";
            this.picImage.Size = new System.Drawing.Size(76, 90);
            this.picImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picImage.TabIndex = 1;
            this.picImage.TabStop = false;
            this.picImage.Visible = false;
            // 
            // howto_print_image_Form1
            // 
            this.AcceptButton = this.btnPrint;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 114);
            this.Controls.Add(this.picImage);
            this.Controls.Add(this.btnPrint);
            this.Name = "howto_print_image_Form1";
            this.Text = "howto_print_image";
            ((System.ComponentModel.ISupportInitialize)(this.picImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.PrintPreviewDialog ppdImage;
        private System.Drawing.Printing.PrintDocument pdocImage;
        private System.Windows.Forms.PictureBox picImage;
    }
}

