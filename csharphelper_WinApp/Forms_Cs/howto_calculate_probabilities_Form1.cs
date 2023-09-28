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
     public partial class howto_calculate_probabilities_Form1:Form
  { 


        public howto_calculate_probabilities_Form1()
        {
            InitializeComponent();
        }

        // Calculate and display probabilities.
        private void btnGo_Click(object sender, EventArgs e)
        {
            // See if the probability contains a % sign.
            bool percent = txtEventProb.Text.Contains("%");

            // Get the event probability.
            double event_prob = double.Parse(txtEventProb.Text.Replace("%", ""));

            // If we're using percents, divide by 100.
            if (percent) event_prob /= 100.0;

            // Get the probability of the event not happening.
            double non_prob = 1.0 - event_prob;

            lvwResults.Items.Clear();
            for (int i = 0; i <= 100; i++)
            {
                double prob = 1.0 - Math.Pow(non_prob, i);
                ListViewItem new_item = lvwResults.Items.Add(i.ToString());

                if (percent)
                {
                    prob *= 100.0;
                    new_item.SubItems.Add(prob.ToString("0.0000") + "%");
                }
                else
                {
                    new_item.SubItems.Add(prob.ToString("0.000000"));
                }
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
            this.lvwResults = new System.Windows.Forms.ListView();
            this.colRepetitions = new System.Windows.Forms.ColumnHeader();
            this.colProbability = new System.Windows.Forms.ColumnHeader();
            this.btnGo = new System.Windows.Forms.Button();
            this.txtEventProb = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lvwResults
            // 
            this.lvwResults.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwResults.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colRepetitions,
            this.colProbability});
            this.lvwResults.FullRowSelect = true;
            this.lvwResults.Location = new System.Drawing.Point(12, 40);
            this.lvwResults.Name = "lvwResults";
            this.lvwResults.Size = new System.Drawing.Size(310, 208);
            this.lvwResults.TabIndex = 7;
            this.lvwResults.UseCompatibleStateImageBehavior = false;
            this.lvwResults.View = System.Windows.Forms.View.Details;
            // 
            // colRepetitions
            // 
            this.colRepetitions.Text = "Reps";
            this.colRepetitions.Width = 50;
            // 
            // colProbability
            // 
            this.colProbability.Text = "Probability";
            this.colProbability.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.colProbability.Width = 180;
            // 
            // btnGo
            // 
            this.btnGo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGo.Location = new System.Drawing.Point(247, 12);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(75, 23);
            this.btnGo.TabIndex = 6;
            this.btnGo.Text = "Go";
            this.btnGo.UseVisualStyleBackColor = true;
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // txtEventProb
            // 
            this.txtEventProb.Location = new System.Drawing.Point(107, 14);
            this.txtEventProb.Name = "txtEventProb";
            this.txtEventProb.Size = new System.Drawing.Size(60, 20);
            this.txtEventProb.TabIndex = 5;
            this.txtEventProb.Text = "0.01";
            this.txtEventProb.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Event Probability:";
            // 
            // howto_calculate_probabilities_Form1
            // 
            this.AcceptButton = this.btnGo;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(334, 261);
            this.Controls.Add(this.lvwResults);
            this.Controls.Add(this.btnGo);
            this.Controls.Add(this.txtEventProb);
            this.Controls.Add(this.label1);
            this.Name = "howto_calculate_probabilities_Form1";
            this.Text = "howto_calculate_probabilities";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lvwResults;
        private System.Windows.Forms.ColumnHeader colRepetitions;
        private System.Windows.Forms.ColumnHeader colProbability;
        private System.Windows.Forms.Button btnGo;
        private System.Windows.Forms.TextBox txtEventProb;
        private System.Windows.Forms.Label label1;
    }
}

