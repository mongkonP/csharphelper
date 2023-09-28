
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;

  namespace  howto_sunburst_chart5

 { 

public class Wedge
    {
        public GraphicsPath Path;
        public Color FgColor, BgColor;
        public string Text;
        public bool IsHidden;

        public Wedge(GraphicsPath path, Color fg_color,
            Color bg_color, string text, bool is_hidden)
        {
            Path = path;
            FgColor = fg_color;
            BgColor = bg_color;
            Text = text;
            IsHidden = is_hidden;
        }

        // Return true if the Wedge contains this point.
        public bool ContainsPoint(Point point)
        {
            return Path.IsVisible(point);
        }

        // Return the Wedge's text.
        public override string ToString()
        {
            return Text;
        }
    }

}