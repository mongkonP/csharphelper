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
using System.Drawing.Drawing2D;

 

namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_tower_of_hanoi_Form1:Form
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

        public howto_tower_of_hanoi_Form1()
        {
            InitializeComponent();
        }

        private const int Delay = 250;

        // Geometry.
        private const int NumDisks = 5;
        private const int Y1 = 10;
        private const int Y2 = 50;
        private const int DiskThickness = 20;
        private int X1, X2, X3, Y3;

        private Rectangle[] PegLocation = new Rectangle[3];

        // Peg stacks. Each disk is represented by its width.
        Stack<int>[] PegStack = new Stack<int>[3];

        // The peg that currently holds the disks.
        private int OccupiedPegNum = 0;

        // True if we are performing a move.
        private bool Moving = false;

        // Build the controls.
        private void howto_tower_of_hanoi_Form1_Load(object sender, EventArgs e)
        {
            // Make the peg stacks.
            for (int i = 0; i < 3; i++)
            {
                PegStack[i] = new Stack<int>();
            }

            // Calculate the widest disk's width.
            int disk_width = (NumDisks + 2) * DiskThickness;

            // See how big the form must be.
            ClientSize = new Size(3 * disk_width + 4 * DiskThickness, ClientSize.Height);

            // Figure out where the pegs must be.
            X1 = (int)(DiskThickness + disk_width / 2);
            X2 = X1 + disk_width + DiskThickness;
            X3 = X2 + disk_width + DiskThickness;
            Y3 = ClientSize.Height - 10;

            PegLocation[0] = new Rectangle(X1 - DiskThickness / 2, Y2, DiskThickness, Y3 - Y2);
            PegLocation[1] = new Rectangle(X2 - DiskThickness / 2, Y2, DiskThickness, Y3 - Y2);
            PegLocation[2] = new Rectangle(X3 - DiskThickness / 2, Y2, DiskThickness, Y3 - Y2);

            // Make the disks.
            for (int i = 0; i < NumDisks; i++)
            {
                PegStack[0].Push(disk_width);
                disk_width -= DiskThickness;
            }
            OccupiedPegNum = 0;
        }

        #region "Mouse"

        // If the mouse is over a clickable peg, display a crosshair cursor.
        private void howto_tower_of_hanoi_Form1_MouseMove(object sender, MouseEventArgs e)
        {
            int peg_under_mouse = PegAtLocation(e.Location);
            if (peg_under_mouse < 0)
            {
                this.Cursor = Cursors.Default;
            }
            else
            {
                this.Cursor = Cursors.Cross;
            }
        }

        // Return the index of the peg at this location.
        // Return -1 if the location is not on any peg
        // or if the peg is not clickable.
        private int PegAtLocation(Point location)
        {
            if (Moving) return -1; // Not clickable if we're moving.

            for (int i = 0; i < 3; i++)
            {
                if (PegLocation[i].Contains(location))
                {
                    // Not clickable if this is the occupied peg.
                    if (i == OccupiedPegNum) return -1;
                    return i;
                }
            }
            return -1;
        }

        // Move disks to this peg.
        private void howto_tower_of_hanoi_Form1_MouseClick(object sender, MouseEventArgs e)
        {
            if (Moving) return;
            int peg_under_mouse = PegAtLocation(e.Location);
            if (peg_under_mouse < 0) return;

            Moving = true;
            this.Cursor = Cursors.WaitCursor;
            Application.DoEvents();

            int other_peg = 0;
            if (OccupiedPegNum != 1 && peg_under_mouse != 1) other_peg = 1;
            if (OccupiedPegNum != 2 && peg_under_mouse != 2) other_peg = 2;

            MoveDisks(OccupiedPegNum, peg_under_mouse, other_peg, NumDisks);
            OccupiedPegNum = peg_under_mouse;

            this.Cursor = Cursors.Default;
            Moving = false;
            FlushMouseMessages();   // Discard any pending clicks.
        }

        #endregion // Mouse

        // Move num_disks disks from peg from_peg to peg to_peg.
        private void MoveDisks(int from_peg, int to_peg, int other_peg, int num_disks)
        {
            // See if we have more than one disk to move.
            if (num_disks > 1)
            {
                // We have more than one disk to move.
                // Recursively move all but one disk to the other peg.
                MoveDisks(from_peg, other_peg, to_peg, num_disks - 1);
            }

            // Move the remaining disk.
            PegStack[to_peg].Push(PegStack[from_peg].Pop());
            this.Refresh();
            System.Threading.Thread.Sleep(Delay);

            if (num_disks > 1)
            {
                // Recursively move the other disks back where they belong.
                MoveDisks(other_peg, to_peg, from_peg, num_disks - 1);
            }
        }

        #region "Drawing"

        // Draw the pegs and disks.
        private void howto_tower_of_hanoi_Form1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(this.BackColor);
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            DrawPegs(e.Graphics);
            DrawDisks(e.Graphics);
        }

        // Draw the pegs.
        private void DrawPegs(Graphics gr)
        {
            for (int i = 0; i < 3; i++)
            {
                gr.FillRectangle(Brushes.Orange, PegLocation[i]);
                gr.DrawRectangle(Pens.Red, PegLocation[i]);
            }
        }

        // Draw the disks.
        private void DrawDisks(Graphics gr)
        {
            // For each peg...
            for (int peg = 0; peg < 3; peg++)
            {
                // For each disk on the peg...
                int y = Y3 - 2 - DiskThickness;
                foreach (int disk_width in PegStack[peg].ToArray().Reverse())
                {
                    // Draw the disk.
                    Rectangle disk_rect = new Rectangle(
                        PegLocation[peg].X + DiskThickness / 2 - disk_width / 2,
                        y, disk_width, DiskThickness);
                    gr.FillRectangle(Brushes.LightGreen, disk_rect);
                    gr.DrawRectangle(Pens.Green, disk_rect);
                    y -= DiskThickness + 2;
                }
            }
        }

        #endregion // Drawing

    

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
            this.SuspendLayout();
            // 
            // howto_tower_of_hanoi_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(494, 214);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "howto_tower_of_hanoi_Form1";
            this.Text = "howto_tower_of_hanoi";
            this.Load += new System.EventHandler(this.howto_tower_of_hanoi_Form1_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.howto_tower_of_hanoi_Form1_Paint);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.howto_tower_of_hanoi_Form1_MouseClick);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.howto_tower_of_hanoi_Form1_MouseMove);
            this.ResumeLayout(false);

        }

        #endregion

    }
}

