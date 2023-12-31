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
     public partial class howto_barnsley_fern_fractal_Form1:Form
  { 


        public howto_barnsley_fern_fractal_Form1()
        {
            InitializeComponent();
        }

        private float[] Prob = { 0.01f, 0.85f, 0.08f, 0.06f };
        private float[, ,] Func =
        {
            {
                {0, 0},
                {0, 0.16f},
            },
            {
                {0.85f, 0.04f},
                {-0.04f, 0.85f},
            },
            {
                {0.2f, -0.26f},
                {0.23f, 0.22f},
            },
            {
                {-0.15f, 0.28f},
                {0.26f, 0.24f},
            },
        };
        private float[,] Plus =
        {
            {0, 0},
            {0, 1.6f},
            {0, 1.6f},
            {0, 0.44f},
        };

        // Make the fern.
        private void howto_barnsley_fern_fractal_Form1_Load(object sender, EventArgs e)
        {
            MakeFern();
        }

        private void MakeFern()
        {
            int wid = picCanvas.ClientSize.Width;
            int hgt = picCanvas.ClientSize.Height;
            Bitmap bm = new Bitmap(wid, hgt);
            using (Graphics gr = Graphics.FromImage(bm))
            {
                gr.Clear(Color.Black);

                Random rnd = new Random();
                int func_num = 0, ix, iy;
                float x = 1, y = 1, x1, y1;
                for (int i = 1; i <= 100000; i++)
                {
                    double num = rnd.NextDouble();
                    for (int j = 0; j <= 3; j++)
                    {
                        num = num - Prob[j];
                        if (num <= 0)
                        {
                            func_num = j;
                            break;
                        }
                    }

                    x1 = x * Func[func_num, 0, 0] +
                         y * Func[func_num, 0, 1] +
                         Plus[func_num, 0];
                    y1 = x * Func[func_num, 1, 0] +
                         y * Func[func_num, 1, 1] +
                         Plus[func_num, 1];
                    x = x1;
                    y = y1;

                    const float w_xmin = -4;
                    const float w_xmax = 4;
                    const float w_ymin = -0.1f;
                    const float w_ymax = 10.1f;
                    const float w_wid = w_xmax - w_xmin;
                    const float w_hgt = w_ymax - w_ymin;
                    ix = (int)Math.Round((x - w_xmin) /
                        w_wid * picCanvas.ClientSize.Width);
                    iy = (int)Math.Round(
                        (picCanvas.ClientSize.Height - 1) - 
                        (y - w_ymin) / w_hgt * hgt);
                    if ((ix >= 0) && (iy >= 0) &&
                        (ix < wid) && (iy < hgt))
                    {
                        bm.SetPixel(ix, iy, Color.Lime);
                    }
                }
            }

            // Display the result.
            picCanvas.BackgroundImage = bm;
        }

        // Rebuild the fern for the new size.
        private void picCanvas_Resize(object sender, EventArgs e)
        {
            MakeFern();
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
            this.picCanvas = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picCanvas)).BeginInit();
            this.SuspendLayout();
            // 
            // picCanvas
            // 
            this.picCanvas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.picCanvas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picCanvas.Location = new System.Drawing.Point(0, 0);
            this.picCanvas.Name = "picCanvas";
            this.picCanvas.Size = new System.Drawing.Size(584, 514);
            this.picCanvas.TabIndex = 2;
            this.picCanvas.TabStop = false;
            this.picCanvas.Resize += new System.EventHandler(this.picCanvas_Resize);
            // 
            // howto_barnsley_fern_fractal_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 514);
            this.Controls.Add(this.picCanvas);
            this.Name = "howto_barnsley_fern_fractal_Form1";
            this.Text = "howto_barnsley_fern_fractal";
            this.Load += new System.EventHandler(this.howto_barnsley_fern_fractal_Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picCanvas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.PictureBox picCanvas;
    }
}

