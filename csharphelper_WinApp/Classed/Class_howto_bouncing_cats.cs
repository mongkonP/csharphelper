
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;

  namespace  howto_bouncing_cats

 { 

class ImageSprite
    {
        public float Angle, DAngle;
        public PointF Center, Velocity;
        public Bitmap Picture;
        private float Radius;

        public ImageSprite(float angle, float dangle,
            PointF center, PointF velocity, Bitmap picture)
        {
            Angle = angle;
            DAngle = dangle;
            Center = center;
            Velocity = velocity;
            Picture = picture;

            Radius = Math.Min(picture.Width, picture.Height) / 2f;
        }

        public void Move(Rectangle bounds, float elapsed)
        {
            Center.X += Velocity.X * elapsed;
            float right = Center.X + Radius;
            if (right > bounds.Right)
            {
                right = bounds.Right - (right - bounds.Right);
                Center.X = right - Radius;
                Velocity.X = -Velocity.X;
            }
            float left = Center.X - Radius;
            if (left < 0)
            {
                left = -left;
                Center.X = left + Radius;
                Velocity.X = -Velocity.X;
            }

            Center.Y += Velocity.Y * elapsed;
            float bottom = Center.Y + Radius;
            if (bottom > bounds.Bottom)
            {
                bottom = bounds.Bottom - (bottom - bounds.Bottom);
                Center.Y = bottom - Radius;
                Velocity.Y = -Velocity.Y;
            }
            float top = Center.Y - Radius;
            if (top < 0)
            {
                top = -top;
                Center.Y = top + Radius;
                Velocity.Y = -Velocity.Y;
            }

            Angle += DAngle * elapsed;
        }

        public void Draw(Graphics gr)
        {
            GraphicsState state = gr.Save();
            gr.ResetTransform();
            gr.RotateTransform(Angle);
            gr.TranslateTransform(Center.X, Center.Y, MatrixOrder.Append);
            gr.DrawImage(Picture, new PointF(-Radius, -Radius));
            gr.Restore(state);
        }
    }

}