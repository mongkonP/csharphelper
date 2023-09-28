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
     public partial class howto_mean_median_sets_Form1:Form
  { 


        public howto_mean_median_sets_Form1()
        {
            InitializeComponent();
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            lstMatches.Items.Clear();
            lblNumMatches.Text = "";
            Cursor = Cursors.WaitCursor;
            Refresh();

            int max = int.Parse(txtMax.Text);

            List<List<int>> list1 = Triples(max);
            foreach (List<int> triple1 in list1)
            {
                int sum1 = triple1.Sum();
                if (sum1 % 3 != 0) continue;
                int mean1 = sum1 / 3;
                int median1 = triple1[1];
                if (mean1 == median1) continue;

                foreach (List<int> triple2 in list1)
                {
                    if ((triple1[0] == triple2[0]) &&
                        (triple1[1] == triple2[1]) &&
                        (triple1[2] == triple2[2]))
                        continue;

                    int sum2 = triple2.Sum();
                    if (sum2 % 3 != 0) continue;
                    int mean2 = sum2 / 3;
                    int median2 = triple2[1];
                    if (mean2 == median2) continue;

                    if ((mean1 == median2) && (mean2 == median1))
                    {
                        // Find sets where the mean of one is the
                        // median of the other and vice versa.
                        lstMatches.Items.Add(
                            TripleString(triple1) + '\t' +
                            TripleString(triple2));
                        Console.WriteLine(
                            TripleString(triple1) + '\t' +
                            triple1.Sum() / 3 + '\t' +
                            triple1[1].ToString() + '\t' +

                            TripleString(triple2) + '\t' +
                            triple2.Sum() / 3 + '\t' +
                            triple2[1].ToString());
                        Refresh();
                    }
                }
            }

            lblNumMatches.Text = lstMatches.Items.Count.ToString();
            Cursor = Cursors.Default;
        }

        private List<List<int>> Triples(int max)
        {
            List<List<int>> results = new List<List<int>>();

            for (int i = 1; i < max; i++)
                for (int j = i + 1; j < max; j++)
                    for (int k = j + 1; k < max; k++)
                    {
                        results.Add(new List<int>(new int[] { i, j, k }));
                    }
            return results;
        }

        private List<List<int>> Fives(int max)
        {
            List<List<int>> results = new List<List<int>>();
            for (int i = 1; i < max; i++)
                for (int j = i + 1; j < max; j++)
                    for (int k = j + 1; k < max; k++)
                        for (int l = k + 1; l < max; l++)
                            for (int m = l + 1; m < max; m++)
                            {
                                results.Add(new List<int>(new int[] { i, j, k, l, m }));
                            }
            return results;
        }

        private string TripleString(List<int> list)
        {
            return "{" + list[0].ToString() +
                ", " + list[1].ToString() +
                ", " + list[2].ToString() + "}";
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
            this.txtMax = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblNumMatches = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lstMatches = new System.Windows.Forms.ListBox();
            this.btnGo = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtMax
            // 
            this.txtMax.Location = new System.Drawing.Point(48, 12);
            this.txtMax.Name = "txtMax";
            this.txtMax.Size = new System.Drawing.Size(42, 20);
            this.txtMax.TabIndex = 5;
            this.txtMax.Text = "10";
            this.txtMax.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Max:";
            // 
            // lblNumMatches
            // 
            this.lblNumMatches.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblNumMatches.AutoSize = true;
            this.lblNumMatches.Location = new System.Drawing.Point(79, 157);
            this.lblNumMatches.Name = "lblNumMatches";
            this.lblNumMatches.Size = new System.Drawing.Size(0, 13);
            this.lblNumMatches.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 157);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "# Matches:";
            // 
            // lstMatches
            // 
            this.lstMatches.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lstMatches.FormattingEnabled = true;
            this.lstMatches.IntegralHeight = false;
            this.lstMatches.Location = new System.Drawing.Point(12, 39);
            this.lstMatches.Name = "lstMatches";
            this.lstMatches.Size = new System.Drawing.Size(260, 115);
            this.lstMatches.TabIndex = 7;
            // 
            // btnGo
            // 
            this.btnGo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGo.Location = new System.Drawing.Point(197, 10);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(75, 23);
            this.btnGo.TabIndex = 6;
            this.btnGo.Text = "Go";
            this.btnGo.UseVisualStyleBackColor = true;
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // howto_mean_median_sets_Form1
            // 
            this.AcceptButton = this.btnGo;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 181);
            this.Controls.Add(this.txtMax);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblNumMatches);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lstMatches);
            this.Controls.Add(this.btnGo);
            this.Name = "howto_mean_median_sets_Form1";
            this.Text = "howto_mean_median_sets";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtMax;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblNumMatches;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox lstMatches;
        private System.Windows.Forms.Button btnGo;
    }
}

