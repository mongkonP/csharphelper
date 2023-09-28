using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Text.RegularExpressions;

 

namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_show_regular_expression_matches_Form1:Form
  { 


        public howto_show_regular_expression_matches_Form1()
        {
            InitializeComponent();
        }

        // Display matches.
        private void btnGo_Click(object sender, EventArgs e)
        {
            try
            {
                Regex reg_exp = new Regex(txtPattern.Text);
                MatchCollection matches = reg_exp.Matches(txtTestString.Text);

                rchResults.Text = txtTestString.Text;
                foreach (Match a_match in matches)
                {
                    rchResults.Select(a_match.Index, a_match.Length);
                    rchResults.SelectionColor = Color.Red;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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
            this.rchResults = new System.Windows.Forms.RichTextBox();
            this.txtTestString = new System.Windows.Forms.TextBox();
            this.Label4 = new System.Windows.Forms.Label();
            this.btnGo = new System.Windows.Forms.Button();
            this.Label3 = new System.Windows.Forms.Label();
            this.txtPattern = new System.Windows.Forms.TextBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // rchResults
            // 
            this.rchResults.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.rchResults.Location = new System.Drawing.Point(6, 144);
            this.rchResults.Multiline = false;
            this.rchResults.Name = "rchResults";
            this.rchResults.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.rchResults.Size = new System.Drawing.Size(397, 20);
            this.rchResults.TabIndex = 25;
            this.rchResults.Text = "";
            // 
            // txtTestString
            // 
            this.txtTestString.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTestString.Location = new System.Drawing.Point(6, 64);
            this.txtTestString.Name = "txtTestString";
            this.txtTestString.Size = new System.Drawing.Size(397, 20);
            this.txtTestString.TabIndex = 20;
            this.txtTestString.Text = "When in worry or in doubt, run in circles scream and shout.";
            // 
            // Label4
            // 
            this.Label4.AutoSize = true;
            this.Label4.Location = new System.Drawing.Point(6, 48);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(58, 13);
            this.Label4.TabIndex = 24;
            this.Label4.Text = "Test String";
            // 
            // btnGo
            // 
            this.btnGo.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnGo.Location = new System.Drawing.Point(186, 88);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(40, 24);
            this.btnGo.TabIndex = 21;
            this.btnGo.Text = "Go";
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.Location = new System.Drawing.Point(6, 128);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(42, 13);
            this.Label3.TabIndex = 23;
            this.Label3.Text = "Results";
            // 
            // txtPattern
            // 
            this.txtPattern.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPattern.Location = new System.Drawing.Point(6, 24);
            this.txtPattern.Name = "txtPattern";
            this.txtPattern.Size = new System.Drawing.Size(397, 20);
            this.txtPattern.TabIndex = 22;
            this.txtPattern.Text = "in|or|and";
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(6, 8);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(41, 13);
            this.Label1.TabIndex = 19;
            this.Label1.Text = "Pattern";
            // 
            // howto_show_regular_expression_matches_Form1
            // 
            this.AcceptButton = this.btnGo;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(409, 173);
            this.Controls.Add(this.rchResults);
            this.Controls.Add(this.txtTestString);
            this.Controls.Add(this.Label4);
            this.Controls.Add(this.btnGo);
            this.Controls.Add(this.Label3);
            this.Controls.Add(this.txtPattern);
            this.Controls.Add(this.Label1);
            this.Name = "howto_show_regular_expression_matches_Form1";
            this.Text = "howto_show_regular_expression_matches";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.RichTextBox rchResults;
        internal System.Windows.Forms.TextBox txtTestString;
        internal System.Windows.Forms.Label Label4;
        internal System.Windows.Forms.Button btnGo;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.TextBox txtPattern;
        internal System.Windows.Forms.Label Label1;
    }
}

