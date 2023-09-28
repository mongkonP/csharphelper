using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Runtime.InteropServices;
using System.Security;

 

namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_flush_clicks_Form1:Form
  { 


        [StructLayout(LayoutKind.Sequential)]
        public struct NativeMessage
        {
            public IntPtr handle;
            public uint msg;
            public IntPtr wParam;
            public IntPtr lParam;
            public uint time;
            public System.Drawing.Point p;
        }

        [SuppressUnmanagedCodeSecurity]
        [return: MarshalAs(UnmanagedType.Bool)]
        [DllImport("User32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern bool PeekMessage(out NativeMessage message, IntPtr handle, uint filterMin, uint filterMax, uint flags);
        private const UInt32 WM_MOUSEFIRST = 0x0200;
        private const UInt32 WM_MOUSELAST = 0x020D;
        public const int PM_REMOVE = 0x0001;

        // Flush all pending mouse events.
        private void FlushMouseMessages()
        {
            NativeMessage msg;
            // Repeat until PeekMessage returns false.
            while (PeekMessage(out msg, IntPtr.Zero,
                WM_MOUSEFIRST, WM_MOUSELAST, PM_REMOVE))
                ;
        }

        public howto_flush_clicks_Form1()
        {
            InitializeComponent();
        }

        // Wait for 5 seconds.
        private void btnWaitNow_Click(object sender, EventArgs e)
        {
            // None of these seem to work.
            //this.Enabled = false;
            //btnWaitNow.Click -= btnWaitNow_Click;
            btnWaitNow.Enabled = false;
            this.Cursor = Cursors.WaitCursor;
            Application.DoEvents();

            lstMessages.Items.Add("Wait Now Start " + DateTime.Now.ToString());
            Refresh();
            System.Threading.Thread.Sleep(5000);
            lstMessages.Items.Add("Wait Now Stop  " + DateTime.Now.ToString());

            //this.Enabled = true;
            //btnWaitNow.Click += btnWaitNow_Click;
            btnWaitNow.Enabled = true;
            this.Cursor = Cursors.Default;
        }

        // Wait for 5 seconds and then flush the buffer.
        private void btnWaitAndFlush_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            lstMessages.Items.Add("Wait and Flush Start " + DateTime.Now.ToString());
            Refresh();

            System.Threading.Thread.Sleep(5000);

            lstMessages.Items.Add("Wait and Flush Stop  " + DateTime.Now.ToString());
            FlushMouseMessages();
            this.Cursor = Cursors.Default;
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
            this.btnWaitAndFlush = new System.Windows.Forms.Button();
            this.lstMessages = new System.Windows.Forms.ListBox();
            this.btnWaitNow = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnWaitAndFlush
            // 
            this.btnWaitAndFlush.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnWaitAndFlush.Location = new System.Drawing.Point(177, 12);
            this.btnWaitAndFlush.Name = "btnWaitAndFlush";
            this.btnWaitAndFlush.Size = new System.Drawing.Size(95, 23);
            this.btnWaitAndFlush.TabIndex = 6;
            this.btnWaitAndFlush.Text = "Wait and Flush";
            this.btnWaitAndFlush.UseVisualStyleBackColor = true;
            this.btnWaitAndFlush.Click += new System.EventHandler(this.btnWaitAndFlush_Click);
            // 
            // lstMessages
            // 
            this.lstMessages.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lstMessages.FormattingEnabled = true;
            this.lstMessages.IntegralHeight = false;
            this.lstMessages.Location = new System.Drawing.Point(12, 42);
            this.lstMessages.Name = "lstMessages";
            this.lstMessages.Size = new System.Drawing.Size(260, 157);
            this.lstMessages.TabIndex = 5;
            // 
            // btnWaitNow
            // 
            this.btnWaitNow.Location = new System.Drawing.Point(12, 13);
            this.btnWaitNow.Name = "btnWaitNow";
            this.btnWaitNow.Size = new System.Drawing.Size(95, 23);
            this.btnWaitNow.TabIndex = 4;
            this.btnWaitNow.Text = "Wait Now";
            this.btnWaitNow.UseVisualStyleBackColor = true;
            this.btnWaitNow.Click += new System.EventHandler(this.btnWaitNow_Click);
            // 
            // howto_flush_clicks_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 211);
            this.Controls.Add(this.btnWaitAndFlush);
            this.Controls.Add(this.lstMessages);
            this.Controls.Add(this.btnWaitNow);
            this.Name = "howto_flush_clicks_Form1";
            this.Text = "howto_flush_clicks";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnWaitAndFlush;
        private System.Windows.Forms.ListBox lstMessages;
        private System.Windows.Forms.Button btnWaitNow;
    }
}

