using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Globalization;

 

namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_dec_hex_oct_bin_Form1:Form
  { 


        public howto_dec_hex_oct_bin_Form1()
        {
            InitializeComponent();
        }

        // Get the value from the sender and
        // display it in the other TextBoxes.
        private bool ignore_events = false;
        private void TextBox_TextChanged(object sender, EventArgs e)
        {
            // Don't recurse.
            if (ignore_events) return;
            ignore_events = true;

            // Get the sender as a TextBox.
            TextBox source = sender as TextBox;

            // Get the value.
            long value = 0;
            try
            {
                switch (source.Name)
                {
                    case "txtDecimal":
                        // Parse a decimal value.
                        value = long.Parse(source.Text);
                        break;
                    case "txtHexadecimal":
                        // Parse a hexadecimal value.
                        value = Convert.ToInt64(source.Text, 16);
                        break;
                    case "txtOctal":
                        // Parse an octal value.
                        value = Convert.ToInt64(source.Text, 8);
                        break;
                    case "txtBinary":
                        // Parse a binary value.
                        value = Convert.ToInt64(source.Text, 2);
                        break;
                    default:
                        throw new Exception("Unknown control " + source.Name);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error parsing input\n\n" + ex.Message,
                    "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            // Display the value in different formats.
            if (source.Name != "txtDecimal")
            {
                txtDecimal.Text = value.ToString();
            }
            if (source.Name != "txtHexadecimal")
            {
                txtHexadecimal.Text = Convert.ToString(value, 16);
            }
            if (source.Name != "txtOctal")
            {
                txtOctal.Text = Convert.ToString(value, 8);
            }
            if (source.Name != "txtBinary")
            {
                txtBinary.Text = Convert.ToString(value, 2);
            }

            ignore_events = false;
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
            this.txtBinary = new System.Windows.Forms.TextBox();
            this.txtOctal = new System.Windows.Forms.TextBox();
            this.txtHexadecimal = new System.Windows.Forms.TextBox();
            this.txtDecimal = new System.Windows.Forms.TextBox();
            this._Label1_3 = new System.Windows.Forms.Label();
            this._Label1_2 = new System.Windows.Forms.Label();
            this._Label1_1 = new System.Windows.Forms.Label();
            this._Label1_0 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtBinary
            // 
            this.txtBinary.AcceptsReturn = true;
            this.txtBinary.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBinary.BackColor = System.Drawing.SystemColors.Window;
            this.txtBinary.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtBinary.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBinary.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtBinary.Location = new System.Drawing.Point(90, 90);
            this.txtBinary.MaxLength = 0;
            this.txtBinary.Name = "txtBinary";
            this.txtBinary.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtBinary.Size = new System.Drawing.Size(207, 20);
            this.txtBinary.TabIndex = 23;
            this.txtBinary.TextChanged += new System.EventHandler(this.TextBox_TextChanged);
            // 
            // txtOctal
            // 
            this.txtOctal.AcceptsReturn = true;
            this.txtOctal.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtOctal.BackColor = System.Drawing.SystemColors.Window;
            this.txtOctal.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtOctal.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOctal.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtOctal.Location = new System.Drawing.Point(90, 64);
            this.txtOctal.MaxLength = 0;
            this.txtOctal.Name = "txtOctal";
            this.txtOctal.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtOctal.Size = new System.Drawing.Size(207, 20);
            this.txtOctal.TabIndex = 22;
            this.txtOctal.TextChanged += new System.EventHandler(this.TextBox_TextChanged);
            // 
            // txtHexadecimal
            // 
            this.txtHexadecimal.AcceptsReturn = true;
            this.txtHexadecimal.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtHexadecimal.BackColor = System.Drawing.SystemColors.Window;
            this.txtHexadecimal.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtHexadecimal.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtHexadecimal.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtHexadecimal.Location = new System.Drawing.Point(90, 38);
            this.txtHexadecimal.MaxLength = 0;
            this.txtHexadecimal.Name = "txtHexadecimal";
            this.txtHexadecimal.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtHexadecimal.Size = new System.Drawing.Size(207, 20);
            this.txtHexadecimal.TabIndex = 21;
            this.txtHexadecimal.TextChanged += new System.EventHandler(this.TextBox_TextChanged);
            // 
            // txtDecimal
            // 
            this.txtDecimal.AcceptsReturn = true;
            this.txtDecimal.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDecimal.BackColor = System.Drawing.SystemColors.Window;
            this.txtDecimal.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtDecimal.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDecimal.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtDecimal.Location = new System.Drawing.Point(90, 12);
            this.txtDecimal.MaxLength = 0;
            this.txtDecimal.Name = "txtDecimal";
            this.txtDecimal.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtDecimal.Size = new System.Drawing.Size(207, 20);
            this.txtDecimal.TabIndex = 20;
            this.txtDecimal.TextChanged += new System.EventHandler(this.TextBox_TextChanged);
            // 
            // _Label1_3
            // 
            this._Label1_3.BackColor = System.Drawing.SystemColors.Control;
            this._Label1_3.Cursor = System.Windows.Forms.Cursors.Default;
            this._Label1_3.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Label1_3.ForeColor = System.Drawing.SystemColors.ControlText;
            this._Label1_3.Location = new System.Drawing.Point(12, 93);
            this._Label1_3.Name = "_Label1_3";
            this._Label1_3.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._Label1_3.Size = new System.Drawing.Size(65, 17);
            this._Label1_3.TabIndex = 19;
            this._Label1_3.Text = "Binary";
            // 
            // _Label1_2
            // 
            this._Label1_2.BackColor = System.Drawing.SystemColors.Control;
            this._Label1_2.Cursor = System.Windows.Forms.Cursors.Default;
            this._Label1_2.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Label1_2.ForeColor = System.Drawing.SystemColors.ControlText;
            this._Label1_2.Location = new System.Drawing.Point(12, 67);
            this._Label1_2.Name = "_Label1_2";
            this._Label1_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._Label1_2.Size = new System.Drawing.Size(65, 17);
            this._Label1_2.TabIndex = 18;
            this._Label1_2.Text = "Octal";
            // 
            // _Label1_1
            // 
            this._Label1_1.BackColor = System.Drawing.SystemColors.Control;
            this._Label1_1.Cursor = System.Windows.Forms.Cursors.Default;
            this._Label1_1.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Label1_1.ForeColor = System.Drawing.SystemColors.ControlText;
            this._Label1_1.Location = new System.Drawing.Point(12, 41);
            this._Label1_1.Name = "_Label1_1";
            this._Label1_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._Label1_1.Size = new System.Drawing.Size(72, 17);
            this._Label1_1.TabIndex = 17;
            this._Label1_1.Text = "Hexadecimal";
            // 
            // _Label1_0
            // 
            this._Label1_0.BackColor = System.Drawing.SystemColors.Control;
            this._Label1_0.Cursor = System.Windows.Forms.Cursors.Default;
            this._Label1_0.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Label1_0.ForeColor = System.Drawing.SystemColors.ControlText;
            this._Label1_0.Location = new System.Drawing.Point(12, 15);
            this._Label1_0.Name = "_Label1_0";
            this._Label1_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._Label1_0.Size = new System.Drawing.Size(65, 17);
            this._Label1_0.TabIndex = 16;
            this._Label1_0.Text = "Decimal";
            // 
            // howto_dec_hex_oct_bin_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(311, 124);
            this.Controls.Add(this.txtBinary);
            this.Controls.Add(this.txtOctal);
            this.Controls.Add(this.txtHexadecimal);
            this.Controls.Add(this.txtDecimal);
            this.Controls.Add(this._Label1_3);
            this.Controls.Add(this._Label1_2);
            this.Controls.Add(this._Label1_1);
            this.Controls.Add(this._Label1_0);
            this.Name = "howto_dec_hex_oct_bin_Form1";
            this.Text = "howto_dec_hex_oct_bin";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.TextBox txtBinary;
        public System.Windows.Forms.TextBox txtOctal;
        public System.Windows.Forms.TextBox txtHexadecimal;
        public System.Windows.Forms.TextBox txtDecimal;
        public System.Windows.Forms.Label _Label1_3;
        public System.Windows.Forms.Label _Label1_2;
        public System.Windows.Forms.Label _Label1_1;
        public System.Windows.Forms.Label _Label1_0;
    }
}

