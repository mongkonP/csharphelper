
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

  namespace  howto_draw_lines

 { 

class Segment
    {
        public Pen Pen;
        public Point Point1, Point2;

        public Segment(Pen pen, Point point1, Point point2)
        {
            Pen = pen;
            Point1 = point1;
            Point2 = point2;
        }

        public void Draw(Graphics gr)
        {
            gr.DrawLine(Pen, Point1, Point2);
        }
    }

}