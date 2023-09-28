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
     public partial class howto_sizemode_image_parts_Form1:Form
  { 


        public howto_sizemode_image_parts_Form1()
        {
            InitializeComponent();
        }

        private Bitmap OriginalImage = null;
        private int X0, Y0, X1, Y1;
        private bool SelectingArea = false;
        private Bitmap SelectedImage = null;
        private Graphics SelectedGraphics = null;
        private Rectangle SelectedRect;
        private bool MadeSelection = false;

        // Save the original image.
        private void howto_sizemode_image_parts_Form1_Load(object sender, EventArgs e)
        {
            cboSizeMode.SelectedIndex = 1;
            OriginalImage = new Bitmap(picImage.Image);

            this.KeyPreview = true;
        }

        // Start selecting an area.
        private void picImage_MouseDown(object sender, MouseEventArgs e)
        {
            // Save the starting point.
            SelectingArea = true;
            ConvertCoordinates(picImage, out X0, out Y0, e.X, e.Y);

            // Make the selected image.
            SelectedImage = new Bitmap(OriginalImage);
            SelectedGraphics = Graphics.FromImage(SelectedImage);
            picImage.Image = SelectedImage;
        }

        // Convert the coordinates for the image's SizeMode.
        private void ConvertCoordinates(PictureBox pic, out int X0, out int Y0, int x, int y)
        {
            int pic_hgt = pic.ClientSize.Height;
            int pic_wid = pic.ClientSize.Width;
            int img_hgt = pic.Image.Height;
            int img_wid = pic.Image.Width;

            X0 = x;
            Y0 = y;
            switch (pic.SizeMode)
            {
                case PictureBoxSizeMode.AutoSize:
                case PictureBoxSizeMode.Normal:
                    // These are okay. Leave them alone.
                    break;
                case PictureBoxSizeMode.CenterImage:
                    X0 = x - (pic_wid - img_wid) / 2;
                    Y0 = y - (pic_hgt - img_hgt) / 2;
                    break;
                case PictureBoxSizeMode.StretchImage:
                    X0 = (int)(img_wid * x / (float)pic_wid);
                    Y0 = (int)(img_hgt * y / (float)pic_hgt);
                    break;
                case PictureBoxSizeMode.Zoom:
                    float pic_aspect = pic_wid / (float)pic_hgt;
                    float img_aspect = img_wid / (float)img_hgt;
                    if (pic_aspect > img_aspect)
                    {
                        // The PictureBox is wider/shorter than the image.
                        Y0 = (int)(img_hgt * y / (float)pic_hgt);

                        // The image fills the height of the PictureBox.
                        // Get its width.
                        float scaled_width = img_wid * pic_hgt / img_hgt;
                        float dx = (pic_wid - scaled_width) / 2;
                        X0 = (int)((x - dx) * img_hgt / (float)pic_hgt);
                    }
                    else
                    {
                        // The PictureBox is taller/thinner than the image.
                        X0 = (int)(img_wid * x / (float)pic_wid);

                        // The image fills the height of the PictureBox.
                        // Get its height.
                        float scaled_height = img_hgt * pic_wid / img_wid;
                        float dy = (pic_hgt - scaled_height) / 2;
                        Y0 = (int)((y - dy) * img_wid / pic_wid);
                    }
                    break;
            }
        }

        // Continue selecting an area.
        private void picImage_MouseMove(object sender, MouseEventArgs e)
        {
            // Do nothing if we're not selecting an area.
            if (!SelectingArea) return;

            // Generate the new image with the selection rectangle.
            ConvertCoordinates(picImage, out X1, out Y1, e.X, e.Y);

            // Copy the original image.
            SelectedGraphics.DrawImage(OriginalImage, 0, 0);

            // Draw the selection rectangle.
            using (Pen select_pen = new Pen(Color.Red))
            {
                select_pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
                Rectangle rect = MakeRectangle(X0, Y0, X1, Y1);
                SelectedGraphics.DrawRectangle(select_pen, rect);
            }

            picImage.Refresh();
        }

        // Finish selecting the area.
        private void picImage_MouseUp(object sender, MouseEventArgs e)
        {
            // Do nothing if we're not selecting an area.
            if (!SelectingArea) return;
            SelectingArea = false;

            // Stop selecting.
            SelectedGraphics = null;

            // Convert the points into a Rectangle.
            SelectedRect = MakeRectangle(X0, Y0, X1, Y1);
            MadeSelection = (
                (SelectedRect.Width > 0) &&
                (SelectedRect.Height > 0));

            // Enable the menu items appropriately.
            EnableMenuItems();
        }

        // Enable or disable the menu items.
        private void EnableMenuItems()
        {
            mnuEditCopy.Enabled = MadeSelection;
            mnuEditCut.Enabled = MadeSelection;
            mnuEditPasteStretched.Enabled = MadeSelection;
            mnuEditPasteCentered.Enabled = MadeSelection;
        }

        // Return a Rectangle with these points as corners.
        private Rectangle MakeRectangle(int x0, int y0, int x1, int y1)
        {
            return new Rectangle(
                Math.Min(x0, x1),
                Math.Min(y0, y1),
                Math.Abs(x0 - x1),
                Math.Abs(y0 - y1));
        }

        // If the user presses Escape, cancel.
        private void howto_sizemode_image_parts_Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 27)
            {
                if (!SelectingArea) return;
                SelectingArea = false;

                // Stop selecting.
                SelectedImage = null;
                SelectedGraphics = null;
                picImage.Image = OriginalImage;
                picImage.Refresh();

                // There is no selection.
                MadeSelection = false;

                // Enable the menu items appropriately.
                EnableMenuItems();
            }
        }

        // Copy the selected area to the clipboard.
        private void CopyToClipboard(Rectangle src_rect)
        {
            // Make a bitmap for the selected area's image.
            Bitmap bm = new Bitmap(src_rect.Width, src_rect.Height);

            // Copy the selected area into the bitmap.
            using (Graphics gr = Graphics.FromImage(bm))
            {
                Rectangle dest_rect = new Rectangle(0, 0, src_rect.Width, src_rect.Height);
                gr.DrawImage(OriginalImage, dest_rect, src_rect, GraphicsUnit.Pixel);
            }

            // Copy the selection image to the clipboard.
            Clipboard.SetImage(bm);
        }

        // Copy the selected area to the clipboard.
        private void mnuEditCopy_Click(object sender, EventArgs e)
        {
            CopyToClipboard(SelectedRect);
            System.Media.SystemSounds.Beep.Play();
        }

        // Copy the selected area to the clipboard
        // and blank that area.
        private void mnuEditCut_Click(object sender, EventArgs e)
        {
            // Copy the selection to the clipboard.
            CopyToClipboard(SelectedRect);

            // Blank the selected area in the original image.
            using (Graphics gr = Graphics.FromImage(OriginalImage))
            {
                using (SolidBrush br = new SolidBrush(picImage.BackColor))
                {
                    gr.FillRectangle(br, SelectedRect);
                }
            }

            // Display the result.
            SelectedImage = new Bitmap(OriginalImage);
            picImage.Image = SelectedImage;

            // Enable the menu items appropriately.
            EnableMenuItems();
            SelectedImage = null;
            SelectedGraphics = null;
            MadeSelection = false;

            System.Media.SystemSounds.Beep.Play();
        }

        // Exit.
        private void mnuFileExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Paste the image on the clipboard, centering it on the selected area.
        private void mnuEditPasteCentered_Click(object sender, EventArgs e)
        {
            // Do nothing if the clipboard doesn't hold an image.
            if (!Clipboard.ContainsImage()) return;

            // Get the clipboard's image.
            Image clipboard_image = Clipboard.GetImage();

            // Figure out where to put it.
            int cx = SelectedRect.X + (SelectedRect.Width - clipboard_image.Width) / 2;
            int cy = SelectedRect.Y + (SelectedRect.Height - clipboard_image.Height) / 2;
            Rectangle dest_rect = new Rectangle(
                cx, cy,
                clipboard_image.Width,
                clipboard_image.Height);

            // Copy the new image into position.
            using (Graphics gr = Graphics.FromImage(OriginalImage))
            {
                gr.DrawImage(clipboard_image, dest_rect);
            }

            // Display the result.
            picImage.Image = OriginalImage;
            picImage.Refresh();

            SelectedImage = null;
            SelectedGraphics = null;
            MadeSelection = false;
        }

        // Paste the image on the clipboard, stretching it to fit the selected area.
        private void mnuEditPasteStretched_Click(object sender, EventArgs e)
        {
            // Do nothing if the clipboard doesn't hold an image.
            if (!Clipboard.ContainsImage()) return;

            // Get the clipboard's image.
            Image clipboard_image = Clipboard.GetImage();

            // Get the image's bounding Rectangle.
            Rectangle src_rect = new Rectangle(
                0, 0,
                clipboard_image.Width,
                clipboard_image.Height);

            // Copy the new image into position.
            using (Graphics gr = Graphics.FromImage(OriginalImage))
            {
                gr.DrawImage(clipboard_image, SelectedRect,
                    src_rect, GraphicsUnit.Pixel);
            }

            // Display the result.
            picImage.Image = OriginalImage;
            picImage.Refresh();

            SelectedImage = null;
            SelectedGraphics = null;
            MadeSelection = false;
        }

        // Change the PictureBox's SizeMode.
        private void cboSizeMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cboSizeMode.SelectedItem.ToString())
            {
                case "AutoSize":
                    picImage.SizeMode = PictureBoxSizeMode.AutoSize;
                    this.ClientSize =
                        new Size(picImage.Right + 10, picImage.Bottom + 10);
                    break;
                case "Normal":
                    picImage.SizeMode = PictureBoxSizeMode.Normal;
                    break;
                case "CenterImage":
                    picImage.SizeMode = PictureBoxSizeMode.CenterImage;
                    break;
                case "StretchImage":
                    picImage.SizeMode = PictureBoxSizeMode.StretchImage;
                    break;
                case "Zoom":
                    picImage.SizeMode = PictureBoxSizeMode.Zoom;
                    break;
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
            this.picImage = new System.Windows.Forms.PictureBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFileExit = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuEditCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuEditCut = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuEditPasteCentered = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuEditPasteStretched = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.cboSizeMode = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.picImage)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // picImage
            // 
            this.picImage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.picImage.BackColor = System.Drawing.Color.LightBlue;
            this.picImage.Cursor = System.Windows.Forms.Cursors.Cross;
            this.picImage.Image = Properties.Resources.KenDriving;
            this.picImage.Location = new System.Drawing.Point(12, 54);
            this.picImage.Name = "picImage";
            this.picImage.Size = new System.Drawing.Size(600, 450);
            this.picImage.TabIndex = 5;
            this.picImage.TabStop = false;
            this.picImage.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picImage_MouseMove);
            this.picImage.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picImage_MouseDown);
            this.picImage.MouseUp += new System.Windows.Forms.MouseEventHandler(this.picImage_MouseUp);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.editToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(626, 24);
            this.menuStrip1.TabIndex = 6;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFileExit});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(37, 20);
            this.toolStripMenuItem1.Text = "&File";
            // 
            // mnuFileExit
            // 
            this.mnuFileExit.Name = "mnuFileExit";
            this.mnuFileExit.Size = new System.Drawing.Size(92, 22);
            this.mnuFileExit.Text = "E&xit";
            this.mnuFileExit.Click += new System.EventHandler(this.mnuFileExit_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuEditCopy,
            this.mnuEditCut,
            this.mnuEditPasteCentered,
            this.mnuEditPasteStretched});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "&Edit";
            // 
            // mnuEditCopy
            // 
            this.mnuEditCopy.Name = "mnuEditCopy";
            this.mnuEditCopy.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.mnuEditCopy.Size = new System.Drawing.Size(194, 22);
            this.mnuEditCopy.Text = "&Copy";
            this.mnuEditCopy.ToolTipText = "Copy the selected area to the clipboard";
            this.mnuEditCopy.Click += new System.EventHandler(this.mnuEditCopy_Click);
            // 
            // mnuEditCut
            // 
            this.mnuEditCut.Name = "mnuEditCut";
            this.mnuEditCut.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
            this.mnuEditCut.Size = new System.Drawing.Size(194, 22);
            this.mnuEditCut.Text = "C&ut";
            this.mnuEditCut.ToolTipText = "Copy the selected area to the clipboard and clear the area";
            this.mnuEditCut.Click += new System.EventHandler(this.mnuEditCut_Click);
            // 
            // mnuEditPasteCentered
            // 
            this.mnuEditPasteCentered.Name = "mnuEditPasteCentered";
            this.mnuEditPasteCentered.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
            this.mnuEditPasteCentered.Size = new System.Drawing.Size(194, 22);
            this.mnuEditPasteCentered.Text = "&Paste Centered";
            this.mnuEditPasteCentered.ToolTipText = "Paste the image on the clipboard to the selected area, centering it in the select" +
                "ed area";
            this.mnuEditPasteCentered.Click += new System.EventHandler(this.mnuEditPasteCentered_Click);
            // 
            // mnuEditPasteStretched
            // 
            this.mnuEditPasteStretched.Name = "mnuEditPasteStretched";
            this.mnuEditPasteStretched.Size = new System.Drawing.Size(194, 22);
            this.mnuEditPasteStretched.Text = "Paste &Stretched";
            this.mnuEditPasteStretched.ToolTipText = "Paste the image on the clipboard to the selected area, stretching it to fit";
            this.mnuEditPasteStretched.Click += new System.EventHandler(this.mnuEditPasteStretched_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Size Mode:";
            // 
            // cboSizeMode
            // 
            this.cboSizeMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSizeMode.FormattingEnabled = true;
            this.cboSizeMode.Items.AddRange(new object[] {
            "AutoSize",
            "Normal",
            "CenterImage",
            "StretchImage",
            "Zoom"});
            this.cboSizeMode.Location = new System.Drawing.Point(75, 27);
            this.cboSizeMode.Name = "cboSizeMode";
            this.cboSizeMode.Size = new System.Drawing.Size(121, 21);
            this.cboSizeMode.TabIndex = 8;
            this.cboSizeMode.SelectedIndexChanged += new System.EventHandler(this.cboSizeMode_SelectedIndexChanged);
            // 
            // howto_sizemode_image_parts_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(626, 517);
            this.Controls.Add(this.cboSizeMode);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.picImage);
            this.Controls.Add(this.menuStrip1);
            this.Name = "howto_sizemode_image_parts_Form1";
            this.Text = "howto_sizemode_image_parts";
            this.Load += new System.EventHandler(this.howto_sizemode_image_parts_Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picImage)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picImage;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem mnuFileExit;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuEditCopy;
        private System.Windows.Forms.ToolStripMenuItem mnuEditCut;
        private System.Windows.Forms.ToolStripMenuItem mnuEditPasteCentered;
        private System.Windows.Forms.ToolStripMenuItem mnuEditPasteStretched;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboSizeMode;
    }
}

