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
     public partial class howto_test_numeric_Form1:Form
  { 


        public howto_test_numeric_Form1()
        {
            InitializeComponent();
        }

        // See if the text is an int.
        private void txtInteger_TextChanged(object sender, EventArgs e)
        {
            int value;
            if (int.TryParse(txtInteger.Text, out value))
                txtInteger.BackColor = Color.White;
            else
                txtInteger.BackColor = Color.Yellow;
        }

        // See if the text is a float.
        private void txtFloat_TextChanged(object sender, EventArgs e)
        {
            float value;
            if (float.TryParse(txtFloat.Text, out value))
                txtFloat.BackColor = Color.White;
            else
                txtFloat.BackColor = Color.Yellow;
        }

        // See if the text is a bool.
        private void txtBool_TextChanged(object sender, EventArgs e)
        {
            bool value;
            if (bool.TryParse(txtBool.Text, out value))
                txtBool.BackColor = Color.White;
            else
                txtBool.BackColor = Color.Yellow;
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtInteger = new System.Windows.Forms.TextBox();
            this.txtFloat = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtBool = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(71, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Integer:";
            // 
            // txtInteger
            // 
            this.txtInteger.Location = new System.Drawing.Point(124, 12);
            this.txtInteger.Name = "txtInteger";
            this.txtInteger.Size = new System.Drawing.Size(89, 20);
            this.txtInteger.TabIndex = 1;
            this.txtInteger.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtInteger.TextChanged += new System.EventHandler(this.txtInteger_TextChanged);
            // 
            // txtFloat
            // 
            this.txtFloat.Location = new System.Drawing.Point(124, 38);
            this.txtFloat.Name = "txtFloat";
            this.txtFloat.Size = new System.Drawing.Size(89, 20);
            this.txtFloat.TabIndex = 3;
            this.txtFloat.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtFloat.TextChanged += new System.EventHandler(this.txtFloat_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(71, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Float:";
            // 
            // txtBool
            // 
            this.txtBool.Location = new System.Drawing.Point(124, 64);
            this.txtBool.Name = "txtBool";
            this.txtBool.Size = new System.Drawing.Size(89, 20);
            this.txtBool.TabIndex = 5;
            this.txtBool.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtBool.TextChanged += new System.EventHandler(this.txtBool_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(71, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Boolean:";
            // 
            // howto_test_numeric_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 103);
            this.Controls.Add(this.txtBool);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtFloat);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtInteger);
            this.Controls.Add(this.label1);
            this.Name = "howto_test_numeric_Form1";
            this.Text = "howto_test_numeric";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtInteger;
        private System.Windows.Forms.TextBox txtFloat;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtBool;
        private System.Windows.Forms.Label label3;
    }
}

