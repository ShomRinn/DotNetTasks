using System;

#pragma warning disable CA1707 // Identifiers should not contain underscores
namespace Gcd.Version._1
{
    /// <summary>
    /// Calculates the GCD by the Euclidean algorithm.
    /// </summary>
    internal class EuclideanAlgorithm : Algorithm
    {
        /// <summary>
        /// Calculates the GCD of integers [-int.MaxValue;int.MaxValue] by the Stein algorithm.
        /// </summary>
        /// <param name="first">First integer.</param>
        /// <param name="second">Second integer.</param>
        /// <returns>The GCD value.</returns>
        protected override int Func(int first, int second)
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
