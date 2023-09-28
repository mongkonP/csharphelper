using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

 

using howto_pick_random_object;
namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_pick_random_object_Form1:Form
  { 


        public howto_pick_random_object_Form1()
        {
            InitializeComponent();
        }

        // Pick a random line from the TextBox.
        private void btnPick_Click(object sender, EventArgs e)
        {
            txtResult.Text = txtNames.Lines.PickRandom();
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
            this.txtNames = new System.Windows.Forms.TextBox();
            this.btnPick = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtResult = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtNames
            // 
            this.txtNames.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.txtNames.Location = new System.Drawing.Point(12, 12);
            this.txtNames.Multiline = true;
            this.txtNames.Name = "txtNames";
            this.txtNames.Size = new System.Drawing.Size(100, 98);
            this.txtNames.TabIndex = 0;
            this.txtNames.Text = "Ann\r\nBob\r\nCindy\r\nDan\r\nEdwina\r\nFrank\r\nGina\r\nHarry\r\nIvy\r\nJack\r\nKlaudia\r\nLeonard\r\nMa" +
                "rcie\r\nNate\r\nOlivia\r\nPaul\r\nQueenie\r\nRussell\r\nSally\r\nTim\r\nUma\r\nVern\r\nWendy\r\nXavier" +
                "\r\nYoko\r\nZack";
            // 
            // btnPick
            // 
            this.btnPick.Location = new System.Drawing.Point(118, 12);
            this.btnPick.Name = "btnPick";
            this.btnPick.Size = new System.Drawing.Size(75, 23);
            this.btnPick.TabIndex = 1;
            this.btnPick.Text = "Pick";
            this.btnPick.UseVisualStyleBackColor = true;
            this.btnPick.Click += new System.EventHandler(this.btnPick_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(199, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Result:";
            // 
            // txtResult
            // 
            this.txtResult.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtResult.Location = new System.Drawing.Point(245, 14);
            this.txtResult.Name = "txtResult";
            this.txtResult.ReadOnly = true;
            this.txtResult.Size = new System.Drawing.Size(68, 20);
            this.txtResult.TabIndex = 3;
            // 
            // howto_pick_random_object_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(325, 122);
            this.Controls.Add(this.txtResult);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnPick);
            this.Controls.Add(this.txtNames);
            this.Name = "howto_pick_random_object_Form1";
            this.Text = "howto_pick_random_object";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtNames;
        private System.Windows.Forms.Button btnPick;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtResult;
    }
}

