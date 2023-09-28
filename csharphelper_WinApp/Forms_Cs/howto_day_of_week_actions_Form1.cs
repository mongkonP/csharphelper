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
     public partial class howto_day_of_week_actions_Form1:Form
  { 


        public howto_day_of_week_actions_Form1()
        {
            InitializeComponent();
        }

        // Display a message that depends on the day of the week.
        private void howto_day_of_week_actions_Form1_Load(object sender, EventArgs e)
        {
            // Set the label with a switch statement.
            switch (DateTime.Now.DayOfWeek)
            {
                case DayOfWeek.Monday:
                    lblGreeting1.Text = "It's Manic Monday!";
                    break;
                case DayOfWeek.Tuesday:
                    lblGreeting1.Text = "It's Terriffic Tuesday";
                    break;
                case DayOfWeek.Wednesday:
                    lblGreeting1.Text = "It's Happy Hump Day!";
                    break;
                case DayOfWeek.Thursday:
                    lblGreeting1.Text = "It's Thirsty Thursday";
                    break;
                case DayOfWeek.Friday:
                    lblGreeting1.Text = "It's Freaky Friday";
                    break;
                case DayOfWeek.Saturday:
                    lblGreeting1.Text = "It's Satisfying Saturday";
                    break;
                case DayOfWeek.Sunday:
                    lblGreeting1.Text = "It's Sleepy Sunday";
                    break;
            }

            // Set a label by using an array.
            string[] greetings = 
            {
                "Sleepy Sunday",
                "Manic Monday!",
                "Terriffic Tuesday",
                "Happy Hump Day!",
                "Thirsty Thursday",
                "Freaky Friday",
                "Satisfying Saturday",
            };
            lblGreeting2.Text = "It's " + greetings[(int)DateTime.Now.DayOfWeek];
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
            this.lblGreeting2 = new System.Windows.Forms.Label();
            this.lblGreeting1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblGreeting2
            // 
            this.lblGreeting2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblGreeting2.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGreeting2.Location = new System.Drawing.Point(12, 57);
            this.lblGreeting2.Name = "lblGreeting2";
            this.lblGreeting2.Size = new System.Drawing.Size(310, 37);
            this.lblGreeting2.TabIndex = 3;
            this.lblGreeting2.Text = "label1";
            this.lblGreeting2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblGreeting1
            // 
            this.lblGreeting1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblGreeting1.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGreeting1.Location = new System.Drawing.Point(12, 9);
            this.lblGreeting1.Name = "lblGreeting1";
            this.lblGreeting1.Size = new System.Drawing.Size(310, 37);
            this.lblGreeting1.TabIndex = 2;
            this.lblGreeting1.Text = "label1";
            this.lblGreeting1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // howto_day_of_week_actions_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(334, 103);
            this.Controls.Add(this.lblGreeting2);
            this.Controls.Add(this.lblGreeting1);
            this.Name = "howto_day_of_week_actions_Form1";
            this.Text = "howto_day_of_week_actions";
            this.Load += new System.EventHandler(this.howto_day_of_week_actions_Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblGreeting2;
        private System.Windows.Forms.Label lblGreeting1;
    }
}

