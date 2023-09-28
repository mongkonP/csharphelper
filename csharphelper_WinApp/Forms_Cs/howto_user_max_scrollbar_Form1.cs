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
     public partial class howto_user_max_scrollbar_Form1:Form
  { 


        public howto_user_max_scrollbar_Form1()
        {
            InitializeComponent();
        }

        // Display the ScrollBars' values.
        private void hscr1_Scroll(object sender, ScrollEventArgs e)
        {
            lblValue1.Text = "Value: " + hscr1.Value.ToString();
        }

        private void hscr2_Scroll(object sender, ScrollEventArgs e)
        {
            lblValue2.Text = "Value: " + hscr2.Value.ToString();
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
            this.lblValue2 = new System.Windows.Forms.Label();
            this.Label3 = new System.Windows.Forms.Label();
            this.hscr2 = new System.Windows.Forms.HScrollBar();
            this.lblValue1 = new System.Windows.Forms.Label();
            this.Label1 = new System.Windows.Forms.Label();
            this.hscr1 = new System.Windows.Forms.HScrollBar();
            this.SuspendLayout();
            // 
            // lblValue2
            // 
            this.lblValue2.AutoSize = true;
            this.lblValue2.Location = new System.Drawing.Point(12, 139);
            this.lblValue2.Name = "lblValue2";
            this.lblValue2.Size = new System.Drawing.Size(46, 13);
            this.lblValue2.TabIndex = 19;
            this.lblValue2.Text = "Value: 0";
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.Location = new System.Drawing.Point(12, 91);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(326, 13);
            this.Label3.TabIndex = 18;
            this.Label3.Text = "Minimum = 0, Maximum = 109, SmallChange = 1, LargeChange  =10";
            // 
            // hscr2
            // 
            this.hscr2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.hscr2.Location = new System.Drawing.Point(9, 113);
            this.hscr2.Maximum = 109;
            this.hscr2.Name = "hscr2";
            this.hscr2.Size = new System.Drawing.Size(365, 17);
            this.hscr2.TabIndex = 17;
            this.hscr2.Scroll += new System.Windows.Forms.ScrollEventHandler(this.hscr2_Scroll);
            // 
            // lblValue1
            // 
            this.lblValue1.AutoSize = true;
            this.lblValue1.Location = new System.Drawing.Point(11, 59);
            this.lblValue1.Name = "lblValue1";
            this.lblValue1.Size = new System.Drawing.Size(46, 13);
            this.lblValue1.TabIndex = 16;
            this.lblValue1.Text = "Value: 0";
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(11, 11);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(326, 13);
            this.Label1.TabIndex = 15;
            this.Label1.Text = "Minimum = 0, Maximum = 100, SmallChange = 1, LargeChange  =10";
            // 
            // hscr1
            // 
            this.hscr1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.hscr1.Location = new System.Drawing.Point(9, 33);
            this.hscr1.Name = "hscr1";
            this.hscr1.Size = new System.Drawing.Size(365, 17);
            this.hscr1.TabIndex = 14;
            this.hscr1.Scroll += new System.Windows.Forms.ScrollEventHandler(this.hscr1_Scroll);
            // 
            // howto_user_max_scrollbar_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 161);
            this.Controls.Add(this.lblValue2);
            this.Controls.Add(this.Label3);
            this.Controls.Add(this.hscr2);
            this.Controls.Add(this.lblValue1);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.hscr1);
            this.Name = "howto_user_max_scrollbar_Form1";
            this.Text = "howto_user_max_scrollbar";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Label lblValue2;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.HScrollBar hscr2;
        internal System.Windows.Forms.Label lblValue1;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.HScrollBar hscr1;
    }
}

