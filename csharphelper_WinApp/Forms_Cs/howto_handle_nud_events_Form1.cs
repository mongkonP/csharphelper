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
     public partial class howto_handle_nud_events_Form1:Form
  { 


        public howto_handle_nud_events_Form1()
        {
            InitializeComponent();
        }

        // Redraw on resize.
        private void howto_handle_nud_events_Form1_Load(object sender, EventArgs e)
        {
            ResizeRedraw = true;
            nudScale.Minimum = 0;
            nudScale.Maximum = 1;
            nudScale.DecimalPlaces = 2;
            nudScale.Increment = 0.01m;
        }

        // Occurs when the user clicks an arrow.
        private void nudScale_ValueChanged(object sender, EventArgs e)
        {
            Refresh();
        }

        // Occurs when the user presses a key.
        private void nudScale_KeyUp(object sender, KeyEventArgs e)
        {
            Refresh();
        }

        // Draw an ellipse.
        private void howto_handle_nud_events_Form1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            // Get the ellipse's size as a fraction of the form's width and height.
            float width = (float)(ClientSize.Width * nudScale.Value);
            float height = (float)(ClientSize.Height * nudScale.Value);

            // Draw the ellipse.
            float x = (ClientSize.Width - width) / 2;
            float y = (ClientSize.Height - height) / 2;
            e.Graphics.DrawEllipse(Pens.Red, x, y, width, height);
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
            this.nudScale = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.nudScale)).BeginInit();
            this.SuspendLayout();
            // 
            // nudScale
            // 
            this.nudScale.DecimalPlaces = 2;
            this.nudScale.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.nudScale.Location = new System.Drawing.Point(55, 12);
            this.nudScale.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudScale.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.nudScale.Name = "nudScale";
            this.nudScale.Size = new System.Drawing.Size(66, 20);
            this.nudScale.TabIndex = 5;
            this.nudScale.Value = new decimal(new int[] {
            75,
            0,
            0,
            131072});
            this.nudScale.ValueChanged += new System.EventHandler(this.nudScale_ValueChanged);
            this.nudScale.KeyUp += new System.Windows.Forms.KeyEventHandler(this.nudScale_KeyUp);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Scale:";
            // 
            // howto_handle_nud_events_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(314, 161);
            this.Controls.Add(this.nudScale);
            this.Controls.Add(this.label1);
            this.Name = "howto_handle_nud_events_Form1";
            this.Text = "howto_handle_nud_events";
            this.Load += new System.EventHandler(this.howto_handle_nud_events_Form1_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.howto_handle_nud_events_Form1_Paint);
            ((System.ComponentModel.ISupportInitialize)(this.nudScale)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown nudScale;
        private System.Windows.Forms.Label label1;
    }
}

