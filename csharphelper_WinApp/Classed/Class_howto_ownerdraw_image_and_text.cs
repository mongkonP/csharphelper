
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Windows.Forms;

  namespace  howto_ownerdraw_image_and_text

 { 

public static class ComboBoxTools
    {
        // Margins around owner drawn ComboBoxes.
        private const int MarginWidth = 4;
        private const int MarginHeight = 4;

        #region Display Colors

        // Set up the ComboBox to display color samples and their names.
        public static void DisplayColorSamples(this ComboBox cbo, Color[] colors)
        {
            // Make the ComboBox owner-drawn.
            cbo.DrawMode = DrawMode.OwnerDrawFixed;

            // Add the colors to the ComboBox's items.
            cbo.Items.Clear();
            foreach (Color color in colors) cbo.Items.Add(color);

            // Subscribe to the DrawItem event.
            cbo.DrawItem += cboColorSample_DrawItem;
        }

        // Draw a ComboBox item that is displaying a color sample
        private static void cboColorSample_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0) return;

            // Clear the background appropriately.
            e.DrawBackground();

            // Draw the color sample.
            int hgt = e.Bounds.Height - 2 * MarginHeight;
            Rectangle rect = new Rectangle(
                e.Bounds.X + MarginWidth,
                e.Bounds.Y + MarginHeight,
                hgt, hgt);
            ComboBox cbo = sender as ComboBox;
            Color color = (Color)cbo.Items[e.Index];
            using (SolidBrush brush = new SolidBrush(color))
            {
                e.Graphics.FillRectangle(brush, rect);
            }

            // Outline the sample in black.
            e.Graphics.DrawRectangle(Pens.Black, rect);

            // Draw the color's name to the right.
            using (Font font = new Font(cbo.Font.FontFamily,
                cbo.Font.Size * 0.75f, FontStyle.Bold))
            {
                using (StringFormat sf = new StringFormat())
                {
                    sf.Alignment = StringAlignment.Near;
                    sf.LineAlignment = StringAlignment.Center;
                    int x = hgt + 2 * MarginWidth;
                    int y = e.Bounds.Y + e.Bounds.Height / 2;
                    e.Graphics.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;
                    e.Graphics.DrawString(color.Name, font,
                        Brushes.Black, x, y, sf);
                }
            }

            // Draw the focus rectangle if appropriate.
            e.DrawFocusRectangle();
        }

        #endregion Display Colors

        #region Display Images

        // Set up the ComboBox to display images.
        public static void DisplayImages(this ComboBox cbo, Image[] images)
        {
            // Make the ComboBox owner-drawn.
            cbo.DrawMode = DrawMode.OwnerDrawVariable;

            // Add the images to the ComboBox's items.
            cbo.Items.Clear();
            foreach (Image image in images) cbo.Items.Add(image);

            // Subscribe to the DrawItem event.
            cbo.MeasureItem += cboDrawImage_MeasureItem;
            cbo.DrawItem += cboDrawImage_DrawItem;
        }

        // Measure a ComboBox item that is displaying an image.
        private static void cboDrawImage_MeasureItem(object sender, MeasureItemEventArgs e)
        {
            if (e.Index < 0) return;

            // Get this item's image.
            ComboBox cbo = sender as ComboBox;
            Image img = (Image)cbo.Items[e.Index];
            e.ItemHeight = img.Height + 2 * MarginHeight;
            e.ItemWidth = img.Width + 2 * MarginWidth;
        }

        // Draw a ComboBox item that is displaying an image.
        private static void cboDrawImage_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0) return;

            // Clear the background appropriately.
            e.DrawBackground();

            // Draw the image.
            ComboBox cbo = sender as ComboBox;
            Image img = (Image)cbo.Items[e.Index];
            float hgt = e.Bounds.Height - 2 * MarginHeight;
            float scale = hgt / img.Height;
            float wid = img.Width * scale;
            RectangleF rect = new RectangleF(
                e.Bounds.X + MarginWidth,
                e.Bounds.Y + MarginHeight,
                wid, hgt);
            e.Graphics.InterpolationMode = InterpolationMode.HighQualityBilinear;
            e.Graphics.DrawImage(img, rect);

            // Draw the focus rectangle if appropriate.
            e.DrawFocusRectangle();
        }

        #endregion Display Images

        #region Images and Text

        // Set up the ComboBox to display images with text.
        public static void DisplayImagesAndText(this ComboBox cbo, ImageAndText[] values)
        {
            // Make the ComboBox owner-drawn.
            cbo.DrawMode = DrawMode.OwnerDrawVariable;

            // Add the images to the ComboBox's items.
            cbo.Items.Clear();
            cbo.Items.AddRange(values);

            // Subscribe to the DrawItem event.
            cbo.MeasureItem += cboDrawImageAndText_MeasureItem;
            cbo.DrawItem += cboDrawImageAndText_DrawItem;
        }

        // Measure a ComboBox item that is displaying an image.
        private static void cboDrawImageAndText_MeasureItem(object sender, MeasureItemEventArgs e)
        {
            if (e.Index < 0) return;

            // Get the item.
            ComboBox cbo = sender as ComboBox;
            ImageAndText item = (ImageAndText)cbo.Items[e.Index];

            // Make the item measure itself.
            item.MeasureItem(e);
        }

        // Draw a ComboBox item that is displaying an image.
        private static void cboDrawImageAndText_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0) return;

            // Get the item.
            ComboBox cbo = sender as ComboBox;
            ImageAndText item = (ImageAndText)cbo.Items[e.Index];

            // Make the item draw itself.
            item.DrawItem(e);
        }

        #endregion Images and Text
    }













    public class ImageAndText
    {
        // Margins around owner drawn ComboBoxes.
        private const int MarginWidth = 4;
        private const int MarginHeight = 4;

        public Image Picture;
        public string Text;
        public Font Font;

        public ImageAndText(Image picture, string text, Font font)
        {
            Picture = picture;
            Text = text;
            Font = font;
        }

        // Set the size needed to display the image and text.
        private int Width, Height;
        private bool SizeCalculated = false;
        public void MeasureItem(MeasureItemEventArgs e)
        {
            // See if we've already calculated this.
            if (!SizeCalculated)
            {
                SizeCalculated = true;

                // See how much room the text needs.
                SizeF text_size = e.Graphics.MeasureString(Text, Font);

                // The height is the maximum of the image height and text height.
                Height = 2 * MarginHeight +
                    (int)Math.Max(Picture.Height, text_size.Height);

                // The width is the sum of the image and text widths.
                Width = (int)(4 * MarginWidth + Picture.Width + text_size.Width);
            }

            e.ItemWidth = Width;
            e.ItemHeight = Height;
        }

        // Draw the item.
        public void DrawItem(DrawItemEventArgs e)
        {
            // Clear the background appropriately.
            e.DrawBackground();

            // Draw the image.
            float hgt = e.Bounds.Height - 2 * MarginHeight;
            float scale = hgt / Picture.Height;
            float wid = Picture.Width * scale;
            RectangleF rect = new RectangleF(
                e.Bounds.X + MarginWidth,
                e.Bounds.Y + MarginHeight,
                wid, hgt);
            e.Graphics.InterpolationMode = InterpolationMode.HighQualityBilinear;
            e.Graphics.DrawImage(Picture, rect);

            // Draw the text.
            // If we're drawing on the control,
            // draw only the first line of text.
            string visible_text = Text;
            if (e.Bounds.Height < Picture.Height)
                visible_text = Text.Substring(0, Text.IndexOf('\n'));

            // Make a rectangle to hold the text.
            wid = e.Bounds.Width - rect.Right - 3 * MarginWidth;
            rect = new RectangleF(
                rect.Right + 2 * MarginWidth, rect.Y,
                wid, hgt);
            using (StringFormat sf = new StringFormat())
            {
                sf.Alignment = StringAlignment.Near;
                sf.LineAlignment = StringAlignment.Center;
                e.Graphics.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;
                e.Graphics.DrawString(visible_text, Font, Brushes.Black, rect, sf);
            }
            e.Graphics.DrawRectangle(Pens.Blue, Rectangle.Round(rect));

            // Draw the focus rectangle if appropriate.
            e.DrawFocusRectangle();
        }
    }

}