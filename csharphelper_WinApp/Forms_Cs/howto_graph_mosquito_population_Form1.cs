using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Drawing.Drawing2D;

 

namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_graph_mosquito_population_Form1:Form
  { 


        public howto_graph_mosquito_population_Form1()
        {
            InitializeComponent();
        }

        // Start or stop the simulation.
        private void btnStart_Click(object sender, EventArgs e)
        {
            tmrGeneration.Interval = int.Parse(txtInterval.Text);

            tmrGeneration.Enabled = !tmrGeneration.Enabled;
            if (tmrGeneration.Enabled)
            {
                // We just started.
                btnStart.Text = "Stop";
            }
            else
            {
                // We just stopped.
                btnStart.Text = "Start";
            }
        }

        // Reset the simulation.
        private void btnReset_Click(object sender, EventArgs e)
        {
            ResetData();
        }

        // Reset the data to the values in the TextBoxes.
        private void ResetData()
        {
            GenerationNumber = 0;
            NumFemales = int.Parse(txtNumFemales.Text);
            NumRegularMales = int.Parse(txtNumRegularMales.Text);
            NumModifiedMales = int.Parse(txtNumModifiedMales.Text);

            FemalePoints = new List<Point>();
            RegularMalePoints = new List<Point>();
            ModifiedMalePoints = new List<Point>();

            // Save points representing the initial values.
            FemalePoints.Add(new Point(GenerationNumber, NumFemales));
            RegularMalePoints.Add(new Point(GenerationNumber, NumRegularMales));
            ModifiedMalePoints.Add(new Point(GenerationNumber, NumModifiedMales));

            PopulationLimit = int.Parse(txtPopulationLimit.Text);
            EggsPerClutch = int.Parse(txtEggsPerClutch.Text);
            DisplayCurrentValues();
        }

        // Display the current values.
        private void DisplayCurrentValues()
        {
            lblGeneration.Text = "Generation: " + GenerationNumber;
            txtCurFemales.Text = NumFemales.ToString();
            txtCurRegularMales.Text = NumRegularMales.ToString();
            txtCurModifiedMales.Text = NumModifiedMales.ToString();

            // Graph the data.
            picGraph.Refresh();
        }

        // The generation number.
        private int GenerationNumber = 0;

        // The population limit.
        private double PopulationLimit;

        // The current numbers of each kind of mosquito.
        private int NumFemales = -1, NumRegularMales, NumModifiedMales, EggsPerClutch;

        // Data for the graph.
        private List<Point> FemalePoints,
            RegularMalePoints, ModifiedMalePoints;

        // Simulate a generation.
        private void tmrGeneration_Tick(object sender, EventArgs e)
        {
            // See if we need to start a new run.
            if (NumFemales == -1) ResetData();

            // Display the generation number.
            GenerationNumber++;
            lblGeneration.Text = "Gen: " + GenerationNumber;

            // Breed.
            double prob_regular =
                NumRegularMales / (double)(NumRegularMales + NumModifiedMales);
            Random rand = new Random();
            int num_baby_females = 0;
            int num_baby_regular_males = 0;
            int num_baby_modified_males = 0;
            for (int i = 0; i < NumFemales; i++)
            {
                // See if this female finds a regular male.
                if (rand.NextDouble() < prob_regular)
                {
                    // A regular male.
                    num_baby_females += EggsPerClutch / 2;
                    num_baby_regular_males += EggsPerClutch / 2;
                }
                else
                {
                    // A modified male.
                    num_baby_females += (int)(EggsPerClutch * 0.05);
                    num_baby_modified_males += (int)(EggsPerClutch * 0.95);
                }
            }

            // Update the totals.
            NumFemales = num_baby_females;
            NumRegularMales = num_baby_regular_males;
            NumModifiedMales = num_baby_modified_males;

            // Reduce to the population limit.
            double total_population = NumFemales +
                NumRegularMales + NumModifiedMales;
            if (total_population > PopulationLimit)
            {
                NumFemales = (int)(PopulationLimit *
                    NumFemales / total_population);
                NumRegularMales = (int)(PopulationLimit *
                    NumRegularMales / total_population);
                NumModifiedMales = (int)(PopulationLimit *
                    NumModifiedMales / total_population);
            }

            // Save points representing the new values.
            FemalePoints.Add(new Point(GenerationNumber, NumFemales));
            RegularMalePoints.Add(new Point(GenerationNumber, NumRegularMales));
            ModifiedMalePoints.Add(new Point(GenerationNumber, NumModifiedMales));

            // Display the current values.
            DisplayCurrentValues();
        }

        // Graph the data.
        private void picGraph_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(picGraph.BackColor);
            if (FemalePoints == null) return;
            if (FemalePoints.Count < 2) return;

            // Use the next multiple of 10 generations
            int num_generations =
                10 * (1 + (int)((GenerationNumber - 1) / 10.0));

            // Transform the graph.
            Rectangle source_rect = new Rectangle(
                0, 0, num_generations, (int)PopulationLimit);
            Point[] dest_points =
            {
                new Point(0, picGraph.ClientSize.Height),
                new Point(picGraph.ClientSize.Width, picGraph.ClientSize.Height),
                new Point(0, 0),
            };
            e.Graphics.Transform = new Matrix(
                source_rect, dest_points);

            using (Pen thin_pen = new Pen(Color.Gray, 0))
            {
                // Draw lines to show the generations.
                for (int i = 1; i < num_generations; i++)
                {
                    e.Graphics.DrawLine(thin_pen,
                        i, 0, i, (int)PopulationLimit);
                }

                // Draw the population data.
                thin_pen.Color = Color.Red;
                e.Graphics.DrawLines(thin_pen, FemalePoints.ToArray());
                thin_pen.Color = Color.Green;
                e.Graphics.DrawLines(thin_pen, RegularMalePoints.ToArray());
                thin_pen.Color = Color.Blue;
                e.Graphics.DrawLines(thin_pen, ModifiedMalePoints.ToArray());
            }
        }

        private void picGraph_Resize(object sender, EventArgs e)
        {
            picGraph.Refresh();
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
            this.components = new System.ComponentModel.Container();
            this.txtPopulationLimit = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtEggsPerClutch = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.lblGeneration = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtCurModifiedMales = new System.Windows.Forms.TextBox();
            this.txtCurRegularMales = new System.Windows.Forms.TextBox();
            this.txtCurFemales = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtInterval = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtNumModifiedMales = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtNumRegularMales = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNumFemales = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.picGraph = new System.Windows.Forms.PictureBox();
            this.tmrGeneration = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.picGraph)).BeginInit();
            this.SuspendLayout();
            // 
            // txtPopulationLimit
            // 
            this.txtPopulationLimit.Location = new System.Drawing.Point(102, 108);
            this.txtPopulationLimit.Name = "txtPopulationLimit";
            this.txtPopulationLimit.Size = new System.Drawing.Size(48, 20);
            this.txtPopulationLimit.TabIndex = 29;
            this.txtPopulationLimit.Text = "400";
            this.txtPopulationLimit.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 111);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(84, 13);
            this.label8.TabIndex = 45;
            this.label8.Text = "Population Limit:";
            // 
            // txtEggsPerClutch
            // 
            this.txtEggsPerClutch.Location = new System.Drawing.Point(102, 134);
            this.txtEggsPerClutch.Name = "txtEggsPerClutch";
            this.txtEggsPerClutch.Size = new System.Drawing.Size(48, 20);
            this.txtEggsPerClutch.TabIndex = 30;
            this.txtEggsPerClutch.Text = "200";
            this.txtEggsPerClutch.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 137);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(69, 13);
            this.label7.TabIndex = 44;
            this.label7.Text = "Eggs/Clutch:";
            // 
            // lblGeneration
            // 
            this.lblGeneration.AutoSize = true;
            this.lblGeneration.Location = new System.Drawing.Point(231, 85);
            this.lblGeneration.Name = "lblGeneration";
            this.lblGeneration.Size = new System.Drawing.Size(0, 13);
            this.lblGeneration.TabIndex = 43;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(167, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(48, 18);
            this.label6.TabIndex = 42;
            this.label6.Text = "Current";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtCurModifiedMales
            // 
            this.txtCurModifiedMales.Location = new System.Drawing.Point(167, 82);
            this.txtCurModifiedMales.Name = "txtCurModifiedMales";
            this.txtCurModifiedMales.ReadOnly = true;
            this.txtCurModifiedMales.Size = new System.Drawing.Size(48, 20);
            this.txtCurModifiedMales.TabIndex = 38;
            this.txtCurModifiedMales.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtCurRegularMales
            // 
            this.txtCurRegularMales.Location = new System.Drawing.Point(167, 56);
            this.txtCurRegularMales.Name = "txtCurRegularMales";
            this.txtCurRegularMales.ReadOnly = true;
            this.txtCurRegularMales.Size = new System.Drawing.Size(48, 20);
            this.txtCurRegularMales.TabIndex = 36;
            this.txtCurRegularMales.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtCurFemales
            // 
            this.txtCurFemales.Location = new System.Drawing.Point(167, 30);
            this.txtCurFemales.Name = "txtCurFemales";
            this.txtCurFemales.ReadOnly = true;
            this.txtCurFemales.Size = new System.Drawing.Size(48, 20);
            this.txtCurFemales.TabIndex = 35;
            this.txtCurFemales.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(102, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 18);
            this.label5.TabIndex = 41;
            this.label5.Text = "Initial";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtInterval
            // 
            this.txtInterval.Location = new System.Drawing.Point(102, 160);
            this.txtInterval.Name = "txtInterval";
            this.txtInterval.Size = new System.Drawing.Size(48, 20);
            this.txtInterval.TabIndex = 31;
            this.txtInterval.Text = "1000";
            this.txtInterval.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 163);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 13);
            this.label4.TabIndex = 40;
            this.label4.Text = "ms/generation:";
            // 
            // txtNumModifiedMales
            // 
            this.txtNumModifiedMales.Location = new System.Drawing.Point(102, 82);
            this.txtNumModifiedMales.Name = "txtNumModifiedMales";
            this.txtNumModifiedMales.Size = new System.Drawing.Size(48, 20);
            this.txtNumModifiedMales.TabIndex = 28;
            this.txtNumModifiedMales.Text = "5";
            this.txtNumModifiedMales.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 85);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 13);
            this.label3.TabIndex = 39;
            this.label3.Text = "Modified Males:";
            // 
            // txtNumRegularMales
            // 
            this.txtNumRegularMales.Location = new System.Drawing.Point(102, 56);
            this.txtNumRegularMales.Name = "txtNumRegularMales";
            this.txtNumRegularMales.Size = new System.Drawing.Size(48, 20);
            this.txtNumRegularMales.TabIndex = 27;
            this.txtNumRegularMales.Text = "195";
            this.txtNumRegularMales.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 13);
            this.label2.TabIndex = 37;
            this.label2.Text = "Normal Males:";
            // 
            // txtNumFemales
            // 
            this.txtNumFemales.Location = new System.Drawing.Point(102, 30);
            this.txtNumFemales.Name = "txtNumFemales";
            this.txtNumFemales.Size = new System.Drawing.Size(48, 20);
            this.txtNumFemales.TabIndex = 26;
            this.txtNumFemales.Text = "200";
            this.txtNumFemales.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 34;
            this.label1.Text = "Females:";
            // 
            // btnReset
            // 
            this.btnReset.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnReset.Location = new System.Drawing.Point(234, 54);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(75, 23);
            this.btnReset.TabIndex = 33;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(234, 28);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 32;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // picGraph
            // 
            this.picGraph.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.picGraph.BackColor = System.Drawing.Color.White;
            this.picGraph.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.picGraph.Location = new System.Drawing.Point(315, 12);
            this.picGraph.Name = "picGraph";
            this.picGraph.Size = new System.Drawing.Size(245, 167);
            this.picGraph.TabIndex = 46;
            this.picGraph.TabStop = false;
            this.picGraph.Resize += new System.EventHandler(this.picGraph_Resize);
            this.picGraph.Paint += new System.Windows.Forms.PaintEventHandler(this.picGraph_Paint);
            // 
            // tmrGeneration
            // 
            this.tmrGeneration.Tick += new System.EventHandler(this.tmrGeneration_Tick);
            // 
            // howto_graph_mosquito_population_Form1
            // 
            this.AcceptButton = this.btnStart;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnReset;
            this.ClientSize = new System.Drawing.Size(572, 191);
            this.Controls.Add(this.picGraph);
            this.Controls.Add(this.txtPopulationLimit);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtEggsPerClutch);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.lblGeneration);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtCurModifiedMales);
            this.Controls.Add(this.txtCurRegularMales);
            this.Controls.Add(this.txtCurFemales);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtInterval);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtNumModifiedMales);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtNumRegularMales);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtNumFemales);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnStart);
            this.Name = "howto_graph_mosquito_population_Form1";
            this.Text = "howto_graph_mosquito_population";
            ((System.ComponentModel.ISupportInitialize)(this.picGraph)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtPopulationLimit;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtEggsPerClutch;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblGeneration;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtCurModifiedMales;
        private System.Windows.Forms.TextBox txtCurRegularMales;
        private System.Windows.Forms.TextBox txtCurFemales;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtInterval;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtNumModifiedMales;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtNumRegularMales;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtNumFemales;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.PictureBox picGraph;
        private System.Windows.Forms.Timer tmrGeneration;
    }
}

