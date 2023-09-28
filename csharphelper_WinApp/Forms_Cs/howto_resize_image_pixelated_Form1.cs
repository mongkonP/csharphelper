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
     public partial class howto_resize_image_pixelated_Form1:Form
  { 


        public howto_resize_image_pixelated_Form1()
        {
            InitializeComponent();
        }

        private void howto_resize_image_pixelated_Form1_Load(object sender, EventArgs e)
        {
            cboScale.Text = "1";
        }

        // Display the image at the selected size.
        private void cboScale_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Get the scale.
            float scale = float.Parse(cboScale.Text);

            // Make a bitmap of the right size.
            int wid = (int)(picOriginal.Image.Width * scale);
            int hgt = (int)(picOriginal.Image.Height * scale);
            Bitmap bm = new Bitmap(wid, hgt);
            
            // Draw the image onto the new bitmap.
            using (Graphics gr = Graphics.FromImage(bm))
            {
                // No smoothing.
                gr.InterpolationMode = InterpolationMode.NearestNeighbor;

                Point[] dest =
                {
                    new Point(0, 0),
                    new Point(wid, 0),
                    new Point(0, hgt),
                };
                Rectangle source = new Rectangle(
                    0, 0,
                    picOriginal.Image.Width,
                    picOriginal.Image.Height);
                gr.DrawImage(picOriginal.Image,
                    dest, source, GraphicsUnit.Pixel);
            }

            // Display the result.
            picScaled.Image = bm;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(howto_resize_image_pixelated_Form1));
            this.picOriginal = new System.Windows.Forms.PictureBox();
            this.picScaled = new System.Windows.Forms.PictureBox();
            this.cboScale = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picOriginal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picScaled)).BeginInit();
            this.SuspendLayout();
            // 
            // picOriginal
            // 
            this.picOriginal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picOriginal.Image = ((System.Drawing.Image)(resources.GetObject("picOriginal.Image")));
            this.picOriginal.Location = new System.Drawing.Point(12, 12);
            this.picOriginal.Name = "picOriginal";
            this.picOriginal.Size = new System.Drawing.Size(137, 44);
            this.picOriginal.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picOriginal.TabIndex = 0;
            this.picOriginal.TabStop = false;
            // 
            // picScaled
            // 
            this.picScaled.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picScaled.Image = ((System.Drawing.Image)(resources.GetObject("picScaled.Image")));
            this.picScaled.Location = new System.Drawing.Point(12, 62);
            this.picScaled.Name = "picScaled";
            this.picScaled.Size = new System.Drawing.Size(137, 44);
            this.picScaled.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picScaled.TabIndex = 1;
            this.picScaled.TabStop = false;
            // 
            // cboScale
            // 
            this.cboScale.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboScale.FormattingEnabled = true;
            this.cboScale.Items.AddRange(new object[] {
            "0.25",
            "0.5",
            "1",
            "2",
            "4",
            "8",
            "16"});
            this.cboScale.Location = new System.Drawing.Point(196, 12);
            this.cboScale.Name = "cboScale";
            this.cboScale.Size = new System.Drawing.Size(45, 21);
            this.cboScale.TabIndex = 2;
            this.cboScale.SelectedIndexChanged += new System.EventHandler(this.cboScale_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(153, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Scale:";
            // 
            // howto_resize_image_pixelated_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(387, 261);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cboScale);
            this.Controls.Add(this.picScaled);
            this.Controls.Add(this.picOriginal);
            this.Name = "howto_resize_image_pixelated_Form1";
            this.Text = "howto_resize_image_pixelated";
            this.Load += new System.EventHandler(this.howto_resize_image_pixelated_Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picOriginal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picScaled)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picOriginal;
        private System.Windows.Forms.PictureBox picScaled;
        private System.Windows.Forms.ComboBox cboScale;
        private System.Windows.Forms.Label label1;
    }
}

