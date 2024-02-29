using System;
#pragma warning disable CA1822

namespace Gcd.Version_4.GcdImplementations
{
    /// <summary>
    /// Calculates the GCD of integers [-int.MaxValue;int.MaxValue].
    /// </summary>
    internal class EuclideanAlgorithm
    {
        /// <summary>
        /// Calculates the GCD of integers [-int.MaxValue;int.MaxValue].
        /// </summary>
        /// <param name="first">first value.</param>
        /// <param name="second">second value.</param>
        /// <returns>The GCD value.</returns>
        /// <exception cref="ArgumentException">Thrown when all numbers are 0 at the same time.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when one or two numbers are int.MinValue.</exception>
        public int Calculate(int first, int second)
        {
            first = Math.Abs(first);
            second = Math.Abs(second);

            while (first != 0 && second != 0)
            {
                if (first > second)
                {
                    first %= second;
                }
                else
                {
                    second %= first;
                }
            }

            return first + second;
        }
    }
}
