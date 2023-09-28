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
     public partial class howto_nonzero_lower_bound_Form1:Form
  { 


        public howto_nonzero_lower_bound_Form1()
        {
            InitializeComponent();
        }

        private void howto_nonzero_lower_bound_Form1_Load(object sender, EventArgs e)
        {
            // Make an array data[2000..2009, 1..4].
            Array data = Array.CreateInstance(typeof(int),
                new int[] { 10, 4 },
                new int[] { 2000, 1});

            // Initialize the data randomly.
            Random rand = new Random();
            for (int year = 2000; year <= 2009; year++)
            {
                for (int quarter = 1; quarter <= 4; quarter++)
                {
                    data.SetValue(rand.Next(10, 99), year, quarter);
                }
            }

            // Display the data.
            string txt = "Year\tQ1\tQ2\tQ3\tQ4";
            for (int year = data.GetLowerBound(0); year <= data.GetUpperBound(0); year++)
            {
                txt += "\r\n" + year.ToString();
                for (int quarter = data.GetLowerBound(1); quarter <= data.GetUpperBound(1); quarter++)
                {
                    txt += string.Format("\t{0}", data.GetValue(year, quarter));
                }
            }
            txtData.Text = txt;
            txtData.Select(0, 0);
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
            this.txtData = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtData
            // 
            this.txtData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtData.Location = new System.Drawing.Point(12, 12);
            this.txtData.Multiline = true;
            this.txtData.Name = "txtData";
            this.txtData.Size = new System.Drawing.Size(301, 169);
            this.txtData.TabIndex = 0;
            // 
            // howto_nonzero_lower_bound_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(325, 193);
            this.Controls.Add(this.txtData);
            this.Name = "howto_nonzero_lower_bound_Form1";
            this.Text = "howto_nonzero_lower_bound";
            this.Load += new System.EventHandler(this.howto_nonzero_lower_bound_Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtData;
    }
}

