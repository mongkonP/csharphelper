using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

 

using howto_make_ordinal;
namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_make_ordinal_Form1:Form
  { 


        public howto_make_ordinal_Form1()
        {
            InitializeComponent();
        }

        // Display an initial value.
        private void howto_make_ordinal_Form1_Load(object sender, EventArgs e)
        {
            txtNumber.Text = "1337";
        }

        // Display the ordinal version of the number.
        private void txtNumber_TextChanged(object sender, EventArgs e)
        {
            // Parse the value and display its ordinal extension.
            try
            {
                int value = int.Parse(txtNumber.Text,
                    System.Globalization.NumberStyles.Any);
                txtResult.Text = value.ToString("#,##0 ") + value.ToOrdinal();
            }
            catch
            {
                txtResult.Clear();
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
            this.txtNumber = new System.Windows.Forms.TextBox();
            this.txtResult = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(104, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Number:";
            // 
            // txtNumber
            // 
            this.txtNumber.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtNumber.Location = new System.Drawing.Point(157, 12);
            this.txtNumber.Name = "txtNumber";
            this.txtNumber.Size = new System.Drawing.Size(73, 20);
            this.txtNumber.TabIndex = 1;
            this.txtNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtNumber.TextChanged += new System.EventHandler(this.txtNumber_TextChanged);
            // 
            // txtResult
            // 
            this.txtResult.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtResult.Location = new System.Drawing.Point(125, 38);
            this.txtResult.Name = "txtResult";
            this.txtResult.ReadOnly = true;
            this.txtResult.Size = new System.Drawing.Size(84, 20);
            this.txtResult.TabIndex = 2;
            this.txtResult.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // howto_make_ordinal_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(334, 71);
            this.Controls.Add(this.txtResult);
            this.Controls.Add(this.txtNumber);
            this.Controls.Add(this.label1);
            this.Name = "howto_make_ordinal_Form1";
            this.Text = "howto_make_ordinal";
            this.Load += new System.EventHandler(this.howto_make_ordinal_Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNumber;
        private System.Windows.Forms.TextBox txtResult;
    }
}

