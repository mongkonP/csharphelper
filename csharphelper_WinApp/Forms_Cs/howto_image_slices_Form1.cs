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

 

using howto_image_slices;
namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_image_slices_Form1:Form
  { 


        public howto_image_slices_Form1()
        {
            InitializeComponent();
        }

        // The result image.
        private Bitmap ResultImage = null;

        // Open a new file.
        private void mnuFileOpen_Click(object sender, EventArgs e)
        {
            ofdImage.Multiselect = true;
            if (ofdImage.ShowDialog() == DialogResult.OK)
            {
                foreach (string filename in ofdImage.FileNames)
                {
                    FileData file_data = new FileData(filename);
                    lstFiles.Items.Add(file_data);
                }

                ClearResult();
            }
        }

        // Save the result.
        private void mnuFileSave_Click(object sender, EventArgs e)
        {
            if (sfdImage.ShowDialog() == DialogResult.OK)
            {
                SaveImage(ResultImage, sfdImage.FileName);
            }
        }

        // Display the context menu.
        private void lstFiles_MouseDown(object sender, MouseEventArgs e)
        {
            // If this is not the right button, do nothing.
            if (e.Button != MouseButtons.Right) return;

            // Select the item under the mouse.
            lstFiles.SelectedIndex =
                lstFiles.IndexFromPoint(e.Location);

            // If no item is selected. do nothing.
            if (lstFiles.SelectedIndex == -1) return;

            // Display the context menu.
            ctxFile.Show(lstFiles, e.Location);
        }

        // Enable and disable the appropriate context menu items.
        private void ctxFile_Opening(object sender, CancelEventArgs e)
        {
            ctxMoveUp.Enabled =
                (lstFiles.SelectedIndex > 0);
            ctxMoveDown.Enabled =
                (lstFiles.SelectedIndex < lstFiles.Items.Count - 1);
        }

        // Move the selected file up in the list.
        private void ctxMoveUp_Click(object sender, EventArgs e)
        {
            // Get the selected index and its item.
            int index = lstFiles.SelectedIndex;
            if (index < 1) return;
            object item = lstFiles.Items[index];

            lstFiles.Items.RemoveAt(index);
            lstFiles.Items.Insert(index - 1, item);

            ClearResult();
        }

        // Move the selected file down in the list.
        private void ctxMoveDown_Click(object sender, EventArgs e)
        {
            // Get the selected index and its item.
            int index = lstFiles.SelectedIndex;
            if (index >= lstFiles.Items.Count) return;
            object item = lstFiles.Items[index];

            lstFiles.Items.RemoveAt(index);
            lstFiles.Items.Insert(index + 1, item);

            ClearResult();
        }

        // Remove this file from the list.
        private void ctxDelete_Click(object sender, EventArgs e)
        {
            lstFiles.Items.RemoveAt(lstFiles.SelectedIndex);
            ClearResult();
        }

        // Display the sliced image.
        private void ShowImage()
        {
            // Find the biggest image size.
            int width = 0;
            int height = 0;
            foreach (FileData file_data in lstFiles.Items)
            {
                if (width < file_data.Picture.Width)
                    width = file_data.Picture.Width;
                if (height < file_data.Picture.Height)
                    height = file_data.Picture.Height;
            }

            // Get the number of slices and the slice width.
            int num_slices = lstFiles.Items.Count;
            int slice_width = width / num_slices;

            // Make the result image.
            ResultImage = new Bitmap(width, height);
            using (Graphics gr = Graphics.FromImage(ResultImage))
            {
                gr.Clear(picResult.BackColor);

                // Draw the slices.
                for (int i = 0; i < num_slices; i++)
                {
                    int x = i * slice_width;
                    FileData file_data = (FileData)lstFiles.Items[i];
                    Rectangle rect = new Rectangle(x, 0, width, height);
                    gr.DrawImage(file_data.Picture,
                        rect, rect, GraphicsUnit.Pixel);
                }
            }

            // Display the result.
            picResult.Image = ResultImage;
            picResult.Visible = true;
            mnuFileSave.Enabled = true;
        }

        // Draw the image.
        private void btnDraw_Click(object sender, EventArgs e)
        {
            ShowImage();
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

        // Clear the result image and disable the Save menu item.
        private void ClearResult()
        {
            picResult.Image = null;
            picResult.Visible = false;
            mnuFileSave.Enabled = false;
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
            this.components = new System.ComponentModel.Container();
            this.picResult = new System.Windows.Forms.PictureBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFileOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFileSave = new System.Windows.Forms.ToolStripMenuItem();
            this.ofdImage = new System.Windows.Forms.OpenFileDialog();
            this.sfdImage = new System.Windows.Forms.SaveFileDialog();
            this.lstFiles = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.btnDraw = new System.Windows.Forms.Button();
            this.ctxFile = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ctxMoveUp = new System.Windows.Forms.ToolStripMenuItem();
            this.ctxMoveDown = new System.Windows.Forms.ToolStripMenuItem();
            this.ctxDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.eventLog1 = new System.Diagnostics.EventLog();
            ((System.ComponentModel.ISupportInitialize)(this.picResult)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.ctxFile.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.eventLog1)).BeginInit();
            this.SuspendLayout();
            // 
            // picResult
            // 
            this.picResult.BackColor = System.Drawing.Color.White;
            this.picResult.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.picResult.Location = new System.Drawing.Point(3, 16);
            this.picResult.Name = "picResult";
            this.picResult.Size = new System.Drawing.Size(231, 174);
            this.picResult.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picResult.TabIndex = 0;
            this.picResult.TabStop = false;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(417, 24);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFileOpen,
            this.mnuFileSave});
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
            this.mnuFileSave.Enabled = false;
            this.mnuFileSave.Name = "mnuFileSave";
            this.mnuFileSave.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.mnuFileSave.Size = new System.Drawing.Size(155, 22);
            this.mnuFileSave.Text = "&Save";
            this.mnuFileSave.Click += new System.EventHandler(this.mnuFileSave_Click);
            // 
            // ofdImage
            // 
            this.ofdImage.Filter = "Image Files|*.bmp;*.jpg;*.gif;*.png;*.tif";
            // 
            // sfdImage
            // 
            this.sfdImage.DefaultExt = "png";
            this.sfdImage.Filter = "Image Files|*.bmp;*.jpg;*.gif;*.png;*.tif";
            // 
            // lstFiles
            // 
            this.lstFiles.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lstFiles.FormattingEnabled = true;
            this.lstFiles.IntegralHeight = false;
            this.lstFiles.Location = new System.Drawing.Point(0, 16);
            this.lstFiles.Name = "lstFiles";
            this.lstFiles.Size = new System.Drawing.Size(128, 174);
            this.lstFiles.TabIndex = 0;
            this.lstFiles.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lstFiles_MouseDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Selected Files";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(12, 27);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.btnDraw);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Controls.Add(this.lstFiles);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.AutoScroll = true;
            this.splitContainer1.Panel2.Controls.Add(this.picResult);
            this.splitContainer1.Size = new System.Drawing.Size(393, 222);
            this.splitContainer1.SplitterDistance = 131;
            this.splitContainer1.TabIndex = 6;
            // 
            // btnDraw
            // 
            this.btnDraw.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnDraw.Location = new System.Drawing.Point(28, 196);
            this.btnDraw.Name = "btnDraw";
            this.btnDraw.Size = new System.Drawing.Size(75, 23);
            this.btnDraw.TabIndex = 6;
            this.btnDraw.Text = "Draw";
            this.btnDraw.UseVisualStyleBackColor = true;
            this.btnDraw.Click += new System.EventHandler(this.btnDraw_Click);
            // 
            // ctxFile
            // 
            this.ctxFile.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ctxMoveUp,
            this.ctxMoveDown,
            this.ctxDelete});
            this.ctxFile.Name = "ctxFile";
            this.ctxFile.Size = new System.Drawing.Size(139, 70);
            this.ctxFile.Opening += new System.ComponentModel.CancelEventHandler(this.ctxFile_Opening);
            // 
            // ctxMoveUp
            // 
            this.ctxMoveUp.Name = "ctxMoveUp";
            this.ctxMoveUp.Size = new System.Drawing.Size(138, 22);
            this.ctxMoveUp.Text = "Move &Up";
            this.ctxMoveUp.Click += new System.EventHandler(this.ctxMoveUp_Click);
            // 
            // ctxMoveDown
            // 
            this.ctxMoveDown.Name = "ctxMoveDown";
            this.ctxMoveDown.Size = new System.Drawing.Size(138, 22);
            this.ctxMoveDown.Text = "Move &Down";
            this.ctxMoveDown.Click += new System.EventHandler(this.ctxMoveDown_Click);
            // 
            // ctxDelete
            // 
            this.ctxDelete.Name = "ctxDelete";
            this.ctxDelete.Size = new System.Drawing.Size(138, 22);
            this.ctxDelete.Text = "Delete";
            this.ctxDelete.Click += new System.EventHandler(this.ctxDelete_Click);
            // 
            // eventLog1
            // 
            this.eventLog1.SynchronizingObject = this;
            // 
            // howto_image_slices_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(417, 261);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "howto_image_slices_Form1";
            this.Text = "howto_image_slices";
            ((System.ComponentModel.ISupportInitialize)(this.picResult)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            this.splitContainer1.ResumeLayout(false);
            this.ctxFile.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.eventLog1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picResult;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuFileOpen;
        private System.Windows.Forms.ToolStripMenuItem mnuFileSave;
        private System.Windows.Forms.OpenFileDialog ofdImage;
        private System.Windows.Forms.SaveFileDialog sfdImage;
        private System.Windows.Forms.ListBox lstFiles;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ContextMenuStrip ctxFile;
        private System.Windows.Forms.ToolStripMenuItem ctxMoveUp;
        private System.Windows.Forms.ToolStripMenuItem ctxMoveDown;
        private System.Windows.Forms.ToolStripMenuItem ctxDelete;
        private System.Windows.Forms.Button btnDraw;
        private System.Diagnostics.EventLog eventLog1;
    }
}

