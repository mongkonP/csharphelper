
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

  namespace  howto_flow_blocks

 { 

public class Block
    {
        public RectangleF Bounds;
        public float TopHeight;
        public float BottomHeight
        {
            get { return Bounds.Height - TopHeight; }
        }

        public Block(RectangleF bounds, float top_height)
        {
            Bounds = bounds;
            TopHeight = top_height;
        }

        // Draw the block.
        public void Draw(Graphics gr, int index, Font font)
        {
            if (Bounds.X < 0) return;

            gr.FillRectangle(Brushes.LightGreen, Bounds);
            gr.DrawRectangle(Pens.Green, Bounds);

            float x1 = Bounds.Left;
            float x2 = Bounds.Right;
            float y = Bounds.Top + TopHeight;
            gr.DrawLine(Pens.Red, x1, y, x2, y);

            gr.DrawString(index.ToString(),
                font, Brushes.Black,
                Bounds);
        }
    }










    public static class Extensions
    {
        public static void DrawRectangle(this Graphics graphics,
            Pen pen, RectangleF rect)
        {
            graphics.DrawRectangle(pen, rect.X, rect.Y, rect.Width, rect.Height);
        }
    }

}