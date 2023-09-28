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
     public partial class howto_tower_of_hanoi_animated_Form1:Form
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

        public howto_tower_of_hanoi_animated_Form1()
        {
            InitializeComponent();
        }

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

        // The position of the disk that is moving.
        private Rectangle MovingDiskRect;

        // Build the controls.
        private void howto_tower_of_hanoi_animated_Form1_Load(object sender, EventArgs e)
        {
            this.DoubleBuffered = true;

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
        private void howto_tower_of_hanoi_animated_Form1_MouseMove(object sender, MouseEventArgs e)
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
        private void howto_tower_of_hanoi_animated_Form1_MouseClick(object sender, MouseEventArgs e)
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
            AnimateDiskMove(from_peg, to_peg);

            if (num_disks > 1)
            {
                // Recursively move the other disks back where they belong.
                MoveDisks(other_peg, to_peg, from_peg, num_disks - 1);
            }
        }

        #region "Drawing"

        // Draw the pegs and disks.
        private void howto_tower_of_hanoi_animated_Form1_Paint(object sender, PaintEventArgs e)
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

            // If we are currently moving a disk, draw it.
            if (Moving)
            {
                gr.FillRectangle(Brushes.LightBlue, MovingDiskRect);
                gr.DrawRectangle(Pens.Blue, MovingDiskRect);
            }
        }

        // Animate moving a disk from peg from_peg to peg to_peg.
        private void AnimateDiskMove(int from_peg, int to_peg)
        {
            // Remove the disk so Paint doesn't draw it.
            int disk_width = PegStack[from_peg].Pop();

            // Move the disk above from_peg.
            int y = PegLocation[from_peg].Bottom -
                (PegStack[from_peg].Count + 1) * (DiskThickness + 2);
            int x = PegLocation[from_peg].X + DiskThickness / 2 - disk_width / 2;
            MovingDiskRect = new Rectangle(
                x, y, disk_width, DiskThickness);

            // Move the disk up above the peg.
            int to_y = 10;
            AnimateMovement(x, to_y);

            // Move the disk over the new peg.
            int to_x = PegLocation[to_peg].X + DiskThickness / 2 - disk_width / 2;
            AnimateMovement(to_x, to_y);

            // Move the disk down onto the peg.
            to_y = PegLocation[to_peg].Bottom -
                (PegStack[to_peg].Count + 1) * (DiskThickness + 2);
            AnimateMovement(to_x, to_y);

            // Redraw.
            this.Refresh();

            // Add the disk to its new peg.
            MovingDiskRect.X = -1;
            PegStack[to_peg].Push(disk_width);
        }

        // Move the moving disk to this location.
        private void AnimateMovement(int end_x, int end_y)
        {
            int start_x = MovingDiskRect.X;
            int start_y = MovingDiskRect.Y;

            const int pixels_per_second = 400;
            float dx = end_x - MovingDiskRect.X;
            float dy = end_y - MovingDiskRect.Y;
            float dist = (float)Math.Sqrt(dx * dx + dy * dy);

            // Calculate distance moved per second.
            dx = pixels_per_second * dx / dist;
            dy = pixels_per_second * dy / dist;

            // See how long the total move will take.
            float seconds = dist / pixels_per_second;
            DateTime start_time = DateTime.Now;

            // Start moving.
            for (; ; )
            {
                // Redraw.
                this.Refresh();

                // Wait a little while.
                System.Threading.Thread.Sleep(10);

                // See how much time has passed.
                TimeSpan elapsed = DateTime.Now - start_time;
                if (elapsed.TotalSeconds > seconds) break;

                // Update the rectangle's position.
                MovingDiskRect.X = (int)(start_x + elapsed.TotalSeconds * dx);
                MovingDiskRect.Y = (int)(start_y + elapsed.TotalSeconds * dy);
            }

            MovingDiskRect.X = end_x;
            MovingDiskRect.Y = end_y;
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
            // howto_tower_of_hanoi_animated_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 204);
            this.Name = "howto_tower_of_hanoi_animated_Form1";
            this.Text = "howto_tower_of_hanoi_animated";
            this.Load += new System.EventHandler(this.howto_tower_of_hanoi_animated_Form1_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.howto_tower_of_hanoi_animated_Form1_Paint);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.howto_tower_of_hanoi_animated_Form1_MouseClick);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.howto_tower_of_hanoi_animated_Form1_MouseMove);
            this.ResumeLayout(false);

        }

        #endregion
    }
}

