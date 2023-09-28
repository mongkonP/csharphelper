using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Runtime.InteropServices;
using System.IO;
using System.Drawing.Imaging;

 

namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_set_desktop_background_Form1:Form
  { 


        [DllImport("user32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool SystemParametersInfo(uint uiAction, uint uiParam, String pvParam, uint fWinIni);

        private const uint SPI_SETDESKWALLPAPER = 0x14;
        private const uint SPIF_UPDATEINIFILE = 0x1;
        private const uint SPIF_SENDWININICHANGE = 0x2;

        public howto_set_desktop_background_Form1()
        {
            InitializeComponent();
        }

        private void howto_set_desktop_background_Form1_Load(object sender, EventArgs e)
        {
            txtPictureFile.Text = Application.StartupPath + "\\Picture1.jpg";
        }

        // Set the desktop picture.
        private void btnSetDesktop_Click(object sender, EventArgs e)
        {
            DisplayPicture(txtPictureFile.Text, chkUpdateRegistry.Checked);
        }

        // Display the file on the desktop.
        private void DisplayPicture(string file_name, bool update_registry)
        {
            try
            {
                // If we should update the registry,
                // set the appropriate flags.
                uint flags = 0;
                if (update_registry)
                    flags = SPIF_UPDATEINIFILE | SPIF_SENDWININICHANGE;

                // Set the desktop background to this file.
                if (!SystemParametersInfo(SPI_SETDESKWALLPAPER,
                    0, file_name, flags))
                {
                    MessageBox.Show("SystemParametersInfo failed.",
                        "Error", MessageBoxButtons.OK,
                        MessageBoxIcon.Exclamation);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error displaying picture " +
                    file_name + ".\n" + ex.Message,
                    "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
            }
        }

        // Let the user browse for a file.
        private void btnBrowse_Click(object sender, EventArgs e)
        {
            if (ofdImage.ShowDialog() == DialogResult.OK)
            {
                txtPictureFile.Text = ofdImage.FileName;
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
            this.chkUpdateRegistry = new System.Windows.Forms.CheckBox();
            this.txtPictureFile = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSetDesktop = new System.Windows.Forms.Button();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.ofdImage = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // chkUpdateRegistry
            // 
            this.chkUpdateRegistry.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.chkUpdateRegistry.AutoSize = true;
            this.chkUpdateRegistry.Location = new System.Drawing.Point(121, 37);
            this.chkUpdateRegistry.Name = "chkUpdateRegistry";
            this.chkUpdateRegistry.Size = new System.Drawing.Size(102, 17);
            this.chkUpdateRegistry.TabIndex = 6;
            this.chkUpdateRegistry.Text = "Update Registry";
            this.chkUpdateRegistry.UseVisualStyleBackColor = true;
            // 
            // txtPictureFile
            // 
            this.txtPictureFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPictureFile.Location = new System.Drawing.Point(61, 11);
            this.txtPictureFile.Name = "txtPictureFile";
            this.txtPictureFile.Size = new System.Drawing.Size(241, 20);
            this.txtPictureFile.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Picture:";
            // 
            // btnSetDesktop
            // 
            this.btnSetDesktop.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnSetDesktop.Location = new System.Drawing.Point(135, 76);
            this.btnSetDesktop.Name = "btnSetDesktop";
            this.btnSetDesktop.Size = new System.Drawing.Size(75, 23);
            this.btnSetDesktop.TabIndex = 5;
            this.btnSetDesktop.Text = "Set Desktop";
            this.btnSetDesktop.UseVisualStyleBackColor = true;
            this.btnSetDesktop.Click += new System.EventHandler(this.btnSetDesktop_Click);
            // 
            // btnBrowse
            // 
            this.btnBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBrowse.Image = Properties.Resources.Ellipsis;
            this.btnBrowse.Location = new System.Drawing.Point(308, 11);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(24, 20);
            this.btnBrowse.TabIndex = 7;
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // ofdImage
            // 
            this.ofdImage.CheckFileExists = false;
            this.ofdImage.FileName = "openFileDialog1";
            this.ofdImage.Filter = "Image Files|*.bmp;*.png;*.jpg;*.tif;*.gif|All Files|*.*";
            // 
            // howto_set_desktop_background_Form1
            // 
            this.AcceptButton = this.btnSetDesktop;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(344, 111);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.chkUpdateRegistry);
            this.Controls.Add(this.txtPictureFile);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSetDesktop);
            this.Name = "howto_set_desktop_background_Form1";
            this.Text = "howto_set_desktop_background";
            this.Load += new System.EventHandler(this.howto_set_desktop_background_Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chkUpdateRegistry;
        private System.Windows.Forms.TextBox txtPictureFile;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSetDesktop;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.OpenFileDialog ofdImage;
    }
}

