using System;
using System.Windows;
using System.Windows.Media;

using System.Globalization;

namespace howto_wpf_drawstring
{
    public enum VertAlignment
    {
        Top,
        Middle,
        Bottom,
    }

    public static class DrawingContextExtensions
    {
        // Draw text at the indicated location.
        public static void DrawString(this DrawingContext drawing_context,
            string text, string font_name, double em_size, Brush brush,
            Point origin, VertAlignment valign, TextAlignment halign)
        {
            Typeface typeface = new Typeface(font_name);
            FormattedText formatted_text = new FormattedText(
                text, CultureInfo.CurrentUICulture, FlowDirection.LeftToRight,
                typeface, em_size, brush);
            formatted_text.TextAlignment = halign;

            if (valign == VertAlignment.Middle) origin.Y -= formatted_text.Height / 2;
            else if (valign == VertAlignment.Bottom) origin.Y -= formatted_text.Height;

            drawing_context.DrawText(formatted_text, origin);
        }
    }
}
