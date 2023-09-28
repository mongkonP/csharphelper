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
     public partial class howto_packed_circles_Form1:Form
  { 


        public howto_packed_circles_Form1()
        {
            InitializeComponent();
        }

        private float InnerRadius, OuterRadius;

        // Display the PrintPreviewDialog.
        private void btnPreview_Click(object sender, EventArgs e)
        {
            InnerRadius = 100 * float.Parse(txtInnerRadius.Text);
            OuterRadius = 100 * float.Parse(txtOuterRadius.Text);
            Form frm = ppdCircles as Form;
            frm.WindowState = FormWindowState.Maximized;
            ppdCircles.PrintPreviewControl.Zoom = 1.0;
            ppdCircles.PrintPreviewControl.UseAntiAlias = true;
            ppdCircles.ShowDialog();
        }

        // Generate the printout.
        private void pdocCircles_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            float cx = e.MarginBounds.Left + OuterRadius;
            float cy = e.MarginBounds.Top + OuterRadius;

            float dx = OuterRadius;
            float dy = (float)(OuterRadius * Math.Sqrt(3));

            using (Pen dashed_pen = new Pen(Color.Black))
            {
                dashed_pen.DashPattern = new float[] { 10, 10 };

                while (cy - OuterRadius < e.MarginBounds.Bottom)
                {
                    // Make rectangles for the first circle.
                    RectangleF outer_rect = new RectangleF(
                        cx - OuterRadius,
                        cy - OuterRadius,
                        2 * OuterRadius,
                        2 * OuterRadius);
                    RectangleF inner_rect = new RectangleF(
                        cx - InnerRadius,
                        cy - InnerRadius,
                        2 * InnerRadius,
                        2 * InnerRadius);

                    // Draw a row.
                    while (outer_rect.Left < e.MarginBounds.Right)
                    {
                        e.Graphics.DrawEllipse(dashed_pen, outer_rect);
                        e.Graphics.DrawEllipse(Pens.Black, inner_rect);
                        outer_rect.X += 2 * OuterRadius;
                        inner_rect.X += 2 * OuterRadius;
                    }

                    // Prepare for the next row.
                    cx -= dx;
                    if (cx < e.MarginBounds.Left) cx += 2 * OuterRadius;
                    cy += dy;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(howto_packed_circles_Form1));
            this.label1 = new System.Windows.Forms.Label();
            this.txtInnerRadius = new System.Windows.Forms.TextBox();
            this.txtOuterRadius = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnPreview = new System.Windows.Forms.Button();
            this.ppdCircles = new System.Windows.Forms.PrintPreviewDialog();
            this.pdocCircles = new System.Drawing.Printing.PrintDocument();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Inner Radius:";
            // 
            // txtInnerRadius
            // 
            this.txtInnerRadius.Location = new System.Drawing.Point(94, 12);
            this.txtInnerRadius.Name = "txtInnerRadius";
            this.txtInnerRadius.Size = new System.Drawing.Size(58, 20);
            this.txtInnerRadius.TabIndex = 1;
            this.txtInnerRadius.Text = "1.00";
            this.txtInnerRadius.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtOuterRadius
            // 
            this.txtOuterRadius.Location = new System.Drawing.Point(94, 38);
            this.txtOuterRadius.Name = "txtOuterRadius";
            this.txtOuterRadius.Size = new System.Drawing.Size(58, 20);
            this.txtOuterRadius.TabIndex = 3;
            this.txtOuterRadius.Text = "1.50";
            this.txtOuterRadius.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Outer Radius:";
            // 
            // btnPreview
            // 
            this.btnPreview.Location = new System.Drawing.Point(168, 24);
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Size = new System.Drawing.Size(75, 23);
            this.btnPreview.TabIndex = 4;
            this.btnPreview.Text = "Preview";
            this.btnPreview.UseVisualStyleBackColor = true;
            this.btnPreview.Click += new System.EventHandler(this.btnPreview_Click);
            // 
            // ppdCircles
            // 
            this.ppdCircles.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.ppdCircles.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.ppdCircles.ClientSize = new System.Drawing.Size(400, 300);
            this.ppdCircles.Document = this.pdocCircles;
            this.ppdCircles.Enabled = true;
            this.ppdCircles.Icon = ((System.Drawing.Icon)(resources.GetObject("ppdCircles.Icon")));
            this.ppdCircles.Name = "ppdCircles";
            this.ppdCircles.Visible = false;
            // 
            // pdocCircles
            // 
            this.pdocCircles.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.pdocCircles_PrintPage);
            // 
            // howto_packed_circles_Form1
            // 
            this.AcceptButton = this.btnPreview;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(258, 69);
            this.Controls.Add(this.btnPreview);
            this.Controls.Add(this.txtOuterRadius);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtInnerRadius);
            this.Controls.Add(this.label1);
            this.Name = "howto_packed_circles_Form1";
            this.Text = "howto_packed_circles";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtInnerRadius;
        private System.Windows.Forms.TextBox txtOuterRadius;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnPreview;
        private System.Windows.Forms.PrintPreviewDialog ppdCircles;
        private System.Drawing.Printing.PrintDocument pdocCircles;
    }
}

