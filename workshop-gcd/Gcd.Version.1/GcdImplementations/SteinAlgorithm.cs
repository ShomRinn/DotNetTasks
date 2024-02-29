using System;

namespace Gcd.Version._1
{
    /// <summary>
    /// Calculates the GCD by the Stein algorithm.
    /// </summary>
    internal class SteinAlgorithm : Algorithm
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

            if (first == 0)
            {
                return second;
            }

            if (second == 0)
            {
                return first;
            }

            if (first < second)
            {
                int temp = first;
                first = second;
                second = temp;
            }

            int shift = 0;
            while ((first & 1) == 0 && (second & 1) == 0)
            {
                shift++;
                first >>= 1;
                second >>= 1;
            }

            while ((first & 1) == 0)
            {
                first >>= 1;
            }

            do
            {
                while ((second & 1) == 0)
                {
                    second >>= 1;
                }

                if (first > second)
                {
                    int temp = first;
                    first = second;
                    second = temp;
                }

                second = second - first;
            }
            while (second != 0);

            return first << shift;
        }
    }
}
