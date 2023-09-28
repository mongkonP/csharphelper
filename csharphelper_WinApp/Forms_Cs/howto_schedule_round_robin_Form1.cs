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
     public partial class howto_schedule_round_robin_Form1:Form
  { 


        public howto_schedule_round_robin_Form1()
        {
            InitializeComponent();
        }

        private const int BYE = -1;

        // Schedule the round robin.
        private void btnGo_Click(object sender, EventArgs e)
        {
            // Get the schedule.
            int num_teams = (int)nudNumTeams.Value;
            int[,] results = GenerateRoundRobin(num_teams);

            // Display the result.
            string txt = "";
            for (int round = 0; round <= results.GetUpperBound(1); round++)
            {
                txt += "Round " + round + ":\r\n";
                for (int team = 0; team < num_teams; team++)
                {
                    if (results[team, round] == BYE)
                    {
                        txt += "    " + team + " (bye)\r\n";
                    } else if (team < results[team, round])
                    {
                        txt += "    " + team + " v " + results[team, round] + "\r\n";
                    }
                }
            }

            txtResults.Text = txt;
        }

        // Return an array where results(i, j) gives
        // the opponent of team i in round j.
        private int[,] GenerateRoundRobin(int num_teams)
        {
            if (num_teams % 2 == 0)
                return GenerateRoundRobinEven(num_teams);
            else
                return GenerateRoundRobinOdd(num_teams);
        }

        // Return an array where results(i, j) gives
        // the opponent of team i in round j.
        // Note: num_teams must be odd.
        private int [,] GenerateRoundRobinOdd(int num_teams)
        {
            int n2 = (int)((num_teams - 1) / 2);
            int[,] results = new int[num_teams, num_teams];

            // Initialize the list of teams.
            int[] teams = new int[num_teams];
            for (int i = 0; i < num_teams; i++) teams[i] = i;

            // Start the rounds.
            for (int round = 0; round < num_teams; round++)
            {
                for (int i = 0; i < n2; i++)
                {
                    int team1 = teams[n2 - i];
                    int team2 = teams[n2 + i + 1];
                    results[team1, round] = team2;
                    results[team2, round] = team1;
                }

                // Set the team with the bye.
                results[teams[0], round] = BYE;

                // Rotate the array.
                RotateArray(teams);
            }

            return results;
        }

        // Return an array where results(i, j) gives
        // the opponent of team i in round j.
        // Note: num_teams must be even.
        private int[,] GenerateRoundRobinEven(int num_teams)
        {
            // Generate the result for one fewer teams.
            int[,] results = GenerateRoundRobinOdd(num_teams - 1);

            // Copy the results into a bigger array,
            // replacing the byes with the extra team.
            int[,] results2 = new int[num_teams, num_teams - 1];
            for (int team = 0; team < num_teams - 1; team++)
            {
                for (int round = 0; round < num_teams - 1; round++)
                {
                    if (results[team, round] == BYE)
                    {
                        // Change the bye to the new team.
                        results2[team, round] = num_teams - 1;
                        results2[num_teams - 1, round] = team;
                    }
                    else
                    {
                        results2[team, round] = results[team, round];
                    }
                }
            }

            return results2;
        }

        // Rotate the entries one position.
        private void RotateArray(int[] teams)
        {
            int tmp = teams[teams.Length - 1];
            Array.Copy(teams, 0, teams, 1, teams.Length - 1);
            teams[0] = tmp;
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
            this.txtResults = new System.Windows.Forms.TextBox();
            this.btnGo = new System.Windows.Forms.Button();
            this.Label1 = new System.Windows.Forms.Label();
            this.nudNumTeams = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.nudNumTeams)).BeginInit();
            this.SuspendLayout();
            // 
            // txtResults
            // 
            this.txtResults.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtResults.Location = new System.Drawing.Point(12, 41);
            this.txtResults.Multiline = true;
            this.txtResults.Name = "txtResults";
            this.txtResults.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtResults.Size = new System.Drawing.Size(310, 208);
            this.txtResults.TabIndex = 2;
            // 
            // btnGo
            // 
            this.btnGo.Location = new System.Drawing.Point(142, 12);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(75, 23);
            this.btnGo.TabIndex = 1;
            this.btnGo.Text = "Go";
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(12, 17);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(49, 13);
            this.Label1.TabIndex = 5;
            this.Label1.Text = "# Teams";
            // 
            // nudNumTeams
            // 
            this.nudNumTeams.Location = new System.Drawing.Point(67, 15);
            this.nudNumTeams.Name = "nudNumTeams";
            this.nudNumTeams.Size = new System.Drawing.Size(53, 20);
            this.nudNumTeams.TabIndex = 0;
            this.nudNumTeams.Value = new decimal(new int[] {
            6,
            0,
            0,
            0});
            // 
            // howto_schedule_round_robin_Form1
            // 
            this.AcceptButton = this.btnGo;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(334, 261);
            this.Controls.Add(this.nudNumTeams);
            this.Controls.Add(this.txtResults);
            this.Controls.Add(this.btnGo);
            this.Controls.Add(this.Label1);
            this.Name = "howto_schedule_round_robin_Form1";
            this.Text = "howto_schedule_round_robin";
            ((System.ComponentModel.ISupportInitialize)(this.nudNumTeams)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.TextBox txtResults;
        internal System.Windows.Forms.Button btnGo;
        internal System.Windows.Forms.Label Label1;
        private System.Windows.Forms.NumericUpDown nudNumTeams;
    }
}

