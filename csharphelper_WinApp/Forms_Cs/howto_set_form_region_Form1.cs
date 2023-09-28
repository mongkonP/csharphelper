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
     public partial class howto_set_form_region_Form1:Form
  { 


        public howto_set_form_region_Form1()
        {
            InitializeComponent();
        }

        private void howto_set_form_region_Form1_Load(object sender, EventArgs e)
        {
            // Make points to define a polygon for the form.
            PointF[] pts = new PointF[10];
            float cx = (float)(this.ClientSize.Width * 0.5);
            float cy = (float)(this.ClientSize.Height * 0.5);
            float r1 = (float)(this.ClientSize.Height * 0.45);
            float r2 = (float)(this.ClientSize.Height * 0.25);
            float theta = (float)(-Math.PI / 2);
            float dtheta = (float)(2 * Math.PI / 10);
            for (int i = 0; i < 10; i += 2)
            {
                pts[i] = new PointF(
                    (float)(cx + r1 * Math.Cos(theta)),
                    (float)(cy + r1 * Math.Sin(theta)));
                theta += dtheta;
                pts[i + 1] = new PointF(
                    (float)(cx + r2 * Math.Cos(theta)),
                    (float)(cy + r2 * Math.Sin(theta)));
                theta += dtheta;
            }

            // Use the polygon to define a GraphicsPath.
            GraphicsPath path = new GraphicsPath();
            path.AddPolygon(pts);

            // Make a region from the path.
            Region form_region = new Region(path);

            // Restrict the form to the region.
            this.Region = form_region;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
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
            this.btnClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(105, 121);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 0;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // howto_set_form_region_Form1
            // 
            this.AcceptButton = this.btnClose;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(284, 264);
            this.Controls.Add(this.btnClose);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "howto_set_form_region_Form1";
            this.Text = "howto_set_form_region";
            this.Load += new System.EventHandler(this.howto_set_form_region_Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnClose;
    }
}

