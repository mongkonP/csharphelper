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
     public partial class howto_time_date_loops_Form1:Form
  { 


        public howto_time_date_loops_Form1()
        {
            InitializeComponent();
        }

        // Compare two methods for looping over the dates.
        private void btnGo_Click(object sender, EventArgs e)
        {
            txtDateTimeLoop.Clear();
            txtIntLoop.Clear();

            // Test variables.
            DateTime loop_start_time;
            TimeSpan elapsed;
            bool test_bool;

            // Get the start and end date components.
            DateTime start_date = dtpStart.Value.Date;
            DateTime end_date = dtpEnd.Value.Date;
            int start_year = start_date.Year;
            int end_year = end_date.Year;

            // *** Loop by using int variables. ***
            // Loop over the selected years.
            loop_start_time = DateTime.Now;
            for (int year = start_year; year <= end_year; year++)
            {
                // Loop over the months in the year.
                for (int month = 1; month <= 12; month++)
                {
                    // See if this month's 13th is a Friday.
                    DateTime test_date = new DateTime(year, month, 13);

                    // If we haven't reached the start date, skip this one.
                    if (test_date < start_date) continue;

                    // If we've passed the end date, stop looping.
                    if (test_date > end_date) break;

                    // See if this is a Friday.
                    test_bool = (test_date.DayOfWeek == DayOfWeek.Friday);
                }
            }
            elapsed = DateTime.Now - loop_start_time;
            txtIntLoop.Text = elapsed.TotalSeconds.ToString("0.0000") + " secs";

            // *** Loop by using a DateTime variable. ***
            // Find the first 13th date >= start_date.
            DateTime loop_start = new DateTime(start_year, start_date.Month, 13);
            if (loop_start < start_date) loop_start.AddMonths(1);

            // Find the last 13th date <= end_date.
            DateTime loop_end = new DateTime(end_year, end_date.Month, 13);
            if (loop_end > end_date) loop_end.AddMonths(-1);

            // Time the first loop.
            loop_start_time = DateTime.Now;
            for (DateTime loop_date = loop_start;
                loop_date < loop_end;
                loop_date = loop_date.AddMonths(1))
            {
                test_bool = (loop_date.DayOfWeek == DayOfWeek.Friday);
            }
            elapsed = DateTime.Now - loop_start_time;
            txtDateTimeLoop.Text = elapsed.TotalSeconds.ToString("0.0000") + " secs";
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
            this.txtIntLoop = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDateTimeLoop = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnGo = new System.Windows.Forms.Button();
            this.dtpEnd = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpStart = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtIntLoop
            // 
            this.txtIntLoop.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtIntLoop.Location = new System.Drawing.Point(157, 93);
            this.txtIntLoop.Name = "txtIntLoop";
            this.txtIntLoop.ReadOnly = true;
            this.txtIntLoop.Size = new System.Drawing.Size(100, 20);
            this.txtIntLoop.TabIndex = 17;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(68, 96);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 13);
            this.label4.TabIndex = 22;
            this.label4.Text = "Int Loop:";
            // 
            // txtDateTimeLoop
            // 
            this.txtDateTimeLoop.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtDateTimeLoop.Location = new System.Drawing.Point(157, 119);
            this.txtDateTimeLoop.Name = "txtDateTimeLoop";
            this.txtDateTimeLoop.ReadOnly = true;
            this.txtDateTimeLoop.Size = new System.Drawing.Size(100, 20);
            this.txtDateTimeLoop.TabIndex = 18;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(68, 122);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 13);
            this.label3.TabIndex = 21;
            this.label3.Text = "DateTime Loop:";
            // 
            // btnGo
            // 
            this.btnGo.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnGo.Location = new System.Drawing.Point(125, 64);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(75, 23);
            this.btnGo.TabIndex = 16;
            this.btnGo.Text = "Go";
            this.btnGo.UseVisualStyleBackColor = true;
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // dtpEnd
            // 
            this.dtpEnd.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpEnd.Location = new System.Drawing.Point(56, 38);
            this.dtpEnd.Name = "dtpEnd";
            this.dtpEnd.Size = new System.Drawing.Size(256, 20);
            this.dtpEnd.TabIndex = 15;
            this.dtpEnd.Value = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(23, 13);
            this.label2.TabIndex = 20;
            this.label2.Text = "To:";
            // 
            // dtpStart
            // 
            this.dtpStart.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpStart.Location = new System.Drawing.Point(56, 12);
            this.dtpStart.Name = "dtpStart";
            this.dtpStart.Size = new System.Drawing.Size(256, 20);
            this.dtpStart.TabIndex = 14;
            this.dtpStart.Value = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 13);
            this.label1.TabIndex = 19;
            this.label1.Text = "From:";
            // 
            // howto_time_date_loops_Form1
            // 
            this.AcceptButton = this.btnGo;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(324, 150);
            this.Controls.Add(this.txtIntLoop);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtDateTimeLoop);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnGo);
            this.Controls.Add(this.dtpEnd);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dtpStart);
            this.Controls.Add(this.label1);
            this.Name = "howto_time_date_loops_Form1";
            this.Text = "howto_time_date_loops";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtIntLoop;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtDateTimeLoop;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnGo;
        private System.Windows.Forms.DateTimePicker dtpEnd;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpStart;
        private System.Windows.Forms.Label label1;
    }
}

