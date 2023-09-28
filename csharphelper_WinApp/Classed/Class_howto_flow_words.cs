
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;

  namespace  howto_flow_words

 { 

public class Block
    {
        public RectangleF Bounds;
        public float TopHeight;
        public float BottomHeight
        {
            get { return Bounds.Height - TopHeight; }
        }

        public Block()
        {
        }
        public Block(RectangleF bounds, float top_height)
        {
            Bounds = bounds;
            TopHeight = top_height;
        }

        // Draw the block.
        public virtual void Draw(Graphics gr)
        {
            if (Bounds.X < 0) return;

            gr.FillRectangle(Brushes.LightGreen, Bounds);
            gr.DrawRectangle(Pens.Green, Bounds);

            float x1 = Bounds.Left;
            float x2 = Bounds.Right;
            float y = Bounds.Top + TopHeight;
            gr.DrawLine(Pens.Red, x1, y, x2, y);
        }
    }










    public static class Extensions
    {
        public static void DrawRectangle(this Graphics graphics,
            Pen pen, RectangleF rect)
        {
            graphics.DrawRectangle(pen, rect.X, rect.Y, rect.Width, rect.Height);
        }

        // The random number generator.
        private static Random Rand = new Random();

        // Return a random item from an array.
        public static T RandomElement<T>(this T[] items)
        {
            // Return a random item.
            return items[Rand.Next(0, items.Length)];
        }

        // Return a random item from a list.
        public static T RandomElement<T>(this List<T> items)
        {
            // Return a random item.
            return items[Rand.Next(0, items.Count)];
        }
    }







// See: Get font metrics in C#
// http://csharphelper.com/blog/2014/08/get-font-metrics-in-c/





    class FontInfo
    {
        // Heights and positions in pixels.
        public float EmHeightPixels;
        public float AscentPixels;
        public float DescentPixels;
        public float CellHeightPixels;
        public float InternalLeadingPixels;
        public float LineSpacingPixels;
        public float ExternalLeadingPixels;

        // Distances from the top of the cell in pixels.
        public float RelTop;
        public float RelBaseline;
        public float RelBottom;

        // Initialize the properties.
        public FontInfo(Graphics gr, Font the_font)
        {
            float em_height = the_font.FontFamily.GetEmHeight(the_font.Style);
            EmHeightPixels = ConvertUnits(gr, the_font.Size,
                the_font.Unit, GraphicsUnit.Pixel);
            float design_to_pixels = EmHeightPixels / em_height;

            AscentPixels = design_to_pixels *
                the_font.FontFamily.GetCellAscent(the_font.Style);
            DescentPixels = design_to_pixels *
                the_font.FontFamily.GetCellDescent(the_font.Style);
            CellHeightPixels = AscentPixels + DescentPixels;
            InternalLeadingPixels = CellHeightPixels - EmHeightPixels;
            LineSpacingPixels = design_to_pixels *
                the_font.FontFamily.GetLineSpacing(the_font.Style);
            ExternalLeadingPixels = LineSpacingPixels - CellHeightPixels;

            RelTop = InternalLeadingPixels;
            RelBaseline = AscentPixels;
            RelBottom = CellHeightPixels;
        }

        // Convert from one type of unit to another.
        // I don't know how to do Display or World.
        private float ConvertUnits(Graphics gr, float value, GraphicsUnit from_unit, GraphicsUnit to_unit)
        {
            if (from_unit == to_unit) return value;

            // Convert to pixels. 
            switch (from_unit)
            {
                case GraphicsUnit.Document:
                    value *= gr.DpiX / 300;
                    break;
                case GraphicsUnit.Inch:
                    value *= gr.DpiX;
                    break;
                case GraphicsUnit.Millimeter:
                    value *= gr.DpiX / 25.4F;
                    break;
                case GraphicsUnit.Pixel:
                    // Do nothing.
                    break;
                case GraphicsUnit.Point:
                    value *= gr.DpiX / 72;
                    break;
                default:
                    throw new Exception("Unknown input unit " + from_unit.ToString() + " in FontInfo.ConvertUnits");
            }

            // Convert from pixels to the new units. 
            switch (to_unit)
            {
                case GraphicsUnit.Document:
                    value /= gr.DpiX / 300;
                    break;
                case GraphicsUnit.Inch:
                    value /= gr.DpiX;
                    break;
                case GraphicsUnit.Millimeter:
                    value /= gr.DpiX / 25.4F;
                    break;
                case GraphicsUnit.Pixel:
                    // Do nothing.
                    break;
                case GraphicsUnit.Point:
                    value /= gr.DpiX / 72;
                    break;
                default:
                    throw new Exception("Unknown output unit " + to_unit.ToString() + " in FontInfo.ConvertUnits");
            }

            return value;
        }
    }










    public class TextBlock : Block
    {
        public Font Font;
        public String Text;

        public TextBlock(string text, Font font, Graphics gr)
        {
            Font = font;
            Text = text;

            SizeF size = gr.MeasureString(Text, font);
            Bounds = new RectangleF(new PointF(), size);

            FontInfo font_info = new FontInfo(gr, font);
            TopHeight = font_info.AscentPixels;
        }

        // Draw the text block.
        public override void Draw(Graphics gr)
        {
            if (Bounds.X < 0) return;

            // Draw the box (optional). 
            base.Draw(gr);

            // Draw the text.
            gr.DrawString(Text, Font, Brushes.Black, Bounds);
        }
    }

}