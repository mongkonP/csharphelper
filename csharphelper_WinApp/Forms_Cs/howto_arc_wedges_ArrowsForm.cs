using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Drawing.Drawing2D;

 

using howto_arc_wedges;
namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_arc_wedges_ArrowsForm:Form
  { 


        public howto_arc_wedges_ArrowsForm()
        {
            InitializeComponent();
        }

        private void howto_arc_wedges_ArrowsForm_Paint(object sender, PaintEventArgs e)
        {
        }

        // Display some sample arrows.
        private void howto_arc_wedges_ArrowsForm_Load(object sender, EventArgs e)
        {
            const float margin = 20;
            int width = 250;
            int height = 150;
            float dy = (height - 4 * margin) / 3f;

            Bitmap bm = new Bitmap(width, height);
            using (Graphics gr = Graphics.FromImage(bm))
            {
                gr.SmoothingMode = SmoothingMode.AntiAlias;

                using (Pen pen = new Pen(Color.Red, 2))
                {
                    gr.SmoothingMode = SmoothingMode.AntiAlias;

                    // Draw sample arrows.
                    PointF p1 = new PointF(margin, margin);
                    PointF p2 = new PointF(width - margin, 3 * margin);
                    gr.DrawSegment(p1, p2, pen, pen, 10, 15, 1, 1,
                        Extensions.ArrowheadTypes.None, Brushes.Red, 10,
                        Extensions.ArrowheadTypes.None, Brushes.Red, 10);
                    pen.Color = Color.Black;
                    gr.DrawSegment(p1, p2, pen, pen, 10, 15, 1, 1,
                        Extensions.ArrowheadTypes.None, Brushes.Black, 10,
                        Extensions.ArrowheadTypes.None, Brushes.Black, 10);

                    p1.Y += dy;
                    p2.Y += dy;
                    pen.Color = Color.Green;
                    gr.DrawSegment(p1, p2, pen, pen, 10, 15, 1, 1,
                        Extensions.ArrowheadTypes.TriangleTail, Brushes.Red, 10,
                        Extensions.ArrowheadTypes.TriangleHead, Brushes.Red, 10);
                    pen.Color = Color.Black;
                    gr.DrawSegment(p1, p2, pen, pen, 10, 15, 1, 1,
                        Extensions.ArrowheadTypes.None, Brushes.Black, 10,
                        Extensions.ArrowheadTypes.None, Brushes.Black, 10);

                    p1.Y += dy;
                    p2.Y += dy;
                    pen.Color = Color.Blue;
                    gr.DrawSegment(p1, p2, pen, pen, 10, 15, 1, 1,
                        Extensions.ArrowheadTypes.VTail, Brushes.Green, 10,
                        Extensions.ArrowheadTypes.VHead, Brushes.Green, 10);
                    pen.Color = Color.Black;
                    gr.DrawSegment(p1, p2, pen, pen, 10, 15, 1, 1,
                        Extensions.ArrowheadTypes.None, Brushes.Black, 10,
                        Extensions.ArrowheadTypes.None, Brushes.Black, 10);

                    p1.Y += dy;
                    p2.Y += dy;
                    pen.Color = Color.Orange;
                    gr.DrawSegment(p1, p2, pen, pen, 10, 15, 1, 1,
                        Extensions.ArrowheadTypes.Broadtail, Brushes.Blue, 10,
                        Extensions.ArrowheadTypes.Broadhead, Brushes.Blue, 10);
                    pen.Color = Color.Black;
                    gr.DrawSegment(p1, p2, pen, pen, 10, 15, 1, 1,
                        Extensions.ArrowheadTypes.None, Brushes.Black, 10,
                        Extensions.ArrowheadTypes.None, Brushes.Black, 10);
                }
            }

            BackgroundImage = bm;
            ClientSize = bm.Size;
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
            // howto_arc_wedges_ArrowsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(260, 139);
            this.Name = "howto_arc_wedges_ArrowsForm";
            this.Text = "Arrows";
            this.Load += new System.EventHandler(this.howto_arc_wedges_ArrowsForm_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.howto_arc_wedges_ArrowsForm_Paint);
            this.ResumeLayout(false);

        }

        #endregion
    }
}