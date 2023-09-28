using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

// Card deck from:
// http://www.thehouseofcards.com/img/misc/Deck-72x100x16.gif

 

using howto_playing_cards;
namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_playing_cards_Form1:Form
  { 


        public howto_playing_cards_Form1()
        {
            InitializeComponent();
        }

        // Basic deck information.
        // The 5th suite is for the back, jokers, etc.
        private const int NumSuits = 5;
        private const int NumRanks = 13;
        private int CardWidth, CardHeight;

        // The suits in their order in the file.
        private enum Suits
        {
            Hearts,
            Diamonds,
            Clubs,
            Spades,
            Misc,
        }

        // PictureBoxes holding card images.
        private PictureBox[,] Pics = null;

        // Load the cards.
        private void howto_playing_cards_Form1_Load(object sender, EventArgs e)
        {
            // Load the card images.
            LoadCardImages();

            // Arrange the card PictureBoxes.
            ArrangeCards();
        }

        // Load the card PictureBoxes.
        private void LoadCardImages()
        {
            CardWidth = Properties.Resources.cards.Width / NumRanks;
            CardHeight = Properties.Resources.cards.Height / NumSuits;
            int x0 = 0;
            int y0 = 0;
            int dx = CardWidth;
            int dy = CardHeight;
            Pics = new PictureBox[NumRanks, NumSuits];
            int y = y0;
            for (int suit = 0; suit < NumSuits; suit++)
            {
                int x = x0;
                for (int rank = 0; rank < NumRanks; rank++)
                {
                    Pics[rank, suit] = LoadCard(rank, suit, x, y);
                    x += dx;
                }
                y += dy;
            }
        }

        // Load a single card from the deck.
        private PictureBox LoadCard(int rank, int suit, int x, int y)
        {
            // Get the image.
            PictureBox pic = new PictureBox();
            Bitmap bm = LoadCardImage(rank, suit, x, y);

            // Make the PictureBox.
            pic.Image = bm;
            pic.SizeMode = PictureBoxSizeMode.AutoSize;
            pic.BorderStyle = BorderStyle.Fixed3D;
            pic.Parent = panCards;
            pic.MouseEnter += pic_MouseEnter;
            pic.MouseLeave += pic_MouseLeave;

            // Give the PictureBox a Card object so
            // we can tell what card it is.
            pic.Tag = new Card(rank, suit, bm);

            return pic;
        }

        // Return the image for a card.
        private Bitmap LoadCardImage(int rank, int suit, int x, int y)
        {
            Bitmap bm = new Bitmap(CardWidth, CardHeight);
            using (Graphics gr = Graphics.FromImage(bm))
            {
                Rectangle dest_rect =
                    new Rectangle(0, 0, CardWidth, CardHeight);
                Rectangle src_rect =
                    new Rectangle(x, y, CardWidth, CardHeight);
                gr.DrawImage(Properties.Resources.cards,
                    dest_rect, src_rect, GraphicsUnit.Pixel);
            }

            return bm;
        }

        // Arrange the card PictureBoxes.
        private void ArrangeCards()
        {
            // Display the deck.
            const int margin = 4;
            int y = margin;
            for (int suit = 0; suit < NumSuits; suit++)
            {
                int x = margin;
                for (int rank = 0; rank < NumRanks; rank++)
                {
                    Pics[rank, suit].Location = new Point(x, y);
                    x += Pics[0, 0].Width + margin;
                }
                y += Pics[0, 0].Height + margin;
            }
        }

        // Display the card's information.
        private void pic_MouseEnter(object sender, EventArgs e)
        {
            // Get the card information.
            PictureBox pic = sender as PictureBox;
            Card card = pic.Tag as Card;
            Suits suit = (Suits)card.Suit;
            int rank = card.Rank + 1;
            Text = rank.ToString() + " of " + suit.ToString();
        }

        // Clear the cardf information.
        private void pic_MouseLeave(object sender, EventArgs e)
        {
            Text = "howto_playing_cards";
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
            this.panCards = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // panCards
            // 
            this.panCards.AutoScroll = true;
            this.panCards.BackColor = System.Drawing.Color.LightBlue;
            this.panCards.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panCards.Location = new System.Drawing.Point(0, 0);
            this.panCards.Name = "panCards";
            this.panCards.Size = new System.Drawing.Size(284, 261);
            this.panCards.TabIndex = 0;
            // 
            // howto_playing_cards_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.panCards);
            this.Name = "howto_playing_cards_Form1";
            this.Text = "howto_playing_cards";
            this.Load += new System.EventHandler(this.howto_playing_cards_Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panCards;

    }
}

