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
     public partial class howto_pickover_popcorn_Form1:Form
  { 


        public howto_pickover_popcorn_Form1()
        {
            InitializeComponent();
        }

        // The bitmap.
        private Bitmap Bm;

        // Parameters;
        private int IterationsPerPixel;
        private float H;

        // Make a bitmap of the appropriate size.
        private void howto_pickover_popcorn_Form1_Load(object sender, EventArgs e)
        {
            picCanvas.ClientSize = new Size((int)Dxmax, (int)Dymax);

            Bm = new Bitmap(picCanvas.ClientSize.Width, picCanvas.ClientSize.Height);
            picCanvas.Image = Bm;
        }

        // Plot a bunch of points.
        private void btnPlotAll_Click(object sender, EventArgs e)
        {
            GetParameters();

            // Make a new bitmap.
            Bm = new Bitmap(picCanvas.ClientSize.Width, picCanvas.ClientSize.Height);
            picCanvas.Image = Bm;

            // Plot a series for each point.
            int dx = int.Parse(txtDx.Text);
            for (int x = 0; x < Bm.Width; x += dx)
            {
                for (int y = 0; y < Bm.Height; y += dx)
                {
                    PlotPoints(Bm, H, x, y, IterationsPerPixel);
                }
                picCanvas.Refresh();
            }
            picCanvas.Refresh();
        }

        // Clear.
        private void btnClear_Click(object sender, EventArgs e)
        {
            // Make a new bitmap.
            Bm = new Bitmap(picCanvas.ClientSize.Width, picCanvas.ClientSize.Height);
            picCanvas.Image = Bm;
            picCanvas.Refresh();
        }

        // Plot points for the clicked pixel.
        private void picCanvas_MouseClick(object sender, MouseEventArgs e)
        {
            GetParameters();

            // Plot the point's series.
            PlotPoints(Bm, H, e.X, e.Y, IterationsPerPixel);
            picCanvas.Refresh();
        }

        // Get the parameters.
        private void GetParameters()
        {
            IterationsPerPixel = int.Parse(txtIterationsPerPixel.Text);
            H = float.Parse(txtH.Text);
        }

        // Plot points for a pixel using the equations:
        //      x(n + 1) = x(n) - h * Sin(y(n) + Tan(3 * y(n)))
        //      y(n + 1) = y(n) - h * Sin(x(n) + Tan(3 * x(n)))
        private void PlotPoints(Bitmap bm, float h, int pix_x, int pix_y, int iterations)
        {
            // Convert the first point to world coordinates.
            float wx, wy;
            DeviceToWorld(pix_x, pix_y, out wx, out wy);

            // Plot points.
            bm.SetPixel(pix_x, pix_y, Color.Blue);
            for (int i = 0; i < iterations; i++)
            {
                float new_x = (float)(wx - h * Math.Sin(wy + Math.Tan(3 * wy)));
                float new_y = (float)(wy - h * Math.Sin(wx + Math.Tan(3 * wx)));
                wx = new_x;
                wy = new_y;

                WorldToDevice(wx, wy, out pix_x, out pix_y);
                if (pix_x >= 0 && pix_x < bm.Width &&
                    pix_y >= 0 && pix_y < bm.Height)
                {
                    bm.SetPixel(pix_x, pix_y, Color.Red);
                }
            }
        }

        // Convert between world and device coordinates.
        private const float Wxmin = -4.0f;
        private const float Wxmax = 4.0f;
        private const float Wymin = -3.0f;
        private const float Wymax = 3.0f;
        private const float Wwid = (Wxmax - Wxmin);
        private const float Whgt = (Wymax - Wymin);
        private const float Dxmin = 0f;
        private const float Dxmax = 400f;
        private const float Dymin = 0f;
        private const float Dymax = 300f;
        private const float Dwid = (Dxmax - Dxmin);
        private const float Dhgt = (Dymax - Dymin);
        private void WorldToDevice(float wx, float wy, out int dx, out int dy)
        {
            dx = (int)(Dxmin + Dwid * (wx - Wxmin) / Wwid);
            dy = (int)(Dymin + Dhgt * (wy - Wymin) / Whgt);
        }
        private void DeviceToWorld(int dx, int dy, out float wx, out float wy)
        {
            wx = Wxmin + Wwid * (dx - Dxmin) / Dwid;
            wy = Wymin + Whgt * (dy - Dymin) / Dhgt;
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
            this.btnClear = new System.Windows.Forms.Button();
            this.txtDx = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtIterationsPerPixel = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnPlotAll = new System.Windows.Forms.Button();
            this.txtH = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.picCanvas = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picCanvas)).BeginInit();
            this.SuspendLayout();
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(349, 10);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(60, 23);
            this.btnClear.TabIndex = 16;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // txtDx
            // 
            this.txtDx.Location = new System.Drawing.Point(217, 12);
            this.txtDx.Name = "txtDx";
            this.txtDx.Size = new System.Drawing.Size(34, 20);
            this.txtDx.TabIndex = 12;
            this.txtDx.Text = "10";
            this.txtDx.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(190, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(21, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "dx:";
            // 
            // txtIterationsPerPixel
            // 
            this.txtIterationsPerPixel.Location = new System.Drawing.Point(141, 12);
            this.txtIterationsPerPixel.Name = "txtIterationsPerPixel";
            this.txtIterationsPerPixel.Size = new System.Drawing.Size(34, 20);
            this.txtIterationsPerPixel.TabIndex = 10;
            this.txtIterationsPerPixel.Text = "50";
            this.txtIterationsPerPixel.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(82, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "Iterations:";
            // 
            // btnPlotAll
            // 
            this.btnPlotAll.Location = new System.Drawing.Point(283, 10);
            this.btnPlotAll.Name = "btnPlotAll";
            this.btnPlotAll.Size = new System.Drawing.Size(60, 23);
            this.btnPlotAll.TabIndex = 13;
            this.btnPlotAll.Text = "Plot All";
            this.btnPlotAll.UseVisualStyleBackColor = true;
            this.btnPlotAll.Click += new System.EventHandler(this.btnPlotAll_Click);
            // 
            // txtH
            // 
            this.txtH.Location = new System.Drawing.Point(33, 12);
            this.txtH.Name = "txtH";
            this.txtH.Size = new System.Drawing.Size(34, 20);
            this.txtH.TabIndex = 8;
            this.txtH.Text = "0.05";
            this.txtH.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(16, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "h:";
            // 
            // picCanvas
            // 
            this.picCanvas.BackColor = System.Drawing.Color.Black;
            this.picCanvas.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.picCanvas.Cursor = System.Windows.Forms.Cursors.Default;
            this.picCanvas.Location = new System.Drawing.Point(11, 39);
            this.picCanvas.Name = "picCanvas";
            this.picCanvas.Size = new System.Drawing.Size(400, 300);
            this.picCanvas.TabIndex = 9;
            this.picCanvas.TabStop = false;
            this.picCanvas.MouseClick += new System.Windows.Forms.MouseEventHandler(this.picCanvas_MouseClick);
            // 
            // howto_pickover_popcorn_Form1
            // 
            this.AcceptButton = this.btnPlotAll;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(422, 349);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.txtDx);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtIterationsPerPixel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnPlotAll);
            this.Controls.Add(this.txtH);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.picCanvas);
            this.Name = "howto_pickover_popcorn_Form1";
            this.Text = "howto_pickover_popcorn";
            this.Load += new System.EventHandler(this.howto_pickover_popcorn_Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picCanvas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.TextBox txtDx;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtIterationsPerPixel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnPlotAll;
        private System.Windows.Forms.TextBox txtH;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox picCanvas;
    }
}

