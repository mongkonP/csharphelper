
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

  namespace  howto_draw_equations

 { 

// #define DrawBox









    // Draw vertical bars beside the contents.
    class BarEquation : Equation
    {
        // Bar styles.
        public enum BarStyles
        {
            None,
            Bar,
            Bracket,
            Brace,
            PointyBracket,
            Parenthesis,
        }

        // The contents.
        private Equation Contents;

        // The bar style.
        private BarStyles LeftBarStyle, RightBarStyle;

        // Extra space around the content.
        public float MarginX = 5;
        public float MarginY = 5;

        // Width of bars.
        private const float BracketWidth = 8;
        private const float BracesWidth = 6;
        private const float PointyBracketWidthFraction = 0.1f;
        private const float ParenthesisWidthFraction = 0.1f;

        // Initialize the contents.
        public BarEquation(Equation contents, BarStyles left_bar_style, BarStyles right_bar_style)
        {
            Contents = contents;
            LeftBarStyle = left_bar_style;
            RightBarStyle = right_bar_style;
        }

        // Set font sizes for sub-equations.
        public override void SetFontSizes(float font_size)
        {
            FontSize = font_size;
            Contents.SetFontSizes(font_size);
        }

        // Return the equation's size.
        public override SizeF GetSize(Graphics gr, Font font)
        {
            // Get the content's height.
            SizeF item_size = Contents.GetSize(gr, font);

            // Add vertical space.
            item_size.Height += 2 * MarginY;

            // Add room for the bars.
            item_size.Width +=
                2 * MarginX +
                GetBarWidth(gr, font, item_size.Height, LeftBarStyle) +
                GetBarWidth(gr, font, item_size.Height, RightBarStyle);

            return item_size;
        }

        // Return the size of a bar.
        private float GetBarWidth(Graphics gr, Font font, float our_height, BarStyles bar_style)
        {
            switch (bar_style)
            {
                case BarStyles.Bar:
                    return 0;
                case BarStyles.Brace:
                    return 2 * BracesWidth;
                case BarStyles.Bracket:
                    return BracketWidth;
                case BarStyles.PointyBracket:
                    return our_height * PointyBracketWidthFraction;
                case BarStyles.Parenthesis:
                    return our_height * ParenthesisWidthFraction;
                case BarStyles.None:
                    return 0;
                default:
                    throw new ArgumentOutOfRangeException("bar_style",
                        "Unknown BarStyles value " + LeftBarStyle.ToString());
            }
        }

        // Draw the equation.
        public override void Draw(Graphics gr, Font font, Pen pen, Brush brush, float x, float y)
        {
            // Get our size.
            SizeF our_size = GetSize(gr, font);

#if DrawBox
            using (Pen dashed_pen = new Pen(Color.Orange, 1))
            {
                dashed_pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
                gr.DrawRectangle(dashed_pen, x, y, our_size.Width, our_size.Height);
            }
#endif

            // Draw the bars.
            DrawLeftBar(our_size, x, y, gr, font, pen);
            DrawRightBar(our_size, x, y, gr, font, pen);

            // Draw the contents.
            float contents_x = x + MarginX + GetBarWidth(gr, font, our_size.Height, LeftBarStyle);
            Contents.Draw(gr, font, pen, brush, contents_x, y + MarginY);
        }

        // Draw a left bar.
        private void DrawLeftBar(SizeF our_size, float x, float y, Graphics gr, Font font, Pen pen)
        {
            x += MarginX;
            switch (LeftBarStyle)
            {
                case BarStyles.Bar:
                    gr.DrawLine(pen, x, y, x, y + our_size.Height);
                    break;
                case BarStyles.Bracket:
                    PointF[] bracket_pts = 
                    {
                        new PointF(x + BracketWidth, y),
                        new PointF(x, y),
                        new PointF(x, y + our_size.Height),
                        new PointF(x + BracketWidth, y + our_size.Height),
                    };
                    gr.DrawLines(pen, bracket_pts);
                    break;
                case BarStyles.Brace:
                    PointF[] brace_pts = 
                    {
                        new PointF(x + 2 * BracesWidth, y),
                        new PointF(x + BracesWidth, y + 2 * BracesWidth),
                        new PointF(x + BracesWidth, y + our_size.Height / 2 - 2 * BracesWidth),
                        new PointF(x, y + our_size.Height / 2),
                        new PointF(x, y + our_size.Height / 2),
                        new PointF(x + BracesWidth, y + our_size.Height / 2 + 2 * BracesWidth),
                        new PointF(x + BracesWidth, y + our_size.Height - 2 * BracesWidth),
                        new PointF(x + 2 * BracesWidth, y + our_size.Height),
                    };
                    gr.DrawCurve(pen, brace_pts);
                    break;
                case BarStyles.PointyBracket:
                    float pointy_bracket_width = PointyBracketWidthFraction * our_size.Height;
                    PointF[] point_bracket_pts = 
                    {
                        new PointF(x + pointy_bracket_width, y),
                        new PointF(x, y + our_size.Height / 2),
                        new PointF(x + pointy_bracket_width, y + our_size.Height),
                    };
                    gr.DrawLines(pen, point_bracket_pts);
                    break;
                case BarStyles.Parenthesis:
                    float parenthesis_width = PointyBracketWidthFraction * our_size.Height;
                    PointF[] parenthesis_pts = 
                    {
                        new PointF(x + parenthesis_width, y),
                        new PointF(x + parenthesis_width / 2, y + 2 * parenthesis_width),
                        new PointF(x + parenthesis_width / 2, y + our_size.Height - 2 * parenthesis_width),
                        new PointF(x + parenthesis_width, y + our_size.Height),
                    };
                    gr.DrawCurve(pen, parenthesis_pts);
                    break;
                case BarStyles.None:
                    break;
                default:
                    throw new ArgumentOutOfRangeException("LeftBarStyle",
                        "Unknown BarStyles value " + LeftBarStyle.ToString());
            }
        }

        // Draw a right bar.
        private void DrawRightBar(SizeF our_size, float x, float y, Graphics gr, Font font, Pen pen)
        {
            x += our_size.Width - MarginX;
            switch (RightBarStyle)
            {
                case BarStyles.Bar:
                    gr.DrawLine(pen, x, y, x, y + our_size.Height);
                    break;
                case BarStyles.Bracket:
                    PointF[] bracket_pts = 
                    {
                        new PointF(x - BracketWidth, y),
                        new PointF(x, y),
                        new PointF(x, y + our_size.Height),
                        new PointF(x - BracketWidth, y + our_size.Height),
                    };
                    gr.DrawLines(pen, bracket_pts);
                    break;
                case BarStyles.Brace:
                    PointF[] brace_pts = 
                    {
                        new PointF(x - 2 * BracesWidth, y),
                        new PointF(x - BracesWidth, y + 2 * BracesWidth),
                        new PointF(x - BracesWidth, y + our_size.Height / 2 - 2 * BracesWidth),
                        new PointF(x, y + our_size.Height / 2),
                        new PointF(x, y + our_size.Height / 2),
                        new PointF(x - BracesWidth, y + our_size.Height / 2 + 2 * BracesWidth),
                        new PointF(x - BracesWidth, y + our_size.Height - 2 * BracesWidth),
                        new PointF(x - 2 * BracesWidth, y + our_size.Height),
                    };
                    gr.DrawCurve(pen, brace_pts);
                    break;
                case BarStyles.PointyBracket:
                    float pointy_bracket_width = PointyBracketWidthFraction * our_size.Height;
                    PointF[] point_bracket_pts = 
                    {
                        new PointF(x - pointy_bracket_width, y),
                        new PointF(x, y + our_size.Height / 2),
                        new PointF(x - pointy_bracket_width, y + our_size.Height),
                    };
                    gr.DrawLines(pen, point_bracket_pts);
                    break;
                case BarStyles.Parenthesis:
                    float parenthesis_width = PointyBracketWidthFraction * our_size.Height;
                    PointF[] parenthesis_pts = 
                    {
                        new PointF(x - parenthesis_width, y),
                        new PointF(x - parenthesis_width / 2, y + 2 * parenthesis_width),
                        new PointF(x - parenthesis_width / 2, y + our_size.Height - 2 * parenthesis_width),
                        new PointF(x - parenthesis_width, y + our_size.Height),
                    };
                    gr.DrawCurve(pen, parenthesis_pts);
                    break;
                case BarStyles.None:
                    break;
                default:
                    throw new ArgumentOutOfRangeException("RightBarStyle",
                        "Unknown BarStyles value " + RightBarStyle.ToString());
            }
        }
    }










    abstract class Equation
    {
        // The font size used by this equation.
        public float FontSize = 20;

        // Set font sizes for sub-equations.
        public abstract void SetFontSizes(float font_size);

        // Return the equation's size.
        public abstract SizeF GetSize(Graphics gr, Font font);

        // Draw the equation.
        public abstract void Draw(Graphics gr, Font font, Pen pen, Brush brush, float x, float y);
    }










    // Draw one item over another.
    class FractionEquation : Equation
    {
        // True to draw a separator line.
        public bool DrawSeparator;

        // The space between the top and bottom items.
        private const float Gap = 0;

        // Extra width for the separator (on each side).
        private const float ExtraWidth = 6;

        // The items to draw.
        private Equation Numerator, Denominator;

        // Initialize a new object.
        public FractionEquation(Equation top_item, Equation bottom_item, bool draw_separator)
        {
            Numerator = top_item;
            Denominator = bottom_item;
            DrawSeparator = draw_separator;
        }

        // Initialize a new object.
        public FractionEquation(string top_string, string bottom_string, bool draw_separator)
            : this(new StringEquation(top_string), new StringEquation(bottom_string), draw_separator)
        {
        }

        // Set font sizes for sub-equations.
        public override void SetFontSizes(float font_size)
        {
            FontSize = font_size;
            Numerator.SetFontSizes(font_size * 0.75f);
            Denominator.SetFontSizes(font_size * 0.75f);
        }

        // Return the object's size.
        public override SizeF GetSize(Graphics gr, Font font)
        {
            // Get the sizes of the items.
            SizeF top_size, bottom_size;
            float width, height;
            GetSizes(gr, font, out top_size, out bottom_size, out width, out height);

            // Calculate our size.
            return new SizeF(width, height);
        }

        // Draw the equation.
        public override void Draw(Graphics gr, Font font, Pen pen, Brush brush, float x, float y)
        {
            // Get the sizes of the items.
            SizeF top_size, bottom_size;
            float width, height;
            GetSizes(gr, font, out top_size, out bottom_size, out width, out height);

            // Draw the separator.
            if (DrawSeparator)
            {
                float separator_y = y + top_size.Height + Gap / 2;
                gr.DrawLine(pen,
                    x, separator_y,
                    x + width, separator_y);
            }

            // Draw the top.
            float top_x = x + (width - top_size.Width) / 2;
            Numerator.Draw(gr, font, pen, brush, top_x, y);

            // Draw the bottom.
            float bottom_x = x + (width - bottom_size.Width) / 2;
            float bottom_y = y + top_size.Height + Gap;
            Denominator.Draw(gr, font, pen, brush, bottom_x, bottom_y);
        }

        // Return various sizes.
        private void GetSizes(Graphics gr, Font font, out SizeF top_size, out SizeF bottom_size, out float width, out float height)
        {
            top_size = Numerator.GetSize(gr, font);
            bottom_size = Denominator.GetSize(gr, font);
            width = Math.Max(top_size.Width, bottom_size.Width) + 2 * ExtraWidth;
            height = top_size.Height + bottom_size.Height + Gap;
        }
    }










    class IntegralEquation : Equation
    {
        // The contents.
        private Equation Contents, Above, Below;

        // Dimensions.
        private const float WidthFraction = 0.2f;

        // Initialize the contents.
        public IntegralEquation(Equation contents, Equation above, Equation below)
        {
            Contents = contents;
            Above = above;
            Below = below;
        }

        // Set font sizes for sub-equations.
        public override void SetFontSizes(float font_size)
        {
            FontSize = font_size;
            Contents.SetFontSizes(font_size);
            Above.SetFontSizes(font_size / 2);
            Below.SetFontSizes(font_size / 2);
        }

        // Return the equation's size.
        public override System.Drawing.SizeF GetSize(Graphics gr, Font font)
        {
            // Get sizes.
            SizeF contents_size, above_size, below_size, our_size;
            float symbol_area_width, symbol_area_height, symbol_width, symbol_height;
            GetSizes(gr, font, out contents_size, out above_size, out below_size,
                out our_size, out symbol_area_width, out symbol_area_height, out symbol_width, out symbol_height);
            return our_size;
        }

        // Get sizes.
        private void GetSizes(Graphics gr, Font font, out SizeF contents_size, out SizeF above_size, out SizeF below_size, out SizeF our_size, out float symbol_area_width, out float symbol_area_height, out float symbol_width, out float symbol_height)
        {
            contents_size = Contents.GetSize(gr, font);
            above_size = Above.GetSize(gr, font);
            below_size = Below.GetSize(gr, font);

            float height = Math.Max(
                2f * (above_size.Height + below_size.Height),
                contents_size.Height);
            symbol_height = height - (above_size.Height + below_size.Height);
            symbol_width = symbol_height * WidthFraction;

            symbol_area_width = Math.Max(
                Math.Max(above_size.Width, below_size.Width),
                symbol_width);
            symbol_area_height = height;

            float width = contents_size.Width + symbol_area_width;

            our_size = new SizeF(width, height);
        }

        // Draw the equation.
        public override void Draw(Graphics gr, Font font, Pen pen, Brush brush, float x, float y)
        {
            // Get sizes.
            SizeF contents_size, above_size, below_size, our_size;
            float symbol_area_width, symbol_area_height, symbol_width, symbol_height;
            GetSizes(gr, font, out contents_size, out above_size, out below_size,
                out our_size, out symbol_area_width, out symbol_area_height, out symbol_width, out symbol_height);

            // Draw Above.
            float above_x = x + (symbol_area_width - above_size.Width) / 2;
            Above.Draw(gr, font, pen, brush, above_x, y);

            // Draw the sigma symbol.
            float x1 = x + (symbol_area_width + symbol_width) / 2;
            float y1 = y + above_size.Height;
            float x2 = x1 - symbol_width / 2;
            float y2 = y1 + symbol_width;
            float x3 = x2;
            float y3 = y1 + symbol_height - symbol_width;
            float x4 = x3 - symbol_width / 2;
            float y4 = y3 + symbol_width;
            PointF[] integral_pts =
                {
                    new PointF(x1, y1),
                    new PointF(x2, y2),
                    new PointF(x3, y3),
                    new PointF(x4, y4),
                };
            gr.DrawCurve(pen, integral_pts);

            // Draw Below.
            float below_x = x + (symbol_area_width - below_size.Width) / 2;
            float below_y = y4;
            Below.Draw(gr, font, pen, brush, below_x, below_y);

            // Draw the contents.
            float contents_x = x + symbol_area_width;
            float contents_y = y + (our_size.Height - contents_size.Height) / 2;
            Contents.Draw(gr, font, pen, brush, contents_x, contents_y);
        }
    }


// #define DrawBox









    // Draw a matrix of Equations.
    class MatrixEquation : Equation
    {
        // The items to draw.
        private int NumRows, NumCols;
        private Equation[,] Items;

        // Space to add between rows and columns;
        private const float RowSpace = 4;
        private const float ColSpace = 4;

        // True if we should make rows/columns have the same sizes.
        private bool UniformRows, UniformCols;

        // Initialize the items.
        public MatrixEquation(int num_rows, int num_cols, bool uniform_rows, bool uniform_cols, params Equation[] items)
        {
            NumRows = num_rows;
            NumCols = num_cols;
            UniformRows = uniform_rows;
            UniformCols= uniform_cols;

            Items = new Equation[num_rows, num_cols];
            for (int i = 0, row = 0; row < NumRows; row++)
            {
                for (int col = 0; col < NumCols; col++, i++)
                {
                    if (i >= items.Length) break;
                    Items[row, col] = items[i];
                }
                if (i >= items.Length) break;
            }
        }

        // Set font sizes for sub-equations.
        public override void SetFontSizes(float font_size)
        {
            FontSize = font_size;
            for (int i = 0, row = 0; row < NumRows; row++)
            {
                for (int col = 0; col < NumCols; col++, i++)
                {
                    Items[row, col].SetFontSizes(font_size);
                }
            }
        }

        // Return the equation's size.
        public override SizeF GetSize(Graphics gr, Font font)
        {
            // Get the row and column sizes.
            float[] row_heights, col_widths;
            MeasureRowsAndColumns(gr, font, out row_heights, out col_widths);

            // Add them up.
            float height = row_heights.Sum() + RowSpace * (NumRows - 1);
            float width = col_widths.Sum() + ColSpace * (NumCols - 1);

            return new SizeF(width, height);
        }

        // Draw the equation.
        public override void Draw(Graphics gr, Font font, Pen pen, Brush brush, float x, float y)
        {
            // Get the row and column sizes.
            float[] row_heights, col_widths;
            MeasureRowsAndColumns(gr, font, out row_heights, out col_widths);

#if DrawBox
            float height = row_heights.Sum() + (row_heights.Length - 1) * RowSpace;
            float width = col_widths.Sum() + (col_widths.Length - 1) * ColSpace;
            using (Pen dashed_pen = new Pen(Color.Blue, 1))
            {
                dashed_pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
                gr.DrawRectangle(dashed_pen, x, y, width, height);
            }
#endif

            // Draw the items.
            float row_y = y;
            for (int row = 0; row < NumRows; row++)
            {
                float col_x = x;
                for (int col = 0; col < NumCols; col++)
                {
                    if (Items[row, col] != null)
                    {
                        // Get the item's size.
                        SizeF item_size = Items[row, col].GetSize(gr, font);

                        // Draw the item.
                        float item_x = col_x + (col_widths[col] - item_size.Width) / 2;
                        float item_y = row_y + (row_heights[row] - item_size.Height) / 2;
                        Items[row, col].Draw(gr, font, pen, brush, item_x, item_y);
                    }

                    // Move to the next column.
                    col_x += col_widths[col] + ColSpace;
                }

                // Move to the next row.
                row_y += row_heights[row] + RowSpace;
            }
        }

        // Measure the row and column sizes.
        private void MeasureRowsAndColumns(Graphics gr, Font font, out float[] row_heights, out float[] col_widths)
        {
            // Make room for the values.
            row_heights = new float[NumRows];
            col_widths = new float[NumCols];

            // Get the largest row heights and column widths.
            for (int row = 0; row < NumRows; row++)
            {
                for (int col = 0; col < NumCols; col++)
                {
                    if (Items[row, col] != null)
                    {
                        SizeF item_size = Items[row, col].GetSize(gr, font);
                        if (row_heights[row] < item_size.Height) row_heights[row] = item_size.Height;
                        if (col_widths[col] < item_size.Width) col_widths[col] = item_size.Width;
                    }
                }
            }

            // See if we want uniform row heights.
            if (UniformRows)
            {
                // Get the maximum row height.
                float max_height = row_heights.Max();

                // Set all rows to this height.
                for (int row = 0; row < NumRows; row++) row_heights[row] = max_height;
            }

            // See if we want uniform column widths.
            if (UniformCols)
            {
                // Get the maximum col width.
                float max_width = col_widths.Max();

                // Set all cols to this width.
                for (int col = 0; col < NumCols; col++) col_widths[col] = max_width;
            }
        }
    }










    // Draw an item to a power.
    class PowerEquation : Equation
    {
        // The items to draw.
        private Equation Base, Power;

        // Initialize a new object.
        public PowerEquation(Equation base_item, Equation power_item)
        {
            Base = base_item;
            Power = power_item;
        }

        // Initialize a new object.
        public PowerEquation(string base_string, string power_string)
            : this(new StringEquation(base_string), new StringEquation(power_string))
        {
        }

        // Set font sizes for sub-equations.
        public override void SetFontSizes(float font_size)
        {
            FontSize = font_size;
            Base.SetFontSizes(font_size);
            Power.SetFontSizes(font_size * 0.75f);
        }

        // Return the object's size.
        public override SizeF GetSize(Graphics gr, Font font)
        {
            // Get the sizes of the items.
            SizeF base_size, power_size;
            float width, height;
            GetSizes(gr, font, out base_size, out power_size, out width, out height);

            // Calculate our size.
            return new SizeF(width, height);
        }

        // Draw the equation.
        public override void Draw(Graphics gr, Font font, Pen pen, Brush brush, float x, float y)
        {
            // Get the sizes of the items.
            SizeF base_size, power_size;
            float width, height;
            GetSizes(gr, font, out base_size, out power_size, out width, out height);

            // Draw the base.
            float base_y = y + power_size.Height / 2;
            Base.Draw(gr, font, pen, brush, x, base_y);

            // Draw the power.
            float power_x = x + base_size.Width;
            Power.Draw(gr, font, pen, brush, power_x, y);
        }

        // Return various sizes.
        private void GetSizes(Graphics gr, Font font, out SizeF base_size, out SizeF power_size, out float width, out float height)
        {
            base_size = Base.GetSize(gr, font);
            power_size = Power.GetSize(gr, font);
            width = base_size.Width + power_size.Width;
            height = base_size.Height + power_size.Height / 2;
        }
    }










    class RootEquation : Equation
    {
        // Gap between items and horizontal lines.
        private float ExtraHeight = 2;

        // Extra width of line under the index.
        private float ExtraWidth = 4;

        // The items to draw.
        private Equation Index, Radicand;

        // The angle for the radical sign.
        private float Angle = (float)(80 * Math.PI / 180);

        // Initialize the equation.
        public RootEquation(Equation index, Equation radicand)
        {
            Index = index;
            Radicand = radicand;
        }

        // Set font sizes for sub-equations.
        public override void SetFontSizes(float font_size)
        {
            FontSize = font_size;
            Index.SetFontSizes(font_size * 0.75f);
            Radicand.SetFontSizes(font_size);
        }

        // Return the equation's size.
        public override SizeF GetSize(Graphics gr, Font font)
        {
            // Get the sizes.
            SizeF index_size, radicand_size, our_size;
            GetSizes(gr, font, out index_size, out radicand_size, out our_size);

            return our_size;
        }

        // Calculate sizes.
        private void GetSizes(Graphics gr, Font font, out SizeF index_size, out SizeF radicand_size, out SizeF our_size)
        {
            // Get the sizes of the index and radicand.
            index_size = Index.GetSize(gr, font);
            radicand_size = Radicand.GetSize(gr, font);

            // See how tall we must be.
            float height = ExtraHeight + Math.Max(
                2 * index_size.Height,
                radicand_size.Height);

            // Calculate our width.
            float width = index_size.Width + radicand_size.Width +
                (float)Math.Cos(Angle) * 1.5f * height + ExtraWidth;

            // Set our size.
            our_size = new SizeF(width, height);
        }

        // Draw the equation.
        public override void Draw(Graphics gr, Font font, Pen pen, Brush brush, float x, float y)
        {
            // Get the sizes.
            SizeF index_size, radicand_size, our_size;
            GetSizes(gr, font, out index_size, out radicand_size, out our_size);

            // Draw the radical symbol.
            float x1 = x + index_size.Width + ExtraWidth;
            float x2 = x1 + (float)Math.Cos(Angle) * our_size.Height / 2;
            float x3 = x2 + (float)Math.Cos(Angle) * our_size.Height;
            float x4 = x + our_size.Width;
            float y1 = y + our_size.Height / 2 + ExtraHeight;
            float y2 = y + our_size.Height + ExtraHeight;
            float y3 = y;
            float y4 = y;
            PointF[] pts =
            {
                new PointF(x, y1), 
                new PointF(x1, y1), 
                new PointF(x2, y2),
                new PointF(x3, y3),
                new PointF(x4, y4),
            };
            gr.DrawLines(pen, pts);

            // Draw the index.
            float index_x = x + ExtraWidth;
            float index_y = y + (our_size.Height / 2 - index_size.Height) / 2;
            Index.Draw(gr, font, pen, brush, index_x, index_y);

            // Draw the radicand.
            float randicand_x = x3;
            float randicand_y = y + ExtraHeight + (our_size.Height - ExtraHeight - radicand_size.Height) / 2;
            Radicand.Draw(gr, font, pen, brush, randicand_x, randicand_y);
        }
    }










    class SigmaEquation : Equation
    {
        // The contents.
        private Equation Contents, Above, Below;

        // Dimensions.
        private const float FootFraction = 0.2f;
        private const float AspectRatio = 0.6666f;

        // Initialize the contents.
        public SigmaEquation(Equation contents, Equation above, Equation below)
        {
            Contents = contents;
            Above = above;
            Below = below;
        }

        // Set font sizes for sub-equations.
        public override void SetFontSizes(float font_size)
        {
            FontSize = font_size;
            Contents.SetFontSizes(font_size);
            Above.SetFontSizes(font_size / 2);
            Below.SetFontSizes(font_size / 2);
        }

        // Return the equation's size.
        public override System.Drawing.SizeF GetSize(Graphics gr, Font font)
        {
            // Get sizes.
            SizeF contents_size, above_size, below_size, our_size;
            float symbol_area_width, symbol_area_height, symbol_width, symbol_height;
            GetSizes(gr, font, out contents_size, out above_size, out below_size,
                out our_size, out symbol_area_width, out symbol_area_height, out symbol_width, out symbol_height);
            return our_size;
        }

        // Get sizes.
        private void GetSizes(Graphics gr, Font font, out SizeF contents_size, out SizeF above_size, out SizeF below_size, out SizeF our_size, out float symbol_area_width, out float symbol_area_height, out float symbol_width, out float symbol_height)
        {
            contents_size = Contents.GetSize(gr, font);
            above_size = Above.GetSize(gr, font);
            below_size = Below.GetSize(gr, font);

            float height = Math.Max(
                1.5f * (above_size.Height + below_size.Height),
                contents_size.Height);
            symbol_height = height - above_size.Height - below_size.Height;
            symbol_width = symbol_height * AspectRatio;

            symbol_area_width = Math.Max(
                Math.Max(above_size.Width, below_size.Width),
                symbol_width);
            symbol_area_height = symbol_height + above_size.Height + below_size.Height;

            float width = contents_size.Width + symbol_area_width;

            our_size = new SizeF(width, height);
        }

        // Draw the equation.
        public override void Draw(Graphics gr, Font font, Pen pen, Brush brush, float x, float y)
        {
            // Get sizes.
            SizeF contents_size, above_size, below_size, our_size;
            float symbol_area_width, symbol_area_height, symbol_width, symbol_height;
            GetSizes(gr, font, out contents_size, out above_size, out below_size,
                out our_size, out symbol_area_width, out symbol_area_height, out symbol_width, out symbol_height);

            // Draw Above.
            float above_x = x + (symbol_area_width - above_size.Width) / 2;
            float above_y = y + (our_size.Height - symbol_area_height) / 2;
            Above.Draw(gr, font, pen, brush, above_x, above_y);

            // Draw the sigma symbol.
            float x1 = x + (symbol_area_width - symbol_width) / 2;
            float x2 = x1 + symbol_width;
            float y1 = above_y + above_size.Height;
            float y2 = y1 + symbol_height / 2;
            float y3 = y1 + symbol_height;
            PointF[] sigma_pts = 
                {
                    new PointF(x2, y1 + symbol_height * FootFraction),
                    new PointF(x2, y1),
                    new PointF(x1, y1),
                    new PointF(x2, y2),
                    new PointF(x1, y3),
                    new PointF(x2, y3),
                    new PointF(x2, y3 - symbol_height * FootFraction),
                };
            gr.DrawLines(pen, sigma_pts);

            // Draw Below.
            float below_x = x + (symbol_area_width - below_size.Width) / 2;
            float below_y = y3;
            Below.Draw(gr, font, pen, brush, below_x, below_y);

            // Draw the contents.
            float contents_x = x + symbol_area_width;
            float contents_y = y + (our_size.Height - contents_size.Height) / 2;
            Contents.Draw(gr, font, pen, brush, contents_x, contents_y);
        }
    }


// #define DrawBox









    // Draw some text.
    class StringEquation : Equation
    {
        // The text to draw.
        private string Text;

        // Initialize the text.
        public StringEquation(string text)
        {
            Text = text;
        }

        // Set font sizes for sub-equations.
        public override void SetFontSizes(float font_size)
        {
            FontSize = font_size;
        }

        // Return the equation's size.
        public override SizeF GetSize(Graphics gr, Font font)
        {
            using (Font new_font = new Font(font.FontFamily, FontSize, font.Style))
            {
                return gr.MeasureString(Text, new_font);
            }
        }

        // Draw the equation.
        public override void Draw(Graphics gr, Font font, Pen pen, Brush brush, float x, float y)
        {
#if DrawBox
            SizeF our_size = GetSize(gr, font);
            using (Pen dashed_pen = new Pen(Color.Red, 0))
            {
                dashed_pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
                gr.DrawRectangle(dashed_pen, x, y, our_size.Width, our_size.Height);
            }
#endif
            using (Font new_font = new Font(font.FontFamily, FontSize, font.Style))
            {
                gr.DrawString(Text, new_font, brush, x, y);
            }
        }
    }

}