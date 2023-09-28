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
     public partial class howto_floats_equal_Form1:Form
  { 


        public howto_floats_equal_Form1()
        {
            InitializeComponent();
        }

        private void howto_floats_equal_Form1_Load(object sender, EventArgs e)
        {
            float A = 5.7f;
            float B = 12f;
            float A_times_B = A * B;
            txtAtimesB.Text = A_times_B.ToString();

            bool equals1 = (A_times_B == 68.4f);
            txtEquals1.Text = equals1.ToString();

            bool equals2 = Math.Abs(A_times_B - 68.4f) < 0.00001;
            txtEquals2.Text = equals2.ToString();
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
            this.txtEquals2 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtEquals1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtAtimesB = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtEquals2
            // 
            this.txtEquals2.Location = new System.Drawing.Point(199, 63);
            this.txtEquals2.Name = "txtEquals2";
            this.txtEquals2.ReadOnly = true;
            this.txtEquals2.Size = new System.Drawing.Size(62, 20);
            this.txtEquals2.TabIndex = 12;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 66);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(180, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Math.Abs(A_times_B - 68.4f) < 0.001";
            // 
            // txtEquals1
            // 
            this.txtEquals1.Location = new System.Drawing.Point(199, 37);
            this.txtEquals1.Name = "txtEquals1";
            this.txtEquals1.ReadOnly = true;
            this.txtEquals1.Size = new System.Drawing.Size(62, 20);
            this.txtEquals1.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "(A_times_B == 68.4f)";
            // 
            // txtAtimesB
            // 
            this.txtAtimesB.Location = new System.Drawing.Point(199, 11);
            this.txtAtimesB.Name = "txtAtimesB";
            this.txtAtimesB.ReadOnly = true;
            this.txtAtimesB.Size = new System.Drawing.Size(62, 20);
            this.txtAtimesB.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "A * B";
            // 
            // howto_floats_equal_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(274, 94);
            this.Controls.Add(this.txtEquals2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtEquals1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtAtimesB);
            this.Controls.Add(this.label1);
            this.Name = "howto_floats_equal_Form1";
            this.Text = "howto_floats_equal";
            this.Load += new System.EventHandler(this.howto_floats_equal_Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtEquals2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtEquals1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtAtimesB;
        private System.Windows.Forms.Label label1;
    }
}

