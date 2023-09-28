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
     public partial class howto_timespan_Form1:Form
  { 


        public howto_timespan_Form1()
        {
            InitializeComponent();
        }

        // Start with a sample date.
        private void howto_timespan_Form1_Load(object sender, EventArgs e)
        {
            txtDate.Text = "1 April 2000, 23:45";
        }

        // If the text is a date, display
        // the elapsed time between then and now.
        private void txtDate_TextChanged(object sender, EventArgs e)
        {
            DateTime date;
            if (DateTime.TryParse(txtDate.Text, out date))
            {
                txtParsed.Text = date.ToString();

                TimeSpan elapsed = DateTime.Now - date;
                txtDays.Text = elapsed.TotalDays.ToString();
                txtHours.Text = elapsed.TotalHours.ToString();
                txtMinutes.Text = elapsed.TotalMinutes.ToString();
                txtSeconds.Text = elapsed.TotalSeconds.ToString();
            }
            else
            {
                txtParsed.Clear();
                txtDays.Clear();
                txtHours.Clear();
                txtMinutes.Clear();
                txtSeconds.Clear();
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtDate = new System.Windows.Forms.TextBox();
            this.txtHours = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDays = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtSeconds = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtMinutes = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtParsed = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Date:";
            // 
            // txtDate
            // 
            this.txtDate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDate.Location = new System.Drawing.Point(75, 12);
            this.txtDate.Name = "txtDate";
            this.txtDate.Size = new System.Drawing.Size(145, 20);
            this.txtDate.TabIndex = 2;
            this.txtDate.TextChanged += new System.EventHandler(this.txtDate_TextChanged);
            // 
            // txtHours
            // 
            this.txtHours.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtHours.Location = new System.Drawing.Point(75, 126);
            this.txtHours.Name = "txtHours";
            this.txtHours.ReadOnly = true;
            this.txtHours.Size = new System.Drawing.Size(145, 20);
            this.txtHours.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 129);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Hours:";
            // 
            // txtDays
            // 
            this.txtDays.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDays.Location = new System.Drawing.Point(75, 100);
            this.txtDays.Name = "txtDays";
            this.txtDays.ReadOnly = true;
            this.txtDays.Size = new System.Drawing.Size(145, 20);
            this.txtDays.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 103);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(34, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Days:";
            // 
            // txtSeconds
            // 
            this.txtSeconds.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSeconds.Location = new System.Drawing.Point(75, 178);
            this.txtSeconds.Name = "txtSeconds";
            this.txtSeconds.ReadOnly = true;
            this.txtSeconds.Size = new System.Drawing.Size(145, 20);
            this.txtSeconds.TabIndex = 14;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 181);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "Seconds:";
            // 
            // txtMinutes
            // 
            this.txtMinutes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMinutes.Location = new System.Drawing.Point(75, 152);
            this.txtMinutes.Name = "txtMinutes";
            this.txtMinutes.ReadOnly = true;
            this.txtMinutes.Size = new System.Drawing.Size(145, 20);
            this.txtMinutes.TabIndex = 12;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 155);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(47, 13);
            this.label7.TabIndex = 11;
            this.label7.Text = "Minutes:";
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.label9.Location = new System.Drawing.Point(15, 70);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(205, 18);
            this.label9.TabIndex = 17;
            this.label9.Text = "Elapsed";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtParsed
            // 
            this.txtParsed.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtParsed.Location = new System.Drawing.Point(75, 38);
            this.txtParsed.Name = "txtParsed";
            this.txtParsed.ReadOnly = true;
            this.txtParsed.Size = new System.Drawing.Size(145, 20);
            this.txtParsed.TabIndex = 18;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 19;
            this.label2.Text = "Parsed:";
            // 
            // howto_timespan_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(234, 207);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtParsed);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtSeconds);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtMinutes);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtHours);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtDays);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtDate);
            this.Controls.Add(this.label1);
            this.Name = "howto_timespan_Form1";
            this.Text = "howto_timespan";
            this.Load += new System.EventHandler(this.howto_timespan_Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDate;
        private System.Windows.Forms.TextBox txtHours;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtDays;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtSeconds;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtMinutes;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtParsed;
        private System.Windows.Forms.Label label2;
    }
}

