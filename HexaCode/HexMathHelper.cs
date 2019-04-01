using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexaCode
{
    class HexMathHelper
    {
        /// <summary>
        /// Функция считает суммарное количество шестиугольников до слоя, включая последний слой и центральный
        /// </summary>
        /// <param name="layer">Номер слоя, для которого производится расчёт</param>
        public static int GetLayerSumHexagonsCount(int layer)
        {
            var sum = 0;
            for (int i = 1; i <= layer; i++)
            {
                sum += i * 6;
            }

            return sum + 1;
        }

        /// <summary>
        /// Функция возвращает реальный радиус шестиугольника, используемый при отрисовке
        /// </summary>
        /// <param name="radius">Радиус шестиугольника</param>
        /// <param name="distanceBetweenHexes">Расстояние между шестиугольниками</param>
        /// <returns></returns>
        public static float GetDrawingR(float radius, float distanceBetweenHexes)
        {
            return radius + distanceBetweenHexes / 2;
        }

        /// <summary>
        /// Функция возвращает суммарную ширину картинки зная радиус и кол-во слоёв
        /// </summary>
        /// <param name="layer">Количество слоёв</param>
        /// <param name="radius">Радиус шестиугольника</param>
        /// <param name="distanceBetweenHexes">Расстояние между шестиугольниками</param>
        /// <returns></returns>
        public static float GetWidth(int layer, float radius, float distanceBetweenHexes)
        {
            return (float)Math.Ceiling(2 * GetDrawingR(radius, distanceBetweenHexes) * (1.5f * layer + 1));
        }

        /// <summary>
        /// Функция возвращает суммарную высоту картинки зная радиус и кол-во слоёв
        /// </summary>
        /// <param name="layer">Количество слоёв</param>
        /// <param name="radius">Радиус шестиугольника</param>
        /// <param name="distanceBetweenHexes">Расстояние между шестиугольниками</param>
        /// <returns></returns>
        public static float GetHeight(int layer, float radius, float distanceBetweenHexes)
        {
            return (float)Math.Ceiling((2 * layer + 1) * MathHelper.Sqrt3 * HexMathHelper.GetDrawingR(radius, distanceBetweenHexes));
        }

        /// <summary>
        /// Функция смещает точку вокруг шестиугольника, зная позицию в слое, кол-во шестиугольников в одной стороне и радиус
        /// </summary>
        /// <param name="vecX">Координата X, которую необходимо сместить</param>
        /// <param name="vecY">Координата Y, которую необходимо сместить</param>
        /// <param name="position">Позиция в слое</param>
        /// <param name="hexesInSide">Кол-во шестиугольников в одной стороне</param>
        /// <param name="drawingR">Радиус отрисовки</param>
        public static void TranslatePointAroundHexagon(ref PointF hexagonPoint, int position, int hexesInSide, float drawingR)
        {
            //начинаем в цикле сдвигаться по грани гексагона
            for (var j = 0; j <= position; j++)
            {
                for (int side = 0; side < hexesInSide - 1 && j < position; side++, j++)
                {
                    hexagonPoint.Y += MathHelper.Sqrt3 * drawingR;
                }

                for (int side = 0; side < hexesInSide - 1 && j < position; side++, j++)
                {
                    hexagonPoint.Y += drawingR * MathHelper.Sqrt3 / 2;
                    hexagonPoint.X -= 1.5f * drawingR;
                }

                for (int side = 0; side < hexesInSide - 1 && j < position; side++, j++)
                {
                    hexagonPoint.Y -= drawingR * MathHelper.Sqrt3 / 2;
                    hexagonPoint.X -= 1.5f * drawingR;
                }

                for (int side = 0; side < hexesInSide - 1 && j < position; side++, j++)
                {
                    hexagonPoint.Y -= MathHelper.Sqrt3 * drawingR;
                }

                for (int side = 0; side < hexesInSide - 1 && j < position; side++, j++)
                {
                    hexagonPoint.Y -= drawingR * MathHelper.Sqrt3 / 2;
                    hexagonPoint.X += 1.5f * drawingR;
                }

                for (int side = 0; side < hexesInSide - 1 && j < position; side++, j++)
                {
                    hexagonPoint.Y += drawingR * MathHelper.Sqrt3 / 2;
                    hexagonPoint.X += 1.5f * drawingR;
                }
            }
        }

        /// <summary>
        /// Функция вычисляет слой, на котором лежит заданный элемент
        /// </summary>
        /// <param name="itemPosition"></param>
        /// <returns></returns>
        public static void GetItemLayer(ref int itemPosition, ref int layer)
        {
            var index = itemPosition; //индекс символа в текущем слое
            var calculatedLayer = 1; //вычисляем слой буквы
            for (var sub = 1; index - sub * 6 >= 0; calculatedLayer++, sub++)
            {
                index -= sub * 6;
            }

            itemPosition = index;
            layer = calculatedLayer;
        }

        /// <summary>
        /// Функция сдвигает точку в правый верхний угол
        /// </summary>
        /// <param name="vecX"></param>
        /// <param name="vecY"></param>
        /// <param name="drawingR"></param>
        /// <param name="layer"></param>
        public static void TranlateToTopRightCorner(ref PointF hexagonPoint, float drawingR, int layer)
        {
            hexagonPoint.X += 1.5f * drawingR * layer;
            hexagonPoint.Y -= MathHelper.Sqrt3 / 2 * drawingR * layer;
        }

        /// <summary>
        /// Функция возвращает кол-во шестиугольников в одной стороне, зная слой
        /// </summary>
        /// <param name="layer">Слой</param>
        /// <returns></returns>
        public static int GetHexagonsInSide(int layer)
        {
            return layer + 1;
        }
    }
}
