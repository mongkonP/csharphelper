using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.IO;
using System.Text.RegularExpressions;

 

namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_search_pi_Form1:Form
  { 


        public howto_search_pi_Form1()
        {
            InitializeComponent();
        }

        // The digits of pi.
        private string Pi;

        // Load the digits of pi.
        private void howto_search_pi_Form1_Load(object sender, EventArgs e)
        {
            Pi = File.ReadAllText("Pi.txt");
            rchPi.Text = Pi;
            rchPi.Select(0, 0);
            lblPosition.Text = "";
        }

        // Search for a pattern.
        private void btnSearch_Click(object sender, EventArgs e)
        {
            // Get the pattern.
            string pattern = txtPattern.Text;

            // Remove all non-digits.
            Regex reg_exp = new Regex("[^0-9]");
            pattern = reg_exp.Replace(pattern, "");

            // Search for the pattern.
            int position = Pi.IndexOf(pattern);

            // Display the result.
            rchPi.Text = Pi;
            if (position < 0)
                lblPosition.Text = pattern + " was not found";
            else
            {
                lblPosition.Text = pattern + " found at digit " + position.ToString();
                rchPi.Select(position, pattern.Length);
                rchPi.SelectionBackColor = Color.Yellow;
                rchPi.SelectionColor = Color.Red;
                rchPi.ScrollToCaret();
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
            this.txtPattern = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.rchPi = new System.Windows.Forms.RichTextBox();
            this.lblPosition = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Pattern:";
            // 
            // txtPattern
            // 
            this.txtPattern.Location = new System.Drawing.Point(62, 14);
            this.txtPattern.Name = "txtPattern";
            this.txtPattern.Size = new System.Drawing.Size(100, 20);
            this.txtPattern.TabIndex = 1;
            this.txtPattern.Text = "9/25";
            this.txtPattern.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(197, 12);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // rchPi
            // 
            this.rchPi.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.rchPi.Location = new System.Drawing.Point(12, 40);
            this.rchPi.Name = "rchPi";
            this.rchPi.Size = new System.Drawing.Size(260, 196);
            this.rchPi.TabIndex = 3;
            this.rchPi.Text = "";
            // 
            // lblPosition
            // 
            this.lblPosition.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblPosition.AutoSize = true;
            this.lblPosition.Location = new System.Drawing.Point(12, 239);
            this.lblPosition.Name = "lblPosition";
            this.lblPosition.Size = new System.Drawing.Size(54, 13);
            this.lblPosition.TabIndex = 4;
            this.lblPosition.Text = "lblPosition";
            // 
            // howto_search_pi_Form1
            // 
            this.AcceptButton = this.btnSearch;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.lblPosition);
            this.Controls.Add(this.rchPi);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.txtPattern);
            this.Controls.Add(this.label1);
            this.Name = "howto_search_pi_Form1";
            this.Text = "howto_search_pi";
            this.Load += new System.EventHandler(this.howto_search_pi_Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPattern;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.RichTextBox rchPi;
        private System.Windows.Forms.Label lblPosition;
    }
}

