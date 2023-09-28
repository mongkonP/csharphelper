using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Diagnostics;

 

namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_check_string_blank_Form1:Form
  { 


        public howto_check_string_blank_Form1()
        {
            InitializeComponent();
        }

        private void howto_check_string_blank_Form1_Load(object sender, EventArgs e)
        {
            // Uncomment the following if running .NET Framework 4.5 or later.
            label6.Enabled = true;
            txtIsNullOrWhiteSpace.Enabled = true;
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            txtEmpty.Clear();
            txtCompareTo.Clear();
            txtQuote.Clear();
            txtLength.Clear();
            txtIsNullOrEmpty.Clear();
            txtIsNullOrWhiteSpace.Clear();

            Cursor = Cursors.WaitCursor;
            int num_trials = int.Parse(txtNumTrials.Text);
            Stopwatch watch = new Stopwatch();
            string string1 = "", string2 = "ABCD", string3;
            Refresh();

            watch.Start();
            for (int i = 0; i < num_trials; i++)
            {
                if (string1 == string.Empty) string3 = string1;
                if (string2 == string.Empty) string3 = string2;
            }
            watch.Stop();
            txtEmpty.Text = watch.Elapsed.TotalSeconds.ToString("0.00") + " sec";
            Refresh();

            watch.Restart();
            for (int i = 0; i < num_trials; i++)
            {
                if (string1.CompareTo(string.Empty) == 0) string3 = string1;
                if (string2.CompareTo(string.Empty) == 0) string3 = string2;
            }
            watch.Stop();
            txtCompareTo.Text = watch.Elapsed.TotalSeconds.ToString("0.00") + " sec";
            Refresh();

            watch.Restart();
            for (int i = 0; i < num_trials; i++)
            {
                if (string1 == "") string3 = string1;
                if (string2 == "") string3 = string2;
            }
            watch.Stop();
            txtQuote.Text = watch.Elapsed.TotalSeconds.ToString("0.00") + " sec";
            Refresh();

            watch.Restart();
            for (int i = 0; i < num_trials; i++)
            {
                if (string1.Length == 0) string3 = string1;
                if (string2.Length == 0) string3 = string2;
            }
            watch.Stop();
            txtLength.Text = watch.Elapsed.TotalSeconds.ToString("0.00") + " sec";
            Refresh();

            watch.Restart();
            for (int i = 0; i < num_trials; i++)
            {
                if (string.IsNullOrEmpty(string1)) string3 = string1;
                if (string.IsNullOrEmpty(string2)) string3 = string2;
            }
            watch.Stop();
            txtIsNullOrEmpty.Text = watch.Elapsed.TotalSeconds.ToString("0.00") + " sec";
            Refresh();

            // Uncomment the following if running .NET Framework 4.5 or later.
            watch.Start();
            for (int i = 0; i < num_trials; i++)
            {
                if (string.IsNullOrWhiteSpace(string1)) string3 = string1;
                if (string.IsNullOrWhiteSpace(string2)) string3 = string2;
            }
            watch.Stop();
            txtIsNullOrWhiteSpace.Text = watch.Elapsed.TotalSeconds.ToString("0.00") + " sec";
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
            this.txtIsNullOrWhiteSpace = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtIsNullOrEmpty = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtCompareTo = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtLength = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtEmpty = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtQuote = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnGo = new System.Windows.Forms.Button();
            this.txtNumTrials = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtIsNullOrWhiteSpace
            // 
            this.txtIsNullOrWhiteSpace.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtIsNullOrWhiteSpace.Enabled = false;
            this.txtIsNullOrWhiteSpace.Location = new System.Drawing.Point(149, 185);
            this.txtIsNullOrWhiteSpace.Name = "txtIsNullOrWhiteSpace";
            this.txtIsNullOrWhiteSpace.ReadOnly = true;
            this.txtIsNullOrWhiteSpace.Size = new System.Drawing.Size(153, 20);
            this.txtIsNullOrWhiteSpace.TabIndex = 27;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Enabled = false;
            this.label6.Location = new System.Drawing.Point(12, 188);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(131, 13);
            this.label6.TabIndex = 28;
            this.label6.Text = "string.IsNullOrWhiteSpace";
            // 
            // txtIsNullOrEmpty
            // 
            this.txtIsNullOrEmpty.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtIsNullOrEmpty.Location = new System.Drawing.Point(149, 159);
            this.txtIsNullOrEmpty.Name = "txtIsNullOrEmpty";
            this.txtIsNullOrEmpty.ReadOnly = true;
            this.txtIsNullOrEmpty.Size = new System.Drawing.Size(153, 20);
            this.txtIsNullOrEmpty.TabIndex = 26;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 162);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(101, 13);
            this.label7.TabIndex = 25;
            this.label7.Text = "string.IsNullOrEmpty";
            // 
            // txtCompareTo
            // 
            this.txtCompareTo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCompareTo.Location = new System.Drawing.Point(149, 81);
            this.txtCompareTo.Name = "txtCompareTo";
            this.txtCompareTo.ReadOnly = true;
            this.txtCompareTo.Size = new System.Drawing.Size(153, 20);
            this.txtCompareTo.TabIndex = 18;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 84);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(128, 13);
            this.label5.TabIndex = 24;
            this.label5.Text = ".CompareTo(string.Empty)";
            // 
            // txtLength
            // 
            this.txtLength.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLength.Location = new System.Drawing.Point(149, 133);
            this.txtLength.Name = "txtLength";
            this.txtLength.ReadOnly = true;
            this.txtLength.Size = new System.Drawing.Size(153, 20);
            this.txtLength.TabIndex = 21;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 136);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 13);
            this.label4.TabIndex = 23;
            this.label4.Text = "Length == 0";
            // 
            // txtEmpty
            // 
            this.txtEmpty.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtEmpty.Location = new System.Drawing.Point(149, 55);
            this.txtEmpty.Name = "txtEmpty";
            this.txtEmpty.ReadOnly = true;
            this.txtEmpty.Size = new System.Drawing.Size(153, 20);
            this.txtEmpty.TabIndex = 17;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 58);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 13);
            this.label3.TabIndex = 22;
            this.label3.Text = "== string.Empty";
            // 
            // txtQuote
            // 
            this.txtQuote.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtQuote.Location = new System.Drawing.Point(149, 107);
            this.txtQuote.Name = "txtQuote";
            this.txtQuote.ReadOnly = true;
            this.txtQuote.Size = new System.Drawing.Size(153, 20);
            this.txtQuote.TabIndex = 20;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 110);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 19;
            this.label2.Text = "== \"\"";
            // 
            // btnGo
            // 
            this.btnGo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGo.Location = new System.Drawing.Point(227, 11);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(75, 23);
            this.btnGo.TabIndex = 16;
            this.btnGo.Text = "Go";
            this.btnGo.UseVisualStyleBackColor = true;
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // txtNumTrials
            // 
            this.txtNumTrials.Location = new System.Drawing.Point(63, 14);
            this.txtNumTrials.Name = "txtNumTrials";
            this.txtNumTrials.Size = new System.Drawing.Size(77, 20);
            this.txtNumTrials.TabIndex = 14;
            this.txtNumTrials.Text = "100000000";
            this.txtNumTrials.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 15;
            this.label1.Text = "# Trials:";
            // 
            // howto_check_string_blank_Form1
            // 
            this.AcceptButton = this.btnGo;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(314, 217);
            this.Controls.Add(this.txtIsNullOrWhiteSpace);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtIsNullOrEmpty);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtCompareTo);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtLength);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtEmpty);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtQuote);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnGo);
            this.Controls.Add(this.txtNumTrials);
            this.Controls.Add(this.label1);
            this.Name = "howto_check_string_blank_Form1";
            this.Text = "howto_check_string_blank";
            this.Load += new System.EventHandler(this.howto_check_string_blank_Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtIsNullOrWhiteSpace;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtIsNullOrEmpty;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtCompareTo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtLength;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtEmpty;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtQuote;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnGo;
        private System.Windows.Forms.TextBox txtNumTrials;
        private System.Windows.Forms.Label label1;
    }
}

