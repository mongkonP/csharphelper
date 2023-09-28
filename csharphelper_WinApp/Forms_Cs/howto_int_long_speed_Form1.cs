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
     public partial class howto_int_long_speed_Form1:Form
  { 


        public howto_int_long_speed_Form1()
        {
            InitializeComponent();
        }

        // Compare performances.
        private void btnGo_Click(object sender, EventArgs e)
        {
            txtTimeFloat.Clear();
            txtTimeInt.Clear();
            txtTimeLong.Clear();
            txtTimeByte.Clear();
            Cursor = Cursors.WaitCursor;
            Refresh();

            int num_trials = int.Parse(txtNumTrials.Text);
            Stopwatch watch = new Stopwatch();
            float float1, float2, float3;
            int int1, int2, int3;
            long long1, long2, long3;
            byte byte1, byte2, byte3;

            watch.Start();
            int float_trials = num_trials / 10;
            for (int i = 0; i < num_trials; i++)
            {
                float1 = 1.23f;
                float2 = 4.56f;
                float3 = float1 / float2;
            }
            watch.Stop();
            txtTimeFloat.Text = "~" +
                (10 * watch.Elapsed.TotalSeconds).ToString() + " sec";
            txtTimeFloat.Refresh();

            watch.Reset();
            watch.Start();
            for (int i = 0; i < num_trials; i++)
            {
                int1 = 7331;
                int2 = 1337;
                int3 = int1 / int2;
            }
            watch.Stop();
            txtTimeInt.Text =
                watch.Elapsed.TotalSeconds.ToString() + " sec";
            txtTimeInt.Refresh();

            watch.Reset();
            watch.Start();
            for (int i = 0; i < num_trials; i++)
            {
                long1 = 73317331;
                long2 = 13371337;
                long3 = long1 / long2;
            }
            watch.Stop();
            txtTimeLong.Text =
                watch.Elapsed.TotalSeconds.ToString() + " sec";
            txtTimeLong.Refresh();

            watch.Reset();
            watch.Start();
            for (int i = 0; i < num_trials; i++)
            {
                byte1 = 231;
                byte2 = 123;
                byte3 = (byte)(byte1 / byte2);
            }
            watch.Stop();
            txtTimeByte.Text =
                watch.Elapsed.TotalSeconds.ToString() + " sec";
            txtTimeByte.Refresh();

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
            this.txtTimeByte = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtTimeLong = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtTimeInt = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtTimeFloat = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnGo = new System.Windows.Forms.Button();
            this.txtNumTrials = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtTimeByte
            // 
            this.txtTimeByte.Location = new System.Drawing.Point(63, 141);
            this.txtTimeByte.Name = "txtTimeByte";
            this.txtTimeByte.ReadOnly = true;
            this.txtTimeByte.Size = new System.Drawing.Size(100, 20);
            this.txtTimeByte.TabIndex = 28;
            this.txtTimeByte.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 144);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(30, 13);
            this.label7.TabIndex = 33;
            this.label7.Text = "byte:";
            // 
            // txtTimeLong
            // 
            this.txtTimeLong.Location = new System.Drawing.Point(63, 115);
            this.txtTimeLong.Name = "txtTimeLong";
            this.txtTimeLong.ReadOnly = true;
            this.txtTimeLong.Size = new System.Drawing.Size(100, 20);
            this.txtTimeLong.TabIndex = 27;
            this.txtTimeLong.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 118);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(30, 13);
            this.label5.TabIndex = 32;
            this.label5.Text = "long:";
            // 
            // txtTimeInt
            // 
            this.txtTimeInt.Location = new System.Drawing.Point(63, 89);
            this.txtTimeInt.Name = "txtTimeInt";
            this.txtTimeInt.ReadOnly = true;
            this.txtTimeInt.Size = new System.Drawing.Size(100, 20);
            this.txtTimeInt.TabIndex = 26;
            this.txtTimeInt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 92);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(21, 13);
            this.label6.TabIndex = 31;
            this.label6.Text = "int:";
            // 
            // txtTimeFloat
            // 
            this.txtTimeFloat.Location = new System.Drawing.Point(63, 63);
            this.txtTimeFloat.Name = "txtTimeFloat";
            this.txtTimeFloat.ReadOnly = true;
            this.txtTimeFloat.Size = new System.Drawing.Size(100, 20);
            this.txtTimeFloat.TabIndex = 25;
            this.txtTimeFloat.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 13);
            this.label2.TabIndex = 30;
            this.label2.Text = "float:";
            // 
            // btnGo
            // 
            this.btnGo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGo.Location = new System.Drawing.Point(207, 12);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(75, 23);
            this.btnGo.TabIndex = 24;
            this.btnGo.Text = "Go";
            this.btnGo.UseVisualStyleBackColor = true;
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // txtNumTrials
            // 
            this.txtNumTrials.Location = new System.Drawing.Point(63, 14);
            this.txtNumTrials.Name = "txtNumTrials";
            this.txtNumTrials.Size = new System.Drawing.Size(100, 20);
            this.txtNumTrials.TabIndex = 23;
            this.txtNumTrials.Text = "100000000";
            this.txtNumTrials.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 29;
            this.label1.Text = "# Trials:";
            // 
            // howto_int_long_speed_Form1
            // 
            this.AcceptButton = this.btnGo;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(294, 171);
            this.Controls.Add(this.txtTimeByte);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtTimeLong);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtTimeInt);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtTimeFloat);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnGo);
            this.Controls.Add(this.txtNumTrials);
            this.Controls.Add(this.label1);
            this.Name = "howto_int_long_speed_Form1";
            this.Text = "howto_int_long_speed";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtTimeByte;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtTimeLong;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtTimeInt;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtTimeFloat;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnGo;
        private System.Windows.Forms.TextBox txtNumTrials;
        private System.Windows.Forms.Label label1;
    }
}

