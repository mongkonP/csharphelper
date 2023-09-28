using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

 

using howto_pick_several_items;
namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_pick_several_items_Form1:Form
  { 


        public howto_pick_several_items_Form1()
        {
            InitializeComponent();
        }

        // Pick some items.
        private void btnPick_Click(object sender, EventArgs e)
        {
            int num_values = int.Parse(txtNumSelections.Text);
            txtResults.Lines = txtNames.Lines.PickRandom(num_values).ToArray();
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
            this.btnPick = new System.Windows.Forms.Button();
            this.txtNames = new System.Windows.Forms.TextBox();
            this.txtResults = new System.Windows.Forms.TextBox();
            this.txtNumSelections = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(126, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "# Selections:";
            // 
            // btnPick
            // 
            this.btnPick.Location = new System.Drawing.Point(143, 85);
            this.btnPick.Name = "btnPick";
            this.btnPick.Size = new System.Drawing.Size(75, 23);
            this.btnPick.TabIndex = 4;
            this.btnPick.Text = "Pick";
            this.btnPick.UseVisualStyleBackColor = true;
            this.btnPick.Click += new System.EventHandler(this.btnPick_Click);
            // 
            // txtNames
            // 
            this.txtNames.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.txtNames.Location = new System.Drawing.Point(12, 25);
            this.txtNames.Multiline = true;
            this.txtNames.Name = "txtNames";
            this.txtNames.Size = new System.Drawing.Size(100, 130);
            this.txtNames.TabIndex = 3;
            this.txtNames.Text = "Ann\r\nBob\r\nCindy\r\nDan\r\nEdwina\r\nFrank\r\nGina\r\nHarry\r\nIvy\r\nJack\r\nKlaudia\r\nLeonard\r\nMa" +
                "rcie\r\nNate\r\nOlivia\r\nPaul\r\nQueenie\r\nRussell\r\nSally\r\nTim\r\nUma\r\nVern\r\nWendy\r\nXavier" +
                "\r\nYoko\r\nZack";
            // 
            // txtResults
            // 
            this.txtResults.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.txtResults.Location = new System.Drawing.Point(250, 25);
            this.txtResults.Multiline = true;
            this.txtResults.Name = "txtResults";
            this.txtResults.ReadOnly = true;
            this.txtResults.Size = new System.Drawing.Size(100, 130);
            this.txtResults.TabIndex = 6;
            // 
            // txtNumSelections
            // 
            this.txtNumSelections.Location = new System.Drawing.Point(201, 59);
            this.txtNumSelections.Name = "txtNumSelections";
            this.txtNumSelections.Size = new System.Drawing.Size(33, 20);
            this.txtNumSelections.TabIndex = 7;
            this.txtNumSelections.Text = "5";
            this.txtNumSelections.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Names:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(247, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Selections:";
            // 
            // howto_pick_several_items_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(361, 167);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtNumSelections);
            this.Controls.Add(this.txtResults);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnPick);
            this.Controls.Add(this.txtNames);
            this.Name = "howto_pick_several_items_Form1";
            this.Text = "howto_pick_several_items";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnPick;
        private System.Windows.Forms.TextBox txtNames;
        private System.Windows.Forms.TextBox txtResults;
        private System.Windows.Forms.TextBox txtNumSelections;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}

