using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

 

using howto_byte_array_to_hex_string;
namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_byte_array_to_hex_string_Form1:Form
  { 


        public howto_byte_array_to_hex_string_Form1()
        {
            InitializeComponent();
        }

        // Convert the string into an array of bytes and display it.
        private void btnToHexString_Click(object sender, EventArgs e)
        {
            // Convert the string into bytes.
            UnicodeEncoding ascii_encoder = new UnicodeEncoding();
            byte[] bytes = ascii_encoder.GetBytes(txtOriginal.Text);

            // Display the result as a string of hexadecimal values.
            txtHexadecimal.Text = bytes.ToHex(' ');
        }

        // Converrt the string of hexadecimal values back into a string.
        private void btnToString_Click(object sender, EventArgs e)
        {
            // Convert the string of hexadecimal values into an array of bytes.
            byte[] bytes = txtHexadecimal.Text.ToBytes();

            // Convert the bytes into a string and display the result.
            UnicodeEncoding ascii_encoder = new UnicodeEncoding();
            txtConvertedBack.Text = ascii_encoder.GetString(bytes);
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
            this.txtConvertedBack = new System.Windows.Forms.TextBox();
            this.txtHexadecimal = new System.Windows.Forms.TextBox();
            this.txtOriginal = new System.Windows.Forms.TextBox();
            this.Label4 = new System.Windows.Forms.Label();
            this.btnToString = new System.Windows.Forms.Button();
            this.btnToHexString = new System.Windows.Forms.Button();
            this.Label2 = new System.Windows.Forms.Label();
            this.Label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtConvertedBack
            // 
            this.txtConvertedBack.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.txtConvertedBack.Location = new System.Drawing.Point(492, 39);
            this.txtConvertedBack.Margin = new System.Windows.Forms.Padding(0, 2, 3, 3);
            this.txtConvertedBack.Multiline = true;
            this.txtConvertedBack.Name = "txtConvertedBack";
            this.txtConvertedBack.ReadOnly = true;
            this.txtConvertedBack.Size = new System.Drawing.Size(200, 107);
            this.txtConvertedBack.TabIndex = 111;
            // 
            // txtHexadecimal
            // 
            this.txtHexadecimal.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.txtHexadecimal.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtHexadecimal.Location = new System.Drawing.Point(252, 39);
            this.txtHexadecimal.Margin = new System.Windows.Forms.Padding(0, 2, 3, 3);
            this.txtHexadecimal.Multiline = true;
            this.txtHexadecimal.Name = "txtHexadecimal";
            this.txtHexadecimal.ReadOnly = true;
            this.txtHexadecimal.Size = new System.Drawing.Size(200, 107);
            this.txtHexadecimal.TabIndex = 110;
            // 
            // txtOriginal
            // 
            this.txtOriginal.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.txtOriginal.Location = new System.Drawing.Point(12, 39);
            this.txtOriginal.Margin = new System.Windows.Forms.Padding(3, 2, 3, 3);
            this.txtOriginal.Multiline = true;
            this.txtOriginal.Name = "txtOriginal";
            this.txtOriginal.Size = new System.Drawing.Size(200, 107);
            this.txtOriginal.TabIndex = 109;
            this.txtOriginal.Text = "To encrypt data, attach a CryptoStream object to a stream. As you write data into" +
                " the CryptoStream, it encrypts or decrypts the data and sends it on to the outpu" +
                "t stream.";
            // 
            // Label4
            // 
            this.Label4.Location = new System.Drawing.Point(492, 12);
            this.Label4.Margin = new System.Windows.Forms.Padding(3, 3, 2, 1);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(200, 24);
            this.Label4.TabIndex = 108;
            this.Label4.Text = "Converted Back to a String";
            this.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnToString
            // 
            this.btnToString.Location = new System.Drawing.Point(460, 36);
            this.btnToString.Name = "btnToString";
            this.btnToString.Size = new System.Drawing.Size(23, 23);
            this.btnToString.TabIndex = 105;
            this.btnToString.TabStop = false;
            this.btnToString.Text = ">";
            this.btnToString.Click += new System.EventHandler(this.btnToString_Click);
            // 
            // btnToHexString
            // 
            this.btnToHexString.Location = new System.Drawing.Point(220, 36);
            this.btnToHexString.Margin = new System.Windows.Forms.Padding(3, 2, 1, 3);
            this.btnToHexString.Name = "btnToHexString";
            this.btnToHexString.Size = new System.Drawing.Size(23, 23);
            this.btnToHexString.TabIndex = 104;
            this.btnToHexString.TabStop = false;
            this.btnToHexString.Text = ">";
            this.btnToHexString.Click += new System.EventHandler(this.btnToHexString_Click);
            // 
            // Label2
            // 
            this.Label2.Location = new System.Drawing.Point(252, 12);
            this.Label2.Margin = new System.Windows.Forms.Padding(3, 3, 2, 1);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(200, 24);
            this.Label2.TabIndex = 103;
            this.Label2.Text = "As Hexadecimal";
            this.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Label1
            // 
            this.Label1.Location = new System.Drawing.Point(12, 12);
            this.Label1.Margin = new System.Windows.Forms.Padding(3, 3, 2, 1);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(200, 24);
            this.Label1.TabIndex = 102;
            this.Label1.Text = "Original String";
            this.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // howto_byte_array_to_hex_string_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(706, 158);
            this.Controls.Add(this.txtConvertedBack);
            this.Controls.Add(this.txtHexadecimal);
            this.Controls.Add(this.txtOriginal);
            this.Controls.Add(this.Label4);
            this.Controls.Add(this.btnToString);
            this.Controls.Add(this.btnToHexString);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.Label1);
            this.Name = "howto_byte_array_to_hex_string_Form1";
            this.Text = "howto_byte_array_to_hex_string";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.TextBox txtConvertedBack;
        internal System.Windows.Forms.TextBox txtHexadecimal;
        internal System.Windows.Forms.TextBox txtOriginal;
        internal System.Windows.Forms.Label Label4;
        internal System.Windows.Forms.Button btnToString;
        internal System.Windows.Forms.Button btnToHexString;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.Label Label1;
    }
}

