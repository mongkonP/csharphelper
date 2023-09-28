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
     public partial class howto_use_standard_dialogs_Form1:Form
  { 


        public howto_use_standard_dialogs_Form1()
        {
            InitializeComponent();
        }

        // Select the open file.
        private void btnOpenFile_Click(object sender, EventArgs e)
        {
            // Initialize the dialog.
            ofdFile.FileName = txtOpenFile.Text;

            // Display and check result.
            if (ofdFile.ShowDialog() == DialogResult.OK)
            {
                // Take action.
                txtOpenFile.Text = ofdFile.FileName;
            }
        }

        // Select the save file.
        private void btnSaveFile_Click(object sender, EventArgs e)
        {
            // Initialize the dialog.
            sfdFile.FileName = txtSaveFile.Text;

            // Display and check result.
            if (sfdFile.ShowDialog() == DialogResult.OK)
            {
                // Take action.
                txtSaveFile.Text = sfdFile.FileName;
            }
        }

        // Select foreground color.
        private void btnForeColor_Click(object sender, EventArgs e)
        {
            // Initialize.
            cdColor.Color = this.ForeColor;

            // Display and check result.
            if (cdColor.ShowDialog() == DialogResult.OK)
            {
                // Take action.
                this.ForeColor = cdColor.Color;
            }
        }

        // Select background color.
        private void btnBackColor_Click(object sender, EventArgs e)
        {
            // Initialize.
            cdColor.Color = this.BackColor;

            // Display and check result.
            if (cdColor.ShowDialog() == DialogResult.OK)
            {
                // Take action.
                this.BackColor = cdColor.Color;
            }
        }

        // Select the font.
        private void btnFont_Click(object sender, EventArgs e)
        {
            // Initialize.
            fdFont.Font = this.Font;

            // Display and check result.
            if (fdFont.ShowDialog() == DialogResult.OK)
            {
                // Take action.
                this.Font = fdFont.Font;
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtOpenFile = new System.Windows.Forms.TextBox();
            this.txtSaveFile = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnOpenFile = new System.Windows.Forms.Button();
            this.btnSaveFile = new System.Windows.Forms.Button();
            this.btnBackColor = new System.Windows.Forms.Button();
            this.btnForeColor = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnFont = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.sfdFile = new System.Windows.Forms.SaveFileDialog();
            this.ofdFile = new System.Windows.Forms.OpenFileDialog();
            this.fdFont = new System.Windows.Forms.FontDialog();
            this.cdColor = new System.Windows.Forms.ColorDialog();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Open File:";
            // 
            // txtOpenFile
            // 
            this.txtOpenFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtOpenFile.Location = new System.Drawing.Point(72, 15);
            this.txtOpenFile.Name = "txtOpenFile";
            this.txtOpenFile.Size = new System.Drawing.Size(208, 20);
            this.txtOpenFile.TabIndex = 1;
            // 
            // txtSaveFile
            // 
            this.txtSaveFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSaveFile.Location = new System.Drawing.Point(72, 41);
            this.txtSaveFile.Name = "txtSaveFile";
            this.txtSaveFile.Size = new System.Drawing.Size(208, 20);
            this.txtSaveFile.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Save File:";
            // 
            // btnOpenFile
            // 
            this.btnOpenFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOpenFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOpenFile.Location = new System.Drawing.Point(289, 12);
            this.btnOpenFile.Name = "btnOpenFile";
            this.btnOpenFile.Size = new System.Drawing.Size(30, 24);
            this.btnOpenFile.TabIndex = 4;
            this.btnOpenFile.Text = "...";
            this.btnOpenFile.UseVisualStyleBackColor = true;
            this.btnOpenFile.Click += new System.EventHandler(this.btnOpenFile_Click);
            // 
            // btnSaveFile
            // 
            this.btnSaveFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveFile.Location = new System.Drawing.Point(289, 38);
            this.btnSaveFile.Name = "btnSaveFile";
            this.btnSaveFile.Size = new System.Drawing.Size(30, 24);
            this.btnSaveFile.TabIndex = 5;
            this.btnSaveFile.Text = "...";
            this.btnSaveFile.UseVisualStyleBackColor = true;
            this.btnSaveFile.Click += new System.EventHandler(this.btnSaveFile_Click);
            // 
            // btnBackColor
            // 
            this.btnBackColor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBackColor.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBackColor.Location = new System.Drawing.Point(289, 90);
            this.btnBackColor.Name = "btnBackColor";
            this.btnBackColor.Size = new System.Drawing.Size(30, 24);
            this.btnBackColor.TabIndex = 11;
            this.btnBackColor.Text = "...";
            this.btnBackColor.UseVisualStyleBackColor = true;
            this.btnBackColor.Click += new System.EventHandler(this.btnBackColor_Click);
            // 
            // btnForeColor
            // 
            this.btnForeColor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnForeColor.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnForeColor.Location = new System.Drawing.Point(289, 64);
            this.btnForeColor.Name = "btnForeColor";
            this.btnForeColor.Size = new System.Drawing.Size(30, 24);
            this.btnForeColor.TabIndex = 10;
            this.btnForeColor.Text = "...";
            this.btnForeColor.UseVisualStyleBackColor = true;
            this.btnForeColor.Click += new System.EventHandler(this.btnForeColor_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 96);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "BackColor:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 70);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "ForeColor:";
            // 
            // btnFont
            // 
            this.btnFont.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFont.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFont.Location = new System.Drawing.Point(289, 116);
            this.btnFont.Name = "btnFont";
            this.btnFont.Size = new System.Drawing.Size(30, 24);
            this.btnFont.TabIndex = 15;
            this.btnFont.Text = "...";
            this.btnFont.UseVisualStyleBackColor = true;
            this.btnFont.Click += new System.EventHandler(this.btnFont_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 122);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(31, 13);
            this.label5.TabIndex = 14;
            this.label5.Text = "Font:";
            // 
            // sfdFile
            // 
            this.sfdFile.Filter = "Text Files|*.txt|All Files|*.*";
            // 
            // ofdFile
            // 
            this.ofdFile.FileName = "openFileDialog1";
            this.ofdFile.Filter = "Text Files|*.txt|All Files|*.*";
            // 
            // howto_use_standard_dialogs_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(325, 156);
            this.Controls.Add(this.btnFont);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnBackColor);
            this.Controls.Add(this.btnForeColor);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnSaveFile);
            this.Controls.Add(this.btnOpenFile);
            this.Controls.Add(this.txtSaveFile);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtOpenFile);
            this.Controls.Add(this.label1);
            this.Name = "howto_use_standard_dialogs_Form1";
            this.Text = "howto_use_standard_dialogs";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtOpenFile;
        private System.Windows.Forms.TextBox txtSaveFile;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnOpenFile;
        private System.Windows.Forms.Button btnSaveFile;
        private System.Windows.Forms.Button btnBackColor;
        private System.Windows.Forms.Button btnForeColor;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnFont;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.SaveFileDialog sfdFile;
        private System.Windows.Forms.OpenFileDialog ofdFile;
        private System.Windows.Forms.FontDialog fdFont;
        private System.Windows.Forms.ColorDialog cdColor;
    }
}

