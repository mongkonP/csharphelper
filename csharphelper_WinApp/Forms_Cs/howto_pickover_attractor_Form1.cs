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
     public partial class howto_pickover_attractor_Form1:Form
  { 


        public howto_pickover_attractor_Form1()
        {
            InitializeComponent();
        }

        // The plane we should project on.
        private enum Plane
        {
            XY,
            YZ,
            XZ,
        }
        private Plane SelectedPlane;

        // The Bitmap and Graphics object.
        private Bitmap bm;
        private Graphics gr;

        // Drawing size variables.
        private int wid, hgt;
        private double xoff, yoff, zoff, xscale, yscale, zscale;

        // Drawing parameters.
        private double A, B, C, D, E, X0, Y0, Z0;

        // The colors.
        Color BgColor, FgColor;

        // Start with the first plane selected.
        private void howto_pickover_attractor_Form1_Load(object sender, EventArgs e)
        {
            cboPlane.SelectedIndex = 0;
            SelectedPlane = Plane.XY;
        }

        // Let the user pick a new color.
        private void ColorSample_Click(object sender, EventArgs e)
        {
            Label lbl = sender as Label;
            cdColor.Color = lbl.BackColor;
            if (cdColor.ShowDialog() == DialogResult.OK)
            {
                lbl.BackColor = cdColor.Color;
            }
        }

        // Start or stop drawing.
        bool Running = false;
        private void btnStart_Click(object sender, EventArgs e)
        {
            if (Running)
            {
                Running = false;
                btnStart.Text = "Stopped";
            }
            else
            {
                Running = true;
                btnStart.Text = "Stop";
                DrawCurve();
                btnStart.Text = "Go";
            }
        }

        // Draw the curve.
        private void DrawCurve()
        {
            // Get the parameters and otherwise get ready.
            Prepare();

            // Start drawing.
            double x = X0, y = Y0, z = Z0;
            while (Running)
            {
                // Plot a bunch of points.
                for (int i = 1; i<=1000; i++)
                {
                    // Move to the next point.
                    double x2 = Math.Sin(A * y) - z * Math.Cos(B * x);
                    double y2 = z * Math.Sin(C * x) - Math.Cos(D * y);
                    z = Math.Sin(x);
                    x = x2;
                    y = y2;

                    // Plot the point.
                    switch (SelectedPlane)
                    {
                        case Plane.XY:
                            bm.SetPixel((int)(x * xscale + xoff), (int)(y * yscale + yoff), FgColor);
                            break;
                        case Plane.YZ:
                            bm.SetPixel((int)(y * yscale + yoff), (int)(z * zscale + zoff), FgColor);
                            break;
                        case Plane.XZ:
                            bm.SetPixel((int)(x * xscale + xoff), (int)(z * zscale + zoff), FgColor);
                            break;
                    }
                }

                // Refresh.
                picCanvas.Refresh();

                // Check events to see if the user clicked Stop.
                Application.DoEvents();
            }
        }

        // Get ready to draw.
        private void Prepare()
        {
            // Get the colors.
            BgColor = lblBackColor.BackColor;
            FgColor = lblForeColor.BackColor;

            // Make the Bitmap and Graphics object.
            wid = picCanvas.ClientSize.Width;
            hgt = picCanvas.ClientSize.Height;
            bm = new Bitmap(wid, hgt);
            gr = Graphics.FromImage(bm);
            gr.Clear(BgColor);
            picCanvas.Image = bm;

            // Calculate scaling parameters.
            const double XMIN = -2.1;
            const double XMAX = 2.1;
            const double YMIN = -2.1;
            const double YMAX = 2.1;
            const double ZMIN = -1.2;
            const double ZMAX = 1.2;
            SelectedPlane = (Plane)cboPlane.SelectedIndex;
            switch (SelectedPlane)
            {
                case Plane.XY:
                    xoff = wid / 2;
                    yoff = hgt / 2;
                    xscale = wid / (XMAX - XMIN);
                    yscale = hgt / (YMAX - YMIN);
                    break;
                case Plane.YZ:
                    yoff = wid / 2;
                    zoff = hgt / 2;
                    yscale = wid / (YMAX - YMIN);
                    zscale = hgt / (ZMAX - ZMIN);
                    break;
                case Plane.XZ:
                    xoff = wid / 2;
                    zoff = hgt / 2;
                    xscale = wid / (XMAX - XMIN);
                    zscale = hgt / (ZMAX - ZMIN);
                    break;
            }

            // Get the parameters.
            if (double.TryParse(txtA.Text, out A)) A = 2.0;
            if (double.TryParse(txtB.Text, out B)) B = 0.5;
            if (double.TryParse(txtC.Text, out C)) C = -0.6;
            if (double.TryParse(txtD.Text, out D)) D = -2.5;
            if (double.TryParse(txtE.Text, out E)) E = 1.0;
            if (double.TryParse(txtX0.Text, out X0)) X0 = 0.0;
            if (double.TryParse(txtY0.Text, out Y0)) Y0 = 0.0;
            if (double.TryParse(txtZ0.Text, out Z0)) Z0 = 0.0;
        }

        // Adjust for the new size.
        private void picCanvas_Resize(object sender, EventArgs e)
        {
            Prepare();
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
            this.btnStart = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lblForeColor = new System.Windows.Forms.Label();
            this.lblBackColor = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cboPlane = new System.Windows.Forms.ComboBox();
            this.cdColor = new System.Windows.Forms.ColorDialog();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtA = new System.Windows.Forms.TextBox();
            this.txtB = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtC = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtD = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtE = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtZ0 = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtY0 = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtX0 = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.picCanvas = new System.Windows.Forms.PictureBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picCanvas)).BeginInit();
            this.SuspendLayout();
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(266, 78);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 9;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Foreground";
            // 
            // lblForeColor
            // 
            this.lblForeColor.BackColor = System.Drawing.Color.Blue;
            this.lblForeColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblForeColor.Location = new System.Drawing.Point(81, 25);
            this.lblForeColor.Name = "lblForeColor";
            this.lblForeColor.Size = new System.Drawing.Size(20, 20);
            this.lblForeColor.TabIndex = 3;
            this.lblForeColor.Click += new System.EventHandler(this.ColorSample_Click);
            // 
            // lblBackColor
            // 
            this.lblBackColor.BackColor = System.Drawing.Color.Black;
            this.lblBackColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblBackColor.Location = new System.Drawing.Point(81, 51);
            this.lblBackColor.Name = "lblBackColor";
            this.lblBackColor.Size = new System.Drawing.Size(20, 20);
            this.lblBackColor.TabIndex = 5;
            this.lblBackColor.Click += new System.EventHandler(this.ColorSample_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 52);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Background";
            // 
            // cboPlane
            // 
            this.cboPlane.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPlane.FormattingEnabled = true;
            this.cboPlane.Items.AddRange(new object[] {
            "XY",
            "YZ",
            "XZ"});
            this.cboPlane.Location = new System.Drawing.Point(81, 75);
            this.cboPlane.Name = "cboPlane";
            this.cboPlane.Size = new System.Drawing.Size(41, 21);
            this.cboPlane.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Plane";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.txtZ0);
            this.groupBox1.Controls.Add(this.btnStart);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.txtY0);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.txtX0);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.txtE);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.txtD);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.txtC);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtB);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtA);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.lblForeColor);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cboPlane);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.lblBackColor);
            this.groupBox1.Location = new System.Drawing.Point(12, 9);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(506, 110);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Parameters";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(162, 26);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(14, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "A";
            // 
            // txtA
            // 
            this.txtA.Location = new System.Drawing.Point(182, 23);
            this.txtA.Name = "txtA";
            this.txtA.Size = new System.Drawing.Size(33, 20);
            this.txtA.TabIndex = 1;
            this.txtA.Text = "2.0";
            this.txtA.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtB
            // 
            this.txtB.Location = new System.Drawing.Point(252, 23);
            this.txtB.Name = "txtB";
            this.txtB.Size = new System.Drawing.Size(33, 20);
            this.txtB.TabIndex = 2;
            this.txtB.Text = "0.5";
            this.txtB.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(232, 26);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(14, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "B";
            // 
            // txtC
            // 
            this.txtC.Location = new System.Drawing.Point(322, 23);
            this.txtC.Name = "txtC";
            this.txtC.Size = new System.Drawing.Size(33, 20);
            this.txtC.TabIndex = 3;
            this.txtC.Text = "-0.6";
            this.txtC.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(301, 26);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(14, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "C";
            // 
            // txtD
            // 
            this.txtD.Location = new System.Drawing.Point(392, 23);
            this.txtD.Name = "txtD";
            this.txtD.Size = new System.Drawing.Size(33, 20);
            this.txtD.TabIndex = 4;
            this.txtD.Text = "-2.5";
            this.txtD.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(371, 26);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(15, 13);
            this.label7.TabIndex = 15;
            this.label7.Text = "D";
            // 
            // txtE
            // 
            this.txtE.Location = new System.Drawing.Point(462, 23);
            this.txtE.Name = "txtE";
            this.txtE.Size = new System.Drawing.Size(33, 20);
            this.txtE.TabIndex = 5;
            this.txtE.Text = "1.0";
            this.txtE.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(441, 26);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(14, 13);
            this.label8.TabIndex = 17;
            this.label8.Text = "E";
            // 
            // txtZ0
            // 
            this.txtZ0.Location = new System.Drawing.Point(322, 49);
            this.txtZ0.Name = "txtZ0";
            this.txtZ0.Size = new System.Drawing.Size(33, 20);
            this.txtZ0.TabIndex = 8;
            this.txtZ0.Text = "0";
            this.txtZ0.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(301, 52);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(20, 13);
            this.label9.TabIndex = 24;
            this.label9.Text = "Z0";
            // 
            // txtY0
            // 
            this.txtY0.Location = new System.Drawing.Point(252, 49);
            this.txtY0.Name = "txtY0";
            this.txtY0.Size = new System.Drawing.Size(33, 20);
            this.txtY0.TabIndex = 7;
            this.txtY0.Text = "0";
            this.txtY0.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(232, 52);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(20, 13);
            this.label10.TabIndex = 22;
            this.label10.Text = "Y0";
            // 
            // txtX0
            // 
            this.txtX0.Location = new System.Drawing.Point(182, 49);
            this.txtX0.Name = "txtX0";
            this.txtX0.Size = new System.Drawing.Size(33, 20);
            this.txtX0.TabIndex = 6;
            this.txtX0.Text = "0";
            this.txtX0.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(162, 52);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(20, 13);
            this.label11.TabIndex = 20;
            this.label11.Text = "X0";
            // 
            // picCanvas
            // 
            this.picCanvas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.picCanvas.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.picCanvas.Location = new System.Drawing.Point(12, 125);
            this.picCanvas.Name = "picCanvas";
            this.picCanvas.Size = new System.Drawing.Size(506, 506);
            this.picCanvas.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picCanvas.TabIndex = 9;
            this.picCanvas.TabStop = false;
            this.picCanvas.Resize += new System.EventHandler(this.picCanvas_Resize);
            // 
            // howto_pickover_attractor_Form1
            // 
            this.AcceptButton = this.btnStart;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(530, 643);
            this.Controls.Add(this.picCanvas);
            this.Controls.Add(this.groupBox1);
            this.Name = "howto_pickover_attractor_Form1";
            this.Text = "howto_pickover_attractor";
            this.Load += new System.EventHandler(this.howto_pickover_attractor_Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picCanvas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblForeColor;
        private System.Windows.Forms.Label lblBackColor;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboPlane;
        private System.Windows.Forms.ColorDialog cdColor;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtE;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtD;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtC;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtB;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtA;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtZ0;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtY0;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtX0;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.PictureBox picCanvas;
    }
}

