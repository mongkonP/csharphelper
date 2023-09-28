using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Runtime.InteropServices;

 

namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_get_volume_serial_number_Form1:Form
  { 


        [DllImport("kernel32.dll")]
        private static extern long GetVolumeInformation(
            string PathName,
            StringBuilder VolumeNameBuffer,
            UInt32 VolumeNameSize,
            ref UInt32 VolumeSerialNumber,
            ref UInt32 MaximumComponentLength,
            ref UInt32 FileSystemFlags,
            StringBuilder FileSystemNameBuffer,
            UInt32 FileSystemNameSize);

        public howto_get_volume_serial_number_Form1()
        {
            InitializeComponent();
        }

        private void btnGetInformation_Click(object sender, EventArgs e)
        {
            string drive_letter = txtDisk.Text;
            drive_letter = drive_letter.Substring(0, 1) + ":\\";

            uint serial_number = 0;
            uint max_component_length = 0;
            StringBuilder sb_volume_name = new StringBuilder(256);
            UInt32 file_system_flags = new UInt32();
            StringBuilder sb_file_system_name = new StringBuilder(256);

            if (GetVolumeInformation(drive_letter, sb_volume_name,
                (UInt32)sb_volume_name.Capacity, ref serial_number,
                ref max_component_length, ref file_system_flags,
                sb_file_system_name,
                (UInt32)sb_file_system_name.Capacity) == 0)
            {
                MessageBox.Show(
                    "Error getting volume information.",
                    "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
            }
            else
            {
                txtVolumeName.Text = sb_volume_name.ToString();
                txtSerialNumber.Text = serial_number.ToString();
                txtMaxComponentLength.Text = max_component_length.ToString();
                txtFileSystem.Text = sb_file_system_name.ToString();
                txtFlags.Text = "&&H" + file_system_flags.ToString("x");
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
            this.txtFlags = new System.Windows.Forms.TextBox();
            this.txtFileSystem = new System.Windows.Forms.TextBox();
            this.txtMaxComponentLength = new System.Windows.Forms.TextBox();
            this.txtSerialNumber = new System.Windows.Forms.TextBox();
            this.txtVolumeName = new System.Windows.Forms.TextBox();
            this.btnGetInformation = new System.Windows.Forms.Button();
            this.txtDisk = new System.Windows.Forms.TextBox();
            this._Label1_6 = new System.Windows.Forms.Label();
            this._Label1_5 = new System.Windows.Forms.Label();
            this._Label1_4 = new System.Windows.Forms.Label();
            this._Label1_3 = new System.Windows.Forms.Label();
            this._Label1_2 = new System.Windows.Forms.Label();
            this._Label1_0 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtFlags
            // 
            this.txtFlags.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFlags.Location = new System.Drawing.Point(136, 162);
            this.txtFlags.Name = "txtFlags";
            this.txtFlags.ReadOnly = true;
            this.txtFlags.Size = new System.Drawing.Size(212, 20);
            this.txtFlags.TabIndex = 56;
            // 
            // txtFileSystem
            // 
            this.txtFileSystem.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFileSystem.Location = new System.Drawing.Point(136, 136);
            this.txtFileSystem.Name = "txtFileSystem";
            this.txtFileSystem.ReadOnly = true;
            this.txtFileSystem.Size = new System.Drawing.Size(212, 20);
            this.txtFileSystem.TabIndex = 55;
            // 
            // txtMaxComponentLength
            // 
            this.txtMaxComponentLength.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMaxComponentLength.Location = new System.Drawing.Point(136, 110);
            this.txtMaxComponentLength.Name = "txtMaxComponentLength";
            this.txtMaxComponentLength.ReadOnly = true;
            this.txtMaxComponentLength.Size = new System.Drawing.Size(212, 20);
            this.txtMaxComponentLength.TabIndex = 54;
            // 
            // txtSerialNumber
            // 
            this.txtSerialNumber.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSerialNumber.Location = new System.Drawing.Point(136, 84);
            this.txtSerialNumber.Name = "txtSerialNumber";
            this.txtSerialNumber.ReadOnly = true;
            this.txtSerialNumber.Size = new System.Drawing.Size(212, 20);
            this.txtSerialNumber.TabIndex = 53;
            // 
            // txtVolumeName
            // 
            this.txtVolumeName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtVolumeName.Location = new System.Drawing.Point(136, 58);
            this.txtVolumeName.Name = "txtVolumeName";
            this.txtVolumeName.ReadOnly = true;
            this.txtVolumeName.Size = new System.Drawing.Size(212, 20);
            this.txtVolumeName.TabIndex = 52;
            // 
            // btnGetInformation
            // 
            this.btnGetInformation.BackColor = System.Drawing.SystemColors.Control;
            this.btnGetInformation.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnGetInformation.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGetInformation.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnGetInformation.Location = new System.Drawing.Point(136, 8);
            this.btnGetInformation.Name = "btnGetInformation";
            this.btnGetInformation.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnGetInformation.Size = new System.Drawing.Size(97, 25);
            this.btnGetInformation.TabIndex = 46;
            this.btnGetInformation.Text = "Get Information";
            this.btnGetInformation.UseVisualStyleBackColor = false;
            this.btnGetInformation.Click += new System.EventHandler(this.btnGetInformation_Click);
            // 
            // txtDisk
            // 
            this.txtDisk.AcceptsReturn = true;
            this.txtDisk.BackColor = System.Drawing.SystemColors.Window;
            this.txtDisk.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtDisk.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDisk.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtDisk.Location = new System.Drawing.Point(42, 10);
            this.txtDisk.MaxLength = 0;
            this.txtDisk.Name = "txtDisk";
            this.txtDisk.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtDisk.Size = new System.Drawing.Size(41, 20);
            this.txtDisk.TabIndex = 45;
            this.txtDisk.Text = "C:\\";
            // 
            // _Label1_6
            // 
            this._Label1_6.AutoSize = true;
            this._Label1_6.BackColor = System.Drawing.SystemColors.Control;
            this._Label1_6.Cursor = System.Windows.Forms.Cursors.Default;
            this._Label1_6.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Label1_6.ForeColor = System.Drawing.SystemColors.ControlText;
            this._Label1_6.Location = new System.Drawing.Point(10, 57);
            this._Label1_6.Name = "_Label1_6";
            this._Label1_6.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._Label1_6.Size = new System.Drawing.Size(72, 14);
            this._Label1_6.TabIndex = 51;
            this._Label1_6.Text = "Volume Name";
            // 
            // _Label1_5
            // 
            this._Label1_5.AutoSize = true;
            this._Label1_5.BackColor = System.Drawing.SystemColors.Control;
            this._Label1_5.Cursor = System.Windows.Forms.Cursors.Default;
            this._Label1_5.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Label1_5.ForeColor = System.Drawing.SystemColors.ControlText;
            this._Label1_5.Location = new System.Drawing.Point(10, 139);
            this._Label1_5.Name = "_Label1_5";
            this._Label1_5.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._Label1_5.Size = new System.Drawing.Size(62, 14);
            this._Label1_5.TabIndex = 50;
            this._Label1_5.Text = "File System";
            // 
            // _Label1_4
            // 
            this._Label1_4.AutoSize = true;
            this._Label1_4.BackColor = System.Drawing.SystemColors.Control;
            this._Label1_4.Cursor = System.Windows.Forms.Cursors.Default;
            this._Label1_4.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Label1_4.ForeColor = System.Drawing.SystemColors.ControlText;
            this._Label1_4.Location = new System.Drawing.Point(10, 165);
            this._Label1_4.Name = "_Label1_4";
            this._Label1_4.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._Label1_4.Size = new System.Drawing.Size(33, 14);
            this._Label1_4.TabIndex = 49;
            this._Label1_4.Text = "Flags";
            // 
            // _Label1_3
            // 
            this._Label1_3.AutoSize = true;
            this._Label1_3.BackColor = System.Drawing.SystemColors.Control;
            this._Label1_3.Cursor = System.Windows.Forms.Cursors.Default;
            this._Label1_3.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Label1_3.ForeColor = System.Drawing.SystemColors.ControlText;
            this._Label1_3.Location = new System.Drawing.Point(10, 113);
            this._Label1_3.Name = "_Label1_3";
            this._Label1_3.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._Label1_3.Size = new System.Drawing.Size(120, 14);
            this._Label1_3.TabIndex = 48;
            this._Label1_3.Text = "Max Component Length";
            // 
            // _Label1_2
            // 
            this._Label1_2.AutoSize = true;
            this._Label1_2.BackColor = System.Drawing.SystemColors.Control;
            this._Label1_2.Cursor = System.Windows.Forms.Cursors.Default;
            this._Label1_2.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Label1_2.ForeColor = System.Drawing.SystemColors.ControlText;
            this._Label1_2.Location = new System.Drawing.Point(10, 87);
            this._Label1_2.Name = "_Label1_2";
            this._Label1_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._Label1_2.Size = new System.Drawing.Size(74, 14);
            this._Label1_2.TabIndex = 47;
            this._Label1_2.Text = "Serial Number";
            // 
            // _Label1_0
            // 
            this._Label1_0.AutoSize = true;
            this._Label1_0.BackColor = System.Drawing.SystemColors.Control;
            this._Label1_0.Cursor = System.Windows.Forms.Cursors.Default;
            this._Label1_0.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Label1_0.ForeColor = System.Drawing.SystemColors.ControlText;
            this._Label1_0.Location = new System.Drawing.Point(10, 10);
            this._Label1_0.Name = "_Label1_0";
            this._Label1_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._Label1_0.Size = new System.Drawing.Size(27, 14);
            this._Label1_0.TabIndex = 44;
            this._Label1_0.Text = "Disk";
            // 
            // howto_get_volume_serial_number_Form1
            // 
            this.AcceptButton = this.btnGetInformation;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(358, 192);
            this.Controls.Add(this.txtFlags);
            this.Controls.Add(this.txtFileSystem);
            this.Controls.Add(this.txtMaxComponentLength);
            this.Controls.Add(this.txtSerialNumber);
            this.Controls.Add(this.txtVolumeName);
            this.Controls.Add(this.btnGetInformation);
            this.Controls.Add(this.txtDisk);
            this.Controls.Add(this._Label1_6);
            this.Controls.Add(this._Label1_5);
            this.Controls.Add(this._Label1_4);
            this.Controls.Add(this._Label1_3);
            this.Controls.Add(this._Label1_2);
            this.Controls.Add(this._Label1_0);
            this.Name = "howto_get_volume_serial_number_Form1";
            this.Text = "howto_get_volume_serial_number";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtFlags;
        private System.Windows.Forms.TextBox txtFileSystem;
        private System.Windows.Forms.TextBox txtMaxComponentLength;
        private System.Windows.Forms.TextBox txtSerialNumber;
        private System.Windows.Forms.TextBox txtVolumeName;
        public System.Windows.Forms.Button btnGetInformation;
        public System.Windows.Forms.TextBox txtDisk;
        public System.Windows.Forms.Label _Label1_6;
        public System.Windows.Forms.Label _Label1_5;
        public System.Windows.Forms.Label _Label1_4;
        public System.Windows.Forms.Label _Label1_3;
        public System.Windows.Forms.Label _Label1_2;
        public System.Windows.Forms.Label _Label1_0;
    }
}

