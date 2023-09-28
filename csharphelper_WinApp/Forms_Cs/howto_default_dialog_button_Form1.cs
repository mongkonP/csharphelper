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
     public partial class howto_default_dialog_button_Form1:Form
  { 


        public howto_default_dialog_button_Form1()
        {
            InitializeComponent();
        }

        // Display a message box with the first button the default.
        private void btnButton1_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "The first button is the default.",
                "Caption",
                MessageBoxButtons.YesNoCancel,
                MessageBoxIcon.Information,
                MessageBoxDefaultButton.Button1);
            MessageBox.Show("You selected " + result.ToString());
        }

        // Display a message box with the second button the default.
        private void btnButton2_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "The second button is the default.",
                "Caption",
                MessageBoxButtons.YesNoCancel,
                MessageBoxIcon.Information,
                MessageBoxDefaultButton.Button2);
            MessageBox.Show("You selected " + result.ToString());
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
            this.btnButton2 = new System.Windows.Forms.Button();
            this.btnButton1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnButton2
            // 
            this.btnButton2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnButton2.Location = new System.Drawing.Point(194, 37);
            this.btnButton2.Name = "btnButton2";
            this.btnButton2.Size = new System.Drawing.Size(75, 23);
            this.btnButton2.TabIndex = 3;
            this.btnButton2.Text = "Button 2";
            this.btnButton2.UseVisualStyleBackColor = true;
            this.btnButton2.Click += new System.EventHandler(this.btnButton2_Click);
            // 
            // btnButton1
            // 
            this.btnButton1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnButton1.Location = new System.Drawing.Point(76, 37);
            this.btnButton1.Name = "btnButton1";
            this.btnButton1.Size = new System.Drawing.Size(75, 23);
            this.btnButton1.TabIndex = 2;
            this.btnButton1.Text = "Button 1";
            this.btnButton1.UseVisualStyleBackColor = true;
            this.btnButton1.Click += new System.EventHandler(this.btnButton1_Click);
            // 
            // howto_default_dialog_button_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(344, 96);
            this.Controls.Add(this.btnButton2);
            this.Controls.Add(this.btnButton1);
            this.Name = "howto_default_dialog_button_Form1";
            this.Text = "howto_default_dialog_button";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnButton2;
        private System.Windows.Forms.Button btnButton1;
    }
}

