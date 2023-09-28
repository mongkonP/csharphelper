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
     public partial class howto_scrollbar_select_fraction_Form1:Form
  { 


        public howto_scrollbar_select_fraction_Form1()
        {
            InitializeComponent();
        }

        // Display the 1st selected value.
        private void scrValue_Scroll(object sender, ScrollEventArgs e)
        {
            float value = scrValue1.Value / 100f;
            lblValue1.Text = value.ToString("0.00");
        }

        // Display the 2nd selected value.
        private void scrValue2_Scroll(object sender, ScrollEventArgs e)
        {
            float value = scrValue2.Value / 100f;
            lblValue2.Text = value.ToString("0.00");
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
            this.lblValue1 = new System.Windows.Forms.Label();
            this.scrValue1 = new System.Windows.Forms.HScrollBar();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblValue2 = new System.Windows.Forms.Label();
            this.scrValue2 = new System.Windows.Forms.HScrollBar();
            this.SuspendLayout();
            // 
            // lblValue1
            // 
            this.lblValue1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblValue1.Location = new System.Drawing.Point(285, 27);
            this.lblValue1.Name = "lblValue1";
            this.lblValue1.Size = new System.Drawing.Size(47, 17);
            this.lblValue1.TabIndex = 4;
            this.lblValue1.Text = "0.00";
            this.lblValue1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // scrValue1
            // 
            this.scrValue1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.scrValue1.LargeChange = 100;
            this.scrValue1.Location = new System.Drawing.Point(9, 27);
            this.scrValue1.Maximum = 10099;
            this.scrValue1.Name = "scrValue1";
            this.scrValue1.Size = new System.Drawing.Size(273, 17);
            this.scrValue1.TabIndex = 3;
            this.scrValue1.Scroll += new System.Windows.Forms.ScrollEventHandler(this.scrValue_Scroll);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "0 - 100";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "50 - 100";
            // 
            // lblValue2
            // 
            this.lblValue2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblValue2.Location = new System.Drawing.Point(285, 79);
            this.lblValue2.Name = "lblValue2";
            this.lblValue2.Size = new System.Drawing.Size(47, 17);
            this.lblValue2.TabIndex = 7;
            this.lblValue2.Text = "50.00";
            this.lblValue2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // scrValue2
            // 
            this.scrValue2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.scrValue2.LargeChange = 100;
            this.scrValue2.Location = new System.Drawing.Point(9, 79);
            this.scrValue2.Maximum = 10099;
            this.scrValue2.Minimum = 5000;
            this.scrValue2.Name = "scrValue2";
            this.scrValue2.Size = new System.Drawing.Size(273, 17);
            this.scrValue2.TabIndex = 6;
            this.scrValue2.Value = 5000;
            this.scrValue2.Scroll += new System.Windows.Forms.ScrollEventHandler(this.scrValue2_Scroll);
            // 
            // howto_scrollbar_select_fraction_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(344, 114);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblValue2);
            this.Controls.Add(this.scrValue2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblValue1);
            this.Controls.Add(this.scrValue1);
            this.Name = "howto_scrollbar_select_fraction_Form1";
            this.Text = "howto_scrollbar_select_fraction";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblValue1;
        private System.Windows.Forms.HScrollBar scrValue1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblValue2;
        private System.Windows.Forms.HScrollBar scrValue2;
    }
}

