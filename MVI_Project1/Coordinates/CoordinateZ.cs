using System;

namespace MVI_Project1_MIN.Coordinates
{
    class CoordinateZ
    {
        public double realValue;

        public CoordinateZ(CoordinateX x, CoordinateY y)
        {
            double xValue = Math.Round(x.realValue, 4);
            double yValue = Math.Round(y.realValue, 4);

            this.realValue = Math.Round(3 * Math.Pow(1 - xValue, 2) * Math.Exp(-(xValue * xValue + Math.Pow(yValue + 1, 2)))
                        - 7 * (xValue / 5 - Math.Pow(xValue, 3) - Math.Pow(yValue, 5)) * Math.Exp(-(xValue * xValue + yValue * yValue)) 
                        - (1 / 3) * Math.Exp(-(Math.Pow(xValue + 2, 2) + yValue * yValue)), 4); // zadana funkcija
        }

        public CoordinateZ(Chromosome xy)
        {
            double xValue = Math.Round(xy.x.realValue, 4);
            double yValue = Math.Round(xy.y.realValue, 4);

            this.realValue = Math.Round(3 * Math.Pow(1 - xValue, 2) * Math.Exp(-(xValue * xValue + Math.Pow(yValue + 1, 2)))
                        - 7 * (xValue / 5 - Math.Pow(xValue, 3) - Math.Pow(yValue, 5)) * Math.Exp(-(xValue * xValue + yValue * yValue))
                        - (1 / 3) * Math.Exp(-(Math.Pow(xValue + 2, 2) + yValue * yValue)), 4); // zadana funkcija
        }

        public override string ToString()
        {
            return realValue.ToString();
        }
    }
}
