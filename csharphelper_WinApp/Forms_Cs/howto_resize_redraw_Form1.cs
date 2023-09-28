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
     public partial class howto_resize_redraw_Form1:Form
  { 


        public howto_resize_redraw_Form1()
        {
            InitializeComponent();
        }

        // Turn ResizeRedraw on or off.
        private void chkResizeRedraw_CheckedChanged(object sender, EventArgs e)
        {
            this.ResizeRedraw = (chkResizeRedraw.Checked);
        }

        // Draw a diamond that fits the form.
        private void howto_resize_redraw_Form1_Paint(object sender, PaintEventArgs e)
        {
            Point[] pts =
            {
                new Point((int)(this.ClientSize.Width / 2), 0),
                new Point(this.ClientSize.Width, (int)(this.ClientSize.Height / 2)),
                new Point((int)(this.ClientSize.Width / 2), this.ClientSize.Height),
                new Point(0, (int)(this.ClientSize.Height / 2)),
            };
            e.Graphics.DrawPolygon(Pens.Red, pts);
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
            this.chkResizeRedraw = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // chkResizeRedraw
            // 
            this.chkResizeRedraw.AutoSize = true;
            this.chkResizeRedraw.Location = new System.Drawing.Point(12, 12);
            this.chkResizeRedraw.Name = "chkResizeRedraw";
            this.chkResizeRedraw.Size = new System.Drawing.Size(95, 17);
            this.chkResizeRedraw.TabIndex = 0;
            this.chkResizeRedraw.Text = "ResizeRedraw";
            this.chkResizeRedraw.UseVisualStyleBackColor = true;
            this.chkResizeRedraw.CheckedChanged += new System.EventHandler(this.chkResizeRedraw_CheckedChanged);
            // 
            // howto_resize_redraw_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 264);
            this.Controls.Add(this.chkResizeRedraw);
            this.Name = "howto_resize_redraw_Form1";
            this.Text = "howto_resize_redraw";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.howto_resize_redraw_Form1_Paint);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chkResizeRedraw;
    }
}

