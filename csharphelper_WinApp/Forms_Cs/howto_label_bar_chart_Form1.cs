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
     public partial class howto_label_bar_chart_Form1:Form
  { 


        public howto_label_bar_chart_Form1()
        {
            InitializeComponent();
        }

        // Make some data.
        private void howto_label_bar_chart_Form1_Load(object sender, EventArgs e)
        {
            // Make an array to hold counts for values
            // between 2 and 12 with indexes between 0 and 10.
            int[] counts = new int[11];

            // Make the values.
            Random rand = new Random();
            for (int i = 0; i < 1000; i++)
            {
                // Roll two 6-sided dice.
                int new_value = rand.Next(1, 7) + rand.Next(1, 7);
                int index = new_value - 2;
                counts[index]++;
            }

            // Make a simple histogram.
            Label[] labels = { lbl2, lbl3, lbl4, lbl5, lbl6,
                lbl7, lbl8, lbl9, lbl10, lbl11, lbl12 };
            MakeHistogram(labels, counts);
        }

        // Display the values.
        private void MakeHistogram(Label[] labels, int[] values)
        {
            // Calculate a scale so the largest
            // value fits nicely on the form.
            int available_height = labels[0].Bottom - 5;
            int max = values.Max();
            float scale = available_height / (float)max;

            for (int i = 0; i < labels.Length; i++)
            {
                int height = (int)(scale * values[i]);
                labels[i].Top = labels[i].Bottom - height;
                labels[i].Height = height;
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
            this.label18 = new System.Windows.Forms.Label();
            this.lbl12 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.lbl11 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.lbl10 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.lbl9 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.lbl8 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.lbl7 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.lbl6 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.lbl5 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lbl4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lbl3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lbl2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label18
            // 
            this.label18.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label18.Location = new System.Drawing.Point(212, 232);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(20, 23);
            this.label18.TabIndex = 51;
            this.label18.Text = "12";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl12
            // 
            this.lbl12.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbl12.BackColor = System.Drawing.Color.LightGreen;
            this.lbl12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl12.Location = new System.Drawing.Point(212, 209);
            this.lbl12.Name = "lbl12";
            this.lbl12.Size = new System.Drawing.Size(20, 23);
            this.lbl12.TabIndex = 50;
            // 
            // label20
            // 
            this.label20.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label20.Location = new System.Drawing.Point(192, 232);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(20, 23);
            this.label20.TabIndex = 49;
            this.label20.Text = "11";
            this.label20.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl11
            // 
            this.lbl11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbl11.BackColor = System.Drawing.Color.LightGreen;
            this.lbl11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl11.Location = new System.Drawing.Point(192, 209);
            this.lbl11.Name = "lbl11";
            this.lbl11.Size = new System.Drawing.Size(20, 23);
            this.lbl11.TabIndex = 48;
            // 
            // label22
            // 
            this.label22.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label22.Location = new System.Drawing.Point(172, 232);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(20, 23);
            this.label22.TabIndex = 47;
            this.label22.Text = "10";
            this.label22.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl10
            // 
            this.lbl10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbl10.BackColor = System.Drawing.Color.LightGreen;
            this.lbl10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl10.Location = new System.Drawing.Point(172, 209);
            this.lbl10.Name = "lbl10";
            this.lbl10.Size = new System.Drawing.Size(20, 23);
            this.lbl10.TabIndex = 46;
            // 
            // label24
            // 
            this.label24.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label24.Location = new System.Drawing.Point(152, 232);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(20, 23);
            this.label24.TabIndex = 45;
            this.label24.Text = "9";
            this.label24.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl9
            // 
            this.lbl9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbl9.BackColor = System.Drawing.Color.LightGreen;
            this.lbl9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl9.Location = new System.Drawing.Point(152, 209);
            this.lbl9.Name = "lbl9";
            this.lbl9.Size = new System.Drawing.Size(20, 23);
            this.lbl9.TabIndex = 44;
            // 
            // label26
            // 
            this.label26.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label26.Location = new System.Drawing.Point(132, 232);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(20, 23);
            this.label26.TabIndex = 43;
            this.label26.Text = "8";
            this.label26.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl8
            // 
            this.lbl8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbl8.BackColor = System.Drawing.Color.LightGreen;
            this.lbl8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl8.Location = new System.Drawing.Point(132, 209);
            this.lbl8.Name = "lbl8";
            this.lbl8.Size = new System.Drawing.Size(20, 23);
            this.lbl8.TabIndex = 42;
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label10.Location = new System.Drawing.Point(112, 232);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(20, 23);
            this.label10.TabIndex = 41;
            this.label10.Text = "7";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl7
            // 
            this.lbl7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbl7.BackColor = System.Drawing.Color.LightGreen;
            this.lbl7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl7.Location = new System.Drawing.Point(112, 209);
            this.lbl7.Name = "lbl7";
            this.lbl7.Size = new System.Drawing.Size(20, 23);
            this.lbl7.TabIndex = 40;
            // 
            // label12
            // 
            this.label12.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label12.Location = new System.Drawing.Point(92, 232);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(20, 23);
            this.label12.TabIndex = 39;
            this.label12.Text = "6";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl6
            // 
            this.lbl6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbl6.BackColor = System.Drawing.Color.LightGreen;
            this.lbl6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl6.Location = new System.Drawing.Point(92, 209);
            this.lbl6.Name = "lbl6";
            this.lbl6.Size = new System.Drawing.Size(20, 23);
            this.lbl6.TabIndex = 38;
            // 
            // label14
            // 
            this.label14.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label14.Location = new System.Drawing.Point(72, 232);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(20, 23);
            this.label14.TabIndex = 37;
            this.label14.Text = "5";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl5
            // 
            this.lbl5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbl5.BackColor = System.Drawing.Color.LightGreen;
            this.lbl5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl5.Location = new System.Drawing.Point(72, 209);
            this.lbl5.Name = "lbl5";
            this.lbl5.Size = new System.Drawing.Size(20, 23);
            this.lbl5.TabIndex = 36;
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label8.Location = new System.Drawing.Point(52, 232);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(20, 23);
            this.label8.TabIndex = 35;
            this.label8.Text = "4";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl4
            // 
            this.lbl4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbl4.BackColor = System.Drawing.Color.LightGreen;
            this.lbl4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl4.Location = new System.Drawing.Point(52, 209);
            this.lbl4.Name = "lbl4";
            this.lbl4.Size = new System.Drawing.Size(20, 23);
            this.lbl4.TabIndex = 34;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label6.Location = new System.Drawing.Point(32, 232);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(20, 23);
            this.label6.TabIndex = 33;
            this.label6.Text = "3";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl3
            // 
            this.lbl3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbl3.BackColor = System.Drawing.Color.LightGreen;
            this.lbl3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl3.Location = new System.Drawing.Point(32, 209);
            this.lbl3.Name = "lbl3";
            this.lbl3.Size = new System.Drawing.Size(20, 23);
            this.lbl3.TabIndex = 32;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label5.Location = new System.Drawing.Point(12, 232);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(20, 23);
            this.label5.TabIndex = 31;
            this.label5.Text = "2";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl2
            // 
            this.lbl2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbl2.BackColor = System.Drawing.Color.LightGreen;
            this.lbl2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl2.Location = new System.Drawing.Point(12, 209);
            this.lbl2.Name = "lbl2";
            this.lbl2.Size = new System.Drawing.Size(20, 23);
            this.lbl2.TabIndex = 30;
            // 
            // howto_label_bar_chart_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(244, 264);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.lbl12);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.lbl11);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.lbl10);
            this.Controls.Add(this.label24);
            this.Controls.Add(this.lbl9);
            this.Controls.Add(this.label26);
            this.Controls.Add(this.lbl8);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.lbl7);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.lbl6);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.lbl5);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.lbl4);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lbl3);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lbl2);
            this.Name = "howto_label_bar_chart_Form1";
            this.Text = "howto_label_bar_chart";
            this.Load += new System.EventHandler(this.howto_label_bar_chart_Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label lbl12;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label lbl11;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label lbl10;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label lbl9;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label lbl8;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lbl7;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label lbl6;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label lbl5;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lbl4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lbl3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lbl2;
    }
}

