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
     public partial class howto_extract_comments_Form1:Form
  { 


        public howto_extract_comments_Form1()
        {
            InitializeComponent();
        }

        // Pick an initial file.
        private void howto_extract_comments_Form1_Load(object sender, EventArgs e)
        {
            /* This is a
             * multi-line comment   // Hidden comment.
             */
            string filename = Path.Combine(Application.StartupPath, @"..\..\howto_extract_comments_Form1.cs");
            FileInfo file_info = new FileInfo(filename);
            txtFile.Text = file_info.FullName;
        }

        // Extract the comments.
        private void btnExtract_Click(object sender, EventArgs e)
        {
            // A weirder comment.   /* Not a multi-line comment

            // Display the comments.
            txtComments.Text = ExtractComments(txtFile.Text);
        }

        // Return a file's comments.
        private string ExtractComments(string filename)
        {
            // Get the file's contents.
            string all_text = File.ReadAllText(filename);

            // Get rid of \" escape sequences.
            all_text = all_text.Replace("\\\"", "");

            // Process the file.
            string comments = "";
            while (all_text.Length > 0)
            {
                // Find the next string or comment.
                int string_pos = all_text.IndexOf("\"");
                int end_line_pos = all_text.IndexOf("//");
                int multi_line_pos = all_text.IndexOf("/*");

                // If there are none of these, we're done.
                if ((string_pos < 0) && (end_line_pos < 0) && (multi_line_pos < 0)) break;

                if (string_pos < 0) string_pos = all_text.Length;
                if (end_line_pos < 0) end_line_pos = all_text.Length;
                if (multi_line_pos < 0) multi_line_pos = all_text.Length;

                // See which comes first.
                if ((string_pos < end_line_pos) && (string_pos < multi_line_pos))
                {
                    // String.
                    // Find its end.
                    int end_pos = all_text.IndexOf("\"", string_pos + 1);

                    // Extract and discard everything up to the string.
                    if (end_pos < 0)
                    {
                        all_text = "";
                    }
                    else
                    {
                        all_text = all_text.Substring(end_pos + 1);
                    }
                }
                else if (end_line_pos < multi_line_pos)
                {
                    // End of line comment.
                    // Find its end.
                    int end_pos = all_text.IndexOf("\r\n", end_line_pos + 2);

                    // Extract the comment.
                    if (end_pos < 0)
                    {
                        comments += all_text.Substring(end_line_pos) + "\r\n";
                        all_text = "";
                    }
                    else
                    {
                        comments += all_text.Substring(end_line_pos, end_pos - end_line_pos) + "\r\n";
                        all_text = all_text.Substring(end_pos + 2);
                    }
                }
                else
                {
                    // Multi-line comment.
                    // Find its end.
                    int end_pos = all_text.IndexOf("*/", multi_line_pos + 2);

                    // Extract the comment.
                    if (end_pos < 0)
                    {
                        comments += all_text.Substring(multi_line_pos) + "\r\n";
                        all_text = "";
                    }
                    else
                    {
                        comments += all_text.Substring(multi_line_pos, end_pos - multi_line_pos + 2) + "\r\n";
                        all_text = all_text.Substring(end_pos + 2);
                    }
                }
            }

            return comments;
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
            this.txtFile = new System.Windows.Forms.TextBox();
            this.btnExtract = new System.Windows.Forms.Button();
            this.txtComments = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(26, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "File:";
            // 
            // txtFile
            // 
            this.txtFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFile.Location = new System.Drawing.Point(44, 14);
            this.txtFile.Name = "txtFile";
            this.txtFile.Size = new System.Drawing.Size(547, 20);
            this.txtFile.TabIndex = 1;
            // 
            // btnExtract
            // 
            this.btnExtract.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExtract.Location = new System.Drawing.Point(597, 12);
            this.btnExtract.Name = "btnExtract";
            this.btnExtract.Size = new System.Drawing.Size(75, 23);
            this.btnExtract.TabIndex = 2;
            this.btnExtract.Text = "Extract";
            this.btnExtract.UseVisualStyleBackColor = true;
            this.btnExtract.Click += new System.EventHandler(this.btnExtract_Click);
            // 
            // txtComments
            // 
            this.txtComments.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtComments.Location = new System.Drawing.Point(15, 57);
            this.txtComments.Multiline = true;
            this.txtComments.Name = "txtComments";
            this.txtComments.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtComments.Size = new System.Drawing.Size(657, 195);
            this.txtComments.TabIndex = 3;
            // 
            // howto_extract_comments_Form1
            // 
            this.AcceptButton = this.btnExtract;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 264);
            this.Controls.Add(this.txtComments);
            this.Controls.Add(this.btnExtract);
            this.Controls.Add(this.txtFile);
            this.Controls.Add(this.label1);
            this.Name = "howto_extract_comments_Form1";
            this.Text = "howto_extract_comments";
            this.Load += new System.EventHandler(this.howto_extract_comments_Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtFile;
        private System.Windows.Forms.Button btnExtract;
        private System.Windows.Forms.TextBox txtComments;
    }
}

