using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.IO;

 

namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_all_pi_patterns_Form1:Form
  { 


        public howto_all_pi_patterns_Form1()
        {
            InitializeComponent();
        }

        // The digits of pi.
        private string Pi;

        // Load the digits of pi.
        private void howto_all_pi_patterns_Form1_Load(object sender, EventArgs e)
        {
            Pi = File.ReadAllText("Pi.txt");
            lblResults.Text = "";
        }

        // Search for all dates.
        private void btnCheck_Click(object sender, EventArgs e)
        {
            lstResults.Items.Clear();

            int found = 0;
            int not_found = 0;
            int biggest = -1;
            DateTime date = new DateTime(DateTime.Now.Year, 1, 1);
            DateTime end_date = new DateTime(DateTime.Now.Year, 12, 31);
            while (date <= end_date)
            {
                string pattern = date.Month.ToString() + date.Day.ToString();
                int pos = Pi.IndexOf(pattern);
                string short_date = date.Month.ToString() + "/" + date.Day.ToString();
                if (pos < 0)
                {
                    not_found++;
                    lstResults.Items.Add(
                        short_date + "\tNot found");
                }
                else
                {
                    found++;
                    if (biggest < pos) biggest = pos;
                    lstResults.Items.Add(
                        short_date + "\t" + pos.ToString());
                }

                date = date.AddDays(1);
            }
            lblResults.Text = "Found: " + found.ToString() +
                ", Not found: " + not_found.ToString() +
                ", Biggest position: " + biggest.ToString();
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
            this.btnCheck = new System.Windows.Forms.Button();
            this.lstResults = new System.Windows.Forms.ListBox();
            this.lblResults = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnCheck
            // 
            this.btnCheck.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnCheck.Location = new System.Drawing.Point(115, 12);
            this.btnCheck.Name = "btnCheck";
            this.btnCheck.Size = new System.Drawing.Size(75, 23);
            this.btnCheck.TabIndex = 0;
            this.btnCheck.Text = "Check";
            this.btnCheck.UseVisualStyleBackColor = true;
            this.btnCheck.Click += new System.EventHandler(this.btnCheck_Click);
            // 
            // lstResults
            // 
            this.lstResults.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lstResults.FormattingEnabled = true;
            this.lstResults.IntegralHeight = false;
            this.lstResults.Location = new System.Drawing.Point(12, 41);
            this.lstResults.Name = "lstResults";
            this.lstResults.Size = new System.Drawing.Size(280, 195);
            this.lstResults.TabIndex = 1;
            // 
            // lblResults
            // 
            this.lblResults.AutoSize = true;
            this.lblResults.Location = new System.Drawing.Point(12, 239);
            this.lblResults.Name = "lblResults";
            this.lblResults.Size = new System.Drawing.Size(52, 13);
            this.lblResults.TabIndex = 2;
            this.lblResults.Text = "lblResults";
            // 
            // howto_all_pi_patterns_Form1
            // 
            this.AcceptButton = this.btnCheck;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(304, 261);
            this.Controls.Add(this.lblResults);
            this.Controls.Add(this.lstResults);
            this.Controls.Add(this.btnCheck);
            this.Name = "howto_all_pi_patterns_Form1";
            this.Text = "howto_all_pi_patterns";
            this.Load += new System.EventHandler(this.howto_all_pi_patterns_Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCheck;
        private System.Windows.Forms.ListBox lstResults;
        private System.Windows.Forms.Label lblResults;
    }
}

