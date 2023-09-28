using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.IO;
using System.Drawing.Imaging;

// Glyph image at: http://futurama.wikia.com/wiki/Alienese

 

namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_separate_glyphs_Form1:Form
  { 


        public howto_separate_glyphs_Form1()
        {
            InitializeComponent();
        }

        // The image containing the glyphs.
        private Bitmap GlyphsBm = null;

        // The glyph position and dimensions.
        private Rectangle GlyphRect = new Rectangle(0, 0, 60, 60);

        // Initialize.
        private void howto_separate_glyphs_Form1_Load(object sender, EventArgs e)
        {
            KeyPreview = true;
            picGlyphs.SizeMode = PictureBoxSizeMode.Normal;
        }

        // Open a glyph file.
        private void mnuFileOpen_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            Refresh();

            if (ofdFile.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    GlyphsBm = LoadBitmapUnlocked(ofdFile.FileName);
                    picGlyphs.ClientSize = GlyphsBm.Size;
                    picGlyphs.Visible = true;
                    mnuFileSaveGlyph.Enabled = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            Cursor = Cursors.Default;
        }

        // Save a glyph.
        private void mnuFileSaveGlyph_Click(object sender, EventArgs e)
        {
            if (sfdGlyph.ShowDialog() == DialogResult.OK)
            {
                using (Bitmap bm = new Bitmap(GlyphRect.Width, GlyphRect.Height))
                {
                    using (Graphics gr = Graphics.FromImage(bm))
                    {
                        Rectangle dest_rect = new Rectangle(
                            0, 0, GlyphRect.Width, GlyphRect.Height);
                        gr.DrawImage(GlyphsBm, dest_rect, GlyphRect, GraphicsUnit.Pixel);
                    }
                    SaveImage(bm, sfdGlyph.FileName);
                }
            }
        }

        // Close the application.
        private void mnuFileExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        // Let the user select the glyph dimensions.
        private void mnuDataDimensions_Click(object sender, EventArgs e)
        {
            howto_separate_glyphs_DimensionsDialog dlg = new  howto_separate_glyphs_DimensionsDialog();
            dlg.txtDimensions.Text = GlyphRect.Width.ToString() +
                " x " + GlyphRect.Height.ToString();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string[] fields = dlg.txtDimensions.Text.ToLower().Split('x');
                    int width = int.Parse(fields[0]);
                    int height = int.Parse(fields[1]);
                    GlyphRect = new Rectangle(GlyphRect.X, GlyphRect.Y, width, height);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                picGlyphs.Refresh();
            }
        }

        // Draw the glyphs and glyph rectangle.
        private void picGlyphs_Paint(object sender, PaintEventArgs e)
        {
            if (GlyphsBm == null) return;

            e.Graphics.DrawImage(GlyphsBm, 0, 0);
            using (Pen pen = new Pen(Color.Red, 3))
            {
                e.Graphics.DrawRectangle(pen, GlyphRect);
            }
        }

        // Load a bitmap without locking it.
        private Bitmap LoadBitmapUnlocked(string file_name)
        {
            using (Bitmap bm = new Bitmap(file_name))
            {
                return new Bitmap(bm);
            }
        }

        // Save the file with the appropriate format.
        public void SaveImage(Image image, string filename)
        {
            string extension = Path.GetExtension(filename);
            switch (extension.ToLower())
            {
                case ".bmp":
                    image.Save(filename, ImageFormat.Bmp);
                    break;
                case ".exif":
                    image.Save(filename, ImageFormat.Exif);
                    break;
                case ".gif":
                    image.Save(filename, ImageFormat.Gif);
                    break;
                case ".jpg":
                case ".jpeg":
                    image.Save(filename, ImageFormat.Jpeg);
                    break;
                case ".png":
                    image.Save(filename, ImageFormat.Png);
                    break;
                case ".tif":
                case ".tiff":
                    image.Save(filename, ImageFormat.Tiff);
                    break;
                default:
                    throw new NotSupportedException(
                        "Unknown file extension " + extension);
            }
        }

        // Mouse events.
        private bool Dragging = false;
        private Point DragOffset;
        private void picGlyphs_MouseDown(object sender, MouseEventArgs e)
        {
            // See if the mouse is inside the current GlyphRect.
            if (!GlyphRect.Contains(e.Location)) return;

            Dragging = true;
            DragOffset = new Point(
                GlyphRect.X - e.Location.X,
                GlyphRect.Y - e.Location.Y);
        }

        private void picGlyphs_MouseMove(object sender, MouseEventArgs e)
        {
            if (!Dragging) return;
            int x = e.Location.X + DragOffset.X;
            int y = e.Location.Y + DragOffset.Y;
            GlyphRect = new Rectangle(x, y, GlyphRect.Width, GlyphRect.Height);
            picGlyphs.Refresh();
        }

        private void picGlyphs_MouseUp(object sender, MouseEventArgs e)
        {
            Dragging = false;
        }

        // Handle arrow keys.
        private void howto_separate_glyphs_Form1_KeyDown(object sender, KeyEventArgs e)
        {
            int distance = 1;
            if (e.Shift) distance = 5;

            switch (e.KeyCode)
            {
                case Keys.Left:
                    GlyphRect.X -= distance;
                    break;
                case Keys.Right:
                    GlyphRect.X += distance;
                    break;
                case Keys.Up:
                    GlyphRect.Y -= distance;
                    break;
                case Keys.Down:
                    GlyphRect.Y += distance;
                    break;
            }
            picGlyphs.Refresh();
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
            this.mnuFileSaveGlyph = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuFileExit = new System.Windows.Forms.ToolStripMenuItem();
            this.dataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDataDimensions = new System.Windows.Forms.ToolStripMenuItem();
            this.ofdFile = new System.Windows.Forms.OpenFileDialog();
            this.sfdGlyph = new System.Windows.Forms.SaveFileDialog();
            this.picGlyphs = new System.Windows.Forms.PictureBox();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picGlyphs)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.dataToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(484, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFileOpen,
            this.mnuFileSaveGlyph,
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
            this.mnuFileOpen.Size = new System.Drawing.Size(181, 22);
            this.mnuFileOpen.Text = "&Open...";
            this.mnuFileOpen.Click += new System.EventHandler(this.mnuFileOpen_Click);
            // 
            // mnuFileSaveGlyph
            // 
            this.mnuFileSaveGlyph.Enabled = false;
            this.mnuFileSaveGlyph.Name = "mnuFileSaveGlyph";
            this.mnuFileSaveGlyph.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.mnuFileSaveGlyph.Size = new System.Drawing.Size(181, 22);
            this.mnuFileSaveGlyph.Text = "&Save Glyph...";
            this.mnuFileSaveGlyph.Click += new System.EventHandler(this.mnuFileSaveGlyph_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(149, 6);
            // 
            // mnuFileExit
            // 
            this.mnuFileExit.Name = "mnuFileExit";
            this.mnuFileExit.Size = new System.Drawing.Size(152, 22);
            this.mnuFileExit.Text = "E&xit";
            this.mnuFileExit.Click += new System.EventHandler(this.mnuFileExit_Click);
            // 
            // dataToolStripMenuItem
            // 
            this.dataToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuDataDimensions});
            this.dataToolStripMenuItem.Name = "dataToolStripMenuItem";
            this.dataToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.dataToolStripMenuItem.Text = "&Data";
            // 
            // mnuDataDimensions
            // 
            this.mnuDataDimensions.Name = "mnuDataDimensions";
            this.mnuDataDimensions.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D)));
            this.mnuDataDimensions.Size = new System.Drawing.Size(178, 22);
            this.mnuDataDimensions.Text = "&Dimensions";
            this.mnuDataDimensions.Click += new System.EventHandler(this.mnuDataDimensions_Click);
            // 
            // ofdFile
            // 
            this.ofdFile.DefaultExt = "png";
            this.ofdFile.FileName = "openFileDialog1";
            this.ofdFile.Filter = "Image Files|*.bmp;*.jpg;*.gif;*.png;*.tif|All Files|*.*";
            // 
            // sfdGlyph
            // 
            this.sfdGlyph.DefaultExt = "png";
            this.sfdGlyph.Filter = "Image Files|*.bmp;*.jpg;*.gif;*.png;*.tif|All Files|*.*";
            // 
            // picGlyphs
            // 
            this.picGlyphs.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.picGlyphs.Location = new System.Drawing.Point(12, 27);
            this.picGlyphs.Name = "picGlyphs";
            this.picGlyphs.Size = new System.Drawing.Size(100, 100);
            this.picGlyphs.TabIndex = 1;
            this.picGlyphs.TabStop = false;
            this.picGlyphs.Visible = false;
            this.picGlyphs.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picGlyphs_MouseMove);
            this.picGlyphs.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picGlyphs_MouseDown);
            this.picGlyphs.Paint += new System.Windows.Forms.PaintEventHandler(this.picGlyphs_Paint);
            this.picGlyphs.MouseUp += new System.Windows.Forms.MouseEventHandler(this.picGlyphs_MouseUp);
            // 
            // howto_separate_glyphs_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 361);
            this.Controls.Add(this.picGlyphs);
            this.Controls.Add(this.menuStrip1);
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "howto_separate_glyphs_Form1";
            this.Text = "howto_separate_glyphs";
            this.Load += new System.EventHandler(this.howto_separate_glyphs_Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.howto_separate_glyphs_Form1_KeyDown);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picGlyphs)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuFileOpen;
        private System.Windows.Forms.ToolStripMenuItem mnuFileSaveGlyph;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem mnuFileExit;
        private System.Windows.Forms.ToolStripMenuItem dataToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuDataDimensions;
        private System.Windows.Forms.OpenFileDialog ofdFile;
        private System.Windows.Forms.SaveFileDialog sfdGlyph;
        private System.Windows.Forms.PictureBox picGlyphs;
    }
}

