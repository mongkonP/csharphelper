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
     public partial class howto_queue_breadth_first_tree_Form1:Form
  { 


        public howto_queue_breadth_first_tree_Form1()
        {
            InitializeComponent();
        }

        // Hold branch information.
        private class BranchInfo
        {
            public float X, Y, Theta, Length;
            public int Depth;
            public BranchInfo(float x, float y, float theta, float length, int depth)
            {
                X = x;
                Y = y;
                Theta = theta;
                Length = length;
                Depth = depth;
            }
        }

        // Draw a binary tree.
        private void DrawTree(Graphics gr, Pen pen,
            int max_depth, float x, float y, float max_length,
            float initial_theta, float length_scale, float dtheta)
        {
            // Add the trunk to a queue.
            Queue<BranchInfo> branches = new Queue<BranchInfo>();
            branches.Enqueue(new BranchInfo(x, y, initial_theta, max_length, max_depth));

            // Process branches until the queue is empty.
            while (branches.Count > 0)
            {
                // Draw the next branch.
                BranchInfo branch = branches.Dequeue();

                // Set the pen's color depending on the depth.
                if (branch.Depth == 1) pen.Color = Color.Red;
                else
                {
                    int g = 255 * (max_depth - branch.Depth) / max_depth;
                    int r = 139 * (branch.Depth - 3) / max_depth;
                    if (r < 0) r = 0;
                    int b = 0;
                    pen.Color = Color.FromArgb(r, g, b);
                }

                // Set the pen's thickness depending on the depth.
                int thickness = 10 * branch.Depth / max_depth;
                if (thickness < 0) thickness = 0;
                pen.Width = thickness;

                // See where this branch should end.
                float x1 = (float)(branch.X + branch.Length * Math.Cos(branch.Theta));
                float y1 = (float)(branch.Y + branch.Length * Math.Sin(branch.Theta));

                // Draw the branch.
                gr.DrawLine(pen, branch.X, branch.Y, x1, y1);

                // If branch.depth > 1, add child branches to the queue.
                if (branch.Depth > 1)
                {
                    branches.Enqueue(new BranchInfo(x1, y1,
                        branch.Theta + dtheta, branch.Length * length_scale, branch.Depth - 1));
                    branches.Enqueue(new BranchInfo(x1, y1,
                        branch.Theta - dtheta, branch.Length * length_scale, branch.Depth - 1));
                }
            }
        }

        // Draw the tree.
        private void picCanvas_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(picCanvas.BackColor);
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            try
            {
                float root_x = picCanvas.ClientSize.Width / 2;
                float root_y = picCanvas.ClientSize.Height - 4;
                float length_scale = float.Parse(txtLengthScale.Text);
                float dtheta = (float)(Math.PI / 180.0 * (double)nudDtheta.Value);
                using (Pen the_pen = new Pen(Color.Black))
                {
                    DrawTree(e.Graphics, the_pen,
                        (int)nudDepth.Value, root_x, root_y,
                        (int)nudLength.Value, (float)(-Math.PI / 2), length_scale,
                        dtheta);
                }
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

        // Redraw.
        private void picCanvas_Resize(object sender, EventArgs e)
        {
            picCanvas.Refresh();
        }

        // Redraw.
        private void nud_KeyUp(object sender, KeyEventArgs e)
        {
            picCanvas.Refresh();
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
            this.nudDtheta = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.txtLengthScale = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.nudLength = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.nudDepth = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.picCanvas = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.nudDtheta)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudLength)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDepth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCanvas)).BeginInit();
            this.SuspendLayout();
            // 
            // nudDtheta
            // 
            this.nudDtheta.Location = new System.Drawing.Point(92, 90);
            this.nudDtheta.Maximum = new decimal(new int[] {
            360,
            0,
            0,
            0});
            this.nudDtheta.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudDtheta.Name = "nudDtheta";
            this.nudDtheta.Size = new System.Drawing.Size(42, 20);
            this.nudDtheta.TabIndex = 17;
            this.nudDtheta.Value = new decimal(new int[] {
            35,
            0,
            0,
            0});
            this.nudDtheta.ValueChanged += new System.EventHandler(this.parameter_ValueChanged);
            this.nudDtheta.KeyUp += new System.Windows.Forms.KeyEventHandler(this.nud_KeyUp);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 92);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 13);
            this.label4.TabIndex = 16;
            this.label4.Text = "DTheta:";
            // 
            // txtLengthScale
            // 
            this.txtLengthScale.Location = new System.Drawing.Point(91, 64);
            this.txtLengthScale.Name = "txtLengthScale";
            this.txtLengthScale.Size = new System.Drawing.Size(43, 20);
            this.txtLengthScale.TabIndex = 15;
            this.txtLengthScale.Text = "0.75";
            this.txtLengthScale.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtLengthScale.TextChanged += new System.EventHandler(this.parameter_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 13);
            this.label3.TabIndex = 14;
            this.label3.Text = "Length Scale:";
            // 
            // nudLength
            // 
            this.nudLength.Location = new System.Drawing.Point(92, 38);
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
            this.nudLength.KeyUp += new System.Windows.Forms.KeyEventHandler(this.nud_KeyUp);
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
            this.nudDepth.Location = new System.Drawing.Point(92, 12);
            this.nudDepth.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.nudDepth.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudDepth.Name = "nudDepth";
            this.nudDepth.Size = new System.Drawing.Size(42, 20);
            this.nudDepth.TabIndex = 11;
            this.nudDepth.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nudDepth.ValueChanged += new System.EventHandler(this.parameter_ValueChanged);
            this.nudDepth.KeyUp += new System.Windows.Forms.KeyEventHandler(this.nud_KeyUp);
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
            this.picCanvas.Location = new System.Drawing.Point(140, 12);
            this.picCanvas.Name = "picCanvas";
            this.picCanvas.Size = new System.Drawing.Size(257, 215);
            this.picCanvas.TabIndex = 9;
            this.picCanvas.TabStop = false;
            this.picCanvas.Resize += new System.EventHandler(this.picCanvas_Resize);
            this.picCanvas.Paint += new System.Windows.Forms.PaintEventHandler(this.picCanvas_Paint);
            // 
            // howto_queue_breadth_first_tree_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(409, 239);
            this.Controls.Add(this.nudDtheta);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtLengthScale);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.nudLength);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.nudDepth);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.picCanvas);
            this.Name = "howto_queue_breadth_first_tree_Form1";
            this.Text = "howto_queue_breadth_first_tree";
            ((System.ComponentModel.ISupportInitialize)(this.nudDtheta)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudLength)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDepth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCanvas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown nudDtheta;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtLengthScale;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown nudLength;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown nudDepth;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox picCanvas;
    }
}

