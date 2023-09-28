using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Drawing.Text;

 

using howto_outline_graphics;
namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_outline_graphics_Form1:Form
  { 


        public howto_outline_graphics_Form1()
        {
            InitializeComponent();
        }

        // Create some sample text.
        private void howto_outline_graphics_Form1_Load(object sender, EventArgs e)
        {
            picGraphics.Image = Properties.Resources.Image;
            picGraphics.Refresh();
        }

        // Draw an outline.
        private void btnGo_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            picGraphics.Image = Properties.Resources.Image;
            picGraphics.Refresh();

            // Get the parameters.
            int min_radius = int.Parse(txtMinRadius.Text);
            int max_radius = int.Parse(txtMaxRadius.Text);

            // Get the outline image.
            Bitmap outline_bm = MakeOutline(Properties.Resources.Mask,
                min_radius, max_radius);
            
            // Combine the original image with the outline.
            Bitmap new_bm = (Bitmap)Properties.Resources.Image.Clone();
            using (Graphics gr = Graphics.FromImage(new_bm))
            {
                Rectangle rect = new Rectangle(0, 0, new_bm.Width, new_bm.Height);
                gr.DrawImageUnscaledAndClipped(outline_bm, rect);
            }

            picGraphics.Image = new_bm;
            picGraphics.Refresh();

            Cursor = Cursors.Default;
        }

        // Make an outline image.
        private Bitmap MakeOutline(Bitmap mask, int min_radius, int max_radius)
        {
            Bitmap32 mask_bm32 = new Bitmap32(mask);
            mask_bm32.LockBitmap();

            // Make the result bitmap.
            Bitmap new_bm = new Bitmap(mask.Width, mask.Height);
            using (Graphics gr = Graphics.FromImage(new_bm))
            {
                gr.Clear(Color.Transparent);
            }
            Bitmap32 new_bm32 = new Bitmap32(new_bm);
            new_bm32.LockBitmap();

            for (int x = 0; x < mask_bm32.Width; x++)
            {
                for (int y = 0; y < mask_bm32.Height; y++)
                {
                    float dist = DistToNonWhite(mask_bm32, x, y, max_radius);
                    if ((dist > min_radius) && (dist < max_radius))
                    {
                        byte alpha = 255;
                        if (dist - min_radius < 1)
                            alpha = (byte)(255 * (dist - min_radius));
                        else if (max_radius - dist < 1)
                            alpha = (byte)(255 * (max_radius - dist));

                        new_bm32.SetPixel(x, y, 255, 0, 0, alpha);
                    }
                }
            }

            mask_bm32.UnlockBitmap();
            new_bm32.UnlockBitmap();
            return new_bm;
        }

        // Return the distance to the nearest non-white pixel within the radius.
        private float DistToNonWhite(Bitmap32 bm32, int x, int y, int radius)
        {
            int minx = Math.Max(x - radius, 0);
            int maxx = Math.Min(x + radius, bm32.Width - 1);
            int miny = Math.Max(y - radius, 0);
            int maxy = Math.Min(y + radius, bm32.Height - 1);
            int dist2 = radius * radius + 1;

            for (int tx = minx; tx < maxx; tx++)
            {
                for (int ty = miny; ty <= maxy; ty++)
                {
                    byte r, g, b, a;
                    bm32.GetPixel(tx, ty, out r, out g, out b, out a);

                    if ((r < 200) || (g < 200) || (b < 200))
                    {
                        int dx = tx - x;
                        int dy = ty - y;
                        int test_dist2 = dx * dx + dy * dy;
                        if (test_dist2 < dist2) dist2 = test_dist2;
                    }
                }
            }

            return (float)Math.Sqrt(dist2);
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
            this.picGraphics = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtMinRadius = new System.Windows.Forms.TextBox();
            this.btnGo = new System.Windows.Forms.Button();
            this.txtMaxRadius = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picGraphics)).BeginInit();
            this.SuspendLayout();
            // 
            // picGraphics
            // 
            this.picGraphics.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.picGraphics.BackColor = System.Drawing.Color.White;
            this.picGraphics.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.picGraphics.Location = new System.Drawing.Point(12, 66);
            this.picGraphics.Name = "picGraphics";
            this.picGraphics.Size = new System.Drawing.Size(285, 121);
            this.picGraphics.TabIndex = 0;
            this.picGraphics.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Min Radius:";
            // 
            // txtMinRadius
            // 
            this.txtMinRadius.Location = new System.Drawing.Point(84, 14);
            this.txtMinRadius.Name = "txtMinRadius";
            this.txtMinRadius.Size = new System.Drawing.Size(61, 20);
            this.txtMinRadius.TabIndex = 0;
            this.txtMinRadius.Text = "5";
            this.txtMinRadius.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnGo
            // 
            this.btnGo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGo.Location = new System.Drawing.Point(223, 12);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(75, 23);
            this.btnGo.TabIndex = 2;
            this.btnGo.Text = "Go";
            this.btnGo.UseVisualStyleBackColor = true;
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // txtMaxRadius
            // 
            this.txtMaxRadius.Location = new System.Drawing.Point(84, 40);
            this.txtMaxRadius.Name = "txtMaxRadius";
            this.txtMaxRadius.Size = new System.Drawing.Size(61, 20);
            this.txtMaxRadius.TabIndex = 1;
            this.txtMaxRadius.Text = "10";
            this.txtMaxRadius.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Max Radius:";
            // 
            // howto_outline_graphics_Form1
            // 
            this.AcceptButton = this.btnGo;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(309, 199);
            this.Controls.Add(this.txtMaxRadius);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnGo);
            this.Controls.Add(this.txtMinRadius);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.picGraphics);
            this.Name = "howto_outline_graphics_Form1";
            this.Text = "howto_outline_graphics";
            this.Load += new System.EventHandler(this.howto_outline_graphics_Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picGraphics)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picGraphics;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtMinRadius;
        private System.Windows.Forms.Button btnGo;
        private System.Windows.Forms.TextBox txtMaxRadius;
        private System.Windows.Forms.Label label2;
    }
}

