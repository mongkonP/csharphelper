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
     public partial class howto_center_form_Form1:Form
  { 


        public howto_center_form_Form1()
        {
            InitializeComponent();
        }

        private void btnCenter_Click(object sender, EventArgs e)
        {
            this.CenterToScreen();
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
            this.btnCenter = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnCenter
            // 
            this.btnCenter.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnCenter.Location = new System.Drawing.Point(105, 44);
            this.btnCenter.Name = "btnCenter";
            this.btnCenter.Size = new System.Drawing.Size(75, 23);
            this.btnCenter.TabIndex = 1;
            this.btnCenter.Text = "Center";
            this.btnCenter.UseVisualStyleBackColor = true;
            this.btnCenter.Click += new System.EventHandler(this.btnCenter_Click);
            // 
            // howto_center_form_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 111);
            this.Controls.Add(this.btnCenter);
            this.Name = "howto_center_form_Form1";
            this.Text = "howto_center_form";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCenter;
    }
}

