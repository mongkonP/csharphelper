using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Runtime.InteropServices;
using System.Drawing.Drawing2D;

 

namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_move_click_mouse_Form1:Form
  { 


        public howto_move_click_mouse_Form1()
        {
            InitializeComponent();
        }

        // See http://www.pinvoke.net/default.aspx/user32/mouse_event.html
        // Mouse event flags.
        [Flags]
        public enum MouseEventFlags : uint
        {
            LEFTDOWN = 0x00000002,
            LEFTUP = 0x00000004,
            MIDDLEDOWN = 0x00000020,
            MIDDLEUP = 0x00000040,
            MOVE = 0x00000001,
            ABSOLUTE = 0x00008000,
            RIGHTDOWN = 0x00000008,
            RIGHTUP = 0x00000010,
            WHEEL = 0x00000800,
            XDOWN = 0x00000080,
            XUP = 0x00000100
        }

        // Use the values of this enum for the 'dwData' parameter
        // to specify an X button when using MouseEventFlags.XDOWN or
        // MouseEventFlags.XUP for the dwFlags parameter.
        public enum MouseEventDataXButtons : uint
        {
            XBUTTON1 = 0x00000001,
            XBUTTON2 = 0x00000002
        }

        [DllImport("user32.dll")]
        static extern void mouse_event(uint dwFlags, uint dx, uint dy, uint dwData, int dwExtraInfo);

        // The mouse's target location.
        private Point m_Target = new Point(150, 100);

        // Move the mouse and click it.
        private void btnMoveClick_Click(object sender, EventArgs e)
        {
            // Convert the target to absolute screen coordinates.
            Point pt = this.PointToScreen(m_Target);

            // mouse_event moves in a coordinate system where
            // (0, 0) is in the upper left corner and
            // (65535,65535) is in the lower right corner.
            // Convert the coordinates.
            Rectangle screen_bounds = Screen.GetBounds(pt);
            uint x = (uint)(pt.X * 65535 / screen_bounds.Width);
            uint y = (uint)(pt.Y * 65535 / screen_bounds.Height);

            // Move the mouse.
            mouse_event(
                (uint)(MouseEventFlags.ABSOLUTE | MouseEventFlags.MOVE),
                x, y, 0, 0);

            // Click there.
            mouse_event(
                (uint)(MouseEventFlags.ABSOLUTE | MouseEventFlags.MOVE |
                    MouseEventFlags.LEFTDOWN | MouseEventFlags.LEFTUP),
                x, y, 0, 0);
        }

        // Draw an X where the user clicked.
        private void howto_move_click_mouse_Form1_Click(object sender, EventArgs e)
        {
            // Get the mouse position.
            Point pt = MousePosition;

            // Convert to screen coordinates.
            pt = this.PointToClient(pt);

            using (Graphics gr = this.CreateGraphics())
            {
                gr.SmoothingMode = SmoothingMode.AntiAlias;
                gr.DrawLine(Pens.Blue, pt.X - 5, pt.Y - 5, pt.X + 5, pt.Y + 5);
                gr.DrawLine(Pens.Blue, pt.X + 5, pt.Y - 5, pt.X - 5, pt.Y + 5);
            }
        }

        // Draw a target.
        private void howto_move_click_mouse_Form1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            for (int i = 5; i <= 20; i += 5)
            {
                e.Graphics.DrawEllipse(Pens.Red, m_Target.X - i - 1, m_Target.Y - i - 1, 2 * i, 2 * i);
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
            this.btnMoveClick = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnMoveClick
            // 
            this.btnMoveClick.Location = new System.Drawing.Point(12, 12);
            this.btnMoveClick.Name = "btnMoveClick";
            this.btnMoveClick.Size = new System.Drawing.Size(104, 32);
            this.btnMoveClick.TabIndex = 2;
            this.btnMoveClick.Text = "Move && Click";
            this.btnMoveClick.UseVisualStyleBackColor = true;
            this.btnMoveClick.Click += new System.EventHandler(this.btnMoveClick_Click);
            // 
            // howto_move_click_mouse_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(333, 161);
            this.Controls.Add(this.btnMoveClick);
            this.Name = "howto_move_click_mouse_Form1";
            this.Text = "howto_move_click_mouse";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.howto_move_click_mouse_Form1_Paint);
            this.Click += new System.EventHandler(this.howto_move_click_mouse_Form1_Click);
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.Button btnMoveClick;
    }
}

