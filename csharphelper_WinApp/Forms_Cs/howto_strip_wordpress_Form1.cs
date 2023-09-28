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
     public partial class howto_strip_wordpress_Form1:Form
  { 


        public howto_strip_wordpress_Form1()
        {
            InitializeComponent();
        }

        // Set initial WordPress files.
        private void howto_strip_wordpress_Form1_Load(object sender, EventArgs e)
        {
            string path = Path.GetFullPath(
                Path.Combine(Application.StartupPath, "..\\..\\"));
            txtInput.Text = path + "Posts.txt";
            txtOutput.Text = path + "PostsTrimmed.txt";
        }

        // Remove the comments.
        private void btnRemoveSections_Click(object sender, EventArgs e)
        {
            lblResults.Text = "";
            Cursor = Cursors.WaitCursor;
            Refresh();

            // See what sections we want to remove.
            string targets = "\n";
            if (chkComment.Checked) targets += "COMMENT:\n";
            if (chkExtendedBody.Checked) targets += "EXTENDED BODY: \n";
            if (chkExcerpt.Checked) targets += "EXCERPT: \n";
            if (chkKeywords.Checked) targets += "KEYWORDS: \n";
            if (chkPing.Checked) targets += "PING:\n";

            // Read the input file.
            string[] input_lines = File.ReadAllLines(txtInput.Text);

            // Build the output.
            int num_removed = 0;
            bool reading_text = true;
            List<string> output_lines = new List<string>();
            foreach (string line in input_lines)
            {
                if (reading_text)
                {
                    // We're reading text. See if we should stop.
                    if (targets.Contains('\n' + line + '\n'))
                    {
                        num_removed++;
                        reading_text = false;
                    }
                    else output_lines.Add(line);
                }
                else
                {
                    // We're not reading text. See if we should start.
                    if (line == "-----") reading_text = true;
                }
            }

            // Save the result.
            File.WriteAllLines(txtOutput.Text, output_lines.ToArray());
            lblResults.Text = "Removed " + num_removed.ToString() +
                " sections";
            Cursor = Cursors.Default;
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
            this.btnRemoveSections = new System.Windows.Forms.Button();
            this.txtOutput = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtInput = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkComment = new System.Windows.Forms.CheckBox();
            this.chkExtendedBody = new System.Windows.Forms.CheckBox();
            this.chkKeywords = new System.Windows.Forms.CheckBox();
            this.chkExcerpt = new System.Windows.Forms.CheckBox();
            this.chkPing = new System.Windows.Forms.CheckBox();
            this.lblResults = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnRemoveSections
            // 
            this.btnRemoveSections.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnRemoveSections.Location = new System.Drawing.Point(142, 224);
            this.btnRemoveSections.Name = "btnRemoveSections";
            this.btnRemoveSections.Size = new System.Drawing.Size(122, 23);
            this.btnRemoveSections.TabIndex = 10;
            this.btnRemoveSections.Text = "Remove Sections";
            this.btnRemoveSections.UseVisualStyleBackColor = true;
            this.btnRemoveSections.Click += new System.EventHandler(this.btnRemoveSections_Click);
            // 
            // txtOutput
            // 
            this.txtOutput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtOutput.Location = new System.Drawing.Point(79, 36);
            this.txtOutput.Name = "txtOutput";
            this.txtOutput.Size = new System.Drawing.Size(300, 20);
            this.txtOutput.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Output File:";
            // 
            // txtInput
            // 
            this.txtInput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtInput.Location = new System.Drawing.Point(79, 10);
            this.txtInput.Name = "txtInput";
            this.txtInput.Size = new System.Drawing.Size(300, 20);
            this.txtInput.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Input File:";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.chkPing);
            this.groupBox1.Controls.Add(this.chkKeywords);
            this.groupBox1.Controls.Add(this.chkExcerpt);
            this.groupBox1.Controls.Add(this.chkExtendedBody);
            this.groupBox1.Controls.Add(this.chkComment);
            this.groupBox1.Location = new System.Drawing.Point(11, 82);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(368, 136);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Remove";
            // 
            // chkComment
            // 
            this.chkComment.AutoSize = true;
            this.chkComment.Checked = true;
            this.chkComment.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkComment.Location = new System.Drawing.Point(23, 19);
            this.chkComment.Name = "chkComment";
            this.chkComment.Size = new System.Drawing.Size(84, 17);
            this.chkComment.TabIndex = 0;
            this.chkComment.Text = "COMMENT:";
            this.chkComment.UseVisualStyleBackColor = true;
            // 
            // chkExtendedBody
            // 
            this.chkExtendedBody.AutoSize = true;
            this.chkExtendedBody.Checked = true;
            this.chkExtendedBody.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkExtendedBody.Location = new System.Drawing.Point(23, 42);
            this.chkExtendedBody.Name = "chkExtendedBody";
            this.chkExtendedBody.Size = new System.Drawing.Size(121, 17);
            this.chkExtendedBody.TabIndex = 1;
            this.chkExtendedBody.Text = "EXTENDED BODY:";
            this.chkExtendedBody.UseVisualStyleBackColor = true;
            // 
            // chkKeywords
            // 
            this.chkKeywords.AutoSize = true;
            this.chkKeywords.Checked = true;
            this.chkKeywords.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkKeywords.Location = new System.Drawing.Point(23, 88);
            this.chkKeywords.Name = "chkKeywords";
            this.chkKeywords.Size = new System.Drawing.Size(92, 17);
            this.chkKeywords.TabIndex = 3;
            this.chkKeywords.Text = "KEYWORDS:";
            this.chkKeywords.UseVisualStyleBackColor = true;
            // 
            // chkExcerpt
            // 
            this.chkExcerpt.AutoSize = true;
            this.chkExcerpt.Checked = true;
            this.chkExcerpt.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkExcerpt.Location = new System.Drawing.Point(23, 65);
            this.chkExcerpt.Name = "chkExcerpt";
            this.chkExcerpt.Size = new System.Drawing.Size(79, 17);
            this.chkExcerpt.TabIndex = 2;
            this.chkExcerpt.Text = "EXCERPT:";
            this.chkExcerpt.UseVisualStyleBackColor = true;
            // 
            // chkPing
            // 
            this.chkPing.AutoSize = true;
            this.chkPing.Checked = true;
            this.chkPing.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkPing.Location = new System.Drawing.Point(23, 111);
            this.chkPing.Name = "chkPing";
            this.chkPing.Size = new System.Drawing.Size(55, 17);
            this.chkPing.TabIndex = 4;
            this.chkPing.Text = "PING:";
            this.chkPing.UseVisualStyleBackColor = true;
            // 
            // lblResults
            // 
            this.lblResults.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblResults.AutoSize = true;
            this.lblResults.Location = new System.Drawing.Point(12, 260);
            this.lblResults.Name = "lblResults";
            this.lblResults.Size = new System.Drawing.Size(0, 13);
            this.lblResults.TabIndex = 12;
            // 
            // howto_strip_wordpress_Form1
            // 
            this.AcceptButton = this.btnRemoveSections;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(391, 282);
            this.Controls.Add(this.lblResults);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnRemoveSections);
            this.Controls.Add(this.txtOutput);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtInput);
            this.Controls.Add(this.label1);
            this.Name = "howto_strip_wordpress_Form1";
            this.Text = "howto_strip_wordpress";
            this.Load += new System.EventHandler(this.howto_strip_wordpress_Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnRemoveSections;
        private System.Windows.Forms.TextBox txtOutput;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtInput;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox chkComment;
        private System.Windows.Forms.CheckBox chkPing;
        private System.Windows.Forms.CheckBox chkKeywords;
        private System.Windows.Forms.CheckBox chkExcerpt;
        private System.Windows.Forms.CheckBox chkExtendedBody;
        private System.Windows.Forms.Label lblResults;
    }
}

