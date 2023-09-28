using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Diagnostics;

 

namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_ducci_sequence_Form1:Form
  { 


        public howto_ducci_sequence_Form1()
        {
            InitializeComponent();
        }

        // Return the numbers separated by dashes.
        private string NumsToString(List<int> nums)
        {
            return string.Join("-", nums.ConvertAll(n => n.ToString()).ToArray());
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            lstResults.DataSource = null;
            Refresh();

            // Convert into a List<int>.
            string nums_str = txtStart.Text;
            List<string> ints = nums_str.Split('-').ToList();
            List<int> nums = ints.ConvertAll(s => int.Parse(s));
            int nums_length = nums.Count;

            // Build the sequence.
            List<string> sequence = new List<string>();
            sequence.Add(NumsToString(nums));
            for (; ; )
            {
                List<int> new_nums = new List<int>();
                for (int i = 0; i < nums.Count; i++)
                    new_nums.Add(Math.Abs(nums[i] - nums[(i + 1) % nums_length]));
                nums = new_nums;

                nums_str = NumsToString(nums);
                if (sequence.Contains(nums_str))
                {
                    sequence.Add(nums_str);
                    int start = sequence.IndexOf(nums_str);
                    int length = sequence.Count - start;
                    lblSequenceStart.Text = start.ToString();
                    lblSequenceLength.Text = length.ToString();
                    lstResults.DataSource = sequence;
                    return;
                }
                sequence.Add(nums_str);

                Debug.Assert(sequence.Count < 10000);
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
            this.txtStart = new System.Windows.Forms.TextBox();
            this.brnGo = new System.Windows.Forms.Button();
            this.lstResults = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblSequenceStart = new System.Windows.Forms.Label();
            this.lblSequenceLength = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Start:";
            // 
            // txtStart
            // 
            this.txtStart.Location = new System.Drawing.Point(50, 14);
            this.txtStart.Name = "txtStart";
            this.txtStart.Size = new System.Drawing.Size(100, 20);
            this.txtStart.TabIndex = 1;
            this.txtStart.Text = "1-2-3-4-5";
            // 
            // brnGo
            // 
            this.brnGo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.brnGo.Location = new System.Drawing.Point(247, 12);
            this.brnGo.Name = "brnGo";
            this.brnGo.Size = new System.Drawing.Size(75, 23);
            this.brnGo.TabIndex = 2;
            this.brnGo.Text = "Go";
            this.brnGo.UseVisualStyleBackColor = true;
            this.brnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // lstResults
            // 
            this.lstResults.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lstResults.FormattingEnabled = true;
            this.lstResults.IntegralHeight = false;
            this.lstResults.Location = new System.Drawing.Point(12, 41);
            this.lstResults.MultiColumn = true;
            this.lstResults.Name = "lstResults";
            this.lstResults.Size = new System.Drawing.Size(310, 195);
            this.lstResults.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 239);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Sequence Start:";
            // 
            // lblSequenceStart
            // 
            this.lblSequenceStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblSequenceStart.AutoSize = true;
            this.lblSequenceStart.Location = new System.Drawing.Point(102, 239);
            this.lblSequenceStart.Name = "lblSequenceStart";
            this.lblSequenceStart.Size = new System.Drawing.Size(25, 13);
            this.lblSequenceStart.TabIndex = 5;
            this.lblSequenceStart.Text = "100";
            // 
            // lblSequenceLength
            // 
            this.lblSequenceLength.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblSequenceLength.AutoSize = true;
            this.lblSequenceLength.Location = new System.Drawing.Point(257, 239);
            this.lblSequenceLength.Name = "lblSequenceLength";
            this.lblSequenceLength.Size = new System.Drawing.Size(25, 13);
            this.lblSequenceLength.TabIndex = 7;
            this.lblSequenceLength.Text = "100";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(156, 239);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(95, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Sequence Length:";
            // 
            // howto_ducci_sequence_Form1
            // 
            this.AcceptButton = this.brnGo;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(334, 261);
            this.Controls.Add(this.lblSequenceLength);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lblSequenceStart);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lstResults);
            this.Controls.Add(this.brnGo);
            this.Controls.Add(this.txtStart);
            this.Controls.Add(this.label1);
            this.Name = "howto_ducci_sequence_Form1";
            this.Text = "howto_ducci_sequence";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtStart;
        private System.Windows.Forms.Button brnGo;
        private System.Windows.Forms.ListBox lstResults;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblSequenceStart;
        private System.Windows.Forms.Label lblSequenceLength;
        private System.Windows.Forms.Label label5;
    }
}

