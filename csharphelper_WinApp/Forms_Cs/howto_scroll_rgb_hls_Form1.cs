using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

 

using howto_scroll_rgb_hls;
namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_scroll_rgb_hls_Form1:Form
  { 


        public howto_scroll_rgb_hls_Form1()
        {
            InitializeComponent();
        }

        private void howto_scroll_rgb_hls_Form1_Load(object sender, EventArgs e)
        {
            scrRGB_Scroll(null, null);
        }

        // Select a new RGB color.
        private void scrRGB_Scroll(object sender, ScrollEventArgs e)
        {
            // Save the selected color and display a sample.
            int R = scrR.Value;
            int G = scrG.Value;
            int B = scrB.Value;
            picSample.BackColor = Color.FromArgb(R, G, B);

            // Convert to HLS.
            double H, L, S;
            ColorStuff.RgbToHls(R, G, B, out H, out L, out S);

            // Display HLS values.
            scrH.Value = (int)H;
            scrL.Value = (int)(L * 1000);
            scrS.Value = (int)(S * 1000);

            ShowNumericValues(R, G, B, H, L, S);
        }

        // Select a new HLS color.
        private void scrHLS_Scroll(object sender, ScrollEventArgs e)
        {
            // Convert into RGB.
            double H = scrH.Value;
            double L = scrL.Value / 1000.0;
            double S = scrS.Value / 1000.0;
            int R, G, B;
            ColorStuff.HlsToRgb(H, L, S, out R, out G, out B);

            // Display RGB values.
            scrR.Value = R;
            scrG.Value = G;
            scrB.Value = B;

            // Save the selected color and display a sample.
            picSample.BackColor = Color.FromArgb(R, G, B);

            ShowNumericValues(R, G, B, H, L, S);
        }

        private void ShowNumericValues(int R, int G, int B, double H, double L, double S)
        {
            txtR.Text = R.ToString();
            txtG.Text = G.ToString();
            txtB.Text = B.ToString();
            txtH.Text = H.ToString("0");
            txtL.Text = L.ToString("0.00");
            txtS.Text = S.ToString("0.00");
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
            this.txtB = new System.Windows.Forms.TextBox();
            this.txtG = new System.Windows.Forms.TextBox();
            this.txtR = new System.Windows.Forms.TextBox();
            this.scrS = new System.Windows.Forms.HScrollBar();
            this.label4 = new System.Windows.Forms.Label();
            this.scrL = new System.Windows.Forms.HScrollBar();
            this.label5 = new System.Windows.Forms.Label();
            this.scrH = new System.Windows.Forms.HScrollBar();
            this.label6 = new System.Windows.Forms.Label();
            this.scrB = new System.Windows.Forms.HScrollBar();
            this.label3 = new System.Windows.Forms.Label();
            this.scrG = new System.Windows.Forms.HScrollBar();
            this.label2 = new System.Windows.Forms.Label();
            this.scrR = new System.Windows.Forms.HScrollBar();
            this.picSample = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picSample)).BeginInit();
            this.SuspendLayout();
            // 
            // txtS
            // 
            this.txtS.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtS.Location = new System.Drawing.Point(231, 128);
            this.txtS.Name = "txtS";
            this.txtS.ReadOnly = true;
            this.txtS.Size = new System.Drawing.Size(41, 20);
            this.txtS.TabIndex = 64;
            this.txtS.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtL
            // 
            this.txtL.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtL.Location = new System.Drawing.Point(231, 107);
            this.txtL.Name = "txtL";
            this.txtL.ReadOnly = true;
            this.txtL.Size = new System.Drawing.Size(41, 20);
            this.txtL.TabIndex = 63;
            this.txtL.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtH
            // 
            this.txtH.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtH.Location = new System.Drawing.Point(231, 85);
            this.txtH.Name = "txtH";
            this.txtH.ReadOnly = true;
            this.txtH.Size = new System.Drawing.Size(41, 20);
            this.txtH.TabIndex = 62;
            this.txtH.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtB
            // 
            this.txtB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtB.Location = new System.Drawing.Point(231, 55);
            this.txtB.Name = "txtB";
            this.txtB.ReadOnly = true;
            this.txtB.Size = new System.Drawing.Size(41, 20);
            this.txtB.TabIndex = 61;
            this.txtB.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtG
            // 
            this.txtG.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtG.Location = new System.Drawing.Point(231, 34);
            this.txtG.Name = "txtG";
            this.txtG.ReadOnly = true;
            this.txtG.Size = new System.Drawing.Size(41, 20);
            this.txtG.TabIndex = 60;
            this.txtG.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtR
            // 
            this.txtR.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtR.Location = new System.Drawing.Point(231, 13);
            this.txtR.Name = "txtR";
            this.txtR.ReadOnly = true;
            this.txtR.Size = new System.Drawing.Size(41, 20);
            this.txtR.TabIndex = 59;
            this.txtR.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // scrS
            // 
            this.scrS.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.scrS.LargeChange = 100;
            this.scrS.Location = new System.Drawing.Point(33, 127);
            this.scrS.Maximum = 1099;
            this.scrS.Name = "scrS";
            this.scrS.Size = new System.Drawing.Size(195, 17);
            this.scrS.SmallChange = 10;
            this.scrS.TabIndex = 58;
            this.scrS.Scroll += new System.Windows.Forms.ScrollEventHandler(this.scrHLS_Scroll);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 127);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(17, 13);
            this.label4.TabIndex = 57;
            this.label4.Text = "S:";
            // 
            // scrL
            // 
            this.scrL.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.scrL.LargeChange = 100;
            this.scrL.Location = new System.Drawing.Point(33, 106);
            this.scrL.Maximum = 1099;
            this.scrL.Name = "scrL";
            this.scrL.Size = new System.Drawing.Size(195, 17);
            this.scrL.SmallChange = 10;
            this.scrL.TabIndex = 56;
            this.scrL.Scroll += new System.Windows.Forms.ScrollEventHandler(this.scrHLS_Scroll);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 106);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(16, 13);
            this.label5.TabIndex = 55;
            this.label5.Text = "L:";
            // 
            // scrH
            // 
            this.scrH.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.scrH.Location = new System.Drawing.Point(33, 85);
            this.scrH.Maximum = 369;
            this.scrH.Name = "scrH";
            this.scrH.Size = new System.Drawing.Size(195, 17);
            this.scrH.TabIndex = 54;
            this.scrH.Scroll += new System.Windows.Forms.ScrollEventHandler(this.scrHLS_Scroll);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 85);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(18, 13);
            this.label6.TabIndex = 53;
            this.label6.Text = "H:";
            // 
            // scrB
            // 
            this.scrB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.scrB.Location = new System.Drawing.Point(33, 55);
            this.scrB.Maximum = 264;
            this.scrB.Name = "scrB";
            this.scrB.Size = new System.Drawing.Size(195, 17);
            this.scrB.TabIndex = 52;
            this.scrB.Scroll += new System.Windows.Forms.ScrollEventHandler(this.scrRGB_Scroll);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 55);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(17, 13);
            this.label3.TabIndex = 51;
            this.label3.Text = "B:";
            // 
            // scrG
            // 
            this.scrG.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.scrG.Location = new System.Drawing.Point(33, 34);
            this.scrG.Maximum = 264;
            this.scrG.Name = "scrG";
            this.scrG.Size = new System.Drawing.Size(195, 17);
            this.scrG.TabIndex = 50;
            this.scrG.Scroll += new System.Windows.Forms.ScrollEventHandler(this.scrRGB_Scroll);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(18, 13);
            this.label2.TabIndex = 49;
            this.label2.Text = "G:";
            // 
            // scrR
            // 
            this.scrR.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.scrR.Location = new System.Drawing.Point(33, 13);
            this.scrR.Maximum = 264;
            this.scrR.Name = "scrR";
            this.scrR.Size = new System.Drawing.Size(195, 17);
            this.scrR.TabIndex = 48;
            this.scrR.Scroll += new System.Windows.Forms.ScrollEventHandler(this.scrRGB_Scroll);
            // 
            // picSample
            // 
            this.picSample.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.picSample.Location = new System.Drawing.Point(12, 153);
            this.picSample.Name = "picSample";
            this.picSample.Size = new System.Drawing.Size(260, 96);
            this.picSample.TabIndex = 47;
            this.picSample.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(18, 13);
            this.label1.TabIndex = 46;
            this.label1.Text = "R:";
            // 
            // howto_scroll_rgb_hls_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.txtS);
            this.Controls.Add(this.txtL);
            this.Controls.Add(this.txtH);
            this.Controls.Add(this.txtB);
            this.Controls.Add(this.txtG);
            this.Controls.Add(this.txtR);
            this.Controls.Add(this.scrS);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.scrL);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.scrH);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.scrB);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.scrG);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.scrR);
            this.Controls.Add(this.picSample);
            this.Controls.Add(this.label1);
            this.Name = "howto_scroll_rgb_hls_Form1";
            this.Text = "howto_scroll_rgb_hls";
            this.Load += new System.EventHandler(this.howto_scroll_rgb_hls_Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picSample)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtS;
        private System.Windows.Forms.TextBox txtL;
        private System.Windows.Forms.TextBox txtH;
        private System.Windows.Forms.TextBox txtB;
        private System.Windows.Forms.TextBox txtG;
        private System.Windows.Forms.TextBox txtR;
        private System.Windows.Forms.HScrollBar scrS;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.HScrollBar scrL;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.HScrollBar scrH;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.HScrollBar scrB;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.HScrollBar scrG;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.HScrollBar scrR;
        private System.Windows.Forms.PictureBox picSample;
        private System.Windows.Forms.Label label1;
    }
}

