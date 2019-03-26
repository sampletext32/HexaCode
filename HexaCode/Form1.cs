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

        private readonly float _sqrt3 = (float) Math.Sqrt(3);
        private readonly float _sqrt2 = (float) Math.Sqrt(2);
        private const float FPi = (float) Math.PI;
        private const float Pi2 = (float) Math.PI / 2;
        private const float Pi3 = (float) Math.PI / 3;
        private const float Pi6 = (float) Math.PI / 6;

        private static void DrawHexagon(float xCenter, float yCenter, float radius, Graphics graphics, bool[] binary)
        {
            var pointCenter = new PointF(xCenter, yCenter);
            for (var i = 0; i <= 5; i++)
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

        private string ToBinaryString(int value, int strLength)
        {
            return Convert.ToString(value, 2).PadLeft(strLength, '0');
        }

        private void pictureBoxMain_Paint(object sender, PaintEventArgs e)
        {
            //Константы
            const float R = 25f; //Радиус описанной вокруг гексагона окружности
            const float distanceBetweenHexes = 25f; //Расстояние между ячейками
            const float drawingR = R + distanceBetweenHexes / 2; //Размер рисуемой ячейки
            const string originText = "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA";

            //если хотя бы 1 символ в обычном алфавите отсутствует
            var useLargeAlphabet = originText.Any(c => !_alphabet.Contains(c));

            //длина бинарного символа (кол-во бит на символ)
            var binarySymbolLength = 6 + (useLargeAlphabet ? 1 : 0);

            var sb = new StringBuilder(originText.Length * binarySymbolLength);
            var arr = useLargeAlphabet ? _largeAlphabet : _alphabet;
            foreach (var t in originText)
            {
                sb.Append(ToBinaryString(Array.IndexOf(arr, t), binarySymbolLength));
            }

            var binaryString = sb.ToString();

            var centerX = pictureBoxMain.Width / 2f;
            var centerY = pictureBoxMain.Height / 2f;
            const float centerPointRadius = 10f;


            e.Graphics.DrawLine(Pens.DarkSlateGray, centerX, 0, centerX, pictureBoxMain.Height);
            e.Graphics.DrawLine(Pens.DarkSlateGray, 0, centerY, pictureBoxMain.Width, centerY);


            for (var i = 0; i < originText.Length; i++)
            {
                //i - индекс текущего шестиугольника
                //i * 6 - индекс текущего бинарного символа
                //binaryPieceLength - кол-во кусочков в выделяемом гексагоне
                var binaryPieceLength = (binaryString.Length - i * binarySymbolLength) > binarySymbolLength
                    ? binarySymbolLength
                    : (binaryString.Length - i * binarySymbolLength);
                var binaryPiece = new bool[binaryPieceLength];
                for (var j = 0; j < binaryPieceLength && j < binaryString.Length; j++)
                {
                    binaryPiece[j] = binaryString[i * 6 + j] == '1';
                    //binaryPiece[j - i] = false;
                }

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
                float hexagonX = vecX;
                float hexagonY = vecY;
                //рисуем гексагон
                DrawHexagon(hexagonX, hexagonY, R, e.Graphics, binaryPiece);

                var binDump = string.Join("", binaryPiece.Select(t => t ? '1' : '0')).Substring(0, binaryPieceLength)
                    .ToUpper();
                var textSize = e.Graphics.MeasureString(binDump, DefaultFont);
                //выводим бинарную строку
                e.Graphics.DrawString(binDump, DefaultFont, Brushes.Red, hexagonX - textSize.Width / 2,
                    hexagonY - textSize.Height / 2);

                //заполняем центр (дебаг)
                e.Graphics.FillEllipse(Brushes.Black, hexagonX - centerPointRadius / 2,
                    hexagonY - centerPointRadius / 2,
                    centerPointRadius, centerPointRadius);
            }
        }
    }
}