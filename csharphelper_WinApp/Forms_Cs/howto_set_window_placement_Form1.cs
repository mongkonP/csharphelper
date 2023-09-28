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
     public partial class howto_set_window_placement_Form1:Form
  { 


        public howto_set_window_placement_Form1()
        {
            InitializeComponent();
        }

        // Define API functions.
        [DllImport("user32.dll", EntryPoint = "FindWindow", SetLastError = true)]
        static extern IntPtr FindWindowByCaption(IntPtr ZeroOnly, string lpWindowName);

        [DllImport("user32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern bool GetWindowPlacement(IntPtr hWnd, out WINDOWPLACEMENT lpwndpl);

        [DllImport("user32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool SetWindowPlacement(IntPtr hWnd,
           [In] ref WINDOWPLACEMENT lpwndpl);

        [Serializable]
        [StructLayout(LayoutKind.Sequential)]
        internal struct WINDOWPLACEMENT
        {
            public int Length;
            public int Flags;
            public ShowWindowCommands ShowCmd;
            public POINT MinPosition;
            public POINT MaxPosition;
            public RECT NormalPosition;
            public static WINDOWPLACEMENT Default
            {
                get
                {
                    WINDOWPLACEMENT result = new WINDOWPLACEMENT();
                    result.Length = Marshal.SizeOf(result);
                    return result;
                }
            }
        }

        internal enum ShowWindowCommands : int
        {
            Hide = 0,
            Normal = 1,
            ShowMinimized = 2,
            Maximize = 3, // is this the right value?
            ShowMaximized = 3,
            ShowNoActivate = 4,
            Show = 5,
            Minimize = 6,
            ShowMinNoActive = 7,
            ShowNA = 8,
            Restore = 9,
            ShowDefault = 10,
            ForceMinimize = 11
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct POINT
        {
            public int X;
            public int Y;

            public POINT(int x, int y)
            {
                this.X = x;
                this.Y = y;
            }

            public static implicit operator System.Drawing.Point(POINT p)
            {
                return new System.Drawing.Point(p.X, p.Y);
            }

            public static implicit operator POINT(System.Drawing.Point p)
            {
                return new POINT(p.X, p.Y);
            }
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct RECT
        {
            private int _Left;
            private int _Top;
            private int _Right;
            private int _Bottom;
        }

        // Set the target's placement.
        private void btnSet_Click(object sender, EventArgs e)
        {
            // Get the target window's handle.
            IntPtr target_hwnd = FindWindowByCaption(IntPtr.Zero, txtAppTitle.Text);
            if (target_hwnd == IntPtr.Zero)
            {
                MessageBox.Show("Could not find a window with the title \"" +
                    txtAppTitle.Text + "\"");
                return;
            }

            // Prepare the WINDOWPLACEMENT structure.
            WINDOWPLACEMENT placement = new WINDOWPLACEMENT();
            placement.Length = Marshal.SizeOf(placement);

            // Get the window's current placement.
            GetWindowPlacement(target_hwnd, out placement);

            // Set the placement's action.
            if (radMaximized.Checked)
                placement.ShowCmd = ShowWindowCommands.ShowMaximized;
            else if (radMinimized.Checked)
                placement.ShowCmd = ShowWindowCommands.ShowMinimized;
            else
                placement.ShowCmd = ShowWindowCommands.Normal;

            // Perform the action.
            SetWindowPlacement(target_hwnd, ref placement);
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
            this.radNormal = new System.Windows.Forms.RadioButton();
            this.radMinimized = new System.Windows.Forms.RadioButton();
            this.radMaximized = new System.Windows.Forms.RadioButton();
            this.btnSet = new System.Windows.Forms.Button();
            this.txtAppTitle = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // radNormal
            // 
            this.radNormal.AutoSize = true;
            this.radNormal.Checked = true;
            this.radNormal.Location = new System.Drawing.Point(15, 109);
            this.radNormal.Name = "radNormal";
            this.radNormal.Size = new System.Drawing.Size(58, 17);
            this.radNormal.TabIndex = 30;
            this.radNormal.TabStop = true;
            this.radNormal.Text = "Normal";
            this.radNormal.UseVisualStyleBackColor = true;
            // 
            // radMinimized
            // 
            this.radMinimized.AutoSize = true;
            this.radMinimized.Location = new System.Drawing.Point(15, 86);
            this.radMinimized.Name = "radMinimized";
            this.radMinimized.Size = new System.Drawing.Size(71, 17);
            this.radMinimized.TabIndex = 29;
            this.radMinimized.TabStop = true;
            this.radMinimized.Text = "Minimized";
            this.radMinimized.UseVisualStyleBackColor = true;
            // 
            // radMaximized
            // 
            this.radMaximized.AutoSize = true;
            this.radMaximized.Location = new System.Drawing.Point(15, 63);
            this.radMaximized.Name = "radMaximized";
            this.radMaximized.Size = new System.Drawing.Size(74, 17);
            this.radMaximized.TabIndex = 28;
            this.radMaximized.TabStop = true;
            this.radMaximized.Text = "Maximized";
            this.radMaximized.UseVisualStyleBackColor = true;
            // 
            // btnSet
            // 
            this.btnSet.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSet.Location = new System.Drawing.Point(247, 86);
            this.btnSet.Name = "btnSet";
            this.btnSet.Size = new System.Drawing.Size(75, 23);
            this.btnSet.TabIndex = 27;
            this.btnSet.Text = "Set";
            this.btnSet.UseVisualStyleBackColor = true;
            this.btnSet.Click += new System.EventHandler(this.btnSet_Click);
            // 
            // txtAppTitle
            // 
            this.txtAppTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAppTitle.Location = new System.Drawing.Point(70, 21);
            this.txtAppTitle.Name = "txtAppTitle";
            this.txtAppTitle.Size = new System.Drawing.Size(252, 20);
            this.txtAppTitle.TabIndex = 26;
            this.txtAppTitle.Text = "Document - WordPad";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 25;
            this.label1.Text = "App Title:";
            // 
            // howto_set_window_placement_Form1
            // 
            this.AcceptButton = this.btnSet;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(334, 146);
            this.Controls.Add(this.radNormal);
            this.Controls.Add(this.radMinimized);
            this.Controls.Add(this.radMaximized);
            this.Controls.Add(this.btnSet);
            this.Controls.Add(this.txtAppTitle);
            this.Controls.Add(this.label1);
            this.Name = "howto_set_window_placement_Form1";
            this.Text = "howto_set_window_placement";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton radNormal;
        private System.Windows.Forms.RadioButton radMinimized;
        private System.Windows.Forms.RadioButton radMaximized;
        private System.Windows.Forms.Button btnSet;
        private System.Windows.Forms.TextBox txtAppTitle;
        private System.Windows.Forms.Label label1;
    }
}

