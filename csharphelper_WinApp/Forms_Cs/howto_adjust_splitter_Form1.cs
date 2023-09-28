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
     public partial class howto_adjust_splitter_Form1:Form
  { 


        public howto_adjust_splitter_Form1()
        {
            InitializeComponent();
        }

        private void btnCloseLeft_Click(object sender, EventArgs e)
        {
            SplitContainer1.Panel1Collapsed = true;
        }

        private void btnLeft25_Click(object sender, EventArgs e)
        {
            SplitContainer1.Panel1Collapsed = false;
            SplitContainer1.Panel2Collapsed = false;
            SplitContainer1.SplitterDistance = (int)(SplitContainer1.ClientSize.Width * 0.25);
        }

        private void btnLeft50_Click(object sender, EventArgs e)
        {
            SplitContainer1.Panel1Collapsed = false;
            SplitContainer1.Panel2Collapsed = false;
            SplitContainer1.SplitterDistance = (int)(SplitContainer1.ClientSize.Width * 0.5);
        }

        private void btnRight25_Click(object sender, EventArgs e)
        {
            SplitContainer1.Panel1Collapsed = false;
            SplitContainer1.Panel2Collapsed = false;
            SplitContainer1.SplitterDistance = (int)(SplitContainer1.ClientSize.Width * 0.75);
        }

        private void btnCloseRight_Click(object sender, EventArgs e)
        {
            SplitContainer1.Panel2Collapsed = true;
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
            this.SplitContainer1 = new System.Windows.Forms.SplitContainer();
            this.Panel1 = new System.Windows.Forms.Panel();
            this.btnCloseRight = new System.Windows.Forms.Button();
            this.btnCloseLeft = new System.Windows.Forms.Button();
            this.btnLeft25 = new System.Windows.Forms.Button();
            this.btnRight25 = new System.Windows.Forms.Button();
            this.btnLeft50 = new System.Windows.Forms.Button();
            this.SplitContainer1.SuspendLayout();
            this.Panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // SplitContainer1
            // 
            this.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SplitContainer1.Location = new System.Drawing.Point(0, 32);
            this.SplitContainer1.Name = "SplitContainer1";
            // 
            // SplitContainer1.Panel1
            // 
            this.SplitContainer1.Panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            // 
            // SplitContainer1.Panel2
            // 
            this.SplitContainer1.Panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.SplitContainer1.Size = new System.Drawing.Size(284, 232);
            this.SplitContainer1.SplitterDistance = 94;
            this.SplitContainer1.TabIndex = 3;
            // 
            // Panel1
            // 
            this.Panel1.Controls.Add(this.btnCloseRight);
            this.Panel1.Controls.Add(this.btnCloseLeft);
            this.Panel1.Controls.Add(this.btnLeft25);
            this.Panel1.Controls.Add(this.btnRight25);
            this.Panel1.Controls.Add(this.btnLeft50);
            this.Panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.Panel1.Location = new System.Drawing.Point(0, 0);
            this.Panel1.Name = "Panel1";
            this.Panel1.Size = new System.Drawing.Size(284, 32);
            this.Panel1.TabIndex = 2;
            // 
            // btnCloseRight
            // 
            this.btnCloseRight.Location = new System.Drawing.Point(257, 3);
            this.btnCloseRight.Name = "btnCloseRight";
            this.btnCloseRight.Size = new System.Drawing.Size(24, 23);
            this.btnCloseRight.TabIndex = 4;
            this.btnCloseRight.Text = "V";
            this.btnCloseRight.UseVisualStyleBackColor = true;
            this.btnCloseRight.Click += new System.EventHandler(this.btnCloseRight_Click);
            // 
            // btnCloseLeft
            // 
            this.btnCloseLeft.Location = new System.Drawing.Point(3, 3);
            this.btnCloseLeft.Name = "btnCloseLeft";
            this.btnCloseLeft.Size = new System.Drawing.Size(24, 23);
            this.btnCloseLeft.TabIndex = 0;
            this.btnCloseLeft.Text = "V";
            this.btnCloseLeft.UseVisualStyleBackColor = true;
            this.btnCloseLeft.Click += new System.EventHandler(this.btnCloseLeft_Click);
            // 
            // btnLeft25
            // 
            this.btnLeft25.Location = new System.Drawing.Point(63, 3);
            this.btnLeft25.Name = "btnLeft25";
            this.btnLeft25.Size = new System.Drawing.Size(24, 23);
            this.btnLeft25.TabIndex = 1;
            this.btnLeft25.Text = "V";
            this.btnLeft25.UseVisualStyleBackColor = true;
            this.btnLeft25.Click += new System.EventHandler(this.btnLeft25_Click);
            // 
            // btnRight25
            // 
            this.btnRight25.Location = new System.Drawing.Point(197, 3);
            this.btnRight25.Name = "btnRight25";
            this.btnRight25.Size = new System.Drawing.Size(24, 23);
            this.btnRight25.TabIndex = 3;
            this.btnRight25.Text = "V";
            this.btnRight25.UseVisualStyleBackColor = true;
            this.btnRight25.Click += new System.EventHandler(this.btnRight25_Click);
            // 
            // btnLeft50
            // 
            this.btnLeft50.Location = new System.Drawing.Point(130, 3);
            this.btnLeft50.Name = "btnLeft50";
            this.btnLeft50.Size = new System.Drawing.Size(24, 23);
            this.btnLeft50.TabIndex = 2;
            this.btnLeft50.Text = "V";
            this.btnLeft50.UseVisualStyleBackColor = true;
            this.btnLeft50.Click += new System.EventHandler(this.btnLeft50_Click);
            // 
            // howto_adjust_splitter_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 264);
            this.Controls.Add(this.SplitContainer1);
            this.Controls.Add(this.Panel1);
            this.Name = "howto_adjust_splitter_Form1";
            this.Text = "howto_adjust_splitter";
            this.SplitContainer1.ResumeLayout(false);
            this.Panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.SplitContainer SplitContainer1;
        internal System.Windows.Forms.Panel Panel1;
        internal System.Windows.Forms.Button btnCloseRight;
        internal System.Windows.Forms.Button btnCloseLeft;
        internal System.Windows.Forms.Button btnLeft25;
        internal System.Windows.Forms.Button btnRight25;
        internal System.Windows.Forms.Button btnLeft50;
    }
}

