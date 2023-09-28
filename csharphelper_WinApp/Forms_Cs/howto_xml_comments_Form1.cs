using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

 

using howto_xml_comments;
namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_xml_comments_Form1:Form
  { 


        /// <summary>
        /// Initialize the form. (Because this is automatically generated code
        /// you might think it would automatically generate the XML comment
        /// but it doesn't.)
        /// </summary>
        public howto_xml_comments_Form1()
        {
            InitializeComponent();
        }

        // Make a TestScore object and see what grade the student would get.
        private void btnCalculate_Click(object sender, EventArgs e)
        {
            int test_number = int.Parse(txtTestNumber.Text);
            int score = int.Parse(txtScore.Text);
            TestScore test_score = new TestScore(test_number, score);
            MessageBox.Show(test_score.Grade(null, null));
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
            this.lblResult = new System.Windows.Forms.Label();
            this.btnCalculate = new System.Windows.Forms.Button();
            this.txtScore = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTestNumber = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblResult
            // 
            this.lblResult.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblResult.Location = new System.Drawing.Point(12, 74);
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size(270, 18);
            this.lblResult.TabIndex = 11;
            this.lblResult.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnCalculate
            // 
            this.btnCalculate.Location = new System.Drawing.Point(169, 23);
            this.btnCalculate.Name = "btnCalculate";
            this.btnCalculate.Size = new System.Drawing.Size(75, 23);
            this.btnCalculate.TabIndex = 10;
            this.btnCalculate.Text = "Calculate";
            this.btnCalculate.UseVisualStyleBackColor = true;
            this.btnCalculate.Click += new System.EventHandler(this.btnCalculate_Click);
            // 
            // txtScore
            // 
            this.txtScore.Location = new System.Drawing.Point(89, 36);
            this.txtScore.Name = "txtScore";
            this.txtScore.Size = new System.Drawing.Size(49, 20);
            this.txtScore.TabIndex = 9;
            this.txtScore.Text = "88";
            this.txtScore.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Score:";
            // 
            // txtTestNumber
            // 
            this.txtTestNumber.Location = new System.Drawing.Point(89, 10);
            this.txtTestNumber.Name = "txtTestNumber";
            this.txtTestNumber.Size = new System.Drawing.Size(49, 20);
            this.txtTestNumber.TabIndex = 7;
            this.txtTestNumber.Text = "1";
            this.txtTestNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Test Number:";
            // 
            // howto_xml_comments_Form1
            // 
            this.AcceptButton = this.btnCalculate;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(294, 101);
            this.Controls.Add(this.lblResult);
            this.Controls.Add(this.btnCalculate);
            this.Controls.Add(this.txtScore);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtTestNumber);
            this.Controls.Add(this.label1);
            this.Name = "howto_xml_comments_Form1";
            this.Text = "howto_xml_comments";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblResult;
        private System.Windows.Forms.Button btnCalculate;
        private System.Windows.Forms.TextBox txtScore;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtTestNumber;
        private System.Windows.Forms.Label label1;
    }
}

