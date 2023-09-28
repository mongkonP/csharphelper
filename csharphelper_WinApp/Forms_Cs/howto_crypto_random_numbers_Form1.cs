using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Drawing.Drawing2D;
using System.Security.Cryptography;

 

namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_crypto_random_numbers_Form1:Form
  { 


        public howto_crypto_random_numbers_Form1()
        {
            InitializeComponent();
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            using (Pen thin_pen = new Pen(Color.Black, 0))
            {
                lblRandom.Text = "";
                lblRng.Text = "";
                picGraphRandom.Image = null;
                picGraphRNG.Image = null;
                DateTime start_time, stop_time;
                TimeSpan elapsed;
                Cursor = Cursors.WaitCursor;
                Refresh();

                // Generate values with Random.
                int num_numbers = int.Parse(txtNumNumbers.Text);
                int min = int.Parse(txtMin.Text);
                int max = int.Parse(txtMax.Text);
                Random rand = new Random();
                int[] rand_numbers = new int[num_numbers];
                start_time = DateTime.Now;
                for (int i = 0; i < num_numbers; i++)
                    rand_numbers[i] = rand.Next(min, max);
                stop_time = DateTime.Now;
                elapsed = stop_time - start_time;
                lblRandom.Text = "Random (" + elapsed.TotalSeconds.ToString("0.00") + " sec)";

                // Display a histogram.
                thin_pen.Color = Color.LightBlue;
                DrawHistogram(picGraphRandom, Brushes.Blue, thin_pen, rand_numbers);

                // Generate values with RNGCryptoServiceProvider.
                start_time = DateTime.Now;
                for (int i = 0; i < num_numbers; i++)
                    rand_numbers[i] = RandomInteger(min, max);
                stop_time = DateTime.Now;
                elapsed = stop_time - start_time;
                lblRng.Text = "RNGCryptoServiceProvider (" + elapsed.TotalSeconds.ToString("0.00") + " sec)";

                // Display a histogram.
                thin_pen.Color = Color.LightGreen;
                DrawHistogram(picGraphRNG, Brushes.Green, thin_pen, rand_numbers);

                Cursor = Cursors.Default;
            }
        }

        // The random number provider.
        private RNGCryptoServiceProvider Rand = new RNGCryptoServiceProvider();

        // Return a random integer between a min and max value.
        private int RandomInteger(int min, int max)
        {
            uint scale = uint.MaxValue;
            while (scale == uint.MaxValue)
            {
                // Get four random bytes.
                byte[] four_bytes = new byte[4];
                Rand.GetBytes(four_bytes);

                // Convert that into an uint.
                scale = BitConverter.ToUInt32(four_bytes, 0);
            }

            // Add min to the scaled difference between max and min.
            return (int)(min + (max - min) * (scale / (double)uint.MaxValue));
        }

        // Display a histogram.
        private void DrawHistogram(PictureBox pic, Brush brush, Pen pen, int[] values)
        {
            // Count the values.
            int min = values.Min();
            int max = values.Max();
            int[] counts = new int[max - min + 1];
            for (int i = 0; i < values.Length; i++)
            {
                counts[values[i] - min]++;
            }
            int max_count = counts.Max();

            // Make a Bitmap.
            Bitmap bm = new Bitmap(pic.ClientSize.Width, pic.ClientSize.Height);
            using (Graphics gr = Graphics.FromImage(bm))
            {
                gr.SmoothingMode = SmoothingMode.AntiAlias;

                // Scale to fit the data.
                RectangleF rect = new RectangleF(0, 0, counts.Length, max_count);
                PointF[] pts = 
                {
                    new PointF(0, pic.ClientSize.Height),
                    new PointF(pic.ClientSize.Width, pic.ClientSize.Height),
                    new PointF(0, 0),
                };
                gr.Transform = new Matrix(rect, pts);

                // Fill the histogram.
                for (int i = 0; i < counts.Length; i++)
                {
                    gr.FillRectangle(brush, i, 0, 1, counts[i]);
                }

                // Draw the histogram.
                if (counts.Length < 200)
                {
                    for (int i = 0; i < counts.Length; i++)
                    {
                        gr.DrawRectangle(pen, i, 0, 1, counts[i]);
                    }
                }
            }

            // Display the histogram.
            pic.Image = bm;
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
            this.txtMax = new System.Windows.Forms.TextBox();
            this.Label3 = new System.Windows.Forms.Label();
            this.txtMin = new System.Windows.Forms.TextBox();
            this.Label2 = new System.Windows.Forms.Label();
            this.txtNumNumbers = new System.Windows.Forms.TextBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.picGraphRandom = new System.Windows.Forms.PictureBox();
            this.lblRandom = new System.Windows.Forms.Label();
            this.picGraphRNG = new System.Windows.Forms.PictureBox();
            this.lblRng = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picGraphRandom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picGraphRNG)).BeginInit();
            this.SuspendLayout();
            // 
            // txtMax
            // 
            this.txtMax.Location = new System.Drawing.Point(80, 55);
            this.txtMax.Name = "txtMax";
            this.txtMax.Size = new System.Drawing.Size(56, 20);
            this.txtMax.TabIndex = 15;
            this.txtMax.Text = "100";
            this.txtMax.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.Location = new System.Drawing.Point(8, 55);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(30, 13);
            this.Label3.TabIndex = 14;
            this.Label3.Text = "Max:";
            // 
            // txtMin
            // 
            this.txtMin.Location = new System.Drawing.Point(80, 31);
            this.txtMin.Name = "txtMin";
            this.txtMin.Size = new System.Drawing.Size(56, 20);
            this.txtMin.TabIndex = 13;
            this.txtMin.Text = "1";
            this.txtMin.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Location = new System.Drawing.Point(8, 31);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(27, 13);
            this.Label2.TabIndex = 12;
            this.Label2.Text = "Min:";
            // 
            // txtNumNumbers
            // 
            this.txtNumNumbers.Location = new System.Drawing.Point(80, 7);
            this.txtNumNumbers.Name = "txtNumNumbers";
            this.txtNumNumbers.Size = new System.Drawing.Size(56, 20);
            this.txtNumNumbers.TabIndex = 10;
            this.txtNumNumbers.Text = "1000";
            this.txtNumNumbers.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(8, 7);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(62, 13);
            this.Label1.TabIndex = 9;
            this.Label1.Text = "# Numbers:";
            // 
            // btnGenerate
            // 
            this.btnGenerate.Location = new System.Drawing.Point(184, 31);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(75, 23);
            this.btnGenerate.TabIndex = 8;
            this.btnGenerate.Text = "Generate";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // picGraphRandom
            // 
            this.picGraphRandom.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.picGraphRandom.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.picGraphRandom.Location = new System.Drawing.Point(11, 97);
            this.picGraphRandom.Name = "picGraphRandom";
            this.picGraphRandom.Size = new System.Drawing.Size(807, 162);
            this.picGraphRandom.TabIndex = 16;
            this.picGraphRandom.TabStop = false;
            // 
            // lblRandom
            // 
            this.lblRandom.AutoSize = true;
            this.lblRandom.Location = new System.Drawing.Point(12, 81);
            this.lblRandom.Name = "lblRandom";
            this.lblRandom.Size = new System.Drawing.Size(47, 13);
            this.lblRandom.TabIndex = 17;
            this.lblRandom.Text = "Random";
            // 
            // picGraphRNG
            // 
            this.picGraphRNG.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.picGraphRNG.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.picGraphRNG.Location = new System.Drawing.Point(11, 287);
            this.picGraphRNG.Name = "picGraphRNG";
            this.picGraphRNG.Size = new System.Drawing.Size(807, 162);
            this.picGraphRNG.TabIndex = 18;
            this.picGraphRNG.TabStop = false;
            // 
            // lblRng
            // 
            this.lblRng.AutoSize = true;
            this.lblRng.Location = new System.Drawing.Point(8, 271);
            this.lblRng.Name = "lblRng";
            this.lblRng.Size = new System.Drawing.Size(136, 13);
            this.lblRng.TabIndex = 19;
            this.lblRng.Text = "RNGCryptoServiceProvider";
            // 
            // howto_crypto_random_numbers_Form1
            // 
            this.AcceptButton = this.btnGenerate;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(830, 462);
            this.Controls.Add(this.lblRng);
            this.Controls.Add(this.picGraphRNG);
            this.Controls.Add(this.lblRandom);
            this.Controls.Add(this.picGraphRandom);
            this.Controls.Add(this.txtMax);
            this.Controls.Add(this.Label3);
            this.Controls.Add(this.txtMin);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.txtNumNumbers);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.btnGenerate);
            this.Name = "howto_crypto_random_numbers_Form1";
            this.Text = "howto_crypto_random_numbers";
            ((System.ComponentModel.ISupportInitialize)(this.picGraphRandom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picGraphRNG)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.TextBox txtMax;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.TextBox txtMin;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.TextBox txtNumNumbers;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.PictureBox picGraphRandom;
        private System.Windows.Forms.Label lblRandom;
        private System.Windows.Forms.PictureBox picGraphRNG;
        private System.Windows.Forms.Label lblRng;
    }
}

