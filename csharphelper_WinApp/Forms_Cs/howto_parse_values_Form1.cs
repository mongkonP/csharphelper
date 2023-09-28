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
     public partial class howto_parse_values_Form1:Form
  { 


        public howto_parse_values_Form1()
        {
            InitializeComponent();
        }

        // Enter values to parse.
        private void howto_parse_values_Form1_Load(object sender, EventArgs e)
        {
            txtInt.Text = "2147483647";
            txtLong.Text = "9223372036854775807";
            txtDecimal.Text = "$-12.34";
            txtDecimal2.Text = "$-12.34";
            txtDateTime.Text = "1 April 2010 23:45:12.34567";
        }

        // Parse an int.
        private void txtInt_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int value = int.Parse(txtInt.Text);
                lblInt.Text = value.ToString();
            }
            catch
            {
                lblInt.Text = "Error";
            }
        }

        // Parse a long.
        private void txtLong_TextChanged(object sender, EventArgs e)
        {
            try
            {
                long value = long.Parse(txtLong.Text);
                lblLong.Text = value.ToString();
            }
            catch
            {
                lblLong.Text = "Error";
            }
        }

        // Parse a decimal normally.
        private void txtDecimal_TextChanged(object sender, EventArgs e)
        {
            try
            {
                decimal value = decimal.Parse(txtDecimal.Text);
                lblDecimal.Text = value.ToString();
            }
            catch
            {
                lblDecimal.Text = "Error";
            }
        }

        // Parse a decimal with any format.
        private void txtDecimal2_TextChanged(object sender, EventArgs e)
        {
            try
            {
                decimal value = decimal.Parse(
                    txtDecimal2.Text, 
                    System.Globalization.NumberStyles.Any);
                lblDecimal2.Text = value.ToString();
            }
            catch
            {
                lblDecimal2.Text = "Error";
            }
        }

        // Parse a DateTime.
        private void txtDateTime_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DateTime value = DateTime.Parse(txtDateTime.Text);
                lblDateTime.Text = value.ToString();
            }
            catch
            {
                lblDateTime.Text = "Error";
            }
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
            this.txtInt = new System.Windows.Forms.TextBox();
            this.txtLong = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDecimal2 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDecimal = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lblInt = new System.Windows.Forms.Label();
            this.lblLong = new System.Windows.Forms.Label();
            this.lblDecimal2 = new System.Windows.Forms.Label();
            this.lblDecimal = new System.Windows.Forms.Label();
            this.lblDateTime = new System.Windows.Forms.Label();
            this.txtDateTime = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(18, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "int";
            // 
            // txtInt
            // 
            this.txtInt.Location = new System.Drawing.Point(71, 12);
            this.txtInt.Name = "txtInt";
            this.txtInt.Size = new System.Drawing.Size(200, 20);
            this.txtInt.TabIndex = 0;
            this.txtInt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtInt.TextChanged += new System.EventHandler(this.txtInt_TextChanged);
            // 
            // txtLong
            // 
            this.txtLong.Location = new System.Drawing.Point(71, 38);
            this.txtLong.Name = "txtLong";
            this.txtLong.Size = new System.Drawing.Size(200, 20);
            this.txtLong.TabIndex = 1;
            this.txtLong.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtLong.TextChanged += new System.EventHandler(this.txtLong_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(27, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "long";
            // 
            // txtDecimal2
            // 
            this.txtDecimal2.Location = new System.Drawing.Point(71, 90);
            this.txtDecimal2.Name = "txtDecimal2";
            this.txtDecimal2.Size = new System.Drawing.Size(200, 20);
            this.txtDecimal2.TabIndex = 3;
            this.txtDecimal2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtDecimal2.TextChanged += new System.EventHandler(this.txtDecimal2_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 93);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "decimal";
            // 
            // txtDecimal
            // 
            this.txtDecimal.Location = new System.Drawing.Point(71, 64);
            this.txtDecimal.Name = "txtDecimal";
            this.txtDecimal.Size = new System.Drawing.Size(200, 20);
            this.txtDecimal.TabIndex = 2;
            this.txtDecimal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtDecimal.TextChanged += new System.EventHandler(this.txtDecimal_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 67);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "decimal";
            // 
            // lblInt
            // 
            this.lblInt.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblInt.Location = new System.Drawing.Point(277, 12);
            this.lblInt.Name = "lblInt";
            this.lblInt.Size = new System.Drawing.Size(200, 20);
            this.lblInt.TabIndex = 8;
            this.lblInt.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblLong
            // 
            this.lblLong.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblLong.Location = new System.Drawing.Point(277, 38);
            this.lblLong.Name = "lblLong";
            this.lblLong.Size = new System.Drawing.Size(200, 20);
            this.lblLong.TabIndex = 9;
            this.lblLong.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblDecimal2
            // 
            this.lblDecimal2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblDecimal2.Location = new System.Drawing.Point(277, 90);
            this.lblDecimal2.Name = "lblDecimal2";
            this.lblDecimal2.Size = new System.Drawing.Size(200, 20);
            this.lblDecimal2.TabIndex = 11;
            this.lblDecimal2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblDecimal
            // 
            this.lblDecimal.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblDecimal.Location = new System.Drawing.Point(277, 64);
            this.lblDecimal.Name = "lblDecimal";
            this.lblDecimal.Size = new System.Drawing.Size(200, 20);
            this.lblDecimal.TabIndex = 10;
            this.lblDecimal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblDateTime
            // 
            this.lblDateTime.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblDateTime.Location = new System.Drawing.Point(277, 116);
            this.lblDateTime.Name = "lblDateTime";
            this.lblDateTime.Size = new System.Drawing.Size(200, 20);
            this.lblDateTime.TabIndex = 16;
            // 
            // txtDateTime
            // 
            this.txtDateTime.Location = new System.Drawing.Point(71, 116);
            this.txtDateTime.Name = "txtDateTime";
            this.txtDateTime.Size = new System.Drawing.Size(200, 20);
            this.txtDateTime.TabIndex = 4;
            this.txtDateTime.TextChanged += new System.EventHandler(this.txtDateTime_TextChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 119);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 13);
            this.label8.TabIndex = 12;
            this.label8.Text = "DateTime";
            // 
            // howto_parse_values_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(491, 149);
            this.Controls.Add(this.lblDateTime);
            this.Controls.Add(this.txtDateTime);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.lblDecimal2);
            this.Controls.Add(this.lblDecimal);
            this.Controls.Add(this.lblLong);
            this.Controls.Add(this.lblInt);
            this.Controls.Add(this.txtDecimal2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtDecimal);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtLong);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtInt);
            this.Controls.Add(this.label1);
            this.Name = "howto_parse_values_Form1";
            this.Text = "howto_parse_values";
            this.Load += new System.EventHandler(this.howto_parse_values_Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtInt;
        private System.Windows.Forms.TextBox txtLong;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDecimal2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtDecimal;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblInt;
        private System.Windows.Forms.Label lblLong;
        private System.Windows.Forms.Label lblDecimal2;
        private System.Windows.Forms.Label lblDecimal;
        private System.Windows.Forms.Label lblDateTime;
        private System.Windows.Forms.TextBox txtDateTime;
        private System.Windows.Forms.Label label8;
    }
}

