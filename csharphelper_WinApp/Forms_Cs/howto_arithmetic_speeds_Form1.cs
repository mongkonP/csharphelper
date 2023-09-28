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
     public partial class howto_arithmetic_speeds_Form1:Form
  { 


        public howto_arithmetic_speeds_Form1()
        {
            InitializeComponent();
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            txtByte.Clear();
            txtInt.Clear();
            txtLong.Clear();
            txtDecimal.Clear();
            txtFloat.Clear();
            txtDouble.Clear();

            txtByteSecs.Clear();
            txtIntSecs.Clear();
            txtLongSecs.Clear();
            txtDecimalSecs.Clear();
            txtFloatSecs.Clear();
            txtDoubleSecs.Clear();
            Cursor = Cursors.WaitCursor;
            Refresh();

            double sec_per_test = double.Parse(txtSecPerTest.Text);
            DateTime start_time, stop_time, time_now;
            TimeSpan elapsed;
            double trials_per_sec, ns_per_trial;

            // Byte.
            start_time = DateTime.Now;
            stop_time = start_time.AddSeconds(sec_per_test);
            for (int trial = 0; ; trial++)
            {
                byte i = 12 * 31 / 13;
                byte j = (byte)(i * 7);
                i = (byte)(j / 17);

                time_now = DateTime.Now;
                if (time_now > stop_time)
                {
                    elapsed = time_now - start_time;
                    trials_per_sec = trial / elapsed.TotalSeconds;
                    txtByte.Text = trials_per_sec.ToString("N");
                    txtByte.Refresh();
                    ns_per_trial = 1.0 / trials_per_sec * 1000000000;
                    txtByteSecs.Text = ns_per_trial.ToString("0.00");
                    txtByteSecs.Refresh();
                    break;
                }
            }

            // Int.
            start_time = DateTime.Now;
            stop_time = start_time.AddSeconds(sec_per_test);
            for (int trial = 0; ; trial++)
            {
                int i = 12345 * 54231 / 13;
                int j = i * 267;
                i = j / 287;

                time_now = DateTime.Now;
                if (time_now > stop_time)
                {
                    elapsed = time_now - start_time;
                    trials_per_sec = trial / elapsed.TotalSeconds;
                    txtInt.Text = trials_per_sec.ToString("N");
                    txtInt.Refresh();

                    ns_per_trial = 1.0 / trials_per_sec * 1000000000;
                    txtIntSecs.Text = ns_per_trial.ToString("0.00");
                    txtIntSecs.Refresh();
                    break;
                }
            }

            // Long.
            start_time = DateTime.Now;
            stop_time = start_time.AddSeconds(sec_per_test);
            for (int trial = 0; ; trial++)
            {
                long i = 12345L * 54231L / 13L;
                long j = i * 267L;
                i = j / 287L;

                time_now = DateTime.Now;
                if (time_now > stop_time)
                {
                    elapsed = time_now - start_time;
                    trials_per_sec = trial / elapsed.TotalSeconds;
                    txtLong.Text = trials_per_sec.ToString("N");
                    txtLong.Refresh();

                    ns_per_trial = 1.0 / trials_per_sec * 1000000000;
                    txtLongSecs.Text = ns_per_trial.ToString("0.00");
                    txtLongSecs.Refresh();
                    break;
                }
            }

            // Decimal.
            start_time = DateTime.Now;
            stop_time = start_time.AddSeconds(sec_per_test);
            for (int trial = 0; ; trial++)
            {
                decimal i = 12345m * 54231m / 13m;
                decimal j = i * 267m;
                i = j / 287m;

                time_now = DateTime.Now;
                if (time_now > stop_time)
                {
                    elapsed = time_now - start_time;
                    trials_per_sec = trial / elapsed.TotalSeconds;
                    txtDecimal.Text = trials_per_sec.ToString("N");
                    txtDecimal.Refresh();

                    ns_per_trial = 1.0 / trials_per_sec * 1000000000;
                    txtDecimalSecs.Text = ns_per_trial.ToString("0.00");
                    txtDecimalSecs.Refresh();
                    break;
                }
            }

            // Float.
            start_time = DateTime.Now;
            stop_time = start_time.AddSeconds(sec_per_test);
            for (int trial = 0; ; trial++)
            {
                float i = 12345f * 54231f / 13f;
                float j = i * 267f;
                i = j / 287f;

                time_now = DateTime.Now;
                if (time_now > stop_time)
                {
                    elapsed = time_now - start_time;
                    trials_per_sec = trial / elapsed.TotalSeconds;
                    txtFloat.Text = trials_per_sec.ToString("N");
                    txtFloat.Refresh();

                    ns_per_trial = 1.0 / trials_per_sec * 1000000000;
                    txtFloatSecs.Text = ns_per_trial.ToString("0.00");
                    txtFloatSecs.Refresh();
                    break;
                }
            }

            // Double.
            start_time = DateTime.Now;
            stop_time = start_time.AddSeconds(sec_per_test);
            for (int trial = 0; ; trial++)
            {
                double i = 12345d * 54231d / 13d;
                double j = i * 267d;
                i = j / 287d;

                time_now = DateTime.Now;
                if (time_now > stop_time)
                {
                    elapsed = time_now - start_time;
                    trials_per_sec = trial / elapsed.TotalSeconds;
                    txtDouble.Text = trials_per_sec.ToString("N");
                    txtDouble.Refresh();

                    ns_per_trial = 1.0 / trials_per_sec * 1000000000;
                    txtDoubleSecs.Text = ns_per_trial.ToString("0.00");
                    txtDoubleSecs.Refresh();
                    break;
                }
            }

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
            this.label1 = new System.Windows.Forms.Label();
            this.txtSecPerTest = new System.Windows.Forms.TextBox();
            this.btnGo = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtInt = new System.Windows.Forms.TextBox();
            this.txtFloat = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDouble = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDecimal = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtLong = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtByte = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtByteSecs = new System.Windows.Forms.TextBox();
            this.txtLongSecs = new System.Windows.Forms.TextBox();
            this.txtDecimalSecs = new System.Windows.Forms.TextBox();
            this.txtDoubleSecs = new System.Windows.Forms.TextBox();
            this.txtFloatSecs = new System.Windows.Forms.TextBox();
            this.txtIntSecs = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Sec/Test:";
            // 
            // txtSecPerTest
            // 
            this.txtSecPerTest.Location = new System.Drawing.Point(73, 14);
            this.txtSecPerTest.Name = "txtSecPerTest";
            this.txtSecPerTest.Size = new System.Drawing.Size(100, 20);
            this.txtSecPerTest.TabIndex = 0;
            this.txtSecPerTest.Text = "1.0";
            this.txtSecPerTest.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnGo
            // 
            this.btnGo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGo.Location = new System.Drawing.Point(224, 12);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(75, 23);
            this.btnGo.TabIndex = 1;
            this.btnGo.Text = "Go";
            this.btnGo.UseVisualStyleBackColor = true;
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 125);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Integer:";
            // 
            // txtInt
            // 
            this.txtInt.Location = new System.Drawing.Point(73, 122);
            this.txtInt.Name = "txtInt";
            this.txtInt.ReadOnly = true;
            this.txtInt.Size = new System.Drawing.Size(100, 20);
            this.txtInt.TabIndex = 4;
            this.txtInt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtFloat
            // 
            this.txtFloat.Location = new System.Drawing.Point(73, 200);
            this.txtFloat.Name = "txtFloat";
            this.txtFloat.ReadOnly = true;
            this.txtFloat.Size = new System.Drawing.Size(100, 20);
            this.txtFloat.TabIndex = 10;
            this.txtFloat.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 203);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Float:";
            // 
            // txtDouble
            // 
            this.txtDouble.Location = new System.Drawing.Point(73, 226);
            this.txtDouble.Name = "txtDouble";
            this.txtDouble.ReadOnly = true;
            this.txtDouble.Size = new System.Drawing.Size(100, 20);
            this.txtDouble.TabIndex = 12;
            this.txtDouble.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 229);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Double:";
            // 
            // txtDecimal
            // 
            this.txtDecimal.Location = new System.Drawing.Point(73, 174);
            this.txtDecimal.Name = "txtDecimal";
            this.txtDecimal.ReadOnly = true;
            this.txtDecimal.Size = new System.Drawing.Size(100, 20);
            this.txtDecimal.TabIndex = 8;
            this.txtDecimal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 177);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Decimal:";
            // 
            // txtLong
            // 
            this.txtLong.Location = new System.Drawing.Point(73, 148);
            this.txtLong.Name = "txtLong";
            this.txtLong.ReadOnly = true;
            this.txtLong.Size = new System.Drawing.Size(100, 20);
            this.txtLong.TabIndex = 7;
            this.txtLong.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 151);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(34, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Long:";
            // 
            // txtByte
            // 
            this.txtByte.Location = new System.Drawing.Point(73, 96);
            this.txtByte.Name = "txtByte";
            this.txtByte.ReadOnly = true;
            this.txtByte.Size = new System.Drawing.Size(100, 20);
            this.txtByte.TabIndex = 2;
            this.txtByte.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 99);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(31, 13);
            this.label7.TabIndex = 13;
            this.label7.Text = "Byte:";
            // 
            // txtByteSecs
            // 
            this.txtByteSecs.Location = new System.Drawing.Point(179, 96);
            this.txtByteSecs.Name = "txtByteSecs";
            this.txtByteSecs.ReadOnly = true;
            this.txtByteSecs.Size = new System.Drawing.Size(100, 20);
            this.txtByteSecs.TabIndex = 3;
            this.txtByteSecs.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtLongSecs
            // 
            this.txtLongSecs.Location = new System.Drawing.Point(179, 148);
            this.txtLongSecs.Name = "txtLongSecs";
            this.txtLongSecs.ReadOnly = true;
            this.txtLongSecs.Size = new System.Drawing.Size(100, 20);
            this.txtLongSecs.TabIndex = 16;
            this.txtLongSecs.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtDecimalSecs
            // 
            this.txtDecimalSecs.Location = new System.Drawing.Point(179, 174);
            this.txtDecimalSecs.Name = "txtDecimalSecs";
            this.txtDecimalSecs.ReadOnly = true;
            this.txtDecimalSecs.Size = new System.Drawing.Size(100, 20);
            this.txtDecimalSecs.TabIndex = 9;
            this.txtDecimalSecs.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtDoubleSecs
            // 
            this.txtDoubleSecs.Location = new System.Drawing.Point(179, 226);
            this.txtDoubleSecs.Name = "txtDoubleSecs";
            this.txtDoubleSecs.ReadOnly = true;
            this.txtDoubleSecs.Size = new System.Drawing.Size(100, 20);
            this.txtDoubleSecs.TabIndex = 13;
            this.txtDoubleSecs.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtFloatSecs
            // 
            this.txtFloatSecs.Location = new System.Drawing.Point(179, 200);
            this.txtFloatSecs.Name = "txtFloatSecs";
            this.txtFloatSecs.ReadOnly = true;
            this.txtFloatSecs.Size = new System.Drawing.Size(100, 20);
            this.txtFloatSecs.TabIndex = 11;
            this.txtFloatSecs.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtIntSecs
            // 
            this.txtIntSecs.Location = new System.Drawing.Point(179, 122);
            this.txtIntSecs.Name = "txtIntSecs";
            this.txtIntSecs.ReadOnly = true;
            this.txtIntSecs.Size = new System.Drawing.Size(100, 20);
            this.txtIntSecs.TabIndex = 5;
            this.txtIntSecs.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(70, 68);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(103, 25);
            this.label8.TabIndex = 20;
            this.label8.Text = "Ops/Second";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(176, 68);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(103, 25);
            this.label9.TabIndex = 21;
            this.label9.Text = "Ns/Op";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // howto_arithmetic_speeds_Form1
            // 
            this.AcceptButton = this.btnGo;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(311, 258);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtByteSecs);
            this.Controls.Add(this.txtLongSecs);
            this.Controls.Add(this.txtDecimalSecs);
            this.Controls.Add(this.txtDoubleSecs);
            this.Controls.Add(this.txtFloatSecs);
            this.Controls.Add(this.txtIntSecs);
            this.Controls.Add(this.txtByte);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtLong);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtDecimal);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtDouble);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtFloat);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtInt);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnGo);
            this.Controls.Add(this.txtSecPerTest);
            this.Controls.Add(this.label1);
            this.Name = "howto_arithmetic_speeds_Form1";
            this.Text = "howto_arithmetic_speeds";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSecPerTest;
        private System.Windows.Forms.Button btnGo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtInt;
        private System.Windows.Forms.TextBox txtFloat;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtDouble;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtDecimal;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtLong;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtByte;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtByteSecs;
        private System.Windows.Forms.TextBox txtLongSecs;
        private System.Windows.Forms.TextBox txtDecimalSecs;
        private System.Windows.Forms.TextBox txtDoubleSecs;
        private System.Windows.Forms.TextBox txtFloatSecs;
        private System.Windows.Forms.TextBox txtIntSecs;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
    }
}

