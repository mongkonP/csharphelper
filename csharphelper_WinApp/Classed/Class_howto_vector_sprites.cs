
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Media;

  namespace  howto_vector_sprites

 { 

class BallSprite
    {
        public PointF Center;
        public Vector2D Velocity;
        public float Radius;
        public Color BackColor, ForeColor;
        public int MaxX, MaxY;

        // Constructor that initializes randomly.
        private static Random rand = new Random();
        public BallSprite(int min_r, int max_r, int max_x, int max_y, int min_v, int max_v)
        {
            MaxX = max_x;
            MaxY = max_y;
            Radius = rand.Next(min_r, max_r);
            int radius = (int)Radius;
            Center = new PointF(
                rand.Next(radius, max_x - radius),
                rand.Next(radius, max_y - radius));

            int vx = rand.Next(min_v, max_v);
            int vy = rand.Next(min_v, max_v);
            if (rand.Next(0, 2) == 0) vx = -vx;
            if (rand.Next(0, 2) == 0) vy = -vy;
            Velocity = new Vector2D(vx, vy);

            BackColor = RandomColor();
            ForeColor = RandomColor();
        }

        // Return a random color.
        private Color[] colors =
        {
            Color.Red,
            Color.Green,
            Color.Blue,
            Color.Lime,
            Color.Orange,
            Color.Fuchsia,
        };
        private Color RandomColor()
        {
            return colors[rand.Next(0, colors.Length)];
        }

        // Return the ball's bounds.
        public RectangleF GetBounds()
        {
            return new RectangleF(
                Center.X - Radius, Center.Y - Radius,
                2 * Radius, 2 * Radius);
        }

        // Move the ball.
        public void Move()
        {
            // Move the ball.
            Center += Velocity;

            bool bounced = false;
            if ((Center.X < Radius) ||
                (Center.X + Radius > MaxX))
            {
                Velocity.X = -Velocity.X;
                bounced = true;
            }
            if ((Center.Y < Radius) ||
                (Center.Y + Radius > MaxY))
            {
                Velocity.Y = -Velocity.Y;
                bounced = true;
            }

            if (bounced) Boing();
        }

        // Play the boing sound file resource.
        private static void Boing()
        {
            using (SoundPlayer player = new SoundPlayer(
              csharphelper_WinApp. Properties.Resources.boing))
            {
                player.Play();
            }
        }

        // Draw the ball.
        public void Draw(Graphics gr)
        {
            RectangleF bounds = GetBounds();
            using (SolidBrush the_brush = new SolidBrush(BackColor))
            {
                gr.FillEllipse(the_brush, bounds);
            }
            using (Pen the_pen = new Pen(ForeColor))
            {
                gr.DrawEllipse(the_pen, bounds);
            }
        }
    }










    public class Vector2D
    {
        public float X, Y;

        public Vector2D(float x, float y)
        {
            X = x;
            Y = y;
        }
        public Vector2D(PointF from_point, PointF to_point)
        {
            X = to_point.X - from_point.X;
            Y = to_point.Y - from_point.Y;
        }

        public static Vector2D operator +(Vector2D v1, Vector2D v2)
        {
            return new Vector2D(v1.X + v2.X, v1.Y + v2.Y);
        }

        public static Vector2D operator -(Vector2D v1)
        {
            return new Vector2D(-v1.X, -v1.Y);
        }

        public static PointF operator *(Vector2D vector, float scale)
        {
            return new PointF(vector.X * scale, vector.Y * scale);
        }

        public static PointF operator /(Vector2D vector, float scale)
        {
            return new PointF(vector.X / scale, vector.Y / scale);
        }

        public static PointF operator +(Vector2D vector, PointF point)
        {
            return new PointF(point.X + vector.X, point.Y + vector.Y);
        }
        public static PointF operator +(PointF point, Vector2D vector)
        {
            return new PointF(point.X + vector.X, point.Y + vector.Y);
        }
    }

}