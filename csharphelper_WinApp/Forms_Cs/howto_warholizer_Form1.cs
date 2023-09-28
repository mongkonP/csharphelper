using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

using System.Drawing.Imaging;
using System.IO;

 

using howto_warholizer;
namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_warholizer_Form1:Form
  { 


        public howto_warholizer_Form1()
        {
            InitializeComponent();
        }

        // Warholize.
        private void btnGo_Click(object sender, EventArgs e)
        {
            picOutput.Image = null;
            picOutput.Refresh();

            // Get the input and output color data.
            PictureBox[] in_boxes = { picFromColor0, picFromColor1, picFromColor2, picFromColor3, picFromColor4 };
            PictureBox[] out_boxes = { picToColor0, picToColor1, picToColor2, picToColor3, picToColor4 };
            byte[] in_r = new byte[in_boxes.Length];
            byte[] in_g = new byte[in_boxes.Length];
            byte[] in_b = new byte[in_boxes.Length];
            byte[] out_r = new byte[in_boxes.Length];
            byte[] out_g = new byte[in_boxes.Length];
            byte[] out_b = new byte[in_boxes.Length];
            for (int i = 0; i < in_boxes.Length; i++)
            {
                in_r[i] = in_boxes[i].BackColor.R;
                in_g[i] = in_boxes[i].BackColor.G;
                in_b[i] = in_boxes[i].BackColor.B;
                out_r[i] = out_boxes[i].BackColor.R;
                out_g[i] = out_boxes[i].BackColor.G;
                out_b[i] = out_boxes[i].BackColor.B;
            }

            // Get and lock the Bitmap32.
            Bitmap original_bm = picInput.Image as Bitmap;
            Bitmap bm = new Bitmap(original_bm);
            Bitmap32 bm32 = new Bitmap32(bm);
            bm32.LockBitmap();

            // Process the pixels.
            for (int y = 0; y < bm.Height; y++)
            {
                for (int x = 0; x < bm.Width; x++)
                {
                    // Process pixel (row, col).
                    byte r, g, b, a;
                    bm32.GetPixel(x, y, out r, out g, out b, out a);
                    int best_i = 0;
                    int best_dist = int.MaxValue;
                    for (int i = 0; i < in_boxes.Length; i++)
                    {
                        // Compute the distance from this pixel to input pixel i.
                        int dr = r - in_r[i];
                        int dg = g - in_g[i];
                        int db = b - in_b[i];
                        int dist = dr * dr + dg * dg + db * db;

                        // See if this is an improvement.
                        if (dist < best_dist)
                        {
                            best_dist = dist;
                            best_i = i;
                        }
                    }

                    // Update the pixel.
                    bm32.SetPixel(x, y, out_r[best_i], out_g[best_i], out_b[best_i], 255);
                }
            }

            // Unlock the Bitmap32.
            bm32.UnlockBitmap();

            // Display the result.
            picOutput.Image = bm;
        }

        // Let the user pick a new color.
        private void picColor_Click(object sender, EventArgs e)
        {
            PictureBox pic = sender as PictureBox;
            cdColor.Color = pic.BackColor;
            if (cdColor.ShowDialog() == DialogResult.OK)
            {
                pic.BackColor = cdColor.Color;
            }
        }

        // Let the user select a file.
        private void mnuFileOpen_Click(object sender, EventArgs e)
        {
            if (ofdOriginal.ShowDialog() == DialogResult.OK)
            {
                int margin = picInput.Left;
                picInput.Image = Bitmap.FromFile(ofdOriginal.FileName);
                picOutput.Image = null;
                picOutput.Left = picInput.Right + margin;
                picOutput.ClientSize = picInput.ClientSize;
                this.ClientSize = new Size(
                    picOutput.Right + margin,
                    picOutput.Bottom + margin);
            }
        }

        // Save the result image.
        private void mnuFileSave_Click(object sender, EventArgs e)
        {
            if (sfdResult.ShowDialog() == DialogResult.OK)
            {
                SaveBitmapUsingExtension(picOutput.Image as Bitmap, sfdResult.FileName);
            }
        }

        // Save the file with the appropriate format.
        // Throw a NotSupportedException if the file
        // has an unknown extension.
        public void SaveBitmapUsingExtension(Bitmap bm, string filename)
        {
            string extension = Path.GetExtension(filename);
            switch (extension.ToLower())
            {
                case ".bmp":
                    bm.Save(filename, ImageFormat.Bmp);
                    break;
                case ".exif":
                    bm.Save(filename, ImageFormat.Exif);
                    break;
                case ".gif":
                    bm.Save(filename, ImageFormat.Gif);
                    break;
                case ".jpg":
                case ".jpeg":
                    bm.Save(filename, ImageFormat.Jpeg);
                    break;
                case ".png":
                    bm.Save(filename, ImageFormat.Png);
                    break;
                case ".tif":
                case ".tiff":
                    bm.Save(filename, ImageFormat.Tiff);
                    break;
                default:
                    throw new NotSupportedException(
                        "Unknown file extension " + extension);
            }
        }

        // Standard color sets.
        private void mnuColorsSet1_Click(object sender, EventArgs e)
        {
            picFromColor0.BackColor = Color.Red;
            picFromColor1.BackColor = Color.Green;
            picFromColor2.BackColor = Color.Blue;
            picFromColor3.BackColor = Color.Black;
            picFromColor4.BackColor = Color.White;
            picToColor0.BackColor = Color.Red;
            picToColor1.BackColor = Color.Green;
            picToColor2.BackColor = Color.Blue;
            picToColor3.BackColor = Color.Black;
            picToColor4.BackColor = Color.White;
        }

        private void mnuColorsSet2_Click(object sender, EventArgs e)
        {
            picFromColor0.BackColor = Color.Red;
            picFromColor1.BackColor = Color.Green;
            picFromColor2.BackColor = Color.Blue;
            picFromColor3.BackColor = Color.Black;
            picFromColor4.BackColor = Color.White;
            picToColor0.BackColor = Color.Yellow;
            picToColor1.BackColor = Color.Orange;
            picToColor2.BackColor = Color.Purple;
            picToColor3.BackColor = Color.Violet;
            picToColor4.BackColor = Color.Lime;
        }

        private void mnuColorsSet3_Click(object sender, EventArgs e)
        {
            picFromColor0.BackColor = Color.Pink;
            picFromColor1.BackColor = Color.LightGreen;
            picFromColor2.BackColor = Color.LightBlue;
            picFromColor3.BackColor = Color.Gray;
            picFromColor4.BackColor = Color.White;
            picToColor0.BackColor = Color.Pink;
            picToColor1.BackColor = Color.LightGreen;
            picToColor2.BackColor = Color.LightBlue;
            picToColor3.BackColor = Color.Gray;
            picToColor4.BackColor = Color.White;
        }

        private void mnuColorsSet4_Click(object sender, EventArgs e)
        {
            picFromColor0.BackColor = Color.Red;
            picFromColor1.BackColor = Color.Green;
            picFromColor2.BackColor = Color.Blue;
            picFromColor3.BackColor = Color.Black;
            picFromColor4.BackColor = Color.White;
            picToColor0.BackColor = Color.Pink;
            picToColor1.BackColor = Color.LightGreen;
            picToColor2.BackColor = Color.LightBlue;
            picToColor3.BackColor = Color.Gray;
            picToColor4.BackColor = Color.Khaki;
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
            this.ofdOriginal = new System.Windows.Forms.OpenFileDialog();
            this.picToColor4 = new System.Windows.Forms.PictureBox();
            this.picToColor3 = new System.Windows.Forms.PictureBox();
            this.mnuColorsSet2 = new System.Windows.Forms.ToolStripMenuItem();
            this.btnGo = new System.Windows.Forms.Button();
            this.mnuColorsSet1 = new System.Windows.Forms.ToolStripMenuItem();
            this.picToColor2 = new System.Windows.Forms.PictureBox();
            this.mnuColors = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuColorsSet3 = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuColorsSet4 = new System.Windows.Forms.ToolStripMenuItem();
            this.picToColor0 = new System.Windows.Forms.PictureBox();
            this.picToColor1 = new System.Windows.Forms.PictureBox();
            this.picFromColor4 = new System.Windows.Forms.PictureBox();
            this.picFromColor3 = new System.Windows.Forms.PictureBox();
            this.picFromColor2 = new System.Windows.Forms.PictureBox();
            this.mnuFileSave = new System.Windows.Forms.ToolStripMenuItem();
            this.picFromColor1 = new System.Windows.Forms.PictureBox();
            this.cdColor = new System.Windows.Forms.ColorDialog();
            this.picOutput = new System.Windows.Forms.PictureBox();
            this.sfdResult = new System.Windows.Forms.SaveFileDialog();
            this.picFromColor0 = new System.Windows.Forms.PictureBox();
            this.mnuFileOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.picInput = new System.Windows.Forms.PictureBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.mnuFile = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.picToColor4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picToColor3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picToColor2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picToColor0)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picToColor1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picFromColor4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picFromColor3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picFromColor2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picFromColor1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picOutput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picFromColor0)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picInput)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ofdOriginal
            // 
            this.ofdOriginal.FileName = "openFileDialog1";
            this.ofdOriginal.Filter = "Image Files|*.bmp;*.jpg;*.gif;*.tif;*.png|All Files|*.*";
            // 
            // picToColor4
            // 
            this.picToColor4.BackColor = System.Drawing.Color.White;
            this.picToColor4.Location = new System.Drawing.Point(164, 70);
            this.picToColor4.Name = "picToColor4";
            this.picToColor4.Size = new System.Drawing.Size(32, 32);
            this.picToColor4.TabIndex = 25;
            this.picToColor4.TabStop = false;
            this.picToColor4.Click += new System.EventHandler(this.picColor_Click);
            // 
            // picToColor3
            // 
            this.picToColor3.BackColor = System.Drawing.Color.Black;
            this.picToColor3.Location = new System.Drawing.Point(126, 70);
            this.picToColor3.Name = "picToColor3";
            this.picToColor3.Size = new System.Drawing.Size(32, 32);
            this.picToColor3.TabIndex = 24;
            this.picToColor3.TabStop = false;
            this.picToColor3.Click += new System.EventHandler(this.picColor_Click);
            // 
            // mnuColorsSet2
            // 
            this.mnuColorsSet2.Name = "mnuColorsSet2";
            this.mnuColorsSet2.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D2)));
            this.mnuColorsSet2.Size = new System.Drawing.Size(152, 22);
            this.mnuColorsSet2.Text = "Set &2";
            this.mnuColorsSet2.Click += new System.EventHandler(this.mnuColorsSet2_Click);
            // 
            // btnGo
            // 
            this.btnGo.Location = new System.Drawing.Point(202, 57);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(75, 23);
            this.btnGo.TabIndex = 26;
            this.btnGo.Text = "Go";
            this.btnGo.UseVisualStyleBackColor = true;
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // mnuColorsSet1
            // 
            this.mnuColorsSet1.Name = "mnuColorsSet1";
            this.mnuColorsSet1.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D1)));
            this.mnuColorsSet1.Size = new System.Drawing.Size(152, 22);
            this.mnuColorsSet1.Text = "Set &1";
            this.mnuColorsSet1.Click += new System.EventHandler(this.mnuColorsSet1_Click);
            // 
            // picToColor2
            // 
            this.picToColor2.BackColor = System.Drawing.Color.Blue;
            this.picToColor2.Location = new System.Drawing.Point(88, 70);
            this.picToColor2.Name = "picToColor2";
            this.picToColor2.Size = new System.Drawing.Size(32, 32);
            this.picToColor2.TabIndex = 23;
            this.picToColor2.TabStop = false;
            this.picToColor2.Click += new System.EventHandler(this.picColor_Click);
            // 
            // mnuColors
            // 
            this.mnuColors.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuColorsSet1,
            this.mnuColorsSet2,
            this.mnuColorsSet3,
            this.mnuColorsSet4});
            this.mnuColors.Name = "mnuColors";
            this.mnuColors.Size = new System.Drawing.Size(53, 20);
            this.mnuColors.Text = "&Colors";
            // 
            // mnuColorsSet3
            // 
            this.mnuColorsSet3.Name = "mnuColorsSet3";
            this.mnuColorsSet3.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D3)));
            this.mnuColorsSet3.Size = new System.Drawing.Size(152, 22);
            this.mnuColorsSet3.Text = "Set &3";
            this.mnuColorsSet3.Click += new System.EventHandler(this.mnuColorsSet3_Click);
            // 
            // mnuColorsSet4
            // 
            this.mnuColorsSet4.Name = "mnuColorsSet4";
            this.mnuColorsSet4.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D4)));
            this.mnuColorsSet4.Size = new System.Drawing.Size(152, 22);
            this.mnuColorsSet4.Text = "Set &4";
            this.mnuColorsSet4.Click += new System.EventHandler(this.mnuColorsSet4_Click);
            // 
            // picToColor0
            // 
            this.picToColor0.BackColor = System.Drawing.Color.Red;
            this.picToColor0.Location = new System.Drawing.Point(12, 70);
            this.picToColor0.Name = "picToColor0";
            this.picToColor0.Size = new System.Drawing.Size(32, 32);
            this.picToColor0.TabIndex = 21;
            this.picToColor0.TabStop = false;
            this.picToColor0.Click += new System.EventHandler(this.picColor_Click);
            // 
            // picToColor1
            // 
            this.picToColor1.BackColor = System.Drawing.Color.Green;
            this.picToColor1.Location = new System.Drawing.Point(50, 70);
            this.picToColor1.Name = "picToColor1";
            this.picToColor1.Size = new System.Drawing.Size(32, 32);
            this.picToColor1.TabIndex = 22;
            this.picToColor1.TabStop = false;
            this.picToColor1.Click += new System.EventHandler(this.picColor_Click);
            // 
            // picFromColor4
            // 
            this.picFromColor4.BackColor = System.Drawing.Color.White;
            this.picFromColor4.Location = new System.Drawing.Point(164, 32);
            this.picFromColor4.Name = "picFromColor4";
            this.picFromColor4.Size = new System.Drawing.Size(32, 32);
            this.picFromColor4.TabIndex = 20;
            this.picFromColor4.TabStop = false;
            this.picFromColor4.Click += new System.EventHandler(this.picColor_Click);
            // 
            // picFromColor3
            // 
            this.picFromColor3.BackColor = System.Drawing.Color.Black;
            this.picFromColor3.Location = new System.Drawing.Point(126, 32);
            this.picFromColor3.Name = "picFromColor3";
            this.picFromColor3.Size = new System.Drawing.Size(32, 32);
            this.picFromColor3.TabIndex = 19;
            this.picFromColor3.TabStop = false;
            this.picFromColor3.Click += new System.EventHandler(this.picColor_Click);
            // 
            // picFromColor2
            // 
            this.picFromColor2.BackColor = System.Drawing.Color.Blue;
            this.picFromColor2.Location = new System.Drawing.Point(88, 32);
            this.picFromColor2.Name = "picFromColor2";
            this.picFromColor2.Size = new System.Drawing.Size(32, 32);
            this.picFromColor2.TabIndex = 18;
            this.picFromColor2.TabStop = false;
            this.picFromColor2.Click += new System.EventHandler(this.picColor_Click);
            // 
            // mnuFileSave
            // 
            this.mnuFileSave.Name = "mnuFileSave";
            this.mnuFileSave.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.mnuFileSave.Size = new System.Drawing.Size(155, 22);
            this.mnuFileSave.Text = "&Save...";
            this.mnuFileSave.Click += new System.EventHandler(this.mnuFileSave_Click);
            // 
            // picFromColor1
            // 
            this.picFromColor1.BackColor = System.Drawing.Color.Green;
            this.picFromColor1.Location = new System.Drawing.Point(50, 32);
            this.picFromColor1.Name = "picFromColor1";
            this.picFromColor1.Size = new System.Drawing.Size(32, 32);
            this.picFromColor1.TabIndex = 17;
            this.picFromColor1.TabStop = false;
            this.picFromColor1.Click += new System.EventHandler(this.picColor_Click);
            // 
            // picOutput
            // 
            this.picOutput.Location = new System.Drawing.Point(341, 108);
            this.picOutput.Name = "picOutput";
            this.picOutput.Size = new System.Drawing.Size(314, 314);
            this.picOutput.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picOutput.TabIndex = 15;
            this.picOutput.TabStop = false;
            // 
            // sfdResult
            // 
            this.sfdResult.Filter = "Image Files|*.bmp;*.jpg;*.gif;*.tif;*.png|All Files|*.*";
            // 
            // picFromColor0
            // 
            this.picFromColor0.BackColor = System.Drawing.Color.Red;
            this.picFromColor0.Location = new System.Drawing.Point(12, 32);
            this.picFromColor0.Name = "picFromColor0";
            this.picFromColor0.Size = new System.Drawing.Size(32, 32);
            this.picFromColor0.TabIndex = 16;
            this.picFromColor0.TabStop = false;
            this.picFromColor0.Click += new System.EventHandler(this.picColor_Click);
            // 
            // mnuFileOpen
            // 
            this.mnuFileOpen.Name = "mnuFileOpen";
            this.mnuFileOpen.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.mnuFileOpen.Size = new System.Drawing.Size(155, 22);
            this.mnuFileOpen.Text = "&Open...";
            this.mnuFileOpen.Click += new System.EventHandler(this.mnuFileOpen_Click);
            // 
            // picInput
            // 
            this.picInput.Image = Properties.Resources.NoBg;
            this.picInput.Location = new System.Drawing.Point(12, 108);
            this.picInput.Name = "picInput";
            this.picInput.Size = new System.Drawing.Size(314, 314);
            this.picInput.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picInput.TabIndex = 14;
            this.picInput.TabStop = false;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFile,
            this.mnuColors});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(665, 24);
            this.menuStrip1.TabIndex = 27;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // mnuFile
            // 
            this.mnuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFileOpen,
            this.mnuFileSave});
            this.mnuFile.Name = "mnuFile";
            this.mnuFile.Size = new System.Drawing.Size(37, 20);
            this.mnuFile.Text = "&File";
            // 
            // howto_warholizer_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(665, 426);
            this.Controls.Add(this.picToColor4);
            this.Controls.Add(this.picToColor3);
            this.Controls.Add(this.btnGo);
            this.Controls.Add(this.picToColor2);
            this.Controls.Add(this.picToColor0);
            this.Controls.Add(this.picToColor1);
            this.Controls.Add(this.picFromColor4);
            this.Controls.Add(this.picFromColor3);
            this.Controls.Add(this.picFromColor2);
            this.Controls.Add(this.picFromColor1);
            this.Controls.Add(this.picOutput);
            this.Controls.Add(this.picFromColor0);
            this.Controls.Add(this.picInput);
            this.Controls.Add(this.menuStrip1);
            this.Name = "howto_warholizer_Form1";
            this.Text = "howto_warholizer";
            ((System.ComponentModel.ISupportInitialize)(this.picToColor4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picToColor3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picToColor2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picToColor0)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picToColor1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picFromColor4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picFromColor3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picFromColor2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picFromColor1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picOutput)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picFromColor0)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picInput)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog ofdOriginal;
        private System.Windows.Forms.PictureBox picToColor4;
        private System.Windows.Forms.PictureBox picToColor3;
        private System.Windows.Forms.ToolStripMenuItem mnuColorsSet2;
        private System.Windows.Forms.Button btnGo;
        private System.Windows.Forms.ToolStripMenuItem mnuColorsSet1;
        private System.Windows.Forms.PictureBox picToColor2;
        private System.Windows.Forms.ToolStripMenuItem mnuColors;
        private System.Windows.Forms.ToolStripMenuItem mnuColorsSet3;
        private System.Windows.Forms.ToolStripMenuItem mnuColorsSet4;
        private System.Windows.Forms.PictureBox picToColor0;
        private System.Windows.Forms.PictureBox picToColor1;
        private System.Windows.Forms.PictureBox picFromColor4;
        private System.Windows.Forms.PictureBox picFromColor3;
        private System.Windows.Forms.PictureBox picFromColor2;
        private System.Windows.Forms.ToolStripMenuItem mnuFileSave;
        private System.Windows.Forms.PictureBox picFromColor1;
        private System.Windows.Forms.ColorDialog cdColor;
        private System.Windows.Forms.PictureBox picOutput;
        private System.Windows.Forms.SaveFileDialog sfdResult;
        private System.Windows.Forms.PictureBox picFromColor0;
        private System.Windows.Forms.ToolStripMenuItem mnuFileOpen;
        private System.Windows.Forms.PictureBox picInput;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mnuFile;
    }
}

