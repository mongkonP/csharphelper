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
     public partial class howto_letter_combinations2_Form1:Form
  { 


        public howto_letter_combinations2_Form1()
        {
            InitializeComponent();
        }

        // Generate the words.
        private void btnGo_Click(object sender, EventArgs e)
        {
            // If this will take a long time, make the user confirm.
            if (nudNumLetters.Value > 3)
            {
                if (MessageBox.Show("This will generate " +
                    Math.Pow(26, (double)nudNumLetters.Value) +
                    " strings. Are you aure you want to do this?",
                    "Are You Sure?",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question) != DialogResult.Yes)
                    return;
            }

            Cursor = Cursors.WaitCursor;
            lstCombinations.DataSource = null;
            lblCombinations.Text = "";
            Refresh();

            // Generate the combinations.
            lstCombinations.DataSource =
                GenerateLetterCombinations((int)nudNumLetters.Value);
            lblCombinations.Text =
                lstCombinations.Items.Count.ToString("#,#") + " combinations";

            Cursor = Cursors.Default;
        }

        // Generate words with num_letters letters.
        private List<string> GenerateLetterCombinations(int num_letters)
        {
            List<string> values = new List<string>();

            // Build one-letter combinations.
            for (char ch = 'a'; ch <= 'z'; ch++)
            {
                values.Add(ch.ToString());
            }

            // Add onto the combinations.
            for (int i = 1; i < num_letters; i++)
            {
                // Make combinations containing i + 1 letters.
                List<string> new_values = new List<string>();
                foreach (string str in values)
                {
                    // Add all possible letters to this string.
                    for (char ch = 'a'; ch <= 'z'; ch++)
                    {
                        new_values.Add(str + ch);
                    }
                }

                // Replace the old values with the new ones.
                values = new_values;
            }

            return values;
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
            this.btnGo = new System.Windows.Forms.Button();
            this.nudNumLetters = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.lblCombinations = new System.Windows.Forms.Label();
            this.lstCombinations = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.nudNumLetters)).BeginInit();
            this.SuspendLayout();
            // 
            // btnGo
            // 
            this.btnGo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGo.Location = new System.Drawing.Point(237, 12);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(75, 23);
            this.btnGo.TabIndex = 6;
            this.btnGo.Text = "Go";
            this.btnGo.UseVisualStyleBackColor = true;
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // nudNumLetters
            // 
            this.nudNumLetters.Location = new System.Drawing.Point(70, 15);
            this.nudNumLetters.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.nudNumLetters.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudNumLetters.Name = "nudNumLetters";
            this.nudNumLetters.Size = new System.Drawing.Size(54, 20);
            this.nudNumLetters.TabIndex = 5;
            this.nudNumLetters.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "# Letters:";
            // 
            // lblCombinations
            // 
            this.lblCombinations.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblCombinations.AutoSize = true;
            this.lblCombinations.Location = new System.Drawing.Point(12, 189);
            this.lblCombinations.Name = "lblCombinations";
            this.lblCombinations.Size = new System.Drawing.Size(35, 13);
            this.lblCombinations.TabIndex = 8;
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
            this.lstCombinations.Location = new System.Drawing.Point(12, 41);
            this.lstCombinations.MultiColumn = true;
            this.lstCombinations.Name = "lstCombinations";
            this.lstCombinations.Size = new System.Drawing.Size(300, 145);
            this.lstCombinations.TabIndex = 7;
            // 
            // howto_letter_combinations2_Form1
            // 
            this.AcceptButton = this.btnGo;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(324, 211);
            this.Controls.Add(this.btnGo);
            this.Controls.Add(this.nudNumLetters);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblCombinations);
            this.Controls.Add(this.lstCombinations);
            this.Name = "howto_letter_combinations2_Form1";
            this.Text = "howto_letter_combinations2";
            ((System.ComponentModel.ISupportInitialize)(this.nudNumLetters)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnGo;
        private System.Windows.Forms.NumericUpDown nudNumLetters;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblCombinations;
        private System.Windows.Forms.ListBox lstCombinations;

    }
}

