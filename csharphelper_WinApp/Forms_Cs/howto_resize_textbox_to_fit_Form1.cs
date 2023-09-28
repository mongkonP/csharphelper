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
     public partial class howto_resize_textbox_to_fit_Form1:Form
  { 


        public howto_resize_textbox_to_fit_Form1()
        {
            InitializeComponent();
        }

        // Prepare the TextBox.
        private void howto_resize_textbox_to_fit_Form1_Load(object sender, EventArgs e)
        {
            // Register the TextChanged event handler.
            txtContents.TextChanged += txtContents_TextChanged;
            txtContents.Multiline = true;
            txtContents.ScrollBars = ScrollBars.None;

            // Make the TextBox fit its initial text.
            AutoSizeTextBox(txtContents);
        }

        // Make the TextBox fit its new contents.
        private void txtContents_TextChanged(object sender, EventArgs e)
        {
            AutoSizeTextBox(sender as TextBox);
        }

        // Make the TextBox fit its contents.
        private void AutoSizeTextBox(TextBox txt)
        {
            const int x_margin = 0;
            const int y_margin = 2;
            Size size = TextRenderer.MeasureText(txt.Text, txt.Font);
            txt.ClientSize =
                new Size(size.Width + x_margin, size.Height + y_margin);
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
            this.txtContents = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtContents
            // 
            this.txtContents.Location = new System.Drawing.Point(12, 12);
            this.txtContents.Multiline = true;
            this.txtContents.Name = "txtContents";
            this.txtContents.Size = new System.Drawing.Size(171, 37);
            this.txtContents.TabIndex = 2;
            this.txtContents.Text = "Type some text or paste text into the TextBox.";
            // 
            // howto_resize_textbox_to_fit_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(325, 61);
            this.Controls.Add(this.txtContents);
            this.Name = "howto_resize_textbox_to_fit_Form1";
            this.Text = "howto_resize_textbox_to_fit";
            this.Load += new System.EventHandler(this.howto_resize_textbox_to_fit_Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtContents;
    }
}

