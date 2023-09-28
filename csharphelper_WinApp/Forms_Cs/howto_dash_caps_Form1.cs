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
     public partial class howto_dash_caps_Form1:Form
  { 


        public howto_dash_caps_Form1()
        {
            InitializeComponent();
        }

        private void howto_dash_caps_Form1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            int y = 20;
            using (Pen dashed_pen = new Pen(Color.Green, 15))
            {
                dashed_pen.DashStyle = DashStyle.Dash;

                dashed_pen.DashCap = DashCap.Flat;
                e.Graphics.DrawString("Flat", this.Font, Brushes.Black, 10, y - 8);
                e.Graphics.DrawLine(dashed_pen, 100, y, 250, y);
                y += 20;

                dashed_pen.DashCap = DashCap.Round;
                e.Graphics.DrawString("Round", this.Font, Brushes.Black, 10, y - 8);
                e.Graphics.DrawLine(dashed_pen, 100, y, 250, y);
                y += 20;

                dashed_pen.DashCap = DashCap.Triangle;
                e.Graphics.DrawString("Triangle", this.Font, Brushes.Black, 10, y - 8);
                e.Graphics.DrawLine(dashed_pen, 100, y, 250, y);
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
            // howto_dash_caps_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 79);
            this.Name = "howto_dash_caps_Form1";
            this.Text = "howto_dash_caps";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.howto_dash_caps_Form1_Paint);
            this.ResumeLayout(false);

        }

        #endregion
    }
}

