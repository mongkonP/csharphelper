using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

 

using howto_steganography_hide_image;
namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_steganography_hide_image_Form1:Form
  { 


        public howto_steganography_hide_image_Form1()
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
                (Bitmap)picHidden.Image,
                num_bits);

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
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnGo = new System.Windows.Forms.Button();
            this.nudHiddenBits = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.picRecovered = new System.Windows.Forms.PictureBox();
            this.picCombined = new System.Windows.Forms.PictureBox();
            this.picVisible = new System.Windows.Forms.PictureBox();
            this.picHidden = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.nudHiddenBits)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picRecovered)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCombined)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picVisible)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picHidden)).BeginInit();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(479, 48);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(150, 23);
            this.label4.TabIndex = 21;
            this.label4.Text = "Recovered Image";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(323, 48);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(150, 23);
            this.label5.TabIndex = 20;
            this.label5.Text = "Combined Image";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(167, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(150, 23);
            this.label3.TabIndex = 19;
            this.label3.Text = "Image to Hide";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(11, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(150, 23);
            this.label2.TabIndex = 18;
            this.label2.Text = "Cover Image";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnGo
            // 
            this.btnGo.Location = new System.Drawing.Point(180, 11);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(75, 23);
            this.btnGo.TabIndex = 17;
            this.btnGo.Text = "Go";
            this.btnGo.UseVisualStyleBackColor = true;
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // nudHiddenBits
            // 
            this.nudHiddenBits.Location = new System.Drawing.Point(113, 11);
            this.nudHiddenBits.Maximum = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.nudHiddenBits.Name = "nudHiddenBits";
            this.nudHiddenBits.Size = new System.Drawing.Size(48, 20);
            this.nudHiddenBits.TabIndex = 16;
            this.nudHiddenBits.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 13);
            this.label1.TabIndex = 15;
            this.label1.Text = "Hidden Image Bits:";
            // 
            // picRecovered
            // 
            this.picRecovered.Location = new System.Drawing.Point(479, 74);
            this.picRecovered.Name = "picRecovered";
            this.picRecovered.Size = new System.Drawing.Size(150, 175);
            this.picRecovered.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picRecovered.TabIndex = 14;
            this.picRecovered.TabStop = false;
            // 
            // picCombined
            // 
            this.picCombined.Location = new System.Drawing.Point(323, 74);
            this.picCombined.Name = "picCombined";
            this.picCombined.Size = new System.Drawing.Size(150, 175);
            this.picCombined.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picCombined.TabIndex = 13;
            this.picCombined.TabStop = false;
            // 
            // picVisible
            // 
            this.picVisible.Image = Properties.Resources.SmallMcCaw;
            this.picVisible.Location = new System.Drawing.Point(11, 74);
            this.picVisible.Name = "picVisible";
            this.picVisible.Size = new System.Drawing.Size(150, 175);
            this.picVisible.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picVisible.TabIndex = 11;
            this.picVisible.TabStop = false;
            // 
            // picHidden
            // 
            this.picHidden.Image = Properties.Resources.SmallDeer;
            this.picHidden.Location = new System.Drawing.Point(167, 74);
            this.picHidden.Name = "picHidden";
            this.picHidden.Size = new System.Drawing.Size(150, 175);
            this.picHidden.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picHidden.TabIndex = 12;
            this.picHidden.TabStop = false;
            // 
            // howto_steganography_hide_image_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(644, 261);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.picRecovered);
            this.Controls.Add(this.picCombined);
            this.Controls.Add(this.picVisible);
            this.Controls.Add(this.picHidden);
            this.Controls.Add(this.btnGo);
            this.Controls.Add(this.nudHiddenBits);
            this.Controls.Add(this.label1);
            this.Name = "howto_steganography_hide_image_Form1";
            this.Text = "howto_steganography_hide_image";
            ((System.ComponentModel.ISupportInitialize)(this.nudHiddenBits)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picRecovered)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCombined)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picVisible)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picHidden)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox picRecovered;
        private System.Windows.Forms.PictureBox picCombined;
        private System.Windows.Forms.PictureBox picVisible;
        private System.Windows.Forms.PictureBox picHidden;
        private System.Windows.Forms.Button btnGo;
        private System.Windows.Forms.NumericUpDown nudHiddenBits;
        private System.Windows.Forms.Label label1;
    }
}

