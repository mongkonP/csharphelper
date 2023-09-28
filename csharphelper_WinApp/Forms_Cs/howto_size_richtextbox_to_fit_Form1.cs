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
     public partial class howto_size_richtextbox_to_fit_Form1:Form
  { 


        public howto_size_richtextbox_to_fit_Form1()
        {
            InitializeComponent();
        }

        // Don't let the RichTextBox wrap long lines.
        private void howto_size_richtextbox_to_fit_Form1_Load(object sender, EventArgs e)
        {
            rchContents.WordWrap = false;
            rchContents.ScrollBars = RichTextBoxScrollBars.None;
        }

        // Make the RichTextBox fit its contents.
        private void rchContents_ContentsResized(object sender, ContentsResizedEventArgs e)
        {
            const int margin = 5;
            RichTextBox rch = sender as RichTextBox;
            rch.ClientSize = new Size(
                e.NewRectangle.Width + margin,
                e.NewRectangle.Height + margin);
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
            this.rchContents = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // rchContents
            // 
            this.rchContents.Location = new System.Drawing.Point(12, 12);
            this.rchContents.Name = "rchContents";
            this.rchContents.Size = new System.Drawing.Size(227, 40);
            this.rchContents.TabIndex = 1;
            this.rchContents.Text = "";
            this.rchContents.ContentsResized += new System.Windows.Forms.ContentsResizedEventHandler(this.rchContents_ContentsResized);
            // 
            // howto_size_richtextbox_to_fit_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightBlue;
            this.ClientSize = new System.Drawing.Size(334, 111);
            this.Controls.Add(this.rchContents);
            this.Name = "howto_size_richtextbox_to_fit_Form1";
            this.Text = "howto_size_richtextbox_to_fit";
            this.Load += new System.EventHandler(this.howto_size_richtextbox_to_fit_Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox rchContents;
    }
}

