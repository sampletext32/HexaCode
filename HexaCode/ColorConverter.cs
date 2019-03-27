using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexaCode
{
    class ColorConverter
    {
        public static Bitmap ToGrayScale(Bitmap source)
        {
            Bitmap bitmap = new Bitmap(source.Width, source.Height);
            int rgb;
            Color c;

            for (int y = 0; y < bitmap.Height; y++)
            {
                for (int x = 0; x < bitmap.Width; x++)
                {
                    c = source.GetPixel(x, y);
                    rgb = (int) Math.Round(.299 * c.R + .587 * c.G + .114 * c.B);
                    bitmap.SetPixel(x, y, Color.FromArgb(rgb, rgb, rgb));
                }
            }

            return bitmap;
        }

        public static Bitmap SplitColors(Bitmap source, float brightnessLimit)
        {
            Bitmap bitmap = new Bitmap(source.Width, source.Height);
            for (int i = 0; i < source.Width; i++)
            {
                for (int j = 0; j < source.Height; j++)
                {
                    var pixel = source.GetPixel(i, j);
                    if (pixel.GetBrightness() > brightnessLimit)
                    {
                        bitmap.SetPixel(i, j, Color.White);
                    }
                    else
                    {
                        bitmap.SetPixel(i, j, Color.Black);
                    }
                }
            }

            return bitmap;
        }

        public static Bitmap TrimToBlack(Bitmap source)
        {
            int minBlackX = source.Width;
            int minBlackY = source.Height;

            int maxBlackX = 0;
            int maxBlackY = 0;

            for (int i = 0; i < source.Width; i++)
            {
                for (int j = 0; j < source.Height; j++)
                {
                    var pixel = source.GetPixel(i, j);
                    if (pixel.GetBrightness() > 0.7f)
                    {
                        source.SetPixel(i, j, Color.White);
                    }
                    else
                    {
                        source.SetPixel(i, j, Color.Black);
                        if (i > maxBlackX)
                        {
                            maxBlackX = i;
                        }

                        if (i < minBlackX)
                        {
                            minBlackX = i;
                        }

                        if (j > maxBlackY)
                        {
                            maxBlackY = j;
                        }

                        if (j < minBlackY)
                        {
                            minBlackY = j;
                        }
                    }
                }
            }

            Bitmap trimmedBitmap = new Bitmap(maxBlackX - minBlackX + 1, maxBlackY - minBlackY + 1);

            for (int i = 0; i < trimmedBitmap.Width; i++)
            {
                for (int j = 0; j < trimmedBitmap.Height; j++)
                {
                    trimmedBitmap.SetPixel(i, j, source.GetPixel(minBlackX + i, minBlackY + j));
                }
            }

            return trimmedBitmap;
        }

        public static Bitmap ScaleBitmap(Bitmap source, float factor)
        {
            var newWidth = (int) (source.Width * factor);
            var newHeight = (int) (source.Height * factor);
            Bitmap bitmap = new Bitmap(newWidth, newHeight);
            Graphics g = Graphics.FromImage(bitmap);
            g.DrawImage(source, 0, 0, newWidth, newHeight);
            g.Dispose();
            return bitmap;
        }

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