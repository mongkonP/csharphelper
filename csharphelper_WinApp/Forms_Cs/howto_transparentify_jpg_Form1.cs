using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

 

namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_transparentify_jpg_Form1:Form
  { 


        public howto_transparentify_jpg_Form1()
        {
            InitializeComponent();
        }
        private const int Offset = 10;
        private Bitmap BmOriginal = null;
        private Bitmap BmMakeTransparent = null;
        private Bitmap BmTransparentified = null;

        private void mnuFileOpen_Click(object sender, EventArgs e)
        {
            if (ofdImage.ShowDialog() == DialogResult.OK)
            {
                BmOriginal = LoadBitmapUnlocked(ofdImage.FileName);
                BmMakeTransparent = new Bitmap(BmOriginal);
                BmTransparentified = new Bitmap(BmOriginal);
                ShowSamples();
                btnExpandTransparency.Enabled = true;
            }
        }

        private void mnuFileSave_Click(object sender, EventArgs e)
        {
            if (sfdImage.ShowDialog() == DialogResult.OK)
            {
                BmTransparentified.Save(sfdImage.FileName, ImageFormat.Png);
            }
        }

        // Display transparent versions.
        private void picOriginal_MouseClick(object sender, MouseEventArgs e)
        {
            int x = e.X - Offset;
            int y = e.Y - Offset;
            Color color = BmOriginal.GetPixel(x, y);
            BmMakeTransparent.MakeTransparent(color);

            int dr = int.Parse(txtDr.Text);
            int dg = int.Parse(txtDg.Text);
            int db = int.Parse(txtDb.Text);
            BmTransparentified = Transparentify(
                BmTransparentified, x, y, dr, dg, db);

            ShowSamples();
        }

        private void ShowSamples()
        {
            Bitmap bm;

            bm = MakeBackground();
            using (Graphics gr = Graphics.FromImage(bm))
            {
                gr.DrawImage(BmOriginal, Offset, Offset);
            }
            picOriginal.Image = bm;

            bm = MakeBackground();
            using (Graphics gr = Graphics.FromImage(bm))
            {
                gr.DrawImage(BmMakeTransparent, Offset, Offset);
            }
            picMakeTransparent.Image = bm;

            bm = MakeBackground();
            using (Graphics gr = Graphics.FromImage(bm))
            {
                gr.DrawImage(BmTransparentified, Offset, Offset);
            }
            picTransparentified.Image = bm;

            picOriginal.Visible = true;
            picMakeTransparent.Visible = true;
            picTransparentified.Visible = true;
        }

        private Bitmap MakeBackground()
        {
            int width = BmOriginal.Width + 2 * Offset;
            int height = BmOriginal.Height + 2 * Offset;
            Bitmap bm = new Bitmap(width, height);
            using (Graphics gr = Graphics.FromImage(bm))
            {
                using (LinearGradientBrush brush =
                    new LinearGradientBrush(new Point(0, 0),
                        new Point(64, 64), Color.Blue, Color.Yellow))
                {
                    gr.FillRectangle(brush, 0, 0, width, height);
                }
            }

            return bm;
        }

        // Make the indicated pixel's color transparent.
        private Bitmap Transparentify(Bitmap bm_input,
            int x, int y, int dr, int dg, int db)
        {
            // Get the target color's components.
            Color target_color = bm_input.GetPixel(x, y);
            byte r = target_color.R;
            byte g = target_color.G;
            byte b = target_color.B;

            // Make a copy of the original bitmap.
            Bitmap bm = new Bitmap(bm_input);

            // Make a stack of points that we need to visit.
            Stack<Point> points = new Stack<Point>();

            // Make an array to keep track of where we've been.
            int width = bm_input.Width;
            int height = bm_input.Height;
            bool[,] added_to_stack = new bool[width, height];

            // Start at the target point.
            points.Push(new Point(x, y));
            added_to_stack[x, y] = true;
            bm.SetPixel(x, y, Color.Transparent);

            // Repeat until the stack is empty.
            while (points.Count > 0)
            {
                // Process the top point.
                Point point = points.Pop();

                // Examine its neighbors.
                for (int i = point.X - 1; i <= point.X + 1; i++)
                {
                    for (int j = point.Y - 1; j <= point.Y + 1; j++)
                    {
                        // If the point (i, j) is outside
                        // of the bitmap, skip it.
                        if ((i < 0) || (i >= width) ||
                            (j < 0) || (j >= height)) continue;

                        // If we have already considred
                        // this point, skip it.
                        if (added_to_stack[i, j]) continue;

                        // Get this point's color.
                        Color color = bm_input.GetPixel(i, j);

                        // See if this point's RGB vlues are with
                        // the allowed ranges.
                        if (Math.Abs(r - color.R) > dr) continue;
                        if (Math.Abs(g - color.G) > dg) continue;
                        if (Math.Abs(b - color.B) > db) continue;

                        // Add the point to the stack.
                        points.Push(new Point(i, j));
                        added_to_stack[i, j] = true;
                        bm.SetPixel(i, j, Color.Transparent);
                    }
                }
            }

            // Return the new bitmap.
            return bm;
        }

        private void mnuFileReset_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Discard changes?",
                "Discard changes?", MessageBoxButtons.YesNo)
                    == DialogResult.Yes)
            {
                BmMakeTransparent = new Bitmap(BmOriginal);
                BmTransparentified = new Bitmap(BmOriginal);
                ShowSamples();
            }
        }

        private void btnExpandTransparency_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;

            float max_dist = float.Parse(txtMaxDist.Text);
            BmTransparentified =
                ExpandTransparency(BmTransparentified, max_dist);
            ShowSamples();

            Cursor = Cursors.Default;
        }

        // Make pixels that are near transparent ones partly transparent.
        private Bitmap ExpandTransparency(Bitmap input_bm, float max_dist)
        {
            Bitmap result_bm = new Bitmap(input_bm);

            float[,] distances =
                GetDistancesToTransparent(input_bm, max_dist);
            
            int width = input_bm.Width;
            int height = input_bm.Height;
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    // If this pixel is transparent, skip it.
                    if (input_bm.GetPixel(x, y).A == 0)
                        continue;

                    // See if this pixel is near a transparent one.
                    float distance = distances[x, y];
                    if (distance > max_dist) continue;
                    float scale = distance / max_dist;

                    Color color = input_bm.GetPixel(x, y);
                    int r = color.R;
                    int g = color.G;
                    int b = color.B;

                    int a = (int)(255 * scale);
                    color = Color.FromArgb(a, r, g, b);
                    result_bm.SetPixel(x, y, color);
                }
            }
            return result_bm;
        }

        // Return an array showing how far each
        // pixel is from a transparent one.
        private float[,] GetDistancesToTransparent(
            Bitmap bm, float max_dist)
        {
            int width = bm.Width;
            int height = bm.Height;
            float[,] distances = new float[width, height];
            for (int x = 0; x < width; x++)
                for (int y = 0; y < height; y++)
                    distances[x, y] = float.PositiveInfinity;

            // Examine pixels.
            int dxmax = (int)max_dist;
            if (dxmax < max_dist) dxmax++;
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    // See if this pixel is transparent.
                    if (bm.GetPixel(x, y).A == 0)
                    {
                        for (int dx = -dxmax; dx <= dxmax; dx++)
                        {
                            int px = x + dx;
                            if ((px < 0) || (px >= width)) continue;
                            for (int dy = -dxmax; dy <= dxmax; dy++)
                            {
                                int py = y + dy;
                                if ((py < 0) || (py >= height)) continue;
                                float dist = (float)Math.Sqrt(dx * dx + dy * dy);
                                if (distances[px, py] > dist)
                                    distances[px, py] = dist;
                            }
                        }
                    }
                }
            }
            return distances;
        }

        // Load a bitmap without locking it.
        private Bitmap LoadBitmapUnlocked(string file_name)
        {
            using (Bitmap bm = new Bitmap(file_name))
            {
                return new Bitmap(bm);
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFileOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFileSave = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuFileReset = new System.Windows.Forms.ToolStripMenuItem();
            this.ofdImage = new System.Windows.Forms.OpenFileDialog();
            this.sfdImage = new System.Windows.Forms.SaveFileDialog();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.picTransparentified = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.picMakeTransparent = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.picOriginal = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDr = new System.Windows.Forms.TextBox();
            this.txtDg = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtMaxDist = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtDb = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnExpandTransparency = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picTransparentified)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picMakeTransparent)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picOriginal)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(715, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFileOpen,
            this.mnuFileSave,
            this.toolStripMenuItem1,
            this.mnuFileReset});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // mnuFileOpen
            // 
            this.mnuFileOpen.Name = "mnuFileOpen";
            this.mnuFileOpen.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.mnuFileOpen.Size = new System.Drawing.Size(155, 22);
            this.mnuFileOpen.Text = "&Open...";
            this.mnuFileOpen.Click += new System.EventHandler(this.mnuFileOpen_Click);
            // 
            // mnuFileSave
            // 
            this.mnuFileSave.Name = "mnuFileSave";
            this.mnuFileSave.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.mnuFileSave.Size = new System.Drawing.Size(155, 22);
            this.mnuFileSave.Text = "&Save...";
            this.mnuFileSave.Click += new System.EventHandler(this.mnuFileSave_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(152, 6);
            // 
            // mnuFileReset
            // 
            this.mnuFileReset.Name = "mnuFileReset";
            this.mnuFileReset.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.R)));
            this.mnuFileReset.Size = new System.Drawing.Size(155, 22);
            this.mnuFileReset.Text = "&Reset...";
            this.mnuFileReset.Click += new System.EventHandler(this.mnuFileReset_Click);
            // 
            // ofdImage
            // 
            this.ofdImage.Filter = "Picture Files|*.bmp;*.jpg;*.gif;*.png;*.tif";
            // 
            // sfdImage
            // 
            this.sfdImage.Filter = "PNG Files|*.png";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.Controls.Add(this.panel3, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label3, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 55);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 19F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(691, 250);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.AutoScroll = true;
            this.panel3.Controls.Add(this.picTransparentified);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(463, 22);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(225, 225);
            this.panel3.TabIndex = 5;
            // 
            // picTransparentified
            // 
            this.picTransparentified.Location = new System.Drawing.Point(0, 0);
            this.picTransparentified.Name = "picTransparentified";
            this.picTransparentified.Size = new System.Drawing.Size(100, 100);
            this.picTransparentified.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picTransparentified.TabIndex = 5;
            this.picTransparentified.TabStop = false;
            this.picTransparentified.Visible = false;
            // 
            // panel2
            // 
            this.panel2.AutoScroll = true;
            this.panel2.Controls.Add(this.picMakeTransparent);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(233, 22);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(224, 225);
            this.panel2.TabIndex = 4;
            // 
            // picMakeTransparent
            // 
            this.picMakeTransparent.Location = new System.Drawing.Point(0, 0);
            this.picMakeTransparent.Name = "picMakeTransparent";
            this.picMakeTransparent.Size = new System.Drawing.Size(100, 100);
            this.picMakeTransparent.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picMakeTransparent.TabIndex = 4;
            this.picMakeTransparent.TabStop = false;
            this.picMakeTransparent.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Original";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(233, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "MakeTransparent";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(463, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Transparentified";
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.picOriginal);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 22);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(224, 225);
            this.panel1.TabIndex = 3;
            // 
            // picOriginal
            // 
            this.picOriginal.Cursor = System.Windows.Forms.Cursors.Cross;
            this.picOriginal.Location = new System.Drawing.Point(0, 0);
            this.picOriginal.Name = "picOriginal";
            this.picOriginal.Size = new System.Drawing.Size(100, 100);
            this.picOriginal.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picOriginal.TabIndex = 3;
            this.picOriginal.TabStop = false;
            this.picOriginal.Visible = false;
            this.picOriginal.MouseClick += new System.Windows.Forms.MouseEventHandler(this.picOriginal_MouseClick);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 32);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(19, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "dr:";
            // 
            // txtDr
            // 
            this.txtDr.Location = new System.Drawing.Point(39, 29);
            this.txtDr.Name = "txtDr";
            this.txtDr.Size = new System.Drawing.Size(40, 20);
            this.txtDr.TabIndex = 3;
            this.txtDr.Text = "15";
            this.txtDr.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtDg
            // 
            this.txtDg.Location = new System.Drawing.Point(125, 29);
            this.txtDg.Name = "txtDg";
            this.txtDg.Size = new System.Drawing.Size(40, 20);
            this.txtDg.TabIndex = 5;
            this.txtDg.Text = "15";
            this.txtDg.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(97, 32);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(22, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "dg:";
            // 
            // txtMaxDist
            // 
            this.txtMaxDist.Location = new System.Drawing.Point(398, 29);
            this.txtMaxDist.Name = "txtMaxDist";
            this.txtMaxDist.Size = new System.Drawing.Size(40, 20);
            this.txtMaxDist.TabIndex = 9;
            this.txtMaxDist.Text = "5";
            this.txtMaxDist.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(341, 32);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(51, 13);
            this.label6.TabIndex = 8;
            this.label6.Text = "Max Dist:";
            // 
            // txtDb
            // 
            this.txtDb.Location = new System.Drawing.Point(211, 29);
            this.txtDb.Name = "txtDb";
            this.txtDb.Size = new System.Drawing.Size(40, 20);
            this.txtDb.TabIndex = 7;
            this.txtDb.Text = "15";
            this.txtDb.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(184, 32);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(22, 13);
            this.label7.TabIndex = 6;
            this.label7.Text = "db:";
            // 
            // btnExpandTransparency
            // 
            this.btnExpandTransparency.Enabled = false;
            this.btnExpandTransparency.Location = new System.Drawing.Point(444, 27);
            this.btnExpandTransparency.Name = "btnExpandTransparency";
            this.btnExpandTransparency.Size = new System.Drawing.Size(140, 23);
            this.btnExpandTransparency.TabIndex = 12;
            this.btnExpandTransparency.Text = "Expand Transparency";
            this.btnExpandTransparency.UseVisualStyleBackColor = true;
            this.btnExpandTransparency.Click += new System.EventHandler(this.btnExpandTransparency_Click);
            // 
            // howto_transparentify_jpg_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(715, 317);
            this.Controls.Add(this.btnExpandTransparency);
            this.Controls.Add(this.txtMaxDist);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtDb);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtDg);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtDr);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "howto_transparentify_jpg_Form1";
            this.Text = "howto_transparentify_jpg";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picTransparentified)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picMakeTransparent)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picOriginal)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuFileOpen;
        private System.Windows.Forms.ToolStripMenuItem mnuFileSave;
        private System.Windows.Forms.OpenFileDialog ofdImage;
        private System.Windows.Forms.SaveFileDialog sfdImage;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.PictureBox picTransparentified;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox picMakeTransparent;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox picOriginal;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtDr;
        private System.Windows.Forms.TextBox txtDg;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtMaxDist;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtDb;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem mnuFileReset;
        private System.Windows.Forms.Button btnExpandTransparency;
    }
}

