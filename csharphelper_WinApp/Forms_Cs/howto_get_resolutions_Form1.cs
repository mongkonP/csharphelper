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
     public partial class howto_get_resolutions_Form1:Form
  { 


        public howto_get_resolutions_Form1()
        {
            InitializeComponent();
        }

        private void howto_get_resolutions_Form1_Load(object sender, EventArgs e)
        {
            using (Graphics gr = this.CreateGraphics())
            {
                txtScreenHorizontal.Text = gr.DpiX.ToString() + " dpi";
                txtScreenVertical.Text = gr.DpiY.ToString() + " dpi";
            }
            txtScreenHorizontal.Select(0, 0);
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
            this.txtScreenHorizontal = new System.Windows.Forms.TextBox();
            this.txtScreenVertical = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtScreenHorizontal
            // 
            this.txtScreenHorizontal.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtScreenHorizontal.Location = new System.Drawing.Point(154, 12);
            this.txtScreenHorizontal.Name = "txtScreenHorizontal";
            this.txtScreenHorizontal.ReadOnly = true;
            this.txtScreenHorizontal.Size = new System.Drawing.Size(54, 20);
            this.txtScreenHorizontal.TabIndex = 5;
            // 
            // txtScreenVertical
            // 
            this.txtScreenVertical.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtScreenVertical.Location = new System.Drawing.Point(154, 38);
            this.txtScreenVertical.Name = "txtScreenVertical";
            this.txtScreenVertical.ReadOnly = true;
            this.txtScreenVertical.Size = new System.Drawing.Size(54, 20);
            this.txtScreenVertical.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(91, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Horizontal:";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(91, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Vertical:";
            // 
            // howto_get_resolutions_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(299, 71);
            this.Controls.Add(this.txtScreenHorizontal);
            this.Controls.Add(this.txtScreenVertical);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Name = "howto_get_resolutions_Form1";
            this.Text = "howto_get_resolutions";
            this.Load += new System.EventHandler(this.howto_get_resolutions_Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtScreenHorizontal;
        private System.Windows.Forms.TextBox txtScreenVertical;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}

