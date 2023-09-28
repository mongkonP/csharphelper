
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

  namespace  howto_steganography_hide_image2

 { 

class Stego
    {
        // Hide bm_hidden inside bm_visible and return the result.
        public static Bitmap HideImage(Bitmap bm_visible, Bitmap bm_hidden, int hidden_bits)
        {
            int shift = (8 - hidden_bits);
            int visible_mask = 0xFF << hidden_bits;
            int hidden_mask = 0xFF >> shift;
            Bitmap bm_combined = new Bitmap(bm_visible.Width, bm_visible.Height);
            for (int x = 0; x < bm_visible.Width; x++)
            {
                for (int y = 0; y < bm_visible.Height; y++)
                {
                    Color clr_visible = bm_visible.GetPixel(x, y);
                    Color clr_hidden = bm_hidden.GetPixel(x, y);
                    int r = (clr_visible.R & visible_mask) + ((clr_hidden.R >> shift) & hidden_mask);
                    int g = (clr_visible.G & visible_mask) + ((clr_hidden.G >> shift) & hidden_mask);
                    int b = (clr_visible.B & visible_mask) + ((clr_hidden.B >> shift) & hidden_mask);
                    bm_combined.SetPixel(x, y, Color.FromArgb(255, r, g, b));
                }
            }
            return bm_combined;
        }

        // Recover a hidden image.
        public static Bitmap RecoverImage(Bitmap bm_combined, int hidden_bits)
        {
            int shift = (8 - hidden_bits);
            int hidden_mask = 0xFF >> shift;
            Bitmap bm_hidden = new Bitmap(bm_combined.Width, bm_combined.Height);
            for (int x = 0; x < bm_combined.Width; x++)
            {
                for (int y = 0; y < bm_combined.Height; y++)
                {
                    Color clr_combined = bm_combined.GetPixel(x, y);
                    int r = (clr_combined.R & hidden_mask) << shift;
                    int g = (clr_combined.G & hidden_mask) << shift;
                    int b = (clr_combined.B & hidden_mask) << shift;
                    bm_hidden.SetPixel(x, y, Color.FromArgb(255, r, g, b));
                }
            }
            return bm_hidden;
        }
    }

}