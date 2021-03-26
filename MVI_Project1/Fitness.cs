using MVI_Project1_MIN.Coordinates;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MVI_Project1_MIN
{
    class Fitness
    {
        private static List<CoordinateZ> GenerateZs(List<Chromosome> chromosomes)
        {
            List<CoordinateZ> coordinateZs = new List<CoordinateZ>();

            foreach (Chromosome chromosome in chromosomes)
            {
                coordinateZs.Add(new CoordinateZ(chromosome));
            }

            return coordinateZs;

        }

        public static void Calculate(List<Chromosome> chromosomes)
        {
            List<CoordinateZ> coordinateZs = GenerateZs(chromosomes);

            double max = coordinateZs.Max(z => z.realValue);

            for (int i = 0; i < chromosomes.Count; i++)
            {
                chromosomes[i].fitnessValue = max - coordinateZs[i].realValue;  // fitnes funkcija za minimum
            }
        }

        public static double OfEntirePopulation(List<Chromosome> population)
        {
            return population.Sum(p => p.fitnessValue);
        }
    }
}
