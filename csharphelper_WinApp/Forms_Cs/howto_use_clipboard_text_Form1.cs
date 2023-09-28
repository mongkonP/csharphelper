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
     public partial class howto_use_clipboard_text_Form1:Form
  { 


        public howto_use_clipboard_text_Form1()
        {
            InitializeComponent();
        }

        // Copy text to the clipboard.
        private void btnCopy_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(txtCopy.Text);
        }

        // Paste text from the clipboard.
        private void btnPaste_Click(object sender, EventArgs e)
        {
            txtPaste.Text = Clipboard.GetText();
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
            this.txtCopy = new System.Windows.Forms.TextBox();
            this.btnCopy = new System.Windows.Forms.Button();
            this.btnPaste = new System.Windows.Forms.Button();
            this.txtPaste = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtCopy
            // 
            this.txtCopy.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCopy.Location = new System.Drawing.Point(12, 15);
            this.txtCopy.Name = "txtCopy";
            this.txtCopy.Size = new System.Drawing.Size(239, 20);
            this.txtCopy.TabIndex = 0;
            this.txtCopy.Text = "The quick brown fox jumps over the lazy dog.";
            // 
            // btnCopy
            // 
            this.btnCopy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCopy.Location = new System.Drawing.Point(257, 12);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(75, 23);
            this.btnCopy.TabIndex = 1;
            this.btnCopy.Text = "Copy";
            this.btnCopy.UseVisualStyleBackColor = true;
            this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
            // 
            // btnPaste
            // 
            this.btnPaste.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPaste.Location = new System.Drawing.Point(257, 41);
            this.btnPaste.Name = "btnPaste";
            this.btnPaste.Size = new System.Drawing.Size(75, 23);
            this.btnPaste.TabIndex = 3;
            this.btnPaste.Text = "Paste";
            this.btnPaste.UseVisualStyleBackColor = true;
            this.btnPaste.Click += new System.EventHandler(this.btnPaste_Click);
            // 
            // txtPaste
            // 
            this.txtPaste.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPaste.Location = new System.Drawing.Point(12, 44);
            this.txtPaste.Name = "txtPaste";
            this.txtPaste.Size = new System.Drawing.Size(239, 20);
            this.txtPaste.TabIndex = 2;
            // 
            // howto_use_clipboard_text_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(344, 74);
            this.Controls.Add(this.btnPaste);
            this.Controls.Add(this.txtPaste);
            this.Controls.Add(this.btnCopy);
            this.Controls.Add(this.txtCopy);
            this.Name = "howto_use_clipboard_text_Form1";
            this.Text = "howto_use_clipboard_text";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtCopy;
        private System.Windows.Forms.Button btnCopy;
        private System.Windows.Forms.Button btnPaste;
        private System.Windows.Forms.TextBox txtPaste;
    }
}

