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

 

namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_crop_to_size_Form1:Form
  { 


        public howto_crop_to_size_Form1()
        {
            InitializeComponent();
        }

        private Rectangle SelectedRect = new Rectangle();
        private bool Dragging = false;
        private Point LastPoint;

        // Set the selection rectangle's initial size.
        private void howto_crop_to_size_Form1_Load(object sender, EventArgs e)
        {
            int width = int.Parse(txtWidth.Text);
            int height = int.Parse(txtHeight.Text);
            SelectedRect = new Rectangle(0, 0, width, height);
        }

        // Let the user select an image file.
        private void mnuFileOpen_Click(object sender, EventArgs e)
        {
            if (ofdImage.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // Load the image.
                    picImage.Image = new Bitmap(ofdImage.FileName);
                    picImage.Visible = true;
                    picImage.Refresh();

                    // Make the form bigger if necessary.
                    int width = picImage.Right + picImage.Left;
                    int height = picImage.Bottom + picImage.Left;
                    if (width < ClientSize.Width) width = ClientSize.Width;
                    if (height < ClientSize.Height) height = ClientSize.Height;
                    ClientSize = new Size(width, height);

                    // Enable the Save As menu item.
                    mnuFileSaveAs.Enabled = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        // Save the selected area.
        private void mnuFileSaveAs_Click(object sender, EventArgs e)
        {
            if (sfdImage.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // Copy the selected area into a new Bitmap.
                    Bitmap bm = new Bitmap(
                        SelectedRect.Width,
                        SelectedRect.Height);
                    using (Graphics gr = Graphics.FromImage(bm))
                    {
                        gr.DrawImage(picImage.Image, 0, 0,
                            SelectedRect, GraphicsUnit.Pixel);
                    }

                    // Save the new Bitmap.
                    SaveImage(bm, sfdImage.FileName);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void mnuFileExit_Click(object sender, EventArgs e)
        {
            Close();
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

        // Draw the selection rectangle.
        private void picImage_Paint(object sender, PaintEventArgs e)
        {
            try
            {
                // Draw the selection rectangle.
                using (Pen pen = new Pen(Color.Red, 2))
                {
                    e.Graphics.DrawRectangle(pen, SelectedRect);

                    pen.Color = Color.Yellow;
                    pen.DashPattern = new float[] { 5, 5 };
                    e.Graphics.DrawRectangle(pen, SelectedRect);
                }
            }
            catch
            {
            }
        }

        // Return the currently selected area.
        private void UpdateSelection()
        {
            int width, height;

            // Get the desired dimensions.
            // If there's a problem, return a zero-size rectangle.
            if (!int.TryParse(txtWidth.Text, out width)) return;
            if (!int.TryParse(txtHeight.Text, out height)) return;

            // Return the rectangle.
            SelectedRect.Width = width;
            SelectedRect.Height = height;
        }

        // Start dragging.
        private void picImage_MouseDown(object sender, MouseEventArgs e)
        {
            // If the mouse is not inside the
            // selection rectangle, do nothing.
            if (!SelectedRect.Contains(e.Location)) return;

            // Start the drag.
            LastPoint = e.Location;
            Dragging = true;
        }

        // Continue dragging.
        private void picImage_MouseMove(object sender, MouseEventArgs e)
        {
            // See if we are dragging.
            if (Dragging)
            {
                // We are dragging. Move the selected rectangle.
                SelectedRect.X += e.Location.X - LastPoint.X;
                SelectedRect.Y += e.Location.Y - LastPoint.Y;
                LastPoint = e.Location;
                picImage.Refresh();
            }
            else
            {
                // We are not dragging. Update the cursor.
                if (SelectedRect.Contains(e.Location))
                    Cursor = Cursors.SizeAll;
                else
                    Cursor = Cursors.Default;
            }
        }

        // Stop dragging.
        private void picImage_MouseUp(object sender, MouseEventArgs e)
        {
            Dragging = false;
        }

        private void txtWidth_TextChanged(object sender, EventArgs e)
        {
            // Get the new value.
            int value;
            if (!int.TryParse(txtWidth.Text, out value)) value = 0;
            SelectedRect.Width = value;
            picImage.Refresh();
        }

        private void txtHeight_TextChanged(object sender, EventArgs e)
        {
            int value;
            if (!int.TryParse(txtHeight.Text, out value)) value = 0;
            SelectedRect.Height = value;
            picImage.Refresh();
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
            this.mnuFileSaveAs = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuFileExit = new System.Windows.Forms.ToolStripMenuItem();
            this.sfdImage = new System.Windows.Forms.SaveFileDialog();
            this.ofdImage = new System.Windows.Forms.OpenFileDialog();
            this.label1 = new System.Windows.Forms.Label();
            this.txtWidth = new System.Windows.Forms.TextBox();
            this.txtHeight = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.picImage = new System.Windows.Forms.PictureBox();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picImage)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
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
            this.mnuFileSaveAs,
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
            this.mnuFileOpen.Size = new System.Drawing.Size(163, 22);
            this.mnuFileOpen.Text = "&Open...";
            this.mnuFileOpen.Click += new System.EventHandler(this.mnuFileOpen_Click);
            // 
            // mnuFileSaveAs
            // 
            this.mnuFileSaveAs.Enabled = false;
            this.mnuFileSaveAs.Name = "mnuFileSaveAs";
            this.mnuFileSaveAs.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.mnuFileSaveAs.Size = new System.Drawing.Size(163, 22);
            this.mnuFileSaveAs.Text = "&Save As...";
            this.mnuFileSaveAs.Click += new System.EventHandler(this.mnuFileSaveAs_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(160, 6);
            // 
            // mnuFileExit
            // 
            this.mnuFileExit.Name = "mnuFileExit";
            this.mnuFileExit.Size = new System.Drawing.Size(163, 22);
            this.mnuFileExit.Text = "E&xit";
            this.mnuFileExit.Click += new System.EventHandler(this.mnuFileExit_Click);
            // 
            // sfdImage
            // 
            this.sfdImage.DefaultExt = "png";
            this.sfdImage.Filter = "Picture Files|*.bmp;*.jpg;*.gif;*.png;*.tif|All Files|*.*";
            // 
            // ofdImage
            // 
            this.ofdImage.DefaultExt = "png";
            this.ofdImage.Filter = "Picture Files|*.bmp;*.jpg;*.gif;*.png;*.tif|All Files|*.*";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Size:";
            // 
            // txtWidth
            // 
            this.txtWidth.Location = new System.Drawing.Point(48, 27);
            this.txtWidth.Name = "txtWidth";
            this.txtWidth.Size = new System.Drawing.Size(46, 20);
            this.txtWidth.TabIndex = 2;
            this.txtWidth.Text = "200";
            this.txtWidth.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtWidth.TextChanged += new System.EventHandler(this.txtWidth_TextChanged);
            // 
            // txtHeight
            // 
            this.txtHeight.Location = new System.Drawing.Point(118, 27);
            this.txtHeight.Name = "txtHeight";
            this.txtHeight.Size = new System.Drawing.Size(46, 20);
            this.txtHeight.TabIndex = 4;
            this.txtHeight.Text = "100";
            this.txtHeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtHeight.TextChanged += new System.EventHandler(this.txtHeight_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(100, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(12, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "x";
            // 
            // picImage
            // 
            this.picImage.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.picImage.Location = new System.Drawing.Point(12, 53);
            this.picImage.Name = "picImage";
            this.picImage.Size = new System.Drawing.Size(100, 50);
            this.picImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picImage.TabIndex = 5;
            this.picImage.TabStop = false;
            this.picImage.Visible = false;
            this.picImage.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picImage_MouseMove);
            this.picImage.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picImage_MouseDown);
            this.picImage.Paint += new System.Windows.Forms.PaintEventHandler(this.picImage_Paint);
            this.picImage.MouseUp += new System.Windows.Forms.MouseEventHandler(this.picImage_MouseUp);
            // 
            // howto_crop_to_size_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.picImage);
            this.Controls.Add(this.txtHeight);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtWidth);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "howto_crop_to_size_Form1";
            this.Text = "howto_crop_to_size";
            this.Load += new System.EventHandler(this.howto_crop_to_size_Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picImage)).EndInit();
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
        private System.Windows.Forms.SaveFileDialog sfdImage;
        private System.Windows.Forms.OpenFileDialog ofdImage;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtWidth;
        private System.Windows.Forms.TextBox txtHeight;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox picImage;
    }
}

