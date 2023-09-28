using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.IO;

 

namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_stego_images_tiled2_Form1:Form
  { 


        public howto_stego_images_tiled2_Form1()
        {
            InitializeComponent();
        }

        // Hide and then recover the image.
        private void btnGo_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            int num_bits = (int)nudHiddenBits.Value;

            // Hide the image3.
            Bitmap combined;
            combined = HideResizedTiledImages(
                (Bitmap)picMainOriginal.Image,
                (Bitmap)picHiddenOriginal1.Image,
                (Bitmap)picHiddenOriginal2.Image,
                (Bitmap)picHiddenOriginal3.Image,
                (Bitmap)picHiddenOriginal4.Image,
                num_bits);
            picCombined.Image = combined;

            // Recover the hidden images.
            Bitmap hidden1, hidden2, hidden3, hidden4;
            RecoverResizedTiledImages(combined, out hidden1,
                out hidden2, out hidden3, out hidden4, num_bits);
            picHiddenRecovered1.Image = hidden1;
            picHiddenRecovered2.Image = hidden2;
            picHiddenRecovered3.Image = hidden3;
            picHiddenRecovered4.Image = hidden4;

            Cursor = Cursors.Default;
        }

        // Hide bm_hidden inside bm_visible and return the result.
        public Bitmap HideImage(Bitmap bm_visible, Bitmap bm_hidden, int hidden_bits)
        {
            int shift = (8 - hidden_bits);
            int visible_mask = 0xFF << hidden_bits;
            int hidden_mask = 0xFF >> shift;
            Bitmap bm_combined = new Bitmap(bm_visible.Width, bm_visible.Height);
            for (int x = 0; x < bm_visible.Width; x++)
            {
                for (int y = 0; y < bm_visible.Height; y++)
                {
                    Color clr_visible = bm_visible.GetPixel(x, y);
                    Color clr_hidden = bm_hidden.GetPixel(x, y);
                    int r = (clr_visible.R & visible_mask) + ((clr_hidden.R >> shift) & hidden_mask);
                    int g = (clr_visible.G & visible_mask) + ((clr_hidden.G >> shift) & hidden_mask);
                    int b = (clr_visible.B & visible_mask) + ((clr_hidden.B >> shift) & hidden_mask);
                    bm_combined.SetPixel(x, y, Color.FromArgb(255, r, g, b));
                }
            }
            return bm_combined;
        }

        // Recover a hidden image.
        public Bitmap RecoverImage(Bitmap bm_combined, int hidden_bits)
        {
            int shift = (8 - hidden_bits);
            int hidden_mask = 0xFF >> shift;
            Bitmap bm_hidden = new Bitmap(bm_combined.Width, bm_combined.Height);
            for (int x = 0; x < bm_combined.Width; x++)
            {
                for (int y = 0; y < bm_combined.Height; y++)
                {
                    Color clr_combined = bm_combined.GetPixel(x, y);
                    int r = (clr_combined.R & hidden_mask) << shift;
                    int g = (clr_combined.G & hidden_mask) << shift;
                    int b = (clr_combined.B & hidden_mask) << shift;
                    bm_hidden.SetPixel(x, y, Color.FromArgb(255, r, g, b));
                }
            }
            return bm_hidden;
        }

        // Hide the four hidden images inside bm_visible and return the result.
        public Bitmap HideTiledImages(Bitmap bm_visible,
            Bitmap hidden1, Bitmap hidden2, Bitmap hidden3,
            Bitmap hidden4, int hidden_bits)
        {
            // Tile the hidden images onto a
            // bitmap sized to fit the visible image.
            Bitmap bm = (Bitmap)bm_visible.Clone();
            int wid = bm.Width / 2;
            int hgt = bm.Height / 2;

            using (Graphics gr = Graphics.FromImage(bm))
            {
                Rectangle rect = new Rectangle(0, 0, wid, hgt);
                gr.DrawImage(hidden1, rect);

                rect.X += wid;
                gr.DrawImage(hidden2, rect);

                rect.X = 0;
                rect.Y += hgt;
                gr.DrawImage(hidden3, rect);

                rect.X += wid;
                gr.DrawImage(hidden4, rect);
            }

            // Hide the combined image in the main image.
            return HideImage(bm_visible, bm, hidden_bits);
        }

        // Recover four hidden images.
        public void RecoverTiledImages(Bitmap bm_combined,
            out Bitmap hidden1, out Bitmap hidden2,
            out Bitmap hidden3, out Bitmap hidden4, int hidden_bits)
        {
            // Recover the tiled image.
            Bitmap bm = RecoverImage(bm_combined, hidden_bits);

            // Pull out the pieces.
            int wid = bm_combined.Width / 2;
            int hgt = bm_combined.Height / 2;
            Rectangle dest = new Rectangle(0, 0, wid, hgt);

            Rectangle source = new Rectangle(0, 0, wid, hgt);
            hidden1 = new Bitmap(wid, hgt);
            using (Graphics gr = Graphics.FromImage(hidden1))
            {
                gr.DrawImage(bm, dest, source, GraphicsUnit.Pixel);
            }

            source.X += wid;
            hidden2 = new Bitmap(wid, hgt);
            using (Graphics gr = Graphics.FromImage(hidden2))
            {
                gr.DrawImage(bm, dest, source, GraphicsUnit.Pixel);
            }

            source.X = 0;
            source.Y += hgt;
            hidden3 = new Bitmap(wid, hgt);
            using (Graphics gr = Graphics.FromImage(hidden3))
            {
                gr.DrawImage(bm, dest, source, GraphicsUnit.Pixel);
            }

            source.X += wid;
            hidden4 = new Bitmap(wid, hgt);
            using (Graphics gr = Graphics.FromImage(hidden4))
            {
                gr.DrawImage(bm, dest, source, GraphicsUnit.Pixel);
            }
        }

        // Hide the four hidden images inside bm_visible and return the result.
        public Bitmap HideResizedTiledImages(Bitmap bm_visible,
            Bitmap hidden1, Bitmap hidden2, Bitmap hidden3,
            Bitmap hidden4, int hidden_bits)
        {
            // Resize the hidden images to fit.
            int wid = bm_visible.Width / 2;
            int hgt = bm_visible.Height / 2;
            Rectangle dest = new Rectangle(0, 0, wid, hgt);

            Bitmap bm1 = new Bitmap(wid, hgt);
            Rectangle source = new Rectangle(0, 0,
                hidden1.Width, hidden1.Height);
            using (Graphics gr = Graphics.FromImage(bm1))
            {
                gr.DrawImage(hidden1, dest, source, GraphicsUnit.Pixel);
            }

            Bitmap bm2 = new Bitmap(wid, hgt);
            source = new Rectangle(0, 0,
                hidden2.Width, hidden2.Height);
            using (Graphics gr = Graphics.FromImage(bm2))
            {
                gr.DrawImage(hidden2, dest, source, GraphicsUnit.Pixel);
            }

            Bitmap bm3 = new Bitmap(wid, hgt);
            source = new Rectangle(0, 0,
                hidden3.Width, hidden3.Height);
            using (Graphics gr = Graphics.FromImage(bm3))
            {
                gr.DrawImage(hidden3, dest, source, GraphicsUnit.Pixel);
            }

            Bitmap bm4 = new Bitmap(wid, hgt);
            source = new Rectangle(0, 0,
                hidden4.Width, hidden4.Height);
            using (Graphics gr = Graphics.FromImage(bm4))
            {
                gr.DrawImage(hidden4, dest, source, GraphicsUnit.Pixel);
            }

            // Hide the resized images.
            Bitmap combined = HideTiledImages(bm_visible,
                bm1, bm2, bm3, bm4, hidden_bits);

            // Hide the sizes of the original images in the result.
            int[] sizes =
            {
                hidden1.Width, hidden1.Height,
                hidden2.Width, hidden2.Height,
                hidden3.Width, hidden3.Height,
                hidden4.Width, hidden4.Height,
            };
            byte[] bytes = IntArrayToByteArray(sizes);
            int x = 0, y = 0;
            EncodeBytes(ref x, ref y, combined, bytes);

            return combined;
        }

        // Convert an int[] into a byte[].
        private byte[] IntArrayToByteArray(int[] ints)
        {
            byte[] result = new byte[ints.Length * sizeof(int)];
            Buffer.BlockCopy(ints, 0, result, 0, result.Length);
            return result;
        }

        // Convert a byte[] into an int[].
        private int[] ByteArrayToIntArray(byte[] bytes)
        {
            int[] result = new int[bytes.Length / sizeof(int)];
            Buffer.BlockCopy(bytes, 0, result, 0, bytes.Length);
            return result;
        }

        // Recover four resized tiled images.
        public void RecoverResizedTiledImages(Bitmap bm_combined,
            out Bitmap hidden1, out Bitmap hidden2,
            out Bitmap hidden3, out Bitmap hidden4, int hidden_bits)
        {
            // Get the image sizes.
            int x = 0, y = 0;
            byte[] bytes = DecodeBytes(ref x, ref y,
                4 * 2 * sizeof(int), bm_combined);
            int[] sizes = ByteArrayToIntArray(bytes);

            // Recover the resized tiled images.
            Bitmap bm1, bm2, bm3, bm4;
            RecoverTiledImages(bm_combined, out bm1,
                out bm2, out bm3, out bm4, hidden_bits);

            // Restore the images' original sizes.
            Rectangle dest;
            int wid = bm_combined.Width / 2;
            int hgt = bm_combined.Height / 2;
            Rectangle source = new Rectangle(0, 0, wid, hgt);
            int index = 0;

            wid = sizes[index++];
            hgt = sizes[index++];
            dest = new Rectangle(0, 0, wid, hgt);
            hidden1 = new Bitmap(wid, hgt);
            using (Graphics gr = Graphics.FromImage(hidden1))
            {
                gr.DrawImage(bm1, dest, source, GraphicsUnit.Pixel);
            }

            wid = sizes[index++];
            hgt = sizes[index++];
            dest = new Rectangle(0, 0, wid, hgt);
            hidden2 = new Bitmap(wid, hgt);
            using (Graphics gr = Graphics.FromImage(hidden2))
            {
                gr.DrawImage(bm2, dest, source, GraphicsUnit.Pixel);
            }

            wid = sizes[index++];
            hgt = sizes[index++];
            dest = new Rectangle(0, 0, wid, hgt);
            hidden3 = new Bitmap(wid, hgt);
            using (Graphics gr = Graphics.FromImage(hidden3))
            {
                gr.DrawImage(bm3, dest, source, GraphicsUnit.Pixel);
            }

            wid = sizes[index++];
            hgt = sizes[index++];
            dest = new Rectangle(0, 0, wid, hgt);
            hidden4 = new Bitmap(wid, hgt);
            using (Graphics gr = Graphics.FromImage(hidden4))
            {
                gr.DrawImage(bm4, dest, source, GraphicsUnit.Pixel);
            }
        }

        // Encode the message in the bitmap's bytes.
        private Bitmap EncodeMesssage(Bitmap bm, string message)
        {
            // Get the message as an array of bytes.
            byte[] message_bytes = System.Text.Encoding.UTF8.GetBytes(message);

            // Encode the bytes.
            return EncodeMesssageBytes(bm, message_bytes);
        }

        // Encode an array of bytes in the bitmap's bytes.
        private Bitmap EncodeMesssageBytes(Bitmap bm, byte[] message_bytes)
        {
            // Make sure it will fit.
            int message_length = message_bytes.Length;
            int space_available = bm.Width * bm.Height;
            if (message_length + 4 > space_available)
                throw new InvalidDataException(
                    "Message length " + message_bytes.Length +
                    " is too long. This image can hold only " +
                    space_available + " bytes.");

            int total_length = message_length + 4;

            // Make the result Bitmap.
            Bitmap result = bm.Clone() as Bitmap;

            // Records the location of the next pixel.
            int x = 0, y = 0;

            // Encode the message's length.
            byte[] length_bytes = BitConverter.GetBytes(message_length);
            EncodeBytes(ref x, ref y, result, length_bytes);

            // Encode the message.
            EncodeBytes(ref x, ref y, result, message_bytes);

            // Return the result.
            return result;
        }

        // Encode the bytes starting at pixel (row, col).
        private void EncodeBytes(ref int x, ref int y, Bitmap bm, byte[] bytes)
        {
            // Encode the bytes.
            for (int i = 0; i < bytes.Length; i++)
                EncodeByte(ref x, ref y, bm, bytes[i]);
        }

        // Encode a single byte at pixel (row, col).
        private void EncodeByte(ref int x, ref int y, Bitmap bm, byte b)
        {
            // Encode the byte's bits 3 at a time.
            EncodeBits(ref x, ref y, bm, b, 0, 1, 2, 3, 0);
            EncodeBits(ref x, ref y, bm, b, 4, 5, 6, 7, 1);
        }

        // Encode four bits. Values pos1 through pos4 give the
        // positions from the left of the bits in b to encode.
        // Value dest_bit gives the bit in the pixel that should
        // hold the values. It should be 0 or 1.
        private void EncodeBits(ref int x, ref int y, Bitmap bm,
            byte b, int pos1, int pos2, int pos3, int pos4, int dest_bit)
        {
            // Get the pixel's color.
            Color color = bm.GetPixel(x, y);

            // A mask to set the bit we are setting.
            byte only_1 = (byte)(0x01 << dest_bit);

            // A mask to clear all bits except the bit we're setting.
            byte clear_1 = (byte)(only_1 ^ 0xFF);

            // Add the bits to the color components.
            byte alpha, red, green, blue;
            pos1 -= dest_bit;
            byte bit1 = (byte)((b >> pos1) & only_1);
            alpha = (byte)((color.A & clear_1) | bit1);

            pos2 -= dest_bit;
            byte bit2 = (byte)((b >> pos2) & only_1);
            red = (byte)((color.R & clear_1) | bit2);

            pos3 -= dest_bit;
            byte bit3 = (byte)((b >> pos3) & only_1);
            green = (byte)((color.G & clear_1) | bit3);

            pos4 -= dest_bit;
            byte bit4 = (byte)((b >> pos4) & only_1);
            blue = (byte)((color.B & clear_1) | bit4);

            // Update the pixel.
            bm.SetPixel(x, y, Color.FromArgb(alpha, red, green, blue));

            // Move to the next pixel.
            if (dest_bit == 1) NextRowCol(ref x, ref y, bm);
        }

        // Increment row and col to the next pixel in the image.
        private void NextRowCol(ref int x, ref int y, Bitmap bm)
        {
            x++;
            if (x >= bm.Width)
            {
                x = 0;
                y++;
            }
        }

        // Decode the message in the bitmap.
        private string DecodeMesssage(Bitmap bm)
        {
            // Get the message bytes.
            byte[] message_bytes = DecodeMesssageBytes(bm);
            string result = System.Text.Encoding.UTF8.GetString(message_bytes);
            return result;
        }

        // Decode the message in the bitmap.
        private byte[] DecodeMesssageBytes(Bitmap bm)
        {
            // Decode the message's length.
            const int int_len = 4;
            int x = 0, y = 0;
            byte[] length_bytes = DecodeBytes(ref x, ref y, int_len, bm);
            int message_length = BitConverter.ToInt32(length_bytes, 0);

            // Get the message bytes.
            byte[] message_bytes = DecodeBytes(ref x, ref y, message_length, bm);
            return message_bytes;
        }

        // Decode the indicated number of bytes from the image.
        private byte[] DecodeBytes(ref int x, ref int y, int num_bytes, Bitmap bm)
        {
            byte[] bytes = new byte[num_bytes];
            for (int i = 0; i < num_bytes; i++)
                bytes[i] = DecodeByte(ref x, ref y, bm);
            return bytes;
        }

        // Decode a single byte starting at pixel (row, col).
        private byte DecodeByte(ref int x, ref int y, Bitmap bm)
        {
            // Decode the byte's bits 3 at a time.
            byte b = 0;
            DecodeBits(ref x, ref y, bm, ref b, 0, 1, 2, 3, 0);
            DecodeBits(ref x, ref y, bm, ref b, 4, 5, 6, 7, 1);
            return b;
        }

        // Decode four bits. Values pos1, pos2, and pos3 give the
        // positions from the left of the bits in b to decode.
        // Value dest_bit gives the bit in the pixel that should
        // hold the values. It should be 0 or 1.
        private void DecodeBits(ref int x, ref int y, Bitmap bm,
            ref byte b, int pos1, int pos2, int pos3, int pos4, int dest_bit)
        {
            // Get the pixel's color.
            Color color = bm.GetPixel(x, y);

            // A mask to get the bit we're using.
            byte only_1 = (byte)(0x01 << dest_bit);

            // Get the encoded bits from the color components.
            byte bit1 = (byte)(color.A & only_1);
            pos1 -= dest_bit;
            b |= (byte)(bit1 << pos1);

            byte bit2 = (byte)(color.R & only_1);
            pos2 -= dest_bit;
            b |= (byte)(bit2 << pos2);

            byte bit3 = (byte)(color.G & only_1);
            pos3 -= dest_bit;
            b |= (byte)(bit3 << pos3);

            byte bit4 = (byte)(color.B & only_1);
            pos4 -= dest_bit;
            b |= (byte)(bit4 << pos4);

            // Move to the next pixel.
            if (dest_bit == 1) NextRowCol(ref x, ref y, bm);
        }

        // Return a byte as a string containing 0s and 1s.
        private string ByteToBits(byte b)
        {
            byte mask = 1;
            string result = "";
            for (int i = 0; i < 8; i++)
            {
                if ((b & mask) == 0) result = "0" + result;
                else result = "1" + result;
                mask <<= 1;
            }
            return result;
        }

        // Return a byte array as a string containing 0s and 1s.
        private string BytesToBits(byte[] bytes)
        {
            string result = "";
            for (int i = 0; i < bytes.Length; i++)
            {
                result += ByteToBits(bytes[i]) + " ";
            }
            return result;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(howto_stego_images_tiled2_Form1));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.picMainOriginal = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.picHiddenRecovered1 = new System.Windows.Forms.PictureBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.picHiddenOriginal1 = new System.Windows.Forms.PictureBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.picHiddenRecovered2 = new System.Windows.Forms.PictureBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.picHiddenOriginal2 = new System.Windows.Forms.PictureBox();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.picHiddenRecovered3 = new System.Windows.Forms.PictureBox();
            this.label9 = new System.Windows.Forms.Label();
            this.picHiddenOriginal3 = new System.Windows.Forms.PictureBox();
            this.label10 = new System.Windows.Forms.Label();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.picHiddenRecovered4 = new System.Windows.Forms.PictureBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.picHiddenOriginal4 = new System.Windows.Forms.PictureBox();
            this.btnGo = new System.Windows.Forms.Button();
            this.picCombined = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.nudHiddenBits = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picMainOriginal)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picHiddenRecovered1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picHiddenOriginal1)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picHiddenRecovered2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picHiddenOriginal2)).BeginInit();
            this.tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picHiddenRecovered3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picHiddenOriginal3)).BeginInit();
            this.tabPage5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picHiddenRecovered4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picHiddenOriginal4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCombined)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudHiddenBits)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage5);
            this.tabControl1.Location = new System.Drawing.Point(381, 41);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(387, 490);
            this.tabControl1.TabIndex = 24;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.picMainOriginal);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(379, 464);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Main";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // picMainOriginal
            // 
            this.picMainOriginal.Image = Properties.Resources.usmapsmall;
            this.picMainOriginal.Location = new System.Drawing.Point(6, 19);
            this.picMainOriginal.Name = "picMainOriginal";
            this.picMainOriginal.Size = new System.Drawing.Size(363, 233);
            this.picMainOriginal.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picMainOriginal.TabIndex = 3;
            this.picMainOriginal.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Original";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.picHiddenRecovered1);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Controls.Add(this.picHiddenOriginal1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(379, 464);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Hidden 1";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // picHiddenRecovered1
            // 
            this.picHiddenRecovered1.Location = new System.Drawing.Point(253, 19);
            this.picHiddenRecovered1.Name = "picHiddenRecovered1";
            this.picHiddenRecovered1.Size = new System.Drawing.Size(181, 116);
            this.picHiddenRecovered1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picHiddenRecovered1.TabIndex = 9;
            this.picHiddenRecovered1.TabStop = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(256, 3);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Recovered";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 3);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(42, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "Original";
            // 
            // picHiddenOriginal1
            // 
            this.picHiddenOriginal1.Image = ((System.Drawing.Image)(resources.GetObject("picHiddenOriginal1.Image")));
            this.picHiddenOriginal1.Location = new System.Drawing.Point(6, 19);
            this.picHiddenOriginal1.Name = "picHiddenOriginal1";
            this.picHiddenOriginal1.Size = new System.Drawing.Size(241, 367);
            this.picHiddenOriginal1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picHiddenOriginal1.TabIndex = 7;
            this.picHiddenOriginal1.TabStop = false;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.picHiddenRecovered2);
            this.tabPage3.Controls.Add(this.label7);
            this.tabPage3.Controls.Add(this.label8);
            this.tabPage3.Controls.Add(this.picHiddenOriginal2);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(379, 464);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Hidden 2";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // picHiddenRecovered2
            // 
            this.picHiddenRecovered2.Location = new System.Drawing.Point(6, 313);
            this.picHiddenRecovered2.Name = "picHiddenRecovered2";
            this.picHiddenRecovered2.Size = new System.Drawing.Size(181, 116);
            this.picHiddenRecovered2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picHiddenRecovered2.TabIndex = 9;
            this.picHiddenRecovered2.TabStop = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(9, 297);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(60, 13);
            this.label7.TabIndex = 8;
            this.label7.Text = "Recovered";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(9, 3);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(42, 13);
            this.label8.TabIndex = 6;
            this.label8.Text = "Original";
            // 
            // picHiddenOriginal2
            // 
            this.picHiddenOriginal2.Image = ((System.Drawing.Image)(resources.GetObject("picHiddenOriginal2.Image")));
            this.picHiddenOriginal2.Location = new System.Drawing.Point(6, 19);
            this.picHiddenOriginal2.Name = "picHiddenOriginal2";
            this.picHiddenOriginal2.Size = new System.Drawing.Size(412, 270);
            this.picHiddenOriginal2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picHiddenOriginal2.TabIndex = 7;
            this.picHiddenOriginal2.TabStop = false;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.picHiddenRecovered3);
            this.tabPage4.Controls.Add(this.label9);
            this.tabPage4.Controls.Add(this.picHiddenOriginal3);
            this.tabPage4.Controls.Add(this.label10);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(379, 464);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Hidden 3";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // picHiddenRecovered3
            // 
            this.picHiddenRecovered3.Location = new System.Drawing.Point(312, 19);
            this.picHiddenRecovered3.Name = "picHiddenRecovered3";
            this.picHiddenRecovered3.Size = new System.Drawing.Size(181, 116);
            this.picHiddenRecovered3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picHiddenRecovered3.TabIndex = 9;
            this.picHiddenRecovered3.TabStop = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(315, 3);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(60, 13);
            this.label9.TabIndex = 8;
            this.label9.Text = "Recovered";
            // 
            // picHiddenOriginal3
            // 
            this.picHiddenOriginal3.Image = ((System.Drawing.Image)(resources.GetObject("picHiddenOriginal3.Image")));
            this.picHiddenOriginal3.Location = new System.Drawing.Point(6, 19);
            this.picHiddenOriginal3.Name = "picHiddenOriginal3";
            this.picHiddenOriginal3.Size = new System.Drawing.Size(300, 350);
            this.picHiddenOriginal3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picHiddenOriginal3.TabIndex = 7;
            this.picHiddenOriginal3.TabStop = false;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(9, 3);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(42, 13);
            this.label10.TabIndex = 6;
            this.label10.Text = "Original";
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.picHiddenRecovered4);
            this.tabPage5.Controls.Add(this.label11);
            this.tabPage5.Controls.Add(this.label12);
            this.tabPage5.Controls.Add(this.picHiddenOriginal4);
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Size = new System.Drawing.Size(379, 464);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "Hidden 4";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // picHiddenRecovered4
            // 
            this.picHiddenRecovered4.Location = new System.Drawing.Point(6, 299);
            this.picHiddenRecovered4.Name = "picHiddenRecovered4";
            this.picHiddenRecovered4.Size = new System.Drawing.Size(181, 116);
            this.picHiddenRecovered4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picHiddenRecovered4.TabIndex = 9;
            this.picHiddenRecovered4.TabStop = false;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(9, 283);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(60, 13);
            this.label11.TabIndex = 8;
            this.label11.Text = "Recovered";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(9, 3);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(42, 13);
            this.label12.TabIndex = 6;
            this.label12.Text = "Original";
            // 
            // picHiddenOriginal4
            // 
            this.picHiddenOriginal4.Image = ((System.Drawing.Image)(resources.GetObject("picHiddenOriginal4.Image")));
            this.picHiddenOriginal4.Location = new System.Drawing.Point(6, 19);
            this.picHiddenOriginal4.Name = "picHiddenOriginal4";
            this.picHiddenOriginal4.Size = new System.Drawing.Size(529, 256);
            this.picHiddenOriginal4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picHiddenOriginal4.TabIndex = 7;
            this.picHiddenOriginal4.TabStop = false;
            // 
            // btnGo
            // 
            this.btnGo.Location = new System.Drawing.Point(180, 12);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(75, 23);
            this.btnGo.TabIndex = 23;
            this.btnGo.Text = "Go";
            this.btnGo.UseVisualStyleBackColor = true;
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // picCombined
            // 
            this.picCombined.Location = new System.Drawing.Point(12, 82);
            this.picCombined.Name = "picCombined";
            this.picCombined.Size = new System.Drawing.Size(363, 233);
            this.picCombined.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picCombined.TabIndex = 20;
            this.picCombined.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 13);
            this.label2.TabIndex = 19;
            this.label2.Text = "Combined";
            // 
            // nudHiddenBits
            // 
            this.nudHiddenBits.Location = new System.Drawing.Point(114, 12);
            this.nudHiddenBits.Maximum = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.nudHiddenBits.Name = "nudHiddenBits";
            this.nudHiddenBits.Size = new System.Drawing.Size(48, 20);
            this.nudHiddenBits.TabIndex = 22;
            this.nudHiddenBits.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 13);
            this.label1.TabIndex = 21;
            this.label1.Text = "Hidden Image Bits:";
            // 
            // howto_stego_images_tiled2_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(780, 542);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.btnGo);
            this.Controls.Add(this.picCombined);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.nudHiddenBits);
            this.Controls.Add(this.label1);
            this.Name = "howto_stego_images_tiled2_Form1";
            this.Text = "howto_stego_images_tiled2";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picMainOriginal)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picHiddenRecovered1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picHiddenOriginal1)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picHiddenRecovered2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picHiddenOriginal2)).EndInit();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picHiddenRecovered3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picHiddenOriginal3)).EndInit();
            this.tabPage5.ResumeLayout(false);
            this.tabPage5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picHiddenRecovered4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picHiddenOriginal4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCombined)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudHiddenBits)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.PictureBox picMainOriginal;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.PictureBox picHiddenRecovered1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.PictureBox picHiddenOriginal1;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.PictureBox picHiddenRecovered2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.PictureBox picHiddenOriginal2;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.PictureBox picHiddenRecovered3;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.PictureBox picHiddenOriginal3;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.PictureBox picHiddenRecovered4;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.PictureBox picHiddenOriginal4;
        private System.Windows.Forms.Button btnGo;
        private System.Windows.Forms.PictureBox picCombined;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown nudHiddenBits;
        private System.Windows.Forms.Label label1;
    }
}

