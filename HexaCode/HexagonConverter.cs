using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
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

        private const float FPi = (float) Math.PI;
        private const float Pi2 = (float) Math.PI / 2;
        private const float Pi3 = (float) Math.PI / 3;
        private const float Pi6 = (float) Math.PI / 6;

        private readonly float _sqrt3 = (float) Math.Sqrt(3);
        private readonly float _sqrt2 = (float) Math.Sqrt(2);

        //Константы
        private readonly float _r; //Радиус описанной вокруг гексагона окружности
        private readonly float _distanceBetweenHexes; //Расстояние между ячейками

        private char[] _activeAlphabet;

        public HexagonConverter(float r = 25f, float distanceBetweenHexes = 0f)
        {
            _r = r;
            _distanceBetweenHexes = distanceBetweenHexes;
        }

        private float GetDrawingR()
        {
            return _r + _distanceBetweenHexes / 2;
        }

        private static string ToBinaryString(int value, int strLength)
        {
            return Convert.ToString(value, 2).PadLeft(strLength, '0');
        }

        private float GetWidth(int layer)
        {
            return 2 * (1.5f * GetDrawingR() * layer + _r);
        }

        private int GetLayerFromWidth(int width)
        {
            return (int) Math.Ceiling((width / 2f - _r) / 1.5f / GetDrawingR());
        }

        private float GetHeight(int layer)
        {
            return 2 * (2 * layer + 1) * _sqrt3 * GetDrawingR();
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

        private static PointF CenterTriangle(Tuple<PointF, PointF, PointF> triangle)
        {
            return new PointF((triangle.Item1.X + triangle.Item2.X + triangle.Item3.X) / 3f,
                (triangle.Item1.Y + triangle.Item2.Y + triangle.Item3.Y) / 3f);
        }

        private List<PointF> GetPixelsFromCenter(PointF centerPoint)
        {
            var drawingR = GetDrawingR();
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
                }
                else
                {
                    graphics.DrawPolygon(Pens.Black,
                        new[] {triangles[i].Item1, triangles[i].Item2, triangles[i].Item3});
                }
            }
        }


        private bool[] ToBinaryPieceFromPosition(string binaryString, int position, int digitsPerPiece)
        {
            var binaryPieceLength = (binaryString.Length - position * digitsPerPiece) > digitsPerPiece
                ? digitsPerPiece
                : (binaryString.Length - position * digitsPerPiece);
            var binaryPiece = new bool[binaryPieceLength];
            for (var j = 0; j < binaryPieceLength && j < binaryString.Length; j++)
            {
                binaryPiece[j] = binaryString[position * 6 + j] == '1';
                //binaryPiece[j] = false;
            }

            return binaryPiece;
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
                s += _alphabet[index];
                binaryString = binaryString.Remove(0, digitsPerPiece);
            }

            return s;
        }

        private bool[] ToBoolArray(string s)
        {
            return s.Select(t => t == '1').ToArray();
        }

        public string Reverse(string text)
        {
            if (text == null) return null;

            // this was posted by petebob as well 
            char[] array = text.ToCharArray();
            Array.Reverse(array);
            return new String(array);
        }


        //precision [0..255]
        public string ParseBitmap(Bitmap bitmap, int precision = 10)
        {
            var drawingR = GetDrawingR();
            var width = bitmap.Width;
            var height = bitmap.Height;

            var centerX = width / 2f;
            var centerY = height / 2f;

            var maxLayer = GetLayerFromWidth(width);

            var hexesInMaxLayerSide = maxLayer + 1;

            var centerHexagonCenter = new PointF(centerX, centerY);
            var centerHexagonPoints = ListHexagonPoints(centerHexagonCenter, _r);
            var centerHexagonTriangles = ListHexagonTriangles(centerHexagonPoints, centerHexagonCenter);
            var centerBinaryStringBuilder = new StringBuilder();
            for (int i = centerHexagonTriangles.Count - 1; i >= 0; i--)
            {
                var centerTriangle = CenterTriangle(centerHexagonTriangles[i]);
                var value = bitmap.GetPixel((int) centerTriangle.X, (int) centerTriangle.Y);
                if (value.A == 255) //black
                {
                    centerBinaryStringBuilder.Append('1');
                }
                else
                {
                    centerBinaryStringBuilder.Append('0');
                }
            }

            bool[] flags = ToBoolArray(Reverse(centerBinaryStringBuilder.ToString()));
            var useLargeAlphabet = flags[0];

            var sumHexagons = GetLayerSumHexagonsCount(maxLayer) - 1;
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

                var hexagonX = centerX + 1.5f * drawingR * currentLayer; // сдвигаемся в правый верхний угол
                var hexagonY = centerY - _sqrt3 / 2 * drawingR * currentLayer;

                //начинаем в цикле сдвигаться по грани гексагона
                for (var j = 0; j <= index; j++)
                {
                    for (int side = 0; side < hexesInSide - 1 && j < index; side++, j++)
                    {
                        hexagonY += _sqrt3 * drawingR;
                    }

                    for (int side = 0; side < hexesInSide - 1 && j < index; side++, j++)
                    {
                        hexagonY += drawingR * _sqrt3 / 2;
                        hexagonX -= 1.5f * drawingR;
                    }

                    for (int side = 0; side < hexesInSide - 1 && j < index; side++, j++)
                    {
                        hexagonY -= drawingR * _sqrt3 / 2;
                        hexagonX -= 1.5f * drawingR;
                    }

                    for (int side = 0; side < hexesInSide - 1 && j < index; side++, j++)
                    {
                        hexagonY -= _sqrt3 * drawingR;
                    }

                    for (int side = 0; side < hexesInSide - 1 && j < index; side++, j++)
                    {
                        hexagonY -= drawingR * _sqrt3 / 2;
                        hexagonX += 1.5f * drawingR;
                    }

                    for (int side = 0; side < hexesInSide - 1 && j < index; side++, j++)
                    {
                        hexagonY += drawingR * _sqrt3 / 2;
                        hexagonX += 1.5f * drawingR;
                    }
                }

                var hexagonCenterPoint = new PointF(hexagonX, hexagonY);
                var pixels = GetPixelsFromCenter(hexagonCenterPoint);
                for (int i = 0; i < pixels.Count; i++)
                {
                    var value = bitmap.GetPixel((int)pixels[i].X, (int)pixels[i].Y);
                    if (value.A == 255) //black
                    {
                        binaryStringBuilder.Append('1');
                    }
                    else
                    {
                        binaryStringBuilder.Append('0');
                    }
                }
            }

            int a = 5;

            return FromBinaryString(Reverse(binaryStringBuilder.ToString()), useLargeAlphabet);
        }

        private int GetLayerSumHexagonsCount(int layer)
        {
            int sum = 0;
            for (int i = 1; i <= layer; i++)
            {
                sum += i * 6;
            }

            return sum + 1;
        }

        public Bitmap GenerateBitmap(string content)
        {
            var drawingR = GetDrawingR();
            var maxLayer = GetItemLayer(content.Length);
            var width = GetWidth(maxLayer);
            var height = GetWidth(maxLayer);

            var bitmap = new Bitmap((int) Math.Ceiling(width), (int) Math.Ceiling(height));

            var graphics = Graphics.FromImage(bitmap);

            //если хотя бы 1 символ в обычном алфавите отсутствует
            var useLargeAlphabet = content.Any(c => !_alphabet.Contains(c));

            //длина бинарного символа (кол-во бит на символ)
            var binarySymbolLength = 6 + (useLargeAlphabet ? 1 : 0);

            var sb = new StringBuilder(content.Length * binarySymbolLength);
            _activeAlphabet = useLargeAlphabet ? _largeAlphabet : _alphabet;
            foreach (var t in content)
            {
                sb.Append(ToBinaryString(Array.IndexOf(_activeAlphabet, t), binarySymbolLength));
            }


            var binaryString = sb.ToString();

            var centerX = width / 2f;
            var centerY = height / 2f;

            //graphics.DrawLine(Pens.DarkSlateGray, centerX, 0, centerX, height);
            //graphics.DrawLine(Pens.DarkSlateGray, 0, centerY, width, centerY);

            DrawHexagon(centerX, centerY, _r, graphics, new[] {useLargeAlphabet});

            for (var i = 0; i < content.Length; i++)
            {
                var binaryPiece = ToBinaryPieceFromPosition(binaryString, i, binarySymbolLength);

                //считаем по формуле pieces = 1 * 6 + 2 * 6 + 3 * 6
                //тогда pieces / 6 = 1 + 2 + 3 + 4 
                //но pieces / 6 = i
                //тогда, вычитая последовательно числа от 1 до N мы узнаем на каком слое лежит данный гексагон

                var index = i; //индекс символа в текущем слое
                var layer = 1; //вычисляем слой буквы
                for (var sub = 1; index - sub * 6 >= 0; layer++, sub++)
                {
                    index -= sub * 6;
                }

                //чётный ли слой
                //var isEvenLayer = layer % 2 == 0; 

                //количество гексагонов в слое
                //var hexagonsInLayer = layer * 6; 

                var hexesInSide = layer + 1;

                var vecX = centerX + 1.5f * drawingR * layer; // сдвигаемся в правый верхний угол
                var vecY = centerY - _sqrt3 / 2 * drawingR * layer;
                //начинаем в цикле сдвигаться по грани гексагона
                for (var j = 0; j <= index; j++)
                {
                    for (int side = 0; side < hexesInSide - 1 && j < index; side++, j++)
                    {
                        vecY += _sqrt3 * drawingR;
                    }

                    for (int side = 0; side < hexesInSide - 1 && j < index; side++, j++)
                    {
                        vecY += drawingR * _sqrt3 / 2;
                        vecX -= 1.5f * drawingR;
                    }

                    for (int side = 0; side < hexesInSide - 1 && j < index; side++, j++)
                    {
                        vecY -= drawingR * _sqrt3 / 2;
                        vecX -= 1.5f * drawingR;
                    }

                    for (int side = 0; side < hexesInSide - 1 && j < index; side++, j++)
                    {
                        vecY -= _sqrt3 * drawingR;
                    }

                    for (int side = 0; side < hexesInSide - 1 && j < index; side++, j++)
                    {
                        vecY -= drawingR * _sqrt3 / 2;
                        vecX += 1.5f * drawingR;
                    }

                    for (int side = 0; side < hexesInSide - 1 && j < index; side++, j++)
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