
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

  namespace  howto_select_hours_symbiote

 { 

class SelectHoursSymbiote
    {
        // Declare events.
        public event EventHandler HoursScrolled;
        public event EventHandler HoursChanged;

        // The selected hours.
        private int _StartHour = 0;
        private int _StopHour = 0;
        public int StartHour
        {
            get { return _StartHour; }
            set
            {
                _StartHour = value;
                // Raise the HoursChanged event.
                if (HoursChanged != null) HoursChanged(this, null);
            }
        }
        public int StopHour
        {
            get { return _StopHour; }
            set
            {
                _StopHour = value;
                // Raise the HoursChanged event.
                if (HoursChanged != null) HoursChanged(this, null);
            }
        }

        // The PictureBox we manage.
        public PictureBox PictureBox;

        // Constructor.
        public SelectHoursSymbiote(PictureBox pic)
        {
            PictureBox = pic;

            // Add event handlers.
            PictureBox.Paint += pic_Paint;
            PictureBox.MouseDown += pic_MouseDown;
            PictureBox.MouseMove += pic_MouseMove;
            PictureBox.MouseUp += pic_MouseUp;
        }

        // Draw the currently selected hours.
        private void pic_Paint(object sender, PaintEventArgs e)
        {
            DrawHours(PictureBox, e.Graphics, StartHour, StopHour);
        }

        // Draw the hour indicator on this PictureBox.
        private void DrawHours(PictureBox pic, Graphics gr, int start_hour, int stop_hour)
        {
            gr.Clear(Color.LightGreen);

            // Scale to fit a 24-hour period.
            const int margin = 3;
            float scale_x = XScale(pic);
            float hgt = pic.ClientSize.Height;
            float y1 = margin;
            float y2 = hgt - margin;

            // Draw the selected time range.
            RectangleF hours_rect =
                new RectangleF(
                    start_hour * scale_x, y1,
                    (stop_hour - start_hour) * scale_x, y2 - y1);
            gr.FillRectangle(Brushes.Blue, hours_rect);

            // Draw tick marks.
            float x = 0;
            for (int i = 0; i <= 24; i++)
            {
                gr.DrawLine(Pens.DarkGray, x, 0, x, hgt);
                x += scale_x;
            }

            // Draw times.
            gr.RotateTransform(-90);
            int xmid = -pic.ClientSize.Height / 2;
            using (Font font = new Font(FontFamily.GenericSansSerif, 12))
            {
                using (StringFormat sf = new StringFormat())
                {
                    sf.Alignment = StringAlignment.Center;
                    sf.LineAlignment = StringAlignment.Center;

                    x = 0;
                    for (int i = 0; i <= 24; i++)
                    {
                        gr.DrawString(HourToString(i), font,
                            Brushes.Black, xmid, x, sf);
                        x += scale_x;
                    }
                }
            }
        }

        // Return the hour formatted as we want to display it.
        private static string HourToString(int hour)
        {
            if (hour == 0) return "midnight";
            if (hour == 12) return "noon";
            if (hour == 24) return "midnight";
            if (hour <= 12) return hour.ToString() + "am";
            return (hour - 12).ToString() + "pm";
        }

        // Get the horizontal scale factor.
        private float XScale(PictureBox pic)
        {
            return pic.ClientSize.Width / 24;
        }

        // Handle mouse events.
        private bool Drawing = false;
        private int DrawingStartHour, DrawingStopHour;
        private void pic_MouseDown(object sender, MouseEventArgs e)
        {
            Drawing = true;
            DrawingStartHour = (int)Math.Round(e.X / XScale(PictureBox));
            DrawingStopHour = DrawingStartHour;
            StartHour = DrawingStartHour;
            StopHour = DrawingStartHour;
            PictureBox.Refresh();
        }

        private void pic_MouseMove(object sender, MouseEventArgs e)
        {
            if (!Drawing) return;

            // Calculate the value.
            int hour = (int)Math.Round(e.X / XScale(PictureBox));

            // Save the new value.
            DrawingStopHour = hour;

            // Redraw.
            if (DrawingStartHour < DrawingStopHour)
            {
                StopHour = DrawingStopHour;
                StartHour = DrawingStartHour;
            }
            else
            {
                StartHour = DrawingStopHour;
                StopHour = DrawingStartHour;
            }
            PictureBox.Refresh();

            // Raise the HoursScrolled event.
            if (HoursScrolled != null) HoursScrolled(this, null);
        }

        private void pic_MouseUp(object sender, MouseEventArgs e)
        {
            if (!Drawing) return;
            Drawing = false;

            // Raise the HoursChanged event.
            if (HoursChanged != null) HoursChanged(this, null);
        }
    }

}