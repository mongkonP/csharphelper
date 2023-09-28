
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

  namespace  howto_make_nontransparent_region

 { 

class RegionStuff
    {
        // Make a region representing the
        // image's non-transparent pixels.
        public static Region MakeNonTransparentRegion(Bitmap bm)
        {
            if (bm == null) return null;

            // Make the result region.
            Region result = new Region();
            result.MakeEmpty();

            Rectangle rect = new Rectangle(0, 0, 1, 1);
            bool in_image = false;
            for (int y = 0; y < bm.Height; y++)
            {
                for (int x = 0; x < bm.Width; x++)
                {
                    if (!in_image)
                    {
                        // We're not now in the non-transparent pixels.
                        if (bm.GetPixel(x, y).A != 0)
                        {
                            // We just started into the non-transparent pixels.
                            // Start a Rectangle to represent them.
                            in_image = true;
                            rect.X = x;
                            rect.Y = y;
                            rect.Height = 1;
                        }
                    }
                    else if (bm.GetPixel(x, y).A == 0)
                    {
                        // We are in the non-transparent pixels and
                        // have found a transparent one.
                        // Add the rectangle so far to the region.
                        in_image = false;
                        rect.Width = (x - rect.X);
                        result.Union(rect);
                    }
                }

                // Add the final piece of the rectangle if necessary.
                if (in_image)
                {
                    in_image = false;
                    rect.Width = (bm.Width - rect.X);
                    result.Union(rect);
                }
            }

            return result;
        }
    }

}