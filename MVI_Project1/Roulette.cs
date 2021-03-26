using System;
using System.Collections.Generic;
using System.Linq;

namespace MVI_Project1_MIN
{

    class Roulette
    {
        public static void CalculatePi(List<Chromosome> population, double populationFitness)
        {
            foreach (Chromosome chromosome in population)
            {
                if (populationFitness != 0.0)
                    chromosome.pi = chromosome.fitnessValue / populationFitness;
                else
                    chromosome.pi = 0.0;
            }
        }

        public static List<double> CalculateQi(List<Chromosome> population)
        {
            List<double> qi = new List<double>();

            double sum = 0.0;

            for (int i = 0; i < population.Count; i++)
            {
                sum += population[i].pi;
                qi.Add(sum);
            }

            return qi;
        }

        public static List<Chromosome> SelectChromosomes(List<double> qi, List<Chromosome> population, bool elitism)
        {
            List<Chromosome> newPopulation = new List<Chromosome>();
            double maxFitness = population.Max(p => p.fitnessValue);
            double maxQi = qi.Max<double>();

            if (elitism)
            {
                foreach (Chromosome chromosome in population)
                {
                    if (chromosome.fitnessValue == maxFitness)
                    {
                        newPopulation.Add(chromosome);
                        break;
                    }
                }
            }

            if (maxQi != 0.0)
            {
                for (int i = 0; i < population.Count; i++)
                {
                    double randomProbability = new Random().NextDouble();

                    for (int j = 0; j < qi.Count; j++)
                    {
                        if (randomProbability < qi[j])
                        {
                            newPopulation.Add(population[j]);
                            break;
                        }
                    }
                }
            }
            else
                newPopulation.AddRange(population);

            if (elitism && newPopulation.Count > population.Count)
                newPopulation.RemoveAt(newPopulation.Count - 1);

            return newPopulation;
        }

        public static List<T> Shuffle<T>(List<T> list)
        {
            Random rnd = new Random();
            for (int i = 0; i < list.Count; i++)
            {
                int k = rnd.Next(0, i);
                T value = list[k];
                list[k] = list[i];
                list[i] = value;
            }
            return list;
        }
    }
}
