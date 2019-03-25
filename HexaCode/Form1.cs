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

        private void pictureBoxMain_Paint(object sender, PaintEventArgs e)
        {
            const float R = 25f;
            string testStr = "ABC";
            var useLargeAlphabet =
                testStr.Any(c => !_alphabet.Contains(c)); //если хотя бы 1 символ в обычном алфавите отсутствует
            var binarySymbolLength = 6 + (useLargeAlphabet ? 1 : 0);

            StringBuilder sb = new StringBuilder(testStr.Length * binarySymbolLength);
            if (useLargeAlphabet)
            {
                for (int i = 0; i < testStr.Length; i++)
                {
                    sb.Append(Convert.ToString(Array.IndexOf(_largeAlphabet, testStr[i]), 2)
                        .PadLeft(binarySymbolLength, '0'));
                }
            }
            else
            {
                for (int i = 0; i < testStr.Length; i++)
                {
                    sb.Append(Convert.ToString(Array.IndexOf(_alphabet, testStr[i]), 2)
                        .PadLeft(binarySymbolLength, '0'));
                }
            }


            string binaryString = sb.ToString();

            var centerX = pictureBoxMain.Width / 2f;
            var centerY = pictureBoxMain.Height / 2f;
            var centerPointRadius = 10f;
            var sqrt3 = (float) Math.Sqrt(3);
            for (int i = 0; i < (int) Math.Ceiling(binaryString.Length / 6f); i++)
            {
                var binaryPieceLength = (binaryString.Length - i * 6) > 6 ? 6 : (binaryString.Length - i * 6);
                bool[] binaryPiece = new bool[binaryPieceLength];
                for (int j = i; j < binaryPieceLength + i && j < binaryString.Length; j++)
                {
                    binaryPiece[j - i] = binaryString[j] == '1';
                }

                int letterLayer = i / (6 * binarySymbolLength) + 1; //вычисляем слой буквы
                float drawingR = R;
                if (letterLayer % 2 == 1) //для нечётного слоя
                {
                    drawingR *= (letterLayer / 2 + 1) * sqrt3;
                }
                else
                {
                    drawingR *= 3 * letterLayer / 2f;
                }

                var hexagonX = centerX + drawingR * (float) Math.Cos(Pi3 * i - (letterLayer % 2 == 1 ? Pi6 : 0f));
                var hexagonY = centerY + drawingR * (float) Math.Sin(Pi3 * i - (letterLayer % 2 == 1 ? Pi6 : 0f));
                drawHexagon(hexagonX, hexagonY, R, e.Graphics, binaryPiece);
                e.Graphics.DrawString(
                    string.Join("", binaryPiece.Select(t => t ? '1' : '0')).Substring(0, binaryPieceLength).ToUpper(),
                    DefaultFont, Brushes.Red, hexagonX, hexagonY);
                e.Graphics.FillEllipse(Brushes.Black, hexagonX - centerPointRadius / 2,
                    hexagonY - centerPointRadius / 2,
                    centerPointRadius, centerPointRadius);
                //пробегаем 6 точек шестиугольника разметки
            }
        }
    }
}