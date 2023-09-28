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
     public partial class howto_hide_taskbar_Form1:Form
  { 


        public howto_hide_taskbar_Form1()
        {
            InitializeComponent();
        }

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, SetWindowPosFlags uFlags);

        [Flags]
        private enum SetWindowPosFlags : uint
        {
            SWP_ASYNCWINDOWPOS = 0x4000,
            SWP_DEFERERASE = 0x2000,
            SWP_DRAWFRAME = 0x0020,
            SWP_FRAMECHANGED = 0x0020,
            SWP_HIDEWINDOW = 0x0080,
            SWP_NOACTIVATE = 0x0010,
            SWP_NOCOPYBITS = 0x0100,
            SWP_NOMOVE = 0x0002,
            SWP_NOOWNERZORDER = 0x0200,
            SWP_NOREDRAW = 0x0008,
            SWP_NOREPOSITION = 0x0200,
            SWP_NOSENDCHANGING = 0x0400,
            SWP_NOSIZE = 0x0001,
            SWP_NOZORDER = 0x0004,
            SWP_SHOWWINDOW = 0x0040,
        }

        [DllImport("user32", EntryPoint = "FindWindowA", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        private static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        [DllImport("user32.dll")]
        private static extern IntPtr FindWindowEx(IntPtr parentHwnd, IntPtr childAfterHwnd, IntPtr className, string windowText);

        [DllImport("user32.dll", SetLastError = true)]
        private static extern IntPtr GetWindow(IntPtr hWnd, GetWindowCmd uCmd);

        private enum GetWindowCmd : uint
        {
            GW_HWNDFIRST = 0,
            GW_HWNDLAST = 1,
            GW_HWNDNEXT = 2,
            GW_HWNDPREV = 3,
            GW_OWNER = 4,
            GW_CHILD = 5,
            GW_ENABLEDPOPUP = 6
        }

        // The taskbar's window handle.
        private IntPtr TaskbarHWnd, StartButtonHWnd;

        // Hide the taskbar and start button.
        private void howto_hide_taskbar_Form1_Load(object sender, EventArgs e)
        {
            // Get the taskbar's and start button's window handles.
            TaskbarHWnd = FindWindow("Shell_traywnd", "");
            StartButtonHWnd = FindWindowEx(IntPtr.Zero, IntPtr.Zero, (IntPtr)0xC017, null);

            // Hide the taskbar and start button.
            SetWindowPos(TaskbarHWnd, IntPtr.Zero, 0, 0, 0, 0,
                SetWindowPosFlags.SWP_HIDEWINDOW);
            SetWindowPos(StartButtonHWnd, IntPtr.Zero, 0, 0, 0, 0,
                SetWindowPosFlags.SWP_HIDEWINDOW);

            // Maximize.
            this.Bounds = Screen.PrimaryScreen.Bounds;
        }

        // Restore the taskbar and start button.
        private void howto_hide_taskbar_Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            SetWindowPos(TaskbarHWnd, IntPtr.Zero, 0, 0, 0, 0,
                SetWindowPosFlags.SWP_SHOWWINDOW);
            SetWindowPos(StartButtonHWnd, IntPtr.Zero, 0, 0, 0, 0,
                SetWindowPosFlags.SWP_SHOWWINDOW);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
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
            this.btnClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnClose.Location = new System.Drawing.Point(105, 119);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 0;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // howto_hide_taskbar_Form1
            // 
            this.AcceptButton = this.btnClose;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.btnClose);
            this.Name = "howto_hide_taskbar_Form1";
            this.Text = "howto_hide_taskbar";
            this.Load += new System.EventHandler(this.howto_hide_taskbar_Form1_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.howto_hide_taskbar_Form1_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnClose;
    }
}

