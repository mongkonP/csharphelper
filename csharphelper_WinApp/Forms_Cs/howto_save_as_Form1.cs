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
     public partial class howto_save_as_Form1:Form
  { 


        public howto_save_as_Form1()
        {
            InitializeComponent();
        }

        // The document's file name.
        private string _FileName = "";
        private string FileName
        {
            get { return _FileName; }
            set
            {
                if (value == _FileName) return;
                _FileName = value;
                SetFormCaption();
            }
        }

        // True if the document was changed since opening/creation.
        private bool _DocumentChanged = false;
        private bool DocumentChanged
        {
            get { return _DocumentChanged; }
            set
            {
                if (value == _DocumentChanged) return;
                _DocumentChanged = value;
                SetFormCaption();
            }
        }

        // Set the form's caption to indicate the file
        // name and whether there are unsaved changes.
        private void SetFormCaption()
        {
            string caption = "howto_save_as ";

            // If there are changes, add an asterisk.
            if (DocumentChanged) caption += "* ";
            else caption += " ";

            // Add the file name without its path.
            if (FileName == "") caption += "[ ]";
            else caption += "[" + Path.GetFileName(FileName) + "]";

            // Display the result.
            this.Text = caption;
        }

        // Return true if it is safe to discard the current document.
        private bool IsDocumentSafe()
        {
            // If there are no current changes to the document, it's safe.
            if (!DocumentChanged) return true;

            // See if the user wants to save the changes.
            switch (MessageBox.Show(
                "There are unsaved changes. Do you want to save the document?",
                "Save Changes?", MessageBoxButtons.YesNoCancel))
            {
                case DialogResult.Yes:
                    // Save the changes.
                    SaveDocument();

                    // If the document still has unsaved changes,
                    // then we didn't save so the document is not safe.
                    return (!DocumentChanged);

                case DialogResult.No:
                    // It's safe to lose the current changes.
                    return true;

                default:
                    // Cancel. It's not safe to lose the changes.
                    return false;
            }
        }

        // Attempt to save the document.
        // If we don't have a file name, treat this as Save As.
        private void SaveDocument()
        {
            // See if we have a file name.
            if (FileName == "")
            {
                // We have no file name. Treat as Save As.
                SaveDocumentAs();
            }
            else
            {
                // Save with the current name.
                SaveDocumentAs(FileName);
            }
        }

        // Attempt to save the document with a new file name.
        private void SaveDocumentAs()
        {
            // Let the user pick the file in which to save.
            if (sfdDocument.ShowDialog() == DialogResult.OK)
            {
                // Save using the selected file name.
                SaveDocumentAs(sfdDocument.FileName);
            }
        }

        // Save the document with the indicated name.
        private void SaveDocumentAs(string file_name)
        {
            // Save with the indicated name.
            try
            {
                // Save the file.
                if (Path.GetExtension(file_name).ToLower() == ".txt")
                {
                    // Save as a text file.
                    File.WriteAllText(file_name, rchDocument.Text);
                }
                else
                {
                    // Save as an RTF file.
                    rchDocument.SaveFile(file_name);
                }

                // Update the document's file name.
                FileName = file_name;

                // There are no unsaved changed now.
                DocumentChanged = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // Create a new document.
        private void mnuFileNew_Click(object sender, EventArgs e)
        {
            // Make sure it's safe to discard the current document.
            if (!IsDocumentSafe()) return;

            // Clear the document.
            rchDocument.Clear();

            // There are no changes.
            DocumentChanged = false;

            // We have no file name yet.
            FileName = "";
        }

        // Open an existing file.
        private void mnuFileOpen_Click(object sender, EventArgs e)
        {
            // Make sure it's safe to discard the current document.
            if (!IsDocumentSafe()) return;

            // Let the user pick the file.
            if (ofdDocument.ShowDialog() == DialogResult.OK)
            {
                // Open the file.
                OpenFile(ofdDocument.FileName);
            }
        }

        // Open the indicated file.
        private void OpenFile(string file_name)
        {
            try
            {
                // Load the file.
                if (Path.GetExtension(file_name).ToLower() == ".txt")
                {
                    // Read as a text file.
                    rchDocument.Text = File.ReadAllText(file_name);
                }
                else
                {
                    // Read as an RTF file.
                    rchDocument.LoadFile(file_name);
                }

                // There are no changes.
                DocumentChanged = false;

                // Save the file's name.
                FileName = file_name;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // Save using the current document name.
        private void mnuFileSave_Click(object sender, EventArgs e)
        {
            SaveDocument();
        }

        // Save the document with a new name.
        private void mnuFileSaveAs_Click(object sender, EventArgs e)
        {
            SaveDocumentAs();
        }

        // Exit. Just try to close.
        private void mnuFileExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        // Flag the document as changed.
        private void rchDocument_TextChanged(object sender, EventArgs e)
        {
            DocumentChanged = true;
        }

        // Initially we have a new unchanged document.
        private void howto_save_as_Form1_Load(object sender, EventArgs e)
        {
            mnuFileNew_Click(null, null);
        }

        // If it's not safe to close, cancel the close.
        private void howto_save_as_Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = !IsDocumentSafe();
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
            this.mnuFileSaveAs = new System.Windows.Forms.ToolStripMenuItem();
            this.sfdDocument = new System.Windows.Forms.SaveFileDialog();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuFileSave = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFileExit = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFileOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.rchDocument = new System.Windows.Forms.RichTextBox();
            this.mnuFileNew = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ofdDocument = new System.Windows.Forms.OpenFileDialog();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // mnuFileSaveAs
            // 
            this.mnuFileSaveAs.Name = "mnuFileSaveAs";
            this.mnuFileSaveAs.Size = new System.Drawing.Size(155, 22);
            this.mnuFileSaveAs.Text = "&Save As...";
            this.mnuFileSaveAs.Click += new System.EventHandler(this.mnuFileSaveAs_Click);
            // 
            // sfdDocument
            // 
            this.sfdDocument.Filter = "RTF Files|*.rtf|Text Files|*.txt|All Files|*.*";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(152, 6);
            // 
            // mnuFileSave
            // 
            this.mnuFileSave.Name = "mnuFileSave";
            this.mnuFileSave.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.mnuFileSave.Size = new System.Drawing.Size(155, 22);
            this.mnuFileSave.Text = "&Save";
            this.mnuFileSave.Click += new System.EventHandler(this.mnuFileSave_Click);
            // 
            // mnuFileExit
            // 
            this.mnuFileExit.Name = "mnuFileExit";
            this.mnuFileExit.Size = new System.Drawing.Size(155, 22);
            this.mnuFileExit.Text = "E&xit";
            this.mnuFileExit.Click += new System.EventHandler(this.mnuFileExit_Click);
            // 
            // mnuFileOpen
            // 
            this.mnuFileOpen.Name = "mnuFileOpen";
            this.mnuFileOpen.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.mnuFileOpen.Size = new System.Drawing.Size(155, 22);
            this.mnuFileOpen.Text = "&Open...";
            this.mnuFileOpen.Click += new System.EventHandler(this.mnuFileOpen_Click);
            // 
            // rchDocument
            // 
            this.rchDocument.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.rchDocument.Location = new System.Drawing.Point(12, 31);
            this.rchDocument.Name = "rchDocument";
            this.rchDocument.Size = new System.Drawing.Size(260, 218);
            this.rchDocument.TabIndex = 2;
            this.rchDocument.Text = "";
            this.rchDocument.TextChanged += new System.EventHandler(this.rchDocument_TextChanged);
            // 
            // mnuFileNew
            // 
            this.mnuFileNew.Name = "mnuFileNew";
            this.mnuFileNew.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.mnuFileNew.Size = new System.Drawing.Size(155, 22);
            this.mnuFileNew.Text = "&New";
            this.mnuFileNew.Click += new System.EventHandler(this.mnuFileNew_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(284, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFileNew,
            this.mnuFileOpen,
            this.mnuFileSave,
            this.mnuFileSaveAs,
            this.toolStripMenuItem1,
            this.mnuFileExit});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // ofdDocument
            // 
            this.ofdDocument.FileName = "openFileDialog1";
            this.ofdDocument.Filter = "RTF Files|*.rtf|Text Files|*.txt|All Files|*.*";
            // 
            // howto_save_as_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.rchDocument);
            this.Controls.Add(this.menuStrip1);
            this.Name = "howto_save_as_Form1";
            this.Text = "howto_save_as [ ]";
            this.Load += new System.EventHandler(this.howto_save_as_Form1_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.howto_save_as_Form1_FormClosing);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStripMenuItem mnuFileSaveAs;
        private System.Windows.Forms.SaveFileDialog sfdDocument;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem mnuFileSave;
        private System.Windows.Forms.ToolStripMenuItem mnuFileExit;
        private System.Windows.Forms.ToolStripMenuItem mnuFileOpen;
        private System.Windows.Forms.RichTextBox rchDocument;
        private System.Windows.Forms.ToolStripMenuItem mnuFileNew;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog ofdDocument;
    }
}

