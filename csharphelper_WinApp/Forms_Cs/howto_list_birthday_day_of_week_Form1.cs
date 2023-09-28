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
     public partial class howto_list_birthday_day_of_week_Form1:Form
  { 


        public howto_list_birthday_day_of_week_Form1()
        {
            InitializeComponent();
        }

        // Display the next 10 birthdays.
        private void btnGo_Click(object sender, EventArgs e)
        {
            // Get the month, day, and year of the entered birthday.
            DateTime birthday;
            if (!DateTime.TryParse(txtDate.Text, out birthday))
            {
                MessageBox.Show("Please enter a valid birthday.");
                return;
            }
            int month = birthday.Month;
            int day = birthday.Day;
            int year = birthday.Year;

            // Loop through the years.
            lstBirthDays.Items.Clear();
            for (int i = 0; i <= 10; i++)
            {
                DateTime new_birthday;
                try
                {
                    new_birthday = new DateTime(year + i, month, day);
                }
                catch
                {
                    new_birthday = new DateTime(year + i, month + 1, 1);
                }
                lstBirthDays.Items.Add(
                    new_birthday.ToShortDateString() + " : " +
                    new_birthday.DayOfWeek.ToString());
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
            this.btnGo = new System.Windows.Forms.Button();
            this.txtDate = new System.Windows.Forms.TextBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.lstBirthDays = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // btnGo
            // 
            this.btnGo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGo.Location = new System.Drawing.Point(302, 12);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(45, 23);
            this.btnGo.TabIndex = 1;
            this.btnGo.Text = "Go";
            this.btnGo.UseVisualStyleBackColor = true;
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // txtDate
            // 
            this.txtDate.Location = new System.Drawing.Point(66, 14);
            this.txtDate.Name = "txtDate";
            this.txtDate.Size = new System.Drawing.Size(100, 20);
            this.txtDate.TabIndex = 0;
            this.txtDate.Text = "April 1, 2017";
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(12, 17);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(48, 13);
            this.Label1.TabIndex = 13;
            this.Label1.Text = "Birthday:";
            // 
            // lstBirthDays
            // 
            this.lstBirthDays.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lstBirthDays.FormattingEnabled = true;
            this.lstBirthDays.IntegralHeight = false;
            this.lstBirthDays.Location = new System.Drawing.Point(12, 41);
            this.lstBirthDays.Name = "lstBirthDays";
            this.lstBirthDays.Size = new System.Drawing.Size(335, 160);
            this.lstBirthDays.TabIndex = 2;
            // 
            // howto_list_birthday_day_of_week_Form1
            // 
            this.AcceptButton = this.btnGo;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(359, 213);
            this.Controls.Add(this.btnGo);
            this.Controls.Add(this.txtDate);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.lstBirthDays);
            this.Name = "howto_list_birthday_day_of_week_Form1";
            this.Text = "howto_list_birthday_day_of_week";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Button btnGo;
        internal System.Windows.Forms.TextBox txtDate;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.ListBox lstBirthDays;
    }
}

