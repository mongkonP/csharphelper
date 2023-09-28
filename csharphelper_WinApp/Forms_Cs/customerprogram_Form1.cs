using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.IO;
using System.Runtime.InteropServices;

// Create a setting named ProductKey of type uint.

 

namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class customerprogram_Form1:Form
  { 


        [Flags]
        public enum FileSystemFeature : uint
        {
            // The file system supports case-sensitive file names.
            CaseSensitiveSearch = 1,
            // The file system preserves the case of file names when it places a name on disk.
            CasePreservedNames = 2,
            // The file system supports Unicode in file names as they appear on disk.
            UnicodeOnDisk = 4,
            // The file system preserves and enforces access control lists (ACL).
            PersistentACLS = 8,
            // The file system supports file-based compression.
            FileCompression = 0x10,
            // The file system supports disk quotas.
            VolumeQuotas = 0x20,
            // The file system supports sparse files.
            SupportsSparseFiles = 0x40,
            // The file system supports re-parse points.
            SupportsReparsePoints = 0x80,
            // The specified volume is a compressed volume, for example, a DoubleSpace volume.
            VolumeIsCompressed = 0x8000,
            // The file system supports object identifiers.
            SupportsObjectIDs = 0x10000,
            // The file system supports the Encrypted File System (EFS).
            SupportsEncryption = 0x20000,
            // The file system supports named streams.
            NamedStreams = 0x40000,
            // The specified volume is read-only.
            ReadOnlyVolume = 0x80000,
            // The volume supports a single sequential write.
            SequentialWriteOnce = 0x100000,
            // The volume supports transactions.
            SupportsTransactions = 0x200000,
        }
        // Declare the GetVolumeInformation API function.
        [DllImport("Kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        extern static bool GetVolumeInformation(
          string RootPathName,
          StringBuilder VolumeNameBuffer,
          int VolumeNameSize,
          out UInt32 VolumeSerialNumber,
          out UInt32 MaximumComponentLength,
          out FileSystemFeature FileSystemFlags,
          StringBuilder FileSystemNameBuffer,
          int nFileSystemNameSize);

        public customerprogram_Form1()
        {
            InitializeComponent();
        }

        // If the program isn't registered, exit.
        private void customerprogram_Form1_Load(object sender, EventArgs e)
        {
            // An arbitrary number to identify this program.
            const UInt32 program_id = 2267918298;

            if (!IsRegistered(program_id, false)) this.Close();
        }

        // Return true if the program is properly registered.
        private bool IsRegistered(UInt32 program_id, bool default_value)
        {
            StringBuilder volume_name = new StringBuilder(1024);
            StringBuilder file_system_name = new StringBuilder(1024);
            UInt32 serial_number, max_component_length;
            FileSystemFeature file_system_flags;

            // Get the startup directory's drive letter.
            // Get the drive where the program is running.
            FileInfo file_info = new FileInfo(Application.StartupPath);
            string drive_letter = file_info.Directory.Root.Name;

            // Get the information. If we fail, return the default value.
            if (!GetVolumeInformation(drive_letter, volume_name,
                volume_name.Capacity, out serial_number, out max_component_length,
                out file_system_flags, file_system_name, file_system_name.Capacity))
            {
                return default_value;
            }

            // Encrypt the serial number to get the product key.
            UInt32 product_key = Encrypt(program_id, serial_number);

            // If this matches the saved product key, then the program is registered.
            if (Properties.Settings.Default.ProductKey == product_key) return true;

            // It's not registered properly.
            // Display the registration form.
            customerprogram_RegistrationForm frm = new  customerprogram_RegistrationForm();
            frm.txtProductNumber.Text = serial_number.ToString();
            if (frm.ShowDialog() == DialogResult.Cancel) return false;

            // See if the product key matches.
            UInt32 entered_key = 0;
            try
            {
                entered_key = UInt32.Parse(frm.txtProductKey.Text);
            }
            catch
            {
            }
            if (entered_key == product_key)
            {
                Properties.Settings.Default.ProductKey = entered_key;
                Properties.Settings.Default.Save();
                return true;
            }

            // No match. Give up.
            MessageBox.Show("Incorrect product key.", "Invalid Key",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            return false;
        }

        // Simple encryption and decryption.
        private UInt32 Encrypt(UInt32 seed, UInt32 value)
        {
            Random rand = new Random((int)seed);
            return (value ^ (UInt32)(UInt32.MaxValue * rand.NextDouble()));
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
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Blue;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(276, 123);
            this.label1.TabIndex = 0;
            this.label1.Text = "Congratulations, you registered successfully!";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // customerprogram_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(300, 141);
            this.Controls.Add(this.label1);
            this.Name = "customerprogram_Form1";
            this.Text = "CustomerProgram";
            this.Load += new System.EventHandler(this.customerprogram_Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
    }
}

