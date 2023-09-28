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
     public partial class howto_transparent_button_background_Form1:Form
  { 


        public howto_transparent_button_background_Form1()
        {
            InitializeComponent();
        }

        // Give the second button's image a transparent background.
        private void howto_transparent_button_background_Form1_Load(object sender, EventArgs e)
        {
            // Give three buttons transparent backgrounds.
            MakeButtonTransparent(btnTransparent1);
            MakeButtonTransparent(btnTransparent2);

            // Make the labels display only borders.
            lblRegular.Text = "";
            lblTransparent.Text = "";
            lblRegular.BackColor = Color.Transparent;
            lblTransparent.BackColor = Color.Transparent;

            // (Alternatively just hide them.)
            lblRegular.Visible = false;
            lblTransparent.Visible = false;
        }

        // Give the button a transparent background.
        private void MakeButtonTransparent(Button btn)
        {
            Bitmap bm = (Bitmap)btn.Image;
            bm.MakeTransparent(bm.GetPixel(0, 0));
        }

        // Draw sideways text.
        private void howto_transparent_button_background_Form1_Paint(object sender, PaintEventArgs e)
        {
            using (StringFormat string_format = new StringFormat())
            {
                string_format.Alignment = StringAlignment.Center;
                string_format.LineAlignment = StringAlignment.Center;

                e.Graphics.TextRenderingHint =
                    System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;
                DrawSidewaysText(e.Graphics, Font, Brushes.Black,
                    lblRegular.Bounds, string_format, "Regular");
                DrawSidewaysText(e.Graphics, Font, Brushes.Black,
                    lblTransparent.Bounds, string_format, "Transparent");
            }
        }

        // Draw sideways text in the indicated rectangle.
        private void DrawSidewaysText(Graphics gr, Font font, Brush brush, Rectangle bounds, StringFormat string_format, string txt)
        {
            // Make a rotated rectangle at the origin.
            Rectangle rotated_bounds = new Rectangle(
                0, 0, bounds.Height, bounds.Width);

            // Rotate.
            gr.ResetTransform();
            gr.RotateTransform(-90);

            // Translate to move the rectangle to the correct position.
            gr.TranslateTransform(bounds.Left, bounds.Bottom, System.Drawing.Drawing2D.MatrixOrder.Append);

            // Draw the text.
            gr.DrawString(txt, font, brush, rotated_bounds, string_format);
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(howto_transparent_button_background_Form1));
            this.lblTransparent = new System.Windows.Forms.Label();
            this.lblRegular = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnRegular2 = new System.Windows.Forms.Button();
            this.btnTransparent2 = new System.Windows.Forms.Button();
            this.btnTransparent1 = new System.Windows.Forms.Button();
            this.btnRegular1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblTransparent
            // 
            this.lblTransparent.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTransparent.Location = new System.Drawing.Point(42, 133);
            this.lblTransparent.Name = "lblTransparent";
            this.lblTransparent.Size = new System.Drawing.Size(22, 77);
            this.lblTransparent.TabIndex = 21;
            this.lblTransparent.Text = "Transparent";
            // 
            // lblRegular
            // 
            this.lblRegular.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblRegular.Location = new System.Drawing.Point(42, 38);
            this.lblRegular.Name = "lblRegular";
            this.lblRegular.Size = new System.Drawing.Size(22, 77);
            this.lblRegular.TabIndex = 20;
            this.lblRegular.Text = "Regular";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(70, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(128, 23);
            this.label1.TabIndex = 18;
            this.label1.Text = "Normal";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(220, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(128, 23);
            this.label2.TabIndex = 14;
            this.label2.Text = "Mouse Over";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnRegular2
            // 
            this.btnRegular2.Image = ((System.Drawing.Image)(resources.GetObject("btnRegular2.Image")));
            this.btnRegular2.Location = new System.Drawing.Point(223, 38);
            this.btnRegular2.Name = "btnRegular2";
            this.btnRegular2.Size = new System.Drawing.Size(125, 77);
            this.btnRegular2.TabIndex = 12;
            this.btnRegular2.UseVisualStyleBackColor = true;
            // 
            // btnTransparent2
            // 
            this.btnTransparent2.Image = ((System.Drawing.Image)(resources.GetObject("btnTransparent2.Image")));
            this.btnTransparent2.Location = new System.Drawing.Point(223, 133);
            this.btnTransparent2.Name = "btnTransparent2";
            this.btnTransparent2.Size = new System.Drawing.Size(125, 77);
            this.btnTransparent2.TabIndex = 16;
            this.btnTransparent2.UseVisualStyleBackColor = true;
            // 
            // btnTransparent1
            // 
            this.btnTransparent1.Image = ((System.Drawing.Image)(resources.GetObject("btnTransparent1.Image")));
            this.btnTransparent1.Location = new System.Drawing.Point(73, 133);
            this.btnTransparent1.Name = "btnTransparent1";
            this.btnTransparent1.Size = new System.Drawing.Size(125, 77);
            this.btnTransparent1.TabIndex = 15;
            this.btnTransparent1.UseVisualStyleBackColor = true;
            // 
            // btnRegular1
            // 
            this.btnRegular1.Image = ((System.Drawing.Image)(resources.GetObject("btnRegular1.Image")));
            this.btnRegular1.Location = new System.Drawing.Point(73, 38);
            this.btnRegular1.Name = "btnRegular1";
            this.btnRegular1.Size = new System.Drawing.Size(125, 77);
            this.btnRegular1.TabIndex = 11;
            this.btnRegular1.UseVisualStyleBackColor = true;
            // 
            // howto_transparent_button_background_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(390, 223);
            this.Controls.Add(this.lblTransparent);
            this.Controls.Add(this.lblRegular);
            this.Controls.Add(this.btnRegular2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnTransparent2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnTransparent1);
            this.Controls.Add(this.btnRegular1);
            this.Name = "howto_transparent_button_background_Form1";
            this.Text = "howto_transparent_button_background";
            this.Load += new System.EventHandler(this.howto_transparent_button_background_Form1_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.howto_transparent_button_background_Form1_Paint);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblTransparent;
        private System.Windows.Forms.Label lblRegular;
        private System.Windows.Forms.Button btnRegular2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnTransparent2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnTransparent1;
        private System.Windows.Forms.Button btnRegular1;
    }
}

