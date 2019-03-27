using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexaCode
{
    class ImageBorderAdder
    {
        public static Bitmap AddBorder(Bitmap bitmap, int pixels)
        {
            var b = new Bitmap(bitmap.Width + pixels, bitmap.Height + pixels);
            var g = Graphics.FromImage(b);
            g.FillRectangle(Brushes.White, 0, 0, bitmap.Width + pixels, bitmap.Height + pixels);
            g.DrawImage(bitmap, pixels / 2, pixels / 2, bitmap.Width, bitmap.Height);
            g.Dispose();
            return b;
        }
    }
}