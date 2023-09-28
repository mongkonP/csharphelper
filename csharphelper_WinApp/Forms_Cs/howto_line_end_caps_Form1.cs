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
     public partial class howto_line_end_caps_Form1:Form
  { 


        public howto_line_end_caps_Form1()
        {
            InitializeComponent();
        }

        private void howto_line_end_caps_Form1_Load(object sender, EventArgs e)
        {
            ResizeRedraw = true;
        }

        private void howto_line_end_caps_Form1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(BackColor);
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            const int line_width = 10;
            int y = 10;
            int x1 = 110;
            int x2 = ClientSize.Width - 2 * line_width;
            using (Pen pen = new Pen(Color.Blue, line_width))
            {
                LineCap[] caps = (LineCap[])Enum.GetValues(typeof(LineCap));
                foreach (LineCap cap in caps)
                {
                    e.Graphics.DrawString(cap.ToString(),
                        Font, Brushes.Black, 10, y);
                    pen.StartCap = cap;
                    pen.EndCap = cap;
                    e.Graphics.DrawLine(pen, x1, y, x2, y);
                    y += 2 * line_width;
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
            this.SuspendLayout();
            // 
            // howto_line_end_caps_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 231);
            this.Name = "howto_line_end_caps_Form1";
            this.Text = "howto_line_end_caps";
            this.Load += new System.EventHandler(this.howto_line_end_caps_Form1_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.howto_line_end_caps_Form1_Paint);
            this.ResumeLayout(false);

        }

        #endregion
    }
}

