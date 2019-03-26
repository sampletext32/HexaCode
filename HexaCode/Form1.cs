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
            Bitmap b = new HexagonConverter().GenerateBitmap("aaa44a");
            
            e.Graphics.DrawImage(b, new Point(0, 0));
            string s = new HexagonConverter().ParseBitmap(b);
            MessageBox.Show(s);
        }
    }
}