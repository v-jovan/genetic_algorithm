using MVI_Project1_MIN.Coordinates;

namespace MVI_Project1_MIN
{
    class Chromosome
    {
        public CoordinateX x;
        public CoordinateY y; 
        public string binaryValue; // binary representation of the chromosome
        public double fitnessValue; // fitness function value
        public double pi; // probability of choice

        public Chromosome()
        {
            x = new CoordinateX();
            y = new CoordinateY();
            binaryValue = x.binaryValue + y.binaryValue;
        }

        public Chromosome(CoordinateX x, CoordinateY y)
        {
            this.x = x;
            this.y = y;
            binaryValue = x.binaryValue + y.binaryValue;
        }
        public Chromosome(string binary)
        {
            x = new CoordinateX(binary.Substring(0, (binary.Length) / 2));
            y = new CoordinateY(binary.Substring((binary.Length) / 2));
            binaryValue = x.binaryValue + y.binaryValue;
        }

        public override string ToString()
        {
            return "(" + x.realValue + "," + y.realValue + ")(" + binaryValue + ") " + new CoordinateZ(this);
        }
    }
}
