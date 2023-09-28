using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

 

namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_multiple_clipboard_formats_Form1:Form
  { 


        public howto_multiple_clipboard_formats_Form1()
        {
            InitializeComponent();
        }

        // Make some RichText to use.
        private void howto_multiple_clipboard_formats_Form1_Load(object sender, EventArgs e)
        {
            string txt = "The quick brown fox jumps over the lazy dog.";
            rchSource.Text = txt;

            rchSource.Select(txt.IndexOf("quick"), "quick".Length);
            rchSource.SelectionFont = new Font(rchSource.SelectionFont, FontStyle.Italic);

            rchSource.Select(txt.IndexOf("brown"), "brown".Length);
            rchSource.SelectionFont = new Font(rchSource.SelectionFont, FontStyle.Bold);
            rchSource.SelectionColor = Color.Brown;

            rchSource.Select(txt.IndexOf("fox"), "fox".Length);
            rchSource.SelectionFont = new Font(rchSource.SelectionFont, FontStyle.Bold);
            rchSource.SelectionColor = Color.Red;

            rchSource.Select(txt.IndexOf("jumps over"), "jumps over".Length);
            rchSource.SelectionFont = new Font(rchSource.SelectionFont, FontStyle.Underline);

            rchSource.Select(txt.IndexOf("lazy"), "lazy".Length);
            rchSource.SelectionFont = new Font(rchSource.SelectionFont, FontStyle.Bold);

            rchSource.Select(txt.IndexOf("dog"), "dog".Length);
            rchSource.SelectionFont = new Font(rchSource.SelectionFont, FontStyle.Bold);
            rchSource.SelectionColor = Color.Blue;

            rchSource.Select(0, 0);
        }

        // Copy data to the clipboard in text, RTF, and HTML formats.
        private void btnCopy_Click(object sender, EventArgs e)
        {
            // Make a DataObject.
            DataObject data_object = new DataObject();

            // Add the data in various formats.
            data_object.SetData(DataFormats.Rtf, rchSource.Rtf);
            data_object.SetData(DataFormats.Text, rchSource.Text);

            string html_text;
            html_text = "<HTML>\r\n";
            html_text += "  <HEAD>The Quick Brown Fox</HEAD>\r\n";
            html_text += "  <BODY>\r\n";
            html_text += rchSource.Text + "\r\n";
            html_text += "  </BODY>\r\n";
            html_text += "</HTML>";
            data_object.SetData(DataFormats.Html, html_text);

            // Place the data in the Clipboard.
            Clipboard.SetDataObject(data_object);
        }

        // Paste data from the clipboard in text,
        // RTF, and HTML formats if they are available.
        private void btnPaste_Click(object sender, EventArgs e)
        {
            // Get the DataObject.
            IDataObject data_object = Clipboard.GetDataObject();

            if (data_object.GetDataPresent(DataFormats.Rtf))
            {
                rchRtf.Rtf = data_object.GetData(DataFormats.Rtf).ToString();
                txtRtfCode.Text = data_object.GetData(DataFormats.Rtf).ToString();
            }
            else
            {
                rchRtf.Clear();
                txtRtfCode.Clear();
            }

            if (data_object.GetDataPresent(DataFormats.Text))
            {
                txtText.Text = data_object.GetData(DataFormats.Text).ToString();
            }
            else
            {
                txtText.Clear();
            }

            if (data_object.GetDataPresent(DataFormats.Html))
            {
                txtHtml.Text = data_object.GetData(DataFormats.Html).ToString();
            }
            else
            {
                txtHtml.Clear();
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
            this.btnPaste = new System.Windows.Forms.Button();
            this.btnCopy = new System.Windows.Forms.Button();
            this.rchRtf = new System.Windows.Forms.RichTextBox();
            this.rchSource = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtRtfCode = new System.Windows.Forms.TextBox();
            this.txtText = new System.Windows.Forms.TextBox();
            this.txtHtml = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnPaste
            // 
            this.btnPaste.Location = new System.Drawing.Point(256, 12);
            this.btnPaste.Name = "btnPaste";
            this.btnPaste.Size = new System.Drawing.Size(48, 24);
            this.btnPaste.TabIndex = 35;
            this.btnPaste.Text = "Paste";
            this.btnPaste.Click += new System.EventHandler(this.btnPaste_Click);
            // 
            // btnCopy
            // 
            this.btnCopy.Location = new System.Drawing.Point(12, 12);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(48, 24);
            this.btnCopy.TabIndex = 34;
            this.btnCopy.Text = "Copy";
            this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
            // 
            // rchRtf
            // 
            this.rchRtf.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.rchRtf.Location = new System.Drawing.Point(256, 68);
            this.rchRtf.Name = "rchRtf";
            this.rchRtf.Size = new System.Drawing.Size(240, 24);
            this.rchRtf.TabIndex = 30;
            this.rchRtf.Text = "";
            // 
            // rchSource
            // 
            this.rchSource.Location = new System.Drawing.Point(10, 68);
            this.rchSource.Name = "rchSource";
            this.rchSource.Size = new System.Drawing.Size(240, 24);
            this.rchSource.TabIndex = 29;
            this.rchSource.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 36;
            this.label1.Text = "Source:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(253, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 13);
            this.label2.TabIndex = 37;
            this.label2.Text = "RTF:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(253, 95);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 13);
            this.label3.TabIndex = 38;
            this.label3.Text = "RTF Code:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(253, 219);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(31, 13);
            this.label4.TabIndex = 39;
            this.label4.Text = "Text:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(253, 266);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 13);
            this.label5.TabIndex = 40;
            this.label5.Text = "HTML:";
            // 
            // txtRtfCode
            // 
            this.txtRtfCode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRtfCode.Location = new System.Drawing.Point(256, 111);
            this.txtRtfCode.Multiline = true;
            this.txtRtfCode.Name = "txtRtfCode";
            this.txtRtfCode.Size = new System.Drawing.Size(240, 105);
            this.txtRtfCode.TabIndex = 41;
            // 
            // txtText
            // 
            this.txtText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtText.Location = new System.Drawing.Point(256, 235);
            this.txtText.Name = "txtText";
            this.txtText.Size = new System.Drawing.Size(240, 20);
            this.txtText.TabIndex = 42;
            // 
            // txtHtml
            // 
            this.txtHtml.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtHtml.Location = new System.Drawing.Point(256, 282);
            this.txtHtml.Multiline = true;
            this.txtHtml.Name = "txtHtml";
            this.txtHtml.Size = new System.Drawing.Size(240, 105);
            this.txtHtml.TabIndex = 43;
            // 
            // howto_multiple_clipboard_formats_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(504, 394);
            this.Controls.Add(this.txtHtml);
            this.Controls.Add(this.txtText);
            this.Controls.Add(this.txtRtfCode);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnPaste);
            this.Controls.Add(this.btnCopy);
            this.Controls.Add(this.rchRtf);
            this.Controls.Add(this.rchSource);
            this.Name = "howto_multiple_clipboard_formats_Form1";
            this.Text = "howto_multiple_clipboard_formats";
            this.Load += new System.EventHandler(this.howto_multiple_clipboard_formats_Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Button btnPaste;
        internal System.Windows.Forms.Button btnCopy;
        internal System.Windows.Forms.RichTextBox rchRtf;
        internal System.Windows.Forms.RichTextBox rchSource;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtRtfCode;
        private System.Windows.Forms.TextBox txtText;
        private System.Windows.Forms.TextBox txtHtml;
    }
}

