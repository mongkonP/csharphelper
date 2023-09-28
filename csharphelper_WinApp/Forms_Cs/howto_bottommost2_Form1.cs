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
     public partial class howto_bottommost2_Form1:Form
  { 


        public howto_bottommost2_Form1()
        {
            InitializeComponent();
        }

        [DllImport("user32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool SetWindowPos(
            IntPtr hWnd, IntPtr hWndInsertAfter,
            int x, int y, int cx, int cy, uint uFlags);

        // Constants for positioning the window.
        private IntPtr HWND_BOTTOM = (IntPtr)1;
        private const UInt32 SWP_NOMOVE = 0x0002;
        private const UInt32 SWP_NOSIZE = 0x0001;

        // Move to the bottom.
        private void MoveToBottom()
        {
            UInt32 flags = SWP_NOSIZE | SWP_NOMOVE;
            if (!SetWindowPos(this.Handle, HWND_BOTTOM, 0, 0, 0, 0, flags))
                Console.WriteLine("Error in SetWindowPos");
        }

        private void radOption_Click(object sender, EventArgs e)
        {
            this.TopMost = radTopmost.Checked;
            tmrMoveToBottom.Enabled = radBottommost.Checked;
        }

        // Move the form to the bottom.
        private void tmrMoveToBottom_Tick(object sender, EventArgs e)
        {
            MoveToBottom();
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
            this.components = new System.ComponentModel.Container();
            this.radBottommost = new System.Windows.Forms.RadioButton();
            this.radTopmost = new System.Windows.Forms.RadioButton();
            this.radNormal = new System.Windows.Forms.RadioButton();
            this.tmrMoveToBottom = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // radBottommost
            // 
            this.radBottommost.AutoSize = true;
            this.radBottommost.Location = new System.Drawing.Point(12, 58);
            this.radBottommost.Name = "radBottommost";
            this.radBottommost.Size = new System.Drawing.Size(80, 17);
            this.radBottommost.TabIndex = 8;
            this.radBottommost.Text = "Bottommost";
            this.radBottommost.UseVisualStyleBackColor = true;
            this.radBottommost.Click += new System.EventHandler(this.radOption_Click);
            // 
            // radTopmost
            // 
            this.radTopmost.AutoSize = true;
            this.radTopmost.Location = new System.Drawing.Point(12, 35);
            this.radTopmost.Name = "radTopmost";
            this.radTopmost.Size = new System.Drawing.Size(66, 17);
            this.radTopmost.TabIndex = 7;
            this.radTopmost.Text = "Topmost";
            this.radTopmost.UseVisualStyleBackColor = true;
            this.radTopmost.Click += new System.EventHandler(this.radOption_Click);
            // 
            // radNormal
            // 
            this.radNormal.AutoSize = true;
            this.radNormal.Checked = true;
            this.radNormal.Location = new System.Drawing.Point(12, 12);
            this.radNormal.Name = "radNormal";
            this.radNormal.Size = new System.Drawing.Size(58, 17);
            this.radNormal.TabIndex = 6;
            this.radNormal.TabStop = true;
            this.radNormal.Text = "Normal";
            this.radNormal.UseVisualStyleBackColor = true;
            this.radNormal.Click += new System.EventHandler(this.radOption_Click);
            // 
            // tmrMoveToBottom
            // 
            this.tmrMoveToBottom.Interval = 500;
            this.tmrMoveToBottom.Tick += new System.EventHandler(this.tmrMoveToBottom_Tick);
            // 
            // howto_bottommost2_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 111);
            this.Controls.Add(this.radBottommost);
            this.Controls.Add(this.radTopmost);
            this.Controls.Add(this.radNormal);
            this.Name = "howto_bottommost2_Form1";
            this.Text = "howto_bottommost2";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton radBottommost;
        private System.Windows.Forms.RadioButton radTopmost;
        private System.Windows.Forms.RadioButton radNormal;
        private System.Windows.Forms.Timer tmrMoveToBottom;
    }
}

