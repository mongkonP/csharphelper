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
     public partial class howto_align_drawn_text_Form1:Form
  { 


        public howto_align_drawn_text_Form1()
        {
            InitializeComponent();
        }

        // Draw text aligned in various ways.
        private void howto_align_drawn_text_Form1_Paint(object sender, PaintEventArgs e)
        {
            Rectangle rect = new Rectangle(5, 5,
                ClientSize.Width - 10, ClientSize.Height - 10);
            e.Graphics.DrawRectangle(Pens.Red, rect);

            using (Font font = new Font("Times New Roman", 16, GraphicsUnit.Pixel))
            {
                using (StringFormat sf = new StringFormat())
                {
                    // Top.
                    sf.LineAlignment = StringAlignment.Near;    // Top.

                    // Top/Left.
                    sf.Alignment = StringAlignment.Near;        // Left.
                    e.Graphics.DrawString("Top/Left", font, Brushes.Black, rect, sf);

                    // Top/Center.
                    sf.Alignment = StringAlignment.Center;      // Center.
                    e.Graphics.DrawString("Top/Center", font, Brushes.Black, rect, sf);

                    // Top/Right.
                    sf.Alignment = StringAlignment.Far;         // Right.
                    e.Graphics.DrawString("Top/Right", font, Brushes.Black, rect, sf);

                    // Middle.
                    sf.LineAlignment = StringAlignment.Center;  // Middle.

                    // Middle/Left.
                    sf.Alignment = StringAlignment.Near;        // Left.
                    e.Graphics.DrawString("Middle/Left", font, Brushes.Black, rect, sf);

                    // Middle/Center.
                    sf.Alignment = StringAlignment.Center;      // Center.
                    e.Graphics.DrawString("Middle/Center", font, Brushes.Black, rect, sf);

                    // Middle/Right.
                    sf.Alignment = StringAlignment.Far;         // Right.
                    e.Graphics.DrawString("Middle/Right", font, Brushes.Black, rect, sf);

                    // Bottom.
                    sf.LineAlignment = StringAlignment.Far;     // Bottom.

                    // Bottom/Left.
                    sf.Alignment = StringAlignment.Near;        // Left.
                    e.Graphics.DrawString("Bottom/Left", font, Brushes.Black, rect, sf);

                    // Bottom/Center.
                    sf.Alignment = StringAlignment.Center;      // Center.
                    e.Graphics.DrawString("Bottom/Center", font, Brushes.Black, rect, sf);

                    // Bottom/Right.
                    sf.Alignment = StringAlignment.Far;         // Right.
                    e.Graphics.DrawString("Bottom/Right", font, Brushes.Black, rect, sf);
                }
            }
        }

        private void howto_align_drawn_text_Form1_Resize(object sender, EventArgs e)
        {
            Refresh();
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
            this.SuspendLayout();
            // 
            // howto_align_drawn_text_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 164);
            this.Name = "howto_align_drawn_text_Form1";
            this.Text = "howto_align_drawn_text";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.howto_align_drawn_text_Form1_Paint);
            this.Resize += new System.EventHandler(this.howto_align_drawn_text_Form1_Resize);
            this.ResumeLayout(false);

        }

        #endregion
    }
}

