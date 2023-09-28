using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Drawing.Drawing2D;

// See "Curlicue Fractal" by Eric W. Weisstein.
// From MathWorld--A Wolfram Web Resource. http://mathworld.wolfram.com/CurlicueFractal.html 

 

namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_curlicue_fractal_Form1:Form
  { 


        public howto_curlicue_fractal_Form1()
        {
            InitializeComponent();
        }

        // Redraw.
        private void btnGo_Click(object sender, EventArgs e)
        {
            picCanvas.Invalidate();
        }

        // Redraw.
        private void picCanvas_Resize(object sender, EventArgs e)
        {
            picCanvas.Invalidate();
        }

        // Draw the curve.
        private void picCanvas_Paint(object sender, PaintEventArgs e)
        {
            DrawCurlicue(e.Graphics);
        }

        // Draw the newly selected curve.
        private void cboS_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cboS.Text.ToLower())
            {
                case "pi":
                    txtS.Text = Math.PI.ToString();
                    break;
                case "ln(2)":
                    txtS.Text = Math.Log(2).ToString();
                    break;
                case "e":
                    txtS.Text = Math.E.ToString();
                    break;
                case "sqrt(2)":
                    txtS.Text = Math.Sqrt(2).ToString();
                    break;
                case "sqrt(3)":
                    txtS.Text = Math.Sqrt(3).ToString();
                    break;
                case "sqrt(5)":
                    txtS.Text = Math.Sqrt(5).ToString();
                    break;
                case "lambda":
                    txtS.Text = "0.577215664901532860606512090082402431042";
                    break;
                case "golden ratio":
                    txtS.Text = "1.618033988749894848204586834365638117720";
                    break;
                case "feigenbaum":
                    txtS.Text = "4.6692016091029906718532038204662016172581855774757686327456513430041343302113147371386897440239480138";
                    break;
            }
            picCanvas.Invalidate();
        }

        // Draw the curve.
        private void DrawCurlicue(Graphics gr)
        {
            const int scale = 2;
            gr.ScaleTransform(
                scale,
                scale,
                MatrixOrder.Append);
            gr.TranslateTransform(
                picCanvas.ClientSize.Width / 2,
                picCanvas.ClientSize.Width / 2,
                MatrixOrder.Append);

            double s = double.Parse(txtS.Text);
            double theta, phi, x0, y0, x1, y1;
            theta = 0;
            phi = 0;
            x0 = 0;
            y0 = 0;

            // Use a zero-width pen so it draws as thin as possible
            // even after scaling.
            using (Pen thin_pen = new Pen(Color.Red, 0))
            {
                for (int i = 1; i <= 10000; i++)
                {
                    x1 = x0 + Math.Cos(phi);
                    y1 = y0 + Math.Sin(phi);
                    gr.DrawLine(thin_pen, (float)x0, (float)-y0, (float)x1, (float)-y1);
                    x0 = x1;
                    y0 = y1;

                    phi = (theta + phi) % (2 * Math.PI);
                    theta = (theta + 2 * Math.PI * s) % (2 * Math.PI);
                }
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
            this.Label1 = new System.Windows.Forms.Label();
            this.cboS = new System.Windows.Forms.ComboBox();
            this.btnGo = new System.Windows.Forms.Button();
            this.txtS = new System.Windows.Forms.TextBox();
            this.picCanvas = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picCanvas)).BeginInit();
            this.SuspendLayout();
            // 
            // Label1
            // 
            this.Label1.Location = new System.Drawing.Point(5, 6);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(24, 16);
            this.Label1.TabIndex = 2;
            this.Label1.Text = "S =";
            // 
            // cboS
            // 
            this.cboS.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboS.Items.AddRange(new object[] {
            "Pi",
            "ln(2)",
            "e",
            "Sqrt(2)",
            "Sqrt(3)",
            "Sqrt(5)",
            "Lambda",
            "Golden Ratio",
            "Feigenbaum"});
            this.cboS.Location = new System.Drawing.Point(163, 3);
            this.cboS.Name = "cboS";
            this.cboS.Size = new System.Drawing.Size(112, 21);
            this.cboS.TabIndex = 7;
            this.cboS.SelectedIndexChanged += new System.EventHandler(this.cboS_SelectedIndexChanged);
            // 
            // btnGo
            // 
            this.btnGo.Location = new System.Drawing.Point(123, 3);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(32, 23);
            this.btnGo.TabIndex = 6;
            this.btnGo.Text = "Go";
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // txtS
            // 
            this.txtS.Location = new System.Drawing.Point(35, 3);
            this.txtS.Name = "txtS";
            this.txtS.Size = new System.Drawing.Size(80, 20);
            this.txtS.TabIndex = 5;
            this.txtS.Text = "3.14159265";
            // 
            // picCanvas
            // 
            this.picCanvas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.picCanvas.BackColor = System.Drawing.Color.Black;
            this.picCanvas.Location = new System.Drawing.Point(12, 32);
            this.picCanvas.Name = "picCanvas";
            this.picCanvas.Size = new System.Drawing.Size(616, 641);
            this.picCanvas.TabIndex = 8;
            this.picCanvas.TabStop = false;
            this.picCanvas.Resize += new System.EventHandler(this.picCanvas_Resize);
            this.picCanvas.Paint += new System.Windows.Forms.PaintEventHandler(this.picCanvas_Paint);
            // 
            // howto_curlicue_fractal_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(640, 685);
            this.Controls.Add(this.picCanvas);
            this.Controls.Add(this.cboS);
            this.Controls.Add(this.btnGo);
            this.Controls.Add(this.txtS);
            this.Controls.Add(this.Label1);
            this.Name = "howto_curlicue_fractal_Form1";
            this.Text = "howto_curlicue_fractal";
            ((System.ComponentModel.ISupportInitialize)(this.picCanvas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.ComboBox cboS;
        internal System.Windows.Forms.Button btnGo;
        internal System.Windows.Forms.TextBox txtS;
        private System.Windows.Forms.PictureBox picCanvas;
    }
}

