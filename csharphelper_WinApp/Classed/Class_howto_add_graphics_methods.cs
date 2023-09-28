
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

  namespace  howto_add_graphics_methods

 { 

public static class GraphicsExtensions
    {
        // Draw a RectangleF.
        public static void DrawRectangle(this Graphics gr, Pen pen, RectangleF rectf)
        {
            gr.DrawRectangle(pen, rectf.Left, rectf.Top, rectf.Width, rectf.Height);
        }
    }

}