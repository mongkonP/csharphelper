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
     public partial class howto_elapsed_ymd_Form1:Form
  { 


        public howto_elapsed_ymd_Form1()
        {
            InitializeComponent();
        }

        // Clear any previous results.
        private void txtDate_TextChanged(object sender, EventArgs e)
        {
            txtElapsed.Clear();
        }

        // Display the elapsed time.
        private void btnCalculate_Click(object sender, EventArgs e)
        {
            txtElapsed.Clear();

            DateTime start_date, end_date;
            if (!DateTime.TryParse(txtStartDate.Text, out start_date)) return;
            if (!DateTime.TryParse(txtEndDate.Text, out end_date)) return;

            int years, months, days, hours, minutes, seconds, milliseconds;

            GetElapsedTime(start_date, end_date, out years, out months,
                out days, out hours, out minutes, out seconds, out milliseconds);

            // Display the result.
            string txt = "";
            if (years != 0) txt += ", " + years.ToString() + " years";
            if (months != 0) txt += ", " + months.ToString() + " months";
            if (days != 0) txt += ", " + days.ToString() + " days";
            if (hours != 0) txt += ", " + hours.ToString() + " hours";
            if (minutes != 0) txt += ", " + minutes.ToString() + " minutes";
            if (seconds != 0) txt += ", " + seconds.ToString() + " seconds";
            if (milliseconds != 0) txt += ", " + milliseconds.ToString() + " milliseconds";
            if (txt.Length > 0) txt = txt.Substring(2);
            if (txt.Length == 0) txt = "Same";
            txtElapsed.Text = txt;
        }

        // Return the number of years, months, days, hours, minutes, seconds,
        // and milliseconds you need to add to from_date to get to_date.
        private void GetElapsedTime(DateTime from_date, DateTime to_date, 
            out int years, out int months, out int days, out int hours,
            out int minutes, out int seconds, out int milliseconds)
        {
            // If from_date > to_date, switch them around.
            if (from_date > to_date)
            {
                GetElapsedTime(to_date, from_date,
                    out years, out months, out days, out hours,
                    out minutes, out seconds, out milliseconds);
                years = -years;
                months = -months;
                days = -days;
                hours = -hours;
                minutes = -minutes;
                seconds = -seconds;
                milliseconds = -milliseconds;
            }
            else
            {
                // Handle the years.
                years = to_date.Year - from_date.Year;

                // See if we went too far.
                DateTime test_date = from_date.AddMonths(12 * years);
                if (test_date > to_date)
                {
                    years--;
                    test_date = from_date.AddMonths(12 * years);
                }

                // Add months until we go too far.
                months = 0;
                while (test_date <= to_date)
                {
                    months++;
                    test_date = from_date.AddMonths(12 * years + months);
                }
                months--;

                // Subtract to see how many more days,
                // hours, minutes, etc. we need.
                from_date = from_date.AddMonths(12 * years + months);
                TimeSpan remainder = to_date - from_date;
                days = remainder.Days;
                hours = remainder.Hours;
                minutes = remainder.Minutes;
                seconds = remainder.Seconds;
                milliseconds = remainder.Milliseconds;
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
            this.txtElapsed = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtStartDate = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtEndDate = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnCalculate = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtElapsed
            // 
            this.txtElapsed.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtElapsed.Location = new System.Drawing.Point(76, 106);
            this.txtElapsed.Multiline = true;
            this.txtElapsed.Name = "txtElapsed";
            this.txtElapsed.ReadOnly = true;
            this.txtElapsed.Size = new System.Drawing.Size(170, 52);
            this.txtElapsed.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 109);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 13);
            this.label5.TabIndex = 22;
            this.label5.Text = "Elapsed:";
            // 
            // txtStartDate
            // 
            this.txtStartDate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtStartDate.Location = new System.Drawing.Point(76, 10);
            this.txtStartDate.Name = "txtStartDate";
            this.txtStartDate.Size = new System.Drawing.Size(170, 20);
            this.txtStartDate.TabIndex = 0;
            this.txtStartDate.Text = "21 July 1969, 20:17:40";
            this.txtStartDate.TextChanged += new System.EventHandler(this.txtDate_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 20;
            this.label1.Text = "Start Date:";
            // 
            // txtEndDate
            // 
            this.txtEndDate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtEndDate.Location = new System.Drawing.Point(76, 36);
            this.txtEndDate.Name = "txtEndDate";
            this.txtEndDate.Size = new System.Drawing.Size(170, 20);
            this.txtEndDate.TabIndex = 1;
            this.txtEndDate.Text = "14 December 1972, 19:54:57";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 24;
            this.label2.Text = "End Date:";
            // 
            // btnCalculate
            // 
            this.btnCalculate.Location = new System.Drawing.Point(76, 69);
            this.btnCalculate.Name = "btnCalculate";
            this.btnCalculate.Size = new System.Drawing.Size(75, 23);
            this.btnCalculate.TabIndex = 2;
            this.btnCalculate.Text = "Calculate";
            this.btnCalculate.UseVisualStyleBackColor = true;
            this.btnCalculate.Click += new System.EventHandler(this.btnCalculate_Click);
            // 
            // howto_elapsed_ymd_Form1
            // 
            this.AcceptButton = this.btnCalculate;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(259, 170);
            this.Controls.Add(this.btnCalculate);
            this.Controls.Add(this.txtEndDate);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtElapsed);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtStartDate);
            this.Controls.Add(this.label1);
            this.Name = "howto_elapsed_ymd_Form1";
            this.Text = "howto_elapsed_ymd";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtElapsed;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtStartDate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtEndDate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnCalculate;
    }
}

