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
     public partial class howto_hollow_text_Form1:Form
  { 


        public howto_hollow_text_Form1()
        {
            InitializeComponent();
        }

        // Redraw on resize.
        private void howto_hollow_text_Form1_Load(object sender, EventArgs e)
        {
            this.ResizeRedraw = true;
        }

        private void howto_hollow_text_Form1_Paint(object sender, PaintEventArgs e)
        {
            // Make things smoother.
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            // Create the text path.
            GraphicsPath path = new GraphicsPath(FillMode.Alternate);

            // Draw text using a StringFormat to center it on the form.
            using (FontFamily font_family = new FontFamily("Times New Roman"))
            {
                using (StringFormat sf = new StringFormat())
                {
                    sf.Alignment = StringAlignment.Center;
                    sf.LineAlignment = StringAlignment.Center;
                    path.AddString("Hollow Text", font_family,
                        (int)FontStyle.Bold, 100,
                        this.ClientRectangle, sf);
                }
            }

            // Fill and draw the path.
            e.Graphics.FillPath(Brushes.Blue, path);
            using (Pen pen = new Pen(Color.Black, 3))
            {
                e.Graphics.DrawPath(pen, path);
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
            this.SuspendLayout();
            // 
            // howto_hollow_text_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(606, 172);
            this.Name = "howto_hollow_text_Form1";
            this.Text = "howto_hollow_text";
            this.Load += new System.EventHandler(this.howto_hollow_text_Form1_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.howto_hollow_text_Form1_Paint);
            this.ResumeLayout(false);

        }

        #endregion
    }
}

