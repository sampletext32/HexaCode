using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.CV.Util;

namespace HexaCode
{
    class CodeDetector
    {
        int numof = 6;
        public Image<Gray, byte> Detect(Image<Bgr, byte> InImage)
        {
            Image<Gray, byte> ret = null;
            var image = InImage;
            try
            {
                var temp = image.SmoothGaussian(7).Convert<Gray, byte>().ThresholdAdaptive(new Gray(255), Emgu.CV.CvEnum.AdaptiveThresholdType.GaussianC, Emgu.CV.CvEnum.ThresholdType.Binary, 501, new Gray(10));

                VectorOfVectorOfPoint contours = new VectorOfVectorOfPoint();
                Mat m = new Mat();
                CvInvoke.FindContours(temp, contours, m, Emgu.CV.CvEnum.RetrType.Ccomp, Emgu.CV.CvEnum.ChainApproxMethod.ChainApproxSimple);

                double lastsize = 0;
                for (int i = 0; i < contours.Size; i++)
                {
                    double perimeter = CvInvoke.ArcLength(contours[i], true);
                    VectorOfPoint approx = new VectorOfPoint();
                    CvInvoke.ApproxPolyDP(contours[i], approx, 0.04 * perimeter, true);
                    
                    if (approx.Size == numof && contours[i].Size > lastsize)
                    {
                        lastsize = contours[i].Size;
                        //CvInvoke.DrawContours(image, contours, -1, new MCvScalar(0, 0, 255), 10);
                        var r = CvInvoke.BoundingRectangle(contours[i]);
                        temp.ROI = r;
                        var img = temp.Copy();
                        temp.ROI = Rectangle.Empty;
                        ret = img;
                    }
                }
            }
            catch (Exception ex)
            {

            }
            return ret;
        }
    }
}
