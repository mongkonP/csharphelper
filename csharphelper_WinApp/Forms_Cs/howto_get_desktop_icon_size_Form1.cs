using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Microsoft.Win32;

 

using howto_get_desktop_icon_size;
namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_get_desktop_icon_size_Form1:Form
  { 


        public howto_get_desktop_icon_size_Form1()
        {
            InitializeComponent();
        }

        // Get the desktop icon size.
        private void btnGetSize_Click(object sender, EventArgs e)
        {
            object size_string = RegistryTools.GetRegistryValue(
                Registry.CurrentUser,
                @"Control Panel\Desktop\WindowMetrics",
                "Shell Icon Size", -1);
            txtSize.Text = size_string.ToString();
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
            this.txtSize = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnGetSize = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtSize
            // 
            this.txtSize.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtSize.Location = new System.Drawing.Point(117, 48);
            this.txtSize.Name = "txtSize";
            this.txtSize.Size = new System.Drawing.Size(100, 20);
            this.txtSize.TabIndex = 5;
            this.txtSize.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(81, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Size:";
            // 
            // btnGetSize
            // 
            this.btnGetSize.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnGetSize.Location = new System.Drawing.Point(130, 10);
            this.btnGetSize.Name = "btnGetSize";
            this.btnGetSize.Size = new System.Drawing.Size(75, 23);
            this.btnGetSize.TabIndex = 3;
            this.btnGetSize.Text = "Get Size";
            this.btnGetSize.UseVisualStyleBackColor = true;
            this.btnGetSize.Click += new System.EventHandler(this.btnGetSize_Click);
            // 
            // howto_get_desktop_icon_size_Form1
            // 
            this.AcceptButton = this.btnGetSize;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(334, 81);
            this.Controls.Add(this.txtSize);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnGetSize);
            this.Name = "howto_get_desktop_icon_size_Form1";
            this.Text = "howto_get_desktop_icon_size";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtSize;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnGetSize;
    }
}

