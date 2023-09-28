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
     public partial class howto_list_timezones_Form1:Form
  { 


        public howto_list_timezones_Form1()
        {
            InitializeComponent();
        }

        // Load the timezone information.
        private void howto_list_timezones_Form1_Load(object sender, EventArgs e)
        {
            foreach (TimeZoneInfo info in TimeZoneInfo.GetSystemTimeZones())
                lstTimezones.Items.Add(info);
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
            this.lstTimezones = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // lstTimezones
            // 
            this.lstTimezones.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lstTimezones.FormattingEnabled = true;
            this.lstTimezones.Location = new System.Drawing.Point(12, 12);
            this.lstTimezones.Name = "lstTimezones";
            this.lstTimezones.Size = new System.Drawing.Size(260, 238);
            this.lstTimezones.TabIndex = 0;
            // 
            // howto_list_timezones_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 264);
            this.Controls.Add(this.lstTimezones);
            this.Name = "howto_list_timezones_Form1";
            this.Text = "howto_list_timezones";
            this.Load += new System.EventHandler(this.howto_list_timezones_Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lstTimezones;
    }
}

