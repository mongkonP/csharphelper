using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

 

using howto_url_encode_extension;
namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_url_encode_extension_Form1:Form
  { 


        public howto_url_encode_extension_Form1()
        {
            InitializeComponent();
        }

        private void btnConvert_Click(object sender, EventArgs e)
        {
            txtNbsp.Text = txtString.Text.SpaceToNbsp();
            txtUrlEncode.Text = txtString.Text.UrlEncode();
            txtUrlDecode.Text = txtUrlEncode.Text.UrlDecode();
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
            this.txtUrlDecode = new System.Windows.Forms.TextBox();
            this.Label4 = new System.Windows.Forms.Label();
            this.txtUrlEncode = new System.Windows.Forms.TextBox();
            this.Label3 = new System.Windows.Forms.Label();
            this.txtNbsp = new System.Windows.Forms.TextBox();
            this.Label2 = new System.Windows.Forms.Label();
            this.btnConvert = new System.Windows.Forms.Button();
            this.txtString = new System.Windows.Forms.TextBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtUrlDecode
            // 
            this.txtUrlDecode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtUrlDecode.Location = new System.Drawing.Point(71, 121);
            this.txtUrlDecode.Name = "txtUrlDecode";
            this.txtUrlDecode.Size = new System.Drawing.Size(368, 20);
            this.txtUrlDecode.TabIndex = 26;
            // 
            // Label4
            // 
            this.Label4.AutoSize = true;
            this.Label4.Location = new System.Drawing.Point(7, 121);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(61, 13);
            this.Label4.TabIndex = 25;
            this.Label4.Text = "UrlDecode:";
            // 
            // txtUrlEncode
            // 
            this.txtUrlEncode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtUrlEncode.Location = new System.Drawing.Point(71, 97);
            this.txtUrlEncode.Name = "txtUrlEncode";
            this.txtUrlEncode.Size = new System.Drawing.Size(368, 20);
            this.txtUrlEncode.TabIndex = 24;
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.Location = new System.Drawing.Point(7, 97);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(60, 13);
            this.Label3.TabIndex = 23;
            this.Label3.Text = "UrlEncode:";
            // 
            // txtNbsp
            // 
            this.txtNbsp.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNbsp.Location = new System.Drawing.Point(71, 73);
            this.txtNbsp.Name = "txtNbsp";
            this.txtNbsp.Size = new System.Drawing.Size(368, 20);
            this.txtNbsp.TabIndex = 22;
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Location = new System.Drawing.Point(7, 73);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(33, 13);
            this.Label2.TabIndex = 21;
            this.Label2.Text = "nbsp:";
            // 
            // btnConvert
            // 
            this.btnConvert.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnConvert.Location = new System.Drawing.Point(185, 41);
            this.btnConvert.Name = "btnConvert";
            this.btnConvert.Size = new System.Drawing.Size(75, 23);
            this.btnConvert.TabIndex = 20;
            this.btnConvert.Text = "Convert";
            this.btnConvert.UseVisualStyleBackColor = true;
            this.btnConvert.Click += new System.EventHandler(this.btnConvert_Click);
            // 
            // txtString
            // 
            this.txtString.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtString.Location = new System.Drawing.Point(71, 9);
            this.txtString.Name = "txtString";
            this.txtString.Size = new System.Drawing.Size(368, 20);
            this.txtString.TabIndex = 19;
            this.txtString.Text = "This is ^a^ string <that> contains /special characters.";
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(7, 9);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(37, 13);
            this.Label1.TabIndex = 18;
            this.Label1.Text = "String:";
            // 
            // howto_url_encode_extension_Form1
            // 
            this.AcceptButton = this.btnConvert;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(447, 150);
            this.Controls.Add(this.txtUrlDecode);
            this.Controls.Add(this.Label4);
            this.Controls.Add(this.txtUrlEncode);
            this.Controls.Add(this.Label3);
            this.Controls.Add(this.txtNbsp);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.btnConvert);
            this.Controls.Add(this.txtString);
            this.Controls.Add(this.Label1);
            this.Name = "howto_url_encode_extension_Form1";
            this.Text = "howto_url_encode_extension";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.TextBox txtUrlDecode;
        internal System.Windows.Forms.Label Label4;
        internal System.Windows.Forms.TextBox txtUrlEncode;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.TextBox txtNbsp;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.Button btnConvert;
        internal System.Windows.Forms.TextBox txtString;
        internal System.Windows.Forms.Label Label1;
    }
}

