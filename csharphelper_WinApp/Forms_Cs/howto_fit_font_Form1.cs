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
     public partial class howto_fit_font_Form1:Form
  { 


        public howto_fit_font_Form1()
        {
            InitializeComponent();
        }

        private void howto_fit_font_Form1_Load(object sender, EventArgs e)
        {
            SizeLabelFont(lblHello1);
            SizeLabelFont(lblHello2);
            SizeLabelFont(lblHello3);
            SizeLabelFont(label1);
        }

        // Copy this text into the Label using the biggest font that will fit.
        private void SizeLabelFont(Label lbl)
        {
            // Only bother if there's text.
            string txt = lbl.Text;
            if (txt.Length > 0)
            {
                int best_size = 100;

                // See how much room we have, allowing a bit
                // for the Label's internal margin.
                int wid = lbl.DisplayRectangle.Width - 3;
                int hgt = lbl.DisplayRectangle.Height - 3;

                // Make a Graphics object to measure the text.
                using (Graphics gr = lbl.CreateGraphics())
                {
                    for (int i = 1; i <= 100; i++)
                    {
                        using (Font test_font = new Font(lbl.Font.FontFamily, i))
                        {
                            // See how much space the text would
                            // need, specifying a maximum width.
                            SizeF text_size = gr.MeasureString(txt, test_font);
                            if ((text_size.Width > wid) ||
                                (text_size.Height > hgt))
                            {
                                best_size = i - 1;
                                break;
                            }
                        }
                    }
                }

                // Use that font size.
                lbl.Font = new Font(lbl.Font.FontFamily, best_size);
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
            this.lblHello1 = new System.Windows.Forms.Label();
            this.lblHello2 = new System.Windows.Forms.Label();
            this.lblHello3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblHello1
            // 
            this.lblHello1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblHello1.Location = new System.Drawing.Point(12, 9);
            this.lblHello1.Name = "lblHello1";
            this.lblHello1.Size = new System.Drawing.Size(100, 23);
            this.lblHello1.TabIndex = 0;
            this.lblHello1.Text = "C# Helper";
            this.lblHello1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblHello2
            // 
            this.lblHello2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblHello2.Location = new System.Drawing.Point(134, 9);
            this.lblHello2.Name = "lblHello2";
            this.lblHello2.Size = new System.Drawing.Size(100, 38);
            this.lblHello2.TabIndex = 1;
            this.lblHello2.Text = "C# Helper";
            this.lblHello2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblHello3
            // 
            this.lblHello3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblHello3.Location = new System.Drawing.Point(12, 57);
            this.lblHello3.Name = "lblHello3";
            this.lblHello3.Size = new System.Drawing.Size(222, 58);
            this.lblHello3.TabIndex = 2;
            this.lblHello3.Text = "C# Helper";
            this.lblHello3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Location = new System.Drawing.Point(12, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 11);
            this.label1.TabIndex = 3;
            this.label1.Text = "C# Helper";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // howto_fit_font_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(248, 127);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblHello3);
            this.Controls.Add(this.lblHello2);
            this.Controls.Add(this.lblHello1);
            this.Name = "howto_fit_font_Form1";
            this.Text = "howto_fit_font";
            this.Load += new System.EventHandler(this.howto_fit_font_Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblHello1;
        private System.Windows.Forms.Label lblHello2;
        private System.Windows.Forms.Label lblHello3;
        private System.Windows.Forms.Label label1;
    }
}

