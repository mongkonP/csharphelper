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
     public partial class howto_pic_histogram_Form1:Form
  { 


        public howto_pic_histogram_Form1()
        {
            InitializeComponent();
        }

        // Make some random data.
        private void howto_pic_histogram_Form1_Load(object sender, EventArgs e)
        {
            // Do not allow the user to resize the form.
            FormBorderStyle = FormBorderStyle.FixedDialog;

            Color[] Colors = new Color[] {
                Color.Red, Color.LightGreen, Color.Blue,
                Color.Pink, Color.Green, Color.LightBlue,
                Color.Orange, Color.Yellow, Color.Purple
            };

            Random rand = new Random();

            const int num_values = 10;
            int wid = picHisto.ClientSize.Width / num_values;

            for (int i = 0; i < num_values; i++)
            {
                int value = rand.Next(5, 95);

                // Make a label to be the histogram.
                Label lbl_hist = new Label();
                lbl_hist.Parent = picHisto;
                lbl_hist.BackColor = Colors[i % Colors.Length];
                lbl_hist.BorderStyle = BorderStyle.FixedSingle;
                lbl_hist.Width = wid;
                lbl_hist.Height =
                    (int)(picHisto.ClientSize.Height * value / 100f);
                lbl_hist.Left = i * wid;
                lbl_hist.Top =
                    picHisto.ClientSize.Height - lbl_hist.Height;

                // Make a label to display the value.
                Label lbl_value = new Label();
                lbl_value.Parent = picHisto;
                lbl_value.BackColor = Color.Transparent;
                lbl_value.Text = value.ToString();
                lbl_value.TextAlign = ContentAlignment.TopCenter;
                lbl_value.Left = lbl_hist.Left;
                lbl_value.Width = lbl_hist.Width;
                lbl_value.Height = 15;
                lbl_value.Top = lbl_hist.Top - lbl_value.Height;
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
            this.picHisto = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picHisto)).BeginInit();
            this.SuspendLayout();
            // 
            // picHisto
            // 
            this.picHisto.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.picHisto.BackColor = System.Drawing.Color.White;
            this.picHisto.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.picHisto.Location = new System.Drawing.Point(12, 12);
            this.picHisto.Name = "picHisto";
            this.picHisto.Size = new System.Drawing.Size(450, 251);
            this.picHisto.TabIndex = 0;
            this.picHisto.TabStop = false;
            // 
            // howto_pic_histogram_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(474, 275);
            this.Controls.Add(this.picHisto);
            this.Name = "howto_pic_histogram_Form1";
            this.Text = "howto_pic_histogram";
            this.Load += new System.EventHandler(this.howto_pic_histogram_Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picHisto)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox picHisto;
    }
}

