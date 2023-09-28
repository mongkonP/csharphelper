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
     public partial class howto_paste_files_Form1:Form
  { 


        public howto_paste_files_Form1()
        {
            InitializeComponent();
        }

        // Handle paste events.
        private void howto_paste_files_Form1_KeyDown(object sender, KeyEventArgs e)
        {
            // Look for Ctrl+V.
            if (e.Control && (e.KeyCode == Keys.V))
            {
                // Paste.
                // Clear the ListBox.
                lstFiles.Items.Clear();

                // Get the DataObject.
                IDataObject data_object = Clipboard.GetDataObject();

                // Look for a file drop.
                if (data_object.GetDataPresent(DataFormats.FileDrop))
                {
                    string[] files = (string[])
                        data_object.GetData(DataFormats.FileDrop);
                    foreach (string file_name in files)
                    {
                        string name = file_name;
                        if (Directory.Exists(file_name))
                            name = "[" + name + "]";
                        lstFiles.Items.Add(name);
                    }
                }
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
            this.lstFiles = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // lstFiles
            // 
            this.lstFiles.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lstFiles.FormattingEnabled = true;
            this.lstFiles.HorizontalScrollbar = true;
            this.lstFiles.IntegralHeight = false;
            this.lstFiles.Location = new System.Drawing.Point(12, 11);
            this.lstFiles.Name = "lstFiles";
            this.lstFiles.Size = new System.Drawing.Size(260, 168);
            this.lstFiles.TabIndex = 1;
            // 
            // howto_paste_files_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 191);
            this.Controls.Add(this.lstFiles);
            this.KeyPreview = true;
            this.Name = "howto_paste_files_Form1";
            this.Text = "howto_paste_files";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.howto_paste_files_Form1_KeyDown);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lstFiles;
    }
}

