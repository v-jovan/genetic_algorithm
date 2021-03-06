using System;

namespace MVI_Project1_MIN.Coordinates
{
    class CoordinateY : Coordinate
    {
        public static int Gg = 4;  // upper limit of the interval
        public static int Gd = -4; // lower interval limit

        public static long n = (long)(Math.Ceiling(Math.Log2((Gg - Gd) * Math.Pow(10, p) + 1))); // potreban broj bita za reprezentaciju

        public CoordinateY()
        {
            realValue = Math.Round((new Random().NextDouble()) * 8 - 4, 4);
            sectionNumber = (int)(Math.Floor((realValue - Gd) / (Gg - Gd) * (Math.Pow(2, n) - 1)));
            binaryValue = AppendWithZeros(Convert.ToString(sectionNumber, 2), n);
        }

        public CoordinateY(double realValue)
        {
            this.realValue = realValue;
            sectionNumber = (int)(Math.Floor((realValue - Gd) / (Gg - Gd) * (Math.Pow(2, n) - 1)));
            binaryValue = AppendWithZeros(Convert.ToString(sectionNumber, 2), n);
        }

        public CoordinateY(string binaryValue)
        {
            this.binaryValue = binaryValue;
            this.realValue = Math.Round(Decode(Convert.ToInt32(binaryValue, 2)), 4);
            sectionNumber = (int)(Math.Floor((realValue - Gd) / (Gg - Gd) * (Math.Pow(2, n) - 1)));
        }

        public override string ToString()
        {
            return this.realValue + "(" + this.binaryValue + ")";
        }

        public static double Decode(int bd)
        {
            return Gd + ((Gg - Gd) / (Math.Pow(2, n) - 1) * bd);
        }
    }
}
