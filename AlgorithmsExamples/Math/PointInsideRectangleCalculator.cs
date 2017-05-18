using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmsExamples
{
    /// <summary>
    /// https://math.stackexchange.com/questions/190111/how-to-check-if-a-point-is-inside-a-rectangle
    /// http://www.mathopenref.com/heronsformula.html
    /// http://www.mathwarehouse.com/algebra/distance_formula/index.php
    /// </summary>
    public class PointInsideRectangleCalculator
    {
        private Point _A;
        private Point _B;
        private Point _C;
        private Point _D;

        public PointInsideRectangleCalculator(Point A, Point B, Point C, Point D)
        {
            _A = A;
            _B = B;
            _C = C;
            _D = D;
        }

        public string IsWithinRectangle(Point givenPoint)
        {
            double rectangleArea = GetRectangleArea();
            double t1Area = CalculateTriagleArea(_A, _B, givenPoint);
            double t2Area = CalculateTriagleArea(_B, _C, givenPoint);
            double t3Area = CalculateTriagleArea(_C, _D, givenPoint);
            double t4Area = CalculateTriagleArea(_A, _D, givenPoint);

            double totalTriangleArea = t1Area + t2Area + t3Area + t4Area;
            if (Math.Round(totalTriangleArea, 2) > rectangleArea)
            {
                return "Outside rectangle";
            }
            else
            {
                if (t1Area <= 0 || t2Area <= 0 || t3Area <= 0 || t4Area <= 0)
                {
                    return "On rectangle";
                }
                return "Inside rectangle";
            }
            
        }

        private double GetRectangleArea()
        {
            double distanceAB = GetDistance(_A, _B);
            double distanceAD = GetDistance(_A, _D);
            return distanceAB * distanceAD;
        }

        private double CalculateTriagleArea(Point p1, Point p2, Point givenPoint)
        {
            double distanceP1ToGivenPoint = GetDistance(p1, givenPoint);
            double distanceP2ToGivenPoint = GetDistance(p2, givenPoint);
            double distanceP1ToP2 = GetDistance(p1, p2);
            double p = (distanceP1ToGivenPoint + distanceP2ToGivenPoint + distanceP1ToP2) / 2; //p = halfPerimeter

            return Math.Sqrt(p * (p - distanceP1ToGivenPoint) * (p - distanceP2ToGivenPoint) * (p - distanceP1ToP2));
        }

        private double GetDistance(Point p1, Point p2)
        {
            return Math.Sqrt(Math.Pow(p2.X - p1.X, 2) + Math.Pow(p2.Y - p1.Y, 2));
        }
    }

    public class Point
    {
        public Point(double x, double y)
        {
            X = x;
            Y = y;
        }
        public double X { get; set; }
        public double Y { get; set; }
    }
    
}
