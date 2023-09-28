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
     public partial class howto_linq_min_max_ave_Form1:Form
  { 


        public howto_linq_min_max_ave_Form1()
        {
            InitializeComponent();
        }

        // Make some random values.
        private void howto_linq_min_max_ave_Form1_Load(object sender, EventArgs e)
        {
            const int num_values = 50;
            Random rand = new Random();
            int[] values = new int[num_values];
            for (int i = 0; i < num_values; i++)
            {
                values[i] = rand.Next(0, 10000);
            }

            // Display the values.
            lstValues.DataSource = values;

            // Use LINQ extension methods to get
            // the minimum, maximum, and average values.
            txtMin.Text = values.Min().ToString();
            txtMax.Text = values.Max().ToString();
            txtAve.Text = values.Average().ToString();
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
            this.lstValues = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtMin = new System.Windows.Forms.TextBox();
            this.txtMax = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtAve = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lstValues
            // 
            this.lstValues.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lstValues.FormattingEnabled = true;
            this.lstValues.Location = new System.Drawing.Point(12, 12);
            this.lstValues.MultiColumn = true;
            this.lstValues.Name = "lstValues";
            this.lstValues.Size = new System.Drawing.Size(285, 121);
            this.lstValues.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 145);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(27, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Min:";
            // 
            // txtMin
            // 
            this.txtMin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtMin.Location = new System.Drawing.Point(48, 142);
            this.txtMin.Name = "txtMin";
            this.txtMin.Size = new System.Drawing.Size(46, 20);
            this.txtMin.TabIndex = 2;
            // 
            // txtMax
            // 
            this.txtMax.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtMax.Location = new System.Drawing.Point(147, 142);
            this.txtMax.Name = "txtMax";
            this.txtMax.Size = new System.Drawing.Size(46, 20);
            this.txtMax.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(111, 145);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Max:";
            // 
            // txtAve
            // 
            this.txtAve.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtAve.Location = new System.Drawing.Point(251, 142);
            this.txtAve.Name = "txtAve";
            this.txtAve.Size = new System.Drawing.Size(46, 20);
            this.txtAve.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(215, 145);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Ave:";
            // 
            // howto_linq_min_max_ave_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(309, 174);
            this.Controls.Add(this.txtAve);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtMax);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtMin);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lstValues);
            this.Name = "howto_linq_min_max_ave_Form1";
            this.Text = "howto_linq_min_max_ave";
            this.Load += new System.EventHandler(this.howto_linq_min_max_ave_Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lstValues;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtMin;
        private System.Windows.Forms.TextBox txtMax;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtAve;
        private System.Windows.Forms.Label label3;
    }
}

