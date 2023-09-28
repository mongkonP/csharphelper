//#define DRAW_BOXES
//#define RANDOM_FONTS

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Drawing.Drawing2D;

 

using howto_drop_caps;
namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_drop_caps_Form1:Form
  { 


        public howto_drop_caps_Form1()
        {
            InitializeComponent();
        }

        // Obstacles.
        private List<Block> Obstacles;

        // Blocks to flow around obstacles.
        private List<List<Block>> ParagraphBlocks;

        // The initials.
        private List<Block> Initials;

        // The text to draw.
        private string[] Paragraphs =
        {
            "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Phasellus sodales mollis nisi.",
            "Etiam at nulla accumsan, fringilla erat non, luctus lectus. Vestibulum sit amet ullamcorper neque.",
            "Phasellus volutpat consectetur efficitur. In arcu leo, cursus eget lobortis nec, efficitur eu elit.",
            "Nulla viverra ullamcorper diam a tincidunt. Cras tempus tempor ornare.",
            "Curabitur quis lectus lobortis, rutrum dolor viverra, maximus arcu.",
        };

        // Extra space between paragraphs.
        private const float ParagraphSpacing = 20;

        // Define some blocks.
        private void howto_drop_caps_Form1_Load(object sender, EventArgs e)
        {
            // Create a PictureBlock at a fixed position.
            PictureBlock picture_block = new PictureBlock(
                Properties.Resources.essential_algorithms_2e, 250, 70);

            // Add the PictureBlock as an obstacle.
            Obstacles = new List<Block>();
            Obstacles.Add(picture_block);

            // Build the lists of paragraphs and initials.
            ParagraphBlocks = new List<List<Block>>();
            using (Graphics gr = CreateGraphics())
            {
                // Give the initials the same size.
                RectangleF initial_bounds = new RectangleF(0, 0, 64, 64);

                // Break each paragraph into words.
                Initials = new List<Block>();
                Font initial_font = new Font("Times New Roman", 40, FontStyle.Bold);
                for (int i = 0; i < Paragraphs.Length; i++)
                {
                    // Remove the first lettter of the first word.
                    Initials.Add(new TextBlock(Paragraphs[i].Substring(0, 1), initial_font, gr));
                    Paragraphs[i] = Paragraphs[i].Substring(1);
                    Initials[i].Bounds = initial_bounds;

                    // Break the rest of the paragraph into blocks.
                    List<Block> new_blocks = new List<Block>();
                    foreach (string word in Paragraphs[i].Split(' '))
                    {
                        // Make the word's block.
                        new_blocks.Add(new TextBlock(word, RandomFont(), gr));
                    }
                    ParagraphBlocks.Add(new_blocks);
                }

                // Perform the initial flow.
                FlowParagraphBlocks(gr, picWriting.ClientRectangle,
                    Obstacles, new SizeF(64, 64), ParagraphBlocks,
                    ParagraphSpacing);
            }
        }

        // Return a random font.
        private Random Rand = new Random();

#if RANDOM_FONTS
        // Generate very random fonts.
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
#else
        private Font Font1 = new Font("Times New Roman", 14);
        private Font Font2 = new Font("Times New Roman", 18, FontStyle.Bold);

        // Generate sort of normal fonts.
        private Font RandomFont()
        {
            // Allow a small random chance of using the bold font.
            if (Rand.Next(100) < 10) return Font2;
            return Font1;
        }
#endif

        private void picWriting_Resize(object sender, EventArgs e)
        {
            // Reflow the text.
            using (Graphics gr = CreateGraphics())
            {
                FlowParagraphBlocks(gr, picWriting.ClientRectangle,
                    Obstacles, new SizeF(64, 64), ParagraphBlocks,
                    ParagraphSpacing);
            }

            // Redraw.
            picWriting.Refresh();
        }

        // Draw the blocks.
        private void picWriting_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            // Draw obstacles.
            foreach (Block obstacle in Obstacles)
            {
                obstacle.Draw(e.Graphics, Brushes.Red, Brushes.Pink, Pens.Red);
            }

            // Draw initials.
            using (Brush bg_brush = new TextureBrush(Properties.Resources.Butterflies))
            {
                foreach (TextBlock initial in Initials)
                {
                    initial.Draw(e.Graphics, Brushes.Black, bg_brush, Pens.Black);
                }
            }

            // Draw flowed blocks.
            foreach (List<Block> this_paragraphs_blocks in ParagraphBlocks)
            {
                foreach (Block block in this_paragraphs_blocks)
                {
#if DRAW_BOXES
                    block.Draw(e.Graphics, Brushes.Black,
                        Brushes.Transparent, Pens.Red);
#else
                    block.Draw(e.Graphics, Brushes.Black,
                        Brushes.Transparent, Pens.Transparent);
#endif
                }
            }
        }

        // Flow blocks around obstacles.
        private void FlowParagraphBlocks(Graphics gr,
            RectangleF bounds,
            List<Block> fixed_obstacles, SizeF min_initial_size, 
            List<List<Block>> paragraph_blocks,
            float paragraph_spacing)
        {
            // Place objects to be hidden here.
            PointF hidden_point = new PointF(-1, -1);

            // Make a list to hold fixed obstacles and initials.
            List<Block> obstacles = new List<Block>(fixed_obstacles);

            // Start at the top.
            float y = bounds.Y;

            // Repeat until we place all blocks or run out of room.
            for (int paragraph_num = 0;
                paragraph_num < paragraph_blocks.Count;
                paragraph_num++)
            {
                // Position this paragraph's blocks.
                List<Block> this_paragraphs_blocks = paragraph_blocks[paragraph_num];

                // If this paragraph's initial won't fit,
                // move y down so we stop positioning blocks.
                if (y + Initials[paragraph_num].Bounds.Height > bounds.Bottom)
                    y = bounds.Bottom + 1;

                // If we have run out of room, place everything at (-1, -1).
                if (y > bounds.Bottom)
                {
                    // Position the initial and other blocks at (-1, -1).
                    Initials[paragraph_num].Bounds.Location = hidden_point;

                    // Position the text blocks.
                    for (int i = 0; i < this_paragraphs_blocks.Count; i++)
                        this_paragraphs_blocks[i].Bounds.Location = hidden_point;

                    // Go on to the next paragraph.
                    continue;
                }

                // Position the initial.
                Initials[paragraph_num].Bounds.Location = new PointF(bounds.Left, y);
                obstacles.Add(Initials[paragraph_num]);

                // Position the remaining text.
                int first_block = 0;
                while (first_block < this_paragraphs_blocks.Count)
                {
                    // Position a row of blocks.
                    int num_positioned = PositionOneRow(
                        bounds, obstacles, this_paragraphs_blocks,
                        ref first_block, ref y);

                    // See if any fit.
                    if (num_positioned == 0)
                    {
                        // None fit. Move down.
                        MoveDown(bounds, obstacles,
                            this_paragraphs_blocks[first_block], ref y);
                    }

                    // See if we have run out of room.
                    if (y > bounds.Bottom)
                    {
                        // Position the remaining blocks at (-1, -1).
                        for (int i = first_block; i < this_paragraphs_blocks.Count; i++)
                        {
                            this_paragraphs_blocks[i].Bounds.Location = hidden_point;
                        }

                        // Stop positioning the blocks in this
                        // paragraph and go on to the next paragraph.
                        break;
                    }
                }

                // Don't start the next paragraph before the
                // bottom of the current paragraph's initial.
                if ((paragraph_num < paragraph_blocks.Count - 1) && (y < bounds.Bottom))
                {
                    if (y < Initials[paragraph_num].Bounds.Bottom)
                        y = Initials[paragraph_num].Bounds.Bottom;
                }

                // Add some extra space between paragraphs.
                y += paragraph_spacing;
            }
        }

        // Return the maximum number of blocks that will fit
        // on one row starting at the indicated Y coordinate.
        // If we position any blocks, update first_block and y.
        private int PositionOneRow(RectangleF bounds,
            List<Block> obstacles, List<Block> blocks,
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
            List<Block> obstacles, List<Block> blocks,
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

                // See if we stick off the bottom of the bounds.
                if (block.Bounds.Bottom > bounds.Bottom) return false;

                // See if the block intersects with an obstacle.
                RectangleF rect = block.Bounds;
                bool had_hit = true;
                while (had_hit)
                {
                    had_hit = false;
                    foreach (Block obstacle in obstacles)
                    {
                        if (obstacle.IntersectsWith(rect))
                        {
                            had_hit = true;

                            // Move the block to the right.
                            rect.X = obstacle.Bounds.Right;

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
            List<Block> obstacles, Block block, ref float y)
        {
            float min_y = y + block.Bounds.Height;
            RectangleF rect = new RectangleF(
                bounds.X, y, bounds.Width, block.Bounds.Height);
            foreach (Block obstacle in obstacles)
            {
                if (obstacle.IntersectsWith(rect))
                {
                    if (min_y > obstacle.Bounds.Bottom)
                        min_y = obstacle.Bounds.Bottom;
                }
            }

            // Move down at least 10.
            // If min_y == y, then we did not move down.
            // That happens if we could not fit any new
            // blocks but not because of obstacles. That
            // happens when we run out of room.
            if (min_y < y + 10) min_y = y + 10;
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
            this.picWriting.Size = new System.Drawing.Size(560, 537);
            this.picWriting.TabIndex = 2;
            this.picWriting.TabStop = false;
            this.picWriting.Resize += new System.EventHandler(this.picWriting_Resize);
            this.picWriting.Paint += new System.Windows.Forms.PaintEventHandler(this.picWriting_Paint);
            // 
            // howto_drop_caps_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 561);
            this.Controls.Add(this.picWriting);
            this.Name = "howto_drop_caps_Form1";
            this.Text = "howto_drop_caps";
            this.Load += new System.EventHandler(this.howto_drop_caps_Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picWriting)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox picWriting;
    }
}

