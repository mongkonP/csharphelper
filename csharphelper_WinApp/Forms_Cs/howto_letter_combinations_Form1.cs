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
     public partial class howto_letter_combinations_Form1:Form
  { 


        public howto_letter_combinations_Form1()
        {
            InitializeComponent();
        }

        // Make the items.
        private void howto_letter_combinations_Form1_Load(object sender, EventArgs e)
        {
            List<string> values = new List<string>();
            for (char ch1 = 'a'; ch1 <= 'z'; ch1++)
                for (char ch2 = 'a'; ch2 <= 'z'; ch2++)
                    for (char ch3 = 'a'; ch3 <= 'z'; ch3++)
                        values.Add(ch1.ToString() +
                            ch2.ToString() + ch3.ToString());

            lstCombinations.DataSource = values;
            lblCombinations.Text = values.Count + " combinations";
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
            this.lblCombinations = new System.Windows.Forms.Label();
            this.lstCombinations = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // lblCombinations
            // 
            this.lblCombinations.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblCombinations.AutoSize = true;
            this.lblCombinations.Location = new System.Drawing.Point(12, 189);
            this.lblCombinations.Name = "lblCombinations";
            this.lblCombinations.Size = new System.Drawing.Size(35, 13);
            this.lblCombinations.TabIndex = 3;
            this.lblCombinations.Text = "label1";
            // 
            // lstCombinations
            // 
            this.lstCombinations.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lstCombinations.ColumnWidth = 50;
            this.lstCombinations.FormattingEnabled = true;
            this.lstCombinations.IntegralHeight = false;
            this.lstCombinations.Location = new System.Drawing.Point(12, 11);
            this.lstCombinations.MultiColumn = true;
            this.lstCombinations.Name = "lstCombinations";
            this.lstCombinations.Size = new System.Drawing.Size(290, 175);
            this.lstCombinations.TabIndex = 2;
            // 
            // howto_letter_combinations_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(314, 211);
            this.Controls.Add(this.lblCombinations);
            this.Controls.Add(this.lstCombinations);
            this.Name = "howto_letter_combinations_Form1";
            this.Text = "howto_letter_combinations";
            this.Load += new System.EventHandler(this.howto_letter_combinations_Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblCombinations;
        private System.Windows.Forms.ListBox lstCombinations;
    }
}

