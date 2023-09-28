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
     public partial class howto_underscore_case_Form1:Form
  { 


        public howto_underscore_case_Form1()
        {
            InitializeComponent();
        }

        // Convert from TitleCase to underscore_case.
        private void btnConvert_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            bool to_upper = chkUpperCase.Checked;
            bool start_of_word = true;
            foreach (char ch in txtTitleCase.Text)
            {
                if (char.IsUpper(ch))
                    if (!start_of_word) sb.Append("_");

                if (to_upper)
                    sb.Append(ch.ToString().ToUpper());
                else
                    sb.Append(ch.ToString().ToLower());

                start_of_word = char.IsWhiteSpace(ch);
            }
            txtUnderscoreCase.Text = sb.ToString();
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
            this.txtTitleCase = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.txtUnderscoreCase = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnConvert = new System.Windows.Forms.Button();
            this.chkUpperCase = new System.Windows.Forms.CheckBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "TitleCase:";
            // 
            // txtTitleCase
            // 
            this.txtTitleCase.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtTitleCase.Location = new System.Drawing.Point(3, 48);
            this.txtTitleCase.Multiline = true;
            this.txtTitleCase.Name = "txtTitleCase";
            this.txtTitleCase.Size = new System.Drawing.Size(381, 125);
            this.txtTitleCase.TabIndex = 1;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.chkUpperCase, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtTitleCase, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.txtUnderscoreCase, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.btnConvert, 0, 3);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 12);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 6;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(387, 352);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // txtUnderscoreCase
            // 
            this.txtUnderscoreCase.Location = new System.Drawing.Point(3, 224);
            this.txtUnderscoreCase.Multiline = true;
            this.txtUnderscoreCase.Name = "txtUnderscoreCase";
            this.txtUnderscoreCase.Size = new System.Drawing.Size(381, 125);
            this.txtUnderscoreCase.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 206);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "underscore_case:";
            // 
            // btnConvert
            // 
            this.btnConvert.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnConvert.Location = new System.Drawing.Point(156, 179);
            this.btnConvert.Name = "btnConvert";
            this.btnConvert.Size = new System.Drawing.Size(75, 23);
            this.btnConvert.TabIndex = 4;
            this.btnConvert.Text = "Convert";
            this.btnConvert.UseVisualStyleBackColor = true;
            this.btnConvert.Click += new System.EventHandler(this.btnConvert_Click);
            // 
            // chkUpperCase
            // 
            this.chkUpperCase.AutoSize = true;
            this.chkUpperCase.Location = new System.Drawing.Point(3, 3);
            this.chkUpperCase.Name = "chkUpperCase";
            this.chkUpperCase.Size = new System.Drawing.Size(82, 17);
            this.chkUpperCase.TabIndex = 3;
            this.chkUpperCase.Text = "Upper Case";
            this.chkUpperCase.UseVisualStyleBackColor = true;
            // 
            // howto_underscore_case_Form1
            // 
            this.AcceptButton = this.btnConvert;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(411, 376);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "howto_underscore_case_Form1";
            this.Text = "howto_underscore_case";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTitleCase;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TextBox txtUnderscoreCase;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnConvert;
        private System.Windows.Forms.CheckBox chkUpperCase;
    }
}

