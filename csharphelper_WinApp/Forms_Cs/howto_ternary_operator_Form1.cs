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
     public partial class howto_ternary_operator_Form1:Form
  { 


        public howto_ternary_operator_Form1()
        {
            InitializeComponent();
        }

        // Display a greeting.
        private void howto_ternary_operator_Form1_Load(object sender, EventArgs e)
        {
            lblGreeting.Text = (DateTime.Now.Hour < 12) ? "Good morning" : "Good afternoon";

            // Equivalent without the conditional operator:
            //if (DateTime.Now.Hour < 12)
            //    lblGreeting.Text = "Good morning";
            //else
            //    lblGreeting.Text = "Good afternoon";
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
            this.lblGreeting = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblGreeting
            // 
            this.lblGreeting.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblGreeting.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGreeting.Location = new System.Drawing.Point(0, 0);
            this.lblGreeting.Name = "lblGreeting";
            this.lblGreeting.Size = new System.Drawing.Size(252, 72);
            this.lblGreeting.TabIndex = 0;
            this.lblGreeting.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // howto_ternary_operator_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(252, 72);
            this.Controls.Add(this.lblGreeting);
            this.Name = "howto_ternary_operator_Form1";
            this.Text = "howto_ternary_operator";
            this.Load += new System.EventHandler(this.howto_ternary_operator_Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblGreeting;
    }
}

