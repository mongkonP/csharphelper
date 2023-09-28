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
     public partial class howto_stego_bits_Form1:Form
  { 


        public howto_stego_bits_Form1()
        {
            InitializeComponent();
        }

        // A bitmap to record which pixels are used.
        private Bitmap UsedBitmap;

        // Encode the message.
        private void btnEncode_Click(object sender, EventArgs e)
        {
            picEncoded.Image = EncodeMesssage(
                picOriginal.Image as Bitmap, txtMessage.Text);
            txtMessage.Clear();
            btnDecode.Enabled = true;

            picUsed.Image = UsedBitmap;
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
            int space_available = (bm.Width * bm.Height) / 2;
            if (message_length + 4 > space_available)
                throw new InvalidDataException(
                    "Message length " + message_bytes.Length +
                    " is too long. This image can hold only " +
                    space_available + " bytes.");

            int total_length = message_length + 4;
            lblResult.Text = "Encoded " +
                total_length.ToString("N0") + " bytes";

            // Make the result Bitmap.
            Bitmap result = bm.Clone() as Bitmap;
            UsedBitmap = bm.Clone() as Bitmap;

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

        // Encode a single byte starting at pixel (row, col).
        private void EncodeByte(ref int x, ref int y, Bitmap bm, byte b)
        {
            // Encode the byte's bits 3 at a time.
            EncodeBits(ref x, ref y, bm, b, 0, 1, 2, 3);
            EncodeBits(ref x, ref y, bm, b, 4, 5, 6, 7);
        }

        // Encode four bits. Values pos1 through pos4 give the
        // positions from the left of the bits in b to encode.
        private void EncodeBits(ref int x, ref int y, Bitmap bm,
            byte b, int pos1, int pos2, int pos3, int pos4)
        {
            // Get the pixel's color.
            Color color = bm.GetPixel(x, y);

            // A mask to clear the rightmost bit.
            const byte only_1 = 0x01;

            // A mask to clear all bits except the rightmost bit.
            const byte clear_1 = only_1 ^ 0xFF;

            // Add the bits to the color components.
            byte alpha, red, green, blue;
            byte bit1 = (byte)((b >> pos1) & only_1);
            alpha = (byte)((color.A & clear_1) | bit1);

            byte bit2 = (byte)((b >> pos2) & only_1);
            red = (byte)((color.R & clear_1) | bit2);

            byte bit3 = (byte)((b >> pos3) & only_1);
            green = (byte)((color.G & clear_1) | bit3);

            byte bit4 = (byte)((b >> pos4) & only_1);
            blue = (byte)((color.B & clear_1) | bit4);

            // Update the pixel.
            bm.SetPixel(x, y, Color.FromArgb(alpha, red, green, blue));
            UsedBitmap.SetPixel(x, y, Color.Red);

            // Move to the next pixel.
            NextRowCol(ref x, ref y, bm);
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

        // Decode the message.
        private void btnDecode_Click(object sender, EventArgs e)
        {
            txtMessage.Text = DecodeMesssage(picEncoded.Image as Bitmap);
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
            DecodeBits(ref x, ref y, bm, ref b, 0, 1, 2, 3);
            DecodeBits(ref x, ref y, bm, ref b, 4, 5, 6, 7);
            return b;
        }

        // Decode three bits. Values pos1, pos2, and pos3 give the
        // positions from the left of the bits in b to decode.
        private void DecodeBits(ref int x, ref int y, Bitmap bm,
            ref byte b, int pos1, int pos2, int pos3, int pos4)
        {
            // Get the pixel's color.
            Color color = bm.GetPixel(x, y);

            // A mask to get the rightmost bit.
            const byte only_1 = 0x01;

            // Get the encoded bits from the color components.
            byte bit1 = (byte)(color.A & only_1);
            b |= (byte)(bit1 << pos1);

            byte bit2 = (byte)(color.R & only_1);
            b |= (byte)(bit2 << pos2);

            byte bit3 = (byte)(color.G & only_1);
            b |= (byte)(bit3 << pos3);

            byte bit4 = (byte)(color.B & only_1);
            b |= (byte)(bit4 << pos4);

            // Move to the next pixel.
            NextRowCol(ref x, ref y, bm);
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(howto_stego_bits_Form1));
            this.label1 = new System.Windows.Forms.Label();
            this.txtMessage = new System.Windows.Forms.TextBox();
            this.btnEncode = new System.Windows.Forms.Button();
            this.btnDecode = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.picOriginal = new System.Windows.Forms.PictureBox();
            this.picEncoded = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.picUsed = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lblResult = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picOriginal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picEncoded)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picUsed)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Message:";
            // 
            // txtMessage
            // 
            this.txtMessage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMessage.Location = new System.Drawing.Point(71, 12);
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.Size = new System.Drawing.Size(570, 20);
            this.txtMessage.TabIndex = 1;
            this.txtMessage.Text = resources.GetString("txtMessage.Text");
            // 
            // btnEncode
            // 
            this.btnEncode.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnEncode.Location = new System.Drawing.Point(228, 38);
            this.btnEncode.Name = "btnEncode";
            this.btnEncode.Size = new System.Drawing.Size(75, 23);
            this.btnEncode.TabIndex = 2;
            this.btnEncode.Text = "Encode";
            this.btnEncode.UseVisualStyleBackColor = true;
            this.btnEncode.Click += new System.EventHandler(this.btnEncode_Click);
            // 
            // btnDecode
            // 
            this.btnDecode.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnDecode.Enabled = false;
            this.btnDecode.Location = new System.Drawing.Point(349, 38);
            this.btnDecode.Name = "btnDecode";
            this.btnDecode.Size = new System.Drawing.Size(75, 23);
            this.btnDecode.TabIndex = 3;
            this.btnDecode.Text = "Decode";
            this.btnDecode.UseVisualStyleBackColor = true;
            this.btnDecode.Click += new System.EventHandler(this.btnDecode_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Original";
            // 
            // picOriginal
            // 
            this.picOriginal.Image = Properties.Resources.Dog;
            this.picOriginal.Location = new System.Drawing.Point(12, 93);
            this.picOriginal.Name = "picOriginal";
            this.picOriginal.Size = new System.Drawing.Size(206, 135);
            this.picOriginal.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picOriginal.TabIndex = 5;
            this.picOriginal.TabStop = false;
            // 
            // picEncoded
            // 
            this.picEncoded.Location = new System.Drawing.Point(224, 93);
            this.picEncoded.Name = "picEncoded";
            this.picEncoded.Size = new System.Drawing.Size(206, 135);
            this.picEncoded.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picEncoded.TabIndex = 7;
            this.picEncoded.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(224, 77);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Encoded";
            // 
            // picUsed
            // 
            this.picUsed.Location = new System.Drawing.Point(436, 93);
            this.picUsed.Name = "picUsed";
            this.picUsed.Size = new System.Drawing.Size(206, 135);
            this.picUsed.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picUsed.TabIndex = 9;
            this.picUsed.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(436, 77);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Used Pixels";
            // 
            // lblResult
            // 
            this.lblResult.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblResult.AutoSize = true;
            this.lblResult.Location = new System.Drawing.Point(12, 237);
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size(0, 13);
            this.lblResult.TabIndex = 10;
            // 
            // howto_stego_bits_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(653, 259);
            this.Controls.Add(this.lblResult);
            this.Controls.Add(this.picUsed);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.picEncoded);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.picOriginal);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnDecode);
            this.Controls.Add(this.btnEncode);
            this.Controls.Add(this.txtMessage);
            this.Controls.Add(this.label1);
            this.Name = "howto_stego_bits_Form1";
            this.Text = "howto_stego_bits";
            ((System.ComponentModel.ISupportInitialize)(this.picOriginal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picEncoded)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picUsed)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtMessage;
        private System.Windows.Forms.Button btnEncode;
        private System.Windows.Forms.Button btnDecode;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox picOriginal;
        private System.Windows.Forms.PictureBox picEncoded;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox picUsed;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblResult;
    }
}

