using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Drawing.Drawing2D;

 

using howto_polygon_selector;
namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_polygon_selector_Form1:Form
  { 


        public howto_polygon_selector_Form1()
        {
            InitializeComponent();
        }

        // The polygons.
        private List<Point[]> Polygons = new List<Point[]>();

        // The polygon selector.
        private PolygonSelector Selector;

        // Prepare the selector.
        private void howto_polygon_selector_Form1_Load(object sender, EventArgs e)
        {
            Selector = new PolygonSelector(picCanvas, new Pen(Color.Red, 3));
            Selector.PolygonSelected += Selector_PolygonSelected;
        }

        // The user has selected a polygon. Save it.
        void Selector_PolygonSelected(object sender, PolygonEventArgs args)
        {
            // Save the new polygon.
            Polygons.Add(args.Points.ToArray());

            // Redraw.
            picCanvas.Refresh();
        }

        // Draw any existing polygons.
        private void picCanvas_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(picCanvas.BackColor);
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            using (Pen pen = new Pen(Color.Green, 3))
            {
                foreach (Point[] polygon in Polygons)
                {
                    e.Graphics.DrawPolygon(pen, polygon);
                }
            }
        }

        private void chkDrawPolygons_CheckedChanged(object sender, EventArgs e)
        {
            Selector.Enabled = chkDrawPolygons.Checked;
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
            this.picCanvas = new System.Windows.Forms.PictureBox();
            this.chkDrawPolygons = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.picCanvas)).BeginInit();
            this.SuspendLayout();
            // 
            // picCanvas
            // 
            this.picCanvas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.picCanvas.BackColor = System.Drawing.Color.White;
            this.picCanvas.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.picCanvas.Location = new System.Drawing.Point(12, 35);
            this.picCanvas.Name = "picCanvas";
            this.picCanvas.Size = new System.Drawing.Size(260, 214);
            this.picCanvas.TabIndex = 0;
            this.picCanvas.TabStop = false;
            this.picCanvas.Paint += new System.Windows.Forms.PaintEventHandler(this.picCanvas_Paint);
            // 
            // chkDrawPolygons
            // 
            this.chkDrawPolygons.AutoSize = true;
            this.chkDrawPolygons.Checked = true;
            this.chkDrawPolygons.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkDrawPolygons.Location = new System.Drawing.Point(12, 12);
            this.chkDrawPolygons.Name = "chkDrawPolygons";
            this.chkDrawPolygons.Size = new System.Drawing.Size(97, 17);
            this.chkDrawPolygons.TabIndex = 1;
            this.chkDrawPolygons.Text = "Draw Polygons";
            this.chkDrawPolygons.UseVisualStyleBackColor = true;
            this.chkDrawPolygons.CheckedChanged += new System.EventHandler(this.chkDrawPolygons_CheckedChanged);
            // 
            // howto_polygon_selector_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.chkDrawPolygons);
            this.Controls.Add(this.picCanvas);
            this.Name = "howto_polygon_selector_Form1";
            this.Text = "howto_polygon_selector";
            this.Load += new System.EventHandler(this.howto_polygon_selector_Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picCanvas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picCanvas;
        private System.Windows.Forms.CheckBox chkDrawPolygons;
    }
}

