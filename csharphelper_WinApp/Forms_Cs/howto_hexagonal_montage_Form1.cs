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

 

using howto_hexagonal_montage;
namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_hexagonal_montage_Form1:Form
  { 


        public howto_hexagonal_montage_Form1()
        {
            InitializeComponent();
        }

        // The height of a hexagon.
        private float HexHeight = 50;
        private float BorderThickness = 5;
 
        // Selected hexagons.
        private List<Hexagon> Hexagons = new List<Hexagon>();

        // Redraw the grid.
        private void picGrid_Paint(object sender, PaintEventArgs e)
        {
            DrawGrid(e.Graphics,
                picGrid.ClientSize.Width,
                picGrid.ClientSize.Height);
        }
        private void DrawGrid(Graphics gr, int xmax, int ymax)
        {
            gr.Clear(picBackgroundColor.BackColor);
            gr.SmoothingMode = SmoothingMode.AntiAlias;

            // Draw the selected hexagons.
            float xmin = BorderThickness / 2f;
            foreach (Hexagon hexagon in Hexagons)
            {
                PointF[] points = Hex.HexToPoints(HexHeight,
                    hexagon.Row, hexagon.Column, xmin, xmin);

                if (points[3].X > xmax) continue;
                if (points[4].Y > ymax) continue;

                Hex.DrawImageInPolygon(gr,
                    Hex.HexToPoints(HexHeight,
                        hexagon.Row, hexagon.Column, xmin, xmin),
                        hexagon.Picture);
            }

            // Draw the grid.
            using (Pen pen = new Pen(picBorderColor.BackColor, BorderThickness))
            {
                Hex.DrawHexGrid(gr, pen,
                    xmin, xmax, xmin, ymax, HexHeight);
            }
        }

        private void picGrid_Resize(object sender, EventArgs e)
        {
            picGrid.Refresh();
        }

        // Display the row and column under the mouse.
        private void picGrid_MouseMove(object sender, MouseEventArgs e)
        {
            int row, col;
            Hex.PointToHex(e.X, e.Y, HexHeight, out row, out col);
            int index = FindHexagon(row, col);
            if (index < 0)
                this.Text = "howto_hexagonal_montage";
            else
            {
                string name = Hexagons[index].FileName;
                int pos = name.IndexOf('.');
                this.Text = name.Substring(0, pos);
            }
        }

        // Add the clicked hexagon to the Hexagons list.
        private void picGrid_MouseClick(object sender, MouseEventArgs e)
        {
            // Get the row and column clicked.
            int row, col;
            Hex.PointToHex(e.X, e.Y, HexHeight, out row, out col);

            // Remove any existing record for this cell.
            RemoveHexagon(row, col);

            // Let the user select a new picture.
            if (ofdFile.ShowDialog() == DialogResult.OK)
            {
                Bitmap bm = LoadBitmapUnlocked(ofdFile.FileName);
                Hexagons.Add(new Hexagon(row, col, bm, ofdFile.FileName));
            }

            // Redraw.
            picGrid.Refresh();
        }

        // Remove the Hexagon at this position if there is one.
        private void RemoveHexagon(int row, int col)
        {
            int index = FindHexagon(row,col);
            if (index >= 0) Hexagons.RemoveAt(index);
        }

        // Find the Hexagon at this position if there is one.
        private int FindHexagon(int row, int col)
        {
            for (int i = 0; i < Hexagons.Count; i++)
            {
                if ((Hexagons[i].Row == row) &&
                    (Hexagons[i].Column == col))
                    return i;
            }
            return -1;
        }

        private void mnuFileSaveAs_Click(object sender, EventArgs e)
        {
            if (sfdSave.ShowDialog() == DialogResult.OK)
            {
                // See how big the image needs to be.
                float xmax, ymax;
                FindGridBounds(out xmax, out ymax);
                int wid = (int)(xmax + 1);
                int hgt = (int)(ymax + 1);
                using (Bitmap bm = new Bitmap(wid, hgt))
                {
                    using (Graphics gr = Graphics.FromImage(bm))
                    {
                        DrawGrid(gr, wid, hgt);
                    }
                    SaveImage(bm, sfdSave.FileName);
                }
            }
        }

        private void mnuFileExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        // A parameter changed. Update the drawing.
        private void txt_TextChanged(object sender, EventArgs e)
        {
            float height, thickness;
            if (!float.TryParse(txtHexHeight.Text, out height) ||
                height < 10)
                return;
            if (!float.TryParse(txtBorderThickness.Text, out thickness))
                return;

            HexHeight = height;
            BorderThickness = thickness;
            picGrid.Refresh();
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

        private void picBorderColor_Click(object sender, EventArgs e)
        {
            cdBorderColor.Color = picBorderColor.BackColor;
            if (cdBorderColor.ShowDialog() == DialogResult.OK)
            {
                picBorderColor.BackColor = cdBorderColor.Color;
                picGrid.Refresh();
            }
        }

        private void picBackgroundColor_Click(object sender, EventArgs e)
        {
            cdBorderColor.Color = picBackgroundColor.BackColor;
            if (cdBorderColor.ShowDialog() == DialogResult.OK)
            {
                picBackgroundColor.BackColor = cdBorderColor.Color;
                picGrid.Refresh();
            }
        }

        // See http://csharphelper.com/blog/2014/07/load-images-without-locking-their-files-in-c/
        // Load a bitmap without locking it.
        private Bitmap LoadBitmapUnlocked(string file_name)
        {
            using (Bitmap bm = new Bitmap(file_name))
            {
                return new Bitmap(bm);
            }
        }

        // Get the hexs' largest X and Y coordinates.
        private void FindGridBounds(out float xmax, out float ymax)
        {
            xmax = 0;
            ymax = 0;
            float xmin = BorderThickness / 2f;
            foreach (Hexagon hexagon in Hexagons)
            {
                PointF[] points = Hex.HexToPoints(HexHeight,
                    hexagon.Row, hexagon.Column, xmin, xmin);
                if (xmax < points[3].X) xmax = points[3].X;
                if (ymax < points[4].Y) ymax = points[4].Y;
            }

            // Add room for the border thickness.
            xmax += xmin;
            ymax += xmin;
        }

        // Load the files from a directory.
        private void mnuFileOpenDirectoryFiles_Click(object sender, EventArgs e)
        {
            if (ofdDirectoryFiles.ShowDialog() == DialogResult.OK)
            {
                // Get a list of the files in the directory.
                FileInfo info = new FileInfo(ofdDirectoryFiles.FileName);
                DirectoryInfo dir_info = info.Directory;
                List<FileInfo> file_infos = new List<FileInfo>();
                foreach (FileInfo file_info in dir_info.GetFiles())
                {
                    string ext = file_info.Extension.ToLower().Replace(".", "");
                    if ((ext == "bmp") || (ext == "png") ||
                        (ext == "jpg") || (ext == "jpeg") ||
                        (ext == "gif") || (ext == "tiff"))
                    {
                        file_infos.Add(file_info);
                    }
                }

                // Calculate the number of rows and columns.
                int num_rows = (int)Math.Sqrt(file_infos.Count);
                int num_cols = num_rows;
                if (num_rows * num_cols < file_infos.Count)
                    num_cols++;
                if (num_rows * num_cols < file_infos.Count)
                    num_rows++;

                // Load the files.
                Hexagons = new List<Hexagon>();
                int index = 0;
                for (int row = 0; row < num_rows; row++)
                {
                    for (int col = 0; col < num_cols; col++)
                    {
                        string name = file_infos[index].Name;
                        string full_name = file_infos[index].FullName;
                        Bitmap bm = LoadBitmapUnlocked(full_name);
                        Hexagons.Add(new Hexagon(row, col, bm, name));

                        index++;
                        if (index >= file_infos.Count) break;
                    }
                    if (index >= file_infos.Count) break;
                }

                picGrid.Refresh();
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
            this.picGrid = new System.Windows.Forms.PictureBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFileOpenDirectoryFiles = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFileSaveAs = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuFileExit = new System.Windows.Forms.ToolStripMenuItem();
            this.sfdSave = new System.Windows.Forms.SaveFileDialog();
            this.label1 = new System.Windows.Forms.Label();
            this.txtHexHeight = new System.Windows.Forms.TextBox();
            this.ofdFile = new System.Windows.Forms.OpenFileDialog();
            this.txtBorderThickness = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.picBorderColor = new System.Windows.Forms.PictureBox();
            this.cdBorderColor = new System.Windows.Forms.ColorDialog();
            this.picBackgroundColor = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.ofdDirectoryFiles = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.picGrid)).BeginInit();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBorderColor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBackgroundColor)).BeginInit();
            this.SuspendLayout();
            // 
            // picGrid
            // 
            this.picGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.picGrid.BackColor = System.Drawing.Color.White;
            this.picGrid.Location = new System.Drawing.Point(12, 79);
            this.picGrid.Name = "picGrid";
            this.picGrid.Size = new System.Drawing.Size(300, 300);
            this.picGrid.TabIndex = 1;
            this.picGrid.TabStop = false;
            this.picGrid.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picGrid_MouseMove);
            this.picGrid.Resize += new System.EventHandler(this.picGrid_Resize);
            this.picGrid.MouseClick += new System.Windows.Forms.MouseEventHandler(this.picGrid_MouseClick);
            this.picGrid.Paint += new System.Windows.Forms.PaintEventHandler(this.picGrid_Paint);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(324, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFileOpenDirectoryFiles,
            this.mnuFileSaveAs,
            this.toolStripMenuItem1,
            this.mnuFileExit});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // mnuFileOpenDirectoryFiles
            // 
            this.mnuFileOpenDirectoryFiles.Name = "mnuFileOpenDirectoryFiles";
            this.mnuFileOpenDirectoryFiles.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.mnuFileOpenDirectoryFiles.Size = new System.Drawing.Size(245, 22);
            this.mnuFileOpenDirectoryFiles.Text = "&Open Files in Directory...";
            this.mnuFileOpenDirectoryFiles.Click += new System.EventHandler(this.mnuFileOpenDirectoryFiles_Click);
            // 
            // mnuFileSaveAs
            // 
            this.mnuFileSaveAs.Name = "mnuFileSaveAs";
            this.mnuFileSaveAs.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.mnuFileSaveAs.Size = new System.Drawing.Size(181, 22);
            this.mnuFileSaveAs.Text = "&Save As...";
            this.mnuFileSaveAs.Click += new System.EventHandler(this.mnuFileSaveAs_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(178, 6);
            // 
            // mnuFileExit
            // 
            this.mnuFileExit.Name = "mnuFileExit";
            this.mnuFileExit.Size = new System.Drawing.Size(181, 22);
            this.mnuFileExit.Text = "E&xit";
            this.mnuFileExit.Click += new System.EventHandler(this.mnuFileExit_Click);
            // 
            // sfdSave
            // 
            this.sfdSave.DefaultExt = "png";
            this.sfdSave.Filter = "Picture Files|*.bmp;*.jpg;*.gif;*.png;*.tif|All Files|*.*";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Hex Height:";
            // 
            // txtHexHeight
            // 
            this.txtHexHeight.Location = new System.Drawing.Point(111, 27);
            this.txtHexHeight.Name = "txtHexHeight";
            this.txtHexHeight.Size = new System.Drawing.Size(43, 20);
            this.txtHexHeight.TabIndex = 4;
            this.txtHexHeight.Text = "50";
            this.txtHexHeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtHexHeight.TextChanged += new System.EventHandler(this.txt_TextChanged);
            // 
            // ofdFile
            // 
            this.ofdFile.DefaultExt = "png";
            this.ofdFile.Filter = "Picture Files|*.bmp;*.jpg;*.gif;*.png;*.tif|All Files|*.*";
            // 
            // txtBorderThickness
            // 
            this.txtBorderThickness.Location = new System.Drawing.Point(111, 53);
            this.txtBorderThickness.Name = "txtBorderThickness";
            this.txtBorderThickness.Size = new System.Drawing.Size(43, 20);
            this.txtBorderThickness.TabIndex = 6;
            this.txtBorderThickness.Text = "5";
            this.txtBorderThickness.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtBorderThickness.TextChanged += new System.EventHandler(this.txt_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Border Thickness:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(169, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Border Color:";
            // 
            // picBorderColor
            // 
            this.picBorderColor.BackColor = System.Drawing.Color.Red;
            this.picBorderColor.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.picBorderColor.Location = new System.Drawing.Point(270, 27);
            this.picBorderColor.Name = "picBorderColor";
            this.picBorderColor.Size = new System.Drawing.Size(43, 20);
            this.picBorderColor.TabIndex = 8;
            this.picBorderColor.TabStop = false;
            this.picBorderColor.Click += new System.EventHandler(this.picBorderColor_Click);
            // 
            // picBackgroundColor
            // 
            this.picBackgroundColor.BackColor = System.Drawing.Color.LightGreen;
            this.picBackgroundColor.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.picBackgroundColor.Location = new System.Drawing.Point(270, 53);
            this.picBackgroundColor.Name = "picBackgroundColor";
            this.picBackgroundColor.Size = new System.Drawing.Size(43, 20);
            this.picBackgroundColor.TabIndex = 10;
            this.picBackgroundColor.TabStop = false;
            this.picBackgroundColor.Click += new System.EventHandler(this.picBackgroundColor_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(169, 56);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(95, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Background Color:";
            // 
            // ofdDirectoryFiles
            // 
            this.ofdDirectoryFiles.DefaultExt = "png";
            this.ofdDirectoryFiles.Filter = "Picture Files|*.bmp;*.jpg;*.gif;*.png;*.tif|All Files|*.*";
            // 
            // howto_hexagonal_montage_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(324, 391);
            this.Controls.Add(this.picBackgroundColor);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.picBorderColor);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtBorderThickness);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtHexHeight);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.picGrid);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "howto_hexagonal_montage_Form1";
            this.Text = "howto_hexagonal_montage";
            ((System.ComponentModel.ISupportInitialize)(this.picGrid)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBorderColor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBackgroundColor)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picGrid;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuFileSaveAs;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem mnuFileExit;
        private System.Windows.Forms.SaveFileDialog sfdSave;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtHexHeight;
        private System.Windows.Forms.OpenFileDialog ofdFile;
        private System.Windows.Forms.TextBox txtBorderThickness;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox picBorderColor;
        private System.Windows.Forms.ColorDialog cdBorderColor;
        private System.Windows.Forms.PictureBox picBackgroundColor;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ToolStripMenuItem mnuFileOpenDirectoryFiles;
        private System.Windows.Forms.OpenFileDialog ofdDirectoryFiles;
    }
}

