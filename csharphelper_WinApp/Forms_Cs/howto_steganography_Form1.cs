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
     public partial class howto_steganography_Form1:Form
  { 


        public howto_steganography_Form1()
        {
            InitializeComponent();
        }

        // The unmodified and modified pictures.
        private Bitmap 
            OriginalImage = null,
            EncodedImage = null,
            MarkedImage = null;

        // Exit.
        private void mnuFileExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Load a picture.
        private void mnuFileOpen_Click(object sender, EventArgs e)
        {
            if (ofdImage.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    OriginalImage = new Bitmap(ofdImage.FileName);
                    MarkedImage = null;
                    EncodedImage = null;
                    radOriginal.Checked = true;
                    picImage.Image = OriginalImage;
                    mnuFileSave.Enabled = false;
                    btnEncode.Enabled = true;
                    btnDecode.Enabled = true;

                    // Size to show the whole picture.
                    int wid = Math.Max(this.ClientSize.Width,
                        picImage.Bounds.Right + picImage.Left);
                    int hgt = Math.Max(this.ClientSize.Height,
                        picImage.Bounds.Bottom + picImage.Left);
                    this.ClientSize = new Size(wid, hgt);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        // Save the modified picture.
        private void mnuFileSave_Click(object sender, EventArgs e)
        {
            if (EncodedImage == null)
            {
                MessageBox.Show("You have not added a message to the image.");
            }
            else
            {
                if (sfdImage.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        FileInfo file_info = new FileInfo(sfdImage.FileName);
                        switch (file_info.Extension)
                        {
                            case ".png":
                                EncodedImage.Save(sfdImage.FileName, ImageFormat.Png);
                                break;
                            case ".bmp":
                                EncodedImage.Save(sfdImage.FileName, ImageFormat.Bmp);
                                break;
                            case ".gif":
                                EncodedImage.Save(sfdImage.FileName, ImageFormat.Gif);
                                break;
                            case ".tiff":
                            case ".tif":
                                EncodedImage.Save(sfdImage.FileName, ImageFormat.Tiff);
                                break;
                            case ".jpg":
                            case ".jpeg":
                                EncodedImage.Save(sfdImage.FileName, ImageFormat.Jpeg);
                                break;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
        }

        // Encode the message in the picture.
        private void btnEncode_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            Application.DoEvents();

            // Copy the original message.
            EncodedImage = (Bitmap)OriginalImage.Clone();
            MarkedImage = (Bitmap)OriginalImage.Clone();

            // Encode.
            try
            {
                EncodeMessageInImage(EncodedImage, MarkedImage,
                    txtPassword.Text, txtMessage.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            // Display the results.
            radMarked.Checked = true;
            picImage.Image = MarkedImage;

            mnuFileSave.Enabled = true;
            this.Cursor = Cursors.Default;
        }

        // Encode a message into an image.
        private void EncodeMessageInImage(Bitmap bm, Bitmap visible_bm, string password, string message)
        {
            // Initialize a random number generator.
            Random rand = new Random(NumericPassword(password));

            // Create a new HashSet.
            HashSet<string> used_positions = new HashSet<string>();

            // Encode the message length.
            byte[] bytes = BitConverter.GetBytes(message.Length);
            for (int i=0; i < bytes.Length; i++)
            {
                EncodeByte(bm, visible_bm, rand, bytes[i], used_positions);
            }

            // Encode the message.
            char[] chars = message.ToCharArray();
            for (int i = 0; i < chars.Length; i++)
            {
                EncodeByte(bm, visible_bm, rand, (byte)chars[i], used_positions);
            }
        }

        // Encode a byte in the picture.
        private void EncodeByte(Bitmap bm, Bitmap visible_bm, Random rand,
            byte value, HashSet<string> used_positions)
        {
            for (int i = 0; i < 8; i++)
            {
                // Pick a position for the ith bit.
                int row, col, pix;
                PickPosition(bm, rand, used_positions, out row, out col, out pix);

                // Get the color's pixel components.
                Color clr = bm.GetPixel(row, col);
                byte r = clr.R;
                byte g = clr.G;
                byte b = clr.B;

                // Get the next bit to store.
                int bit = 0;
                if ((value & 1) == 1) bit = 1;
                
                // Update the color.
                switch (pix)
                {
                    case 0:
                        r = (byte)((r & 0xFE) | bit);
                        break;
                    case 1:
                        g = (byte)((g & 0xFE) | bit);
                        break;
                    case 2:
                        b = (byte)((b & 0xFE) | bit);
                        break;
                }
                clr = Color.FromArgb(clr.A, r, g, b);
                bm.SetPixel(row, col, clr);

                // Display a red pixel.
                visible_bm.SetPixel(row, col, Color.Red);

                // Move to the next bit in the value.
                value >>= 1;
            }
        }

        // Pick an unused (r, c, pixel) combination.
        private void PickPosition(Bitmap bm, Random rand,
            HashSet<string> used_positions,
            out int row, out int col, out int pix)
        {
            for ( ; ; )
            {
                // Pick random r, c, and pix.
                row = rand.Next(0, bm.Width);
                col = rand.Next(0, bm.Height);
                pix = rand.Next(0, 3);

                // See if this location is available.
                string key = 
                    row.ToString() + "/" +
                    col.ToString() + "/" +
                    pix.ToString();
                if (!used_positions.Contains(key)) 
                {
                    used_positions.Add(key);
                    return;
                }
            }
        }

        // Convert a string password into a numeric value.
        private int NumericPassword(string password)
        {
            // Initialize the shift values to different non-zero values.
            int shift1 = 3;
            int shift2 = 17;

            // Process the message.
            char[] chars = password.ToCharArray();
            int value = 0;
            for (int i = 1; i < password.Length; i++)
            {
                // Add the next letter.
                int ch_value = (int)chars[i];
                value ^= (ch_value << shift1);
                value ^= (ch_value << shift2);

                // Change the shifts.
                shift1 = (shift1 + 7) % 19;
                shift2 = (shift2 + 13) % 23;
            }
            return value;            
        }

        // Display the appropriate image.
        private void radOriginal_CheckedChanged(object sender, EventArgs e)
        {
            picImage.Image = OriginalImage;
        }
        private void radEncoded_CheckedChanged(object sender, EventArgs e)
        {
            picImage.Image = EncodedImage;
        }
        private void radMarked_CheckedChanged(object sender, EventArgs e)
        {
            picImage.Image = MarkedImage;
        }

        // Decode the message in the picture.
        private void btnDecode_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            txtMessage.Text = "";
            Application.DoEvents();

            // Decode.
            try
            {
                txtMessage.Text = DecodeMessageInImage(OriginalImage, txtPassword.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            this.Cursor = Cursors.Default;
        }

        // Decode the message hidden in a picture.
        private string DecodeMessageInImage(Bitmap bm, string password)
        {
            // Initialize a random number generator.
            Random rand = new Random(NumericPassword(password));

            // Create a new HashSet.
            HashSet<string> used_positions = new HashSet<string>();

            // Make a byte array big enough to hold the message length.
            int len = 0;
            byte[] bytes = BitConverter.GetBytes(len);

            // Decode the message length.
            for (int i = 0; i < bytes.Length; i++)
            {
                bytes[i] = DecodeByte(bm, rand, used_positions);
            }
            len = BitConverter.ToInt32(bytes, 0);

            // Sanity check.
            if (len > 10000)
            {
                throw new InvalidDataException(
                    "Message length " + len.ToString() +
                    " is too big to make sense. Invalid password.");
            }

            // Decode the message bytes.
            char[] chars = new char[len];
            for (int i = 0; i < chars.Length; i++)
            {
                chars[i] = (char)DecodeByte(bm, rand, used_positions);
            }
            return new string(chars);
        }

        // Decode a byte.
        private byte DecodeByte(Bitmap bm, Random rand, HashSet<string> used_positions)
        {
            byte value = 0;
            byte value_mask = 1;
            for (int i = 0; i < 8; i++)
            {
                // Find the position for the ith bit.
                int row, col, pix;
                PickPosition(bm, rand, used_positions, out row, out col, out pix);

                // Get the color component value.
                byte color_value = 0;
                switch (pix)
                {
                    case 0:
                        color_value = bm.GetPixel(row, col).R;
                        break;
                    case 1:
                        color_value = bm.GetPixel(row, col).G;
                        break;
                    case 2:
                        color_value = bm.GetPixel(row, col).B;
                        break;
                }

                // Set the next bit if appropriate.
                if ((color_value & 1) == 1)
                {
                    // Set the bit.
                    value = (byte)(value | value_mask);
                }

                // Move to the next bit.
                value_mask <<= 1;
            }

            return value;
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
            this.mnuFileExit = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.txtMessage = new System.Windows.Forms.TextBox();
            this.picImage = new System.Windows.Forms.PictureBox();
            this.btnEncode = new System.Windows.Forms.Button();
            this.btnDecode = new System.Windows.Forms.Button();
            this.sfdImage = new System.Windows.Forms.SaveFileDialog();
            this.ofdImage = new System.Windows.Forms.OpenFileDialog();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.radOriginal = new System.Windows.Forms.RadioButton();
            this.radEncoded = new System.Windows.Forms.RadioButton();
            this.radMarked = new System.Windows.Forms.RadioButton();
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
            this.menuStrip1.Size = new System.Drawing.Size(470, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFileOpen,
            this.mnuFileSave,
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
            this.mnuFileOpen.Size = new System.Drawing.Size(186, 22);
            this.mnuFileOpen.Text = "&Open Picture";
            this.mnuFileOpen.Click += new System.EventHandler(this.mnuFileOpen_Click);
            // 
            // mnuFileSave
            // 
            this.mnuFileSave.Name = "mnuFileSave";
            this.mnuFileSave.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.mnuFileSave.Size = new System.Drawing.Size(186, 22);
            this.mnuFileSave.Text = "&Save Picture";
            this.mnuFileSave.Click += new System.EventHandler(this.mnuFileSave_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(183, 6);
            // 
            // mnuFileExit
            // 
            this.mnuFileExit.Name = "mnuFileExit";
            this.mnuFileExit.Size = new System.Drawing.Size(186, 22);
            this.mnuFileExit.Text = "E&xit";
            this.mnuFileExit.Click += new System.EventHandler(this.mnuFileExit_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Message:";
            // 
            // txtMessage
            // 
            this.txtMessage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMessage.Location = new System.Drawing.Point(74, 53);
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.Size = new System.Drawing.Size(384, 20);
            this.txtMessage.TabIndex = 1;
            this.txtMessage.Text = "This is the secret message!";
            // 
            // picImage
            // 
            this.picImage.Location = new System.Drawing.Point(12, 108);
            this.picImage.Name = "picImage";
            this.picImage.Size = new System.Drawing.Size(89, 80);
            this.picImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picImage.TabIndex = 3;
            this.picImage.TabStop = false;
            // 
            // btnEncode
            // 
            this.btnEncode.Enabled = false;
            this.btnEncode.Location = new System.Drawing.Point(12, 79);
            this.btnEncode.Name = "btnEncode";
            this.btnEncode.Size = new System.Drawing.Size(75, 23);
            this.btnEncode.TabIndex = 2;
            this.btnEncode.Text = "Encode";
            this.btnEncode.UseVisualStyleBackColor = true;
            this.btnEncode.Click += new System.EventHandler(this.btnEncode_Click);
            // 
            // btnDecode
            // 
            this.btnDecode.Enabled = false;
            this.btnDecode.Location = new System.Drawing.Point(93, 79);
            this.btnDecode.Name = "btnDecode";
            this.btnDecode.Size = new System.Drawing.Size(75, 23);
            this.btnDecode.TabIndex = 3;
            this.btnDecode.Text = "Decode";
            this.btnDecode.UseVisualStyleBackColor = true;
            this.btnDecode.Click += new System.EventHandler(this.btnDecode_Click);
            // 
            // sfdImage
            // 
            this.sfdImage.Filter = "Lossless Image Files|*.bmp;*.png;*.tiff|Lossy Image Files|*.jpg;*.gif|All Files|*" +
                ".*";
            // 
            // ofdImage
            // 
            this.ofdImage.DefaultExt = "png";
            this.ofdImage.FileName = "openFileDialog1";
            this.ofdImage.Filter = "Lossless Image Files|*.bmp;*.png;*.tiff|Lossy Image Files|*.jpg;*.gif|All Files|*" +
                ".*";
            // 
            // txtPassword
            // 
            this.txtPassword.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPassword.Location = new System.Drawing.Point(74, 27);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(384, 20);
            this.txtPassword.TabIndex = 0;
            this.txtPassword.Text = "Password";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Password:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(174, 84);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Show:";
            // 
            // radOriginal
            // 
            this.radOriginal.AutoSize = true;
            this.radOriginal.Location = new System.Drawing.Point(217, 82);
            this.radOriginal.Name = "radOriginal";
            this.radOriginal.Size = new System.Drawing.Size(60, 17);
            this.radOriginal.TabIndex = 8;
            this.radOriginal.TabStop = true;
            this.radOriginal.Text = "Original";
            this.radOriginal.UseVisualStyleBackColor = true;
            this.radOriginal.CheckedChanged += new System.EventHandler(this.radOriginal_CheckedChanged);
            // 
            // radEncoded
            // 
            this.radEncoded.AutoSize = true;
            this.radEncoded.Location = new System.Drawing.Point(283, 82);
            this.radEncoded.Name = "radEncoded";
            this.radEncoded.Size = new System.Drawing.Size(68, 17);
            this.radEncoded.TabIndex = 9;
            this.radEncoded.TabStop = true;
            this.radEncoded.Text = "Encoded";
            this.radEncoded.UseVisualStyleBackColor = true;
            this.radEncoded.CheckedChanged += new System.EventHandler(this.radEncoded_CheckedChanged);
            // 
            // radMarked
            // 
            this.radMarked.AutoSize = true;
            this.radMarked.Location = new System.Drawing.Point(357, 82);
            this.radMarked.Name = "radMarked";
            this.radMarked.Size = new System.Drawing.Size(61, 17);
            this.radMarked.TabIndex = 10;
            this.radMarked.TabStop = true;
            this.radMarked.Text = "Marked";
            this.radMarked.UseVisualStyleBackColor = true;
            this.radMarked.CheckedChanged += new System.EventHandler(this.radMarked_CheckedChanged);
            // 
            // howto_steganography_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(470, 264);
            this.Controls.Add(this.radMarked);
            this.Controls.Add(this.radEncoded);
            this.Controls.Add(this.radOriginal);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnDecode);
            this.Controls.Add(this.btnEncode);
            this.Controls.Add(this.picImage);
            this.Controls.Add(this.txtMessage);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "howto_steganography_Form1";
            this.Text = "howto_steganography";
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
        private System.Windows.Forms.ToolStripMenuItem mnuFileSave;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem mnuFileExit;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtMessage;
        private System.Windows.Forms.PictureBox picImage;
        private System.Windows.Forms.Button btnEncode;
        private System.Windows.Forms.Button btnDecode;
        private System.Windows.Forms.SaveFileDialog sfdImage;
        private System.Windows.Forms.OpenFileDialog ofdImage;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton radOriginal;
        private System.Windows.Forms.RadioButton radEncoded;
        private System.Windows.Forms.RadioButton radMarked;
    }
}

