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
     public partial class howto_understand_at_Form1:Form
  { 


        public howto_understand_at_Form1()
        {
            InitializeComponent();
        }

        private void howto_understand_at_Form1_Load(object sender, EventArgs e)
        {
            txtDoubleSlash.Text = "C:\\temp\\whatever";
            txtAtSign.Text = @"C:\temp\whatever";
            txtFirstLabel.Text = label1.Text;
            txtSecondLabel.Text = label2.Text;

            // Some poorly named variables that use @.
            string[] @foreach = { "A", "B", "C" };
            foreach (string _foreach in @foreach)
            {
                Console.WriteLine(_foreach);
            }

            // Adding an @ doesn't change a TextBox's contents.
            Console.WriteLine(txtDoubleSlash.Text);
            Console.WriteLine(@txtDoubleSlash.Text);
        }

        private void btnShowValue_Click(object sender, EventArgs e)
        {
            txtResult.Text = txtEnteredValue.Text;
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
            this.txtSecondLabel = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtFirstLabel = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtResult = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtEnteredValue = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnShowValue = new System.Windows.Forms.Button();
            this.txtAtSign = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDoubleSlash = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtSecondLabel
            // 
            this.txtSecondLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSecondLabel.Location = new System.Drawing.Point(133, 91);
            this.txtSecondLabel.Name = "txtSecondLabel";
            this.txtSecondLabel.Size = new System.Drawing.Size(149, 20);
            this.txtSecondLabel.TabIndex = 25;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 94);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(76, 13);
            this.label6.TabIndex = 24;
            this.label6.Text = "Second Label:";
            // 
            // txtFirstLabel
            // 
            this.txtFirstLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFirstLabel.Location = new System.Drawing.Point(133, 65);
            this.txtFirstLabel.Name = "txtFirstLabel";
            this.txtFirstLabel.Size = new System.Drawing.Size(149, 20);
            this.txtFirstLabel.TabIndex = 23;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 68);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 13);
            this.label5.TabIndex = 22;
            this.label5.Text = "First Label:";
            // 
            // txtResult
            // 
            this.txtResult.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtResult.Location = new System.Drawing.Point(140, 181);
            this.txtResult.Name = "txtResult";
            this.txtResult.ReadOnly = true;
            this.txtResult.Size = new System.Drawing.Size(142, 20);
            this.txtResult.TabIndex = 21;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 184);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 13);
            this.label4.TabIndex = 20;
            this.label4.Text = "Result:";
            // 
            // txtEnteredValue
            // 
            this.txtEnteredValue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtEnteredValue.Location = new System.Drawing.Point(133, 126);
            this.txtEnteredValue.Name = "txtEnteredValue";
            this.txtEnteredValue.Size = new System.Drawing.Size(149, 20);
            this.txtEnteredValue.TabIndex = 19;
            this.txtEnteredValue.Text = "Hello\\n\\tthere!";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 129);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 13);
            this.label3.TabIndex = 18;
            this.label3.Text = "Enter a Value:";
            // 
            // btnShowValue
            // 
            this.btnShowValue.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnShowValue.Location = new System.Drawing.Point(110, 152);
            this.btnShowValue.Name = "btnShowValue";
            this.btnShowValue.Size = new System.Drawing.Size(75, 23);
            this.btnShowValue.TabIndex = 17;
            this.btnShowValue.Text = "Show Value";
            this.btnShowValue.UseVisualStyleBackColor = true;
            this.btnShowValue.Click += new System.EventHandler(this.btnShowValue_Click);
            // 
            // txtAtSign
            // 
            this.txtAtSign.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAtSign.Location = new System.Drawing.Point(133, 39);
            this.txtAtSign.Name = "txtAtSign";
            this.txtAtSign.Size = new System.Drawing.Size(149, 20);
            this.txtAtSign.TabIndex = 16;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(115, 13);
            this.label2.TabIndex = 15;
            this.label2.Text = "@\"C:\\temp\\whatever\"";
            // 
            // txtDoubleSlash
            // 
            this.txtDoubleSlash.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDoubleSlash.Location = new System.Drawing.Point(133, 13);
            this.txtDoubleSlash.Name = "txtDoubleSlash";
            this.txtDoubleSlash.Size = new System.Drawing.Size(149, 20);
            this.txtDoubleSlash.TabIndex = 14;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "\"C:\\\\temp\\\\whatever\"";
            // 
            // howto_understand_at_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(294, 211);
            this.Controls.Add(this.txtSecondLabel);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtFirstLabel);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtResult);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtEnteredValue);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnShowValue);
            this.Controls.Add(this.txtAtSign);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtDoubleSlash);
            this.Controls.Add(this.label1);
            this.Name = "howto_understand_at_Form1";
            this.Text = "howto_understand_at";
            this.Load += new System.EventHandler(this.howto_understand_at_Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtSecondLabel;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtFirstLabel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtResult;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtEnteredValue;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnShowValue;
        private System.Windows.Forms.TextBox txtAtSign;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDoubleSlash;
        private System.Windows.Forms.Label label1;
    }
}

