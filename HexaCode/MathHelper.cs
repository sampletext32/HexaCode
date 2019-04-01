using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexaCode
{
    public class MathHelper
    {
        public static readonly float FPi = (float)Math.PI;
        public static readonly float Pi2 = (float)Math.PI / 2;
        public static readonly float Pi3 = (float)Math.PI / 3;
        public static readonly float Pi6 = (float)Math.PI / 6;

        public static readonly float Sqrt3 = (float)Math.Sqrt(3);
        public static readonly float Sqrt2 = (float)Math.Sqrt(2);

        public static List<PointF> GetPixelsFromCenter(PointF centerPoint, float drawingR)
        {
            var list = new List<PointF>();
            var dy = Sqrt3 / 2 * drawingR / 2;
            list.Add(new PointF(centerPoint.X + drawingR / 2, centerPoint.Y + dy));
            list.Add(new PointF(centerPoint.X, centerPoint.Y + dy));
            list.Add(new PointF(centerPoint.X - drawingR / 2, centerPoint.Y + dy));
            list.Add(new PointF(centerPoint.X - drawingR / 2, centerPoint.Y - dy));
            list.Add(new PointF(centerPoint.X, centerPoint.Y - dy));
            list.Add(new PointF(centerPoint.X + drawingR / 2, centerPoint.Y - dy));
            return list;
        }

        public static List<PointF> ListHexagonPoints(PointF center, float radius)
        {
            var points = new List<PointF>(6);
            for (int i = 0; i <= 5; i++)
            {
                points.Add(new PointF(center.X + radius * (float)Math.Cos(MathHelper.Pi3 * i),
                    center.Y + radius * (float)Math.Sin(MathHelper.Pi3 * i)));
            }

            return points;
        }

        public static List<Tuple<PointF, PointF, PointF>> ListHexagonTriangles(List<PointF> points, PointF center)
        {
            var list = new List<Tuple<PointF, PointF, PointF>>(6);
            for (int i = 0; i < 5; i++)
            {
                list.Add(new Tuple<PointF, PointF, PointF>(points[i], points[i + 1], center));
            }

            list.Add(new Tuple<PointF, PointF, PointF>(points[5], points[0], center));
            return list;
        }
    }
}
