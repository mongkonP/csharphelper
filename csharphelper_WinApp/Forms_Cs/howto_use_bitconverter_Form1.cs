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
     public partial class howto_use_bitconverter_Form1:Form
  { 


        public howto_use_bitconverter_Form1()
        {
            InitializeComponent();
        }

        private void howto_use_bitconverter_Form1_Load(object sender, EventArgs e)
        {
            // Initialize a byte array.
            byte[] bytes = { 121, 222, 111, 212 };
            string txt = "";
            for (int i = 0; i < bytes.Length; i++)
            {
                txt += bytes[i].ToString() + " ";
            }
            txtBytes1.Text = txt;

            // Convert to an integer.
            int int_value = BitConverter.ToInt32(bytes, 0);
            txtInteger.Text = int_value.ToString();

            // Convert back to a byte array.
            byte[] new_bytes = BitConverter.GetBytes(int_value);
            txt = "";
            for (int i = 0; i < new_bytes.Length; i++)
            {
                txt += new_bytes[i].ToString() + " ";
            }
            txtBytes2.Text = txt;
            txtBytes1.Select(0, 0);
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
            this.label3 = new System.Windows.Forms.Label();
            this.txtBytes2 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtInteger = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtBytes1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(224, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 23);
            this.label3.TabIndex = 13;
            this.label3.Text = "Bytes";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtBytes2
            // 
            this.txtBytes2.Location = new System.Drawing.Point(224, 9);
            this.txtBytes2.Name = "txtBytes2";
            this.txtBytes2.ReadOnly = true;
            this.txtBytes2.Size = new System.Drawing.Size(100, 20);
            this.txtBytes2.TabIndex = 12;
            this.txtBytes2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(118, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 23);
            this.label2.TabIndex = 11;
            this.label2.Text = "Integer";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtInteger
            // 
            this.txtInteger.Location = new System.Drawing.Point(118, 9);
            this.txtInteger.Name = "txtInteger";
            this.txtInteger.ReadOnly = true;
            this.txtInteger.Size = new System.Drawing.Size(100, 20);
            this.txtInteger.TabIndex = 10;
            this.txtInteger.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(12, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 23);
            this.label1.TabIndex = 9;
            this.label1.Text = "Bytes";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtBytes1
            // 
            this.txtBytes1.Location = new System.Drawing.Point(12, 9);
            this.txtBytes1.Name = "txtBytes1";
            this.txtBytes1.ReadOnly = true;
            this.txtBytes1.Size = new System.Drawing.Size(100, 20);
            this.txtBytes1.TabIndex = 8;
            this.txtBytes1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // howto_use_bitconverter_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(336, 65);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtBytes2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtInteger);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtBytes1);
            this.Name = "howto_use_bitconverter_Form1";
            this.Text = "howto_use_bitconverter";
            this.Load += new System.EventHandler(this.howto_use_bitconverter_Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtBytes2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtInteger;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtBytes1;
    }
}

