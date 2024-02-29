using System;

#pragma warning disable CA1707 // Identifiers should not contain underscores
namespace Gcd.Version._2
{
    /// <inheritdoc/>
    internal class SteinAlgorithm : IAlgorithm
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
            if (first == 0)
            {
                return second;
            }

            if (second == 0)
            {
                return first;
            }

            int shift = 0;
            while ((first & 1) == 0 && (second & 1) == 0)
            {
                shift++;
                first >>= 1;
                second >>= 1;
            }

            while (first != second && first != 0 && second != 0)
            {
                while ((first & 1) == 0)
                {
                    first >>= 1;
                }

                while ((second & 1) == 0)
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
