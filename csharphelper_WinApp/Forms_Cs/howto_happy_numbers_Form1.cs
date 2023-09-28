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
     public partial class howto_happy_numbers_Form1:Form
  { 


        public howto_happy_numbers_Form1()
        {
            InitializeComponent();
        }

        // The lengths of the numbers' happy loops.
        private PointF[] HappyLoopLengths = null;

        // The number of steps before detecting the happy loops.
        private PointF[] HappyLoopStarts = null;

        private void howto_happy_numbers_Form1_Load(object sender, EventArgs e)
        {
            lblMaxStart.Text = "";
            lblMaxLength.Text = "";
            lblSequence.Text = "";
        }

        // Return true if the number is prime.
        private bool IsPrime(int num)
        {
            // Handle 1 and 2 separately.
            if (num == 1) return false;
            if (num == 2) return true;
            if (num % 2 == 0) return false;

            // See if the number is divisible by odd values up to Sqrt(number).
            int sqrt = (int)(Math.Sqrt(num) + 1);
            for (int i = 3; i < sqrt; i++)
                if (num % i == 0) return false;

            // If we get here, the number is prime.
            return true;
        }

        // Calculate happy loops.
        private void btnGo_Click(object sender, EventArgs e)
        {
            int max = int.Parse(txtMax.Text);
            lvwResults.Items.Clear();
            lblMaxStart.Text = "";
            lblMaxLength.Text = "";
            lblSequence.Text = "";
            Cursor = Cursors.WaitCursor;
            Refresh();

            // Find the happy loop lengths and starts.
            HappyLoopLengths = new PointF[max];
            HappyLoopStarts = new PointF[max];
            int max_start = 0;
            int max_length = 0;
            for (int i = 1; i <= max; i++)
            {
                int loop_length, loop_start;
                FindHappyLoop(i, out loop_start, out loop_length);
                if (max_start < loop_start) max_start = loop_start;
                if (max_length < loop_length) max_length = loop_length;
                HappyLoopLengths[i - 1] = new PointF(i, loop_length);
                HappyLoopStarts[i - 1] = new PointF(i, loop_start);

                ListViewItem item = lvwResults.Items.Add(i.ToString());
                item.SubItems.Add(HappyLoopStarts[i - 1].Y.ToString());
                item.SubItems.Add(HappyLoopLengths[i - 1].Y.ToString());
                item.UseItemStyleForSubItems = false;
                item.SubItems[1].ForeColor = Color.Red;
                item.SubItems[2].ForeColor = Color.Blue;
                if (IsPrime(i))
                {
                    item.BackColor = Color.Pink;
                    item.SubItems[1].BackColor = Color.Pink;
                    item.SubItems[2].BackColor = Color.Pink;
                }
            }

            lblMaxStart.Text = HappyLoopStarts.Max(p => p.Y).ToString();
            lblMaxLength.Text = HappyLoopLengths.Max(p => p.Y).ToString();
            Console.WriteLine("Max Start: " + max_start);
            Console.WriteLine("Max Length: " + max_length);

            picGraph.Refresh();

            Cursor = Cursors.Default;
        }

        // Return the length and start position of the number's happy loop.
        private List<int> FindHappyLoop(int num, out int loop_start, out int loop_length)
        {
            List<int> list = new List<int>();
            list.Add(num);
            for (; ; )
            {
                string str = num.ToString();
                num = 0;
                foreach (char ch in str)
                {
                    int digit = int.Parse(ch.ToString());
                    num += digit * digit;
                }
                if (list.Contains(num))
                {
                    loop_start = list.IndexOf(num);
                    loop_length = list.Count - loop_start;
                    return list;
                }
                list.Add(num);
            }
        }

        // Draw the happy points.
        private void picGraph_Paint(object sender, PaintEventArgs e)
        {
            if (HappyLoopLengths == null) return;

            e.Graphics.Clear(picGraph.BackColor);
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            // Map the world coordinates onto the PictureBox.
            float ymin = 0;
            float ymax = Math.Max(
                HappyLoopLengths.Max(p => p.Y),
                HappyLoopStarts.Max(p => p.Y));
            float xmin = 1;
            float xmax = HappyLoopLengths.Length;
            RectangleF world_rect = new RectangleF(
                xmin, ymin, xmax - xmin, ymax - ymin);
            const int margin = 10;
            PointF[] device_points =
            {
                new PointF(margin, picGraph.ClientSize.Height - margin),
                new PointF(picGraph.ClientSize.Width - margin, picGraph.ClientSize.Height - margin),
                new PointF(margin, margin),
            };
            e.Graphics.Transform = new Matrix(world_rect, device_points);

            // Draw.
            using (Pen pen = new Pen(Color.Red, 0))
            {
                e.Graphics.DrawLines(pen, HappyLoopStarts);
                pen.Color = Color.Blue;
                e.Graphics.DrawLines(pen, HappyLoopLengths);
            }
        }
        private void howto_happy_numbers_Form1_Resize(object sender, EventArgs e)
        {
            picGraph.Refresh();
        }
        
        // Display the selected number's happy sequence.
        private void lvwResults_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvwResults.SelectedIndices.Count < 1) return;
            int num = lvwResults.SelectedIndices[0] + 1;
            int loop_start, loop_length;
            List<int> sequence = FindHappyLoop(num, out loop_start, out loop_length);
            sequence.Add(sequence[loop_start]);
            lblSequence.Text = string.Join(" ",
                sequence.ConvertAll(i => i.ToString()).ToArray());
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
            this.txtMax = new System.Windows.Forms.TextBox();
            this.btnGo = new System.Windows.Forms.Button();
            this.picGraph = new System.Windows.Forms.PictureBox();
            this.lvwResults = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.label2 = new System.Windows.Forms.Label();
            this.lblMaxStart = new System.Windows.Forms.Label();
            this.lblMaxLength = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblSequence = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picGraph)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Max #:";
            // 
            // txtMax
            // 
            this.txtMax.Location = new System.Drawing.Point(58, 14);
            this.txtMax.Name = "txtMax";
            this.txtMax.Size = new System.Drawing.Size(119, 20);
            this.txtMax.TabIndex = 1;
            this.txtMax.Text = "100";
            this.txtMax.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnGo
            // 
            this.btnGo.Location = new System.Drawing.Point(183, 12);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(75, 23);
            this.btnGo.TabIndex = 2;
            this.btnGo.Text = "Go";
            this.btnGo.UseVisualStyleBackColor = true;
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // picGraph
            // 
            this.picGraph.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.picGraph.BackColor = System.Drawing.Color.White;
            this.picGraph.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.picGraph.Location = new System.Drawing.Point(183, 41);
            this.picGraph.Name = "picGraph";
            this.picGraph.Size = new System.Drawing.Size(349, 195);
            this.picGraph.TabIndex = 4;
            this.picGraph.TabStop = false;
            this.picGraph.Paint += new System.Windows.Forms.PaintEventHandler(this.picGraph_Paint);
            // 
            // lvwResults
            // 
            this.lvwResults.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.lvwResults.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.lvwResults.FullRowSelect = true;
            this.lvwResults.Location = new System.Drawing.Point(12, 41);
            this.lvwResults.Name = "lvwResults";
            this.lvwResults.Size = new System.Drawing.Size(165, 195);
            this.lvwResults.TabIndex = 5;
            this.lvwResults.UseCompatibleStateImageBehavior = false;
            this.lvwResults.View = System.Windows.Forms.View.Details;
            this.lvwResults.SelectedIndexChanged += new System.EventHandler(this.lvwResults_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "#";
            this.columnHeader1.Width = 35;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Start";
            this.columnHeader2.Width = 50;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Length";
            this.columnHeader3.Width = 50;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(281, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Max Start:";
            // 
            // lblMaxStart
            // 
            this.lblMaxStart.AutoSize = true;
            this.lblMaxStart.Location = new System.Drawing.Point(342, 17);
            this.lblMaxStart.Name = "lblMaxStart";
            this.lblMaxStart.Size = new System.Drawing.Size(25, 13);
            this.lblMaxStart.TabIndex = 7;
            this.lblMaxStart.Text = "100";
            // 
            // lblMaxLength
            // 
            this.lblMaxLength.AutoSize = true;
            this.lblMaxLength.Location = new System.Drawing.Point(471, 17);
            this.lblMaxLength.Name = "lblMaxLength";
            this.lblMaxLength.Size = new System.Drawing.Size(25, 13);
            this.lblMaxLength.TabIndex = 9;
            this.lblMaxLength.Text = "100";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(399, 17);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Max Length:";
            // 
            // lblSequence
            // 
            this.lblSequence.AutoSize = true;
            this.lblSequence.Location = new System.Drawing.Point(77, 239);
            this.lblSequence.Name = "lblSequence";
            this.lblSequence.Size = new System.Drawing.Size(25, 13);
            this.lblSequence.TabIndex = 11;
            this.lblSequence.Text = "100";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 239);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Sequence:";
            // 
            // howto_happy_numbers_Form1
            // 
            this.AcceptButton = this.btnGo;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(544, 261);
            this.Controls.Add(this.lblSequence);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lblMaxLength);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblMaxStart);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lvwResults);
            this.Controls.Add(this.picGraph);
            this.Controls.Add(this.btnGo);
            this.Controls.Add(this.txtMax);
            this.Controls.Add(this.label1);
            this.Name = "howto_happy_numbers_Form1";
            this.Text = "howto_happy_numbers";
            this.Load += new System.EventHandler(this.howto_happy_numbers_Form1_Load);
            this.Resize += new System.EventHandler(this.howto_happy_numbers_Form1_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.picGraph)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtMax;
        private System.Windows.Forms.Button btnGo;
        private System.Windows.Forms.PictureBox picGraph;
        private System.Windows.Forms.ListView lvwResults;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblMaxStart;
        private System.Windows.Forms.Label lblMaxLength;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblSequence;
        private System.Windows.Forms.Label label5;
    }
}

