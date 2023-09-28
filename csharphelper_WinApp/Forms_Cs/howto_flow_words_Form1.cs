using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Drawing.Drawing2D;

 

using howto_flow_words;
namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_flow_words_Form1:Form
  { 


        public howto_flow_words_Form1()
        {
            InitializeComponent();
        }

        // Obstacles.
        private List<RectangleF> Obstacles;

        // Blocks to flow around obstacles.
        private List<Block> Blocks;

        // The text to draw.
        private string Words = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vestibulum mattis commodo auctor. Ut quis consequat mauris. Ut ut leo urna. Nullam vel lacinia risus. Aenean id malesuada nulla, at tempus.";

        // Define some blocks.
        private void howto_flow_words_Form1_Load(object sender, EventArgs e)
        {
            Obstacles = new List<RectangleF>();
            Obstacles.Add(new RectangleF(0, 0, 64, 64));
            Obstacles.Add(new RectangleF(200, 50, 50, 100));
            Obstacles.Add(new RectangleF(50, 150, 100, 70));
            Obstacles.Add(new RectangleF(300, 200, 100, 64));

            Blocks = new List<Block>();
            Graphics gr = CreateGraphics();
            foreach (string word in Words.Split(' '))
                Blocks.Add(new TextBlock(word, RandomFont(), gr));
        }

        // Return a random font.
        private Random Rand = new Random();
        private Font RandomFont()
        {
            string[] names =
            {
                "Times New Roman",
                "Comic Sans MS",
                "Calibri",
                "Courier New",
                "Script MT Bold",
                "Algerian",
                "Edwardian Script ITC",
                "Headplane",
                "Old English Text MT",
            };
            string name = names.RandomElement();

            const int min_size = 16;
            const int max_size = 25;
            int size = Rand.Next(min_size, max_size);

            FontStyle[] styles =
            {
                FontStyle.Bold,
                FontStyle.Italic,
                FontStyle.Regular,
                FontStyle.Strikeout,
                FontStyle.Underline,
            };
            FontStyle style = styles.RandomElement();

            return new Font(name, size, style);
        }

        private void picWriting_Resize(object sender, EventArgs e)
        {
            picWriting.Refresh();
        }

        // Flow and draw the blocks.
        private void picWriting_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            // Flow.
            FlowBlocks(picWriting.ClientRectangle, Obstacles, Blocks);

            // Draw obstacles.
            foreach (RectangleF obstacle in Obstacles)
            {
                e.Graphics.FillRectangle(Brushes.Pink, obstacle);
                e.Graphics.DrawRectangle(Pens.Red, obstacle);
            }

            // Draw flowed blocks.
            for (int i = 0; i < Blocks.Count; i++)
            {
                Blocks[i].Draw(e.Graphics); 
            }
        }

        // Flow blocks around obstacles.
        private void FlowBlocks(RectangleF bounds,
            List<RectangleF> obstacles, List<Block> blocks)
        {
            float y = bounds.Y;

            // Repeat until we place all blocks or run out of room.
            int first_block = 0;
            while (first_block < blocks.Count)
            {
                // Position a row of blocks.
                int num_positioned = PositionOneRow(
                    bounds, obstacles, blocks,
                    ref first_block, ref y);

                // See if any fit.
                if (num_positioned == 0)
                {
                    // None fit. Move down.
                    MoveDown(bounds, obstacles, blocks[first_block], ref y);
                }

                // See if we have run out of room.
                if (y > bounds.Bottom)
                {
                    // Position the remaining blocks at (-1, -1).
                    for (int i = first_block; i < blocks.Count; i++)
                    {
                        blocks[i].Bounds.X = -1;
                        blocks[i].Bounds.Y = -1;
                    }
                    break;
                }
            }
        }

        // Return the maximum number of blocks that will fit
        // on one row starting at the indicated Y coordinate.
        // If we position any blocks, update first_block and y.
        private int PositionOneRow(RectangleF bounds,
            List<RectangleF> obstacles, List<Block> blocks,
            ref int first_block, ref float y)
        {
            // Loop through the blocks.
            int last_that_fits = blocks.Count - 1;
            for (int i = first_block; i < blocks.Count; i++)
            {
                // See if we can place blocks[first_block]
                // through blocks[i].
                if (!BlocksFit(bounds, obstacles, blocks, first_block, i, y))
                {
                    last_that_fits = i - 1;
                    break;
                }
            }

            // If no blocks fit, return 0.
            if (last_that_fits < first_block) return 0;

            // Position the blocks that fit again.
            BlocksFit(bounds, obstacles, blocks,
                first_block, last_that_fits, y);

            // Find the maximum y coordinate for these blocks.
            for (int i = first_block; i <= last_that_fits; i++)
            {
                if (y < blocks[i].Bounds.Bottom)
                    y = blocks[i].Bounds.Bottom;
            }

            // Update first_block.
            int num_blocks_positioned = last_that_fits - first_block + 1;
            first_block = last_that_fits + 1;

            // Return the number of blocks that fit.
            return num_blocks_positioned;
        }

        // Return true if the indicated blocks will
        // fit starting at the given Y coordinate.
        private bool BlocksFit(RectangleF bounds,
            List<RectangleF> obstacles, List<Block> blocks,
            int first_block, int last_block, float y)
        {
            // Find the maximum top height.
            float top_height = 0;
            for (int i = first_block; i <= last_block; i++)
            {
                if (top_height < blocks[i].TopHeight)
                    top_height = blocks[i].TopHeight;
            }

            // Set the baseline.
            float baseline = y + top_height;

            // Position the blocks.
            float x = bounds.X;
            for (int i = first_block; i <= last_block; i++)
            {
                Block block = blocks[i];
                block.Bounds.X = x;
                x += block.Bounds.Width;
                if (x > bounds.Right) return false;

                block.Bounds.Y = baseline - block.TopHeight;

                // See if the block intersects with an obstacle.
                RectangleF rect = block.Bounds;
                bool had_hit = true;
                while (had_hit)
                {
                    had_hit = false;
                    foreach (RectangleF obstacle in Obstacles)
                    {
                        if (obstacle.IntersectsWith(rect))
                        {
                            had_hit = true;

                            // Move the block to the right.
                            rect.X = obstacle.Right;

                            // See if we are out of bounds.
                            if (rect.Right > bounds.Right) return false;
                        }
                    }
                }

                // Update the block's bounds.
                block.Bounds = rect;
                x = rect.Right;

                // Loop to position the next block.
            }

            // If we get this far, then we have
            // positioned all of the blocks.
            return true;
        }

        // Move down so the block will clear at least one new obstacle.
        private void MoveDown(RectangleF bounds,
            List<RectangleF> obstacles, Block block, ref float y)
        {
            float min_y = y + block.Bounds.Height;
            RectangleF rect = new RectangleF(
                bounds.X, y, bounds.Width, block.Bounds.Height);
            foreach (RectangleF obstacle in obstacles)
            {
                if (obstacle.IntersectsWith(rect))
                {
                    if (min_y > obstacle.Bottom)
                        min_y = obstacle.Bottom;
                }
            }

            y = min_y;
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
            this.picWriting = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picWriting)).BeginInit();
            this.SuspendLayout();
            // 
            // picWriting
            // 
            this.picWriting.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.picWriting.BackColor = System.Drawing.Color.White;
            this.picWriting.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picWriting.Location = new System.Drawing.Point(12, 12);
            this.picWriting.Name = "picWriting";
            this.picWriting.Size = new System.Drawing.Size(460, 337);
            this.picWriting.TabIndex = 2;
            this.picWriting.TabStop = false;
            this.picWriting.Resize += new System.EventHandler(this.picWriting_Resize);
            this.picWriting.Paint += new System.Windows.Forms.PaintEventHandler(this.picWriting_Paint);
            // 
            // howto_flow_words_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 361);
            this.Controls.Add(this.picWriting);
            this.Name = "howto_flow_words_Form1";
            this.Text = "howto_flow_words";
            this.Load += new System.EventHandler(this.howto_flow_words_Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picWriting)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox picWriting;
    }
}

