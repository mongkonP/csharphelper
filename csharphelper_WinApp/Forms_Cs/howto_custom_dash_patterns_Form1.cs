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
     public partial class howto_custom_dash_patterns_Form1:Form
  { 


        public howto_custom_dash_patterns_Form1()
        {
            InitializeComponent();
        }

        private void howto_custom_dash_patterns_Form1_Load(object sender, EventArgs e)
        {
            ResizeRedraw = true;
        }

        private void howto_custom_dash_patterns_Form1_Paint(object sender, PaintEventArgs e)
        {
            int y = 20;
            int x1 = 65;
            int x2 = ClientSize.Width - 10;
            using (Pen dashed_pen = new Pen(Brushes.Red, 5))
            {
                dashed_pen.DashStyle = DashStyle.Custom;

                dashed_pen.DashPattern = new float[] { 3, 1 };
                e.Graphics.DrawString("3, 1", this.Font, Brushes.Black, 10, y - 8);
                e.Graphics.DrawLine(dashed_pen, x1, y, x2, y);
                y += 20;

                dashed_pen.DashPattern = new float[] { 5, 1, 5, 5 };
                e.Graphics.DrawString("5, 1, 5, 5", this.Font, Brushes.Black, 10, y - 8);
                e.Graphics.DrawLine(dashed_pen, x1, y, x2, y);
                y += 20;

                dashed_pen.DashPattern = new float[] { 5, 1 };
                e.Graphics.DrawString("5, 1", this.Font, Brushes.Black, 10, y - 8);
                e.Graphics.DrawLine(dashed_pen, x1, y, x2, y);
                y += 20;

                dashed_pen.DashPattern = new float[] { 1, 3 };
                e.Graphics.DrawString("1, 3", this.Font, Brushes.Black, 10, y - 8);
                e.Graphics.DrawLine(dashed_pen, x1, y, x2, y);
                y += 20;

                dashed_pen.DashPattern = new float[] { 3, 1, 1, 1 };
                e.Graphics.DrawString("3, 1, 1, 1", this.Font, Brushes.Black, 10, y - 8);
                e.Graphics.DrawLine(dashed_pen, x1, y, x2, y);
                y += 20;
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
            // howto_custom_dash_patterns_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(345, 119);
            this.Name = "howto_custom_dash_patterns_Form1";
            this.Text = "howto_custom_dash_patterns";
            this.Load += new System.EventHandler(this.howto_custom_dash_patterns_Form1_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.howto_custom_dash_patterns_Form1_Paint);
            this.ResumeLayout(false);

        }

        #endregion
    }
}

