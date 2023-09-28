
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;

  namespace  howto_scribble_tools

 { 

class Polyline
    {
        public Color Color = Color.Black;
        public int Thickness = 1;
        public DashStyle DashStyle = DashStyle.Solid;
        public List<Point> Points = new List<Point>();

        public void Draw(Graphics gr)
        {
            using (Pen the_pen = new Pen(Color, Thickness))
            {
                the_pen.DashStyle = DashStyle;
                if (DashStyle == DashStyle.Custom)
                {
                    the_pen.DashPattern = new float[] { 10, 2 };
                }
                gr.DrawLines(the_pen, Points.ToArray());
            }
        }
    }

}