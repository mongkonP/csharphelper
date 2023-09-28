using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Xml.Serialization;
using System.Windows;

namespace howto_wpf_save_restore_lines
{
    // Represent a serializable line segment.
    [Serializable()]
    public class Segment
    {
        public double X1, Y1, X2, Y2;
        public Segment()
        {
        }
        public Segment(double x1, double y1, double x2, double y2)
        {
            X1 = x1;
            Y1 = y1;
            X2 = x2;
            Y2 = y2;
        }
    }
}
