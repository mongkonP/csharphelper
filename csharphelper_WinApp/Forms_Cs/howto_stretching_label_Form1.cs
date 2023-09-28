using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Drawing.Text;

 

namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_stretching_label_Form1:Form
  { 


        public howto_stretching_label_Form1()
        {
            InitializeComponent();
        }

        // The PictureBox's current size.
        private float StartWidth;
        private int StartHeight;
        private float EndWidth = 260;
        private float Dx, CurrentWidth;
        private int TicksToGo, TotalTicks;

        // Information about the string to draw.
        private const string LabelText = "C# Programming";
        private Font TextFont;
        private float[] CharacterWidths;
        private float TotalCharacterWidth;

        private void howto_stretching_label_Form1_Load(object sender, EventArgs e)
        {
            // Set the initial size.
            StartWidth = picTitle2.Size.Width;
            StartHeight = picTitle2.Size.Height;
            CurrentWidth = StartWidth;

            // Stretch for 2 seconds.
            TotalTicks = 2 * 1000 / tmrResizePictureBox.Interval;
            Dx = (EndWidth - StartWidth) / TotalTicks;

            // Make the font and measure the characters.
            CharacterWidths = new float[LabelText.Length];
            TextFont = new Font("Times New Roman", 16);
            using (Graphics gr = this.CreateGraphics())
            {
                for (int i = 0; i < LabelText.Length; i++)
                {
                    SizeF ch_size = gr.MeasureString(LabelText.Substring(i, 1), TextFont);
                    CharacterWidths[i] = ch_size.Width;
                }
            }
            TotalCharacterWidth = CharacterWidths.Sum();
        }

        // Resize the PictureBox.
        private void btnAnimate_Click(object sender, EventArgs e)
        {
            btnAnimate.Enabled = false;
            CurrentWidth = StartWidth;
            picTitle2.Size = new Size((int)StartWidth, picTitle2.Size.Height);
            picTitle2.Refresh();
            TicksToGo = TotalTicks;

            tmrResizePictureBox.Enabled = true;
        }

        // Resize the PictureBox.
        private void tmrResizePictureBox_Tick(object sender, EventArgs e)
        {
            CurrentWidth += Dx;
            picTitle2.Size = new Size((int)CurrentWidth, StartHeight);
            picTitle2.Refresh();

            // If we're done moving, disable the Timer.
            if (--TicksToGo <= 0)
            {
                tmrResizePictureBox.Enabled = false;
                btnAnimate.Enabled = true;
            }
        }

        // Draw the text on the control.
        private void picTitle2_Paint(object sender, PaintEventArgs e)
        {
            // Use AntiAlias for the best result.
            e.Graphics.TextRenderingHint = TextRenderingHint.AntiAlias;
            e.Graphics.Clear(picTitle2.BackColor);

            SpaceTextToFit(e.Graphics, picTitle2.ClientRectangle,
                TextFont, Brushes.Red, LabelText);
        }

        // Draw text inserting space between characters
        // to make it fill the indicated width.
        private void SpaceTextToFit(Graphics gr, Rectangle rect, Font font, Brush brush, string text)
        {
            using (StringFormat string_format = new StringFormat())
            {
                string_format.Alignment = StringAlignment.Near;
                string_format.LineAlignment = StringAlignment.Near;

                // Calculate the spacing.
                float space = (rect.Width - TotalCharacterWidth) / (text.Length - 1);

                // Draw the characters.
                PointF point = new PointF(rect.X, rect.Y);
                for (int i = 0; i < text.Length; i++)
                {
                    gr.DrawString(text[i].ToString(), font, brush, point);
                    point.X += CharacterWidths[i] + space;
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
            this.components = new System.ComponentModel.Container();
            this.picTitle2 = new System.Windows.Forms.PictureBox();
            this.btnAnimate = new System.Windows.Forms.Button();
            this.lblTitle4 = new System.Windows.Forms.Label();
            this.tmrResizePictureBox = new System.Windows.Forms.Timer(this.components);
            this.lblTitle3 = new System.Windows.Forms.Label();
            this.lblTitle1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picTitle2)).BeginInit();
            this.SuspendLayout();
            // 
            // picTitle2
            // 
            this.picTitle2.Location = new System.Drawing.Point(12, 47);
            this.picTitle2.Name = "picTitle2";
            this.picTitle2.Size = new System.Drawing.Size(171, 29);
            this.picTitle2.TabIndex = 15;
            this.picTitle2.TabStop = false;
            this.picTitle2.Paint += new System.Windows.Forms.PaintEventHandler(this.picTitle2_Paint);
            // 
            // btnAnimate
            // 
            this.btnAnimate.Location = new System.Drawing.Point(198, 22);
            this.btnAnimate.Name = "btnAnimate";
            this.btnAnimate.Size = new System.Drawing.Size(75, 23);
            this.btnAnimate.TabIndex = 14;
            this.btnAnimate.Text = "Animate";
            this.btnAnimate.UseVisualStyleBackColor = true;
            this.btnAnimate.Click += new System.EventHandler(this.btnAnimate_Click);
            // 
            // lblTitle4
            // 
            this.lblTitle4.AutoSize = true;
            this.lblTitle4.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle4.Location = new System.Drawing.Point(13, 97);
            this.lblTitle4.Name = "lblTitle4";
            this.lblTitle4.Size = new System.Drawing.Size(108, 16);
            this.lblTitle4.TabIndex = 13;
            this.lblTitle4.Text = "24-Hour Trainer";
            // 
            // tmrResizePictureBox
            // 
            this.tmrResizePictureBox.Interval = 10;
            this.tmrResizePictureBox.Tick += new System.EventHandler(this.tmrResizePictureBox_Tick);
            // 
            // lblTitle3
            // 
            this.lblTitle3.AutoSize = true;
            this.lblTitle3.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle3.ForeColor = System.Drawing.Color.Red;
            this.lblTitle3.Location = new System.Drawing.Point(13, 76);
            this.lblTitle3.Name = "lblTitle3";
            this.lblTitle3.Size = new System.Drawing.Size(186, 21);
            this.lblTitle3.TabIndex = 12;
            this.lblTitle3.Text = "with Visual Studio 2010";
            // 
            // lblTitle1
            // 
            this.lblTitle1.AutoSize = true;
            this.lblTitle1.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle1.ForeColor = System.Drawing.Color.Red;
            this.lblTitle1.Location = new System.Drawing.Point(13, 29);
            this.lblTitle1.Name = "lblTitle1";
            this.lblTitle1.Size = new System.Drawing.Size(60, 16);
            this.lblTitle1.TabIndex = 11;
            this.lblTitle1.Text = "Stephens\'";
            // 
            // howto_stretching_label_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 135);
            this.Controls.Add(this.picTitle2);
            this.Controls.Add(this.btnAnimate);
            this.Controls.Add(this.lblTitle4);
            this.Controls.Add(this.lblTitle3);
            this.Controls.Add(this.lblTitle1);
            this.Name = "howto_stretching_label_Form1";
            this.Text = "howto_stretching_label";
            this.Load += new System.EventHandler(this.howto_stretching_label_Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picTitle2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picTitle2;
        private System.Windows.Forms.Button btnAnimate;
        private System.Windows.Forms.Label lblTitle4;
        private System.Windows.Forms.Timer tmrResizePictureBox;
        private System.Windows.Forms.Label lblTitle3;
        private System.Windows.Forms.Label lblTitle1;
    }
}

