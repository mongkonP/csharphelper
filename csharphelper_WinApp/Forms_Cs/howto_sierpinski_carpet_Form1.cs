using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Drawing.Drawing2D;

 

namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_sierpinski_carpet_Form1:Form
  { 


        public howto_sierpinski_carpet_Form1()
        {
            InitializeComponent();
        }

        private int Level = 3;

        private void howto_sierpinski_carpet_Form1_Load(object sender, EventArgs e)
        {
            DrawGasket();
        }
        private void btnDraw_Click(object sender, EventArgs e)
        {
            DrawGasket();
        }
        private void howto_sierpinski_carpet_Form1_Resize(object sender, EventArgs e)
        {
            DrawGasket();
        }

        // Draw the carpet.
        private void DrawGasket()
        {
            Level = int.Parse(txtLevel.Text);

            Bitmap bm = new Bitmap(
                picGasket.ClientSize.Width,
                picGasket.ClientSize.Height);
            using (Graphics gr = Graphics.FromImage(bm))
            {
                gr.Clear(Color.White);
                gr.SmoothingMode = SmoothingMode.AntiAlias;

                // Draw the top-level carpet.
                const float margin = 10;
                RectangleF rect = new RectangleF(
                    margin, margin,
                    picGasket.ClientSize.Width - 2 * margin,
                    picGasket.ClientSize.Height - 2 * margin);
                DrawRectangle(gr, Level, rect);
            }

            // Display the result.
            picGasket.Image = bm;

            // Save the bitmap into a file.
            bm.Save("Carpet " + Level + ".bmp");
        }

        // Draw a carpet in the rectangle.
        private void DrawRectangle(Graphics gr, int level, RectangleF rect)
        {
            // See if we should stop.
            if (level == 0)
            {
                // Fill the rectangle.
                gr.FillRectangle(Brushes.Blue, rect);
            }
            else
            {
                // Divide the rectangle into 9 pieces.
                float wid = rect.Width / 3f;
                float x0 = rect.Left;
                float x1 = x0 + wid;
                float x2 = x0 + wid * 2f;

                float hgt = rect.Height / 3f;
                float y0 = rect.Top;
                float y1 = y0 + hgt;
                float y2 = y0 + hgt * 2f;

                // Recursively draw smaller carpets.
                DrawRectangle(gr, level - 1, new RectangleF(x0, y0, wid, hgt));
                DrawRectangle(gr, level - 1, new RectangleF(x1, y0, wid, hgt));
                DrawRectangle(gr, level - 1, new RectangleF(x2, y0, wid, hgt));
                DrawRectangle(gr, level - 1, new RectangleF(x0, y1, wid, hgt));
                DrawRectangle(gr, level - 1, new RectangleF(x2, y1, wid, hgt));
                DrawRectangle(gr, level - 1, new RectangleF(x0, y2, wid, hgt));
                DrawRectangle(gr, level - 1, new RectangleF(x1, y2, wid, hgt));
                DrawRectangle(gr, level - 1, new RectangleF(x2, y2, wid, hgt));
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
            this.picGasket = new System.Windows.Forms.PictureBox();
            this.btnDraw = new System.Windows.Forms.Button();
            this.txtLevel = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picGasket)).BeginInit();
            this.SuspendLayout();
            // 
            // picGasket
            // 
            this.picGasket.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.picGasket.BackColor = System.Drawing.Color.White;
            this.picGasket.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.picGasket.Location = new System.Drawing.Point(12, 41);
            this.picGasket.Name = "picGasket";
            this.picGasket.Size = new System.Drawing.Size(260, 260);
            this.picGasket.TabIndex = 7;
            this.picGasket.TabStop = false;
            // 
            // btnDraw
            // 
            this.btnDraw.Location = new System.Drawing.Point(91, 12);
            this.btnDraw.Name = "btnDraw";
            this.btnDraw.Size = new System.Drawing.Size(75, 23);
            this.btnDraw.TabIndex = 6;
            this.btnDraw.Text = "Draw";
            this.btnDraw.UseVisualStyleBackColor = true;
            this.btnDraw.Click += new System.EventHandler(this.btnDraw_Click);
            // 
            // txtLevel
            // 
            this.txtLevel.Location = new System.Drawing.Point(54, 14);
            this.txtLevel.Name = "txtLevel";
            this.txtLevel.Size = new System.Drawing.Size(31, 20);
            this.txtLevel.TabIndex = 5;
            this.txtLevel.Text = "4";
            this.txtLevel.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Level:";
            // 
            // howto_sierpinski_carpet_Form1
            // 
            this.AcceptButton = this.btnDraw;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 313);
            this.Controls.Add(this.picGasket);
            this.Controls.Add(this.btnDraw);
            this.Controls.Add(this.txtLevel);
            this.Controls.Add(this.label1);
            this.Name = "howto_sierpinski_carpet_Form1";
            this.Text = "howto_sierpinski_carpet";
            this.Load += new System.EventHandler(this.howto_sierpinski_carpet_Form1_Load);
            this.Resize += new System.EventHandler(this.howto_sierpinski_carpet_Form1_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.picGasket)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picGasket;
        private System.Windows.Forms.Button btnDraw;
        private System.Windows.Forms.TextBox txtLevel;
        private System.Windows.Forms.Label label1;
    }
}

