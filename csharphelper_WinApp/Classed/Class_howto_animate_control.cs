
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

  namespace  howto_animate_control

 { 

// Information about a move in progress.
    public class ControlSprite
    {
        public System.Windows.Forms.Control MovingControl;
        public int EndX, EndY;
        public float CurrentX, CurrentY;

        private float Dx, Dy;
        private DateTime LastMoveTime;
        private TimeSpan TotalElapsed, MoveUntil;
        private Timer MoveTimer;

        public delegate void DoneEventHandler(object sender);
        public event DoneEventHandler Done;

        // Prepare to move the control.
        public ControlSprite(System.Windows.Forms.Control control)
        {
            MovingControl = control;
        }

        // Start moving.
        public void Start(int end_x, int end_y, int pixels_per_second)
        {
            CurrentX = MovingControl.Location.X;
            CurrentY = MovingControl.Location.Y;
            EndX = end_x;
            EndY = end_y;
            
            // Calculate the total distance.
            float dx = EndX - CurrentX;
            float dy = EndY - CurrentY;
            float dist = (float)Math.Sqrt(dx * dx + dy * dy);

            // Calculate the X and Y amounts to move per second.
            Dx = pixels_per_second * dx / dist;
            Dy = pixels_per_second * dy / dist;

            // See how long the total move will take.
            int milliseconds = (int)(1000.0f * dist / pixels_per_second);
            MoveUntil = new TimeSpan(0, 0, 0, 0, milliseconds);
            TotalElapsed = new TimeSpan(0);

            // Make the timer.
            MoveTimer = new Timer();
            MoveTimer.Interval = 10;
            MoveTimer.Tick += MoveTimer_Tick;

            // Start moving.
            Start();
        }

        // Resume moving.
        public void Start()
        {
            LastMoveTime = DateTime.Now;
            MoveTimer.Enabled = true;
        }

        // Stop moving.
        public void Stop()
        {
            MoveTimer.Enabled = false;
        }

        // Move the control.
        private void MoveTimer_Tick(object sender, EventArgs e)
        {
            // See how long it's been since the last move.
            DateTime now = DateTime.Now;
            TimeSpan elapsed_since_last = now - LastMoveTime;
            LastMoveTime = DateTime.Now;

            // See if we should stop.
            TotalElapsed += elapsed_since_last;
            if (TotalElapsed >= MoveUntil)
            {
                // Stop.
                MoveTimer.Enabled = false;
                CurrentX = EndX;
                CurrentY = EndY;
                if (Done != null) Done(this);
            }
            else
            {
                // Continue.
                CurrentX += (float)(Dx * elapsed_since_last.TotalSeconds);
                CurrentY += (float)(Dy * elapsed_since_last.TotalSeconds);
            }

            // Move the control to its new location.
            MovingControl.Location = new Point((int)CurrentX, (int)CurrentY);
        }
    }

}