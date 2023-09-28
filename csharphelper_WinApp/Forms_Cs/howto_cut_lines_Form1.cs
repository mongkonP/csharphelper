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
     public partial class howto_cut_lines_Form1:Form
  { 


        public howto_cut_lines_Form1()
        {
            InitializeComponent();
        }

        private List<Point> StartPoints = new List<Point>();
        private List<Point> EndPoints = new List<Point>();

        private bool Drawing = false;
        private Point NewStartPoint, NewEndPoint;

        private void picLines_MouseDown(object sender, MouseEventArgs e)
        {
            Drawing = true;
            NewStartPoint = e.Location;
            NewEndPoint = e.Location;
        }

        private void picLines_MouseMove(object sender, MouseEventArgs e)
        {
            if (!Drawing) return;
            NewEndPoint = e.Location;
            picLines.Refresh();
        }

        private void picLines_MouseUp(object sender, MouseEventArgs e)
        {
            Drawing = false;

            if (NewStartPoint == NewEndPoint) return;

            StartPoints.Add(NewStartPoint);
            EndPoints.Add(NewEndPoint);
            picLines.Refresh();
        }

        private void picLines_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            // Draw the previously saved lines.
            Pen bg_pen = null;
            if (chkUseCuts.Checked) bg_pen = new Pen(picLines.BackColor, 8);
            using (Pen fg_pen = new Pen(Color.Blue, 4))
            {
                for (int i = 0; i < StartPoints.Count; i++)
                {
                    DrawLine(e.Graphics, bg_pen, fg_pen,
                        StartPoints[i], EndPoints[i]);
                }

                // Draw the new line if there is one.
                if (Drawing)
                {
                    fg_pen.Color = Color.Red;
                    DrawLine(e.Graphics, bg_pen, fg_pen,
                        NewStartPoint, NewEndPoint);
                }
            }
            if (bg_pen != null) bg_pen.Dispose();
        }

        // Draw a line segment in the indicated color.
        private void DrawLine(Graphics gr, Pen bg_pen, Pen fg_pen,
            Point start_point, Point end_point)
        {
            if (bg_pen != null)
                gr.DrawLine(bg_pen, start_point, end_point);
            gr.DrawLine(fg_pen, start_point, end_point);
        }

        private void chkUseCuts_CheckedChanged(object sender, EventArgs e)
        {
            picLines.Refresh();
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
            this.picLines = new System.Windows.Forms.PictureBox();
            this.chkUseCuts = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.picLines)).BeginInit();
            this.SuspendLayout();
            // 
            // picLines
            // 
            this.picLines.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.picLines.BackColor = System.Drawing.Color.White;
            this.picLines.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.picLines.Cursor = System.Windows.Forms.Cursors.Cross;
            this.picLines.Location = new System.Drawing.Point(12, 35);
            this.picLines.Name = "picLines";
            this.picLines.Size = new System.Drawing.Size(260, 214);
            this.picLines.TabIndex = 0;
            this.picLines.TabStop = false;
            this.picLines.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picLines_MouseMove);
            this.picLines.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picLines_MouseDown);
            this.picLines.Paint += new System.Windows.Forms.PaintEventHandler(this.picLines_Paint);
            this.picLines.MouseUp += new System.Windows.Forms.MouseEventHandler(this.picLines_MouseUp);
            // 
            // chkUseCuts
            // 
            this.chkUseCuts.AutoSize = true;
            this.chkUseCuts.Location = new System.Drawing.Point(12, 12);
            this.chkUseCuts.Name = "chkUseCuts";
            this.chkUseCuts.Size = new System.Drawing.Size(69, 17);
            this.chkUseCuts.TabIndex = 1;
            this.chkUseCuts.Text = "Use Cuts";
            this.chkUseCuts.UseVisualStyleBackColor = true;
            this.chkUseCuts.CheckedChanged += new System.EventHandler(this.chkUseCuts_CheckedChanged);
            // 
            // howto_cut_lines_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.chkUseCuts);
            this.Controls.Add(this.picLines);
            this.Name = "howto_cut_lines_Form1";
            this.Text = "howto_cut_lines";
            ((System.ComponentModel.ISupportInitialize)(this.picLines)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picLines;
        private System.Windows.Forms.CheckBox chkUseCuts;
    }
}

