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
     public partial class howto_position_lower_right_Form1:Form
  { 


        public howto_position_lower_right_Form1()
        {
            InitializeComponent();
        }

        // Position the form in the lower right corner of the working area.
        private void howto_position_lower_right_Form1_Load(object sender, EventArgs e)
        {
            const int margin = 10;
            int x = Screen.PrimaryScreen.WorkingArea.Right - this.Width - margin;
            int y = Screen.PrimaryScreen.WorkingArea.Bottom - this.Height - margin;
            this.Location = new Point(x, y);
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
            this.SuspendLayout();
            // 
            // howto_position_lower_right_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(314, 71);
            this.Name = "howto_position_lower_right_Form1";
            this.Text = "howto_position_lower_right";
            this.Load += new System.EventHandler(this.howto_position_lower_right_Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion
    }
}

