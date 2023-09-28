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
     public partial class howto_linear_gradient_Form1:Form
  { 


        public howto_linear_gradient_Form1()
        {
            InitializeComponent();
        }

        private void howto_linear_gradient_Form1_Paint(object sender, PaintEventArgs e)
        {
            // Define a brush with two points and their colors.
            using (LinearGradientBrush br = new LinearGradientBrush(
                new Point(10, 10), new Point(140, 50), Color.Red, Color.White))
            {
                e.Graphics.FillRectangle(br, 10, 10, 125, 50);
                e.Graphics.DrawRectangle(Pens.Black, 10, 10, 125, 50);
            }

            // Define a brush with a Rectangle, colors, and gradient mode.
            Rectangle rect = new Rectangle(145, 10, 125, 50);
            using (LinearGradientBrush br = new LinearGradientBrush(
                rect, Color.Blue, Color.White, LinearGradientMode.ForwardDiagonal))
            {
                e.Graphics.FillRectangle(br, rect);
                e.Graphics.DrawRectangle(Pens.Black, rect);
            }

            // Define a gradient with more than 2 colors.
            rect = new Rectangle(10, 70, 260, 50);
            using (LinearGradientBrush br = new LinearGradientBrush(
                rect, Color.Blue, Color.White, 0f))
            {
                // Create a ColorBlend object. Note that you
                // must initialize it before you save it in the
                // brush's InterpolationColors property.
                ColorBlend colorBlend = new ColorBlend();
                colorBlend.Colors = new Color[] 
                {
                    Color.Red,
                    Color.Orange,
                    Color.Yellow,
                    Color.Lime,
                    Color.Blue,
                    Color.Indigo,
                    Color.Violet,
                };
                colorBlend.Positions = new float[]
                {
                    0f, 1/6f, 2/6f, 3/6f, 4/6f, 5/6f, 1f
                };
                br.InterpolationColors = colorBlend;

                e.Graphics.FillRectangle(br, rect);
                e.Graphics.DrawRectangle(Pens.Black, rect);
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
            this.SuspendLayout();
            // 
            // howto_linear_gradient_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 134);
            this.Name = "howto_linear_gradient_Form1";
            this.Text = "howto_linear_gradient";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.howto_linear_gradient_Form1_Paint);
            this.ResumeLayout(false);

        }

        #endregion
    }
}

