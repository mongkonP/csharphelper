using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Drawing.Drawing2D;

 

using howto_draw_lines;
namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_draw_lines_Form1:Form
  { 


        public howto_draw_lines_Form1()
        {
            InitializeComponent();
        }

        private List<Segment> Segments = new List<Segment>();
        private Segment NewSegment = null;

        // Start drawing a new segment.
        private void picCanvas_MouseDown(object sender, MouseEventArgs e)
        {
            NewSegment = new Segment(Pens.Blue, e.Location, e.Location);
            picCanvas.Refresh();
        }

        // Continue drawing the new segment.
        private void picCanvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (NewSegment == null) return;
            
            NewSegment.Point2 = e.Location;
            picCanvas.Refresh();
        }

        // Finish drawing the new segment.
        private void picCanvas_MouseUp(object sender, MouseEventArgs e)
        {
            if (NewSegment == null) return;

            NewSegment.Pen = Pens.Black;
            Segments.Add(NewSegment);
            NewSegment = null;
            picCanvas.Refresh();
        }

        // Draw the segments.
        private void picCanvas_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(picCanvas.BackColor);
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            // Draw existing segments.
            foreach (Segment segment in Segments)
                segment.Draw(e.Graphics);

            // Draw the new segment if there is one.
            if (NewSegment != null)
                NewSegment.Draw(e.Graphics);
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
            this.picCanvas = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picCanvas)).BeginInit();
            this.SuspendLayout();
            // 
            // picCanvas
            // 
            this.picCanvas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.picCanvas.BackColor = System.Drawing.Color.White;
            this.picCanvas.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.picCanvas.Cursor = System.Windows.Forms.Cursors.Cross;
            this.picCanvas.Location = new System.Drawing.Point(12, 12);
            this.picCanvas.Name = "picCanvas";
            this.picCanvas.Size = new System.Drawing.Size(260, 237);
            this.picCanvas.TabIndex = 0;
            this.picCanvas.TabStop = false;
            this.picCanvas.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picCanvas_MouseMove);
            this.picCanvas.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picCanvas_MouseDown);
            this.picCanvas.Paint += new System.Windows.Forms.PaintEventHandler(this.picCanvas_Paint);
            this.picCanvas.MouseUp += new System.Windows.Forms.MouseEventHandler(this.picCanvas_MouseUp);
            // 
            // howto_draw_lines_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.picCanvas);
            this.Name = "howto_draw_lines_Form1";
            this.Text = "howto_draw_lines";
            ((System.ComponentModel.ISupportInitialize)(this.picCanvas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox picCanvas;
    }
}

