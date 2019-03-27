using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
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

        readonly HexagonConverter _converter = new HexagonConverter(45);

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
            //Bitmap b = _displayingBitmap;
            //Image<Bgr, byte> img = new Image<Bgr, byte>(b);
            //var codeDetector = new CodeDetector();
            //var detectedImage = codeDetector.Detect(img);
            //var detectedBitmap = detectedImage.Bitmap;
            //_displayingBitmap = detectedBitmap;
            
            var b = ColorConverter.SplitColors(_displayingBitmap, 0.7f);

            b = ColorConverter.TrimToBlack(b);

            b = ImageBorderAdder.AddBorder(b, 3);

            var radius = HexagonConverter.GetHexagonRadiusFromImage(b, 0f);
            
            var converter = new HexagonConverter(radius, 0f);

            var logLines = Logger.GetLog().Split('\n');
            Array.Reverse(logLines);
            File.WriteAllText("log1.txt", string.Join("\n", logLines));
            Logger.Clear();
            var parsedData = converter.ParseCorrectBitmap(b);
            _displayingBitmap = b;
            pictureBoxMain.Refresh();
            
            File.WriteAllText("log2.txt", Logger.GetLog());
            textBox2.Text = parsedData;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Bitmap bitmap = _converter.GenerateBitmap(textBox1.Text);
            

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