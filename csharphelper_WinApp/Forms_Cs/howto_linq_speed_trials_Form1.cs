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
     public partial class howto_linq_speed_trials_Form1:Form
  { 


        public howto_linq_speed_trials_Form1()
        {
            InitializeComponent();
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            txt2Queries.Clear();
            txt1Query.Clear();
            txtArray.Clear();
            txtLoop.Clear();
            txtForeach.Clear();
            Cursor = Cursors.WaitCursor;
            Refresh();

            // Create the random values.
            int num_items = int.Parse(txtNumItems.Text);
            Point[] points = new Point[num_items];
            Random rand = new Random();
            for (int i = 0; i < num_items; i++)
                points[i] = new Point(
                    rand.Next(int.MinValue, int.MaxValue),
                    rand.Next(int.MinValue, int.MaxValue));

            Stopwatch watch = new Stopwatch();

            // Find the minimum and maximum values in 2 queries.
            watch.Reset();
            watch.Start();
            int xmin = (from Point p in points select p.X).Min();
            int xmax = (from Point p in points select p.X).Max();
            watch.Stop();
            txt2Queries.Text =
                watch.Elapsed.TotalSeconds.ToString("0.00") +
                " sec";
            Refresh();

            // Find the minimum and maximum values in 1 reused query.
            watch.Reset();
            watch.Start();
            var x_query = from Point p in points select p.X;
            xmin = x_query.Min();
            xmax = x_query.Max();
            watch.Stop();
            txt1Query.Text =
                watch.Elapsed.TotalSeconds.ToString("0.00") +
                " sec";
            Refresh();

            // Find the minimum and maximum values with an array.
            watch.Reset();
            watch.Start();
            var arr_query = from Point p in points select p.X;
            int[] xs = arr_query.ToArray();
            xmin = xs.Min();
            xmax = xs.Max();
            watch.Stop();
            txtArray.Text =
                watch.Elapsed.TotalSeconds.ToString("0.00") +
                " sec";
            Refresh();

            // Find the minimum and maximum values with a loop.
            watch.Reset();
            watch.Start();
            xmin = points[0].X;
            xmax = xmin;
            for (int i = 1; i < points.Length; i++)
            {
                if (xmin > points[i].X) xmin = points[i].X;
                if (xmax < points[i].X) xmax = points[i].X;
            }
            watch.Stop();
            txtLoop.Text =
                watch.Elapsed.TotalSeconds.ToString("0.00") +
                " sec";
            Refresh();

            // Find the minimum and maximum values with a foreach loop.
            watch.Reset();
            watch.Start();
            xmin = points[0].X;
            xmax = xmin;
            foreach (Point pt in points)
            {
                if (xmin > pt.X) xmin = pt.X;
                if (xmax < pt.X) xmax = pt.X;
            }
            watch.Stop();
            txtForeach.Text =
                watch.Elapsed.TotalSeconds.ToString("0.00") +
                " sec";
            Refresh();

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
            this.txtForeach = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtLoop = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtArray = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txt1Query = new System.Windows.Forms.TextBox();
            this.txt2Queries = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNumItems = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnGo = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtForeach
            // 
            this.txtForeach.Location = new System.Drawing.Point(73, 160);
            this.txtForeach.Name = "txtForeach";
            this.txtForeach.Size = new System.Drawing.Size(70, 20);
            this.txtForeach.TabIndex = 25;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 163);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(49, 13);
            this.label6.TabIndex = 24;
            this.label6.Text = "Foreach:";
            // 
            // txtLoop
            // 
            this.txtLoop.Location = new System.Drawing.Point(73, 134);
            this.txtLoop.Name = "txtLoop";
            this.txtLoop.Size = new System.Drawing.Size(70, 20);
            this.txtLoop.TabIndex = 23;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 137);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(34, 13);
            this.label5.TabIndex = 22;
            this.label5.Text = "Loop:";
            // 
            // txtArray
            // 
            this.txtArray.Location = new System.Drawing.Point(73, 108);
            this.txtArray.Name = "txtArray";
            this.txtArray.Size = new System.Drawing.Size(70, 20);
            this.txtArray.TabIndex = 21;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 111);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 13);
            this.label3.TabIndex = 20;
            this.label3.Text = "Array:";
            // 
            // txt1Query
            // 
            this.txt1Query.Location = new System.Drawing.Point(73, 82);
            this.txt1Query.Name = "txt1Query";
            this.txt1Query.Size = new System.Drawing.Size(70, 20);
            this.txt1Query.TabIndex = 19;
            // 
            // txt2Queries
            // 
            this.txt2Queries.Location = new System.Drawing.Point(73, 56);
            this.txt2Queries.Name = "txt2Queries";
            this.txt2Queries.Size = new System.Drawing.Size(70, 20);
            this.txt2Queries.TabIndex = 18;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 85);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 13);
            this.label4.TabIndex = 17;
            this.label4.Text = "1 Query:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 16;
            this.label2.Text = "2 Queries:";
            // 
            // txtNumItems
            // 
            this.txtNumItems.Location = new System.Drawing.Point(73, 14);
            this.txtNumItems.Name = "txtNumItems";
            this.txtNumItems.Size = new System.Drawing.Size(70, 20);
            this.txtNumItems.TabIndex = 15;
            this.txtNumItems.Text = "10000000";
            this.txtNumItems.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "# Items:";
            // 
            // btnGo
            // 
            this.btnGo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGo.Location = new System.Drawing.Point(197, 12);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(75, 23);
            this.btnGo.TabIndex = 26;
            this.btnGo.Text = "Go";
            this.btnGo.UseVisualStyleBackColor = true;
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // howto_linq_speed_trials_Form1
            // 
            this.AcceptButton = this.btnGo;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 193);
            this.Controls.Add(this.btnGo);
            this.Controls.Add(this.txtForeach);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtLoop);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtArray);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txt1Query);
            this.Controls.Add(this.txt2Queries);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtNumItems);
            this.Controls.Add(this.label1);
            this.Name = "howto_linq_speed_trials_Form1";
            this.Text = "howto_linq_speed_trials";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtForeach;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtLoop;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtArray;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt1Query;
        private System.Windows.Forms.TextBox txt2Queries;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtNumItems;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnGo;
    }
}

