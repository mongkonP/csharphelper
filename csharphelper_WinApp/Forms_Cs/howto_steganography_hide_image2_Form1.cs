using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

 

using howto_steganography_hide_image2;
namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_steganography_hide_image2_Form1:Form
  { 


        public howto_steganography_hide_image2_Form1()
        {
            InitializeComponent();
        }

        // Hide and then recover the image.
        private void btnGo_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            int num_bits = (int)nudHiddenBits.Value;

            // Hide the image.
            picCombined.Image = Stego.HideImage(
                (Bitmap)picVisible.Image,
                (Bitmap)picHidden.Image, num_bits);

            // Recover the hidden image.
            picRecovered.Image = Stego.RecoverImage(
                (Bitmap)picCombined.Image, num_bits);
            Cursor = Cursors.Default;
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
            this.btnGo = new System.Windows.Forms.Button();
            this.nudHiddenBits = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.picVisible = new System.Windows.Forms.PictureBox();
            this.picHidden = new System.Windows.Forms.PictureBox();
            this.picCombined = new System.Windows.Forms.PictureBox();
            this.picRecovered = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.nudHiddenBits)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picVisible)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picHidden)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCombined)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picRecovered)).BeginInit();
            this.SuspendLayout();
            // 
            // btnGo
            // 
            this.btnGo.Location = new System.Drawing.Point(181, 7);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(75, 23);
            this.btnGo.TabIndex = 10;
            this.btnGo.Text = "Go";
            this.btnGo.UseVisualStyleBackColor = true;
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // nudHiddenBits
            // 
            this.nudHiddenBits.Location = new System.Drawing.Point(114, 7);
            this.nudHiddenBits.Maximum = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.nudHiddenBits.Name = "nudHiddenBits";
            this.nudHiddenBits.Size = new System.Drawing.Size(48, 20);
            this.nudHiddenBits.TabIndex = 9;
            this.nudHiddenBits.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Hidden Image Bits:";
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Location = new System.Drawing.Point(12, 36);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(587, 315);
            this.tabControl1.TabIndex = 7;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.picVisible);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(579, 289);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Visible";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.picHidden);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(579, 289);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Hidden";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.picCombined);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(579, 289);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Combined";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.picRecovered);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(579, 289);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Recovered";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // picVisible
            // 
            this.picVisible.Image = Properties.Resources.McCaw;
            this.picVisible.Location = new System.Drawing.Point(3, 3);
            this.picVisible.Name = "picVisible";
            this.picVisible.Size = new System.Drawing.Size(600, 700);
            this.picVisible.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picVisible.TabIndex = 0;
            this.picVisible.TabStop = false;
            // 
            // picHidden
            // 
            this.picHidden.Image = Properties.Resources.DeerCropped;
            this.picHidden.Location = new System.Drawing.Point(3, 3);
            this.picHidden.Name = "picHidden";
            this.picHidden.Size = new System.Drawing.Size(600, 700);
            this.picHidden.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picHidden.TabIndex = 1;
            this.picHidden.TabStop = false;
            // 
            // picCombined
            // 
            this.picCombined.Location = new System.Drawing.Point(3, 3);
            this.picCombined.Name = "picCombined";
            this.picCombined.Size = new System.Drawing.Size(100, 50);
            this.picCombined.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picCombined.TabIndex = 2;
            this.picCombined.TabStop = false;
            // 
            // picRecovered
            // 
            this.picRecovered.Location = new System.Drawing.Point(3, 3);
            this.picRecovered.Name = "picRecovered";
            this.picRecovered.Size = new System.Drawing.Size(100, 50);
            this.picRecovered.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picRecovered.TabIndex = 3;
            this.picRecovered.TabStop = false;
            // 
            // howto_steganography_hide_image2_Form1
            // 
            this.AcceptButton = this.btnGo;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(611, 363);
            this.Controls.Add(this.btnGo);
            this.Controls.Add(this.nudHiddenBits);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tabControl1);
            this.Name = "howto_steganography_hide_image2_Form1";
            this.Text = "howto_steganography_hide_image2";
            ((System.ComponentModel.ISupportInitialize)(this.nudHiddenBits)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picVisible)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picHidden)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCombined)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picRecovered)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnGo;
        private System.Windows.Forms.NumericUpDown nudHiddenBits;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.PictureBox picVisible;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.PictureBox picHidden;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.PictureBox picCombined;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.PictureBox picRecovered;
    }
}

