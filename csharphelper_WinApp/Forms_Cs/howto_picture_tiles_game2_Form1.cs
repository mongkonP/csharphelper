using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Drawing.Drawing2D;

 

using howto_picture_tiles_game2;
namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_picture_tiles_game2_Form1:Form
  { 


        public howto_picture_tiles_game2_Form1()
        {
            InitializeComponent();
        }

        // The current full picture.
        private Bitmap FullPicture = null;

        // The board's background.
        private Bitmap Background = null;

        // The board.
        private Bitmap Board = null;

        // The pieces.
        private List<Piece> Pieces = null;

        // The target size. (Initially easy.)
        private int TargetSize = 100;

        // The number and size of the rows and columns.
        private int NumRows, NumCols, RowHgt, ColWid;

        // The piece the user is moving.
        private Piece MovingPiece = null;
        private Point MovingPoint;

        // True when the game is over.
        private bool GameOver = true;

        // Exit.
        private void mnuFileExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Open a file.
        private void mnuFileOpen_Click(object sender, EventArgs e)
        {
            if (ofdPicture.ShowDialog() == DialogResult.OK)
            {
                LoadPicture(ofdPicture.FileName);
            }
        }

        // Load this file.
        private void LoadPicture(string filename)
        {
            try
            {
                // Load the picture.
                using (Bitmap bm = new Bitmap(ofdPicture.FileName))
                {
                    FullPicture = new Bitmap(bm.Width, bm.Height);
                    using (Graphics gr = Graphics.FromImage(FullPicture))
                    {
                        gr.DrawImage(bm, 0, 0, bm.Width, bm.Height);
                    }
                }

                // Make the Board and background bitmaps.
                Background = new Bitmap(FullPicture.Width, FullPicture.Height);
                Board = new Bitmap(FullPicture.Width, FullPicture.Height);
                picPuzzle.Size = FullPicture.Size;
                picPuzzle.Image = Board;
                this.ClientSize = new Size(
                    picPuzzle.Right + picPuzzle.Left,
                    picPuzzle.Bottom + picPuzzle.Left);

                // Start a new game.
                StartGame();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // Select the level.
        private void mnuOptionsLevel_Click(object sender, EventArgs e)
        {
            // Check and uncheck the items.
            ToolStripMenuItem mnu = sender as ToolStripMenuItem;
            mnuOptionsEasy.Checked = (mnu == mnuOptionsEasy);
            mnuOptionsMedium.Checked = (mnu == mnuOptionsMedium);
            mnuOptionsHard.Checked = (mnu == mnuOptionsHard);

            // Get the target size.
            TargetSize = int.Parse((string)mnu.Tag);

            // Start a new game.
            StartGame();
        }

        // Start a new game.
        private void StartGame()
        {
            if (FullPicture == null) return;
            GameOver = false;

            // Figure out how big the pieces should be.
            NumRows = FullPicture.Height / TargetSize;
            RowHgt = FullPicture.Height / NumRows;
            NumCols = FullPicture.Width / TargetSize;
            ColWid  = FullPicture.Width / NumCols;

            // Make the pieces.
            Random rand = new Random();
            Pieces = new List<Piece>();
            for (int row = 0; row < NumRows; row++)
            {
                int hgt = RowHgt;
                if (row == NumRows - 1) hgt = FullPicture.Height - row * RowHgt;
                for (int col = 0; col < NumCols; col++)
                {
                    int wid = ColWid;
                    if (col == NumCols - 1) wid = FullPicture.Width - col * ColWid;
                    Rectangle rect = new Rectangle(col * ColWid, row * RowHgt, wid, hgt);
                    Piece new_piece = new Piece(FullPicture, rect);

                    // Randomize the initial location.
                    new_piece.CurrentLocation = new Rectangle(
                        rand.Next(0, FullPicture.Width - wid),
                        rand.Next(0, FullPicture.Height - hgt),
                        wid, hgt);

                    // Add to the Pieces collection.
                    Pieces.Add(new_piece);
                }
            }

            // Make the background.
            MakeBackground();

            // Draw the board.
            DrawBoard();
        }

        // Make the whole background image without MovingPiece.
        private void MakeBackground()
        {
            using (Graphics gr = Graphics.FromImage(Background))
            {
                MakeBackgroundOnGraphics(gr);
            }
        }

        // Make the background image without MovingPiece
        // confined to the rectangle rect.
        private void MakeBackground(Rectangle rect)
        {
            using (Graphics gr = Graphics.FromImage(Background))
            {
                gr.SetClip(rect);
                MakeBackgroundOnGraphics(gr);
            }
        }

        // Make the background image without MovingPiece.
        private void MakeBackgroundOnGraphics(Graphics gr)
        {
            // Clear.
            gr.Clear(picPuzzle.BackColor);

            // Draw a grid on the background.
            DrawGrid(gr);

            // Draw the pieces.
            DrawPieces(gr);

            picPuzzle.Visible = true;
            picPuzzle.Refresh();
        }

        // Draw the pieces.
        private void DrawPieces(Graphics gr)
        {
            using (Pen white_pen = new Pen(Color.White, 3))
            {
                using (Pen black_pen = new Pen(Color.Black, 3))
                {
                    foreach (Piece piece in Pieces)
                    {
                        // Don't draw the piece we are moving.
                        if (piece != MovingPiece)
                        {
                            gr.DrawImage(FullPicture,
                                piece.CurrentLocation,
                                piece.HomeLocation,
                                GraphicsUnit.Pixel);
                            if (!GameOver)
                            {
                                if (piece.IsHome())
                                {
                                    // Draw locked pieces with a white border.
                                    gr.DrawRectangle(white_pen, piece.CurrentLocation);
                                }
                                else
                                {
                                    // Draw locked pieces with a black border.
                                    gr.DrawRectangle(black_pen, piece.CurrentLocation);
                                }
                            }
                        }
                    }
                }
            }
        }

        // Draw a grid on the background.
        private void DrawGrid(Graphics gr)
        {
            using (Pen thick_pen = new Pen(Color.DarkGray, 4))
            {
                for (int y = 0; y <= FullPicture.Height; y += RowHgt)
                {
                    gr.DrawLine(thick_pen, 0, y, FullPicture.Width, y);
                }
                gr.DrawLine(thick_pen, 0, FullPicture.Height, FullPicture.Width, FullPicture.Height);

                for (int x = 0; x <= FullPicture.Width; x += ColWid)
                {
                    gr.DrawLine(thick_pen, x, 0, x, FullPicture.Height);
                }
                gr.DrawLine(thick_pen, FullPicture.Width, 0, FullPicture.Width, FullPicture.Height);
            }
        }

        // Fix the background image without MovingPiece.
        private void RemoveMovingPieceFromBackground()
        {
            if (MovingPiece == null) return;

            using (Graphics gr = Graphics.FromImage(Background))
            {
                // Restrict the drawing to MovingPiece's area.
                gr.SetClip(MovingPiece.CurrentLocation);

                // Draw the grid at that position.
                using (SolidBrush bg_brush = new SolidBrush(picPuzzle.BackColor))
                {
                    gr.FillRectangle(bg_brush, MovingPiece.CurrentLocation);
                }

                // Draw a grid on the background.
                DrawGrid(gr);

                // Draw the pieces.
                DrawPieces(gr);
            }

            picPuzzle.Visible = true;
            picPuzzle.Refresh();
        }

        // Draw the board.
        private void DrawBoard()
        {
            using (Graphics gr = Graphics.FromImage(Board))
            {
                // Restore the background.
                gr.DrawImage(Background, 0, 0, Background.Width, Background.Height);

                // Draw MovingPiece.
                if (MovingPiece != null)
                {
                    gr.DrawImage(FullPicture,
                        MovingPiece.CurrentLocation,
                        MovingPiece.HomeLocation,
                        GraphicsUnit.Pixel);

                    using (Pen blue_pen = new Pen(Color.Blue, 4))
                    {
                        gr.DrawRectangle(blue_pen, MovingPiece.CurrentLocation);
                    }
                }
            }

            picPuzzle.Visible = true;
            picPuzzle.Refresh();
        }

        // Start moving a piece.
        private void picPuzzle_MouseDown(object sender, MouseEventArgs e)
        {
            // See which piece contains this point.
            // Skip fixed pieces.
            // Keep the last one because it's on the top.
            MovingPiece = null;
            foreach (Piece piece in Pieces)
            {
                if (!piece.IsHome() && piece.Contains(e.Location))
                    MovingPiece = piece;
            }
            if (MovingPiece == null) return;

            // Save this location.
            MovingPoint = e.Location;

            // Move it to the top of the stack.
            Pieces.Remove(MovingPiece);
            Pieces.Add(MovingPiece);

            // Redraw the area under MovingPiece.
            Rectangle rect = MovingPiece.CurrentLocation;
            rect.Inflate(4, 4);
            MakeBackground(rect);
            DrawBoard();
        }

        // Move the selected piece.
        private void picPuzzle_MouseMove(object sender, MouseEventArgs e)
        {
            if (MovingPiece == null) return;

            // Move the piece.
            int dx = e.X - MovingPoint.X;
            int dy = e.Y - MovingPoint.Y;
            MovingPiece.CurrentLocation.X += dx;
            MovingPiece.CurrentLocation.Y += dy;

            // Save the new mouse location.
            MovingPoint = e.Location;

            // Redraw.
            DrawBoard();
        }

        // Stop moving the piece and see if it is where it belongs.
        private void picPuzzle_MouseUp(object sender, MouseEventArgs e)
        {
            if (MovingPiece == null) return;

            // See if the piece is in its home position.
            if (MovingPiece.SnapToHome())
            {
                // Move the piece to the bottom.
                Pieces.Remove(MovingPiece);
                Pieces.Reverse();
                Pieces.Add(MovingPiece);
                Pieces.Reverse();

                // See if the game is over.
                GameOver = true;
                foreach (Piece piece in Pieces)
                {
                    if (!piece.IsHome())
                    {
                        GameOver = false;
                        break;
                    }
                }
            }

            // Get MovingPiece's location.
            Rectangle rect = MovingPiece.CurrentLocation;
            rect.Inflate(4, 4);

            // Stop moving the piece.
            MovingPiece = null;

            // Redraw the area that was under MovingPiece.
            if (GameOver)
            {
                MakeBackground();
            }
            else
            {
                MakeBackground(rect);
            }
            DrawBoard();
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFileOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuFileExit = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuOptionsEasy = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuOptionsMedium = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuOptionsHard = new System.Windows.Forms.ToolStripMenuItem();
            this.ofdPicture = new System.Windows.Forms.OpenFileDialog();
            this.picPuzzle = new System.Windows.Forms.PictureBox();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picPuzzle)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.optionsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(284, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFileOpen,
            this.toolStripMenuItem1,
            this.mnuFileExit});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // mnuFileOpen
            // 
            this.mnuFileOpen.Name = "mnuFileOpen";
            this.mnuFileOpen.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.mnuFileOpen.Size = new System.Drawing.Size(146, 22);
            this.mnuFileOpen.Text = "&Open";
            this.mnuFileOpen.Click += new System.EventHandler(this.mnuFileOpen_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(143, 6);
            // 
            // mnuFileExit
            // 
            this.mnuFileExit.Name = "mnuFileExit";
            this.mnuFileExit.Size = new System.Drawing.Size(146, 22);
            this.mnuFileExit.Text = "E&xit";
            this.mnuFileExit.Click += new System.EventHandler(this.mnuFileExit_Click);
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuOptionsEasy,
            this.mnuOptionsMedium,
            this.mnuOptionsHard});
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.optionsToolStripMenuItem.Text = "&Options";
            // 
            // mnuOptionsEasy
            // 
            this.mnuOptionsEasy.Checked = true;
            this.mnuOptionsEasy.CheckState = System.Windows.Forms.CheckState.Checked;
            this.mnuOptionsEasy.Name = "mnuOptionsEasy";
            this.mnuOptionsEasy.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this.mnuOptionsEasy.Size = new System.Drawing.Size(152, 22);
            this.mnuOptionsEasy.Tag = "200";
            this.mnuOptionsEasy.Text = "&Easy";
            this.mnuOptionsEasy.Click += new System.EventHandler(this.mnuOptionsLevel_Click);
            // 
            // mnuOptionsMedium
            // 
            this.mnuOptionsMedium.Name = "mnuOptionsMedium";
            this.mnuOptionsMedium.ShortcutKeys = System.Windows.Forms.Keys.F6;
            this.mnuOptionsMedium.Size = new System.Drawing.Size(152, 22);
            this.mnuOptionsMedium.Tag = "100";
            this.mnuOptionsMedium.Text = "&Medium";
            this.mnuOptionsMedium.Click += new System.EventHandler(this.mnuOptionsLevel_Click);
            // 
            // mnuOptionsHard
            // 
            this.mnuOptionsHard.Name = "mnuOptionsHard";
            this.mnuOptionsHard.ShortcutKeys = System.Windows.Forms.Keys.F7;
            this.mnuOptionsHard.Size = new System.Drawing.Size(152, 22);
            this.mnuOptionsHard.Tag = "50";
            this.mnuOptionsHard.Text = "&Hard";
            this.mnuOptionsHard.Click += new System.EventHandler(this.mnuOptionsLevel_Click);
            // 
            // ofdPicture
            // 
            this.ofdPicture.Filter = "Graphics Files|*.jpg;*.gif;*.png|All Files|*.*";
            // 
            // picPuzzle
            // 
            this.picPuzzle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.picPuzzle.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.picPuzzle.Location = new System.Drawing.Point(12, 27);
            this.picPuzzle.Name = "picPuzzle";
            this.picPuzzle.Size = new System.Drawing.Size(52, 52);
            this.picPuzzle.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picPuzzle.TabIndex = 1;
            this.picPuzzle.TabStop = false;
            this.picPuzzle.Visible = false;
            this.picPuzzle.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picPuzzle_MouseMove);
            this.picPuzzle.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picPuzzle_MouseDown);
            this.picPuzzle.MouseUp += new System.Windows.Forms.MouseEventHandler(this.picPuzzle_MouseUp);
            // 
            // howto_picture_tiles_game2_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 264);
            this.Controls.Add(this.picPuzzle);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "howto_picture_tiles_game2_Form1";
            this.Text = "PictureTiles";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picPuzzle)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuFileOpen;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem mnuFileExit;
        private System.Windows.Forms.OpenFileDialog ofdPicture;
        private System.Windows.Forms.PictureBox picPuzzle;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuOptionsEasy;
        private System.Windows.Forms.ToolStripMenuItem mnuOptionsMedium;
        private System.Windows.Forms.ToolStripMenuItem mnuOptionsHard;
    }
}

