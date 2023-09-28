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
     public partial class howto_copy_files_to_clipboard_Form1:Form
  { 


        public howto_copy_files_to_clipboard_Form1()
        {
            InitializeComponent();
        }

        private void howto_copy_files_to_clipboard_Form1_Load(object sender, EventArgs e)
        {
            // Copy some files to the clipboard.
            List<string> file_list = new List<string>();
            foreach (string file_name in Directory.GetFiles(Application.StartupPath))
                file_list.Add(file_name);
            Clipboard.Clear();
            Clipboard.SetData(DataFormats.FileDrop, file_list.ToArray());

            // Paste the file list back out of the clipboard.
            string[] file_names = (string[])
                Clipboard.GetData(DataFormats.FileDrop);

            // Display the pasted file names.
            lstFiles.DataSource = file_names;
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
            this.lstFiles.Location = new System.Drawing.Point(12, 15);
            this.lstFiles.Name = "lstFiles";
            this.lstFiles.Size = new System.Drawing.Size(330, 82);
            this.lstFiles.TabIndex = 1;
            // 
            // howto_copy_files_to_clipboard_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(354, 111);
            this.Controls.Add(this.lstFiles);
            this.Name = "howto_copy_files_to_clipboard_Form1";
            this.Text = "howto_copy_files_to_clipboard";
            this.Load += new System.EventHandler(this.howto_copy_files_to_clipboard_Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lstFiles;
    }
}

