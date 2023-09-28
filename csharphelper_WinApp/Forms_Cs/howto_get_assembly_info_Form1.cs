using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

 

using howto_get_assembly_info;
namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_get_assembly_info_Form1:Form
  { 


        public howto_get_assembly_info_Form1()
        {
            InitializeComponent();
        }

        private void howto_get_assembly_info_Form1_Load(object sender, EventArgs e)
        {
            // Get the AssemblyInfo class.
            AssemblyInfo info = new AssemblyInfo();

            // Display the values.
            titleTextBox.Text = info.Title;
            descriptionTextBox.Text = info.Description;
            companyTextBox.Text = info.Company;
            productTextBox.Text = info.Product;
            copyrightTextBox.Text = info.Copyright;
            trademarkTextBox.Text = info.Trademark;
            assemblyVersionTextBox.Text = info.AssemblyVersion;
            fileVersionTextBox.Text = info.FileVersion;
            guidTextBox.Text = info.Guid;
            neutralLanguageTextBox.Text = info.NeutralLanguage;
            comVisibleTextBox.Text = info.IsComVisible.ToString();
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
            this.comVisibleTextBox = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.neutralLanguageTextBox = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.guidTextBox = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.fileVersionTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.assemblyVersionTextBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.trademarkTextBox = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.copyrightTextBox = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.productTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.companyTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.descriptionTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.titleTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // comVisibleTextBox
            // 
            this.comVisibleTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.comVisibleTextBox.Location = new System.Drawing.Point(113, 273);
            this.comVisibleTextBox.Name = "comVisibleTextBox";
            this.comVisibleTextBox.ReadOnly = true;
            this.comVisibleTextBox.Size = new System.Drawing.Size(359, 20);
            this.comVisibleTextBox.TabIndex = 87;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(12, 276);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(67, 13);
            this.label11.TabIndex = 86;
            this.label11.Text = "COM Visible:";
            // 
            // neutralLanguageTextBox
            // 
            this.neutralLanguageTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.neutralLanguageTextBox.Location = new System.Drawing.Point(113, 247);
            this.neutralLanguageTextBox.Name = "neutralLanguageTextBox";
            this.neutralLanguageTextBox.ReadOnly = true;
            this.neutralLanguageTextBox.Size = new System.Drawing.Size(359, 20);
            this.neutralLanguageTextBox.TabIndex = 85;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(12, 250);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(95, 13);
            this.label9.TabIndex = 84;
            this.label9.Text = "Neutral Language:";
            // 
            // guidTextBox
            // 
            this.guidTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.guidTextBox.Location = new System.Drawing.Point(113, 221);
            this.guidTextBox.Name = "guidTextBox";
            this.guidTextBox.ReadOnly = true;
            this.guidTextBox.Size = new System.Drawing.Size(359, 20);
            this.guidTextBox.TabIndex = 83;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(12, 224);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(37, 13);
            this.label10.TabIndex = 82;
            this.label10.Text = "GUID:";
            // 
            // fileVersionTextBox
            // 
            this.fileVersionTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.fileVersionTextBox.Location = new System.Drawing.Point(113, 195);
            this.fileVersionTextBox.Name = "fileVersionTextBox";
            this.fileVersionTextBox.ReadOnly = true;
            this.fileVersionTextBox.Size = new System.Drawing.Size(359, 20);
            this.fileVersionTextBox.TabIndex = 81;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 198);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 13);
            this.label5.TabIndex = 80;
            this.label5.Text = "File Version:";
            // 
            // assemblyVersionTextBox
            // 
            this.assemblyVersionTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.assemblyVersionTextBox.Location = new System.Drawing.Point(113, 169);
            this.assemblyVersionTextBox.Name = "assemblyVersionTextBox";
            this.assemblyVersionTextBox.ReadOnly = true;
            this.assemblyVersionTextBox.Size = new System.Drawing.Size(359, 20);
            this.assemblyVersionTextBox.TabIndex = 79;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 172);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(92, 13);
            this.label6.TabIndex = 78;
            this.label6.Text = "Assembly Version:";
            // 
            // trademarkTextBox
            // 
            this.trademarkTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.trademarkTextBox.Location = new System.Drawing.Point(113, 143);
            this.trademarkTextBox.Name = "trademarkTextBox";
            this.trademarkTextBox.ReadOnly = true;
            this.trademarkTextBox.Size = new System.Drawing.Size(359, 20);
            this.trademarkTextBox.TabIndex = 77;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 146);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(61, 13);
            this.label7.TabIndex = 76;
            this.label7.Text = "Trademark:";
            // 
            // copyrightTextBox
            // 
            this.copyrightTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.copyrightTextBox.Location = new System.Drawing.Point(113, 117);
            this.copyrightTextBox.Name = "copyrightTextBox";
            this.copyrightTextBox.ReadOnly = true;
            this.copyrightTextBox.Size = new System.Drawing.Size(359, 20);
            this.copyrightTextBox.TabIndex = 75;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 120);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(54, 13);
            this.label8.TabIndex = 74;
            this.label8.Text = "Copyright:";
            // 
            // productTextBox
            // 
            this.productTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.productTextBox.Location = new System.Drawing.Point(113, 91);
            this.productTextBox.Name = "productTextBox";
            this.productTextBox.ReadOnly = true;
            this.productTextBox.Size = new System.Drawing.Size(359, 20);
            this.productTextBox.TabIndex = 73;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 94);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 13);
            this.label3.TabIndex = 72;
            this.label3.Text = "Product:";
            // 
            // companyTextBox
            // 
            this.companyTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.companyTextBox.Location = new System.Drawing.Point(113, 65);
            this.companyTextBox.Name = "companyTextBox";
            this.companyTextBox.ReadOnly = true;
            this.companyTextBox.Size = new System.Drawing.Size(359, 20);
            this.companyTextBox.TabIndex = 71;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 68);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 13);
            this.label4.TabIndex = 70;
            this.label4.Text = "Company:";
            // 
            // descriptionTextBox
            // 
            this.descriptionTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.descriptionTextBox.Location = new System.Drawing.Point(113, 39);
            this.descriptionTextBox.Name = "descriptionTextBox";
            this.descriptionTextBox.ReadOnly = true;
            this.descriptionTextBox.Size = new System.Drawing.Size(359, 20);
            this.descriptionTextBox.TabIndex = 69;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 68;
            this.label2.Text = "Description:";
            // 
            // titleTextBox
            // 
            this.titleTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.titleTextBox.Location = new System.Drawing.Point(113, 13);
            this.titleTextBox.Name = "titleTextBox";
            this.titleTextBox.ReadOnly = true;
            this.titleTextBox.Size = new System.Drawing.Size(359, 20);
            this.titleTextBox.TabIndex = 67;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 66;
            this.label1.Text = "Title:";
            // 
            // howto_get_assembly_info_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 306);
            this.Controls.Add(this.comVisibleTextBox);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.neutralLanguageTextBox);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.guidTextBox);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.fileVersionTextBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.assemblyVersionTextBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.trademarkTextBox);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.copyrightTextBox);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.productTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.companyTextBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.descriptionTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.titleTextBox);
            this.Controls.Add(this.label1);
            this.Name = "howto_get_assembly_info_Form1";
            this.Text = "howto_get_assembly_info";
            this.Load += new System.EventHandler(this.howto_get_assembly_info_Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox comVisibleTextBox;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox neutralLanguageTextBox;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox guidTextBox;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox fileVersionTextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox assemblyVersionTextBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox trademarkTextBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox copyrightTextBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox productTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox companyTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox descriptionTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox titleTextBox;
        private System.Windows.Forms.Label label1;
    }
}

