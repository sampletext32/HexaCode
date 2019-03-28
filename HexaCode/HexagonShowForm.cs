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
    public partial class HexagonShowForm : Form
    {
        private HexagonConverter _converter;
        private string _displayingContent;
        private Bitmap _displayingBitmap;

        private ObjectWrapper _returnableWrapper;
        private ObjectWrapper _sendableWrapper;

        public HexagonShowForm(ObjectWrapper returnableWrapper, ObjectWrapper sendableWrapper)
        {
            InitializeComponent();
            _returnableWrapper = returnableWrapper;
            _sendableWrapper = sendableWrapper;

            var dpiGraphics = Graphics.FromHwnd(IntPtr.Zero);

            AutoScaleDimensions = new SizeF(dpiGraphics.DpiX, dpiGraphics.DpiX);

            AutoScaleMode = AutoScaleMode.Dpi;

            dpiGraphics.Dispose();

            _displayingContent = (string)sendableWrapper.O;
        }

        private void RegenerateImage()
        {
            if (_displayingContent != null)
            {
                _converter = new HexagonConverter((float) numericUpDownRadius.Value);
                var bitmap = _converter.GenerateBitmap(_displayingContent);
                SetImage(ColorConverter.AddBorder(bitmap, 10));
            }
            else
            {
                MessageBox.Show("Content Null");
            }
        }

        private void HexagonShowForm_Load(object sender, EventArgs e)
        {
            RegenerateImage();
        }

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

        private void numericUpDownRadius_ValueChanged(object sender, EventArgs e)
        {
            RegenerateImage();
        }

        private void buttonSaveToFile_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            var directoryInfo = new DirectoryInfo("generated");
            if (!directoryInfo.Exists)
            {
                Directory.CreateDirectory("generated");
                directoryInfo = new DirectoryInfo("generated");
            }

            saveFileDialog.InitialDirectory = Application.StartupPath + "\\generated\\";

            saveFileDialog.FileName = "generated" + directoryInfo.GetFiles().Length + ".jpg";
            saveFileDialog.Filter = "Image Files (*.bmp, *.jpg, *.jpeg)|*.bmp;*.jpg;*.jpeg";
            saveFileDialog.Title = "Save Generated Image";
            var dialogResult = saveFileDialog.ShowDialog();
            if (dialogResult == DialogResult.OK)
            {
                try
                {
                    _displayingBitmap.Save(saveFileDialog.FileName);
                    MessageBox.Show("Saved Successfully");
                }
                catch (Exception)
                {
                    MessageBox.Show("Save Error");
                }
            }
        }

        private void buttonGenerateFromText_Click(object sender, EventArgs e)
        {
            if (textBoxInput.TextLength > 0)
            {
                _displayingContent = textBoxInput.Text;
                RegenerateImage();
            }
        }
    }
}