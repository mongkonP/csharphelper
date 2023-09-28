using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Microsoft.Win32;
using System.Runtime.InteropServices;

 

using howto_refresh_desktop_icons;
namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_refresh_desktop_icons_Form1:Form
  { 


        [Flags]
        private enum SendMessageTimeoutFlags : uint
        {
            SMTO_NORMAL = 0x0,
            SMTO_BLOCK = 0x1,
            SMTO_ABORTIFHUNG = 0x2,
            SMTO_NOTIMEOUTIFNOTHUNG = 0x8
        }
        private IntPtr HWND_BROADCAST = new IntPtr(0xffff);
        private const UInt32 WM_SETTINGCHANGE = 0x001A;
        private const uint SPI_SETNONCLIENTMETRICS = 0x002A;

        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        private static extern IntPtr SendMessageTimeout(
            IntPtr windowHandle,
            uint Msg,
            uint wParam,
            uint lParam,
            SendMessageTimeoutFlags flags,
            uint timeout,
            out IntPtr result);

        public howto_refresh_desktop_icons_Form1()
        {
            InitializeComponent();
        }

        private void btnRefreshIcons_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            btnRefreshIcons.Enabled = false;
            Refresh();

            // Get the current icon size.
            object icon_size_string = RegistryTools.GetRegistryValue(
                Registry.CurrentUser,
                @"Control Panel\Desktop\WindowMetrics",
                "Shell Icon Size", 32);
            int icon_size = int.Parse(icon_size_string.ToString());

            // Add 1 and set the new size.
            icon_size++;
            RegistryTools.SetRegistryValue(
                Registry.CurrentUser,
                @"Control Panel\Desktop\WindowMetrics",
                "Shell Icon Size", icon_size);

            // Send HWND_BROADCAST to refresh the icons.
            IntPtr result;
            SendMessageTimeout(
                HWND_BROADCAST, WM_SETTINGCHANGE,
                SPI_SETNONCLIENTMETRICS, 0,
                SendMessageTimeoutFlags.SMTO_ABORTIFHUNG,
                10000, out result);

            // Restore the original value.
            icon_size--;
            RegistryTools.SetRegistryValue(
                Registry.CurrentUser,
                @"Control Panel\Desktop\WindowMetrics",
                "Shell Icon Size", icon_size);

            // Send HWND_BROADCAST to refresh the icons again.
            SendMessageTimeout(
                HWND_BROADCAST, WM_SETTINGCHANGE,
                SPI_SETNONCLIENTMETRICS, 0,
                SendMessageTimeoutFlags.SMTO_ABORTIFHUNG,
                10000, out result);

            Cursor = Cursors.Default;
            btnRefreshIcons.Enabled = true;
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
            this.btnRefreshIcons = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnRefreshIcons
            // 
            this.btnRefreshIcons.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnRefreshIcons.Location = new System.Drawing.Point(122, 24);
            this.btnRefreshIcons.Name = "btnRefreshIcons";
            this.btnRefreshIcons.Size = new System.Drawing.Size(111, 38);
            this.btnRefreshIcons.TabIndex = 1;
            this.btnRefreshIcons.Text = "Refresh Icons";
            this.btnRefreshIcons.UseVisualStyleBackColor = true;
            this.btnRefreshIcons.Click += new System.EventHandler(this.btnRefreshIcons_Click);
            // 
            // howto_refresh_desktop_icons_Form1
            // 
            this.AcceptButton = this.btnRefreshIcons;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(354, 86);
            this.Controls.Add(this.btnRefreshIcons);
            this.Name = "howto_refresh_desktop_icons_Form1";
            this.Text = "howto_refresh_desktop_icons";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnRefreshIcons;
    }
}

