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
using System.IO;

 

using howto_montage;
namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_montage_Form1:Form
  { 


        public howto_montage_Form1()
        {
            InitializeComponent();
        }

        // The loaded images.
        private List<ImageInfo> Images =
            new List<ImageInfo>();

        // Select images to add to the montage.
        // Note that I set the dialog's Multiselect property
        // to True at design time.
        private void mnuFileOpen_Click(object sender, EventArgs e)
        {
            if (ofdImage.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    foreach (string filename in ofdImage.FileNames)
                    {
                        ImageInfo image = new ImageInfo(filename);
                        Images.Add(image);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                picImages.Refresh();
            }
        }

        // Save the result in a file.
        private void mnuFileSaveAs_Click(object sender, EventArgs e)
        {
            if (sfdMontage.ShowDialog() == DialogResult.OK)
            {
                // Make a Bitmap to hold the result.
                using (Bitmap bm = new Bitmap(
                    picImages.ClientSize.Width,
                    picImages.ClientSize.Height))
                {
                    // Draw the pictures.
                    using (Graphics gr = Graphics.FromImage(bm))
                    {
                        DrawPictures(gr, false);
                    }

                    // Save the file.
                    try
                    {
                        SaveImage(bm, sfdMontage.FileName);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
        }

        // Redraw the images.
        private void picImages_Paint(object sender, PaintEventArgs e)
        {
            DrawPictures(e.Graphics, true);
        }

        // Draw the pictures.
        private void DrawPictures(Graphics gr, bool with_border)
        {
            gr.InterpolationMode = InterpolationMode.High;
            gr.Clear(picImages.BackColor);
            foreach (ImageInfo info in Images)
                info.Draw(gr, with_border);
        }

        private void mnuFileExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        // The type if drag in progress.
        private ImageInfo.HitTypes DragType = ImageInfo.HitTypes.None;

        // Variables to remember what the mouse is over.
        private ImageInfo MouseImage = null;
        private ImageInfo.HitTypes MouseHitType = ImageInfo.HitTypes.None;

        // The position where a drag started.
        private Point StartPoint;
        private Rectangle StartRect;

        // Return the image under the mouse and the hit type.
        private void FindImageAt(Point point, out ImageInfo image,
            out ImageInfo.HitTypes hit_type)
        {
            // See if we hit an image.
            for (int i = Images.Count - 1; i >= 0; i--)
            {
                hit_type = Images[i].HitType(point);
                if (hit_type != ImageInfo.HitTypes.None)
                {
                    image = Images[i];
                    return;
                }
            }

            image = null;
            hit_type = ImageInfo.HitTypes.None;
        }

        // Display an appropriate mouse pointer.
        private void picImages_MouseMove(object sender, MouseEventArgs e)
        {
            // See if a drag is in progress.
            if (DragType == ImageInfo.HitTypes.None)
            {
                // No drag is in progress. Set the appropriate cursor.
                SetMouseCursor(e.Location);
            }
            else
            {
                if (DragType == ImageInfo.HitTypes.Body)
                {
                    // Just move it.
                    int dx = e.X - StartPoint.X;
                    int dy = e.Y - StartPoint.Y;
                    MouseImage.DestRect.X = StartRect.X + dx;
                    MouseImage.DestRect.Y = StartRect.Y + dy;
                }
                else
                {
                    // Get the desired new width and height.
                    int new_wid, new_hgt;
                    if ((DragType == ImageInfo.HitTypes.NwCorner) ||
                        (DragType == ImageInfo.HitTypes.SwCorner))
                        new_wid = StartRect.Right - e.X;
                    else
                        new_wid = e.X - StartRect.Left;

                    if ((DragType == ImageInfo.HitTypes.NwCorner) ||
                        (DragType == ImageInfo.HitTypes.NeCorner))
                        new_hgt = StartRect.Bottom - e.Y;
                    else
                        new_hgt = e.Y - StartRect.Top;

                    // Fix the aspect ratio.
                    if (new_hgt != 0)
                    {
                        float orig_aspect =
                            MouseImage.SourceRect.Width /
                            (float)MouseImage.SourceRect.Height;
                        float new_aspect = new_wid / (float)new_hgt;

                        if (new_aspect > orig_aspect)
                        {
                            // Too short and wide. Make taller.
                            new_hgt = (int)(new_wid / orig_aspect);
                        }
                        else if (new_aspect < orig_aspect)
                        {
                            // Too tall and thin. Make wider.
                            new_wid = (int)(new_hgt * orig_aspect);
                        }
                    }

                    // Update the destination rectangle.
                    int right = MouseImage.DestRect.Right;
                    int bottom = MouseImage.DestRect.Bottom;
                    if ((DragType == ImageInfo.HitTypes.NwCorner) ||
                        (DragType == ImageInfo.HitTypes.SwCorner))
                        MouseImage.DestRect.X = right - new_wid;
                    if ((DragType == ImageInfo.HitTypes.NwCorner) ||
                        (DragType == ImageInfo.HitTypes.NeCorner))
                        MouseImage.DestRect.Y = bottom - new_hgt;
                    MouseImage.DestRect.Width = new_wid;
                    MouseImage.DestRect.Height = new_hgt;
                }

                // Redraw.
                picImages.Refresh();
            }
        }

        // Set the correct mouse cursor.
        private void SetMouseCursor(Point point)
        {
            // See if the mouse is over an image.
            FindImageAt(point, out MouseImage, out MouseHitType);

            switch (MouseHitType)
            {
                case ImageInfo.HitTypes.None:
                    picImages.Cursor = Cursors.Default;
                    break;
                case ImageInfo.HitTypes.Body:
                    picImages.Cursor = Cursors.SizeAll;
                    break;
                case ImageInfo.HitTypes.NwCorner:
                case ImageInfo.HitTypes.SeCorner:
                    picImages.Cursor = Cursors.SizeNWSE;
                    break;
                case ImageInfo.HitTypes.NeCorner:
                case ImageInfo.HitTypes.SwCorner:
                    picImages.Cursor = Cursors.SizeNESW;
                    break;
            }
        }

        // Start dragging a corner or an image.
        private void picImages_MouseDown(object sender, MouseEventArgs e)
        {
            // If we're not over anything, do nothing.
            if (MouseHitType == ImageInfo.HitTypes.None) return;

            // Bring the image to the top.
            Images.Remove(MouseImage);
            Images.Add(MouseImage);
            picImages.Refresh();

            // Save the location and drag type.
            StartPoint = e.Location;
            StartRect = MouseImage.DestRect;
            DragType = MouseHitType;
        }

        // Stop dragging.
        private void picImages_MouseUp(object sender, MouseEventArgs e)
        {
            DragType = ImageInfo.HitTypes.None;
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

        // Remove all images.
        private void mnuFileNew_Click(object sender, EventArgs e)
        {
            Images = new List<ImageInfo>();
            picImages.Refresh();
        }

        // Scale all images.
        private void mnuScale_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem mnu = sender as ToolStripMenuItem;
            float scale = float.Parse(mnu.Tag.ToString());

            foreach (ImageInfo info in Images)
            {
                info.DestRect = new Rectangle(
                    info.DestRect.X,
                    info.DestRect.Y,
                    (int)(info.SourceRect.Width * scale),
                    (int)(info.SourceRect.Height * scale));
            }
            picImages.Refresh();
        }

        // Let the user set the PictureBox's background color.
        private void mnuColorBackground_Click(object sender, EventArgs e)
        {
            cdBackground.Color = picImages.BackColor;
            if (cdBackground.ShowDialog() == DialogResult.OK)
            {
                picImages.BackColor = cdBackground.Color;
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
            this.mnuFileNew = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFileOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFileSaveAs = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuFileExit = new System.Windows.Forms.ToolStripMenuItem();
            this.scaleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuScale1_2 = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuScale1_3 = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuScale1_4 = new System.Windows.Forms.ToolStripMenuItem();
            this.sfdMontage = new System.Windows.Forms.SaveFileDialog();
            this.ofdImage = new System.Windows.Forms.OpenFileDialog();
            this.picImages = new System.Windows.Forms.PictureBox();
            this.mnuScale1_1 = new System.Windows.Forms.ToolStripMenuItem();
            this.colorsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuColorBackground = new System.Windows.Forms.ToolStripMenuItem();
            this.cdBackground = new System.Windows.Forms.ColorDialog();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picImages)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.scaleToolStripMenuItem,
            this.colorsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(584, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFileNew,
            this.mnuFileOpen,
            this.mnuFileSaveAs,
            this.toolStripMenuItem1,
            this.mnuFileExit});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // mnuFileNew
            // 
            this.mnuFileNew.Name = "mnuFileNew";
            this.mnuFileNew.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.mnuFileNew.Size = new System.Drawing.Size(212, 22);
            this.mnuFileNew.Text = "&New";
            this.mnuFileNew.Click += new System.EventHandler(this.mnuFileNew_Click);
            // 
            // mnuFileOpen
            // 
            this.mnuFileOpen.Name = "mnuFileOpen";
            this.mnuFileOpen.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.mnuFileOpen.Size = new System.Drawing.Size(212, 22);
            this.mnuFileOpen.Text = "&Open Image File...";
            this.mnuFileOpen.Click += new System.EventHandler(this.mnuFileOpen_Click);
            // 
            // mnuFileSaveAs
            // 
            this.mnuFileSaveAs.Name = "mnuFileSaveAs";
            this.mnuFileSaveAs.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.mnuFileSaveAs.Size = new System.Drawing.Size(212, 22);
            this.mnuFileSaveAs.Text = "&Save As...";
            this.mnuFileSaveAs.Click += new System.EventHandler(this.mnuFileSaveAs_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(209, 6);
            // 
            // mnuFileExit
            // 
            this.mnuFileExit.Name = "mnuFileExit";
            this.mnuFileExit.Size = new System.Drawing.Size(212, 22);
            this.mnuFileExit.Text = "E&xit";
            this.mnuFileExit.Click += new System.EventHandler(this.mnuFileExit_Click);
            // 
            // scaleToolStripMenuItem
            // 
            this.scaleToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuScale1_1,
            this.mnuScale1_2,
            this.mnuScale1_3,
            this.mnuScale1_4});
            this.scaleToolStripMenuItem.Name = "scaleToolStripMenuItem";
            this.scaleToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
            this.scaleToolStripMenuItem.Text = "&Scale";
            // 
            // mnuScale1_2
            // 
            this.mnuScale1_2.Name = "mnuScale1_2";
            this.mnuScale1_2.Size = new System.Drawing.Size(152, 22);
            this.mnuScale1_2.Tag = "0.5";
            this.mnuScale1_2.Text = "x 1/&2";
            this.mnuScale1_2.Click += new System.EventHandler(this.mnuScale_Click);
            // 
            // mnuScale1_3
            // 
            this.mnuScale1_3.Name = "mnuScale1_3";
            this.mnuScale1_3.Size = new System.Drawing.Size(152, 22);
            this.mnuScale1_3.Tag = "0.33";
            this.mnuScale1_3.Text = "x 1/&3";
            this.mnuScale1_3.Click += new System.EventHandler(this.mnuScale_Click);
            // 
            // mnuScale1_4
            // 
            this.mnuScale1_4.Name = "mnuScale1_4";
            this.mnuScale1_4.Size = new System.Drawing.Size(152, 22);
            this.mnuScale1_4.Tag = "0.25";
            this.mnuScale1_4.Text = "x 1/&4";
            this.mnuScale1_4.Click += new System.EventHandler(this.mnuScale_Click);
            // 
            // sfdMontage
            // 
            this.sfdMontage.DefaultExt = "png";
            this.sfdMontage.Filter = "Image files|*.bmp;*.jpg;*.gif;*.png;*.tif|All files|*.*";
            // 
            // ofdImage
            // 
            this.ofdImage.Filter = "Image files|*.bmp;*.jpg;*.gif;*.png;*.tif|All files|*.*";
            this.ofdImage.Multiselect = true;
            // 
            // picImages
            // 
            this.picImages.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.picImages.BackColor = System.Drawing.Color.White;
            this.picImages.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.picImages.Location = new System.Drawing.Point(12, 27);
            this.picImages.Name = "picImages";
            this.picImages.Size = new System.Drawing.Size(560, 422);
            this.picImages.TabIndex = 1;
            this.picImages.TabStop = false;
            this.picImages.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picImages_MouseMove);
            this.picImages.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picImages_MouseDown);
            this.picImages.Paint += new System.Windows.Forms.PaintEventHandler(this.picImages_Paint);
            this.picImages.MouseUp += new System.Windows.Forms.MouseEventHandler(this.picImages_MouseUp);
            // 
            // mnuScale1_1
            // 
            this.mnuScale1_1.Name = "mnuScale1_1";
            this.mnuScale1_1.Size = new System.Drawing.Size(152, 22);
            this.mnuScale1_1.Tag = "1";
            this.mnuScale1_1.Text = "x &1";
            this.mnuScale1_1.Click += new System.EventHandler(this.mnuScale_Click);
            // 
            // colorsToolStripMenuItem
            // 
            this.colorsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuColorBackground});
            this.colorsToolStripMenuItem.Name = "colorsToolStripMenuItem";
            this.colorsToolStripMenuItem.Size = new System.Drawing.Size(53, 20);
            this.colorsToolStripMenuItem.Text = "&Colors";
            // 
            // mnuColorBackground
            // 
            this.mnuColorBackground.Name = "mnuColorBackground";
            this.mnuColorBackground.Size = new System.Drawing.Size(170, 22);
            this.mnuColorBackground.Text = "&Background Color";
            this.mnuColorBackground.Click += new System.EventHandler(this.mnuColorBackground_Click);
            // 
            // cdBackground
            // 
            this.cdBackground.Color = System.Drawing.Color.White;
            // 
            // howto_montage_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 461);
            this.Controls.Add(this.picImages);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "howto_montage_Form1";
            this.Text = "howto_montage";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picImages)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuFileOpen;
        private System.Windows.Forms.ToolStripMenuItem mnuFileSaveAs;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem mnuFileExit;
        private System.Windows.Forms.SaveFileDialog sfdMontage;
        private System.Windows.Forms.OpenFileDialog ofdImage;
        private System.Windows.Forms.PictureBox picImages;
        private System.Windows.Forms.ToolStripMenuItem mnuFileNew;
        private System.Windows.Forms.ToolStripMenuItem scaleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuScale1_2;
        private System.Windows.Forms.ToolStripMenuItem mnuScale1_3;
        private System.Windows.Forms.ToolStripMenuItem mnuScale1_4;
        private System.Windows.Forms.ToolStripMenuItem mnuScale1_1;
        private System.Windows.Forms.ToolStripMenuItem colorsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuColorBackground;
        private System.Windows.Forms.ColorDialog cdBackground;
    }
}

