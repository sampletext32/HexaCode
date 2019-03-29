using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace HexaCode
{
    class HexagonConverter
    {
        private readonly char[] _alphabet =
        {
            ' ', '!', '"', '#', '$', '%', '&', '\'', '(', ')', '*', '+', ',', '-', '.', '/', '0', '1', '2', '3', '4',
            '5', '6', '7', '8', '9', ':', ';', '<', '=', '>', '?', '@', 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i',
            'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z', '[', '\\', ']', '^',
            '_'
        };

        private readonly char[] _largeAlphabet =
            new char[95]
            {
                ' ', '!', '"', '#', '$', '%', '&', '\'', '(', ')', '*', '+', ',', '-', '.', '/', '0', '1', '2', '3',
                '4',
                '5', '6', '7', '8', '9', ':', ';', '<', '=', '>', '?', '@', 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i',
                'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z', '[', '\\', ']',
                '^',
                '_', '`', 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S',
                'T', 'U', 'V', 'W', 'X', 'Y', 'Z', '{', '|', '}', '~'
            };

        private static float FPi = (float) Math.PI;
        private static float Pi2 = (float) Math.PI / 2;
        private static float Pi3 = (float) Math.PI / 3;
        private static float Pi6 = (float) Math.PI / 6;

        private static float _sqrt3 = (float) Math.Sqrt(3);
        private static float _sqrt2 = (float) Math.Sqrt(2);

        private const float minRadius = 10f;

        //Константы
        private readonly float _r; //Радиус описанной вокруг гексагона окружности
        private readonly float _distanceBetweenHexes; //Расстояние между ячейками

        private char[] _activeAlphabet;

        public HexagonConverter(float r = 50f, float distanceBetweenHexes = 0f)
        {
            if (r < minRadius)
            {
                throw new IndexOutOfRangeException("Radius Is Too Small");
            }

            _r = r;
            _distanceBetweenHexes = distanceBetweenHexes;
        }

        private static float GetDrawingR(float radius, float distanceBetweenHexes)
        {
            return radius + distanceBetweenHexes / 2;
        }

        private static string ToBinaryString(int value, int strLength)
        {
            return Convert.ToString(value, 2).PadLeft(strLength, '0');
        }

        private static float GetWidth(int layer, float radius, float distanceBetweenHexes)
        {
            return (float) Math.Ceiling(2 * GetDrawingR(radius, distanceBetweenHexes) * (1.5f * layer + 1));
        }

        private static int GetLayerFromWidth(int width, float radius, float distanceBetweenHexes)
        {
            int layer = 0;
            while (GetWidth(layer, radius, distanceBetweenHexes) < width)
            {
                layer++;
            }

            return layer - 1;
        }

        private float GetHeight(int layer)
        {
            return (float) Math.Ceiling((2 * layer + 1) * _sqrt3 * GetDrawingR(_r, _distanceBetweenHexes));
        }

        private static int GetItemLayer(int item)
        {
            var index = item; //индекс символа в текущем слое
            var layer = 1; //вычисляем слой буквы
            for (var sub = 1; index - sub * 6 >= 0; layer++, sub++)
            {
                index -= sub * 6;
            }

            return layer;
        }

        private static List<PointF> ListHexagonPoints(PointF center, float radius)
        {
            List<PointF> points = new List<PointF>(6);
            for (int i = 0; i <= 5; i++)
            {
                points.Add(new PointF(center.X + radius * (float) Math.Cos(Pi3 * i),
                    center.Y + radius * (float) Math.Sin(Pi3 * i)));
            }

            return points;
        }

        private static List<Tuple<PointF, PointF, PointF>> ListHexagonTriangles(List<PointF> points, PointF center)
        {
            List<Tuple<PointF, PointF, PointF>> list = new List<Tuple<PointF, PointF, PointF>>(6);
            for (int i = 0; i < 5; i++)
            {
                list.Add(new Tuple<PointF, PointF, PointF>(points[i], points[i + 1], center));
            }

            list.Add(new Tuple<PointF, PointF, PointF>(points[5], points[0], center));
            return list;
        }

        private static List<PointF> GetPixelsFromCenter(PointF centerPoint, float drawingR)
        {
            List<PointF> list = new List<PointF>();
            float dy = _sqrt3 / 2 * drawingR / 2;
            list.Add(new PointF(centerPoint.X + drawingR / 2, centerPoint.Y + dy));
            list.Add(new PointF(centerPoint.X, centerPoint.Y + dy));
            list.Add(new PointF(centerPoint.X - drawingR / 2, centerPoint.Y + dy));
            list.Add(new PointF(centerPoint.X - drawingR / 2, centerPoint.Y - dy));
            list.Add(new PointF(centerPoint.X, centerPoint.Y - dy));
            list.Add(new PointF(centerPoint.X + drawingR / 2, centerPoint.Y - dy));
            return list;
        }

        private static void DrawHexagon(float xCenter, float yCenter, float radius, Graphics graphics, bool[] binary)
        {
            var pointCenter = new PointF(xCenter, yCenter);
            var points = ListHexagonPoints(pointCenter, radius);
            var triangles = ListHexagonTriangles(points, pointCenter);
            for (var i = 0; i < triangles.Count; i++)
            {
                if (i < binary.Length && binary[i])
                {
                    graphics.FillPolygon(Brushes.Black,
                        new[] {triangles[i].Item1, triangles[i].Item2, triangles[i].Item3});
                    //Logger.AppendLine("Pixel " + i + ": " + true);
                }
                else
                {
                    //Logger.AppendLine("Pixel " + i + ": " + false);
                }

                graphics.DrawPolygon(Pens.Black, new[] {triangles[i].Item1, triangles[i].Item2, triangles[i].Item3});
            }
        }

        private int GetAlphabetBinaryDigits(bool useLargeAlphabet)
        {
            return 6 + (useLargeAlphabet ? 1 : 0);
        }

        private string FromBinaryString(string binaryString, bool useLargeAlphabet)
        {
            string s = "";
            var digitsPerPiece = GetAlphabetBinaryDigits(useLargeAlphabet);
            while (binaryString.Length >= digitsPerPiece)
            {
                string subset = binaryString.Substring(0, digitsPerPiece);
                int index = Convert.ToInt32(subset, 2);
                s += _activeAlphabet[index];
                binaryString = binaryString.Remove(0, digitsPerPiece);
            }


            return s;
        }

        private static bool[] ToBoolArray(string s)
        {
            return s.Select(t => t == '1').ToArray();
        }

        private static string Reverse(string text)
        {
            if (text == null) return null;

            var array = text.ToCharArray();
            Array.Reverse(array);
            return new string(array);
        }

        private static bool IsPixelBlack(Color pixel)
        {
            return pixel.R + pixel.G + pixel.B == 0;
        }

        public static float GetHexagonRadiusFromImage(Bitmap bitmap, float distanceBetweenHexes)
        {
            var width = bitmap.Width;
            var height = bitmap.Height;

            var centerX = width / 2f;
            var centerY = height / 2f;

            var centerHexagonCenter = new PointF(centerX, centerY);
            var centerBinaryStringBuilder = new StringBuilder();

            var drawingR = GetDrawingR(minRadius, 0f);
            var centerHexagonPixels = GetPixelsFromCenter(centerHexagonCenter, drawingR);
            for (int i = centerHexagonPixels.Count - 1; i >= 0; i--)
            {
                var value = bitmap.GetPixel((int) centerHexagonPixels[i].X, (int) centerHexagonPixels[i].Y);
                if (IsPixelBlack(value)) //black
                {
                    centerBinaryStringBuilder.Append('1');
                }
                else
                {
                    centerBinaryStringBuilder.Append('0');
                }
            }

            bool[] metaData = ToBoolArray(Reverse(centerBinaryStringBuilder.ToString()));
            var useLargeAlphabet = metaData[0];

            var imageActiveLayer = 0;
            for (int i = metaData.Length - 1; i >= 1; i--)
            {
                imageActiveLayer += (metaData[i] ? 1 : 0) * (int) Math.Pow(2, metaData.Length - i - 1);
            }


            //во всю ширину картинки попадает (3 * R * layer + 2 * R) пикселей
            //dx = 1.5f * R * layer + R
            //width = 3f * drawingR * layer + 2 * R

            //var layerWidth = GetWidth(imageActiveLayer, 20f, 0f);
            //var trueRadius = ((layerWidth) / (3f * imageActiveLayer + 2));

            var imageRadius = ((width) / (3f * imageActiveLayer + 2));

            return imageRadius;
        }

        //precision [0..255]
        public string ParseCorrectBitmap(Bitmap bitmap, int precision = 10)
        {
            Graphics g = Graphics.FromImage(bitmap);
            var drawingR = GetDrawingR(_r, _distanceBetweenHexes);
            var width = bitmap.Width;
            var height = bitmap.Height;

            var centerX = width / 2f;
            var centerY = height / 2f;

            var maxLayer = GetLayerFromWidth(width, _r, _distanceBetweenHexes);

            var hexesInMaxLayerSide = maxLayer + 1;

            var centerHexagonCenter = new PointF(centerX, centerY);
            var centerBinaryStringBuilder = new StringBuilder();
            var centerHexagonPixels = GetPixelsFromCenter(centerHexagonCenter, drawingR);
            for (int i = centerHexagonPixels.Count - 1; i >= 0; i--)
            {
                var value = bitmap.GetPixel((int) centerHexagonPixels[i].X, (int) centerHexagonPixels[i].Y);
                if (IsPixelBlack(value)) //black
                {
                    centerBinaryStringBuilder.Append('1');
                }
                else
                {
                    centerBinaryStringBuilder.Append('0');
                }
            }

            bool[] metaData = ToBoolArray(Reverse(centerBinaryStringBuilder.ToString()));

            var useLargeAlphabet = metaData[0];

            _activeAlphabet = metaData[0] ? _largeAlphabet : _alphabet;

            var imageActiveLayer = 0;
            for (int i = metaData.Length - 1; i >= 1; i--)
            {
                imageActiveLayer += (metaData[i] ? 1 : 0) * (int) Math.Pow(2, metaData.Length - i - 1);
            }

            var sumHexagons = GetLayerSumHexagonsCount(imageActiveLayer) - 1;

            var font = new Font("Arial", 16);
            var size1 = g.MeasureString("1", font);
            var size0 = g.MeasureString("0", font);
            var binaryStringBuilder = new StringBuilder(sumHexagons * 6);
            for (int index = sumHexagons - 1; index >= 0; index--)
            {
                var position = index; //индекс символа в текущем слое
                var currentLayer = 1; //вычисляем слой буквы
                for (var sub = 1; position - sub * 6 >= 0; currentLayer++, sub++)
                {
                    position -= sub * 6;
                }

                var hexesInSide = currentLayer + 1;

                var vecX = centerX + 1.5f * drawingR * currentLayer; // сдвигаемся в правый верхний угол
                var vecY = centerY - _sqrt3 / 2 * drawingR * currentLayer;

                //начинаем в цикле сдвигаться по грани гексагона
                for (var j = 0; j <= position; j++)
                {
                    for (int side = 0; side < hexesInSide - 1 && j < position; side++, j++)
                    {
                        vecY += _sqrt3 * drawingR;
                    }

                    for (int side = 0; side < hexesInSide - 1 && j < position; side++, j++)
                    {
                        vecY += drawingR * _sqrt3 / 2;
                        vecX -= 1.5f * drawingR;
                    }

                    for (int side = 0; side < hexesInSide - 1 && j < position; side++, j++)
                    {
                        vecY -= drawingR * _sqrt3 / 2;
                        vecX -= 1.5f * drawingR;
                    }

                    for (int side = 0; side < hexesInSide - 1 && j < position; side++, j++)
                    {
                        vecY -= _sqrt3 * drawingR;
                    }

                    for (int side = 0; side < hexesInSide - 1 && j < position; side++, j++)
                    {
                        vecY -= drawingR * _sqrt3 / 2;
                        vecX += 1.5f * drawingR;
                    }

                    for (int side = 0; side < hexesInSide - 1 && j < position; side++, j++)
                    {
                        vecY += drawingR * _sqrt3 / 2;
                        vecX += 1.5f * drawingR;
                    }
                }

                //реальные координаты гексагона
                var hexagonX = vecX;
                var hexagonY = vecY;

                var hexagonCenterPoint = new PointF(hexagonX, hexagonY);

                var pixels = GetPixelsFromCenter(hexagonCenterPoint, drawingR);
                for (int i = pixels.Count - 1; i >= 0; i--)
                {
                    var value = bitmap.GetPixel((int) pixels[i].X, (int) pixels[i].Y);
                    if (IsPixelBlack(value)) //black
                    {
                        binaryStringBuilder.Append('1');
                        //g.DrawString("1", font, Brushes.Red, pixels[i].X - size1.Width / 2,
                        //    pixels[i].Y - size1.Height / 2);
                    }
                    else
                    {
                        binaryStringBuilder.Append('0');
                        //g.DrawString("0", font, Brushes.Red, pixels[i].X - size0.Width / 2,
                        //    pixels[i].Y - size0.Height / 2);
                    }
                }
            }

            var binaryString = Reverse(binaryStringBuilder.ToString());
            return FromBinaryString(binaryString, useLargeAlphabet);
        }

        public static int GetLayerSumHexagonsCount(int layer)
        {
            int sum = 0;
            for (int i = 1; i <= layer; i++)
            {
                sum += i * 6;
            }

            return sum + 1;
        }

        private List<string> DivideBy6(string content)
        {
            var list = new List<string>();
            while (content.Length >= 6)
            {
                string subset = content.Substring(0, 6);
                list.Add(subset);
                content = content.Remove(0, 6);
            }

            if (content.Length > 0)
            {
                list.Add(content.PadRight(6, '0'));
            }

            return list;
        }

        public Bitmap GenerateBitmap(string content)
        {
            if (content.Length == 0)
            {
                throw new IndexOutOfRangeException("Content Length 0");
            }

            //если хотя бы 1 символ в обычном алфавите отсутствует
            var useLargeAlphabet = content.Any(c => !_alphabet.Contains(c));

            //длина бинарного символа (кол-во бит на символ)
            var binarySymbolLength = GetAlphabetBinaryDigits(useLargeAlphabet);

            var sb = new StringBuilder(content.Length * binarySymbolLength);
            _activeAlphabet = useLargeAlphabet ? _largeAlphabet : _alphabet;
            foreach (var t in content)
            {
                sb.Append(ToBinaryString(Array.IndexOf(_activeAlphabet, t), binarySymbolLength));
            }

            var binaryString = sb.ToString();

            if (binaryString.Length > GetLayerSumHexagonsCount(32) * 6)
            {
                throw new IndexOutOfRangeException("Message is too long");
            }

            var binaryPieces = DivideBy6(binaryString);

            var maxUsedLayer = GetItemLayer(binaryPieces.Count - 1);

            var drawingR = GetDrawingR(_r, _distanceBetweenHexes);
            var width = GetWidth(maxUsedLayer, _r, _distanceBetweenHexes) + 1;
            var height = GetHeight(maxUsedLayer) + 1;

            var bitmap = new Bitmap((int) width, (int) height);

            var graphics = Graphics.FromImage(bitmap);

            graphics.FillRectangle(Brushes.White, 0, 0, width, height);


            var maxUsedLayerBinaryString = Convert.ToString(maxUsedLayer, 2);
            maxUsedLayerBinaryString = maxUsedLayerBinaryString.PadLeft(5, '0');
            var maxUserLayerBoolArray = ToBoolArray(maxUsedLayerBinaryString);


            var centerX = width / 2f;
            var centerY = height / 2f;

            var metaData = new bool[6];
            metaData[0] = useLargeAlphabet;
            for (int i = 0; i < maxUserLayerBoolArray.Length; i++)
            {
                metaData[i + 1] = maxUserLayerBoolArray[i];
            }

            //graphics.DrawLine(Pens.DarkSlateGray, centerX, 0, centerX, height);
            //graphics.DrawLine(Pens.DarkSlateGray, 0, centerY, width, centerY);

            DrawHexagon(centerX, centerY, _r, graphics, metaData);

            for (var i = 0; i < GetLayerSumHexagonsCount(maxUsedLayer) - 1; i++)
            {
                bool[] binaryPiece;
                if (i < binaryPieces.Count)
                {
                    binaryPiece = binaryPieces[i].Select(c => c == '1').ToArray();
                }
                else
                {
                    binaryPiece = new[] {false, false, false, false, false, false};
                }

                //считаем по формуле pieces = 1 * 6 + 2 * 6 + 3 * 6
                //тогда pieces / 6 = 1 + 2 + 3 + 4 
                //но pieces / 6 = i
                //тогда, вычитая последовательно числа от 1 до N мы узнаем на каком слое лежит данный гексагон

                var indexInLayer = i; //индекс символа в текущем слое
                var layer = 1; //вычисляем слой буквы
                for (var sub = 1; indexInLayer - sub * 6 >= 0; layer++, sub++)
                {
                    indexInLayer -= sub * 6;
                }

                //чётный ли слой
                //var isEvenLayer = layer % 2 == 0; 

                //количество гексагонов в слое
                //var hexagonsInLayer = layer * 6; 

                var hexesInSide = layer + 1;

                var vecX = centerX + 1.5f * drawingR * layer; // сдвигаемся в правый верхний угол
                var vecY = centerY - _sqrt3 / 2 * drawingR * layer;

                //начинаем в цикле сдвигаться по грани гексагона
                for (var j = 0; j <= indexInLayer; j++)
                {
                    for (int side = 0; side < hexesInSide - 1 && j < indexInLayer; side++, j++)
                    {
                        vecY += _sqrt3 * drawingR;
                    }

                    for (int side = 0; side < hexesInSide - 1 && j < indexInLayer; side++, j++)
                    {
                        vecY += drawingR * _sqrt3 / 2;
                        vecX -= 1.5f * drawingR;
                    }

                    for (int side = 0; side < hexesInSide - 1 && j < indexInLayer; side++, j++)
                    {
                        vecY -= drawingR * _sqrt3 / 2;
                        vecX -= 1.5f * drawingR;
                    }

                    for (int side = 0; side < hexesInSide - 1 && j < indexInLayer; side++, j++)
                    {
                        vecY -= _sqrt3 * drawingR;
                    }

                    for (int side = 0; side < hexesInSide - 1 && j < indexInLayer; side++, j++)
                    {
                        vecY -= drawingR * _sqrt3 / 2;
                        vecX += 1.5f * drawingR;
                    }

                    for (int side = 0; side < hexesInSide - 1 && j < indexInLayer; side++, j++)
                    {
                        vecY += drawingR * _sqrt3 / 2;
                        vecX += 1.5f * drawingR;
                    }
                }

                ////реальные координаты гексагона
                var hexagonX = vecX;
                var hexagonY = vecY;

                //рисуем гексагон
                DrawHexagon(hexagonX, hexagonY, _r, graphics, binaryPiece);
            }

            graphics.Dispose();
            return bitmap;
        }
    }
}