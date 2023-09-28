using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

 

using howto_stddev_extension;
namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_stddev_extension_Form1:Form
  { 


        public howto_stddev_extension_Form1()
        {
            InitializeComponent();
        }

        // Make some data.
        private void howto_stddev_extension_Form1_Load(object sender, EventArgs e)
        {
            // Make the values.
            Random rand = new Random();
            const int num_values = 100;

            // List version.
            List<int> values = new List<int>();
            for (int i = 0; i < num_values; i++)
            {
                values.Add(rand.Next(1, 7) + rand.Next(1, 7));
            }

            // Array version.
            //int[] values = new int[num_values];
            //for (int i = 0; i < num_values; i++)
            //{
            //    values[i] = rand.Next(1, 7) + rand.Next(1, 7);
            //}

            // Display the values.
            lstValues.DataSource = values;

            // Display statistics.
            txtAverage.Text = values.Average().ToString("0.00");
            txtStddevSample.Text = values.StdDev(true).ToString("0.00");
            txtStddevPopulation.Text = values.StdDev(false).ToString("0.00");

            // Make a simple histogram.
            Label[] labels = { lbl2, lbl3, lbl4, lbl5, lbl6, lbl7, lbl8, lbl9, lbl10, lbl11, lbl12 };
            int bottom = lbl2.Bottom;
            foreach (Label lbl in labels) lbl.Height = 1;
            const int pixel_scale = 10;
            for (int i = 0; i < num_values; i++)
            {
                int index = values[i] - 2;
                labels[index].Height += pixel_scale;
            }
            foreach (Label lbl in labels)
            {
                lbl.Top = bottom - lbl.Height;
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
            this.txtStddevPopulation = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtStddevSample = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtAverage = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lstValues = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label18
            // 
            this.label18.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label18.Location = new System.Drawing.Point(342, 282);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(20, 23);
            this.label18.TabIndex = 89;
            this.label18.Text = "12";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl12
            // 
            this.lbl12.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl12.BackColor = System.Drawing.Color.LightGreen;
            this.lbl12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl12.Location = new System.Drawing.Point(342, 259);
            this.lbl12.Name = "lbl12";
            this.lbl12.Size = new System.Drawing.Size(20, 23);
            this.lbl12.TabIndex = 88;
            // 
            // label20
            // 
            this.label20.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label20.Location = new System.Drawing.Point(322, 282);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(20, 23);
            this.label20.TabIndex = 87;
            this.label20.Text = "11";
            this.label20.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl11
            // 
            this.lbl11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl11.BackColor = System.Drawing.Color.LightGreen;
            this.lbl11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl11.Location = new System.Drawing.Point(322, 259);
            this.lbl11.Name = "lbl11";
            this.lbl11.Size = new System.Drawing.Size(20, 23);
            this.lbl11.TabIndex = 86;
            // 
            // label22
            // 
            this.label22.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label22.Location = new System.Drawing.Point(302, 282);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(20, 23);
            this.label22.TabIndex = 85;
            this.label22.Text = "10";
            this.label22.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl10
            // 
            this.lbl10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl10.BackColor = System.Drawing.Color.LightGreen;
            this.lbl10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl10.Location = new System.Drawing.Point(302, 259);
            this.lbl10.Name = "lbl10";
            this.lbl10.Size = new System.Drawing.Size(20, 23);
            this.lbl10.TabIndex = 84;
            // 
            // label24
            // 
            this.label24.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label24.Location = new System.Drawing.Point(282, 282);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(20, 23);
            this.label24.TabIndex = 83;
            this.label24.Text = "9";
            this.label24.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl9
            // 
            this.lbl9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl9.BackColor = System.Drawing.Color.LightGreen;
            this.lbl9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl9.Location = new System.Drawing.Point(282, 259);
            this.lbl9.Name = "lbl9";
            this.lbl9.Size = new System.Drawing.Size(20, 23);
            this.lbl9.TabIndex = 82;
            // 
            // label26
            // 
            this.label26.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label26.Location = new System.Drawing.Point(262, 282);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(20, 23);
            this.label26.TabIndex = 81;
            this.label26.Text = "8";
            this.label26.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl8
            // 
            this.lbl8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl8.BackColor = System.Drawing.Color.LightGreen;
            this.lbl8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl8.Location = new System.Drawing.Point(262, 259);
            this.lbl8.Name = "lbl8";
            this.lbl8.Size = new System.Drawing.Size(20, 23);
            this.lbl8.TabIndex = 80;
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label10.Location = new System.Drawing.Point(242, 282);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(20, 23);
            this.label10.TabIndex = 79;
            this.label10.Text = "7";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl7
            // 
            this.lbl7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl7.BackColor = System.Drawing.Color.LightGreen;
            this.lbl7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl7.Location = new System.Drawing.Point(242, 259);
            this.lbl7.Name = "lbl7";
            this.lbl7.Size = new System.Drawing.Size(20, 23);
            this.lbl7.TabIndex = 78;
            // 
            // label12
            // 
            this.label12.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label12.Location = new System.Drawing.Point(222, 282);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(20, 23);
            this.label12.TabIndex = 77;
            this.label12.Text = "6";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl6
            // 
            this.lbl6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl6.BackColor = System.Drawing.Color.LightGreen;
            this.lbl6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl6.Location = new System.Drawing.Point(222, 259);
            this.lbl6.Name = "lbl6";
            this.lbl6.Size = new System.Drawing.Size(20, 23);
            this.lbl6.TabIndex = 76;
            // 
            // label14
            // 
            this.label14.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label14.Location = new System.Drawing.Point(202, 282);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(20, 23);
            this.label14.TabIndex = 75;
            this.label14.Text = "5";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl5
            // 
            this.lbl5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl5.BackColor = System.Drawing.Color.LightGreen;
            this.lbl5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl5.Location = new System.Drawing.Point(202, 259);
            this.lbl5.Name = "lbl5";
            this.lbl5.Size = new System.Drawing.Size(20, 23);
            this.lbl5.TabIndex = 74;
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.Location = new System.Drawing.Point(182, 282);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(20, 23);
            this.label8.TabIndex = 73;
            this.label8.Text = "4";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl4
            // 
            this.lbl4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl4.BackColor = System.Drawing.Color.LightGreen;
            this.lbl4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl4.Location = new System.Drawing.Point(182, 259);
            this.lbl4.Name = "lbl4";
            this.lbl4.Size = new System.Drawing.Size(20, 23);
            this.lbl4.TabIndex = 72;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.Location = new System.Drawing.Point(162, 282);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(20, 23);
            this.label6.TabIndex = 71;
            this.label6.Text = "3";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl3
            // 
            this.lbl3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl3.BackColor = System.Drawing.Color.LightGreen;
            this.lbl3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl3.Location = new System.Drawing.Point(162, 259);
            this.lbl3.Name = "lbl3";
            this.lbl3.Size = new System.Drawing.Size(20, 23);
            this.lbl3.TabIndex = 70;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.Location = new System.Drawing.Point(142, 282);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(20, 23);
            this.label5.TabIndex = 69;
            this.label5.Text = "2";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl2
            // 
            this.lbl2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl2.BackColor = System.Drawing.Color.LightGreen;
            this.lbl2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl2.Location = new System.Drawing.Point(142, 259);
            this.lbl2.Name = "lbl2";
            this.lbl2.Size = new System.Drawing.Size(20, 23);
            this.lbl2.TabIndex = 68;
            // 
            // txtStddevPopulation
            // 
            this.txtStddevPopulation.Location = new System.Drawing.Point(15, 262);
            this.txtStddevPopulation.Name = "txtStddevPopulation";
            this.txtStddevPopulation.Size = new System.Drawing.Size(91, 20);
            this.txtStddevPopulation.TabIndex = 67;
            this.txtStddevPopulation.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 246);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(94, 13);
            this.label4.TabIndex = 66;
            this.label4.Text = "Stddev Population";
            // 
            // txtStddevSample
            // 
            this.txtStddevSample.Location = new System.Drawing.Point(15, 223);
            this.txtStddevSample.Name = "txtStddevSample";
            this.txtStddevSample.Size = new System.Drawing.Size(91, 20);
            this.txtStddevSample.TabIndex = 65;
            this.txtStddevSample.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 207);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 13);
            this.label3.TabIndex = 64;
            this.label3.Text = "Stddev Sample";
            // 
            // txtAverage
            // 
            this.txtAverage.Location = new System.Drawing.Point(15, 175);
            this.txtAverage.Name = "txtAverage";
            this.txtAverage.Size = new System.Drawing.Size(91, 20);
            this.txtAverage.TabIndex = 63;
            this.txtAverage.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 159);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 13);
            this.label2.TabIndex = 62;
            this.label2.Text = "Average:";
            // 
            // lstValues
            // 
            this.lstValues.FormattingEnabled = true;
            this.lstValues.Location = new System.Drawing.Point(15, 25);
            this.lstValues.Name = "lstValues";
            this.lstValues.Size = new System.Drawing.Size(91, 121);
            this.lstValues.TabIndex = 61;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 13);
            this.label1.TabIndex = 60;
            this.label1.Text = "Values:";
            // 
            // howto_stddev_extension_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(374, 314);
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
            this.Controls.Add(this.txtStddevPopulation);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtStddevSample);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtAverage);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lstValues);
            this.Controls.Add(this.label1);
            this.Name = "howto_stddev_extension_Form1";
            this.Text = "howto_stddev_extension";
            this.Load += new System.EventHandler(this.howto_stddev_extension_Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

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
        private System.Windows.Forms.TextBox txtStddevPopulation;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtStddevSample;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtAverage;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox lstValues;
        private System.Windows.Forms.Label label1;
    }
}

