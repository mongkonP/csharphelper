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
     public partial class howto_loop_over_controls_Form1:Form
  { 


        public howto_loop_over_controls_Form1()
        {
            InitializeComponent();
        }

        private void btnAll_Click(object sender, EventArgs e)
        {
            lstControls.Items.Clear();
            foreach (Control control in Controls)
                lstControls.Items.Add(control.Name);
        }

        private void btnHScrollBar_Click(object sender, EventArgs e)
        {
            lstControls.Items.Clear();
            foreach (HScrollBar hbar in Controls.OfType<HScrollBar>())
                lstControls.Items.Add(hbar.Name);
        }

        private void btnScrollBar_Click(object sender, EventArgs e)
        {
            lstControls.Items.Clear();
            foreach (ScrollBar sbar in Controls.OfType<ScrollBar>())
                lstControls.Items.Add(sbar.Name);
        }

        private void btnButton_Click(object sender, EventArgs e)
        {
            lstControls.Items.Clear();
            foreach (Button btn in Controls.OfType<Button>())
                lstControls.Items.Add(btn.Name);
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
            this.btnHScrollBar = new System.Windows.Forms.Button();
            this.btnScrollBar = new System.Windows.Forms.Button();
            this.btnAll = new System.Windows.Forms.Button();
            this.lstControls = new System.Windows.Forms.ListBox();
            this.vScrollBar1 = new System.Windows.Forms.VScrollBar();
            this.hScrollBar1 = new System.Windows.Forms.HScrollBar();
            this.btnButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnHScrollBar
            // 
            this.btnHScrollBar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnHScrollBar.Location = new System.Drawing.Point(227, 41);
            this.btnHScrollBar.Name = "btnHScrollBar";
            this.btnHScrollBar.Size = new System.Drawing.Size(75, 23);
            this.btnHScrollBar.TabIndex = 1;
            this.btnHScrollBar.Text = "HScrollBar";
            this.btnHScrollBar.UseVisualStyleBackColor = true;
            this.btnHScrollBar.Click += new System.EventHandler(this.btnHScrollBar_Click);
            // 
            // btnScrollBar
            // 
            this.btnScrollBar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnScrollBar.Location = new System.Drawing.Point(227, 70);
            this.btnScrollBar.Name = "btnScrollBar";
            this.btnScrollBar.Size = new System.Drawing.Size(75, 23);
            this.btnScrollBar.TabIndex = 2;
            this.btnScrollBar.Text = "ScrollBar";
            this.btnScrollBar.UseVisualStyleBackColor = true;
            this.btnScrollBar.Click += new System.EventHandler(this.btnScrollBar_Click);
            // 
            // btnAll
            // 
            this.btnAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAll.Location = new System.Drawing.Point(227, 12);
            this.btnAll.Name = "btnAll";
            this.btnAll.Size = new System.Drawing.Size(75, 23);
            this.btnAll.TabIndex = 0;
            this.btnAll.Text = "All";
            this.btnAll.UseVisualStyleBackColor = true;
            this.btnAll.Click += new System.EventHandler(this.btnAll_Click);
            // 
            // lstControls
            // 
            this.lstControls.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lstControls.FormattingEnabled = true;
            this.lstControls.IntegralHeight = false;
            this.lstControls.Location = new System.Drawing.Point(12, 99);
            this.lstControls.Name = "lstControls";
            this.lstControls.Size = new System.Drawing.Size(209, 111);
            this.lstControls.TabIndex = 6;
            // 
            // vScrollBar1
            // 
            this.vScrollBar1.Location = new System.Drawing.Point(12, 9);
            this.vScrollBar1.Name = "vScrollBar1";
            this.vScrollBar1.Size = new System.Drawing.Size(17, 80);
            this.vScrollBar1.TabIndex = 4;
            // 
            // hScrollBar1
            // 
            this.hScrollBar1.Location = new System.Drawing.Point(49, 9);
            this.hScrollBar1.Name = "hScrollBar1";
            this.hScrollBar1.Size = new System.Drawing.Size(80, 17);
            this.hScrollBar1.TabIndex = 5;
            // 
            // btnButton
            // 
            this.btnButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnButton.Location = new System.Drawing.Point(227, 99);
            this.btnButton.Name = "btnButton";
            this.btnButton.Size = new System.Drawing.Size(75, 23);
            this.btnButton.TabIndex = 3;
            this.btnButton.Text = "Button";
            this.btnButton.UseVisualStyleBackColor = true;
            this.btnButton.Click += new System.EventHandler(this.btnButton_Click);
            // 
            // howto_loop_over_controls_Form1
            // 
            this.AcceptButton = this.btnAll;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(314, 222);
            this.Controls.Add(this.btnButton);
            this.Controls.Add(this.hScrollBar1);
            this.Controls.Add(this.vScrollBar1);
            this.Controls.Add(this.lstControls);
            this.Controls.Add(this.btnAll);
            this.Controls.Add(this.btnScrollBar);
            this.Controls.Add(this.btnHScrollBar);
            this.Name = "howto_loop_over_controls_Form1";
            this.Text = "howto_loop_over_controls";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnHScrollBar;
        private System.Windows.Forms.Button btnScrollBar;
        private System.Windows.Forms.Button btnAll;
        private System.Windows.Forms.ListBox lstControls;
        private System.Windows.Forms.VScrollBar vScrollBar1;
        private System.Windows.Forms.HScrollBar hScrollBar1;
        private System.Windows.Forms.Button btnButton;
    }
}

