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
        
        private const float MinRadius = 10f;

        //Константы
        private readonly float _r; //Радиус описанной вокруг гексагона окружности
        private readonly float _distanceBetweenHexes; //Расстояние между ячейками

        private char[] _activeAlphabet;

        public HexagonConverter(float r = 50f, float distanceBetweenHexes = 0f)
        {
            if (r < MinRadius)
            {
                throw new IndexOutOfRangeException("Radius Is Too Small");
            }

            _r = r;
            _distanceBetweenHexes = distanceBetweenHexes;
        }

        private static void DrawHexagon(PointF centerPoint, float radius, Graphics graphics, bool[] binary)
        {
            var points = MathHelper.ListHexagonPoints(centerPoint, radius);
            var triangles = MathHelper.ListHexagonTriangles(points, centerPoint);
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
            var s = "";
            var digitsPerPiece = GetAlphabetBinaryDigits(useLargeAlphabet);
            while (binaryString.Length >= digitsPerPiece)
            {
                var subset = binaryString.Substring(0, digitsPerPiece);
                var index = Convert.ToInt32(subset, 2);
                s += _activeAlphabet[index];
                binaryString = binaryString.Remove(0, digitsPerPiece);
            }


            return s;
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

            var drawingR = HexMathHelper.GetDrawingR(MinRadius, 0f);
            var centerHexagonPixels = MathHelper.GetPixelsFromCenter(centerHexagonCenter, drawingR);
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

            var metaData = BinaryHelper.ToBoolArray(Reverse(centerBinaryStringBuilder.ToString()));
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

        /// <summary>
        ///  <para> Парсит один шестиугольник, зная координаты его центра и радиус</para>
        ///  <para> Возвращает данные в обратном порядке</para>
        /// </summary>
        /// <param name="bitmap">Исходная картинка</param>
        /// <param name="centerPoint">Центр шестиугольника</param>
        /// <param name="drawingR">Радиус шестиугольника</param>
        /// <returns></returns>
        public string ParseHexagon(Bitmap bitmap, PointF centerPoint, float drawingR)
        {
            var centerBinaryStringBuilder = new StringBuilder();
            var centerHexagonPixels = MathHelper.GetPixelsFromCenter(centerPoint, drawingR);
            for (int i = centerHexagonPixels.Count - 1; i >= 0; i--)
            {
                var value = bitmap.GetPixel((int)centerHexagonPixels[i].X, (int)centerHexagonPixels[i].Y);
                if (IsPixelBlack(value)) //black
                {
                    centerBinaryStringBuilder.Append('1');
                }
                else
                {
                    centerBinaryStringBuilder.Append('0');
                }
            }

            return centerBinaryStringBuilder.ToString();
        }

        //precision [0..255]
        public string ParseCorrectBitmap(Bitmap bitmap)
        {
            var drawingR = HexMathHelper.GetDrawingR(_r, _distanceBetweenHexes);
            var width = bitmap.Width;
            var height = bitmap.Height;
            
            var centerPoint = new PointF(width / 2f, height / 2f);
            var centerHexagonDataString = ParseHexagon(bitmap, centerPoint, drawingR);

            var metaData = BinaryHelper.ToBoolArray(Reverse(centerHexagonDataString));

            var useLargeAlphabet = metaData[0];

            _activeAlphabet = metaData[0] ? _largeAlphabet : _alphabet;

            var imageActiveLayer = 0;
            for (int i = metaData.Length - 1; i >= 1; i--)
            {
                imageActiveLayer += (metaData[i] ? 1 : 0) * (int) Math.Pow(2, metaData.Length - i - 1);
            }

            var sumHexagons = HexMathHelper.GetLayerSumHexagonsCount(imageActiveLayer) - 1;
            
            var binaryStringBuilder = new StringBuilder(sumHexagons * 6);
            for (int index = sumHexagons - 1; index >= 0; index--)
            {
                var position = index; //индекс символа в текущем слое
                var currentLayer = 1; //вычисляем слой буквы
                
                HexMathHelper.GetItemLayer(ref position, ref currentLayer);

                var hexesInSide = HexMathHelper.GetHexagonsInSide(currentLayer);

                var hexagonPoint = centerPoint;
                HexMathHelper.TranlateToTopRightCorner(ref hexagonPoint, drawingR, currentLayer);

                HexMathHelper.TranslatePointAroundHexagon(ref hexagonPoint, position, hexesInSide, drawingR);
                
                var hexagonDataString = ParseHexagon(bitmap, hexagonPoint, drawingR);
                binaryStringBuilder.Append(hexagonDataString);
            }

            var binaryString = Reverse(binaryStringBuilder.ToString());
            return FromBinaryString(binaryString, useLargeAlphabet);
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
                sb.Append(BinaryHelper.ToBinaryString(Array.IndexOf(_activeAlphabet, t), binarySymbolLength));
            }

            var binaryString = sb.ToString();

            if (binaryString.Length > HexMathHelper.GetLayerSumHexagonsCount(32) * 6)
            {
                throw new IndexOutOfRangeException("Message is too long");
            }

            var binaryPieces = BinaryHelper.DivideBy6(binaryString);

            var maxUsedIndex = binaryPieces.Count - 1;
            var maxUsedLayer = 0;
            HexMathHelper.GetItemLayer(ref maxUsedIndex, ref maxUsedLayer);

            var drawingR = HexMathHelper.GetDrawingR(_r, _distanceBetweenHexes);
            var width = HexMathHelper.GetWidth(maxUsedLayer, _r, _distanceBetweenHexes) + 1;
            var height = HexMathHelper.GetHeight(maxUsedLayer, _r, _distanceBetweenHexes) + 1;

            var bitmap = new Bitmap((int) width, (int) height);

            var graphics = Graphics.FromImage(bitmap);

            graphics.FillRectangle(Brushes.White, 0, 0, width, height);


            var maxUsedLayerBinaryString = Convert.ToString(maxUsedLayer, 2);
            maxUsedLayerBinaryString = maxUsedLayerBinaryString.PadLeft(5, '0');
            var maxUserLayerBoolArray = BinaryHelper.ToBoolArray(maxUsedLayerBinaryString);
            
            var centerPoint = new PointF(width / 2f, height / 2f);

            var metaData = new bool[6];
            metaData[0] = useLargeAlphabet;
            for (int i = 0; i < maxUserLayerBoolArray.Length; i++)
            {
                metaData[i + 1] = maxUserLayerBoolArray[i];
            }

            //graphics.DrawLine(Pens.DarkSlateGray, centerX, 0, centerX, height);
            //graphics.DrawLine(Pens.DarkSlateGray, 0, centerY, width, centerY);
            
            DrawHexagon(centerPoint, _r, graphics, metaData);

            for (var i = 0; i < HexMathHelper.GetLayerSumHexagonsCount(maxUsedLayer) - 1; i++)
            {
                bool[] binaryPiece;
                if (i < binaryPieces.Count)
                {
                    binaryPiece = BinaryHelper.ToBoolArray(binaryPieces[i]);
                }
                else
                {
                    binaryPiece = new[] {false, false, false, false, false, false};
                }
                
                var position = i; //индекс символа в текущем слое
                var currentLayer = 1; //вычисляем слой буквы

                HexMathHelper.GetItemLayer(ref position, ref currentLayer);
                
                var hexesInSide = HexMathHelper.GetHexagonsInSide(currentLayer);

                var hexagonPoint = centerPoint;
                HexMathHelper.TranlateToTopRightCorner(ref hexagonPoint, drawingR, currentLayer);

                HexMathHelper.TranslatePointAroundHexagon(ref hexagonPoint, position, hexesInSide, drawingR);
                
                //рисуем гексагон
                DrawHexagon(hexagonPoint, _r, graphics, binaryPiece);
            }

            graphics.Dispose();
            return bitmap;
        }
    }
}