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
     public partial class howto_two_color_dashes_Form1:Form
  { 


        public howto_two_color_dashes_Form1()
        {
            InitializeComponent();
        }

        // Redraw on resize.
        private void howto_two_color_dashes_Form1_Load(object sender, EventArgs e)
        {
            ResizeRedraw = true;
        }

        // Fill four rectangles and draw a two-color dashed rectangle.
        private void howto_two_color_dashes_Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics gr = e.Graphics;

            // Fill the rectangles.
            int wid = ClientSize.Width / 2;
            int hgr = ClientSize.Height / 2;
            gr.FillRectangle(Brushes.Green, 0, 0, wid, hgr);
            gr.FillRectangle(Brushes.Orange, 0, hgr, wid, hgr);
            gr.FillRectangle(Brushes.Yellow, wid, 0, wid, hgr);
            gr.FillRectangle(Brushes.Blue, wid, hgr, wid, hgr);

            // Draw the dashed rectangle.
            Rectangle rect = new Rectangle(
                20, 20,
                ClientSize.Width - 40, ClientSize.Height - 40);
            using (Pen pen1 = new Pen(Color.Black, 2))
            {
                gr.DrawRectangle(pen1, rect);
            }
            using (Pen pen2 = new Pen(Color.White, 2))
            {
                pen2.DashPattern = new float[] { 5, 5 };
                gr.DrawRectangle(pen2, rect);
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
            // howto_two_color_dashes_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(334, 136);
            this.Name = "howto_two_color_dashes_Form1";
            this.Text = "howto_two_color_dashes";
            this.Load += new System.EventHandler(this.howto_two_color_dashes_Form1_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.howto_two_color_dashes_Form1_Paint);
            this.ResumeLayout(false);

        }

        #endregion
    }
}

