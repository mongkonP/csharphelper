using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

 

using howto_random_extensions;
namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_random_extensions_Form1:Form
  { 


        public howto_random_extensions_Form1()
        {
            InitializeComponent();
        }

        // The pseudo-random number generator.
        private Random rand = new Random();

        // Generate a random number between the minimum and maximum values.
        private void btnGenerate_Click(object sender, EventArgs e)
        {
            double min = double.Parse(txtMinimum.Text);
            double max = double.Parse(txtMaximum.Text);
            txtResult.Text = rand.NextDouble(min, max).ToString("0.00");
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
            this.txtResult = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.txtMaximum = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtMinimum = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtResult
            // 
            this.txtResult.Location = new System.Drawing.Point(72, 79);
            this.txtResult.Name = "txtResult";
            this.txtResult.ReadOnly = true;
            this.txtResult.Size = new System.Drawing.Size(100, 20);
            this.txtResult.TabIndex = 13;
            this.txtResult.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 82);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Result:";
            // 
            // btnGenerate
            // 
            this.btnGenerate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGenerate.Location = new System.Drawing.Point(237, 24);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(75, 23);
            this.btnGenerate.TabIndex = 11;
            this.btnGenerate.Text = "Generate";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // txtMaximum
            // 
            this.txtMaximum.Location = new System.Drawing.Point(72, 38);
            this.txtMaximum.Name = "txtMaximum";
            this.txtMaximum.Size = new System.Drawing.Size(100, 20);
            this.txtMaximum.TabIndex = 10;
            this.txtMaximum.Text = "100.0";
            this.txtMaximum.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Maximum:";
            // 
            // txtMinimum
            // 
            this.txtMinimum.Location = new System.Drawing.Point(72, 12);
            this.txtMinimum.Name = "txtMinimum";
            this.txtMinimum.Size = new System.Drawing.Size(100, 20);
            this.txtMinimum.TabIndex = 8;
            this.txtMinimum.Text = "0.0";
            this.txtMinimum.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Minimum:";
            // 
            // howto_random_extensions_Form1
            // 
            this.AcceptButton = this.btnGenerate;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(324, 111);
            this.Controls.Add(this.txtResult);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnGenerate);
            this.Controls.Add(this.txtMaximum);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtMinimum);
            this.Controls.Add(this.label1);
            this.Name = "howto_random_extensions_Form1";
            this.Text = "howto_random_extensions";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtResult;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.TextBox txtMaximum;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtMinimum;
        private System.Windows.Forms.Label label1;
    }
}

