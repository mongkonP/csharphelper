using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Drawing.Drawing2D;
using System.Drawing.Text;

 

namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_roll_two_dice_Form1:Form
  { 


        public howto_roll_two_dice_Form1()
        {
            InitializeComponent();
        }

        // Generate the rolls.
        private void btnRoll_Click(object sender, EventArgs e)
        {
            picGraph.Image = null;
            Cursor = Cursors.WaitCursor;
            Refresh();

            // Make an array to hold value counts.
            // The value counts[i] represents rolls of i.
            long[] counts = new long[13];

            // Roll.
            Random rand = new Random();
            long numTrials = long.Parse(txtNumTrials.Text);
            for (int i = 0; i < numTrials; i++)
            {
                int result = rand.Next(1, 7) + rand.Next(1, 7);
                counts[result]++;
            }

            // The expected percentages.
            float[] expected = 
            {
                0, 0, 1 / 36f, 2 / 36f, 3 / 36f, 4 / 36f, 5 / 36f, 
                6 / 36f, 5 / 36f, 4 / 36f, 3 / 36f, 2 / 36f, 1 / 36f
            };

            // Display the results.
            Bitmap bm = new Bitmap(
                picGraph.ClientSize.Width,
                picGraph.ClientSize.Height);
            using (Graphics gr = Graphics.FromImage(bm))
            {
                gr.SmoothingMode = SmoothingMode.AntiAlias;
                gr.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;
                using (StringFormat sf = new StringFormat())
                {
                    sf.Alignment = StringAlignment.Center;
                    sf.LineAlignment = StringAlignment.Far;

                    float ymax = picGraph.ClientSize.Height;
                    float scale_x = picGraph.ClientSize.Width / 11;
                    float max_y = Math.Max(counts.Max(), numTrials * expected.Max());
                    float scale_y = ymax / (max_y * 1.05f);
                    for (int i = 2; i <= 12; i++)
                    {
                        gr.FillRectangle(Brushes.LightBlue,
                            (i - 2) * scale_x, ymax - counts[i] * scale_y,
                            scale_x, counts[i] * scale_y);
                        gr.DrawRectangle(Pens.Blue,
                            (i - 2) * scale_x, ymax - counts[i] * scale_y,
                            scale_x, counts[i] * scale_y);

                        float percent = 100 * counts[i] / (float)numTrials;
                        float expected_percent = 100 * expected[i];
                        float error = 100 * (expected_percent - percent) / expected_percent;
                        string txt = percent.ToString("0.00") +
                            Environment.NewLine +
                            expected_percent.ToString("0.00") +
                            Environment.NewLine +
                            error.ToString("0.00") + "%";
                        gr.DrawString(txt, this.Font, Brushes.Black,
                            (i - 2) * scale_x, ymax - counts[i] * scale_y);
                    }

                    // Scale the expected percentages for the number of rolls.
                    for (int i = 0; i < expected.Length; i++)
                    {
                        expected[i] *= numTrials;
                    }

                    // Draw the expected results.
                    List<PointF> expected_points = new List<PointF>();
                    expected_points.Add(new PointF(0, ymax));
                    for (int i = 2; i <= 12; i++)
                    {
                        float y = ymax - expected[i] * scale_y;
                        expected_points.Add(new PointF((i - 2) * scale_x, y));
                        expected_points.Add(new PointF((i - 1) * scale_x, y));
                    }
                    expected_points.Add(new PointF(11 * scale_x, ymax));
                    using (Pen red_pen = new Pen(Color.Red, 3))
                    {
                        gr.DrawLines(red_pen, expected_points.ToArray());
                    }
                }
            }

            picGraph.Image = bm;
            Cursor = Cursors.Default;
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
            this.picGraph = new System.Windows.Forms.PictureBox();
            this.txtNumTrials = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnRoll = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picGraph)).BeginInit();
            this.SuspendLayout();
            // 
            // picGraph
            // 
            this.picGraph.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.picGraph.BackColor = System.Drawing.Color.White;
            this.picGraph.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.picGraph.Location = new System.Drawing.Point(3, 41);
            this.picGraph.Name = "picGraph";
            this.picGraph.Size = new System.Drawing.Size(438, 218);
            this.picGraph.TabIndex = 11;
            this.picGraph.TabStop = false;
            // 
            // txtNumTrials
            // 
            this.txtNumTrials.Location = new System.Drawing.Point(63, 15);
            this.txtNumTrials.Name = "txtNumTrials";
            this.txtNumTrials.Size = new System.Drawing.Size(69, 20);
            this.txtNumTrials.TabIndex = 8;
            this.txtNumTrials.Text = "100";
            this.txtNumTrials.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "# Trials:";
            // 
            // btnRoll
            // 
            this.btnRoll.Location = new System.Drawing.Point(138, 12);
            this.btnRoll.Name = "btnRoll";
            this.btnRoll.Size = new System.Drawing.Size(75, 23);
            this.btnRoll.TabIndex = 10;
            this.btnRoll.Text = "Roll";
            this.btnRoll.UseVisualStyleBackColor = true;
            this.btnRoll.Click += new System.EventHandler(this.btnRoll_Click);
            // 
            // howto_roll_two_dice_Form1
            // 
            this.AcceptButton = this.btnRoll;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(444, 261);
            this.Controls.Add(this.picGraph);
            this.Controls.Add(this.txtNumTrials);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnRoll);
            this.Name = "howto_roll_two_dice_Form1";
            this.Text = "howto_roll_two_dice";
            ((System.ComponentModel.ISupportInitialize)(this.picGraph)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picGraph;
        private System.Windows.Forms.TextBox txtNumTrials;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnRoll;
    }
}

