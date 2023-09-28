using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Globalization;

 

namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_parse_currency_Form1:Form
  { 


        public howto_parse_currency_Form1()
        {
            InitializeComponent();
        }

        // Parse the entered value.
        private void btnParse_Click(object sender, EventArgs e)
        {
            // Default parsing behavior.
            try
            {
                decimal value = decimal.Parse(txtValue.Text);
                txtDefault.Text = value.ToString("C");
            }
            catch (Exception ex)
            {
                txtDefault.Text = ex.Message;
            }

            // Parse with Any format.
            try
            {
                decimal value = decimal.Parse(txtValue.Text, NumberStyles.Any);
                txtAny.Text = value.ToString("C");
            }
            catch (Exception ex)
            {
                txtAny.Text = ex.Message;
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
            this.txtValue = new System.Windows.Forms.TextBox();
            this.btnParse = new System.Windows.Forms.Button();
            this.txtDefault = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtAny = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Value";
            // 
            // txtValue
            // 
            this.txtValue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtValue.Location = new System.Drawing.Point(59, 6);
            this.txtValue.Name = "txtValue";
            this.txtValue.Size = new System.Drawing.Size(246, 20);
            this.txtValue.TabIndex = 1;
            this.txtValue.Text = "($123,456.78)";
            this.txtValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnParse
            // 
            this.btnParse.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnParse.Location = new System.Drawing.Point(121, 37);
            this.btnParse.Name = "btnParse";
            this.btnParse.Size = new System.Drawing.Size(75, 23);
            this.btnParse.TabIndex = 2;
            this.btnParse.Text = "Parse";
            this.btnParse.UseVisualStyleBackColor = true;
            this.btnParse.Click += new System.EventHandler(this.btnParse_Click);
            // 
            // txtDefault
            // 
            this.txtDefault.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDefault.Location = new System.Drawing.Point(59, 67);
            this.txtDefault.Name = "txtDefault";
            this.txtDefault.ReadOnly = true;
            this.txtDefault.Size = new System.Drawing.Size(246, 20);
            this.txtDefault.TabIndex = 4;
            this.txtDefault.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Default";
            // 
            // txtAny
            // 
            this.txtAny.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAny.Location = new System.Drawing.Point(59, 93);
            this.txtAny.Name = "txtAny";
            this.txtAny.ReadOnly = true;
            this.txtAny.Size = new System.Drawing.Size(246, 20);
            this.txtAny.TabIndex = 6;
            this.txtAny.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 96);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(25, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Any";
            // 
            // howto_parse_currency_Form1
            // 
            this.AcceptButton = this.btnParse;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(317, 125);
            this.Controls.Add(this.txtAny);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtDefault);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnParse);
            this.Controls.Add(this.txtValue);
            this.Controls.Add(this.label1);
            this.Name = "howto_parse_currency_Form1";
            this.Text = "howto_parse_currency";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtValue;
        private System.Windows.Forms.Button btnParse;
        private System.Windows.Forms.TextBox txtDefault;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtAny;
        private System.Windows.Forms.Label label3;
    }
}

