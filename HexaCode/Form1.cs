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

        private void pictureBoxMain_Paint(object sender, PaintEventArgs e)
        {
            var converter = new HexagonConverter();
            Bitmap b = converter.GenerateBitmap("{}{}");
            e.Graphics.DrawImage(b, new Point(0, 0));
            Logger.Clear();
            string s = converter.ParseBitmap(b);
            MessageBox.Show(s);
        }
    }
}