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
     public partial class howto_get_forms_screen_Form1:Form
  { 


        public howto_get_forms_screen_Form1()
        {
            InitializeComponent();
        }

        private void howto_get_forms_screen_Form1_Load(object sender, EventArgs e)
        {
            Screen screen = Screen.FromControl(this);
            txtDeviceName.Text = screen.DeviceName;
            txtIsPrimary.Text = screen.Primary.ToString();
            txtWorkingArea.Text = screen.WorkingArea.ToString();
            txtDeviceName.Select(0, 0);
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
            this.txtWorkingArea = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtIsPrimary = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDeviceName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtWorkingArea
            // 
            this.txtWorkingArea.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtWorkingArea.Location = new System.Drawing.Point(93, 66);
            this.txtWorkingArea.Name = "txtWorkingArea";
            this.txtWorkingArea.ReadOnly = true;
            this.txtWorkingArea.Size = new System.Drawing.Size(219, 20);
            this.txtWorkingArea.TabIndex = 11;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 69);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Working Area:";
            // 
            // txtIsPrimary
            // 
            this.txtIsPrimary.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtIsPrimary.Location = new System.Drawing.Point(93, 40);
            this.txtIsPrimary.Name = "txtIsPrimary";
            this.txtIsPrimary.ReadOnly = true;
            this.txtIsPrimary.Size = new System.Drawing.Size(219, 20);
            this.txtIsPrimary.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Is Primary?";
            // 
            // txtDeviceName
            // 
            this.txtDeviceName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDeviceName.Location = new System.Drawing.Point(93, 14);
            this.txtDeviceName.Name = "txtDeviceName";
            this.txtDeviceName.ReadOnly = true;
            this.txtDeviceName.Size = new System.Drawing.Size(219, 20);
            this.txtDeviceName.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Device Name:";
            // 
            // howto_get_forms_screen_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(324, 101);
            this.Controls.Add(this.txtWorkingArea);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtIsPrimary);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtDeviceName);
            this.Controls.Add(this.label1);
            this.Name = "howto_get_forms_screen_Form1";
            this.Text = "howto_get_forms_screen";
            this.Load += new System.EventHandler(this.howto_get_forms_screen_Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtWorkingArea;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtIsPrimary;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDeviceName;
        private System.Windows.Forms.Label label1;
    }
}

