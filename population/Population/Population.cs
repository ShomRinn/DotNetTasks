using System;

namespace PopulationTask
{
    public static class Population
    {
        /// <summary>
        /// Calculates the count of years which the town need to see its population greater or equal to currentPopulation inhabitants.
        /// </summary>
        /// <param name="initialPopulation">The population at the beginning of a year.</param>
        /// <param name="percent">The percentage of growth per year.</param>
        /// <param name="visitors">The visitors (new inhabitants per year) who come to live in the town.</param>
        /// <param name="currentPopulation">The population at present.</param>
        /// <returns>The count of years which the town need to see its population greater or equal to currentPopulation inhabitants.</returns>
        /// <exception cref="ArgumentException">
        /// Thrown when initial population is less or equals 0
        /// - or -
        /// the count of visitors cannot be less 0
        /// - or -
        /// the current population is less or equals 0
        /// - or -
        /// the current population is less than initial population.
        /// </exception>
        /// <exception cref="ArgumentOutOfRangeException">Throw if the value of percents is less then 0% or more then 100%.</exception>
        public static int GetYears(int initialPopulation, double percent, int visitors, int currentPopulation)
        {
            int years = 0;
            if (initialPopulation <= 0)
            {
                throw new ArgumentException("initial population is less or equals 0");
            }
            else if (visitors < 0)
            {
                throw new ArgumentException("the count of visitors cannot be less 0");
            }
            else if (currentPopulation <= 0)
            {
                throw new ArgumentException("the current population is less or equals 0");
            }
            else if (currentPopulation < initialPopulation)
            {
                throw new ArgumentException("the current population is less than initial population");
            }
            else if (percent < 0 || percent > 100)
            {
                throw new ArgumentOutOfRangeException($"value of {percent} is less then 0% or more then 100%");
            }
            else
            {
                percent = (percent / 100) + 1;
                while (initialPopulation < currentPopulation)
                {
                    initialPopulation = (int)(initialPopulation * percent) + visitors;
                    years++;
                }

                return years;
            }
        }
    }
}
