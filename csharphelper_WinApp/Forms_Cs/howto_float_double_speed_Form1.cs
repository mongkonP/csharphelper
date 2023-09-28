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
     public partial class howto_float_double_speed_Form1:Form
  { 


        public howto_float_double_speed_Form1()
        {
            InitializeComponent();
        }

        // Compare performances.
        private void btnGo_Click(object sender, EventArgs e)
        {
            txtTimeFloat.Clear();
            txtTimeDouble.Clear();
            txtTimeDecimal.Clear();
            Cursor = Cursors.WaitCursor;
            Refresh();

            int num_trials = int.Parse(txtNumTrials.Text);
            Stopwatch watch = new Stopwatch();
            float float1, float2, float3;
            double double1, double2, double3;
            decimal decimal1, decimal2, decimal3;

            watch.Start();
            for (int i = 0; i < num_trials; i++)
            {
                float1 = 1.23f;
                float2 = 4.56f;
                float3 = float1 / float2;
            }
            watch.Stop();
            txtTimeFloat.Text =
                watch.Elapsed.TotalSeconds.ToString() + " sec";
            txtTimeFloat.Refresh();

            watch.Reset();
            watch.Start();
            for (int i = 0; i < num_trials; i++)
            {
                double1 = 1.23d;
                double2 = 4.56d;
                double3 = double1 / double2;
            }
            watch.Stop();
            txtTimeDouble.Text =
                watch.Elapsed.TotalSeconds.ToString() + " sec";
            txtTimeDouble.Refresh();

            // Scale by a factor of 10 for decimal.
            num_trials /= 10;
            watch.Reset();
            watch.Start();
            for (int i = 0; i < num_trials; i++)
            {
                decimal1 = 1.23m;
                decimal2 = 4.56m;
                decimal3 = decimal1 / decimal2;
            }
            watch.Stop();
            txtTimeDecimal.Text = "~" +
                (watch.Elapsed.TotalSeconds * 10).ToString() + " sec";

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
            this.txtTimeDecimal = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtTimeDouble = new System.Windows.Forms.TextBox();
            this.txtTimeFloat = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnGo = new System.Windows.Forms.Button();
            this.txtNumTrials = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtTimeDecimal
            // 
            this.txtTimeDecimal.Location = new System.Drawing.Point(63, 114);
            this.txtTimeDecimal.Name = "txtTimeDecimal";
            this.txtTimeDecimal.ReadOnly = true;
            this.txtTimeDecimal.Size = new System.Drawing.Size(100, 20);
            this.txtTimeDecimal.TabIndex = 17;
            this.txtTimeDecimal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 117);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 13);
            this.label4.TabIndex = 16;
            this.label4.Text = "decimal:";
            // 
            // txtTimeDouble
            // 
            this.txtTimeDouble.Location = new System.Drawing.Point(63, 88);
            this.txtTimeDouble.Name = "txtTimeDouble";
            this.txtTimeDouble.ReadOnly = true;
            this.txtTimeDouble.Size = new System.Drawing.Size(100, 20);
            this.txtTimeDouble.TabIndex = 15;
            this.txtTimeDouble.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtTimeFloat
            // 
            this.txtTimeFloat.Location = new System.Drawing.Point(63, 62);
            this.txtTimeFloat.Name = "txtTimeFloat";
            this.txtTimeFloat.ReadOnly = true;
            this.txtTimeFloat.Size = new System.Drawing.Size(100, 20);
            this.txtTimeFloat.TabIndex = 14;
            this.txtTimeFloat.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 91);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "double:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "float:";
            // 
            // btnGo
            // 
            this.btnGo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGo.Location = new System.Drawing.Point(227, 11);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(75, 23);
            this.btnGo.TabIndex = 11;
            this.btnGo.Text = "Go";
            this.btnGo.UseVisualStyleBackColor = true;
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // txtNumTrials
            // 
            this.txtNumTrials.Location = new System.Drawing.Point(63, 13);
            this.txtNumTrials.Name = "txtNumTrials";
            this.txtNumTrials.Size = new System.Drawing.Size(100, 20);
            this.txtNumTrials.TabIndex = 10;
            this.txtNumTrials.Text = "100000000";
            this.txtNumTrials.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "# Trials:";
            // 
            // howto_float_double_speed_Form1
            // 
            this.AcceptButton = this.btnGo;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(314, 145);
            this.Controls.Add(this.txtTimeDecimal);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtTimeDouble);
            this.Controls.Add(this.txtTimeFloat);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnGo);
            this.Controls.Add(this.txtNumTrials);
            this.Controls.Add(this.label1);
            this.Name = "howto_float_double_speed_Form1";
            this.Text = "howto_float_double_speed";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtTimeDecimal;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtTimeDouble;
        private System.Windows.Forms.TextBox txtTimeFloat;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnGo;
        private System.Windows.Forms.TextBox txtNumTrials;
        private System.Windows.Forms.Label label1;
    }
}

