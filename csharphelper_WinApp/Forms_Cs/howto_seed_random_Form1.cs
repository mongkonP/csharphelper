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
     public partial class howto_seed_random_Form1:Form
  { 


        public howto_seed_random_Form1()
        {
            InitializeComponent();
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            GenerateNumbers(txtSeed1, lstNumbers1);
        }
        private void btnGenerate2_Click(object sender, EventArgs e)
        {
            GenerateNumbers(txtSeed2, lstNumbers2);
        }

        // Initialize the random number generator and generate some numbers.
        private void GenerateNumbers(TextBox seed_textbox, ListBox lst)
        {
            // Get the seed.
            int seed = int.Parse(seed_textbox.Text);

            // Initialize the random number generator.
            Random Rand = new Random(seed);

            // Generate numbers.
            lst.Items.Clear();
            for (int i = 1; i < 100; i++)
            {
                lst.Items.Add(Rand.Next(0, 10000));
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
            this.label2 = new System.Windows.Forms.Label();
            this.lstNumbers2 = new System.Windows.Forms.ListBox();
            this.txtSeed2 = new System.Windows.Forms.TextBox();
            this.btnGenerate2 = new System.Windows.Forms.Button();
            this.lstNumbers1 = new System.Windows.Forms.ListBox();
            this.txtSeed1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(150, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 30);
            this.label2.TabIndex = 18;
            this.label2.Text = "Seed:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lstNumbers2
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.lstNumbers2, 2);
            this.lstNumbers2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstNumbers2.FormattingEnabled = true;
            this.lstNumbers2.IntegralHeight = false;
            this.lstNumbers2.Location = new System.Drawing.Point(150, 63);
            this.lstNumbers2.Name = "lstNumbers2";
            this.lstNumbers2.Size = new System.Drawing.Size(142, 171);
            this.lstNumbers2.TabIndex = 17;
            // 
            // txtSeed2
            // 
            this.txtSeed2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSeed2.Location = new System.Drawing.Point(200, 5);
            this.txtSeed2.Name = "txtSeed2";
            this.txtSeed2.Size = new System.Drawing.Size(92, 20);
            this.txtSeed2.TabIndex = 15;
            this.txtSeed2.Text = "219879";
            this.txtSeed2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnGenerate2
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.btnGenerate2, 2);
            this.btnGenerate2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnGenerate2.Location = new System.Drawing.Point(150, 33);
            this.btnGenerate2.Name = "btnGenerate2";
            this.btnGenerate2.Size = new System.Drawing.Size(142, 24);
            this.btnGenerate2.TabIndex = 16;
            this.btnGenerate2.Text = "Generate";
            this.btnGenerate2.UseVisualStyleBackColor = true;
            this.btnGenerate2.Click += new System.EventHandler(this.btnGenerate2_Click);
            // 
            // lstNumbers1
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.lstNumbers1, 2);
            this.lstNumbers1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstNumbers1.FormattingEnabled = true;
            this.lstNumbers1.IntegralHeight = false;
            this.lstNumbers1.Location = new System.Drawing.Point(3, 63);
            this.lstNumbers1.Name = "lstNumbers1";
            this.lstNumbers1.Size = new System.Drawing.Size(141, 171);
            this.lstNumbers1.TabIndex = 14;
            // 
            // txtSeed1
            // 
            this.txtSeed1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSeed1.Location = new System.Drawing.Point(53, 5);
            this.txtSeed1.Name = "txtSeed1";
            this.txtSeed1.Size = new System.Drawing.Size(91, 20);
            this.txtSeed1.TabIndex = 11;
            this.txtSeed1.Text = "219879";
            this.txtSeed1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 30);
            this.label1.TabIndex = 13;
            this.label1.Text = "Seed:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnGenerate
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.btnGenerate, 2);
            this.btnGenerate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnGenerate.Location = new System.Drawing.Point(3, 33);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(141, 24);
            this.btnGenerate.TabIndex = 12;
            this.btnGenerate.Text = "Generate";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtSeed2, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtSeed1, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.lstNumbers1, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.btnGenerate, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnGenerate2, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.lstNumbers2, 2, 2);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(8, 12);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(295, 237);
            this.tableLayoutPanel1.TabIndex = 19;
            // 
            // howto_seed_random_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(315, 261);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "howto_seed_random_Form1";
            this.Text = "howto_seed_random";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox lstNumbers2;
        private System.Windows.Forms.TextBox txtSeed2;
        private System.Windows.Forms.Button btnGenerate2;
        private System.Windows.Forms.ListBox lstNumbers1;
        private System.Windows.Forms.TextBox txtSeed1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}

