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
     public partial class howto_get_clipboard_formats_Form1:Form
  { 


        public howto_get_clipboard_formats_Form1()
        {
            InitializeComponent();
        }

        private void howto_get_clipboard_formats_Form1_Load(object sender, EventArgs e)
        {
            wbrSample.Navigate("about:blank");
        }

        // List the available formats.
        private void btnListFormats_Click(object sender, EventArgs e)
        {
            IDataObject data_object = Clipboard.GetDataObject();
            lstFormats.Items.Clear();
            foreach (string format in data_object.GetFormats())
                lstFormats.Items.Add(format);
            DisplayData();
        }

        // Display data if possible.
        private void DisplayData()
        {
            txtSample.Visible = false;
            rchSample.Visible = false;
            picSample.Visible = false;
            wbrSample.Visible = false;

            // Image.
            if (Clipboard.ContainsImage())
            {
                picSample.Image = Clipboard.GetImage();
                picSample.Visible = true;
            }

            // Text.
            if (Clipboard.ContainsText(TextDataFormat.UnicodeText))
            {
                txtSample.Text = Clipboard.GetText(TextDataFormat.UnicodeText);
                txtSample.Visible = true;
            }

            // HTML.
            if (Clipboard.ContainsText(TextDataFormat.Html))
            {
                HtmlDocument doc = wbrSample.Document;
                doc.Body.InnerHtml = Clipboard.GetText(TextDataFormat.Html);
                wbrSample.Visible = true;
            }

            // Rich Text.
            if (Clipboard.ContainsText(TextDataFormat.Rtf))
            {
                rchSample.Rtf = Clipboard.GetText(TextDataFormat.Rtf);
                rchSample.Visible = true;
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
            this.btnListFormats = new System.Windows.Forms.Button();
            this.lstFormats = new System.Windows.Forms.ListBox();
            this.rchSample = new System.Windows.Forms.RichTextBox();
            this.txtSample = new System.Windows.Forms.TextBox();
            this.wbrSample = new System.Windows.Forms.WebBrowser();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.picSample = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picSample)).BeginInit();
            this.SuspendLayout();
            // 
            // btnListFormats
            // 
            this.btnListFormats.Location = new System.Drawing.Point(12, 12);
            this.btnListFormats.Name = "btnListFormats";
            this.btnListFormats.Size = new System.Drawing.Size(75, 23);
            this.btnListFormats.TabIndex = 0;
            this.btnListFormats.Text = "List Formats";
            this.btnListFormats.UseVisualStyleBackColor = true;
            this.btnListFormats.Click += new System.EventHandler(this.btnListFormats_Click);
            // 
            // lstFormats
            // 
            this.lstFormats.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.lstFormats.FormattingEnabled = true;
            this.lstFormats.IntegralHeight = false;
            this.lstFormats.Location = new System.Drawing.Point(12, 41);
            this.lstFormats.Name = "lstFormats";
            this.lstFormats.Size = new System.Drawing.Size(206, 349);
            this.lstFormats.TabIndex = 1;
            // 
            // rchSample
            // 
            this.rchSample.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rchSample.Location = new System.Drawing.Point(53, 191);
            this.rchSample.Name = "rchSample";
            this.rchSample.Size = new System.Drawing.Size(296, 88);
            this.rchSample.TabIndex = 3;
            this.rchSample.Text = "";
            this.rchSample.Visible = false;
            // 
            // txtSample
            // 
            this.txtSample.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSample.Location = new System.Drawing.Point(53, 97);
            this.txtSample.Multiline = true;
            this.txtSample.Name = "txtSample";
            this.txtSample.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtSample.Size = new System.Drawing.Size(296, 88);
            this.txtSample.TabIndex = 4;
            this.txtSample.Visible = false;
            // 
            // wbrSample
            // 
            this.wbrSample.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wbrSample.Location = new System.Drawing.Point(53, 285);
            this.wbrSample.MinimumSize = new System.Drawing.Size(20, 20);
            this.wbrSample.Name = "wbrSample";
            this.wbrSample.Size = new System.Drawing.Size(296, 89);
            this.wbrSample.TabIndex = 5;
            this.wbrSample.Visible = false;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.picSample, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtSample, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.wbrSample, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.rchSample, 1, 2);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(224, 13);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(352, 377);
            this.tableLayoutPanel1.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Image:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 94);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Text:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 188);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "RTF:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 282);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "HTML:";
            // 
            // picSample
            // 
            this.picSample.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picSample.Location = new System.Drawing.Point(53, 3);
            this.picSample.Name = "picSample";
            this.picSample.Size = new System.Drawing.Size(296, 88);
            this.picSample.TabIndex = 7;
            this.picSample.TabStop = false;
            this.picSample.Visible = false;
            // 
            // howto_get_clipboard_formats_Form1
            // 
            this.AcceptButton = this.btnListFormats;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(588, 401);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.lstFormats);
            this.Controls.Add(this.btnListFormats);
            this.Name = "howto_get_clipboard_formats_Form1";
            this.Text = "howto_get_clipboard_formats";
            this.Load += new System.EventHandler(this.howto_get_clipboard_formats_Form1_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picSample)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnListFormats;
        private System.Windows.Forms.ListBox lstFormats;
        private System.Windows.Forms.RichTextBox rchSample;
        private System.Windows.Forms.TextBox txtSample;
        private System.Windows.Forms.WebBrowser wbrSample;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox picSample;
    }
}

