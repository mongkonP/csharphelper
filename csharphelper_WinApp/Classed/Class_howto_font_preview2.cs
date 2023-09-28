
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

  namespace  howto_font_preview2

 { 

public static class FontExtensions
    {
        // Return true if the Fonts represent the same font.
        // Note that the FontStyle property includes
        // Bold, Italic, Regular, Strikeout, and Underline.
        public static bool ValueEquals(this Font font, Font other)
        {
            if (font.Name != other.Name) return false;
            if (font.SizeInPoints != other.SizeInPoints) return false;
            if (font.Style != other.Style) return false;
            return true;
        }
    }

}