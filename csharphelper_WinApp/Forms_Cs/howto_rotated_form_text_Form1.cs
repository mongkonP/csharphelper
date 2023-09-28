using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Drawing.Text;
using System.Drawing.Drawing2D;

 

namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_rotated_form_text_Form1:Form
  { 


        public howto_rotated_form_text_Form1()
        {
            InitializeComponent();
        }

        // Hide the labels that position the rotated text.
        private void howto_rotated_form_text_Form1_Load(object sender, EventArgs e)
        {
            lblRotated1.Visible = false;
            lblRotated2.Visible = false;
            lblRotated3.Visible = false;
        }

        // Draw rotated text.
        private void howto_rotated_form_text_Form1_Paint(object sender, PaintEventArgs e)
        {
            using (StringFormat string_format = new StringFormat())
            {
                string_format.Alignment = StringAlignment.Center;
                string_format.LineAlignment = StringAlignment.Center;

                e.Graphics.TextRenderingHint =
                    TextRenderingHint.AntiAliasGridFit;
                DrawSidewaysText(e.Graphics, Font, Brushes.Black,
                    lblRotated1.Bounds, string_format, "Row 1");
                DrawSidewaysText(e.Graphics, Font, Brushes.Black,
                    lblRotated2.Bounds, string_format, "Row 2");
                DrawSidewaysText(e.Graphics, Font, Brushes.Black,
                    lblRotated3.Bounds, string_format, "Row 3");
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
            gr.TranslateTransform(bounds.Left, bounds.Bottom, MatrixOrder.Append);

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
            this.label4 = new System.Windows.Forms.Label();
            this.lblRotated3 = new System.Windows.Forms.Label();
            this.lblRotated2 = new System.Windows.Forms.Label();
            this.lblRotated1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(222, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "Column 4";
            // 
            // lblRotated3
            // 
            this.lblRotated3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblRotated3.Location = new System.Drawing.Point(12, 128);
            this.lblRotated3.Name = "lblRotated3";
            this.lblRotated3.Size = new System.Drawing.Size(22, 49);
            this.lblRotated3.TabIndex = 12;
            this.lblRotated3.Text = "Row 3";
            // 
            // lblRotated2
            // 
            this.lblRotated2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblRotated2.Location = new System.Drawing.Point(12, 79);
            this.lblRotated2.Name = "lblRotated2";
            this.lblRotated2.Size = new System.Drawing.Size(22, 49);
            this.lblRotated2.TabIndex = 11;
            this.lblRotated2.Text = "Row 2";
            // 
            // lblRotated1
            // 
            this.lblRotated1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblRotated1.Location = new System.Drawing.Point(12, 30);
            this.lblRotated1.Name = "lblRotated1";
            this.lblRotated1.Size = new System.Drawing.Size(22, 49);
            this.lblRotated1.TabIndex = 10;
            this.lblRotated1.Text = "Row 1";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(165, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Column 3";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(108, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Column 2";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(51, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Column 1";
            // 
            // howto_rotated_form_text_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(309, 201);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblRotated3);
            this.Controls.Add(this.lblRotated2);
            this.Controls.Add(this.lblRotated1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "howto_rotated_form_text_Form1";
            this.Text = "howto_rotated_form_text";
            this.Load += new System.EventHandler(this.howto_rotated_form_text_Form1_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.howto_rotated_form_text_Form1_Paint);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblRotated3;
        private System.Windows.Forms.Label lblRotated2;
        private System.Windows.Forms.Label lblRotated1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}

