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
     public partial class howto_get_drive_info_Form1:Form
  { 


        public howto_get_drive_info_Form1()
        {
            InitializeComponent();
        }

        // Make a list of drives.
        private void howto_get_drive_info_Form1_Load(object sender, EventArgs e)
        {
            foreach (DriveInfo di in DriveInfo.GetDrives())
            {
                cboDrive.Items.Add(di.Name);
                cboDrive.SelectedIndex = 0;
            }
        }

        // Display information about the selected drive.
        private void cboDrive_SelectedIndexChanged(object sender, EventArgs e)
        {
            string drive_letter = cboDrive.Text.Substring(0, 1);
            DriveInfo di = new DriveInfo(drive_letter);
            lblIsReady.Text = di.IsReady.ToString();
            lblDriveType.Text = di.DriveType.ToString();
            lblName.Text = di.Name;
            lblRootDirectory.Text = di.RootDirectory.Name;
            if (di.IsReady)
            {
                lblDriveFormat.Text = di.DriveFormat;
                lblAvailableFreeSpace.Text = di.AvailableFreeSpace.ToString();
                lblTotalFreeSize.Text = di.TotalFreeSpace.ToString();
                lblTotalSize.Text = di.TotalSize.ToString();
                lblVolumeLabel.Text = di.VolumeLabel;
            }
            else
            {
                lblDriveFormat.Text = "";
                lblAvailableFreeSpace.Text = "";
                lblTotalFreeSize.Text = "";
                lblTotalSize.Text = "";
                lblVolumeLabel.Text = "";
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
            this.lblDriveFormat = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblAvailableFreeSpace = new System.Windows.Forms.Label();
            this.lblTotalFreeSize = new System.Windows.Forms.Label();
            this.lblTotalSize = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this._Label1_0 = new System.Windows.Forms.Label();
            this.lblVolumeLabel = new System.Windows.Forms.Label();
            this.lblRootDirectory = new System.Windows.Forms.Label();
            this.lblIsReady = new System.Windows.Forms.Label();
            this.lblDriveType = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.cboDrive = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // lblDriveFormat
            // 
            this.lblDriveFormat.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDriveFormat.BackColor = System.Drawing.SystemColors.Control;
            this.lblDriveFormat.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblDriveFormat.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblDriveFormat.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDriveFormat.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblDriveFormat.Location = new System.Drawing.Point(128, 144);
            this.lblDriveFormat.Name = "lblDriveFormat";
            this.lblDriveFormat.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblDriveFormat.Size = new System.Drawing.Size(172, 14);
            this.lblDriveFormat.TabIndex = 51;
            // 
            // lblName
            // 
            this.lblName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblName.BackColor = System.Drawing.SystemColors.Control;
            this.lblName.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblName.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblName.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblName.Location = new System.Drawing.Point(128, 50);
            this.lblName.Name = "lblName";
            this.lblName.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblName.Size = new System.Drawing.Size(172, 14);
            this.lblName.TabIndex = 50;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.Control;
            this.label1.Cursor = System.Windows.Forms.Cursors.Default;
            this.label1.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(8, 48);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label1.Size = new System.Drawing.Size(34, 14);
            this.label1.TabIndex = 49;
            this.label1.Text = "Name";
            // 
            // lblAvailableFreeSpace
            // 
            this.lblAvailableFreeSpace.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblAvailableFreeSpace.BackColor = System.Drawing.SystemColors.Control;
            this.lblAvailableFreeSpace.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblAvailableFreeSpace.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblAvailableFreeSpace.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAvailableFreeSpace.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblAvailableFreeSpace.Location = new System.Drawing.Point(128, 120);
            this.lblAvailableFreeSpace.Name = "lblAvailableFreeSpace";
            this.lblAvailableFreeSpace.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblAvailableFreeSpace.Size = new System.Drawing.Size(170, 16);
            this.lblAvailableFreeSpace.TabIndex = 48;
            // 
            // lblTotalFreeSize
            // 
            this.lblTotalFreeSize.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTotalFreeSize.BackColor = System.Drawing.SystemColors.Control;
            this.lblTotalFreeSize.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblTotalFreeSize.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblTotalFreeSize.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalFreeSize.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblTotalFreeSize.Location = new System.Drawing.Point(128, 98);
            this.lblTotalFreeSize.Name = "lblTotalFreeSize";
            this.lblTotalFreeSize.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblTotalFreeSize.Size = new System.Drawing.Size(172, 14);
            this.lblTotalFreeSize.TabIndex = 47;
            // 
            // lblTotalSize
            // 
            this.lblTotalSize.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTotalSize.BackColor = System.Drawing.SystemColors.Control;
            this.lblTotalSize.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblTotalSize.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblTotalSize.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalSize.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblTotalSize.Location = new System.Drawing.Point(128, 74);
            this.lblTotalSize.Name = "lblTotalSize";
            this.lblTotalSize.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblTotalSize.Size = new System.Drawing.Size(172, 14);
            this.lblTotalSize.TabIndex = 46;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.SystemColors.Control;
            this.label4.Cursor = System.Windows.Forms.Cursors.Default;
            this.label4.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label4.Location = new System.Drawing.Point(8, 118);
            this.label4.Name = "label4";
            this.label4.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label4.Size = new System.Drawing.Size(110, 14);
            this.label4.TabIndex = 45;
            this.label4.Text = "Available Free Space";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.SystemColors.Control;
            this.label5.Cursor = System.Windows.Forms.Cursors.Default;
            this.label5.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label5.Location = new System.Drawing.Point(8, 144);
            this.label5.Name = "label5";
            this.label5.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label5.Size = new System.Drawing.Size(40, 14);
            this.label5.TabIndex = 44;
            this.label5.Text = "Format";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.SystemColors.Control;
            this.label3.Cursor = System.Windows.Forms.Cursors.Default;
            this.label3.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label3.Location = new System.Drawing.Point(8, 96);
            this.label3.Name = "label3";
            this.label3.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label3.Size = new System.Drawing.Size(79, 14);
            this.label3.TabIndex = 43;
            this.label3.Text = "Total Free Size";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.Control;
            this.label2.Cursor = System.Windows.Forms.Cursors.Default;
            this.label2.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(8, 72);
            this.label2.Name = "label2";
            this.label2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label2.Size = new System.Drawing.Size(54, 14);
            this.label2.TabIndex = 42;
            this.label2.Text = "Total Size";
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
            this._Label1_0.Size = new System.Drawing.Size(32, 14);
            this._Label1_0.TabIndex = 39;
            this._Label1_0.Text = "Drive";
            // 
            // lblVolumeLabel
            // 
            this.lblVolumeLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblVolumeLabel.BackColor = System.Drawing.SystemColors.Control;
            this.lblVolumeLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblVolumeLabel.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblVolumeLabel.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVolumeLabel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblVolumeLabel.Location = new System.Drawing.Point(128, 238);
            this.lblVolumeLabel.Name = "lblVolumeLabel";
            this.lblVolumeLabel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblVolumeLabel.Size = new System.Drawing.Size(172, 14);
            this.lblVolumeLabel.TabIndex = 60;
            // 
            // lblRootDirectory
            // 
            this.lblRootDirectory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblRootDirectory.BackColor = System.Drawing.SystemColors.Control;
            this.lblRootDirectory.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblRootDirectory.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblRootDirectory.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRootDirectory.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblRootDirectory.Location = new System.Drawing.Point(128, 214);
            this.lblRootDirectory.Name = "lblRootDirectory";
            this.lblRootDirectory.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblRootDirectory.Size = new System.Drawing.Size(170, 16);
            this.lblRootDirectory.TabIndex = 59;
            // 
            // lblIsReady
            // 
            this.lblIsReady.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblIsReady.BackColor = System.Drawing.SystemColors.Control;
            this.lblIsReady.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblIsReady.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblIsReady.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIsReady.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblIsReady.Location = new System.Drawing.Point(128, 192);
            this.lblIsReady.Name = "lblIsReady";
            this.lblIsReady.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblIsReady.Size = new System.Drawing.Size(172, 14);
            this.lblIsReady.TabIndex = 58;
            // 
            // lblDriveType
            // 
            this.lblDriveType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDriveType.BackColor = System.Drawing.SystemColors.Control;
            this.lblDriveType.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblDriveType.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblDriveType.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDriveType.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblDriveType.Location = new System.Drawing.Point(128, 168);
            this.lblDriveType.Name = "lblDriveType";
            this.lblDriveType.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblDriveType.Size = new System.Drawing.Size(172, 14);
            this.lblDriveType.TabIndex = 57;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.SystemColors.Control;
            this.label10.Cursor = System.Windows.Forms.Cursors.Default;
            this.label10.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label10.Location = new System.Drawing.Point(8, 212);
            this.label10.Name = "label10";
            this.label10.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label10.Size = new System.Drawing.Size(76, 14);
            this.label10.TabIndex = 56;
            this.label10.Text = "Root Directory";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.SystemColors.Control;
            this.label11.Cursor = System.Windows.Forms.Cursors.Default;
            this.label11.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label11.Location = new System.Drawing.Point(8, 238);
            this.label11.Name = "label11";
            this.label11.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label11.Size = new System.Drawing.Size(72, 14);
            this.label11.TabIndex = 55;
            this.label11.Text = "Volume Label";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.SystemColors.Control;
            this.label12.Cursor = System.Windows.Forms.Cursors.Default;
            this.label12.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label12.Location = new System.Drawing.Point(8, 190);
            this.label12.Name = "label12";
            this.label12.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label12.Size = new System.Drawing.Size(49, 14);
            this.label12.TabIndex = 54;
            this.label12.Text = "Is Ready";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.SystemColors.Control;
            this.label13.Cursor = System.Windows.Forms.Cursors.Default;
            this.label13.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label13.Location = new System.Drawing.Point(8, 166);
            this.label13.Name = "label13";
            this.label13.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label13.Size = new System.Drawing.Size(31, 14);
            this.label13.TabIndex = 53;
            this.label13.Text = "Type";
            // 
            // cboDrive
            // 
            this.cboDrive.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDrive.FormattingEnabled = true;
            this.cboDrive.Location = new System.Drawing.Point(64, 8);
            this.cboDrive.Name = "cboDrive";
            this.cboDrive.Size = new System.Drawing.Size(48, 21);
            this.cboDrive.TabIndex = 61;
            this.cboDrive.SelectedIndexChanged += new System.EventHandler(this.cboDrive_SelectedIndexChanged);
            // 
            // howto_get_drive_info_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(310, 261);
            this.Controls.Add(this.cboDrive);
            this.Controls.Add(this.lblVolumeLabel);
            this.Controls.Add(this.lblRootDirectory);
            this.Controls.Add(this.lblIsReady);
            this.Controls.Add(this.lblDriveType);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.lblDriveFormat);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblAvailableFreeSpace);
            this.Controls.Add(this.lblTotalFreeSize);
            this.Controls.Add(this.lblTotalSize);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this._Label1_0);
            this.Name = "howto_get_drive_info_Form1";
            this.Text = "howto_get_drive_info_Form1";
            this.Load += new System.EventHandler(this.howto_get_drive_info_Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Label lblDriveFormat;
        public System.Windows.Forms.Label lblName;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.Label lblAvailableFreeSpace;
        public System.Windows.Forms.Label lblTotalFreeSize;
        public System.Windows.Forms.Label lblTotalSize;
        public System.Windows.Forms.Label label4;
        public System.Windows.Forms.Label label5;
        public System.Windows.Forms.Label label3;
        public System.Windows.Forms.Label label2;
        public System.Windows.Forms.Label _Label1_0;
        public System.Windows.Forms.Label lblVolumeLabel;
        public System.Windows.Forms.Label lblRootDirectory;
        public System.Windows.Forms.Label lblIsReady;
        public System.Windows.Forms.Label lblDriveType;
        public System.Windows.Forms.Label label10;
        public System.Windows.Forms.Label label11;
        public System.Windows.Forms.Label label12;
        public System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox cboDrive;
    }
}

