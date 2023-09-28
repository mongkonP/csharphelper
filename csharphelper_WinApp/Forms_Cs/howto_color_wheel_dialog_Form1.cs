using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Drawing.Drawing2D;
using System.Drawing.Text;

 

namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_color_wheel_dialog_Form1:Form
  { 


        public howto_color_wheel_dialog_Form1()
        {
            InitializeComponent();
        }

        // The selected colors.
        private Color Color1 = Color.FromArgb(128, 255, 0, 0);
        private Color Color2 = Color.FromArgb(128, 0, 0, 255);

        // Set color 1.
        private void btnColor1_Click(object sender, EventArgs e)
        {
            howto_color_wheel_dialog_ColorWheelDialog dlg = new  howto_color_wheel_dialog_ColorWheelDialog();
            dlg.SelectedColor = Color1;
            if (dlg.ShowDialog() == DialogResult.OK)
                Color1 = dlg.SelectedColor;

            picSample.Refresh();
        }

        // Set color 2.
        private void btnColor2_Click(object sender, EventArgs e)
        {
            howto_color_wheel_dialog_ColorWheelDialog dlg = new  howto_color_wheel_dialog_ColorWheelDialog();
            dlg.SelectedColor = Color2;
            if (dlg.ShowDialog() == DialogResult.OK)
                Color2 = dlg.SelectedColor;

            picSample.Refresh();
        }

        // Draw a sample to show the alpha component.
        private void picSample_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(Color.White);

            // Draw some lines.
            int wid = picSample.ClientSize.Width;
            int hgt = picSample.ClientSize.Height;
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            using (Pen pen = new Pen(Color.Black, 3))
            {
                for (int x = 10; x <= wid; x += 20)
                    e.Graphics.DrawLine(pen, x, 0, x, hgt);
                for (int y = 10; y <= hgt; y += 20)
                    e.Graphics.DrawLine(pen, 0, y, wid, y);
            }

            // Draw an ellipse.
            int third = picSample.ClientSize.Width / 3;
            using (Brush brush = new SolidBrush(Color1))
            {
                e.Graphics.FillEllipse(brush, 0, 0, 2 * third, hgt);
            }
            using (Brush brush = new SolidBrush(Color2))
            {
                e.Graphics.FillEllipse(brush, third, 0, 2 * third, hgt);
            }
        }

        private void picSample_Resize(object sender, EventArgs e)
        {
            picSample.Refresh();
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
            this.btnColor1 = new System.Windows.Forms.Button();
            this.btnColor2 = new System.Windows.Forms.Button();
            this.picSample = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picSample)).BeginInit();
            this.SuspendLayout();
            // 
            // btnColor1
            // 
            this.btnColor1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnColor1.ForeColor = System.Drawing.Color.Black;
            this.btnColor1.Location = new System.Drawing.Point(12, 30);
            this.btnColor1.Name = "btnColor1";
            this.btnColor1.Size = new System.Drawing.Size(91, 37);
            this.btnColor1.TabIndex = 0;
            this.btnColor1.Text = "Select Color 1";
            this.btnColor1.UseVisualStyleBackColor = true;
            this.btnColor1.Click += new System.EventHandler(this.btnColor1_Click);
            // 
            // btnColor2
            // 
            this.btnColor2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnColor2.ForeColor = System.Drawing.Color.Black;
            this.btnColor2.Location = new System.Drawing.Point(12, 73);
            this.btnColor2.Name = "btnColor2";
            this.btnColor2.Size = new System.Drawing.Size(91, 37);
            this.btnColor2.TabIndex = 1;
            this.btnColor2.Text = "Select Color 2";
            this.btnColor2.UseVisualStyleBackColor = true;
            this.btnColor2.Click += new System.EventHandler(this.btnColor2_Click);
            // 
            // picSample
            // 
            this.picSample.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.picSample.Location = new System.Drawing.Point(109, 12);
            this.picSample.Name = "picSample";
            this.picSample.Size = new System.Drawing.Size(183, 116);
            this.picSample.TabIndex = 2;
            this.picSample.TabStop = false;
            this.picSample.Resize += new System.EventHandler(this.picSample_Resize);
            this.picSample.Paint += new System.Windows.Forms.PaintEventHandler(this.picSample_Paint);
            // 
            // howto_color_wheel_dialog_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(304, 141);
            this.Controls.Add(this.picSample);
            this.Controls.Add(this.btnColor2);
            this.Controls.Add(this.btnColor1);
            this.Name = "howto_color_wheel_dialog_Form1";
            this.Text = "howto_color_wheel_dialog";
            ((System.ComponentModel.ISupportInitialize)(this.picSample)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnColor1;
        private System.Windows.Forms.Button btnColor2;
        private System.Windows.Forms.PictureBox picSample;
    }
}

