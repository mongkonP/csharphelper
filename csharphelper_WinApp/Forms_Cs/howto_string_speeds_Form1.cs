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
     public partial class howto_string_speeds_Form1:Form
  { 


        public howto_string_speeds_Form1()
        {
            InitializeComponent();
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            txtStringBuilder.Clear();
            txtConcat.Clear();
            txtPlus.Clear();
            this.Cursor = Cursors.WaitCursor;

            Stopwatch watch = new Stopwatch();
            long num_appends = long.Parse(txtNumAppends.Text);
            long num_trials = long.Parse(txtNumTrials.Text);
            string result;

            // StringBuilder.
            watch.Start();
            for (long trial = 1; trial <= num_trials; trial++)
            {
                StringBuilder sb = new StringBuilder();
                for (long i = 1; i <= num_appends; i++)
                    sb.Append("0123456789");
                result = sb.ToString();
            }
            watch.Stop();
            txtStringBuilder.Text = string.Format("{0:0.00} μ sec",
                watch.Elapsed.TotalSeconds * 1000000 / num_trials);

            // String.Append.
            watch.Reset();
            watch.Start();
            for (long trial = 1; trial <= num_trials; trial++)
            {
                result = "";
                for (long i = 1; i <= num_appends; i++)
                    result = string.Concat(result, "0123456789");
            }
            watch.Stop();
            txtConcat.Text = string.Format("{0:0.00} μ sec",
                watch.Elapsed.TotalSeconds * 1000000 / num_trials);

            // +=.
            watch.Reset();
            watch.Start();
            for (long trial = 1; trial <= num_trials; trial++)
            {
                result = "";
                for (long i = 1; i <= num_appends; i++)
                    result += "0123456789";
            }
            watch.Stop();
            txtPlus.Text = string.Format("{0:0.00} μ sec",
                watch.Elapsed.TotalSeconds * 1000000 / num_trials);

            this.Cursor = Cursors.Default;
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
            this.txtNumAppends = new System.Windows.Forms.TextBox();
            this.btnGo = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtStringBuilder = new System.Windows.Forms.TextBox();
            this.txtConcat = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPlus = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtNumTrials = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "# Appends";
            // 
            // txtNumAppends
            // 
            this.txtNumAppends.Location = new System.Drawing.Point(77, 40);
            this.txtNumAppends.Name = "txtNumAppends";
            this.txtNumAppends.Size = new System.Drawing.Size(74, 20);
            this.txtNumAppends.TabIndex = 1;
            this.txtNumAppends.Text = "10";
            this.txtNumAppends.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnGo
            // 
            this.btnGo.Location = new System.Drawing.Point(177, 12);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(75, 23);
            this.btnGo.TabIndex = 2;
            this.btnGo.Text = "Go";
            this.btnGo.UseVisualStyleBackColor = true;
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 103);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "StringBuilder";
            // 
            // txtStringBuilder
            // 
            this.txtStringBuilder.Location = new System.Drawing.Point(89, 100);
            this.txtStringBuilder.Name = "txtStringBuilder";
            this.txtStringBuilder.ReadOnly = true;
            this.txtStringBuilder.Size = new System.Drawing.Size(100, 20);
            this.txtStringBuilder.TabIndex = 3;
            this.txtStringBuilder.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtConcat
            // 
            this.txtConcat.Location = new System.Drawing.Point(89, 126);
            this.txtConcat.Name = "txtConcat";
            this.txtConcat.ReadOnly = true;
            this.txtConcat.Size = new System.Drawing.Size(100, 20);
            this.txtConcat.TabIndex = 4;
            this.txtConcat.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 129);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "String.Concat";
            // 
            // txtPlus
            // 
            this.txtPlus.Location = new System.Drawing.Point(89, 152);
            this.txtPlus.Name = "txtPlus";
            this.txtPlus.ReadOnly = true;
            this.txtPlus.Size = new System.Drawing.Size(100, 20);
            this.txtPlus.TabIndex = 5;
            this.txtPlus.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 155);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(19, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "+=";
            // 
            // txtNumTrials
            // 
            this.txtNumTrials.Location = new System.Drawing.Point(77, 14);
            this.txtNumTrials.Name = "txtNumTrials";
            this.txtNumTrials.Size = new System.Drawing.Size(74, 20);
            this.txtNumTrials.TabIndex = 0;
            this.txtNumTrials.Text = "1000000";
            this.txtNumTrials.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 17);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(42, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "# Trials";
            // 
            // howto_string_speeds_Form1
            // 
            this.AcceptButton = this.btnGo;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 184);
            this.Controls.Add(this.txtNumTrials);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtPlus);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtConcat);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtStringBuilder);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnGo);
            this.Controls.Add(this.txtNumAppends);
            this.Controls.Add(this.label1);
            this.Name = "howto_string_speeds_Form1";
            this.Text = "howto_string_speeds";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNumAppends;
        private System.Windows.Forms.Button btnGo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtStringBuilder;
        private System.Windows.Forms.TextBox txtConcat;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtPlus;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtNumTrials;
        private System.Windows.Forms.Label label5;
    }
}

