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
     public partial class howto_command_line_arguments_Form1:Form
  { 


        public howto_command_line_arguments_Form1()
        {
            InitializeComponent();
        }

        private void howto_command_line_arguments_Form1_Load(object sender, EventArgs e)
        {
            foreach (string arg in Environment.GetCommandLineArgs())
            {
                lstArguments.Items.Add(arg);
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
            this.lstArguments = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // lstArguments
            // 
            this.lstArguments.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lstArguments.FormattingEnabled = true;
            this.lstArguments.HorizontalScrollbar = true;
            this.lstArguments.IntegralHeight = false;
            this.lstArguments.Location = new System.Drawing.Point(12, 12);
            this.lstArguments.Name = "lstArguments";
            this.lstArguments.Size = new System.Drawing.Size(289, 240);
            this.lstArguments.TabIndex = 0;
            // 
            // howto_command_line_arguments_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(313, 264);
            this.Controls.Add(this.lstArguments);
            this.Name = "howto_command_line_arguments_Form1";
            this.Text = "howto_command_line_arguments";
            this.Load += new System.EventHandler(this.howto_command_line_arguments_Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lstArguments;
    }
}

