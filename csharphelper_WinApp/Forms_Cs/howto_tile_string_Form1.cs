using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Drawing.Imaging;

 

namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_tile_string_Form1:Form
  { 


        public howto_tile_string_Form1()
        {
            InitializeComponent();
        }

        private void howto_tile_string_Form1_Load(object sender, EventArgs e)
        {
            ShowFont();
            DrawText();
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            DrawText();
        }

        private void ShowFont()
        {
            lblFont.Text =
                fdFont.Font.Size.ToString() + " pt " +
                fdFont.Font.Name;
        }

        private void DrawText()
        {
            int width = int.Parse(txtWidth.Text);
            int height = int.Parse(txtHeight.Text);

            Bitmap bm = new Bitmap(width, height);
            using (Graphics gr = Graphics.FromImage(bm))
            {
                gr.Clear(picBackground.BackColor);

                using (Brush brush = new SolidBrush(picForeground.BackColor))
                {
                    string text = txtString.Text;
                    SizeF size = gr.MeasureString(text, fdFont.Font);
                    for (float y = 0; y < bm.Height; y += size.Height * 0.8f)
                    {
                        float x = y;
                        while (x > 0) x -= size.Width;

                        while (x <= bm.Width)
                        {
                            gr.DrawString(text, fdFont.Font, brush, x, y);
                            x += size.Width;
                        }
                    }
                }

                bm.Save("Result.png", ImageFormat.Png);
                picImage.Image = bm;
            }
        }

        private void picBackground_Click(object sender, EventArgs e)
        {
            cdColor.Color = picBackground.BackColor;
            if (cdColor.ShowDialog() == DialogResult.OK)
                picBackground.BackColor = cdColor.Color;
        }

        private void picForeground_Click(object sender, EventArgs e)
        {
            cdColor.Color = picForeground.BackColor;
            if (cdColor.ShowDialog() == DialogResult.OK)
                picForeground.BackColor = cdColor.Color;
        }

        private void lblFont_Click(object sender, EventArgs e)
        {
            if (fdFont.ShowDialog() == DialogResult.OK)
                ShowFont();
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
            this.picImage = new System.Windows.Forms.PictureBox();
            this.fdFont = new System.Windows.Forms.FontDialog();
            this.label1 = new System.Windows.Forms.Label();
            this.lblFont = new System.Windows.Forms.Label();
            this.btnGo = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtWidth = new System.Windows.Forms.TextBox();
            this.txtHeight = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.picBackground = new System.Windows.Forms.PictureBox();
            this.picForeground = new System.Windows.Forms.PictureBox();
            this.cdColor = new System.Windows.Forms.ColorDialog();
            this.label5 = new System.Windows.Forms.Label();
            this.txtString = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.picImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBackground)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picForeground)).BeginInit();
            this.SuspendLayout();
            // 
            // picImage
            // 
            this.picImage.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.picImage.Location = new System.Drawing.Point(12, 133);
            this.picImage.Name = "picImage";
            this.picImage.Size = new System.Drawing.Size(256, 128);
            this.picImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picImage.TabIndex = 0;
            this.picImage.TabStop = false;
            // 
            // fdFont
            // 
            this.fdFont.Font = new System.Drawing.Font("Segoe UI", 20F);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Font:";
            // 
            // lblFont
            // 
            this.lblFont.AutoSize = true;
            this.lblFont.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblFont.Location = new System.Drawing.Point(55, 17);
            this.lblFont.Name = "lblFont";
            this.lblFont.Padding = new System.Windows.Forms.Padding(4);
            this.lblFont.Size = new System.Drawing.Size(45, 23);
            this.lblFont.TabIndex = 0;
            this.lblFont.Text = "label2";
            this.lblFont.Click += new System.EventHandler(this.lblFont_Click);
            // 
            // btnGo
            // 
            this.btnGo.Location = new System.Drawing.Point(110, 104);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(75, 23);
            this.btnGo.TabIndex = 4;
            this.btnGo.Text = "Go";
            this.btnGo.UseVisualStyleBackColor = true;
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Size:";
            // 
            // txtWidth
            // 
            this.txtWidth.Location = new System.Drawing.Point(55, 46);
            this.txtWidth.Name = "txtWidth";
            this.txtWidth.Size = new System.Drawing.Size(32, 20);
            this.txtWidth.TabIndex = 1;
            this.txtWidth.Text = "256";
            this.txtWidth.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtHeight
            // 
            this.txtHeight.Location = new System.Drawing.Point(105, 46);
            this.txtHeight.Name = "txtHeight";
            this.txtHeight.Size = new System.Drawing.Size(32, 20);
            this.txtHeight.TabIndex = 2;
            this.txtHeight.Text = "256";
            this.txtHeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(90, 49);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(12, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "x";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(151, 49);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(39, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Colors:";
            // 
            // picBackground
            // 
            this.picBackground.BackColor = System.Drawing.Color.Black;
            this.picBackground.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.picBackground.Location = new System.Drawing.Point(196, 40);
            this.picBackground.Name = "picBackground";
            this.picBackground.Size = new System.Drawing.Size(32, 32);
            this.picBackground.TabIndex = 10;
            this.picBackground.TabStop = false;
            this.picBackground.Click += new System.EventHandler(this.picBackground_Click);
            // 
            // picForeground
            // 
            this.picForeground.BackColor = System.Drawing.Color.White;
            this.picForeground.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.picForeground.Location = new System.Drawing.Point(237, 40);
            this.picForeground.Name = "picForeground";
            this.picForeground.Size = new System.Drawing.Size(32, 32);
            this.picForeground.TabIndex = 11;
            this.picForeground.TabStop = false;
            this.picForeground.Click += new System.EventHandler(this.picForeground_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 81);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(31, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Text:";
            // 
            // txtString
            // 
            this.txtString.Location = new System.Drawing.Point(55, 78);
            this.txtString.Name = "txtString";
            this.txtString.Size = new System.Drawing.Size(213, 20);
            this.txtString.TabIndex = 3;
            this.txtString.Text = "Ray Tracing";
            // 
            // howto_tile_string_Form1
            // 
            this.AcceptButton = this.btnGo;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(281, 273);
            this.Controls.Add(this.txtString);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.picForeground);
            this.Controls.Add(this.picBackground);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtHeight);
            this.Controls.Add(this.txtWidth);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnGo);
            this.Controls.Add(this.lblFont);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.picImage);
            this.Name = "howto_tile_string_Form1";
            this.Text = "howto_tile_string";
            this.Load += new System.EventHandler(this.howto_tile_string_Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBackground)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picForeground)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picImage;
        private System.Windows.Forms.FontDialog fdFont;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblFont;
        private System.Windows.Forms.Button btnGo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtWidth;
        private System.Windows.Forms.TextBox txtHeight;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox picBackground;
        private System.Windows.Forms.PictureBox picForeground;
        private System.Windows.Forms.ColorDialog cdColor;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtString;
    }
}

