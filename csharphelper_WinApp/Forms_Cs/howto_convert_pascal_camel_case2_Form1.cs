using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

 

using howto_convert_pascal_camel_case2;
namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_convert_pascal_camel_case2_Form1:Form
  { 


        public howto_convert_pascal_camel_case2_Form1()
        {
            InitializeComponent();
        }

        // Enter an initial test string.
        private void howto_convert_pascal_camel_case2_Form1_Load(object sender, EventArgs e)
        {
            txtInput.Text = "this is another test string";
        }

        // Display the new string.
        private void txtInput_TextChanged(object sender, EventArgs e)
        {
            txtPascalCase.Text = txtInput.Text.ToPascalCase();
            txtCamelCase.Text = txtInput.Text.ToCamelCase();
            txtSeparateWords.Text = txtCamelCase.Text.ToProperCase();
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
            this.label4 = new System.Windows.Forms.Label();
            this.txtSeparateWords = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtCamelCase = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPascalCase = new System.Windows.Forms.TextBox();
            this.txtInput = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 113);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(87, 13);
            this.label4.TabIndex = 15;
            this.label4.Text = "Separate Words:";
            // 
            // txtSeparateWords
            // 
            this.txtSeparateWords.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSeparateWords.Location = new System.Drawing.Point(105, 110);
            this.txtSeparateWords.Name = "txtSeparateWords";
            this.txtSeparateWords.ReadOnly = true;
            this.txtSeparateWords.Size = new System.Drawing.Size(267, 20);
            this.txtSeparateWords.TabIndex = 14;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 87);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "Camel Case:";
            // 
            // txtCamelCase
            // 
            this.txtCamelCase.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCamelCase.Location = new System.Drawing.Point(105, 84);
            this.txtCamelCase.Name = "txtCamelCase";
            this.txtCamelCase.ReadOnly = true;
            this.txtCamelCase.Size = new System.Drawing.Size(267, 20);
            this.txtCamelCase.TabIndex = 12;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Pascal Case:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "String:";
            // 
            // txtPascalCase
            // 
            this.txtPascalCase.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPascalCase.Location = new System.Drawing.Point(105, 58);
            this.txtPascalCase.Name = "txtPascalCase";
            this.txtPascalCase.ReadOnly = true;
            this.txtPascalCase.Size = new System.Drawing.Size(267, 20);
            this.txtPascalCase.TabIndex = 9;
            // 
            // txtInput
            // 
            this.txtInput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtInput.Location = new System.Drawing.Point(105, 12);
            this.txtInput.Name = "txtInput";
            this.txtInput.Size = new System.Drawing.Size(267, 20);
            this.txtInput.TabIndex = 8;
            this.txtInput.TextChanged += new System.EventHandler(this.txtInput_TextChanged);
            // 
            // howto_convert_pascal_camel_case2_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 141);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtSeparateWords);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtCamelCase);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtPascalCase);
            this.Controls.Add(this.txtInput);
            this.Name = "howto_convert_pascal_camel_case2_Form1";
            this.Text = "howto_convert_pascal_camel_case2";
            this.Load += new System.EventHandler(this.howto_convert_pascal_camel_case2_Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtSeparateWords;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtCamelCase;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPascalCase;
        private System.Windows.Forms.TextBox txtInput;
    }
}

