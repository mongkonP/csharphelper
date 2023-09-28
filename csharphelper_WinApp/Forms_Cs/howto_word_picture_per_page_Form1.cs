using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.IO;

// Open the Add References dialog. On the COM tab, select
// "Microsoft Word 12.0 Object Library" (or whatever version you
// have installed on your system). 

using Word = Microsoft.Office.Interop.Word;

 

namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_word_picture_per_page_Form1:Form
  { 


        public howto_word_picture_per_page_Form1()
        {
            InitializeComponent();
        }

        // Allow multi-select.
        // (You could set this in the Form Designer.)
        private void howto_word_picture_per_page_Form1_Load(object sender, EventArgs e)
        {
            ofdPictures.Multiselect = true;
        }

        // Let the user select the pictures.
        private void btnSelectPictures_Click(object sender, EventArgs e)
        {
            if (ofdPictures.ShowDialog() == DialogResult.OK)
                lstFiles.DataSource = ofdPictures.FileNames;
        }

        // Create the Word document.
        private void btnCreateDocument_Click(object sender, EventArgs e)
        {
            // Get the Word application object.
            Word._Application word_app = new Word.ApplicationClass();

            // Make Word visible (optional).
            word_app.Visible = true;

            // Create the Word document.
            object missing = Type.Missing;
            Word._Document word_doc = word_app.Documents.Add(ref missing, ref missing,
                ref missing, ref missing);

            // Make one page per picture.
            object collapse_end = Word.WdCollapseDirection.wdCollapseEnd;
            object page_break = Word.WdBreakType.wdPageBreak;
            for (int i = 0; i < lstFiles.Items.Count; i++)
            {
                // Get the file's name.
                string filename = (string)lstFiles.Items[i];

                // Go to the end of the document.
                Word.Range range = word_doc.Paragraphs.Last.Range;

                // Add the picture to the range.
                Word.InlineShape inline_shape =
                    range.InlineShapes.AddPicture(
                        filename, ref missing, ref missing,
                        ref missing);

                // Add a paragraph.
                range.InsertParagraphAfter();

                // Add a caption.
                FileInfo file_info = new FileInfo(filename);
                range.InsertAfter("Picture " +
                    i.ToString() + ": " + file_info.Name);

                // If this isn't the last page, insert a page break.
                if (i < lstFiles.Items.Count - 1)
                {
                    range.Collapse(ref collapse_end);
                    range.InsertBreak(ref page_break);
                }
            }

            // Save the document.
            object doc_filename = Path.GetFullPath(
                Path.Combine(Application.StartupPath, "..\\..")) +
                "\\pictures.docx";
            word_doc.SaveAs(ref doc_filename, ref missing, ref missing, ref missing,
                ref missing, ref missing, ref missing, ref missing, ref missing,
                ref missing, ref missing, ref missing, ref missing, ref missing,
                ref missing, ref missing);

            // Close.
            object save_changes = false;
            word_doc.Close(ref save_changes, ref missing, ref missing);
            word_app.Quit(ref save_changes, ref missing, ref missing);

            MessageBox.Show("Done");
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
            this.btnSelectPictures = new System.Windows.Forms.Button();
            this.ofdPictures = new System.Windows.Forms.OpenFileDialog();
            this.lstFiles = new System.Windows.Forms.ListBox();
            this.btnCreateDocument = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnSelectPictures
            // 
            this.btnSelectPictures.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnSelectPictures.Location = new System.Drawing.Point(89, 12);
            this.btnSelectPictures.Name = "btnSelectPictures";
            this.btnSelectPictures.Size = new System.Drawing.Size(107, 23);
            this.btnSelectPictures.TabIndex = 0;
            this.btnSelectPictures.Text = "Select Pictures";
            this.btnSelectPictures.UseVisualStyleBackColor = true;
            this.btnSelectPictures.Click += new System.EventHandler(this.btnSelectPictures_Click);
            // 
            // ofdPictures
            // 
            this.ofdPictures.Filter = "Picture Files|*.bmp;*.jpg;*.gif;*.png;*.tif|All Files|*.*";
            // 
            // lstFiles
            // 
            this.lstFiles.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lstFiles.FormattingEnabled = true;
            this.lstFiles.HorizontalScrollbar = true;
            this.lstFiles.IntegralHeight = false;
            this.lstFiles.Location = new System.Drawing.Point(12, 41);
            this.lstFiles.Name = "lstFiles";
            this.lstFiles.Size = new System.Drawing.Size(260, 179);
            this.lstFiles.TabIndex = 1;
            // 
            // btnCreateDocument
            // 
            this.btnCreateDocument.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnCreateDocument.Location = new System.Drawing.Point(89, 226);
            this.btnCreateDocument.Name = "btnCreateDocument";
            this.btnCreateDocument.Size = new System.Drawing.Size(107, 23);
            this.btnCreateDocument.TabIndex = 2;
            this.btnCreateDocument.Text = "Create Document";
            this.btnCreateDocument.UseVisualStyleBackColor = true;
            this.btnCreateDocument.Click += new System.EventHandler(this.btnCreateDocument_Click);
            // 
            // howto_word_picture_per_page_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.btnCreateDocument);
            this.Controls.Add(this.lstFiles);
            this.Controls.Add(this.btnSelectPictures);
            this.Name = "howto_word_picture_per_page_Form1";
            this.Text = "howto_word_picture_per_page";
            this.Load += new System.EventHandler(this.howto_word_picture_per_page_Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSelectPictures;
        private System.Windows.Forms.OpenFileDialog ofdPictures;
        private System.Windows.Forms.ListBox lstFiles;
        private System.Windows.Forms.Button btnCreateDocument;
    }
}

