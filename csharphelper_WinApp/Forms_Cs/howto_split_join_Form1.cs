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
     public partial class howto_split_join_Form1:Form
  { 


        public howto_split_join_Form1()
        {
            InitializeComponent();
        }

        // Split the values and then recombine them with Join.
        private void btnSplit_Click(object sender, EventArgs e)
        {
            // Get the string of values.
            string txt = txtValues.Text;

            // Split the values at spaces, removing duplicates.
            string[] values = txt.Split(new char[] { ' ' },
                StringSplitOptions.RemoveEmptyEntries);

            // Rejoin them.
            string result = String.Join(";", values);

            // Display the result.
            txtResult.Text = result;
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
            this.txtValues = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSplit = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtResult = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtValues
            // 
            this.txtValues.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtValues.Location = new System.Drawing.Point(60, 12);
            this.txtValues.Name = "txtValues";
            this.txtValues.Size = new System.Drawing.Size(297, 20);
            this.txtValues.TabIndex = 0;
            this.txtValues.Text = "When in worry or in doubt, run in circles scream and shout.";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Values:";
            // 
            // btnSplit
            // 
            this.btnSplit.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnSplit.Location = new System.Drawing.Point(147, 38);
            this.btnSplit.Name = "btnSplit";
            this.btnSplit.Size = new System.Drawing.Size(75, 23);
            this.btnSplit.TabIndex = 2;
            this.btnSplit.Text = "Split";
            this.btnSplit.UseVisualStyleBackColor = true;
            this.btnSplit.Click += new System.EventHandler(this.btnSplit_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Result:";
            // 
            // txtResult
            // 
            this.txtResult.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtResult.Location = new System.Drawing.Point(60, 67);
            this.txtResult.Name = "txtResult";
            this.txtResult.ReadOnly = true;
            this.txtResult.Size = new System.Drawing.Size(297, 20);
            this.txtResult.TabIndex = 3;
            // 
            // howto_split_join_Form1
            // 
            this.AcceptButton = this.btnSplit;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(369, 102);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtResult);
            this.Controls.Add(this.btnSplit);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtValues);
            this.Name = "howto_split_join_Form1";
            this.Text = "howto_split_join";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtValues;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSplit;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtResult;
    }
}

