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
     public partial class howto_check_card_deck_Form1:Form
  { 


        public howto_check_card_deck_Form1()
        {
            InitializeComponent();
        }

        // The original image.
        private Bitmap OriginalImage = null;

        // Save the original image.
        private void howto_check_card_deck_Form1_Load(object sender, EventArgs e)
        {
            OriginalImage = picDeck.Image as Bitmap;
        }

        // Draw lines on the deck to show where the cards are.
        private void btnOutline_Click(object sender, EventArgs e)
        {
            int NumSuits = int.Parse(txtNumSuits.Text);
            int NumRanks = int.Parse(txtNumRanks.Text);

            Bitmap bm = new Bitmap(OriginalImage);
            using (Graphics gr = Graphics.FromImage(bm))
            {
                int wid = bm.Width / NumRanks;
                int hgt = bm.Height / NumSuits;
                for (int x = 0; x <= NumRanks; x++)
                    gr.DrawLine(Pens.Blue, x * wid, 0, x * wid, bm.Height);
                for (int y = 0; y <= NumSuits; y++)
                    gr.DrawLine(Pens.Blue, 0, y * hgt, bm.Width, y * hgt);
            }
            picDeck.Image = bm;
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
            this.picDeck = new System.Windows.Forms.PictureBox();
            this.btnOutline = new System.Windows.Forms.Button();
            this.panCards = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.txtNumSuits = new System.Windows.Forms.TextBox();
            this.txtNumRanks = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picDeck)).BeginInit();
            this.panCards.SuspendLayout();
            this.SuspendLayout();
            // 
            // picDeck
            // 
            this.picDeck.Image = Properties.Resources.cards;
            this.picDeck.Location = new System.Drawing.Point(3, 3);
            this.picDeck.Name = "picDeck";
            this.picDeck.Size = new System.Drawing.Size(936, 500);
            this.picDeck.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picDeck.TabIndex = 1;
            this.picDeck.TabStop = false;
            // 
            // btnOutline
            // 
            this.btnOutline.Location = new System.Drawing.Point(311, 12);
            this.btnOutline.Name = "btnOutline";
            this.btnOutline.Size = new System.Drawing.Size(75, 23);
            this.btnOutline.TabIndex = 2;
            this.btnOutline.Text = "Outline";
            this.btnOutline.UseVisualStyleBackColor = true;
            this.btnOutline.Click += new System.EventHandler(this.btnOutline_Click);
            // 
            // panCards
            // 
            this.panCards.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panCards.AutoScroll = true;
            this.panCards.Controls.Add(this.picDeck);
            this.panCards.Location = new System.Drawing.Point(3, 41);
            this.panCards.Name = "panCards";
            this.panCards.Size = new System.Drawing.Size(479, 318);
            this.panCards.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "# Suits:";
            // 
            // txtNumSuits
            // 
            this.txtNumSuits.Location = new System.Drawing.Point(61, 14);
            this.txtNumSuits.Name = "txtNumSuits";
            this.txtNumSuits.Size = new System.Drawing.Size(42, 20);
            this.txtNumSuits.TabIndex = 0;
            this.txtNumSuits.Text = "5";
            this.txtNumSuits.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtNumRanks
            // 
            this.txtNumRanks.Location = new System.Drawing.Point(203, 14);
            this.txtNumRanks.Name = "txtNumRanks";
            this.txtNumRanks.Size = new System.Drawing.Size(42, 20);
            this.txtNumRanks.TabIndex = 1;
            this.txtNumRanks.Text = "13";
            this.txtNumRanks.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(146, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "# Ranks:";
            // 
            // howto_check_card_deck_Form1
            // 
            this.AcceptButton = this.btnOutline;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 361);
            this.Controls.Add(this.txtNumRanks);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtNumSuits);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panCards);
            this.Controls.Add(this.btnOutline);
            this.Name = "howto_check_card_deck_Form1";
            this.Text = "howto_check_card_deck";
            this.Load += new System.EventHandler(this.howto_check_card_deck_Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picDeck)).EndInit();
            this.panCards.ResumeLayout(false);
            this.panCards.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picDeck;
        private System.Windows.Forms.Button btnOutline;
        private System.Windows.Forms.Panel panCards;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNumSuits;
        private System.Windows.Forms.TextBox txtNumRanks;
        private System.Windows.Forms.Label label2;

    }
}

