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
     public partial class howto_parse_file_sizes_Form1:Form
  { 


        public howto_parse_file_sizes_Form1()
        {
            InitializeComponent();
        }

        // Convert a file size into bytes.
        private void btnParse_Click(object sender, EventArgs e)
        {
            double bytes = ParseFileSize(txtSize.Text, 1024);
            txtBytes.Text = bytes.ToString("N0");
            txtCheck.Text = ToFileSize(bytes);
        }

        // Parse a file size.
        private string[] SizeSuffixes = { "bytes", "KB", "MB", "GB", "TB", "PB", "EB", "ZB", "YB" };
        private double ParseFileSize(string value, int kb_value)
        {
            // Remove leading and trailing spaces.
            value = value.Trim();

            try
            {
                // Find the last non-alphabetic character.
                int ext_start = 0;
                for (int i = value.Length - 1; i >= 0; i--)
                {
                    // Stop if we find something other than a letter.
                    if (!char.IsLetter(value, i))
                    {
                        ext_start = i + 1;
                        break;
                    }
                }

                // Get the numeric part.
                double number = double.Parse(value.Substring(0, ext_start));

                // Get the extension.
                string suffix;
                if (ext_start < value.Length)
                {
                    suffix = value.Substring(ext_start).Trim().ToUpper();
                    if (suffix == "BYTES") suffix = "bytes";
                }
                else
                {
                    suffix = "bytes";
                }

                // Find the extension in the list.
                int suffix_index = -1;
                for (int i = 0; i < SizeSuffixes.Length; i++)
                {
                    if (SizeSuffixes[i] == suffix)
                    {
                        suffix_index = i;
                        break;
                    }
                }
                if (suffix_index < 0)
                    throw new FormatException("Unknown file size extension " + suffix + ".");

                // Return the result.
                return Math.Round(number * Math.Pow(kb_value, suffix_index));
            }
            catch (Exception ex)
            {
                throw new FormatException("Invalid file size format", ex);
            }
        }

#region Validation

        // Return a string describing the value as a file size.
        // For example, 1.23 MB.
        public string ToFileSize(double value)
        {
            string[] suffixes = { "bytes", "KB", "MB", "GB", "TB", "PB", "EB", "ZB", "YB" };
            for (int i = 0; i < suffixes.Length; i++)
            {
                if (value <= (Math.Pow(1024, i + 1)))
                {
                    return ThreeNonZeroDigits(value / Math.Pow(1024, i)) + " " + suffixes[i];
                }
            }

            return ThreeNonZeroDigits(value / Math.Pow(1024, suffixes.Length - 1)) +
                " " + suffixes[suffixes.Length - 1];
        }

        // Return the value formatted to include at most three
        // non-zero digits and at most two digits after the
        // decimal point. Examples:
        //         1
        //       123
        //        12.3
        //         1.23
        //         0.12
        private static string ThreeNonZeroDigits(double value)
        {
            if (value >= 100)
            {
                // No digits after the decimal.
                return value.ToString("0,0");
            }
            else if (value >= 10)
            {
                // One digit after the decimal.
                return value.ToString("0.0");
            }
            else
            {
                // Two digits after the decimal.
                return value.ToString("0.00");
            }
        }

#endregion Validation

    

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
            this.txtCheck = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtBytes = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnParse = new System.Windows.Forms.Button();
            this.txtSize = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtCheck
            // 
            this.txtCheck.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCheck.Location = new System.Drawing.Point(59, 68);
            this.txtCheck.Name = "txtCheck";
            this.txtCheck.ReadOnly = true;
            this.txtCheck.Size = new System.Drawing.Size(152, 20);
            this.txtCheck.TabIndex = 13;
            this.txtCheck.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 71);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Check:";
            // 
            // txtBytes
            // 
            this.txtBytes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBytes.Location = new System.Drawing.Point(59, 40);
            this.txtBytes.Name = "txtBytes";
            this.txtBytes.ReadOnly = true;
            this.txtBytes.Size = new System.Drawing.Size(152, 20);
            this.txtBytes.TabIndex = 11;
            this.txtBytes.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Bytes:";
            // 
            // btnParse
            // 
            this.btnParse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnParse.Location = new System.Drawing.Point(217, 12);
            this.btnParse.Name = "btnParse";
            this.btnParse.Size = new System.Drawing.Size(75, 23);
            this.btnParse.TabIndex = 9;
            this.btnParse.Text = "Parse";
            this.btnParse.UseVisualStyleBackColor = true;
            this.btnParse.Click += new System.EventHandler(this.btnParse_Click);
            // 
            // txtSize
            // 
            this.txtSize.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSize.Location = new System.Drawing.Point(59, 14);
            this.txtSize.Name = "txtSize";
            this.txtSize.Size = new System.Drawing.Size(152, 20);
            this.txtSize.TabIndex = 8;
            this.txtSize.Text = "1.23 TB";
            this.txtSize.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Size:";
            // 
            // howto_parse_file_sizes_Form1
            // 
            this.AcceptButton = this.btnParse;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(304, 101);
            this.Controls.Add(this.txtCheck);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtBytes);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnParse);
            this.Controls.Add(this.txtSize);
            this.Controls.Add(this.label1);
            this.Name = "howto_parse_file_sizes_Form1";
            this.Text = "howto_parse_file_sizes";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtCheck;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtBytes;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnParse;
        private System.Windows.Forms.TextBox txtSize;
        private System.Windows.Forms.Label label1;
    }
}

