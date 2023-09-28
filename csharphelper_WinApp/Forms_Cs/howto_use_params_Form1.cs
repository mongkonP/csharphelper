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
     public partial class howto_use_params_Form1:Form
  { 


        public howto_use_params_Form1()
        {
            InitializeComponent();
        }

        // Display zero or more values.
        private void ShowValues(params string[] values)
        {
            lstValues.Items.Clear();
            foreach (string value in values)
            {
                lstValues.Items.Add(value);
            }
        }

        private void btn0_Click(object sender, EventArgs e)
        {
            ShowValues();
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            ShowValues("Red", "Green", "Blue");
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            ShowValues("Aardvark", "Bear", "Cantalope", "Dingo", "Eagle");
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
            this.btn0 = new System.Windows.Forms.Button();
            this.btn3 = new System.Windows.Forms.Button();
            this.btn5 = new System.Windows.Forms.Button();
            this.lstValues = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // btn0
            // 
            this.btn0.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btn0.Location = new System.Drawing.Point(11, 12);
            this.btn0.Name = "btn0";
            this.btn0.Size = new System.Drawing.Size(75, 23);
            this.btn0.TabIndex = 0;
            this.btn0.Text = "0 Values";
            this.btn0.UseVisualStyleBackColor = true;
            this.btn0.Click += new System.EventHandler(this.btn0_Click);
            // 
            // btn3
            // 
            this.btn3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btn3.Location = new System.Drawing.Point(92, 12);
            this.btn3.Name = "btn3";
            this.btn3.Size = new System.Drawing.Size(75, 23);
            this.btn3.TabIndex = 1;
            this.btn3.Text = "3 Values";
            this.btn3.UseVisualStyleBackColor = true;
            this.btn3.Click += new System.EventHandler(this.btn3_Click);
            // 
            // btn5
            // 
            this.btn5.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btn5.Location = new System.Drawing.Point(173, 12);
            this.btn5.Name = "btn5";
            this.btn5.Size = new System.Drawing.Size(75, 23);
            this.btn5.TabIndex = 2;
            this.btn5.Text = "5 Values";
            this.btn5.UseVisualStyleBackColor = true;
            this.btn5.Click += new System.EventHandler(this.btn5_Click);
            // 
            // lstValues
            // 
            this.lstValues.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lstValues.FormattingEnabled = true;
            this.lstValues.Location = new System.Drawing.Point(11, 41);
            this.lstValues.Name = "lstValues";
            this.lstValues.Size = new System.Drawing.Size(237, 95);
            this.lstValues.TabIndex = 3;
            // 
            // howto_use_params_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(259, 147);
            this.Controls.Add(this.lstValues);
            this.Controls.Add(this.btn5);
            this.Controls.Add(this.btn3);
            this.Controls.Add(this.btn0);
            this.Name = "howto_use_params_Form1";
            this.Text = "howto_use_params";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn0;
        private System.Windows.Forms.Button btn3;
        private System.Windows.Forms.Button btn5;
        private System.Windows.Forms.ListBox lstValues;
    }
}

