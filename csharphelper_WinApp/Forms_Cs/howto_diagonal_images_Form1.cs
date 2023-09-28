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

 

using howto_diagonal_images;
namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_diagonal_images_Form1:Form
  { 


        public howto_diagonal_images_Form1()
        {
            InitializeComponent();
        }

        private int ImgWidth, ImgHeight;
        private float CellWidth, CellHeight, Angle, DividerWidth;
        private Color DividerColor;
        private Matrix Transform = null, InverseTransform = null;
        private List<Cell> Cells = null;
        private bool DocumentModified = false;

        private void mnuFileExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void mnuFileSaveAs_Click(object sender, EventArgs e)
        {
            SaveResult();
        }
        private void SaveResult()
        {
            if (sfdResult.ShowDialog() == DialogResult.OK)
            {
                using (Bitmap bm = new Bitmap(ImgWidth, ImgHeight))
                {
                    using (Graphics gr = Graphics.FromImage(bm))
                    {
                        DrawCells(gr);
                    }
                    SaveImage(bm, sfdResult.FileName);
                }
                DocumentModified = false;
            }
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            if (!DocumentIsSafe()) return;

            try
            {
                // Save the parameters.
                ImgWidth = int.Parse(txtWidth.Text);
                ImgHeight = int.Parse(txtHeight.Text);
                CellWidth = int.Parse(txtCellWidth.Text);
                CellHeight = int.Parse(txtCellHeight.Text);
                Angle = float.Parse(txtAngle.Text);
                DividerWidth = float.Parse(txtDividerWidth.Text);
                DividerColor = lblColor.BackColor;

                Transform = new Matrix();
                Transform.Rotate(Angle);
                InverseTransform = new Matrix();
                InverseTransform.Rotate(-Angle);

                // Make the cells.
                MakeCells();

                // Show the result.
                picCanvas.ClientSize = new Size(ImgWidth, ImgHeight);
                int margin = picCanvas.Left;
                int client_right = margin + Math.Max(
                    picCanvas.Right, btnCreate.Right);
                int client_bottom = margin + picCanvas.Bottom;
                this.ClientSize = new Size(client_right, client_bottom);
                picCanvas.Visible = true;
                mnuFileSaveAs.Enabled = true;

                picCanvas.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // Make the cells.
        private void MakeCells()
        {
            // Rotate the image's corners by -Angle degrees.
            PointF[] points =
            {
                new PointF(0, 0),
                new PointF(0, ImgHeight),
                new PointF(ImgWidth, ImgHeight),
                new PointF(ImgWidth, 0),
            };
            InverseTransform.TransformPoints(points);

            // Get the rotated image's bounds.
            float xmin = points[0].X;
            float ymin = points[0].Y;
            float xmax = xmin;
            float ymax = ymin;
            for (int i = 1; i < points.Length; i++)
            {
                if (xmin > points[i].X) xmin = points[i].X;
                if (xmax < points[i].X) xmax = points[i].X;
                if (ymin > points[i].Y) ymin = points[i].Y;
                if (ymax < points[i].Y) ymax = points[i].Y;
            }

            // Calculate the minimum and maximum rows
            // and columns that might be needed.
            int min_row = (int)(ymin / CellHeight) - 1;
            int max_row = (int)(ymax / CellHeight) + 1;
            int min_col = (int)(xmin / CellWidth) - 1;
            int max_col = (int)(xmax / CellWidth) + 1;

            // Make a GraphicsPath representing the rotated image bounds.
            GraphicsPath image_path = new GraphicsPath();
            image_path.AddPolygon(points);

            // Make a Graphics Object for use in IsEmpty.
            Graphics gr = CreateGraphics();

            // Loop over the possible rows and columns
            // and see which are actually needed.
            Cells = new List<Cell>();
            for (int row = min_row; row <= max_row; row++)
            {
                for (int col = min_col; col <= max_col; col++)
                {
                    // See if this cell's rectangle intersects
                    // the image's rotated bounds.
                    Region rgn = new Region(image_path);
                    float x = col * CellWidth;
                    float y = row * CellHeight;
                    if (Math.Abs(col % 2) == 1) y += CellHeight / 2f;
                    RectangleF cell_rect = new RectangleF(
                        x, y, CellWidth, CellHeight);
                    rgn.Intersect(cell_rect);
                    if (!rgn.IsEmpty(gr))
                    {
                        // Save this cell.
                        Cells.Add(new Cell(cell_rect));
                    }
                }
            }
            Console.WriteLine("# Cells: " + Cells.Count.ToString());
        }

        // Return true if it is safe to discard the current document.
        private bool DocumentIsSafe()
        {
            if (!DocumentModified) return true;
            DialogResult result = MessageBox.Show(
                "Do you want to save your changes?",
                "Save Changes?", MessageBoxButtons.YesNoCancel);

            // The user wants to discard changes.
            if (result == DialogResult.No) return true;

            // The user wants to cancel.
            if (result == DialogResult.Cancel) return false;

            // Try to save the result.
            SaveResult();
            return !DocumentModified;
        }

        private void lblColor_Click(object sender, EventArgs e)
        {
            cdDivider.Color = lblColor.BackColor;
            if (cdDivider.ShowDialog() == DialogResult.OK)
            {
                lblColor.BackColor = cdDivider.Color;
                picCanvas.Refresh();
            }
        }

        // Draw the picture.
        private void picCanvas_Paint(object sender, PaintEventArgs e)
        {
            DrawCells(e.Graphics);
        }
        private void DrawCells(Graphics gr)
        {
            gr.SmoothingMode = SmoothingMode.AntiAlias;
            gr.InterpolationMode = InterpolationMode.High;
            gr.Clear(picCanvas.BackColor);

            gr.Transform = Transform;
            using (Pen pen = new Pen(lblColor.BackColor, DividerWidth))
            {
                foreach (Cell cell in Cells)
                    cell.Draw(gr, pen, CellWidth, CellHeight);
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

        // If there are unsaved changes, ask the user if we should save them.
        private void howto_diagonal_images_Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = !DocumentIsSafe();
        }

        // Place a picture in this cell.
        private void picCanvas_MouseClick(object sender, MouseEventArgs e)
        {
            if (ofdCellPicture.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // Find the clicked cell.
                    // Inverse transform the clicked point.
                    PointF[] points = { e.Location };
                    InverseTransform.TransformPoints(points);

                    // See which cell contains the inverted point.
                    foreach (Cell cell in Cells)
                    {
                        if (cell.ContainsPoint(points[0]))
                        {
                            cell.Picture = new Bitmap(ofdCellPicture.FileName);
                            DocumentModified = true;
                            break;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                picCanvas.Refresh();
            }
        }

        private void txtDividerWidth_TextChanged(object sender, EventArgs e)
        {
            float width;
            if (float.TryParse(txtDividerWidth.Text, out width))
            {
                DividerWidth = width;
                picCanvas.Refresh();
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtWidth = new System.Windows.Forms.TextBox();
            this.txtHeight = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnCreate = new System.Windows.Forms.Button();
            this.picCanvas = new System.Windows.Forms.PictureBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFileSaveAs = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuFileExit = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtAngle = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtCellWidth = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtCellHeight = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lblColor = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtDividerWidth = new System.Windows.Forms.TextBox();
            this.cdDivider = new System.Windows.Forms.ColorDialog();
            this.sfdResult = new System.Windows.Forms.SaveFileDialog();
            this.ofdCellPicture = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.picCanvas)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Width:";
            // 
            // txtWidth
            // 
            this.txtWidth.Location = new System.Drawing.Point(68, 19);
            this.txtWidth.Name = "txtWidth";
            this.txtWidth.Size = new System.Drawing.Size(49, 20);
            this.txtWidth.TabIndex = 0;
            this.txtWidth.Text = "1000";
            this.txtWidth.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtHeight
            // 
            this.txtHeight.Location = new System.Drawing.Point(68, 45);
            this.txtHeight.Name = "txtHeight";
            this.txtHeight.Size = new System.Drawing.Size(49, 20);
            this.txtHeight.TabIndex = 1;
            this.txtHeight.Text = "300";
            this.txtHeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Height:";
            // 
            // btnCreate
            // 
            this.btnCreate.Location = new System.Drawing.Point(285, 70);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(75, 23);
            this.btnCreate.TabIndex = 2;
            this.btnCreate.Text = "Create";
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // picCanvas
            // 
            this.picCanvas.BackColor = System.Drawing.Color.White;
            this.picCanvas.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.picCanvas.Location = new System.Drawing.Point(12, 133);
            this.picCanvas.Name = "picCanvas";
            this.picCanvas.Size = new System.Drawing.Size(32, 32);
            this.picCanvas.TabIndex = 11;
            this.picCanvas.TabStop = false;
            this.picCanvas.Visible = false;
            this.picCanvas.MouseClick += new System.Windows.Forms.MouseEventHandler(this.picCanvas_MouseClick);
            this.picCanvas.Paint += new System.Windows.Forms.PaintEventHandler(this.picCanvas_Paint);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(506, 24);
            this.menuStrip1.TabIndex = 14;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFileSaveAs,
            this.toolStripMenuItem1,
            this.mnuFileExit});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
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
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtWidth);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtHeight);
            this.groupBox1.Location = new System.Drawing.Point(12, 27);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(130, 100);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Image";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtAngle);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.txtCellWidth);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.txtCellHeight);
            this.groupBox2.Location = new System.Drawing.Point(149, 27);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(130, 100);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Cells";
            // 
            // txtAngle
            // 
            this.txtAngle.Location = new System.Drawing.Point(68, 71);
            this.txtAngle.Name = "txtAngle";
            this.txtAngle.Size = new System.Drawing.Size(49, 20);
            this.txtAngle.TabIndex = 2;
            this.txtAngle.Text = "-25";
            this.txtAngle.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(21, 74);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 13);
            this.label5.TabIndex = 3;
            this.label5.Text = "Angle:";
            // 
            // txtCellWidth
            // 
            this.txtCellWidth.Location = new System.Drawing.Point(68, 19);
            this.txtCellWidth.Name = "txtCellWidth";
            this.txtCellWidth.Size = new System.Drawing.Size(49, 20);
            this.txtCellWidth.TabIndex = 0;
            this.txtCellWidth.Text = "140";
            this.txtCellWidth.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(21, 22);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(38, 13);
            this.label7.TabIndex = 3;
            this.label7.Text = "Width:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(21, 48);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(41, 13);
            this.label8.TabIndex = 6;
            this.label8.Text = "Height:";
            // 
            // txtCellHeight
            // 
            this.txtCellHeight.Location = new System.Drawing.Point(68, 45);
            this.txtCellHeight.Name = "txtCellHeight";
            this.txtCellHeight.Size = new System.Drawing.Size(49, 20);
            this.txtCellHeight.TabIndex = 1;
            this.txtCellHeight.Text = "200";
            this.txtCellHeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.lblColor);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.txtDividerWidth);
            this.groupBox3.Location = new System.Drawing.Point(366, 27);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(130, 100);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Divider";
            // 
            // lblColor
            // 
            this.lblColor.BackColor = System.Drawing.Color.LightBlue;
            this.lblColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblColor.Location = new System.Drawing.Point(68, 45);
            this.lblColor.Name = "lblColor";
            this.lblColor.Size = new System.Drawing.Size(49, 20);
            this.lblColor.TabIndex = 1;
            this.lblColor.Click += new System.EventHandler(this.lblColor_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Color:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(21, 22);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(38, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "Width:";
            // 
            // txtDividerWidth
            // 
            this.txtDividerWidth.Location = new System.Drawing.Point(68, 19);
            this.txtDividerWidth.Name = "txtDividerWidth";
            this.txtDividerWidth.Size = new System.Drawing.Size(49, 20);
            this.txtDividerWidth.TabIndex = 0;
            this.txtDividerWidth.Text = "8";
            this.txtDividerWidth.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtDividerWidth.TextChanged += new System.EventHandler(this.txtDividerWidth_TextChanged);
            // 
            // sfdResult
            // 
            this.sfdResult.DefaultExt = "png";
            this.sfdResult.Filter = "Picture Files|*.bmp;*.jpg;*.gif;*.png;*.tif|All Files|*.*";
            // 
            // ofdCellPicture
            // 
            this.ofdCellPicture.DefaultExt = "png";
            this.ofdCellPicture.Filter = "Picture Files|*.bmp;*.jpg;*.gif;*.png;*.tif|All Files|*.*";
            // 
            // howto_diagonal_images_Form1
            // 
            this.AcceptButton = this.btnCreate;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(506, 204);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.picCanvas);
            this.Controls.Add(this.btnCreate);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "howto_diagonal_images_Form1";
            this.Text = "howto_diagonal_images";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.howto_diagonal_images_Form1_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.picCanvas)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtWidth;
        private System.Windows.Forms.TextBox txtHeight;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.PictureBox picCanvas;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuFileSaveAs;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem mnuFileExit;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtCellWidth;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtCellHeight;
        private System.Windows.Forms.TextBox txtAngle;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label lblColor;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtDividerWidth;
        private System.Windows.Forms.ColorDialog cdDivider;
        private System.Windows.Forms.SaveFileDialog sfdResult;
        private System.Windows.Forms.OpenFileDialog ofdCellPicture;
    }
}

