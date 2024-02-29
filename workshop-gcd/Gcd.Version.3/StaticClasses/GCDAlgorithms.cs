using System;

namespace Gcd.Version._3
{
    /// <summary>
    /// Provide methods to calculates GCD.
    /// </summary>
    public static class GcdAlgorithms
    {
        /// <summary>
        /// Calculates GCD of two integers from [-int.MaxValue;int.MaxValue] by the Euclidean algorithm.
        /// </summary>
        /// <param name="first">First integer.</param>
        /// <param name="second">Second integer.</param>
        /// <returns>The GCD value.</returns>
        /// <exception cref="ArgumentException">Thrown when all numbers are 0 at the same time.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when one or two numbers are int.MinValue.</exception>
        public static int GetGcdByEuclidean(int first, int second)
        {
            ThrowExceptionWhenMinValueOrAllZeros(first, second);
            return GcdAlgorithmsExtension.Calculate(new EuclideanAlgorithm(), first, second);
        }

        /// <summary>
        /// Calculates GCD of three integers from [-int.MaxValue;int.MaxValue] by the Euclidean algorithm.
        /// </summary>
        /// <param name="first">First integer.</param>
        /// <param name="second">Second integer.</param>
        /// <param name="third">Third integer.</param>
        /// <returns>The GCD value.</returns>
        /// <exception cref="ArgumentException">Thrown when all numbers are 0 at the same time.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when one or more numbers are int.MinValue.</exception>
        public static int GetGcdByEuclidean(int first, int second, int third)
        {
            ThrowExceptionWhenMinValueOrAllZeros(first, second, third);
            return GcdAlgorithmsExtension.Calculate(new EuclideanAlgorithm(), first, second, third);
        }

        /// <summary>
        /// Calculates the GCD of integers from [-int.MaxValue;int.MaxValue] by the Euclidean algorithm.
        /// </summary>
        /// <param name="first">First integer.</param>
        /// <param name="second">Second integer.</param>
        /// <param name="numbers">Other integers.</param>
        /// <returns>The GCD value.</returns>
        /// <exception cref="ArgumentException">Thrown when all numbers are 0 at the same time.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when one or more numbers are int.MinValue.</exception>
        public static int GetGcdByEuclidean(int first, int second, params int[] numbers)
        {
            ThrowExceptionWhenMinValueOrAllZeros(new int[] { first, second }.Concat(numbers).ToArray());
            return GcdAlgorithmsExtension.Calculate(new EuclideanAlgorithm(), new int[] { first, second }.Concat(numbers).ToArray());
        }

        /// <summary>
        /// Calculates GCD of two integers from [-int.MaxValue;int.MaxValue] by the Euclidean algorithm with milliseconds time.
        /// </summary>
        /// <param name="milliseconds">Method execution time in milliseconds.</param>
        /// <param name="first">First integer.</param>
        /// <param name="second">Second integer.</param>
        /// <returns>The GCD value.</returns>
        /// <exception cref="ArgumentException">Thrown when all numbers are 0 at the same time.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when one or two numbers are int.MinValue.</exception>
        public static int GetGcdByEuclidean(out long milliseconds, int first, int second)
        {
            ThrowExceptionWhenMinValueOrAllZeros(first, second);
            return GcdAlgorithmsExtension.Calculate(new EuclideanAlgorithm(), out milliseconds, first, second);
        }

        /// <summary>
        /// Calculates GCD of three integers from [-int.MaxValue;int.MaxValue] by the Euclidean algorithm with milliseconds time.
        /// </summary>
        /// <param name="milliseconds">Method execution time in milliseconds.</param>
        /// <param name="first">First integer.</param>
        /// <param name="second">Second integer.</param>
        /// <param name="third">Third integer.</param>
        /// <returns>The GCD value.</returns>
        /// <exception cref="ArgumentException">Thrown when all numbers are 0 at the same time.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when one or more numbers are int.MinValue.</exception>
        public static int GetGcdByEuclidean(out long milliseconds, int first, int second, int third)
        {
            ThrowExceptionWhenMinValueOrAllZeros(first, second, third);
            return GcdAlgorithmsExtension.Calculate(new EuclideanAlgorithm(), out milliseconds, first, second, third);
        }

        /// <summary>
        /// Calculates the GCD of integers from [-int.MaxValue;int.MaxValue] by the Euclidean algorithm with milliseconds time.
        /// </summary>
        /// <param name="milliseconds">Method execution time in milliseconds.</param>
        /// <param name="first">First integer.</param>
        /// <param name="second">Second integer.</param>
        /// <param name="numbers">Other integers.</param>
        /// <returns>The GCD value.</returns>
        /// <exception cref="ArgumentException">Thrown when all numbers are 0 at the same time.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when one or more numbers are int.MinValue.</exception>
        public static int GetGcdByEuclidean(out long milliseconds, int first, int second, params int[] numbers)
        {
            ThrowExceptionWhenMinValueOrAllZeros(new int[] { first, second }.Concat(numbers).ToArray());
            return GcdAlgorithmsExtension.Calculate(new EuclideanAlgorithm(), out milliseconds, new int[] { first, second }.Concat(numbers).ToArray());
        }

        /// <summary>
        /// Calculates GCD of two integers [-int.MaxValue;int.MaxValue] by the Stein algorithm.
        /// </summary>
        /// <param name="first">First integer.</param>
        /// <param name="second">Second integer.</param>
        /// <returns>The GCD value.</returns>
        /// <exception cref="ArgumentException">Thrown when all numbers are 0 at the same time.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when one or two numbers are int.MinValue.</exception>
        public static int GetGcdByStein(int first, int second)
        {
            ThrowExceptionWhenMinValueOrAllZeros(first, second);
            return GcdAlgorithmsExtension.Calculate(new SteinAlgorithm(), first, second);
        }

        /// <summary>
        /// Calculates GCD of three integers [-int.MaxValue;int.MaxValue] by the Stein algorithm.
        /// </summary>
        /// <param name="first">First integer.</param>
        /// <param name="second">Second integer.</param>
        /// <param name="third">Third integer.</param>
        /// <returns>The GCD value.</returns>
        /// <exception cref="ArgumentException">Thrown when all numbers are 0 at the same time.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when one or more numbers are int.MinValue.</exception>
        public static int GetGcdByStein(int first, int second, int third)
        {
            ThrowExceptionWhenMinValueOrAllZeros(first, second, third);
            return GcdAlgorithmsExtension.Calculate(new SteinAlgorithm(), first, second, third);
        }

        /// <summary>
        /// Calculates the GCD of integers [-int.MaxValue;int.MaxValue] by the Stein algorithm.
        /// </summary>
        /// <param name="first">First integer.</param>
        /// <param name="second">Second integer.</param>
        /// <param name="numbers">Other integers.</param>
        /// <returns>The GCD value.</returns>
        /// <exception cref="ArgumentException">Thrown when all numbers are 0 at the same time.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when one or more numbers are int.MinValue.</exception>
        public static int GetGcdByStein(int first, int second, params int[] numbers)
        {
            ThrowExceptionWhenMinValueOrAllZeros(new int[] { first, second }.Concat(numbers).ToArray());
            return GcdAlgorithmsExtension.Calculate(new SteinAlgorithm(), new int[] { first, second }.Concat(numbers).ToArray());
        }

        /// <summary>
        /// Calculates GCD of two integers from [-int.MaxValue;int.MaxValue] by the Euclidean algorithm with milliseconds time.
        /// </summary>
        /// <param name="milliseconds">Method execution time in milliseconds.</param>
        /// <param name="first">First integer.</param>
        /// <param name="second">Second integer.</param>
        /// <returns>The GCD value.</returns>
        /// <exception cref="ArgumentException">Thrown when all numbers are 0 at the same time.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when one or two numbers are int.MinValue.</exception>
        public static int GetGcdByStein(out long milliseconds, int first, int second)
        {
            ThrowExceptionWhenMinValueOrAllZeros(first, second);
            return GcdAlgorithmsExtension.Calculate(new SteinAlgorithm(), out milliseconds, first, second);
        }

        /// <summary>
        /// Calculates GCD of three integers from [-int.MaxValue;int.MaxValue] by the Euclidean algorithm with milliseconds time.
        /// </summary>
        /// <param name="milliseconds">Method execution time in milliseconds.</param>
        /// <param name="first">First integer.</param>
        /// <param name="second">Second integer.</param>
        /// <param name="third">Third integer.</param>
        /// <returns>The GCD value.</returns>
        /// <exception cref="ArgumentException">Thrown when all numbers are 0 at the same time.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when one or more numbers are int.MinValue.</exception>
        public static int GetGcdByStein(out long milliseconds, int first, int second, int third)
        {
            ThrowExceptionWhenMinValueOrAllZeros(first, second, third);
            return GcdAlgorithmsExtension.Calculate(new SteinAlgorithm(), out milliseconds, first, second, third);
        }

        /// <summary>
        /// Calculates the GCD of integers from [-int.MaxValue;int.MaxValue] by the Euclidean algorithm with milliseconds time.
        /// </summary>
        /// <param name="milliseconds">Method execution time in milliseconds.</param>
        /// <param name="first">First integer.</param>
        /// <param name="second">Second integer.</param>
        /// <param name="numbers">Other integers.</param>
        /// <returns>The GCD value.</returns>
        /// <exception cref="ArgumentException">Thrown when all numbers are 0 at the same time.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when one or more numbers are int.MinValue.</exception>
        public static int GetGcdByStein(out long milliseconds, int first, int second, params int[] numbers)
        {
            ThrowExceptionWhenMinValueOrAllZeros(new int[] { first, second }.Concat(numbers).ToArray());
            return GcdAlgorithmsExtension.Calculate(new SteinAlgorithm(), out milliseconds, new int[] { first, second }.Concat(numbers).ToArray());
        }

        private static void ThrowExceptionWhenMinValueOrAllZeros(params int[] numbers)
        {
            bool allZeros = true;

            foreach (int number in numbers)
            {
                if (number == int.MinValue)
                {
                    throw new ArgumentOutOfRangeException($"Number cannot be {int.MinValue}.");
                }

                if (number != 0)
                {
                    allZeros = false;
                }
            }

            if (allZeros)
            {
                throw new ArgumentException("All numbers are 0 at the same time.");
            }
        }
    }
}
