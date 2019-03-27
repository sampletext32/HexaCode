using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.Structure;

namespace HexaCode
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        readonly HexagonConverter _converter = new HexagonConverter();

        private void pictureBoxMain_Paint(object sender, PaintEventArgs e)
        {
            if (_displayingBitmap != null)
            {
                e.Graphics.DrawImage(_displayingBitmap, 0, 0, pictureBoxMain.Width, pictureBoxMain.Height);
            }

            //e.Graphics.DrawRectangle(Pens.Red, minBlackX, minBlackY, maxBlackX - minBlackX, maxBlackY - minBlackY);
        }

        private Bitmap _displayingBitmap;

        private void buttonGenerate_Click(object sender, EventArgs e)
        {
            string text = textBox1.Text;
            try
            {
                _displayingBitmap = ImageBorderAdder.AddBorder(_converter.GenerateBitmap(text), 10);
                pictureBoxMain.Width = _displayingBitmap.Width;
                pictureBoxMain.Height = _displayingBitmap.Height;
                pictureBoxMain.Refresh();
            }
            catch (IndexOutOfRangeException indexOutOfRangeException)
            {
                MessageBox.Show(indexOutOfRangeException.Message);
            }
        }

        private void buttonParse_Click(object sender, EventArgs e)
        {
            Bitmap b = _displayingBitmap;
            Image<Bgr, byte> img = new Image<Bgr, byte>(b);
            var codeDetector = new CodeDetector();
            var detectedImage = codeDetector.Detect(img);
            var detectedBitmap = detectedImage.Bitmap;
            _displayingBitmap = detectedBitmap;
            var parsedData = _converter.ParseCorrectBitmap(_displayingBitmap);
            textBox2.Text = parsedData;
        }

        int minBlackX = 0;
        int minBlackY = 0;

        int maxBlackX = 0;
        int maxBlackY = 0;

        Bitmap ProcessImageFile(string fileName)
        {
            Bitmap bitmap = (Bitmap)Image.FromFile(fileName);
            
            minBlackX = bitmap.Width;
            minBlackY = bitmap.Height;

            maxBlackX = 0;
            maxBlackY = 0;

            for (int i = 0; i < bitmap.Width; i++)
            {
                for (int j = bitmap.Height - 1; j >= 0; j--)
                {
                    var pixel = bitmap.GetPixel(i, j);
                    if (pixel.GetBrightness() > 0.7f)
                    {
                        bitmap.SetPixel(i, j, Color.White);
                    }
                    else
                    {
                        bitmap.SetPixel(i, j, Color.Black);
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

            Bitmap trimmedBitmap = new Bitmap(maxBlackX - minBlackX, maxBlackY - minBlackY);

            for (int i = 0; i < maxBlackX - minBlackX; i++)
            {
                for (int j = 0; j < maxBlackY - minBlackY; j++)
                {
                    trimmedBitmap.SetPixel(i, j, _displayingBitmap.GetPixel(minBlackX + i, minBlackY + j));
                }
            }

            bitmap = trimmedBitmap;
            return bitmap;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Bitmap bitmap = ProcessImageFile("image.jpg");
            //bitmap.Save("imageconverted.jpg", ImageFormat.Jpeg);

            Bitmap bitmap = _converter.GenerateBitmap(textBox1.Text);

            for (int i = 0; i < bitmap.Width; i++)
            {
                for (int j = bitmap.Height - 1; j >= 0; j--)
                {
                    var pixel = bitmap.GetPixel(i, j);
                    if (pixel.GetBrightness() > 0.7f)
                    {
                        bitmap.SetPixel(i, j, Color.White);
                    }
                    else
                    {
                        bitmap.SetPixel(i, j, Color.Black);
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

            bitmap = ImageBorderAdder.AddBorder(bitmap, 10);
            _displayingBitmap = bitmap;

            pictureBoxMain.Refresh();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            pictureBoxMain.Refresh();
        }
    }
}