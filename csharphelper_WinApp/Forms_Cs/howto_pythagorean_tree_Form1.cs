using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Drawing.Drawing2D;

 

using howto_pythagorean_tree;
namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_pythagorean_tree_Form1:Form
  { 


        public howto_pythagorean_tree_Form1()
        {
            InitializeComponent();
        }

        // Draw the tree.
        private void picCanvas_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(picCanvas.BackColor);
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            try
            {
                int depth = (int)nudDepth.Value;
                int length = (int)nudLength.Value;
                float alpha = (float)((double)nudAlpha.Value * Math.PI / 180.0);
                float root_x = picCanvas.ClientSize.Width / 2;
                float root_y = picCanvas.ClientSize.Height * 0.9f;
                VectorF v_base = new VectorF(length, 0);
                PointF ll_corner = new PointF(root_x, root_y) - v_base / 2;

                Brush brush = null;
                if (chkFill.Checked) brush = Brushes.Green;
                
                DrawBranch(e.Graphics, Pens.Black, brush,
                    depth, ll_corner, v_base, alpha);
            }
            catch
            {
            }
        }

        // Redraw.
        private void parameter_ValueChanged(object sender, EventArgs e)
        {
            picCanvas.Refresh();
        }
        private void picCanvas_Resize(object sender, EventArgs e)
        {
            picCanvas.Refresh();
        }
        private void nud_KeyUp(object sender, KeyEventArgs e)
        {
            picCanvas.Refresh();
        }

        // Recursively draw a binary tree branch.
        private void DrawBranch(Graphics gr, Pen pen, Brush brush,
            int depth, PointF ll_corner, VectorF v_base, float alpha)
        {
            // Find the box's corners.
            VectorF v_height = v_base.PerpendicularCCW();
            PointF[] points =
            {
                ll_corner,
                ll_corner + v_base,
                ll_corner + v_base + v_height,
                ll_corner + v_height,
            };

            // Draw this box.
            if (brush != null) gr.FillPolygon(brush, points);
            gr.DrawPolygon(pen, points);

            // If depth > 0, draw the attached branches.
            if (depth > 0)
            {
                // ***********
                // Left branch
                // ***********
                // Calculate the new side length.
                double w1 = v_base.Length * Math.Cos(alpha);

                // Decompose the new base vector in terms of v_base and v_height.
                float wb1 = (float)(w1 * Math.Cos(alpha));
                float wh1 = (float)(w1 * Math.Sin(alpha));
                VectorF v_base1 = v_base.Scale(wb1) + v_height.Scale(wh1);

                // Find the lower left corner.
                PointF ll_corner1 = ll_corner + v_height;

                // Draw the left branch.
                DrawBranch(gr, pen, brush, depth - 1, ll_corner1, v_base1, alpha);

                // ************
                // Right branch
                // ************
                // Calculate the new side length.
                double beta = Math.PI / 2.0 - alpha;
                double w2 = v_base.Length * Math.Sin(alpha);

                // Decompose the new base vector in terms of v_base and v_height.
                float wb2 = (float)(w2 * Math.Cos(beta));
                float wh2 = (float)(w2 * Math.Sin(beta));
                VectorF v_base2 = v_base.Scale(wb2) - v_height.Scale(wh2);

                // Find the lower left corner.
                PointF ll_corner2 = ll_corner1 + v_base1;

                // Draw the right branch.
                DrawBranch(gr, pen, brush, depth - 1, ll_corner2, v_base2, alpha);
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
            this.nudAlpha = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.nudLength = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.nudDepth = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.picCanvas = new System.Windows.Forms.PictureBox();
            this.chkFill = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.nudAlpha)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudLength)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDepth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCanvas)).BeginInit();
            this.SuspendLayout();
            // 
            // nudAlpha
            // 
            this.nudAlpha.Location = new System.Drawing.Point(61, 64);
            this.nudAlpha.Maximum = new decimal(new int[] {
            360,
            0,
            0,
            0});
            this.nudAlpha.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudAlpha.Name = "nudAlpha";
            this.nudAlpha.Size = new System.Drawing.Size(42, 20);
            this.nudAlpha.TabIndex = 17;
            this.nudAlpha.Value = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.nudAlpha.ValueChanged += new System.EventHandler(this.parameter_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 66);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 13);
            this.label4.TabIndex = 16;
            this.label4.Text = "Alpha:";
            // 
            // nudLength
            // 
            this.nudLength.Location = new System.Drawing.Point(61, 38);
            this.nudLength.Maximum = new decimal(new int[] {
            300,
            0,
            0,
            0});
            this.nudLength.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudLength.Name = "nudLength";
            this.nudLength.Size = new System.Drawing.Size(42, 20);
            this.nudLength.TabIndex = 13;
            this.nudLength.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.nudLength.ValueChanged += new System.EventHandler(this.parameter_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Length:";
            // 
            // nudDepth
            // 
            this.nudDepth.Location = new System.Drawing.Point(61, 12);
            this.nudDepth.Maximum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.nudDepth.Name = "nudDepth";
            this.nudDepth.Size = new System.Drawing.Size(42, 20);
            this.nudDepth.TabIndex = 11;
            this.nudDepth.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.nudDepth.ValueChanged += new System.EventHandler(this.parameter_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Depth:";
            // 
            // picCanvas
            // 
            this.picCanvas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.picCanvas.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.picCanvas.Location = new System.Drawing.Point(109, 12);
            this.picCanvas.Name = "picCanvas";
            this.picCanvas.Size = new System.Drawing.Size(263, 217);
            this.picCanvas.TabIndex = 9;
            this.picCanvas.TabStop = false;
            this.picCanvas.Resize += new System.EventHandler(this.picCanvas_Resize);
            this.picCanvas.Paint += new System.Windows.Forms.PaintEventHandler(this.picCanvas_Paint);
            // 
            // chkFill
            // 
            this.chkFill.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkFill.Location = new System.Drawing.Point(15, 90);
            this.chkFill.Name = "chkFill";
            this.chkFill.Size = new System.Drawing.Size(88, 24);
            this.chkFill.TabIndex = 18;
            this.chkFill.Text = "Fill";
            this.chkFill.UseVisualStyleBackColor = true;
            this.chkFill.CheckedChanged += new System.EventHandler(this.parameter_ValueChanged);
            // 
            // howto_pythagorean_tree_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 241);
            this.Controls.Add(this.chkFill);
            this.Controls.Add(this.nudAlpha);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.nudLength);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.nudDepth);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.picCanvas);
            this.Name = "howto_pythagorean_tree_Form1";
            this.Text = "howto_pythagorean_tree";
            ((System.ComponentModel.ISupportInitialize)(this.nudAlpha)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudLength)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDepth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCanvas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown nudAlpha;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown nudLength;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown nudDepth;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox picCanvas;
        private System.Windows.Forms.CheckBox chkFill;
    }
}

