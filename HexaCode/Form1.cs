using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
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

        readonly HexagonConverter _converter = new HexagonConverter(45);

        private Bitmap _displayingBitmap;

        private void pictureBoxMain_Paint(object sender, PaintEventArgs e)
        {
            if (_displayingBitmap != null)
            {
                e.Graphics.DrawImage(_displayingBitmap, 0, 0, pictureBoxMain.Width, pictureBoxMain.Height);
            }
        }

        private void SetImage(Bitmap bitmap)
        {
            _displayingBitmap = bitmap;
            pictureBoxMain.Width = _displayingBitmap.Width;
            pictureBoxMain.Height = _displayingBitmap.Height;
            pictureBoxMain.Refresh();
        }

        private void buttonGenerate_Click(object sender, EventArgs e)
        {
            string text = textBox1.Text;
            try
            {
                var bitmap = _converter.GenerateBitmap(text);
                SetImage(ColorConverter.AddBorder(bitmap, 10));
                //bitmap.Save("generated.jpg");
            }
            catch (IndexOutOfRangeException indexOutOfRangeException)
            {
                MessageBox.Show(indexOutOfRangeException.Message);
            }
        }

        private void buttonParse_Click(object sender, EventArgs e)
        {
            
            try
            {
                //var b = (Bitmap) Image.FromFile("image.jpg");
                var b = _converter.GenerateBitmap(textBox1.Text);

                this.Text = "Finished Reading Image";
                Application.DoEvents();

                b = ColorConverter.SplitColors(b, 0.7f);

                this.Text = "Finished Spliting Colors";
                Application.DoEvents();

                b = ColorConverter.TrimToBlack(b);

                this.Text = "Finished Trimming To Black";
                Application.DoEvents();

                b = ColorConverter.AddBorder(b, 3);

                this.Text = "Finished Adding Border";
                Application.DoEvents();

                var radius = HexagonConverter.GetHexagonRadiusFromImage(b, 0f);

                this.Text = "Finished Getting Radius";
                Application.DoEvents();

                try
                {
                    var converter = new HexagonConverter(radius);
                    var parsedData = converter.ParseCorrectBitmap(b);
                    textBox2.Text = parsedData;
                    this.Text = "Finished Parsing";
                    Application.DoEvents();
                }
                catch (IndexOutOfRangeException exception)
                {
                    this.Text = "Error parsing Image: " + exception.Message;
                    Application.DoEvents();
                }

                SetImage(b);
            }
            catch (IndexOutOfRangeException exception)
            {
                
            }
        }
    }
}