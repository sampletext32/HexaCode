using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HexaCode
{
    public partial class HexagonParseForm : Form
    {
        private HexagonConverter _converter;
        private Bitmap _displayingBitmap;

        private Bitmap _loadedBitmap;

        private ObjectWrapper _returnableWrapper;
        private ObjectWrapper _sendableWrapper;

        private bool _finishAtSplitColor = false;
        private bool _finishAtTrimBlack = false;
        private bool _finishAtAddBorder = false;
        private bool _finishAtGetHexagonRadius = false;

        private string _lastParsedContent = string.Empty;

        public HexagonParseForm(ObjectWrapper returnableWrapper, ObjectWrapper sendableWrapper)
        {
            InitializeComponent();
            _returnableWrapper = returnableWrapper;
            _sendableWrapper = sendableWrapper;

            var dpiGraphics = Graphics.FromHwnd(IntPtr.Zero);

            AutoScaleDimensions = new SizeF(dpiGraphics.DpiX, dpiGraphics.DpiX);

            AutoScaleMode = AutoScaleMode.Dpi;

            dpiGraphics.Dispose();
        }

        private void buttonOpenFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            var directoryInfo = new DirectoryInfo("generated");
            if (!directoryInfo.Exists)
            {
                Directory.CreateDirectory("generated");
                directoryInfo = new DirectoryInfo("generated");
            }

            openFileDialog.InitialDirectory = Application.StartupPath + "\\generated\\";

            openFileDialog.FileName = "generated" + directoryInfo.GetFiles().Length + ".jpg";
            openFileDialog.Filter = "Image Files (*.bmp, *.jpg, *.jpeg)|*.bmp;*.jpg;*.jpeg";
            openFileDialog.Title = "Save Generated Image";
            var dialogResult = openFileDialog.ShowDialog();
            if (dialogResult == DialogResult.OK)
            {
                try
                {
                    _loadedBitmap = (Bitmap) Image.FromFile(openFileDialog.FileName);
                    SetImage(_loadedBitmap);
                    MessageBox.Show("Opened Successfully");
                }
                catch (Exception)
                {
                    MessageBox.Show("Open Error");
                }
            }
        }

        private void SetImage(Bitmap bitmap)
        {
            _displayingBitmap = bitmap;
            var dx = _displayingBitmap.Width - pictureBoxMain.Width;
            var dy = _displayingBitmap.Height - pictureBoxMain.Height;
            pictureBoxMain.Width = _displayingBitmap.Width;
            pictureBoxMain.Height = _displayingBitmap.Height;
            this.Width += dx;
            this.Height += dy;
            pictureBoxMain.Refresh();
        }

        private void pictureBoxMain_Paint(object sender, PaintEventArgs e)
        {
            if (_displayingBitmap != null)
            {
                e.Graphics.DrawImage(_displayingBitmap, 0, 0, pictureBoxMain.Width, pictureBoxMain.Height);
            }
        }

        void ProcessImage()
        {
            richTextBoxLog.Clear();

            if (_loadedBitmap == null)
            {
                richTextBoxLog.AppendText("Image Is Not Loaded\n");
                Application.DoEvents();
                return;
            }

            richTextBoxLog.AppendText("Clonning Original Bitmap\n");
            Application.DoEvents();

            var b = BitmapHelper.CloneBitmap(_loadedBitmap);

            var splitCoefficient = (float) numericUpDownSplitColorCoefficient.Value / 1000f;

            richTextBoxLog.AppendText("Splitting Color\n");
            Application.DoEvents();
            b = BitmapHelper.SplitColors(b, splitCoefficient);
            if (_finishAtSplitColor) goto FINISH;

            richTextBoxLog.AppendText("Trimming To Black\n");
            Application.DoEvents();
            b = BitmapHelper.TrimToBlack(b);
            if (_finishAtTrimBlack) goto FINISH;

            richTextBoxLog.AppendText("Adding Border\n");
            Application.DoEvents();
            b = BitmapHelper.AddBorder(b, (int) numericUpDownBorderSize.Value);
            if (_finishAtAddBorder) goto FINISH;

            richTextBoxLog.AppendText("Getting Hexagon Radius\n");
            Application.DoEvents();
            var radius = HexagonConverter.GetHexagonRadiusFromImage(b, 0f);
            richTextBoxLog.AppendText("Hexagon Radius = " + radius + "\n");
            Application.DoEvents();
            if (_finishAtGetHexagonRadius) goto FINISH;

            try
            {
                var content = new HexagonConverter(radius, 0f).ParseCorrectBitmap(b);
                _lastParsedContent = content;
                richTextBoxLog.AppendText("Parsed Successfully:\n" + content + "\n");
                Application.DoEvents();
            }
            catch (Exception e)
            {
                richTextBoxLog.AppendText("Error: " + e.Message + "\n");
                Application.DoEvents();
            }


            FINISH:
            richTextBoxLog.AppendText("Finished\n");
            Application.DoEvents();
            SetImage(b);
        }

        private void buttonSplitColors_Click(object sender, EventArgs e)
        {
            _finishAtSplitColor = true;
            _finishAtTrimBlack = false;
            _finishAtAddBorder = false;
            _finishAtGetHexagonRadius = false;
            ProcessImage();
        }

        private void buttonTrimToBlack_Click(object sender, EventArgs e)
        {
            _finishAtSplitColor = false;
            _finishAtTrimBlack = true;
            _finishAtAddBorder = false;
            _finishAtGetHexagonRadius = false;
            ProcessImage();
        }

        private void buttonAddBorder_Click(object sender, EventArgs e)
        {
            _finishAtSplitColor = false;
            _finishAtTrimBlack = false;
            _finishAtAddBorder = true;
            _finishAtGetHexagonRadius = false;
            ProcessImage();
        }

        private void buttonGetHexagonRadius_Click(object sender, EventArgs e)
        {
            _finishAtSplitColor = false;
            _finishAtTrimBlack = false;
            _finishAtAddBorder = false;
            _finishAtGetHexagonRadius = true;
            ProcessImage();
        }

        private void buttonCompleteParse_Click(object sender, EventArgs e)
        {
            _finishAtSplitColor = false;
            _finishAtTrimBlack = false;
            _finishAtAddBorder = false;
            _finishAtGetHexagonRadius = false;
            ProcessImage();
        }

        private void buttonFindPart_Click(object sender, EventArgs e)
        {
            _returnableWrapper.O = _lastParsedContent;
            this.Close();
        }
    }
}