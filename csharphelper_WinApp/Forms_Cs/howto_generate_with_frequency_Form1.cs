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
     public partial class howto_generate_with_frequency_Form1:Form
  { 


        public howto_generate_with_frequency_Form1()
        {
            InitializeComponent();
        }

        // The letter frequencies. See:
        // http://en.wikipedia.org/wiki/Letter_frequency
        private float[] Frequencies =
        {
            8.167f, 1.492f, 2.782f, 4.253f, 12.702f, 
            2.228f, 2.015f, 6.094f, 6.966f, 0.153f, 
            0.772f, 4.025f, 2.406f, 6.749f, 7.507f, 
            1.929f, 0.095f, 5.987f, 6.327f, 9.056f, 
            2.758f, 0.978f, 2.360f, 0.150f, 1.974f, 
            0.074f
        };

        // Random number generator.
        private Random Rand = new Random();

        // The ASCII value of A.
        private int int_A = (int)'A';

        // Make sure the frequencies add up to 100.
        private void howto_generate_with_frequency_Form1_Load(object sender, EventArgs e)
        {
            // Give any difference to E.
            float total = Frequencies.Sum();
            float diff = 100f - total;
            Frequencies[(int)'E' - int_A] += diff;
        }

        // Generate random letters with the indicated frequencies.
        private void btnGenerate_Click(object sender, EventArgs e)
        {
            // Keep track of the number of each letter generated.
            int[] counts = new int[26];

            // Generate the letters.
            int num_letters = int.Parse(txtNumLetters.Text);
            string result = "";
            for (int i = 0; i < num_letters; i++)
            {
                // Generate a number between 0 and 100.
                double num = 100.0 * Rand.NextDouble();

                // See which letter this represents.
                for (int letter_num = 0; ; letter_num++)
                {
                    // Subtract this letter's frequency from num.
                    num -= Frequencies[letter_num];

                    // If num <= 0, then this is the letter.
                    if ((num <= 0) || (letter_num == 25))
                    {
                        char ch = (char)(int_A + letter_num);
                        result += ch.ToString() + ' ';
                        counts[letter_num]++;
                        break;
                    }
                }
            }

            txtLetters.Text = result;
            txtLetters.Select(0, 0);

            // Display the frequencies.
            lstFrequencies.Items.Clear();
            for (int i = 0; i < counts.Length; i++)
            {
                char ch = (char)(int_A + i);
                float frequency = (float)counts[i] / num_letters * 100;
                string str = string.Format("{0}\t{1,6}\t{2,6}\t{3,6}",
                    ch.ToString(),
                    frequency.ToString("0.000"),
                    Frequencies[i].ToString("0.000"),
                    (frequency - Frequencies[i]).ToString("0.000"));
                lstFrequencies.Items.Add(str);
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
            this.txtLetters = new System.Windows.Forms.TextBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.lstFrequencies = new System.Windows.Forms.ListBox();
            this.txtNumLetters = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtLetters
            // 
            this.txtLetters.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtLetters.Font = new System.Drawing.Font("Courier New", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLetters.Location = new System.Drawing.Point(0, 0);
            this.txtLetters.Multiline = true;
            this.txtLetters.Name = "txtLetters";
            this.txtLetters.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtLetters.Size = new System.Drawing.Size(325, 95);
            this.txtLetters.TabIndex = 1;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(12, 41);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.txtLetters);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.lstFrequencies);
            this.splitContainer1.Size = new System.Drawing.Size(325, 208);
            this.splitContainer1.SplitterDistance = 95;
            this.splitContainer1.TabIndex = 8;
            // 
            // lstFrequencies
            // 
            this.lstFrequencies.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstFrequencies.Font = new System.Drawing.Font("Courier New", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstFrequencies.FormattingEnabled = true;
            this.lstFrequencies.IntegralHeight = false;
            this.lstFrequencies.ItemHeight = 14;
            this.lstFrequencies.Location = new System.Drawing.Point(0, 0);
            this.lstFrequencies.Name = "lstFrequencies";
            this.lstFrequencies.Size = new System.Drawing.Size(325, 109);
            this.lstFrequencies.TabIndex = 0;
            // 
            // txtNumLetters
            // 
            this.txtNumLetters.Location = new System.Drawing.Point(75, 14);
            this.txtNumLetters.Name = "txtNumLetters";
            this.txtNumLetters.Size = new System.Drawing.Size(61, 20);
            this.txtNumLetters.TabIndex = 7;
            this.txtNumLetters.Text = "1000";
            this.txtNumLetters.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "# Letters:";
            // 
            // btnGenerate
            // 
            this.btnGenerate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGenerate.Location = new System.Drawing.Point(262, 12);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(75, 23);
            this.btnGenerate.TabIndex = 5;
            this.btnGenerate.Text = "Generate";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // howto_generate_with_frequency_Form1
            // 
            this.AcceptButton = this.btnGenerate;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(349, 261);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.txtNumLetters);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnGenerate);
            this.Name = "howto_generate_with_frequency_Form1";
            this.Text = "howto_generate_with_frequency";
            this.Load += new System.EventHandler(this.howto_generate_with_frequency_Form1_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtLetters;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ListBox lstFrequencies;
        private System.Windows.Forms.TextBox txtNumLetters;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnGenerate;
    }
}

