using MVI_Project1_MIN.Coordinates;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MVI_Project1_MIN
{
    class Print
    {
        public static void Pretty(int iteration, List<Chromosome> population, List<double> qi)
        {
            Console.WriteLine();
            Console.WriteLine("  Broj iteracije: " + (iteration + 1));
            Console.WriteLine("  ----------------------------------------------------------");
            Console.WriteLine("     i      x        y     z(x,y)    ff(x)      p        q  ");
            Console.WriteLine("  ----------------------------------------------------------");

            for (int i = 0; i < population.Count; i++)
            {
                Console.Write($" {i + 1,5}");
                Console.Write($"  {population[i].x.realValue,7:N4}");
                Console.Write($"  {population[i].y.realValue,7:N4}");
                Console.Write($"  {new CoordinateZ(population[i]).realValue,7:N4}");
                Console.Write($"  {population[i].fitnessValue,7:N4}");
                Console.Write($"  {population[i].pi,7:N4}");
                Console.Write($"  {qi[i],7:N4}");
                Console.WriteLine();
            }

            Console.WriteLine();
            Console.WriteLine();

        }

        public static void BestChromosomePrint(List<Chromosome> population, List<double> qi)
        {
            Console.WriteLine("  Najbolja jedinka u populaciji je: ");
            Console.WriteLine("  ----------------------------------------------------------");
            Console.WriteLine("     i      x        y     z(x,y)    ff(x)      p        q  ");
            Console.WriteLine("  ----------------------------------------------------------");

            double maxFit = population.Max(p => p.fitnessValue);

            for (int i = 0; i < population.Count; i++)
            {
                if (population[i].fitnessValue == maxFit)
                {
                    Console.Write($" {i + 1,5}");
                    Console.Write($"  {population[i].x.realValue,7:N4}");
                    Console.Write($"  {population[i].y.realValue,7:N4}");
                    Console.Write($"  {new CoordinateZ(population[i]).realValue,7:N4}");
                    Console.Write($"  {population[i].fitnessValue,7:N4}");
                    Console.Write($"  {population[i].pi,7:N4}");
                    Console.Write($"  {qi[i],7:N4}");
                    Console.WriteLine();
                    break;
                }
            }

            Console.WriteLine();
            Console.WriteLine();
        }
    }
}
