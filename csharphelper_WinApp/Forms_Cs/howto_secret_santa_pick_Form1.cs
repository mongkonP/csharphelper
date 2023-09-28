using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

 

using howto_secret_santa_pick;
namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_secret_santa_pick_Form1:Form
  { 


        public howto_secret_santa_pick_Form1()
        {
            InitializeComponent();
        }

        // Make a random number generator.
        private Random Rand = new Random();

        private void btnPick_Click(object sender, EventArgs e)
        {
            // Find a random assignment.
            int N = int.Parse(txtNumPeople.Text);
            int num_tries;
            int[] assignments = SecretSantaAssignment(N, out num_tries);

            txtNumTries.Text = num_tries.ToString();
            lstAssignments.Items.Clear();
            for (int i = 0; i < N; i++)
            {
                lstAssignments.Items.Add(i.ToString() +
                    " --> " + assignments[i].ToString());
            }
        }

        // Generate a random derangement.
        private int[] SecretSantaAssignment(int N, out int num_tries)
        {
            // Make an array to hold the assignment.
            int[] assignments = new int[N];
            for (int i = 0; i < N; i++)
                assignments[i] = i;

            // Try random permutations until we find one that works.
            //Console.WriteLine();
            num_tries = 0;
            for (; ; )
            {
                // Randomize the assignment array.
                num_tries++;
                assignments.Randomize();

                // Display this permutation.
                //for (int i = 0; i < N; i++) Console.Write(assignments[i].ToString() + " ");
                //Console.WriteLine();

                // If this is an invalid assignment, try again.
                bool is_valid = true;
                for (int i = 0; i < N; i++)
                {
                    if (assignments[i] == i)
                    {
                        is_valid = false;
                        break;
                    }
                }

                // See if this is a valid assignment.
                if (is_valid) break;
            }

            return assignments;
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
            this.btnPick = new System.Windows.Forms.Button();
            this.txtNumPeople = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lstAssignments = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNumTries = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnPick
            // 
            this.btnPick.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPick.Location = new System.Drawing.Point(217, 12);
            this.btnPick.Name = "btnPick";
            this.btnPick.Size = new System.Drawing.Size(75, 23);
            this.btnPick.TabIndex = 5;
            this.btnPick.Text = "Pick";
            this.btnPick.UseVisualStyleBackColor = true;
            this.btnPick.Click += new System.EventHandler(this.btnPick_Click);
            // 
            // txtNumPeople
            // 
            this.txtNumPeople.Location = new System.Drawing.Point(71, 14);
            this.txtNumPeople.Name = "txtNumPeople";
            this.txtNumPeople.Size = new System.Drawing.Size(63, 20);
            this.txtNumPeople.TabIndex = 4;
            this.txtNumPeople.Text = "5";
            this.txtNumPeople.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "# People:";
            // 
            // lstAssignments
            // 
            this.lstAssignments.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lstAssignments.FormattingEnabled = true;
            this.lstAssignments.IntegralHeight = false;
            this.lstAssignments.Location = new System.Drawing.Point(15, 40);
            this.lstAssignments.Name = "lstAssignments";
            this.lstAssignments.Size = new System.Drawing.Size(277, 133);
            this.lstAssignments.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 182);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "# Tries:";
            // 
            // txtNumTries
            // 
            this.txtNumTries.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtNumTries.Location = new System.Drawing.Point(71, 179);
            this.txtNumTries.Name = "txtNumTries";
            this.txtNumTries.ReadOnly = true;
            this.txtNumTries.Size = new System.Drawing.Size(63, 20);
            this.txtNumTries.TabIndex = 9;
            this.txtNumTries.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // howto_secret_santa_pick_Form1
            // 
            this.AcceptButton = this.btnPick;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(304, 211);
            this.Controls.Add(this.txtNumTries);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lstAssignments);
            this.Controls.Add(this.btnPick);
            this.Controls.Add(this.txtNumPeople);
            this.Controls.Add(this.label1);
            this.Name = "howto_secret_santa_pick_Form1";
            this.Text = "howto_secret_santa_pick";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnPick;
        private System.Windows.Forms.TextBox txtNumPeople;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox lstAssignments;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtNumTries;
    }
}

