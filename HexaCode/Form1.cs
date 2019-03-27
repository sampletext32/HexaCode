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

        readonly HexagonConverter _converter = new HexagonConverter();

        private void pictureBoxMain_Paint(object sender, PaintEventArgs e)
        {
            if (_displayingBitmap != null)
            {
                e.Graphics.DrawImage(_displayingBitmap, 0, 0, pictureBoxMain.Width, pictureBoxMain.Height);
            }
        }

        private Bitmap _displayingBitmap;

        private void buttonGenerate_Click(object sender, EventArgs e)
        {
            string text = textBox1.Text;
            if (text.Length == 0)
            {
                MessageBox.Show("Length 0");
                return;
            }
            _displayingBitmap = _converter.GenerateBitmap(text);
            pictureBoxMain.Width = _displayingBitmap.Width;
            pictureBoxMain.Height = _displayingBitmap.Height;
            pictureBoxMain.Refresh();
        }
    }
}