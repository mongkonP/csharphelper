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
     public partial class howto_shaped_button_Form1:Form
  { 


        public howto_shaped_button_Form1()
        {
            InitializeComponent();
        }

        private void btnClickMe_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Clicked!");
        }

        // Shape the button.
        private void howto_shaped_button_Form1_Load(object sender, EventArgs e)
        {
            // Define the points in the polygonal path.
            Point[] pts = {
                new Point( 20,  60),
                new Point(140,  60),
                new Point(140,  20),
                new Point(220, 100),
                new Point(140, 180),
                new Point(140, 140),
                new Point( 20, 140)
            };

            // Make the GraphicsPath.
            GraphicsPath polygon_path = new GraphicsPath(FillMode.Winding);
            polygon_path.AddPolygon(pts);

            // Convert the GraphicsPath into a Region.
            Region polygon_region = new Region(polygon_path);

            // Constrain the button to the region.
            btnClickMe.Region = polygon_region;

            // Make the button big enough to hold the whole region.
            btnClickMe.SetBounds(
                btnClickMe.Location.X,
                btnClickMe.Location.Y,
                pts[3].X + 5, pts[4].Y + 5);
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
            this.btnClickMe = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnClickMe
            // 
            this.btnClickMe.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold);
            this.btnClickMe.Location = new System.Drawing.Point(25, 21);
            this.btnClickMe.Name = "btnClickMe";
            this.btnClickMe.Size = new System.Drawing.Size(200, 200);
            this.btnClickMe.TabIndex = 1;
            this.btnClickMe.Text = "Click Me!";
            this.btnClickMe.UseVisualStyleBackColor = true;
            this.btnClickMe.Click += new System.EventHandler(this.btnClickMe_Click);
            // 
            // howto_shaped_button_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.ClientSize = new System.Drawing.Size(282, 242);
            this.Controls.Add(this.btnClickMe);
            this.Name = "howto_shaped_button_Form1";
            this.Text = "howto_shaped_button";
            this.Load += new System.EventHandler(this.howto_shaped_button_Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnClickMe;

    }
}

