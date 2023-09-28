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
     public partial class howto_strange_attractor_Form1:Form
  { 


        public howto_strange_attractor_Form1()
        {
            InitializeComponent();
        }

        private Bitmap Bm;
        private double[] A = new double[12];
        private double X, Y, Wxmin, Wxmax, Wymin, Wymax, Wwid, Whgt;
        private double Wid, Hgt;

        // Select initial coefficients.
        private void howto_strange_attractor_Form1_Load(object sender, EventArgs e)
        {
            cboCoefficients.SelectedIndex = 0;
            StartNewImage();
        }

        // Plot 1,000 points.
        private void tmrDrawPoint_Tick(object sender, EventArgs e)
        {
            for (int i = 1; i <= 1000; i++)
            {
                double new_x = A[0] + A[1] * X + A[2] * X * X + A[3] * X * Y + A[4] * Y + A[5] * Y * Y;
                double new_y = A[6] + A[7] * X + A[8] * X * X + A[9] * X * Y + A[10] * Y + A[11] * Y * Y;
                X = new_x;
                Y = new_y;

                int pix_x = (int)Math.Round((X - Wxmin) / Wwid * Wid);
                int pix_y = (int)Math.Round(Hgt - (Y - Wymin) / Whgt * Hgt - 1);
                if ((pix_x >= 0) && (pix_x < Wid) &&
                    (pix_y >= 0) && (pix_y < Hgt))
                {
                    Bm.SetPixel(pix_x, pix_y, Color.Blue);
                }
            }

            // Display the result.
            picCanvas.Refresh();
        }

        // Start a new image for the new available area.
        private void picCanvas_Resize(object sender, EventArgs e)
        {
            StartNewImage();
        }

        // Make a new bitmap and draw axes if desired.
        private void StartNewImage()
        {
            if (picCanvas.ClientSize.Width <= 0 ||
                picCanvas.ClientSize.Height <= 0) return;

            // Get the current bounds.
            Wid = picCanvas.ClientSize.Width;
            Hgt = picCanvas.ClientSize.Height;

            // Set the coefficients.
            SetCoefficients(cboCoefficients.Text);

            X = 0;
            Y = 0;

            // Make the new bitmap.
            Bm = new Bitmap((int)Wid, (int)Hgt);
            picCanvas.BackgroundImage = Bm;
            using (Graphics gr = Graphics.FromImage(Bm))
            {
                gr.Clear(Color.Black);

                // Draw axes is desired.
                if (chkDrawAxes.Checked)
                {
                    int pix_x = (int)Math.Round((0 - Wxmin) / Wwid * Wid);
                    int pix_y = (int)Math.Round(Hgt - (0 - Wymin) / Whgt * Hgt - 1);
                    gr.DrawLine(Pens.Red, pix_x, 0, pix_x, picCanvas.ClientSize.Height);
                    gr.DrawLine(Pens.Red, 0, pix_y, picCanvas.ClientSize.Width, pix_y);
                    for (float i = -5; i <= 5; i += 0.1f)
                    {
                        pix_x = (int)Math.Round((i - Wxmin) / Wwid * Wid);
                        gr.DrawLine(Pens.Orange, pix_x, pix_y - 3, pix_x, pix_y + 3);
                    }
                    for (float i = -5; i <= 5; i += 1)
                    {
                        pix_x = (int)Math.Round((i - Wxmin) / Wwid * Wid);
                        gr.DrawLine(Pens.Yellow, pix_x, pix_y - 5, pix_x, pix_y + 5);
                    }

                    pix_x = (int)Math.Round((0 - Wxmin) / Wwid * Wid);
                    for (float i = -5; i <= 5; i += 0.1f)
                    {
                        pix_y = (int)Math.Round(Hgt - (i - Wymin) / Whgt * Hgt - 1);
                        gr.DrawLine(Pens.Orange, pix_x - 3, pix_y, pix_x + 3, pix_y);
                    }
                    for (float i = -5; i <= 5; i += 1)
                    {
                        pix_y = (int)Math.Round(Hgt - (i - Wymin) / Whgt * Hgt - 1);
                        gr.DrawLine(Pens.Yellow, pix_x - 5, pix_y, pix_x + 5, pix_y);
                    }
                }
            }

            picCanvas.Invalidate();
        }

        // Set fractal coefficients from the ComboBox's value.
        private void SetCoefficients(string coefficients)
        {
            if (coefficients.Length == 0) return;

            const int ASC_A = (int)'A';

            string[] pieces = coefficients.Split(' ');
            char[] coef_letters = pieces[0].ToUpper().ToCharArray();
            for (int i = 0; i < 12; i++)
            {
                A[i] = -1.2 + ((int)coef_letters[i] - ASC_A) * 0.1;
            }

            Wxmin = Double.Parse(pieces[1]);
            Wxmax = Double.Parse(pieces[2]);
            Wymin = Double.Parse(pieces[3]);
            Wymax = Double.Parse(pieces[4]);
            Wwid = Wxmax - Wxmin;
            Whgt = Wymax - Wymin;
        }

        // Start or stop.
        private void btnStart_Click(object sender, EventArgs e)
        {
            tmrDrawPoint.Enabled = !tmrDrawPoint.Enabled;
            if (tmrDrawPoint.Enabled)
            {
                btnStart.Text = "Stop";
            }
            else
            {
                btnStart.Text = "Start";
            }
        }

        // Select new coefficients.
        private void cboCoefficients_SelectedIndexChanged(object sender, EventArgs e)
        {
            StartNewImage();
        }

        // Redraw with or without axes.
        private void chkDrawAxes_CheckedChanged(object sender, EventArgs e)
        {
            StartNewImage();
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
            this.components = new System.ComponentModel.Container();
            this.chkDrawAxes = new System.Windows.Forms.CheckBox();
            this.cboCoefficients = new System.Windows.Forms.ComboBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.picCanvas = new System.Windows.Forms.PictureBox();
            this.btnStart = new System.Windows.Forms.Button();
            this.tmrDrawPoint = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.picCanvas)).BeginInit();
            this.SuspendLayout();
            // 
            // chkDrawAxes
            // 
            this.chkDrawAxes.Location = new System.Drawing.Point(360, 3);
            this.chkDrawAxes.Name = "chkDrawAxes";
            this.chkDrawAxes.Size = new System.Drawing.Size(80, 16);
            this.chkDrawAxes.TabIndex = 9;
            this.chkDrawAxes.Text = "Draw Axes";
            this.chkDrawAxes.CheckedChanged += new System.EventHandler(this.chkDrawAxes_CheckedChanged);
            // 
            // cboCoefficients
            // 
            this.cboCoefficients.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCoefficients.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboCoefficients.Items.AddRange(new object[] {
            "AMTMNQQXUYGA -1.2 -0.1 -1.5 0.8",
            "CVQKGHQTPHTE -4 1.25 -0.75 1.75",
            "FIRCDERRPVLD -1.1 0.3 -0.75 0.75",
            "GIIETPIQRRUL -2.1 0.9 -0.8 0.85",
            "GLXOESFTTPSV -0.9 1.05 -1 0.85",
            "GXQSNSKEECTX -1.35 0.3 -1.35 0.2",
            "HGUHDPHNSGOH -0.4 0.7 -0.95 -0.15",
            "ILIBVPKJWGRR -0.7 0.4 -0.2 0.7",
            "LUFBBFISGJYS 0.1 2 -1.7 -0.2",
            "MCRBIPOPHTBN -0.8 1.1 -0.4 0.65",
            "MDVAIDOYHYEA -0.8 0.7 -1.1 0.75",
            "ODGQCNXODNYA -1.1 0.6 -0.1 1.5",
            "QFFVSLMJJGCR -1.1 0.8 -0.6 0.7",
            "UWACXDQIGKHF -0.4 1.2 -0.95 0.5",
            "VBWNBDELYHUL 0.15 1.05 -1.1 0.4",
            "WNCSLFLGIHGL -0.35 1.05 -1.25 0.5"});
            this.cboCoefficients.Location = new System.Drawing.Point(64, 0);
            this.cboCoefficients.Name = "cboCoefficients";
            this.cboCoefficients.Size = new System.Drawing.Size(264, 22);
            this.cboCoefficients.TabIndex = 8;
            this.cboCoefficients.SelectedIndexChanged += new System.EventHandler(this.cboCoefficients_SelectedIndexChanged);
            // 
            // Label1
            // 
            this.Label1.Location = new System.Drawing.Point(0, 3);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(64, 16);
            this.Label1.TabIndex = 7;
            this.Label1.Text = "Coefficients";
            // 
            // picCanvas
            // 
            this.picCanvas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.picCanvas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picCanvas.Location = new System.Drawing.Point(0, 24);
            this.picCanvas.Name = "picCanvas";
            this.picCanvas.Size = new System.Drawing.Size(528, 300);
            this.picCanvas.TabIndex = 6;
            this.picCanvas.TabStop = false;
            this.picCanvas.Resize += new System.EventHandler(this.picCanvas_Resize);
            // 
            // btnStart
            // 
            this.btnStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStart.Location = new System.Drawing.Point(452, 0);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 5;
            this.btnStart.Text = "Start";
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // tmrDrawPoint
            // 
            this.tmrDrawPoint.Interval = 10;
            this.tmrDrawPoint.Tick += new System.EventHandler(this.tmrDrawPoint_Tick);
            // 
            // howto_strange_attractor_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(528, 324);
            this.Controls.Add(this.chkDrawAxes);
            this.Controls.Add(this.cboCoefficients);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.picCanvas);
            this.Controls.Add(this.btnStart);
            this.Name = "howto_strange_attractor_Form1";
            this.Text = "howto_strange_attractor";
            this.Load += new System.EventHandler(this.howto_strange_attractor_Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picCanvas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.CheckBox chkDrawAxes;
        internal System.Windows.Forms.ComboBox cboCoefficients;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.PictureBox picCanvas;
        internal System.Windows.Forms.Button btnStart;
        internal System.Windows.Forms.Timer tmrDrawPoint;
    }
}

