using System;

#pragma warning disable CA1707 // Identifiers should not contain underscores
namespace Gcd.Version._3
{
    /// <inheritdoc/>
    internal class EuclideanAlgorithm : IAlgorithm
    {
        /// <inheritdoc/>
        /// <exception cref="ArgumentException">Thrown when all numbers are 0 at the same time.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when one or two numbers are int.MinValue.</exception>
        public int Calculate(int first, int second)
        {
            if (first == int.MinValue || second == int.MinValue)
            {
                throw new ArgumentOutOfRangeException($"{first} or {second} are int.MinValue.");
            }

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
