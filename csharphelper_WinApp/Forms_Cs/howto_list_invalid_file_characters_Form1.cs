using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.IO;

 

namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_list_invalid_file_characters_Form1:Form
  { 


        public howto_list_invalid_file_characters_Form1()
        {
            InitializeComponent();
        }

        private void howto_list_invalid_file_characters_Form1_Load(object sender, EventArgs e)
        {
            string txt = "";
            foreach (char ch in Path.GetInvalidFileNameChars())
            {
                if (Char.IsWhiteSpace(ch) || Char.IsControl(ch))
                    txt += "<" + (int)ch + "> ";
                else
                    txt += ch + " ";
            }
            txtInvalidFileNameChars.Text = txt;

            txt = "";
            foreach (char ch in Path.GetInvalidPathChars())
            {
                if (Char.IsWhiteSpace(ch) || Char.IsControl(ch))
                    txt += "<" + (int)ch + "> ";
                else
                    txt += ch + " ";
            }
            txtInvalidPathChars.Text = txt;

            txtInvalidFileNameChars.Select(0, 0);
            txtInvalidPathChars.Select(0, 0);
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtInvalidFileNameChars = new System.Windows.Forms.TextBox();
            this.txtInvalidPathChars = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Invalid in File Names:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 100);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Invalid in Paths:";
            // 
            // txtInvalidFileNameChars
            // 
            this.txtInvalidFileNameChars.Location = new System.Drawing.Point(12, 25);
            this.txtInvalidFileNameChars.Multiline = true;
            this.txtInvalidFileNameChars.Name = "txtInvalidFileNameChars";
            this.txtInvalidFileNameChars.Size = new System.Drawing.Size(320, 61);
            this.txtInvalidFileNameChars.TabIndex = 0;
            // 
            // txtInvalidPathChars
            // 
            this.txtInvalidPathChars.Location = new System.Drawing.Point(12, 116);
            this.txtInvalidPathChars.Multiline = true;
            this.txtInvalidPathChars.Name = "txtInvalidPathChars";
            this.txtInvalidPathChars.Size = new System.Drawing.Size(320, 61);
            this.txtInvalidPathChars.TabIndex = 1;
            // 
            // howto_list_invalid_file_characters_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(344, 190);
            this.Controls.Add(this.txtInvalidPathChars);
            this.Controls.Add(this.txtInvalidFileNameChars);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "howto_list_invalid_file_characters_Form1";
            this.Text = "howto_list_invalid_file_characters";
            this.Load += new System.EventHandler(this.howto_list_invalid_file_characters_Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtInvalidFileNameChars;
        private System.Windows.Forms.TextBox txtInvalidPathChars;
    }
}

