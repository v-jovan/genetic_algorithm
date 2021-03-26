using System;
using System.Collections.Generic;

namespace MVI_Project1_MIN
{
    class Recombination
    {

        public static double recombinationProbability = 0.85; // global recombination probability
        public static List<Chromosome> Recombine(List<Chromosome> original)
        {
            List<Chromosome> recombined = new List<Chromosome>();
            Random random = new Random();
            for (int i = 0; i < original.Count; i++)
            {
                // recombinate
                double randomProbability = Math.Round(random.NextDouble(), 4);

                if (randomProbability < recombinationProbability)
                {
                    // alternative: if you need reocombinition on both  X and Y coordinates

                    /*int recombinationPointX = random.Next(0, (original[i].binaryValue.Length) / 2);
                    int recombinationPointY = random.Next(0, (original[i].binaryValue.Length) / 2);

                    string firstX = first.Substring(0, first.Length / 2),
                           firstY = first.Substring(first.Length / 2);

                    string secondX = first.Substring(0, second.Length / 2),
                           secondY = first.Substring(second.Length / 2);

                    string recombinedFirstXBinary = firstX.Substring(0, recombinationPointX) + secondX.Substring(recombinationPointX),
                           recombinedSecondXBinary = secondX.Substring(0, recombinationPointX) + firstX.Substring(recombinationPointX);

                    string recombinedFirstYBinary = firstY.Substring(0, recombinationPointY) + secondY.Substring(recombinationPointY),
                           recombinedSecondYBinary = secondY.Substring(0, recombinationPointY) + firstY.Substring(recombinationPointY);

                    string recombinedFirstBinary = recombinedFirstXBinary + recombinedFirstYBinary,
                           recombinedSecondBinary = recombinedSecondXBinary + recombinedSecondYBinary;*/


                    int recombinationPoint = random.Next(0, original[i].binaryValue.Length);

                    string first = original[i].binaryValue;
                    string second = original[(i + 1) % original.Count].binaryValue;

                    string recombinedFirstBinary = first.Substring(0, recombinationPoint) + second.Substring(recombinationPoint);
                    string recombinedSecondBinary = second.Substring(0, recombinationPoint) + first.Substring(recombinationPoint);

                    recombined.Add(new Chromosome(recombinedFirstBinary));

                    if (recombined.Count < original.Count)
                        recombined.Add(new Chromosome(recombinedSecondBinary));

                    i++;
                }
                else
                {
                    recombined.Add(original[i]);
                }
            }

            return recombined;
        }
    }
}
