using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Globalization;
using System.Threading;

 

namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_initialize_textbox_Form1:Form
  { 


        public howto_initialize_textbox_Form1()
        {
            InitializeComponent();
        }

        // Set initial TextBox values.
        private void howto_initialize_textbox_Form1_Load(object sender, EventArgs e)
        {
            // Uncomment to test for a German locale.
            //CultureInfo culture_info = new CultureInfo("DE-de");
            //Thread.CurrentThread.CurrentCulture = culture_info;

            // Set the TextBox values.
            txtFloat.Text = (3.14).ToString();
            txtCurrency.Text = (13.37).ToString("C");
            txtDate.Text = DateTime.Today.ToShortDateString();
            txtTime.Text = DateTime.Now.ToShortTimeString();
        }

        // Parse the values.
        private void btnParse_Click(object sender, EventArgs e)
        {
            float number = float.Parse(txtFloat.Text);
            decimal currency = decimal.Parse(txtCurrency.Text, NumberStyles.Any);
            DateTime date = DateTime.Parse(txtDate.Text);
            DateTime time = DateTime.Parse(txtTime.Text);

            Console.WriteLine(number);
            Console.WriteLine(currency.ToString("C"));
            Console.WriteLine(date.ToShortDateString());
            Console.WriteLine(time.ToShortTimeString());
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
            this.txtFloat = new System.Windows.Forms.TextBox();
            this.txtDate = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTime = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtCurrency = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnParse = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Float:";
            // 
            // txtFloat
            // 
            this.txtFloat.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtFloat.Location = new System.Drawing.Point(70, 12);
            this.txtFloat.Name = "txtFloat";
            this.txtFloat.Size = new System.Drawing.Size(100, 20);
            this.txtFloat.TabIndex = 1;
            // 
            // txtDate
            // 
            this.txtDate.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtDate.Location = new System.Drawing.Point(70, 64);
            this.txtDate.Name = "txtDate";
            this.txtDate.Size = new System.Drawing.Size(100, 20);
            this.txtDate.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Date:";
            // 
            // txtTime
            // 
            this.txtTime.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtTime.Location = new System.Drawing.Point(70, 90);
            this.txtTime.Name = "txtTime";
            this.txtTime.Size = new System.Drawing.Size(100, 20);
            this.txtTime.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 93);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Time:";
            // 
            // txtCurrency
            // 
            this.txtCurrency.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtCurrency.Location = new System.Drawing.Point(70, 38);
            this.txtCurrency.Name = "txtCurrency";
            this.txtCurrency.Size = new System.Drawing.Size(100, 20);
            this.txtCurrency.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 41);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Currency:";
            // 
            // btnParse
            // 
            this.btnParse.Location = new System.Drawing.Point(205, 48);
            this.btnParse.Name = "btnParse";
            this.btnParse.Size = new System.Drawing.Size(75, 23);
            this.btnParse.TabIndex = 8;
            this.btnParse.Text = "Parse";
            this.btnParse.UseVisualStyleBackColor = true;
            this.btnParse.Click += new System.EventHandler(this.btnParse_Click);
            // 
            // howto_initialize_textbox_Form1
            // 
            this.AcceptButton = this.btnParse;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(304, 125);
            this.Controls.Add(this.btnParse);
            this.Controls.Add(this.txtCurrency);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtTime);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtDate);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtFloat);
            this.Controls.Add(this.label1);
            this.Name = "howto_initialize_textbox_Form1";
            this.Text = "howto_initialize_textbox";
            this.Load += new System.EventHandler(this.howto_initialize_textbox_Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtFloat;
        private System.Windows.Forms.TextBox txtDate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtTime;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtCurrency;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnParse;
    }
}

