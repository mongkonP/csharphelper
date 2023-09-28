using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.IO;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

 

namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_change_picture_types_Form1:Form
  { 


        public howto_change_picture_types_Form1()
        {
            InitializeComponent();
        }

        // Let the user browse for the directory.
        private void btnPickDirectory_Click(object sender, EventArgs e)
        {
            try
            {
                fbdDirectory.SelectedPath = txtDirectory.Text;
            }
            catch
            {
            }

            if (fbdDirectory.ShowDialog() == DialogResult.OK)
            {
                txtDirectory.Text = fbdDirectory.SelectedPath;
            }
        }

        // Process the files in the selected directory.
        private void btnGo_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            this.Refresh();

            // Get the new image format.
            string new_ext = cboExtension.Text;
            ImageFormat new_format = ExtensionFormat(new_ext);

            // Enumerate the files.
            DirectoryInfo dir_info = new System.IO.DirectoryInfo(txtDirectory.Text);
            foreach (FileInfo file_info in dir_info.GetFiles())
            {
                try
                {
                    txtProcessing.Text = file_info.Name;
                    txtProcessing.Refresh();

                    // See what kind of file this is.
                    string old_ext = file_info.Extension.ToLower();
                    ImageFormat old_format = ExtensionFormat(old_ext);

                    // Only process if the file has a graphic
                    // extension and we're changing the type
                    if ((old_format != null) && (old_format != new_format))
                    {
                        Bitmap bm = new Bitmap(file_info.FullName);
                        string new_name = file_info.FullName.Replace(old_ext, new_ext);

                        bm.Save(new_name, new_format);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error processing file '" +
                        file_info.Name + "'\n" + ex.Message,
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            } // foreach file_info

            txtProcessing.Clear();
            this.Text = "howto_2005_change_picture_types";
            this.Cursor = Cursors.Default;
        }

        // Return the ImageFormat for this file extension.
        private ImageFormat ExtensionFormat(string extension)
        {
            switch (extension)
            {
                case ".png":
                    return ImageFormat.Png;
                case ".jpg":
                case ".jpeg":
                    return ImageFormat.Jpeg;
                case ".bmp":
                    return ImageFormat.Bmp;
                case ".gif":
                    return ImageFormat.Gif;
                case ".tif":
                case ".tiff":
                    return ImageFormat.Tiff;
            }
            return null;
        }

        // Restore parameters.
        private void howto_change_picture_types_Form1_Load(object sender, EventArgs e)
        {
            this.SetBounds(
                Properties.Settings.Default.Left,
                Properties.Settings.Default.Top,
                Properties.Settings.Default.Width,
                Properties.Settings.Default.Height);

            txtDirectory.Text = Properties.Settings.Default.Directory;
            if (txtDirectory.Text.Length == 0) txtDirectory.Text = Application.StartupPath;
            cboExtension.Text = Properties.Settings.Default.NewExtension;
        }

        // Save parameters.
        private void howto_change_picture_types_Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.Left = this.Left;
            Properties.Settings.Default.Top = this.Top;
            Properties.Settings.Default.Width = this.Width;
            Properties.Settings.Default.Height = this.Height;

            Properties.Settings.Default.Directory = txtDirectory.Text;
            Properties.Settings.Default.NewExtension = cboExtension.Text;

            Properties.Settings.Default.Save();
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
            this.btnGo = new System.Windows.Forms.Button();
            this.Label2 = new System.Windows.Forms.Label();
            this.btnPickDirectory = new System.Windows.Forms.Button();
            this.txtDirectory = new System.Windows.Forms.TextBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.fbdDirectory = new System.Windows.Forms.FolderBrowserDialog();
            this.cboExtension = new System.Windows.Forms.ComboBox();
            this.txtProcessing = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnGo
            // 
            this.btnGo.Location = new System.Drawing.Point(203, 41);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(75, 23);
            this.btnGo.TabIndex = 19;
            this.btnGo.Text = "Go";
            this.btnGo.UseVisualStyleBackColor = true;
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Location = new System.Drawing.Point(12, 44);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(81, 13);
            this.Label2.TabIndex = 17;
            this.Label2.Text = "New Extension:";
            // 
            // btnPickDirectory
            // 
            this.btnPickDirectory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPickDirectory.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPickDirectory.Location = new System.Drawing.Point(444, 12);
            this.btnPickDirectory.Name = "btnPickDirectory";
            this.btnPickDirectory.Size = new System.Drawing.Size(32, 24);
            this.btnPickDirectory.TabIndex = 16;
            this.btnPickDirectory.Text = "...";
            this.btnPickDirectory.UseVisualStyleBackColor = true;
            this.btnPickDirectory.Click += new System.EventHandler(this.btnPickDirectory_Click);
            // 
            // txtDirectory
            // 
            this.txtDirectory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDirectory.Location = new System.Drawing.Point(99, 15);
            this.txtDirectory.Name = "txtDirectory";
            this.txtDirectory.Size = new System.Drawing.Size(307, 20);
            this.txtDirectory.TabIndex = 15;
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(12, 15);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(52, 13);
            this.Label1.TabIndex = 14;
            this.Label1.Text = "Directory:";
            // 
            // cboExtension
            // 
            this.cboExtension.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboExtension.FormattingEnabled = true;
            this.cboExtension.Items.AddRange(new object[] {
            ".png",
            ".jpg",
            ".bmp",
            ".gif",
            ".tif"});
            this.cboExtension.Location = new System.Drawing.Point(99, 41);
            this.cboExtension.Name = "cboExtension";
            this.cboExtension.Size = new System.Drawing.Size(64, 21);
            this.cboExtension.TabIndex = 21;
            // 
            // txtProcessing
            // 
            this.txtProcessing.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtProcessing.Location = new System.Drawing.Point(12, 80);
            this.txtProcessing.Name = "txtProcessing";
            this.txtProcessing.ReadOnly = true;
            this.txtProcessing.Size = new System.Drawing.Size(457, 20);
            this.txtProcessing.TabIndex = 22;
            // 
            // howto_change_picture_types_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 115);
            this.Controls.Add(this.txtProcessing);
            this.Controls.Add(this.cboExtension);
            this.Controls.Add(this.btnGo);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.btnPickDirectory);
            this.Controls.Add(this.txtDirectory);
            this.Controls.Add(this.Label1);
            this.Name = "howto_change_picture_types_Form1";
            this.Text = "howto_change_picture_types";
            this.Load += new System.EventHandler(this.howto_change_picture_types_Form1_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.howto_change_picture_types_Form1_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Button btnGo;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.Button btnPickDirectory;
        internal System.Windows.Forms.TextBox txtDirectory;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.FolderBrowserDialog fbdDirectory;
        private System.Windows.Forms.ComboBox cboExtension;
        private System.Windows.Forms.TextBox txtProcessing;
    }
}

