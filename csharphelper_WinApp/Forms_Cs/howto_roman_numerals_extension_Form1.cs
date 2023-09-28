using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

 

using howto_roman_numerals_extension;
namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_roman_numerals_extension_Form1:Form
  { 


        public howto_roman_numerals_extension_Form1()
        {
            InitializeComponent();
        }

        // Convert.
        private void btnConvert_Click(object sender, EventArgs e)
        {
            // See if we have an Arabic or Roman input.
            if (txtArabic.Text.Length > 0)
            {
                int arabic = int.Parse(txtArabic.Text);
                string roman = arabic.ToRoman();
                int recovered = roman.ToArabic();

                txtRecoveredRoman.Text = roman;
                txtRecoveredArabic.Text = recovered.ToString();
            }
            else
            {
                string roman = txtRoman.Text;
                int arabic = roman.ToArabic();
                string recovered = arabic.ToRoman();

                txtRecoveredRoman.Text = recovered;
                txtRecoveredArabic.Text = arabic.ToString();
            }

            txtArabic.Clear();
            txtRoman.Clear();
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
            this.txtRecoveredRoman = new System.Windows.Forms.TextBox();
            this.txtRecoveredArabic = new System.Windows.Forms.TextBox();
            this.txtRoman = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnConvert = new System.Windows.Forms.Button();
            this.txtArabic = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtRecoveredRoman
            // 
            this.txtRecoveredRoman.Location = new System.Drawing.Point(151, 85);
            this.txtRecoveredRoman.Name = "txtRecoveredRoman";
            this.txtRecoveredRoman.ReadOnly = true;
            this.txtRecoveredRoman.Size = new System.Drawing.Size(129, 20);
            this.txtRecoveredRoman.TabIndex = 14;
            this.txtRecoveredRoman.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtRecoveredArabic
            // 
            this.txtRecoveredArabic.Location = new System.Drawing.Point(16, 85);
            this.txtRecoveredArabic.Name = "txtRecoveredArabic";
            this.txtRecoveredArabic.ReadOnly = true;
            this.txtRecoveredArabic.Size = new System.Drawing.Size(129, 20);
            this.txtRecoveredArabic.TabIndex = 13;
            this.txtRecoveredArabic.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtRoman
            // 
            this.txtRoman.AcceptsReturn = true;
            this.txtRoman.Location = new System.Drawing.Point(151, 30);
            this.txtRoman.Name = "txtRoman";
            this.txtRoman.Size = new System.Drawing.Size(129, 20);
            this.txtRoman.TabIndex = 10;
            this.txtRoman.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(148, 14);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 13);
            this.label4.TabIndex = 15;
            this.label4.Text = "Roman:";
            // 
            // btnConvert
            // 
            this.btnConvert.Location = new System.Drawing.Point(110, 56);
            this.btnConvert.Name = "btnConvert";
            this.btnConvert.Size = new System.Drawing.Size(75, 23);
            this.btnConvert.TabIndex = 11;
            this.btnConvert.Text = "Convert";
            this.btnConvert.UseVisualStyleBackColor = true;
            this.btnConvert.Click += new System.EventHandler(this.btnConvert_Click);
            // 
            // txtArabic
            // 
            this.txtArabic.Location = new System.Drawing.Point(16, 30);
            this.txtArabic.Name = "txtArabic";
            this.txtArabic.Size = new System.Drawing.Size(129, 20);
            this.txtArabic.TabIndex = 9;
            this.txtArabic.Text = "1984";
            this.txtArabic.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Arabic:";
            // 
            // howto_roman_numerals_extension_Form1
            // 
            this.AcceptButton = this.btnConvert;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(293, 118);
            this.Controls.Add(this.txtRecoveredRoman);
            this.Controls.Add(this.txtRecoveredArabic);
            this.Controls.Add(this.txtRoman);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnConvert);
            this.Controls.Add(this.txtArabic);
            this.Controls.Add(this.label2);
            this.Name = "howto_roman_numerals_extension_Form1";
            this.Text = "howto_roman_numerals_extension";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtRecoveredRoman;
        private System.Windows.Forms.TextBox txtRecoveredArabic;
        private System.Windows.Forms.TextBox txtRoman;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnConvert;
        private System.Windows.Forms.TextBox txtArabic;
        private System.Windows.Forms.Label label2;
    }
}

