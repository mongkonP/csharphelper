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
     public partial class howto_ctrl_a_Form1:Form
  { 


        public howto_ctrl_a_Form1()
        {
            InitializeComponent();
        }

        // Start with nothing selected.
        private void howto_ctrl_a_Form1_Load(object sender, EventArgs e)
        {
            txtCopy.Select(0, 0);
        }

        // On Ctrl+A, select all of the TextBox's text.
        private void CtrlA_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(1))
            {
                TextBox txt = sender as TextBox;
                txt.SelectAll();
                e.Handled = true;
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
            this.txtPaste = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCopy = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtPaste
            // 
            this.txtPaste.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPaste.Location = new System.Drawing.Point(55, 57);
            this.txtPaste.Multiline = true;
            this.txtPaste.Name = "txtPaste";
            this.txtPaste.Size = new System.Drawing.Size(187, 40);
            this.txtPaste.TabIndex = 7;
            this.txtPaste.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CtrlA_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Paste:";
            // 
            // txtCopy
            // 
            this.txtCopy.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCopy.Location = new System.Drawing.Point(55, 11);
            this.txtCopy.Multiline = true;
            this.txtCopy.Name = "txtCopy";
            this.txtCopy.Size = new System.Drawing.Size(187, 40);
            this.txtCopy.TabIndex = 5;
            this.txtCopy.Text = "The quick brown fox jumps over the lazy dog.";
            this.txtCopy.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CtrlA_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Copy:";
            // 
            // howto_ctrl_a_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(254, 111);
            this.Controls.Add(this.txtPaste);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtCopy);
            this.Controls.Add(this.label1);
            this.Name = "howto_ctrl_a_Form1";
            this.Text = "howto_ctrl_a";
            this.Load += new System.EventHandler(this.howto_ctrl_a_Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtPaste;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCopy;
        private System.Windows.Forms.Label label1;
    }
}

