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
     public partial class howto_calculate_probability_trials_Form1:Form
  { 


        public howto_calculate_probability_trials_Form1()
        {
            InitializeComponent();
        }

        // See how many trials it takes to get to the target probability.
        private void btnGo_Click(object sender, EventArgs e)
        {
            lvwResults.Items.Clear();

            // See if the event probability contains a % sign.
            bool percent = txtEventProb.Text.Contains("%");

            // Get the event and target probabilities.
            double event_prob = ParseProbability(txtEventProb.Text);
            double target_prob = ParseProbability(txtTargetProb.Text);

            // Get the probability of the event not happening.
            double non_prob = 1 - event_prob;

            // target_prob = 1 - non_prob ^ power. Solving for power gives
            // power = Log(1 - target_prob) base non_prob.
            double calculated_trial = Math.Log(1 - target_prob, non_prob);

            // Display probaility for 1 less trial.
            double trial = (int)calculated_trial;
            double prob = 1.0 - Math.Pow(non_prob, trial);
            DisplayTrial(trial, prob, percent);

            // Display probaility for the calculated trial.
            trial = calculated_trial;
            prob = 1.0 - Math.Pow(non_prob, trial);
            DisplayTrial(trial, prob, percent);

            // Display probaility for 1 more trial.
            trial = (int)calculated_trial + 1;
            prob = 1.0 - Math.Pow(non_prob, trial);
            DisplayTrial(trial, prob, percent);
        }

        // Parse a probability that may include a percent sign.
        private double ParseProbability(string txt)
        {
            // See if the probability contains a % sign.
            bool percent = txt.Contains("%");

            // Get the probability.
            double prob = double.Parse(txt.Replace("%", ""));

            // If we're using percents, divide by 100.
            if (percent) prob /= 100.0;

            return prob;
        }

        // Display a trial and its probability.
        private void DisplayTrial(double trial, double prob, bool percent)
        {
            ListViewItem new_item = lvwResults.Items.Add(trial.ToString());
            if (percent)
            {
                prob *= 100.0;
                new_item.SubItems.Add(prob.ToString() + "%");
            }
            else
            {
                new_item.SubItems.Add(prob.ToString());
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
            this.txtTargetProb = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
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
            this.lvwResults.Location = new System.Drawing.Point(12, 66);
            this.lvwResults.Name = "lvwResults";
            this.lvwResults.Size = new System.Drawing.Size(335, 83);
            this.lvwResults.TabIndex = 15;
            this.lvwResults.UseCompatibleStateImageBehavior = false;
            this.lvwResults.View = System.Windows.Forms.View.Details;
            // 
            // colRepetitions
            // 
            this.colRepetitions.Text = "Repetitions";
            this.colRepetitions.Width = 100;
            // 
            // colProbability
            // 
            this.colProbability.Text = "Probability";
            this.colProbability.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.colProbability.Width = 170;
            // 
            // txtTargetProb
            // 
            this.txtTargetProb.Location = new System.Drawing.Point(107, 40);
            this.txtTargetProb.Name = "txtTargetProb";
            this.txtTargetProb.Size = new System.Drawing.Size(60, 20);
            this.txtTargetProb.TabIndex = 14;
            this.txtTargetProb.Text = "50%";
            this.txtTargetProb.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "Target Probability:";
            // 
            // btnGo
            // 
            this.btnGo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGo.Location = new System.Drawing.Point(272, 12);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(75, 23);
            this.btnGo.TabIndex = 12;
            this.btnGo.Text = "Go";
            this.btnGo.UseVisualStyleBackColor = true;
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // txtEventProb
            // 
            this.txtEventProb.Location = new System.Drawing.Point(107, 14);
            this.txtEventProb.Name = "txtEventProb";
            this.txtEventProb.Size = new System.Drawing.Size(60, 20);
            this.txtEventProb.TabIndex = 11;
            this.txtEventProb.Text = "1%";
            this.txtEventProb.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Event Probability:";
            // 
            // howto_calculate_probability_trials_Form1
            // 
            this.AcceptButton = this.btnGo;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(359, 161);
            this.Controls.Add(this.lvwResults);
            this.Controls.Add(this.txtTargetProb);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnGo);
            this.Controls.Add(this.txtEventProb);
            this.Controls.Add(this.label1);
            this.Name = "howto_calculate_probability_trials_Form1";
            this.Text = "howto_calculate_probability_trials";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lvwResults;
        private System.Windows.Forms.ColumnHeader colRepetitions;
        private System.Windows.Forms.ColumnHeader colProbability;
        private System.Windows.Forms.TextBox txtTargetProb;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnGo;
        private System.Windows.Forms.TextBox txtEventProb;
        private System.Windows.Forms.Label label1;
    }
}

