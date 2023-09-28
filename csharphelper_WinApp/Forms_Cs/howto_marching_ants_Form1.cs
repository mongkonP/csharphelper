using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

 

using howto_marching_ants;
namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_marching_ants_Form1:Form
  { 


        public howto_marching_ants_Form1()
        {
            InitializeComponent();
        }

        // Previously selected rectangles.
        private List<Rectangle> Rectangles = new List<Rectangle>();

        // The rectangle we are selecting.
        private Rectangle NewRectangle;

        // Variables used to select a new rectangle.
        private int StartX, StartY, EndX, EndY;
        private bool SelectingRectangle = false;

        // Start selecting a rectangle.
        private void picCanvas_MouseDown(object sender, MouseEventArgs e)
        {
            // Save the current point.
            StartX = e.X;
            StartY = e.Y;
            EndX = e.X;
            EndY = e.Y;

            // Make a new selection rectangle.
            NewRectangle = new Rectangle(
                Math.Min(StartX, EndX),
                Math.Min(StartY, EndY),
                Math.Abs(StartX - EndX),
                Math.Abs(StartY - EndY));

            // Start marching.
            SelectingRectangle = true;
            tmrMarch.Enabled = true;
        }

        // Continue selecting a rectangle.
        private void picCanvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (!SelectingRectangle) return;

            // Save the current point.
            EndX = e.X;
            EndY = e.Y;

            // Make a new selection rectangle.
            NewRectangle = new Rectangle(
                Math.Min(StartX, EndX),
                Math.Min(StartY, EndY),
                Math.Abs(StartX - EndX),
                Math.Abs(StartY - EndY));

            // Redraw.
            Refresh();
        }

        // Finish selecting a rectangle.
        private void picCanvas_MouseUp(object sender, MouseEventArgs e)
        {
            if (!SelectingRectangle) return;
            SelectingRectangle = false;
            tmrMarch.Enabled = false;
            if ((StartX == EndX) || (StartY == EndY)) return;

            // Save the newly selected rectangle.
            Rectangles.Add(new Rectangle(
                Math.Min(StartX, EndX),
                Math.Min(StartY, EndY),
                Math.Abs(StartX - EndX),
                Math.Abs(StartY - EndY)));

            // Redraw.
            Refresh();
        }

        // Parameters for drawing the dashed rectangle.
        private float Offset = 0;
        private float OffsetDelta = 2;
        private float[] DashPattern = { 5, 5 };

        // Draw the rectangles.
        private void picCanvas_Paint(object sender, PaintEventArgs e)
        {
            Offset += OffsetDelta;

            // Draw previously selected rectangles.
            for (int i = 0; i < Rectangles.Count; i++)
            {
                e.Graphics.FillRectangle(
                    RectangleBrushes[i % RectangleBrushes.Length],
                    Rectangles[i]);
                e.Graphics.DrawRectangle(Pens.Black, Rectangles[i]);
            }

            // Draw the new rectangle.
            if (SelectingRectangle)
            {
                e.Graphics.DrawRectangle(NewRectangle, Color.Yellow,
                    Color.Red, 2f, Offset, DashPattern);
            }
        }

        // Redraw.
        private void tmrMarch_Tick(object sender, EventArgs e)
        {
            Refresh();
        }

        // The rectangles' colors.
        private Brush[] RectangleBrushes =
        {
            Brushes.Red,
            Brushes.Green,
            Brushes.Blue,
            Brushes.Lime,
            Brushes.Orange,
            Brushes.Fuchsia,
            Brushes.Yellow,
            Brushes.LightGreen,
            Brushes.LightBlue,
            Brushes.Cyan,
        };
    

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
            this.components = new System.ComponentModel.Container();
            this.picCanvas = new System.Windows.Forms.PictureBox();
            this.tmrMarch = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.picCanvas)).BeginInit();
            this.SuspendLayout();
            // 
            // picCanvas
            // 
            this.picCanvas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.picCanvas.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.picCanvas.Cursor = System.Windows.Forms.Cursors.Cross;
            this.picCanvas.Location = new System.Drawing.Point(4, 4);
            this.picCanvas.Name = "picCanvas";
            this.picCanvas.Size = new System.Drawing.Size(326, 153);
            this.picCanvas.TabIndex = 1;
            this.picCanvas.TabStop = false;
            this.picCanvas.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picCanvas_MouseMove);
            this.picCanvas.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picCanvas_MouseDown);
            this.picCanvas.Paint += new System.Windows.Forms.PaintEventHandler(this.picCanvas_Paint);
            this.picCanvas.MouseUp += new System.Windows.Forms.MouseEventHandler(this.picCanvas_MouseUp);
            // 
            // tmrMarch
            // 
            this.tmrMarch.Interval = 250;
            this.tmrMarch.Tick += new System.EventHandler(this.tmrMarch_Tick);
            // 
            // howto_marching_ants_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(334, 161);
            this.Controls.Add(this.picCanvas);
            this.Name = "howto_marching_ants_Form1";
            this.Text = "howto_marching_ants";
            ((System.ComponentModel.ISupportInitialize)(this.picCanvas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox picCanvas;
        private System.Windows.Forms.Timer tmrMarch;
    }
}

