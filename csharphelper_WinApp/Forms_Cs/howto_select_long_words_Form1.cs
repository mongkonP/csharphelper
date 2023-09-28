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

// The word file used by this program is the file
// 6of12.txt from the 12Dicts package available at:
//
// http://wordlist.sourceforge.net

 

namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_select_long_words_Form1:Form
  { 


        public howto_select_long_words_Form1()
        {
            InitializeComponent();
        }

        // Select words that have the given minimum length.
        private void btnSelect_Click(object sender, EventArgs e)
        {
                // Remove non-alphabetic characters at the ends of words.
                Regex end_regex = new Regex("[^a-zA-Z]+$");
                string[] all_lines = File.ReadAllLines("6of12.txt");
                var end_query =
                    from string word in all_lines
                    select end_regex.Replace(word, "");

                // Remove words that still contain non-alphabetic characters.
                Regex middle_regex = new Regex("[^a-zA-Z]");
                var middle_query =
                    from string word in end_query
                    where !middle_regex.IsMatch(word)
                    select word;

                // Make a query to select lines of the desired length.
                int min_length = (int)nudMinLength.Value;
                int max_length = (int)nudMaxLength.Value;
                var length_query =
                    from string word in middle_query
                    where (word.Length >= min_length) &&
                          (word.Length <= max_length)
                    select word;

            // Write the selected lines into a new file.
            string[] selected_lines = length_query.ToArray();
            File.WriteAllLines("Words.txt", selected_lines);

            MessageBox.Show("Selected " + selected_lines.Length +
                " words out of " + all_lines.Length + ".");
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
            this.nudMaxLength = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.nudMinLength = new System.Windows.Forms.NumericUpDown();
            this.btnSelect = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.nudMaxLength)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMinLength)).BeginInit();
            this.SuspendLayout();
            // 
            // nudMaxLength
            // 
            this.nudMaxLength.Location = new System.Drawing.Point(134, 38);
            this.nudMaxLength.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudMaxLength.Name = "nudMaxLength";
            this.nudMaxLength.Size = new System.Drawing.Size(41, 20);
            this.nudMaxLength.TabIndex = 10;
            this.nudMaxLength.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Maximum Length:";
            // 
            // nudMinLength
            // 
            this.nudMinLength.Location = new System.Drawing.Point(134, 12);
            this.nudMinLength.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudMinLength.Name = "nudMinLength";
            this.nudMinLength.Size = new System.Drawing.Size(41, 20);
            this.nudMinLength.TabIndex = 8;
            this.nudMinLength.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // btnSelect
            // 
            this.btnSelect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSelect.Location = new System.Drawing.Point(227, 24);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(75, 23);
            this.btnSelect.TabIndex = 7;
            this.btnSelect.Text = "Select";
            this.btnSelect.UseVisualStyleBackColor = true;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Minimum Length:";
            // 
            // howto_select_long_words_Form1
            // 
            this.AcceptButton = this.btnSelect;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(314, 71);
            this.Controls.Add(this.nudMaxLength);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.nudMinLength);
            this.Controls.Add(this.btnSelect);
            this.Controls.Add(this.label1);
            this.Name = "howto_select_long_words_Form1";
            this.Text = "howto_select_long_words";
            ((System.ComponentModel.ISupportInitialize)(this.nudMaxLength)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMinLength)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown nudMaxLength;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown nudMinLength;
        private System.Windows.Forms.Button btnSelect;
        private System.Windows.Forms.Label label1;
    }
}

