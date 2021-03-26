using System;
using System.Collections.Generic;
using System.Text;

namespace MVI_Project1_MIN
{
    class Mutation
    {
        public static double mutationProbability = 0.15; // global mutation probability
        public static void Mutate(List<Chromosome> original)
        {
            if (mutationProbability == 1.0)
            {
                for (int i = 0; i < original.Count; i++)
                {
                    original[i] = new Chromosome();
                }
            }
            else
            {
                Random random = new Random();
                for (int i = 0; i < original.Count; i++)
                {
                    double randomProbability = Math.Round(random.NextDouble(), 4);

                    if (randomProbability < mutationProbability)
                    {
                        int mutationPoint = random.Next(original[i].binaryValue.Length);

                        StringBuilder sb = new StringBuilder(original[i].binaryValue);
                        if (sb[mutationPoint] == '1')
                            sb[mutationPoint] = '0';
                        else
                            sb[mutationPoint] = '1';

                        original[i] = new Chromosome(sb.ToString());
                    }
                }
            }
        }
    }
}
