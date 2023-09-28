using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

 

using howto_rgb_to_hls;
namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_rgb_to_hls_Form1:Form
  { 


        public howto_rgb_to_hls_Form1()
        {
            InitializeComponent();
        }

        // The selected color.
        private Color SelectedColor;

        // Select the first color from the RGB controls.
        private void howto_rgb_to_hls_Form1_Load(object sender, EventArgs e)
        {
            SelectRGBColor();
        }

        // True while we're setting the color.
        private bool IgnoreEvents = false;

        // Set a new RGB value.
        private void nudRGB_ValueChanged(object sender, EventArgs e)
        {
            SelectRGBColor();
        }

        // Happens when the user presses a key.
        private void nudRGB_KeyUp(object sender, KeyEventArgs e)
        {
            SelectRGBColor();
        }

        // Select a color from the RGB values.
        private void SelectRGBColor()
        {
            if (IgnoreEvents) return;
            IgnoreEvents = true;

            // Save the selected color and display a sample.
            int R = (int)nudR.Value;
            int G = (int)nudG.Value;
            int B = (int)nudB.Value;
            SelectedColor = Color.FromArgb(R, G, B);
            picSample.BackColor = SelectedColor;

            // Convert to HLS.
            double H, L, S;
            ColorStuff.RgbToHls(R, G, B, out H, out L, out S);

            // Display HLS values.
            txtH.Text = H.ToString("0.00");
            txtL.Text = L.ToString("0.00");
            txtS.Text = S.ToString("0.00");

            IgnoreEvents = false;
        }

        // Set a new HLS value.
        private void txtHLS_TextChanged(object sender, EventArgs e)
        {
            SelectHLSColor();
        }

        // Select a color from the HLS values.
        private void SelectHLSColor()
        {
            if (IgnoreEvents) return;
            IgnoreEvents = true;

            try
            {
                // Convert into RGB.
                double H = double.Parse(txtH.Text);
                double L = double.Parse(txtL.Text);
                double S = double.Parse(txtS.Text);
                int R, G, B;
                ColorStuff.HlsToRgb(H, L, S, out R, out G, out B);

                // Display RGB values.
                nudR.Value = (decimal)R;
                nudG.Value = (decimal)G;
                nudB.Value = (decimal)B;

                // Save the selected color and display a sample.
                SelectedColor = Color.FromArgb(
                    (int)nudR.Value,
                    (int)nudG.Value,
                    (int)nudB.Value);
                picSample.BackColor = SelectedColor;
            }
            catch
            {
            }
            IgnoreEvents = false;
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
            this.txtS = new System.Windows.Forms.TextBox();
            this.txtL = new System.Windows.Forms.TextBox();
            this.txtH = new System.Windows.Forms.TextBox();
            this.picSample = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.nudB = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.nudG = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.nudR = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picSample)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudG)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudR)).BeginInit();
            this.SuspendLayout();
            // 
            // txtS
            // 
            this.txtS.Location = new System.Drawing.Point(153, 64);
            this.txtS.Name = "txtS";
            this.txtS.Size = new System.Drawing.Size(50, 20);
            this.txtS.TabIndex = 28;
            this.txtS.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtS.TextChanged += new System.EventHandler(this.txtHLS_TextChanged);
            // 
            // txtL
            // 
            this.txtL.Location = new System.Drawing.Point(153, 38);
            this.txtL.Name = "txtL";
            this.txtL.Size = new System.Drawing.Size(50, 20);
            this.txtL.TabIndex = 27;
            this.txtL.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtL.TextChanged += new System.EventHandler(this.txtHLS_TextChanged);
            // 
            // txtH
            // 
            this.txtH.Location = new System.Drawing.Point(153, 12);
            this.txtH.Name = "txtH";
            this.txtH.Size = new System.Drawing.Size(50, 20);
            this.txtH.TabIndex = 26;
            this.txtH.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtH.TextChanged += new System.EventHandler(this.txtHLS_TextChanged);
            // 
            // picSample
            // 
            this.picSample.Location = new System.Drawing.Point(12, 91);
            this.picSample.Name = "picSample";
            this.picSample.Size = new System.Drawing.Size(191, 72);
            this.picSample.TabIndex = 25;
            this.picSample.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(129, 67);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(17, 13);
            this.label4.TabIndex = 24;
            this.label4.Text = "S:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(129, 41);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(16, 13);
            this.label5.TabIndex = 23;
            this.label5.Text = "L:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(129, 15);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(18, 13);
            this.label6.TabIndex = 22;
            this.label6.Text = "H:";
            // 
            // nudB
            // 
            this.nudB.Location = new System.Drawing.Point(36, 65);
            this.nudB.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.nudB.Name = "nudB";
            this.nudB.Size = new System.Drawing.Size(50, 20);
            this.nudB.TabIndex = 21;
            this.nudB.Value = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.nudB.ValueChanged += new System.EventHandler(this.nudRGB_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(17, 13);
            this.label3.TabIndex = 20;
            this.label3.Text = "B:";
            // 
            // nudG
            // 
            this.nudG.Location = new System.Drawing.Point(36, 39);
            this.nudG.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.nudG.Name = "nudG";
            this.nudG.Size = new System.Drawing.Size(50, 20);
            this.nudG.TabIndex = 19;
            this.nudG.Value = new decimal(new int[] {
            128,
            0,
            0,
            0});
            this.nudG.ValueChanged += new System.EventHandler(this.nudRGB_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(18, 13);
            this.label2.TabIndex = 18;
            this.label2.Text = "G:";
            // 
            // nudR
            // 
            this.nudR.Location = new System.Drawing.Point(36, 13);
            this.nudR.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.nudR.Name = "nudR";
            this.nudR.Size = new System.Drawing.Size(50, 20);
            this.nudR.TabIndex = 17;
            this.nudR.ValueChanged += new System.EventHandler(this.nudRGB_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(18, 13);
            this.label1.TabIndex = 16;
            this.label1.Text = "R:";
            // 
            // howto_rgb_to_hls_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(215, 174);
            this.Controls.Add(this.txtS);
            this.Controls.Add(this.txtL);
            this.Controls.Add(this.txtH);
            this.Controls.Add(this.picSample);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.nudB);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.nudG);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.nudR);
            this.Controls.Add(this.label1);
            this.Name = "howto_rgb_to_hls_Form1";
            this.Text = "howto_rgb_to_hls";
            this.Load += new System.EventHandler(this.howto_rgb_to_hls_Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picSample)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudG)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudR)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtS;
        private System.Windows.Forms.TextBox txtL;
        private System.Windows.Forms.TextBox txtH;
        private System.Windows.Forms.PictureBox picSample;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown nudB;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown nudG;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown nudR;
        private System.Windows.Forms.Label label1;
    }
}

