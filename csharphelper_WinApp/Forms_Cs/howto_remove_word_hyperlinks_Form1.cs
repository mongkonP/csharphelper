using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

// Add a reference to Microsoft Word 14.0 Object Library.

using Word = Microsoft.Office.Interop.Word;

 

namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_remove_word_hyperlinks_Form1:Form
  { 


        public howto_remove_word_hyperlinks_Form1()
        {
            InitializeComponent();
        }

        private void howto_remove_word_hyperlinks_Form1_Load(object sender, EventArgs e)
        {
            txtFile.Text = Application.StartupPath + "\\Test.docx";
            txtFile.Select(txtFile.Text.Length, 0);
        }

        // Remove the document's hyperlinks
        private void btnRemoveHyperlinks_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            Refresh();

            // Get the Word application object.
            Word._Application word_app = new Word.Application();

            // Make Word visible (optional).
            word_app.Visible = true;

            // Open the Word document.
            object missing = Type.Missing;
            object filename = txtFile.Text;
            object confirm_conversions = false;
            object read_only = false;
            object add_to_recent_files = false;
            object format = 0;
            Word._Document word_doc =
                word_app.Documents.Open(ref filename, ref confirm_conversions,
                    ref read_only, ref add_to_recent_files,
                    ref missing, ref missing, ref missing, ref missing,
                    ref missing, ref format, ref missing, ref missing,
                    ref missing, ref missing, ref missing, ref missing);

            // Remove the hyperlinks.
            object index = 1;
            while (word_doc.Hyperlinks.Count > 0)
            {
                word_doc.Hyperlinks.get_Item(ref index).Delete();
            }

            // Save and close the document without prompting.
            object save_changes = true; 
            word_doc.Close(ref save_changes, ref missing, ref missing);

            // Close the word application.
            word_app.Quit(ref save_changes, ref missing, ref missing);

            MessageBox.Show("Done");
            Cursor = Cursors.Default;
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
            this.txtFile = new System.Windows.Forms.TextBox();
            this.btnRemoveHyperlinks = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(26, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "File:";
            // 
            // txtFile
            // 
            this.txtFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFile.Location = new System.Drawing.Point(44, 12);
            this.txtFile.Name = "txtFile";
            this.txtFile.Size = new System.Drawing.Size(311, 20);
            this.txtFile.TabIndex = 1;
            // 
            // btnRemoveHyperlinks
            // 
            this.btnRemoveHyperlinks.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnRemoveHyperlinks.Location = new System.Drawing.Point(123, 38);
            this.btnRemoveHyperlinks.Name = "btnRemoveHyperlinks";
            this.btnRemoveHyperlinks.Size = new System.Drawing.Size(120, 23);
            this.btnRemoveHyperlinks.TabIndex = 2;
            this.btnRemoveHyperlinks.Text = "Remove Hyperlinks";
            this.btnRemoveHyperlinks.UseVisualStyleBackColor = true;
            this.btnRemoveHyperlinks.Click += new System.EventHandler(this.btnRemoveHyperlinks_Click);
            // 
            // howto_remove_word_hyperlinks_Form1
            // 
            this.AcceptButton = this.btnRemoveHyperlinks;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(367, 70);
            this.Controls.Add(this.btnRemoveHyperlinks);
            this.Controls.Add(this.txtFile);
            this.Controls.Add(this.label1);
            this.Name = "howto_remove_word_hyperlinks_Form1";
            this.Text = "howto_remove_word_hyperlinks";
            this.Load += new System.EventHandler(this.howto_remove_word_hyperlinks_Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtFile;
        private System.Windows.Forms.Button btnRemoveHyperlinks;
    }
}

