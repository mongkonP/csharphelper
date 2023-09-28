using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// See http://www.codeproject.com/Articles/6759/FOREACH-Vs-FOR-C

using System.Diagnostics;

 

namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_time_loops_vs2015_Form1:Form
  { 


        public howto_time_loops_vs2015_Form1()
        {
            InitializeComponent();
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            txtForEach.Clear();
            txtFor.Clear();
            txtWhile.Clear();
            txtForEach.Refresh();
            txtFor.Refresh();
            txtWhile.Refresh();

            int num_items = int.Parse(txtArraySize.Text);
            int num_trials = int.Parse(txtNumTrials.Text);
            int[] array = new int[num_items];
            int total = 0;
            Stopwatch watch = new Stopwatch();

            total = 0;
            watch.Start();
            for (int trial = 0; trial < num_trials; trial++)
            {
                foreach (int value in array)
                {
                    total += value;
                }
            }
            watch.Stop();
            txtForEach.Text = watch.Elapsed.TotalSeconds.ToString("0.00");
            txtForEach.Refresh();

            total = 0;
            watch.Reset();
            watch.Start();
            for (int trial = 0; trial < num_trials; trial++)
            {
                for (int i = 0; i < num_items; i++)
                {
                    total += array[i];
                }
            }
            watch.Stop();
            txtFor.Text = watch.Elapsed.TotalSeconds.ToString("0.00");
            txtFor.Refresh();

            total = 0;
            watch.Reset();
            watch.Start();
            for (int trial = 0; trial < num_trials; trial++)
            {
                int i = 0;
                while (i < num_items)
                {
                    total += array[i++];
                }
            }
            watch.Stop();
            txtWhile.Text = watch.Elapsed.TotalSeconds.ToString("0.00");
            txtWhile.Refresh();

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
            this.txtWhile = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtFor = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtForEach = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnGo = new System.Windows.Forms.Button();
            this.txtNumTrials = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtArraySize = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtWhile
            // 
            this.txtWhile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtWhile.Location = new System.Drawing.Point(75, 158);
            this.txtWhile.Name = "txtWhile";
            this.txtWhile.ReadOnly = true;
            this.txtWhile.Size = new System.Drawing.Size(130, 20);
            this.txtWhile.TabIndex = 21;
            this.txtWhile.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 161);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(31, 13);
            this.label6.TabIndex = 20;
            this.label6.Text = "while";
            // 
            // txtFor
            // 
            this.txtFor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFor.Location = new System.Drawing.Point(75, 132);
            this.txtFor.Name = "txtFor";
            this.txtFor.ReadOnly = true;
            this.txtFor.Size = new System.Drawing.Size(130, 20);
            this.txtFor.TabIndex = 19;
            this.txtFor.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 135);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(19, 13);
            this.label4.TabIndex = 18;
            this.label4.Text = "for";
            // 
            // txtForEach
            // 
            this.txtForEach.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtForEach.Location = new System.Drawing.Point(75, 106);
            this.txtForEach.Name = "txtForEach";
            this.txtForEach.ReadOnly = true;
            this.txtForEach.Size = new System.Drawing.Size(130, 20);
            this.txtForEach.TabIndex = 17;
            this.txtForEach.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 109);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 16;
            this.label3.Text = "foreach";
            // 
            // btnGo
            // 
            this.btnGo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGo.Location = new System.Drawing.Point(227, 24);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(75, 23);
            this.btnGo.TabIndex = 15;
            this.btnGo.Text = "Go";
            this.btnGo.UseVisualStyleBackColor = true;
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // txtNumTrials
            // 
            this.txtNumTrials.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNumTrials.Location = new System.Drawing.Point(75, 38);
            this.txtNumTrials.Name = "txtNumTrials";
            this.txtNumTrials.Size = new System.Drawing.Size(130, 20);
            this.txtNumTrials.TabIndex = 14;
            this.txtNumTrials.Text = "10000";
            this.txtNumTrials.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "# Trials:";
            // 
            // txtArraySize
            // 
            this.txtArraySize.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtArraySize.Location = new System.Drawing.Point(75, 12);
            this.txtArraySize.Name = "txtArraySize";
            this.txtArraySize.Size = new System.Drawing.Size(130, 20);
            this.txtArraySize.TabIndex = 12;
            this.txtArraySize.Text = "10000";
            this.txtArraySize.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Array Size:";
            // 
            // howto_time_loops_vs2015_Form1
            // 
            this.AcceptButton = this.btnGo;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(314, 191);
            this.Controls.Add(this.txtWhile);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtFor);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtForEach);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnGo);
            this.Controls.Add(this.txtNumTrials);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtArraySize);
            this.Controls.Add(this.label1);
            this.Name = "howto_time_loops_vs2015_Form1";
            this.Text = "howto_time_loops_vs2015";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtWhile;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtFor;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtForEach;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnGo;
        private System.Windows.Forms.TextBox txtNumTrials;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtArraySize;
        private System.Windows.Forms.Label label1;
    }
}

