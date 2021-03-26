namespace MVI_Project1_MIN.Coordinates
{
    class Coordinate
    {
        public double realValue;   // real value of the coordinate
        public int sectionNumber;  // the number of the section
        public string binaryValue; // binary representation of the value
        public static int p = 2;   // precision

        public string AppendWithZeros(string binaryCode, long n) // padding with 0's
        {
            string zeroString = "";
            int difference = (int)(n - binaryCode.Length);
            for (int i = 0; i < difference; i++)
                zeroString += "0";
            return (zeroString + binaryCode);
        }
    }
}
