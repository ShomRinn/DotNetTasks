using System;
#pragma warning disable CA1822

namespace Gcd.Version_4.GcdImplementations
{
    /// <summary>
    /// Calculates the GCD of integers [-int.MaxValue;int.MaxValue].
    /// </summary>
    internal class SteinAlgorithm
    {
        /// <summary>
        /// Calculates the GCD of integers [-int.MaxValue;int.MaxValue].
        /// </summary>
        /// <param name="first">first value.</param>
        /// <param name="second">second value.</param>
        /// <returns>The GCD value.</returns>
        /// <exception cref="ArgumentException">Thrown when all numbers are 0 at the same time.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when one or two numbers are int.MinValue.</exception>
        public int CalculateGcd(int first, int second)
        {
            first = Math.Abs(first);
            second = Math.Abs(second);

            if (first == 0)
            {
                return second;
            }

            if (second == 0)
            {
                return first;
            }

            if (first == second)
            {
                return first;
            }

            int shift = 0;
            while ((first % 2 == 0) && (second % 2 == 0))
            {
                shift++;
                first >>= 1;
                second >>= 1;
            }

            while (first != second && first != 0 && second != 0)
            {
                while (first % 2 == 0)
                {
                    first >>= 1;
                }

                while (second % 2 == 0)
                {
                    second >>= 1;
                }

                if (first > second)
                {
                    first -= second;
                }
                else
                {
                    second -= first;
                }
            }

            return first << shift;
        }
    }
}
