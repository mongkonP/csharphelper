//#define DRAW_POINTS
//#define DRAW_LEVEL_MINUS_1

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

// http://en.wikipedia.org/wiki/Dragon_curve
// http://en.wikipedia.org/wiki/Heighway_dragon
// http://ecademy.agnesscott.edu/~lriddle/ifs/heighway/heighway.htm

 

namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_center_heighway_dragon_Form1:Form
  { 


        public howto_center_heighway_dragon_Form1()
        {
            InitializeComponent();
        }

        // The direction the curve should turn next.
        private enum Direction
        {
            Left,
            Right
        }

        // Redraw.
        private void btnDraw_Click(object sender, EventArgs e)
        {
            picDragon.Refresh();
        }
        private void picDragon_Resize(object sender, EventArgs e)
        {
            picDragon.Refresh();
        }

        // Draw the dragon.
        private void picDragon_Paint(object sender, PaintEventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            e.Graphics.Clear(picDragon.BackColor);

            // Find the first control points.
            const int margin = 5;
            float dx = Math.Min(
                (picDragon.ClientSize.Width - 2 * margin) / 1.5f,
                (picDragon.ClientSize.Height - 2 * margin));

            // Center it.
            float x0 = (picDragon.ClientSize.Width - dx * 1.5f) / 2f + dx / 3f;
            float y0 = (picDragon.ClientSize.Height - dx) / 2f + dx / 3f;

            // Recursively draw the lines.
            int level = (int)nudLevel.Value;
            DrawDragonLine(e.Graphics, level, Direction.Right, x0, y0, dx, 0);
            Cursor = Cursors.Default;

            // Draw a box around it and some other lines to show size.
            e.Graphics.DrawRectangle(Pens.Green,
                x0 - dx / 3, y0 - dx / 3,
                1.5f * dx, dx);
            e.Graphics.DrawLine(Pens.Blue, x0, y0, x0 + dx, y0 + 0);
            e.Graphics.FillEllipse(Brushes.Blue, x0 - 2, y0 - 2, 5, 5);
        }

        // Recursively draw the dragon curve between the two points.
        private void DrawDragonLine(Graphics gr, int level, Direction turn_towards, float x1, float y1, float dx, float dy)
        {
            if (level <= 0)
            {
                gr.DrawLine(Pens.Red, x1, y1, x1 + dx, y1 + dy);

#if DRAW_POINTS
                gr.DrawEllipse(Pens.Blue, x1 - 2, y1 - 2, 4, 4);
                gr.DrawEllipse(Pens.Blue, x1 + dx - 2, y1 + dy - 2, 4, 4);
#endif
            }
            else
            {
#if DRAW_LEVEL_MINUS_1
                if (level == 1)
                {
                    gr.DrawLine(Pens.Silver, x1, y1, x1 + dx, y1 + dy);
                }
#endif
                float nx = (float)(dx / 2);
                float ny = (float)(dy / 2);
                float dx2 = -ny + nx;
                float dy2 = nx + ny;
                if (turn_towards == Direction.Right)
                {
                    // Turn to the right.
                    DrawDragonLine(gr, level - 1, Direction.Right, x1, y1, dx2, dy2);
                    float x2 = x1 + dx2;
                    float y2 = y1 + dy2;
                    DrawDragonLine(gr, level - 1, Direction.Left, x2, y2, dy2, -dx2);
                }
                else
                {
                    // Turn to the left.
                    DrawDragonLine(gr, level - 1, Direction.Right, x1, y1, dy2, -dx2);
                    float x2 = x1 + dy2;
                    float y2 = y1 - dx2;
                    DrawDragonLine(gr, level - 1, Direction.Left, x2, y2, dx2, dy2);
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
            this.btnDraw = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.nudLevel = new System.Windows.Forms.NumericUpDown();
            this.picDragon = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.nudLevel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picDragon)).BeginInit();
            this.SuspendLayout();
            // 
            // btnDraw
            // 
            this.btnDraw.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDraw.Location = new System.Drawing.Point(257, 12);
            this.btnDraw.Name = "btnDraw";
            this.btnDraw.Size = new System.Drawing.Size(75, 23);
            this.btnDraw.TabIndex = 7;
            this.btnDraw.Text = "Draw";
            this.btnDraw.UseVisualStyleBackColor = true;
            this.btnDraw.Click += new System.EventHandler(this.btnDraw_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Level:";
            // 
            // nudLevel
            // 
            this.nudLevel.Location = new System.Drawing.Point(54, 15);
            this.nudLevel.Maximum = new decimal(new int[] {
            18,
            0,
            0,
            0});
            this.nudLevel.Name = "nudLevel";
            this.nudLevel.Size = new System.Drawing.Size(46, 20);
            this.nudLevel.TabIndex = 5;
            // 
            // picDragon
            // 
            this.picDragon.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.picDragon.BackColor = System.Drawing.Color.White;
            this.picDragon.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.picDragon.Location = new System.Drawing.Point(12, 41);
            this.picDragon.Name = "picDragon";
            this.picDragon.Size = new System.Drawing.Size(320, 208);
            this.picDragon.TabIndex = 4;
            this.picDragon.TabStop = false;
            this.picDragon.Resize += new System.EventHandler(this.picDragon_Resize);
            this.picDragon.Paint += new System.Windows.Forms.PaintEventHandler(this.picDragon_Paint);
            // 
            // howto_center_heighway_dragon_Form1
            // 
            this.AcceptButton = this.btnDraw;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(344, 261);
            this.Controls.Add(this.btnDraw);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.nudLevel);
            this.Controls.Add(this.picDragon);
            this.Name = "howto_center_heighway_dragon_Form1";
            this.Text = "howto_center_heighway_dragon";
            ((System.ComponentModel.ISupportInitialize)(this.nudLevel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picDragon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnDraw;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown nudLevel;
        private System.Windows.Forms.PictureBox picDragon;
    }
}

