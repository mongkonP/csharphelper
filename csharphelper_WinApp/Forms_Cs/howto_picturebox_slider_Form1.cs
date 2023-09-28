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
     public partial class howto_picturebox_slider_Form1:Form
  { 


        public howto_picturebox_slider_Form1()
        {
            InitializeComponent();
        }

        // The current value.
        private float SliderValue = 0.3f;

        // The minimum and maximum allowed values.
        private const float MinimumValue = 0.0f;
        private const float MaximumValue = 1.0f;

        // Move the needle to this position.
        private bool MouseIsDown = false;
        private void picSlider_MouseDown(object sender, MouseEventArgs e)
        {
            MouseIsDown = true;
            SetValue(XtoValue(e.X));
        }
        private void picSlider_MouseMove(object sender, MouseEventArgs e)
        {
            if (!MouseIsDown) return;
            SetValue(XtoValue(e.X));
        }
        private void picSlider_MouseUp(object sender, MouseEventArgs e)
        {
            MouseIsDown = false;
            tipValue.Hide(this);

            // Take action here if desired.
            lblResult.Text = SliderValue.ToString("0.00");
        }

        // Convert an X coordinate to a value.
        private float XtoValue(int x)
        {
            return MinimumValue + (MaximumValue - MinimumValue) *
                x / (float)(picSlider.ClientSize.Width - 1);
        }

        // Convert value to an X coordinate.
        private float ValueToX(float value)
        {
            return (picSlider.ClientSize.Width - 1) *
                (value - MinimumValue) / (float)(MaximumValue - MinimumValue);
        }

        // Draw the needle.
        private void picSlider_Paint(object sender, PaintEventArgs e)
        {
            // Calculate the needle's X coordinate.
            float x = ValueToX(SliderValue);

            // Draw it.
            using (Pen pen = new Pen(Color.Blue, 2))
            {
                e.Graphics.DrawLine(pen, x, 0,
                    x, picSlider.ClientSize.Height);
            }
        }

        // Set the slider's value. If the value has changed,
        // display the value tooltip.
        private void SetValue(float value)
        {
            // Make sure the new value is within bounds.
            if (value < MinimumValue) value = MinimumValue;
            if (value > MaximumValue) value = MaximumValue;

            // See if the value has changed.
            if (SliderValue == value) return;

            // Save the new value.
            SliderValue = value;

            // Redraw to show the new value.
            picSlider.Refresh();

            // Display the value tooltip.
            int tip_x = picSlider.Left + (int)ValueToX(SliderValue);
            int tip_y = picSlider.Top;
            tipValue.Show(SliderValue.ToString("0.00"), this, tip_x, tip_y, 3000);

            // Take action here if desired.
            lblResult.Text = SliderValue.ToString("0.00");
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
            this.components = new System.ComponentModel.Container();
            this.lblResult = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.picSlider = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tipValue = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.picSlider)).BeginInit();
            this.SuspendLayout();
            // 
            // lblResult
            // 
            this.lblResult.AutoSize = true;
            this.lblResult.Location = new System.Drawing.Point(12, 94);
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size(28, 13);
            this.lblResult.TabIndex = 7;
            this.lblResult.Text = "0.30";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Result:";
            // 
            // picSlider
            // 
            this.picSlider.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.picSlider.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.picSlider.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.picSlider.Location = new System.Drawing.Point(12, 25);
            this.picSlider.Name = "picSlider";
            this.picSlider.Size = new System.Drawing.Size(260, 18);
            this.picSlider.TabIndex = 4;
            this.picSlider.TabStop = false;
            this.picSlider.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picSlider_MouseMove);
            this.picSlider.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picSlider_MouseDown);
            this.picSlider.Paint += new System.Windows.Forms.PaintEventHandler(this.picSlider_Paint);
            this.picSlider.MouseUp += new System.Windows.Forms.MouseEventHandler(this.picSlider_MouseUp);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Select a value";
            // 
            // howto_picturebox_slider_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 120);
            this.Controls.Add(this.lblResult);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.picSlider);
            this.Controls.Add(this.label1);
            this.Name = "howto_picturebox_slider_Form1";
            this.Text = "howto_picturebox_slider";
            ((System.ComponentModel.ISupportInitialize)(this.picSlider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblResult;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox picSlider;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolTip tipValue;
    }
}

