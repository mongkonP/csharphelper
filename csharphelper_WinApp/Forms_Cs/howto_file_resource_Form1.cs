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
     public partial class howto_file_resource_Form1:Form
  { 


        public howto_file_resource_Form1()
        {
            InitializeComponent();
        }

        // Load the file resource.
        private void howto_file_resource_Form1_Load(object sender, EventArgs e)
        {
            txtQuotes.Text = Properties.Resources.Twain;
            txtQuotes.Select(0, 0);
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
            this.txtQuotes = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtQuotes
            // 
            this.txtQuotes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtQuotes.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtQuotes.Location = new System.Drawing.Point(0, 0);
            this.txtQuotes.Multiline = true;
            this.txtQuotes.Name = "txtQuotes";
            this.txtQuotes.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtQuotes.Size = new System.Drawing.Size(284, 197);
            this.txtQuotes.TabIndex = 1;
            // 
            // howto_file_resource_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 197);
            this.Controls.Add(this.txtQuotes);
            this.Name = "howto_file_resource_Form1";
            this.Text = "howto_file_resource";
            this.Load += new System.EventHandler(this.howto_file_resource_Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtQuotes;
    }
}

