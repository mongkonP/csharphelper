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
     public partial class howto_find_next_friday_Form1:Form
  { 


        public howto_find_next_friday_Form1()
        {
            InitializeComponent();
        }

        // Start with today's date selected.
        private void howto_find_next_friday_Form1_Load(object sender, EventArgs e)
        {
            txtDate.Text = DateTime.Now.ToShortDateString();
        }

        // Find the next Friday.
        private void btnFindFriday_Click(object sender, EventArgs e)
        {
            // Get the indicated date.
            DateTime the_date = DateTime.Parse(txtDate.Text);
            txtDateLong.Text = the_date.ToLongDateString();

            // Find the next Friday.
            // Get the number of days between the_date's day of the week and Friday.
            int num_days = System.DayOfWeek.Friday - the_date.DayOfWeek;
            if (num_days < 0) num_days += 7;

            // Add the needed number of days.
            DateTime friday = the_date.AddDays(num_days);

            // Display the result.
            txtFriday.Text = friday.ToShortDateString();
            txtFridayLong.Text = friday.ToLongDateString();
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
            this.txtFridayLong = new System.Windows.Forms.TextBox();
            this.txtDateLong = new System.Windows.Forms.TextBox();
            this.txtFriday = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnFindFriday = new System.Windows.Forms.Button();
            this.txtDate = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtFridayLong
            // 
            this.txtFridayLong.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFridayLong.Location = new System.Drawing.Point(171, 68);
            this.txtFridayLong.Name = "txtFridayLong";
            this.txtFridayLong.Size = new System.Drawing.Size(186, 20);
            this.txtFridayLong.TabIndex = 13;
            // 
            // txtDateLong
            // 
            this.txtDateLong.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDateLong.Location = new System.Drawing.Point(171, 13);
            this.txtDateLong.Name = "txtDateLong";
            this.txtDateLong.Size = new System.Drawing.Size(186, 20);
            this.txtDateLong.TabIndex = 12;
            // 
            // txtFriday
            // 
            this.txtFriday.Location = new System.Drawing.Point(65, 68);
            this.txtFriday.Name = "txtFriday";
            this.txtFriday.Size = new System.Drawing.Size(100, 20);
            this.txtFriday.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Friday:";
            // 
            // btnFindFriday
            // 
            this.btnFindFriday.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnFindFriday.Location = new System.Drawing.Point(147, 39);
            this.btnFindFriday.Name = "btnFindFriday";
            this.btnFindFriday.Size = new System.Drawing.Size(75, 23);
            this.btnFindFriday.TabIndex = 9;
            this.btnFindFriday.Text = "Find Friday";
            this.btnFindFriday.UseVisualStyleBackColor = true;
            this.btnFindFriday.Click += new System.EventHandler(this.btnFindFriday_Click);
            // 
            // txtDate
            // 
            this.txtDate.Location = new System.Drawing.Point(65, 13);
            this.txtDate.Name = "txtDate";
            this.txtDate.Size = new System.Drawing.Size(100, 20);
            this.txtDate.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Date:";
            // 
            // howto_find_next_friday_Form1
            // 
            this.AcceptButton = this.btnFindFriday;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(369, 100);
            this.Controls.Add(this.txtFridayLong);
            this.Controls.Add(this.txtDateLong);
            this.Controls.Add(this.txtFriday);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnFindFriday);
            this.Controls.Add(this.txtDate);
            this.Controls.Add(this.label1);
            this.Name = "howto_find_next_friday_Form1";
            this.Text = "howto_find_next_friday";
            this.Load += new System.EventHandler(this.howto_find_next_friday_Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtFridayLong;
        private System.Windows.Forms.TextBox txtDateLong;
        private System.Windows.Forms.TextBox txtFriday;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnFindFriday;
        private System.Windows.Forms.TextBox txtDate;
        private System.Windows.Forms.Label label1;
    }
}

