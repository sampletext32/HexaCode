using System;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HexaCode
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

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

        private void drawHexagon(float xCenter, float yCenter, float radius, Graphics graphics, bool[] binary)
        {
            var pointCenter = new PointF(xCenter, yCenter);
            for (int i = 0; i <= 5; i++)
            {
                var x = xCenter + radius * (float) Math.Cos(Pi3 * i);
                var y = yCenter + radius * (float) Math.Sin(Pi3 * i);
                var xPrev = xCenter + radius * (float) Math.Cos(Pi3 * (i + 1));
                var yPrev = yCenter + radius * (float) Math.Sin(Pi3 * (i + 1));
                if (i < binary.Length && binary[i])
                {
                    graphics.FillPolygon(Brushes.Black,
                        new[] {new PointF(x, y), new PointF(xPrev, yPrev), pointCenter});
                }
                else
                {
                    graphics.DrawPolygon(Pens.Black, new[] {new PointF(x, y), new PointF(xPrev, yPrev), pointCenter});
                }
            }
        }

        private float DegreeToRadian(float angle)
        {
            return (float) Math.PI * angle / 180.0f;
        }

        private void Interpolate(float x1, float y1, float x2, float y2, float value)
        {
            var x = x1 + (x2 - x1) * value;
            var y = y1 + (y2 - y1) * value;
        }

        private float clampValue(float betweenFirst, float betweenSecond, float betweenOriginFirst,
            float betweenOriginSecond, float value)
        {
            var position = ((value - betweenOriginFirst) / (betweenOriginSecond - betweenOriginFirst));
            return betweenFirst + (betweenSecond - betweenFirst) * position;
        }

        private void pictureBoxMain_Paint(object sender, PaintEventArgs e)
        {
            const float R = 25f;
            const float distanceBetweenHexes = 0f;
            const string testStr = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
            var useLargeAlphabet =
                testStr.Any(c => !_alphabet.Contains(c)); //если хотя бы 1 символ в обычном алфавите отсутствует
            var binarySymbolLength = 6 + (useLargeAlphabet ? 1 : 0);

            var sb = new StringBuilder(testStr.Length * binarySymbolLength);
            if (useLargeAlphabet)
            {
                foreach (var t in testStr)
                {
                    sb.Append(Convert.ToString(Array.IndexOf(_largeAlphabet, t), 2)
                        .PadLeft(binarySymbolLength, '0'));
                }
            }
            else
            {
                foreach (var t in testStr)
                {
                    sb.Append(Convert.ToString(Array.IndexOf(_alphabet, t), 2)
                        .PadLeft(binarySymbolLength, '0'));
                }
            }


            var binaryString = sb.ToString();

            var centerX = pictureBoxMain.Width / 2f;
            var centerY = pictureBoxMain.Height / 2f;
            const float centerPointRadius = 10f;
            var sqrt3 = (float) Math.Sqrt(3);
            var sqrt2 = (float) Math.Sqrt(2);

            e.Graphics.DrawLine(Pens.DarkSlateGray, centerX, 0, centerX, pictureBoxMain.Height);
            e.Graphics.DrawLine(Pens.DarkSlateGray, 0, centerY, pictureBoxMain.Width, centerY);

            var hex = 6;


            for (int i = 0; i < testStr.Length; i++)
            {
                //i - индекс текущего шестиугольника
                //i * 6 - индекс текущего бинарного символа
                var binaryPieceLength = (binaryString.Length - i * hex) > hex ? hex : (binaryString.Length - i * hex);
                var binaryPiece = new bool[binaryPieceLength];
                for (int j = i; j < binaryPieceLength + i && j < binaryString.Length; j++)
                {
                    //binaryPiece[j - i] = binaryString[j] == '1';
                    binaryPiece[j - i] = false;
                }

                //считаем по формуле pieces = 1 * 6 + 2 * 6 + 3 * 6
                //тогда pieces / 6 = 1 + 2 + 3 + 4 
                //и тогда, вычитая последовательно числа от 1 до N мы узнаем на каком слое лежит данный гексагон

                var index = i;
                var layer = 1; //вычисляем слой буквы
                for (int sub = 1; index - sub * 6 >= 0; layer++, sub++)
                {
                    index -= sub * 6;
                }

                var drawingR = layer * (sqrt3 * R + distanceBetweenHexes);
                var evenLayer = layer % 2 == 0;
                //if (!evenLayer) //для нечётного слоя
                //{
                //    drawingR *= (pieceLayer / 2 + 1) * sqrt3;
                //}
                //else
                //{
                //    drawingR *= 3 * pieceLayer / 2f;
                //}

                var angleBetweenHexagons = 60f / layer; //угол поворота между гексагонами

                var hexagonsInLayer = layer * 6; //количество гексагонов в слое

                var radianBetweenHexagons = DegreeToRadian(angleBetweenHexagons); //кол-во радиан между гексагонами

                var layerStartingRadian = evenLayer ? 0f : radianBetweenHexagons / 2f; //стартовый радиан поворота слоя

                var hexagonRadian =
                    layerStartingRadian + radianBetweenHexagons * index; //конечный радиан поворота центра гексагона

                

                //подтянуть если не pi/6 или не pi/2
                var phi = float.NaN;
                if (Math.Abs(hexagonRadian - Pi6) > 0.01f)
                {
                    phi = Pi6;
                }
                else if (Math.Abs(hexagonRadian - 5 * Pi6) > 0.01f)
                {
                    phi = 5 * Pi6;
                }
                else if (Math.Abs(hexagonRadian - 7 * Pi6) > 0.01f)
                {
                    phi = 7 * Pi6;
                }
                else if (Math.Abs(hexagonRadian - 11 * Pi6) > 0.01f)
                {
                    phi = 11 * Pi6;
                }
                else if (Math.Abs(hexagonRadian - FPi) > 0.01f)
                {
                    phi = FPi;
                }
                else if (Math.Abs(hexagonRadian - 2 * FPi) > 0.01f)
                {
                    phi = 2 * FPi;
                }
                
                if (!float.IsNaN(phi))
                {
                    var dx = (float) Math.Cos(phi);
                    var dy = (float) Math.Sin(phi);
                    drawingR *= 2 * dy;
                }
                //реальные координаты гексагона
                float hexagonX = centerX + drawingR * (float)Math.Cos(hexagonRadian);
                float hexagonY = centerY + drawingR * (float)Math.Sin(hexagonRadian);
                //рисуем шестиугольник
                drawHexagon(hexagonX, hexagonY, R, e.Graphics, binaryPiece);

                //выводим бинарную строку
                //e.Graphics.DrawString(
                //    string.Join("", binaryPiece.Select(t => t ? '1' : '0')).Substring(0, binaryPieceLength).ToUpper(),
                //    DefaultFont, Brushes.Red, hexagonX, hexagonY);
                e.Graphics.DrawString(
                    layer + ":" + index,
                    DefaultFont, Brushes.Red, hexagonX, hexagonY);

                //заполняем центр (дебаг)
                e.Graphics.FillEllipse(Brushes.Black, hexagonX - centerPointRadius / 2,
                    hexagonY - centerPointRadius / 2,
                    centerPointRadius, centerPointRadius);
            }
        }
    }
}