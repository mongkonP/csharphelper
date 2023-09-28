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
     public partial class howto_set_clientsize_Form1:Form
  { 


        public howto_set_clientsize_Form1()
        {
            InitializeComponent();
        }

        // Draw a diamond of the appropriate size.
        private void howto_set_clientsize_Form1_Paint(object sender, PaintEventArgs e)
        {
            int hgt, wid;
            if (rad200x300.Checked) { hgt = 300; wid = 200; }
            else                    { hgt = 200; wid = 300; }
            Point[] pts =
            {
                new Point(wid / 2, 0),
                new Point(wid, hgt / 2),
                new Point(wid / 2, hgt),
                new Point(0, hgt / 2),
            };

            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            e.Graphics.DrawPolygon(Pens.Blue, pts);
        }

        // Change the size.
        private void rad200x300_CheckedChanged(object sender, EventArgs e)
        {
            if (rad200x300.Checked) ClientSize = new Size(200, 300);
            else ClientSize = new Size(300, 200);

            Refresh();
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
            this.rad200x300 = new System.Windows.Forms.RadioButton();
            this.rad300x200 = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // rad200x300
            // 
            this.rad200x300.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.rad200x300.AutoSize = true;
            this.rad200x300.Location = new System.Drawing.Point(69, 124);
            this.rad200x300.Name = "rad200x300";
            this.rad200x300.Size = new System.Drawing.Size(66, 17);
            this.rad200x300.TabIndex = 0;
            this.rad200x300.TabStop = true;
            this.rad200x300.Text = "200x300";
            this.rad200x300.UseVisualStyleBackColor = true;
            this.rad200x300.CheckedChanged += new System.EventHandler(this.rad200x300_CheckedChanged);
            // 
            // rad300x200
            // 
            this.rad300x200.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.rad300x200.AutoSize = true;
            this.rad300x200.Location = new System.Drawing.Point(150, 124);
            this.rad300x200.Name = "rad300x200";
            this.rad300x200.Size = new System.Drawing.Size(66, 17);
            this.rad300x200.TabIndex = 1;
            this.rad300x200.TabStop = true;
            this.rad300x200.Text = "300x200";
            this.rad300x200.UseVisualStyleBackColor = true;
            this.rad300x200.CheckedChanged += new System.EventHandler(this.rad200x300_CheckedChanged);
            // 
            // howto_set_clientsize_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 264);
            this.Controls.Add(this.rad300x200);
            this.Controls.Add(this.rad200x300);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "howto_set_clientsize_Form1";
            this.Text = "howto_set_clientsize";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.howto_set_clientsize_Form1_Paint);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton rad200x300;
        private System.Windows.Forms.RadioButton rad300x200;

    }
}

