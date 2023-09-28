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
     public partial class howto_translucent_text_Form1:Form
  { 


        public howto_translucent_text_Form1()
        {
            InitializeComponent();
        }

        // Draw translucent text.
        private void howto_translucent_text_Form1_Load(object sender, EventArgs e)
        {
            Bitmap bm = new Bitmap(picSrc.Image);
            using (Graphics gr = Graphics.FromImage(bm))
            {
                using (StringFormat string_format = new StringFormat())
                {
                    string_format.Alignment = StringAlignment.Center;

                    int dy = (int)(gr.MeasureString("X", this.Font).Height * 1.2);
                    int x = bm.Width / 2;
                    int y = 20;

                    for (int opacity = 20; opacity <= 80; opacity += 10)
                    {
                        string txt = "OPACITY " + opacity.ToString();
                        using (Brush brush = new SolidBrush(Color.FromArgb(opacity, 0, 0, 0)))
                        {
                            gr.DrawString(txt, this.Font, brush, x, y, string_format);
                        }
                        using (Brush brush = new SolidBrush(Color.FromArgb(opacity, 255, 255, 255)))
                        {
                            gr.DrawString(txt, this.Font, brush, x - 2, y - 2, string_format);
                        }
                        y += dy;
                    }
                }

                picResult.Image = bm;
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
            this.picResult = new System.Windows.Forms.PictureBox();
            this.picSrc = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picResult)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picSrc)).BeginInit();
            this.SuspendLayout();
            // 
            // picResult
            // 
            this.picResult.Location = new System.Drawing.Point(287, 2);
            this.picResult.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.picResult.Name = "picResult";
            this.picResult.Size = new System.Drawing.Size(281, 285);
            this.picResult.TabIndex = 3;
            this.picResult.TabStop = false;
            // 
            // picSrc
            // 
            this.picSrc.Image = Properties.Resources.marble;
            this.picSrc.Location = new System.Drawing.Point(2, 2);
            this.picSrc.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.picSrc.Name = "picSrc";
            this.picSrc.Size = new System.Drawing.Size(281, 285);
            this.picSrc.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picSrc.TabIndex = 2;
            this.picSrc.TabStop = false;
            // 
            // howto_translucent_text_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 28F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(571, 289);
            this.Controls.Add(this.picResult);
            this.Controls.Add(this.picSrc);
            this.Font = new System.Drawing.Font("Arial Black", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.Name = "howto_translucent_text_Form1";
            this.Text = "howto_translucent_text";
            this.Load += new System.EventHandler(this.howto_translucent_text_Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picResult)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picSrc)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.PictureBox picResult;
        internal System.Windows.Forms.PictureBox picSrc;
    }
}

