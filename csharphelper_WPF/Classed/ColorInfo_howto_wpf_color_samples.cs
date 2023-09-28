using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Windows.Media;

namespace howto_wpf_color_samples
{
    // Used to display color name, RGB value, and sample.
    public class ColorInfo
    {
        public string ColorName { get; set; }
        public Color Color { get; set; }

        public SolidColorBrush SampleBrush
        {
            get { return new SolidColorBrush(Color); }
        }
        public string HexValue
        {
            get { return Color.ToString(); }
        }

        public ColorInfo(string color_name, Color color)
        {
            ColorName = color_name;
            Color = color;
        }
    }
}
