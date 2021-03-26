using System.Collections.Generic;

namespace MVI_Project1_MIN
{
    class Program
    {
        static void Main(string[] args)
        {
            int populationSize = 60;          // the size of the population
            int numberOfIterations = 100;     // number of iterations
            bool elitism = true;              // elitist selection   
            bool printEveryGeneration = true; 
            bool printBestChromosome = true;  

            List<Chromosome> population = new List<Chromosome>();

            for (int i = 0; i < populationSize; i++)
            {
                population.Add(new Chromosome());
            }

            for (int iteration = 0; iteration < numberOfIterations; iteration++)
            {
                // fitness
                Fitness.Calculate(population); // calculating the value of the fitness function for each individual
                double populationFitness = Fitness.OfEntirePopulation(population); // calculating the value of the fitness function of the entire population

                // roulette
                Roulette.CalculatePi(population, populationFitness); // calculating the probability of choice
                List<double> qi = Roulette.CalculateQi(population);  // cumulative probability calculation
                List<Chromosome> newPopulation = Roulette.SelectChromosomes(qi, population, elitism); // chromosome selection and creation of a new population of the chosen ones

                // shuffling
                Roulette.Shuffle(newPopulation); // shuffling the new population

                // recombination
                newPopulation = Recombination.Recombine(newPopulation); // recombination of individuals in the new population

                // mutation
                Mutation.Mutate(newPopulation); // mutation of individuals in the new population

                // printing
                if (printEveryGeneration == true) 
                    Print.Pretty(iteration, population, qi);

                if (printBestChromosome == true)
                    Print.BestChromosomePrint(population, qi);

                population = newPopulation;
            }
        }
    }
}
