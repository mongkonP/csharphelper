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
     public partial class howto_dashed_lines_Form1:Form
  { 


        public howto_dashed_lines_Form1()
        {
            InitializeComponent();
        }

        private void howto_dashed_lines_Form1_Paint(object sender, PaintEventArgs e)
        {
            int y = 20;
            using (Pen dashed_pen = new Pen(Color.Blue, 2))
            {
                for (int i = 0; i < 2; i++)
                {
                    dashed_pen.DashStyle = DashStyle.Dash;
                    e.Graphics.DrawString("Dash", this.Font, Brushes.Black, 10, y - 8);
                    e.Graphics.DrawLine(dashed_pen, 100, y, 250, y);
                    y += 20;

                    dashed_pen.DashStyle = DashStyle.DashDot;
                    e.Graphics.DrawString("DashDot", this.Font, Brushes.Black, 10, y - 8);
                    e.Graphics.DrawLine(dashed_pen, 100, y, 250, y);
                    y += 20;

                    dashed_pen.DashStyle = DashStyle.DashDotDot;
                    e.Graphics.DrawString("DashDotDot", this.Font, Brushes.Black, 10, y - 8);
                    e.Graphics.DrawLine(dashed_pen, 100, y, 250, y);
                    y += 20;

                    dashed_pen.DashStyle = DashStyle.Dot;
                    e.Graphics.DrawString("Dot", this.Font, Brushes.Black, 10, y - 8);
                    e.Graphics.DrawLine(dashed_pen, 100, y, 250, y);
                    y += 20;

                    y += 20;
                    dashed_pen.Width = 10;
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
            // howto_dashed_lines_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(269, 199);
            this.Name = "howto_dashed_lines_Form1";
            this.Text = "howto_dashed_lines";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.howto_dashed_lines_Form1_Paint);
            this.ResumeLayout(false);

        }

        #endregion
    }
}

