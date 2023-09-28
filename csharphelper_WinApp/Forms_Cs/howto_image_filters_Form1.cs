using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

 

using howto_image_filters;
namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_image_filters_Form1:Form
  { 


        public howto_image_filters_Form1()
        {
            InitializeComponent();
        }

        // Display the initial image.
        private void howto_image_filters_Form1_Load(object sender, EventArgs e)
        {
            picVisible.Image = picHidden.Image.Clone() as Image;
        }

        // Display the original image.
        private void btnReset_Click(object sender, EventArgs e)
        {
            picVisible.Image = picHidden.Image.Clone() as Image;
            lblElapsed.Text = "";
        }

        // Apply a filter.
        private void ApplyFilter(Bitmap32.Filter filter)
        {
            Bitmap bm = new Bitmap(picVisible.Image);
            this.Cursor = Cursors.WaitCursor;
            DateTime start_time = DateTime.Now;

            // Make a Bitmap24 object.
            Bitmap32 bm32 = new Bitmap32(bm);

            // Apply the filter.
            Bitmap32 new_bm32 = bm32.ApplyFilter(filter, false);

            // Display the result.
            picVisible.Image = new_bm32.Bitmap;

            DateTime stop_time = DateTime.Now;
            this.Cursor = Cursors.Default;

            TimeSpan elapsed_time = stop_time - start_time;
            lblElapsed.Text = elapsed_time.TotalSeconds.ToString("0.000000");
        }

        // Apply an embossing filter.
        private void btnEmboss1_Click(object sender, EventArgs e)
        {
            ApplyFilter(Bitmap32.EmbossingFilter);
        }

        // Apply an embossing filter.
        private void btnEmboss2_Click(object sender, EventArgs e)
        {
            ApplyFilter(Bitmap32.EmbossingFilter2);
        }

        // Apply a 5x5 Gaussian blurring filter.
        private void btnBlur1_Click(object sender, EventArgs e)
        {
            ApplyFilter(Bitmap32.BlurFilter5x5Gaussian);
        }

        // Apply a 5x5 mean blurring filter.
        private void btnBlur2_Click(object sender, EventArgs e)
        {
            ApplyFilter(Bitmap32.BlurFilter5x5Mean);
        }

        // Apply a high-pass filter.
        private void btnHighPass1_Click(object sender, EventArgs e)
        {
            ApplyFilter(Bitmap32.HighPassFilter3x3);
        }

        // Apply a high-pass filter.
        private void btnHighPass2_Click(object sender, EventArgs e)
        {
            ApplyFilter(Bitmap32.HighPassFilter5x5);
        }

        // Apply an edge-detecting filter.
        private void btnEdge1_Click(object sender, EventArgs e)
        {
            ApplyFilter(Bitmap32.EdgeDetectionFilterULtoLR);
        }

        // Apply an edge-detecting filter.
        private void btnEdge2_Click(object sender, EventArgs e)
        {
            ApplyFilter(Bitmap32.EdgeDetectionFilterTopToBottom);
        }

        // Apply an edge-detecting filter.
        private void btnEdge3_Click(object sender, EventArgs e)
        {
            ApplyFilter(Bitmap32.EdgeDetectionFilterLeftToRight);
        }

        // Average the colors.
        private void btnAverage_Click(object sender, EventArgs e)
        {
            Bitmap bm = new Bitmap(picVisible.Image);
            this.Cursor = Cursors.WaitCursor;
            DateTime start_time = DateTime.Now;

            // Make a Bitmap24 object.
            Bitmap32 bm32 = new Bitmap32(bm);

            // Average the colors.
            bm32.Average();

            // Display the result.
            picVisible.Image = bm;

            DateTime stop_time = DateTime.Now;
            this.Cursor = Cursors.Default;

            TimeSpan elapsed_time = stop_time - start_time;
            lblElapsed.Text = elapsed_time.TotalSeconds.ToString("0.000000");
        }

        // Convert to grayscale.
        private void btnGrayscale_Click(object sender, EventArgs e)
        {
            Bitmap bm = new Bitmap(picVisible.Image);
            this.Cursor = Cursors.WaitCursor;
            DateTime start_time = DateTime.Now;

            // Make a Bitmap24 object.
            Bitmap32 bm32 = new Bitmap32(bm);

            // Convert to grayscale.
            bm32.Grayscale();

            // Display the result.
            picVisible.Image = bm;

            DateTime stop_time = DateTime.Now;
            this.Cursor = Cursors.Default;

            TimeSpan elapsed_time = stop_time - start_time;
            lblElapsed.Text = elapsed_time.TotalSeconds.ToString("0.000000");
        }

        // Convert to a red scale.
        private void btnRed_Click(object sender, EventArgs e)
        {
            Bitmap bm = new Bitmap(picVisible.Image);
            this.Cursor = Cursors.WaitCursor;
            DateTime start_time = DateTime.Now;

            // Make a Bitmap24 object.
            Bitmap32 bm32 = new Bitmap32(bm);

            // Convert to red.
            bm32.ClearGreen();
            bm32.ClearBlue();

            // Display the result.
            picVisible.Image = bm;

            DateTime stop_time = DateTime.Now;
            this.Cursor = Cursors.Default;

            TimeSpan elapsed_time = stop_time - start_time;
            lblElapsed.Text = elapsed_time.TotalSeconds.ToString("0.000000");
        }

        // Convert to a green scale.
        private void btnGreen_Click(object sender, EventArgs e)
        {
            Bitmap bm = new Bitmap(picVisible.Image);
            this.Cursor = Cursors.WaitCursor;
            DateTime start_time = DateTime.Now;

            // Make a Bitmap24 object.
            Bitmap32 bm32 = new Bitmap32(bm);

            // Convert to green.
            bm32.ClearRed();
            bm32.ClearBlue();

            // Display the result.
            picVisible.Image = bm;

            DateTime stop_time = DateTime.Now;
            this.Cursor = Cursors.Default;

            TimeSpan elapsed_time = stop_time - start_time;
            lblElapsed.Text = elapsed_time.TotalSeconds.ToString("0.000000");
        }

        // Convert to a blue scale.
        private void btnBlue_Click(object sender, EventArgs e)
        {
            Bitmap bm = new Bitmap(picVisible.Image);
            this.Cursor = Cursors.WaitCursor;
            DateTime start_time = DateTime.Now;

            // Make a Bitmap24 object.
            Bitmap32 bm32 = new Bitmap32(bm);

            // Convert to blue.
            bm32.ClearRed();
            bm32.ClearGreen();

            // Display the result.
            picVisible.Image = bm;

            DateTime stop_time = DateTime.Now;
            this.Cursor = Cursors.Default;

            TimeSpan elapsed_time = stop_time - start_time;
            lblElapsed.Text = elapsed_time.TotalSeconds.ToString("0.000000");
        }

        // Invert the image.
        private void btnInvert_Click(object sender, EventArgs e)
        {
            Bitmap bm = new Bitmap(picVisible.Image);
            this.Cursor = Cursors.WaitCursor;
            DateTime start_time = DateTime.Now;

            // Make a Bitmap24 object.
            Bitmap32 bm32 = new Bitmap32(bm);

            // Convert to blue.
            bm32.Invert();

            // Display the result.
            picVisible.Image = bm;

            DateTime stop_time = DateTime.Now;
            this.Cursor = Cursors.Default;

            TimeSpan elapsed_time = stop_time - start_time;
            lblElapsed.Text = elapsed_time.TotalSeconds.ToString("0.000000");
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
            this.btnReset = new System.Windows.Forms.Button();
            this.lblElapsed = new System.Windows.Forms.Label();
            this.btnEmboss1 = new System.Windows.Forms.Button();
            this.btnBlur1 = new System.Windows.Forms.Button();
            this.btnBlur2 = new System.Windows.Forms.Button();
            this.btnHighPass1 = new System.Windows.Forms.Button();
            this.btnHighPass2 = new System.Windows.Forms.Button();
            this.btnEdge1 = new System.Windows.Forms.Button();
            this.btnEdge2 = new System.Windows.Forms.Button();
            this.btnEmboss2 = new System.Windows.Forms.Button();
            this.btnEdge3 = new System.Windows.Forms.Button();
            this.btnAverage = new System.Windows.Forms.Button();
            this.btnGrayscale = new System.Windows.Forms.Button();
            this.picHidden = new System.Windows.Forms.PictureBox();
            this.picVisible = new System.Windows.Forms.PictureBox();
            this.btnGreen = new System.Windows.Forms.Button();
            this.btnRed = new System.Windows.Forms.Button();
            this.btnBlue = new System.Windows.Forms.Button();
            this.btnInvert = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picHidden)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picVisible)).BeginInit();
            this.SuspendLayout();
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(12, 12);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(80, 24);
            this.btnReset.TabIndex = 0;
            this.btnReset.Text = "Reset";
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // lblElapsed
            // 
            this.lblElapsed.AutoSize = true;
            this.lblElapsed.Location = new System.Drawing.Point(12, 622);
            this.lblElapsed.Name = "lblElapsed";
            this.lblElapsed.Size = new System.Drawing.Size(0, 13);
            this.lblElapsed.TabIndex = 7;
            // 
            // btnEmboss1
            // 
            this.btnEmboss1.Location = new System.Drawing.Point(12, 42);
            this.btnEmboss1.Name = "btnEmboss1";
            this.btnEmboss1.Size = new System.Drawing.Size(80, 24);
            this.btnEmboss1.TabIndex = 1;
            this.btnEmboss1.Text = "Emboss 1";
            this.btnEmboss1.Click += new System.EventHandler(this.btnEmboss1_Click);
            // 
            // btnBlur1
            // 
            this.btnBlur1.Location = new System.Drawing.Point(12, 102);
            this.btnBlur1.Name = "btnBlur1";
            this.btnBlur1.Size = new System.Drawing.Size(80, 24);
            this.btnBlur1.TabIndex = 3;
            this.btnBlur1.Text = "Blur 1";
            this.btnBlur1.Click += new System.EventHandler(this.btnBlur1_Click);
            // 
            // btnBlur2
            // 
            this.btnBlur2.Location = new System.Drawing.Point(12, 132);
            this.btnBlur2.Name = "btnBlur2";
            this.btnBlur2.Size = new System.Drawing.Size(80, 24);
            this.btnBlur2.TabIndex = 4;
            this.btnBlur2.Text = "Blur 2";
            this.btnBlur2.Click += new System.EventHandler(this.btnBlur2_Click);
            // 
            // btnHighPass1
            // 
            this.btnHighPass1.Location = new System.Drawing.Point(12, 162);
            this.btnHighPass1.Name = "btnHighPass1";
            this.btnHighPass1.Size = new System.Drawing.Size(80, 24);
            this.btnHighPass1.TabIndex = 5;
            this.btnHighPass1.Text = "High Pass 1";
            this.btnHighPass1.Click += new System.EventHandler(this.btnHighPass1_Click);
            // 
            // btnHighPass2
            // 
            this.btnHighPass2.Location = new System.Drawing.Point(12, 192);
            this.btnHighPass2.Name = "btnHighPass2";
            this.btnHighPass2.Size = new System.Drawing.Size(80, 24);
            this.btnHighPass2.TabIndex = 6;
            this.btnHighPass2.Text = "High Pass 2";
            this.btnHighPass2.Click += new System.EventHandler(this.btnHighPass2_Click);
            // 
            // btnEdge1
            // 
            this.btnEdge1.Location = new System.Drawing.Point(12, 222);
            this.btnEdge1.Name = "btnEdge1";
            this.btnEdge1.Size = new System.Drawing.Size(80, 24);
            this.btnEdge1.TabIndex = 7;
            this.btnEdge1.Text = "Edge 1";
            this.btnEdge1.Click += new System.EventHandler(this.btnEdge1_Click);
            // 
            // btnEdge2
            // 
            this.btnEdge2.Location = new System.Drawing.Point(12, 252);
            this.btnEdge2.Name = "btnEdge2";
            this.btnEdge2.Size = new System.Drawing.Size(80, 24);
            this.btnEdge2.TabIndex = 8;
            this.btnEdge2.Text = "Edge 2";
            this.btnEdge2.Click += new System.EventHandler(this.btnEdge2_Click);
            // 
            // btnEmboss2
            // 
            this.btnEmboss2.Location = new System.Drawing.Point(12, 72);
            this.btnEmboss2.Name = "btnEmboss2";
            this.btnEmboss2.Size = new System.Drawing.Size(80, 24);
            this.btnEmboss2.TabIndex = 2;
            this.btnEmboss2.Text = "Emboss 2";
            this.btnEmboss2.Click += new System.EventHandler(this.btnEmboss2_Click);
            // 
            // btnEdge3
            // 
            this.btnEdge3.Location = new System.Drawing.Point(12, 282);
            this.btnEdge3.Name = "btnEdge3";
            this.btnEdge3.Size = new System.Drawing.Size(80, 24);
            this.btnEdge3.TabIndex = 9;
            this.btnEdge3.Text = "Edge 3";
            this.btnEdge3.Click += new System.EventHandler(this.btnEdge3_Click);
            // 
            // btnAverage
            // 
            this.btnAverage.Location = new System.Drawing.Point(98, 12);
            this.btnAverage.Name = "btnAverage";
            this.btnAverage.Size = new System.Drawing.Size(80, 24);
            this.btnAverage.TabIndex = 10;
            this.btnAverage.Text = "Average";
            this.btnAverage.Click += new System.EventHandler(this.btnAverage_Click);
            // 
            // btnGrayscale
            // 
            this.btnGrayscale.Location = new System.Drawing.Point(98, 42);
            this.btnGrayscale.Name = "btnGrayscale";
            this.btnGrayscale.Size = new System.Drawing.Size(80, 24);
            this.btnGrayscale.TabIndex = 11;
            this.btnGrayscale.Text = "Grayscale";
            this.btnGrayscale.Click += new System.EventHandler(this.btnGrayscale_Click);
            // 
            // picHidden
            // 
            this.picHidden.Image = Properties.Resources.JackOLanterns;
            this.picHidden.Location = new System.Drawing.Point(315, 58);
            this.picHidden.Name = "picHidden";
            this.picHidden.Size = new System.Drawing.Size(300, 400);
            this.picHidden.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picHidden.TabIndex = 1;
            this.picHidden.TabStop = false;
            this.picHidden.Visible = false;
            // 
            // picVisible
            // 
            this.picVisible.Location = new System.Drawing.Point(237, 12);
            this.picVisible.Name = "picVisible";
            this.picVisible.Size = new System.Drawing.Size(300, 400);
            this.picVisible.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picVisible.TabIndex = 6;
            this.picVisible.TabStop = false;
            // 
            // btnGreen
            // 
            this.btnGreen.Location = new System.Drawing.Point(98, 102);
            this.btnGreen.Name = "btnGreen";
            this.btnGreen.Size = new System.Drawing.Size(80, 24);
            this.btnGreen.TabIndex = 13;
            this.btnGreen.Text = "Green";
            this.btnGreen.Click += new System.EventHandler(this.btnGreen_Click);
            // 
            // btnRed
            // 
            this.btnRed.Location = new System.Drawing.Point(98, 72);
            this.btnRed.Name = "btnRed";
            this.btnRed.Size = new System.Drawing.Size(80, 24);
            this.btnRed.TabIndex = 12;
            this.btnRed.Text = "Red";
            this.btnRed.Click += new System.EventHandler(this.btnRed_Click);
            // 
            // btnBlue
            // 
            this.btnBlue.Location = new System.Drawing.Point(98, 132);
            this.btnBlue.Name = "btnBlue";
            this.btnBlue.Size = new System.Drawing.Size(80, 24);
            this.btnBlue.TabIndex = 14;
            this.btnBlue.Text = "Blue";
            this.btnBlue.Click += new System.EventHandler(this.btnBlue_Click);
            // 
            // btnInvert
            // 
            this.btnInvert.Location = new System.Drawing.Point(98, 162);
            this.btnInvert.Name = "btnInvert";
            this.btnInvert.Size = new System.Drawing.Size(80, 24);
            this.btnInvert.TabIndex = 15;
            this.btnInvert.Text = "Invert";
            this.btnInvert.Click += new System.EventHandler(this.btnInvert_Click);
            // 
            // howto_image_filters_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(549, 421);
            this.Controls.Add(this.btnInvert);
            this.Controls.Add(this.btnBlue);
            this.Controls.Add(this.btnGreen);
            this.Controls.Add(this.btnRed);
            this.Controls.Add(this.btnGrayscale);
            this.Controls.Add(this.btnAverage);
            this.Controls.Add(this.btnEdge3);
            this.Controls.Add(this.btnEmboss2);
            this.Controls.Add(this.btnEdge2);
            this.Controls.Add(this.btnEdge1);
            this.Controls.Add(this.btnHighPass2);
            this.Controls.Add(this.btnHighPass1);
            this.Controls.Add(this.btnBlur2);
            this.Controls.Add(this.btnBlur1);
            this.Controls.Add(this.btnEmboss1);
            this.Controls.Add(this.lblElapsed);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.picHidden);
            this.Controls.Add(this.picVisible);
            this.Name = "howto_image_filters_Form1";
            this.Text = "howto_lockbits_image_class";
            this.Load += new System.EventHandler(this.howto_image_filters_Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picHidden)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picVisible)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.PictureBox picHidden;
        internal System.Windows.Forms.Button btnReset;
        internal System.Windows.Forms.PictureBox picVisible;
        private System.Windows.Forms.Label lblElapsed;
        internal System.Windows.Forms.Button btnEmboss1;
        internal System.Windows.Forms.Button btnBlur1;
        internal System.Windows.Forms.Button btnBlur2;
        internal System.Windows.Forms.Button btnHighPass1;
        internal System.Windows.Forms.Button btnHighPass2;
        internal System.Windows.Forms.Button btnEdge1;
        internal System.Windows.Forms.Button btnEdge2;
        internal System.Windows.Forms.Button btnEmboss2;
        internal System.Windows.Forms.Button btnEdge3;
        internal System.Windows.Forms.Button btnAverage;
        internal System.Windows.Forms.Button btnGrayscale;
        internal System.Windows.Forms.Button btnGreen;
        internal System.Windows.Forms.Button btnRed;
        internal System.Windows.Forms.Button btnBlue;
        internal System.Windows.Forms.Button btnInvert;
    }
}

