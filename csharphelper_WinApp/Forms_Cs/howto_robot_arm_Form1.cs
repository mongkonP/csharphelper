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
     public partial class howto_robot_arm_Form1:Form
  { 


        public howto_robot_arm_Form1()
        {
            InitializeComponent();
        }

        // Redraw.
        private void scrJoint_Scroll(object sender, ScrollEventArgs e)
        {
            picCanvas.Refresh();
        }

        // Draw the arm.
        private void picCanvas_Paint(object sender, PaintEventArgs e)
        {
            DrawRobotArm(e.Graphics);
        }

        // Draw the robot arm.
        private void DrawRobotArm(Graphics gr)
        {
            const int UpperArmLength = 75;
            const int LowerArmLength = 50;
            const int WristLength = 20;

            gr.SmoothingMode = SmoothingMode.AntiAlias;
            gr.Clear(picCanvas.BackColor);

            // For each stage in the arm, draw and then *prepend* the
            // new transformation to represent the next arm in the sequence.

            // Translate to center of form.
            float cx = picCanvas.ClientSize.Width / 2;
            float cy = picCanvas.ClientSize.Height / 2;
            gr.TranslateTransform(cx, cy);

            // **************
            // Draw the arms.
            GraphicsState initial_state = gr.Save();

            // Make a rectangle to represent an arm.
            // Later we'll set its width for each arm.
            Rectangle rect = new Rectangle(0, -2, 100, 5);

            // Rotate at the shoulder.
            // (Negative to make the angle increase counter-clockwise).
            gr.RotateTransform(-scrJoint1.Value, MatrixOrder.Prepend);

            // Draw the first arm.
            rect.Width = UpperArmLength;
            gr.FillRectangle(Brushes.LightBlue, rect);
            gr.DrawRectangle(Pens.Blue, rect);

            // Translate to the end of the first arm.
            gr.TranslateTransform(UpperArmLength, 0, MatrixOrder.Prepend);

            // Rotate at the elbow.
            gr.RotateTransform(-scrJoint2.Value, MatrixOrder.Prepend);

            // Draw the second arm.
            rect.Width = LowerArmLength;
            gr.FillRectangle(Brushes.LightBlue, rect);
            gr.DrawRectangle(Pens.Blue, rect);

            // Translate to the end of the second arm.
            gr.TranslateTransform(LowerArmLength, 0, MatrixOrder.Prepend);

            // Rotate at the wrist.
            gr.RotateTransform(-scrJoint3.Value, MatrixOrder.Prepend);

            // Draw the third arm.
            rect.Width = WristLength;
            gr.FillRectangle(Brushes.LightBlue, rect);
            gr.DrawRectangle(Pens.Blue, rect);

            // ***********************************
            // Draw the joints on top of the arms.
            gr.Restore(initial_state);

            // Draw the shoulder centered at the origin.
            Rectangle joint_rect = new Rectangle(-4, -4, 9, 9);
            gr.FillEllipse(Brushes.Red, joint_rect);

            // Rotate at the shoulder.
            // (Negative to make the angle increase counter-clockwise).
            gr.RotateTransform(-scrJoint1.Value, MatrixOrder.Prepend);

            // Translate to the end of the first arm.
            gr.TranslateTransform(UpperArmLength, 0, MatrixOrder.Prepend);

            // Draw the elbow.
            gr.FillEllipse(Brushes.Red, joint_rect); 

            // Rotate at the elbow.
            gr.RotateTransform(-scrJoint2.Value, MatrixOrder.Prepend);

            // Translate to the end of the second arm.
            gr.TranslateTransform(LowerArmLength, 0, MatrixOrder.Prepend);

            // Draw the wrist.
            gr.FillEllipse(Brushes.Red, joint_rect);
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
            this.scrJoint3 = new System.Windows.Forms.HScrollBar();
            this.scrJoint2 = new System.Windows.Forms.HScrollBar();
            this.scrJoint1 = new System.Windows.Forms.HScrollBar();
            this.picCanvas = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picCanvas)).BeginInit();
            this.SuspendLayout();
            // 
            // scrJoint3
            // 
            this.scrJoint3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.scrJoint3.Location = new System.Drawing.Point(9, 51);
            this.scrJoint3.Maximum = 160;
            this.scrJoint3.Minimum = -160;
            this.scrJoint3.Name = "scrJoint3";
            this.scrJoint3.Size = new System.Drawing.Size(369, 17);
            this.scrJoint3.TabIndex = 14;
            this.scrJoint3.Scroll += new System.Windows.Forms.ScrollEventHandler(this.scrJoint_Scroll);
            // 
            // scrJoint2
            // 
            this.scrJoint2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.scrJoint2.Location = new System.Drawing.Point(9, 30);
            this.scrJoint2.Maximum = 160;
            this.scrJoint2.Minimum = -160;
            this.scrJoint2.Name = "scrJoint2";
            this.scrJoint2.Size = new System.Drawing.Size(369, 17);
            this.scrJoint2.TabIndex = 13;
            this.scrJoint2.Scroll += new System.Windows.Forms.ScrollEventHandler(this.scrJoint_Scroll);
            // 
            // scrJoint1
            // 
            this.scrJoint1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.scrJoint1.Location = new System.Drawing.Point(9, 9);
            this.scrJoint1.Maximum = 160;
            this.scrJoint1.Minimum = -160;
            this.scrJoint1.Name = "scrJoint1";
            this.scrJoint1.Size = new System.Drawing.Size(369, 17);
            this.scrJoint1.TabIndex = 12;
            this.scrJoint1.Scroll += new System.Windows.Forms.ScrollEventHandler(this.scrJoint_Scroll);
            // 
            // picCanvas
            // 
            this.picCanvas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.picCanvas.BackColor = System.Drawing.Color.White;
            this.picCanvas.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.picCanvas.Location = new System.Drawing.Point(8, 71);
            this.picCanvas.Name = "picCanvas";
            this.picCanvas.Size = new System.Drawing.Size(370, 370);
            this.picCanvas.TabIndex = 11;
            this.picCanvas.TabStop = false;
            this.picCanvas.Paint += new System.Windows.Forms.PaintEventHandler(this.picCanvas_Paint);
            // 
            // howto_robot_arm_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(387, 450);
            this.Controls.Add(this.scrJoint3);
            this.Controls.Add(this.scrJoint2);
            this.Controls.Add(this.scrJoint1);
            this.Controls.Add(this.picCanvas);
            this.Name = "howto_robot_arm_Form1";
            this.Text = "howto_robot_arm";
            ((System.ComponentModel.ISupportInitialize)(this.picCanvas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.HScrollBar scrJoint3;
        private System.Windows.Forms.HScrollBar scrJoint2;
        private System.Windows.Forms.HScrollBar scrJoint1;
        internal System.Windows.Forms.PictureBox picCanvas;
    }
}

