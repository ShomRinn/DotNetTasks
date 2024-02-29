using System;

namespace Gcd.Version._2
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
            return Gcd(new EuclideanAlgorithm(), first, second);
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
            return Gcd(new EuclideanAlgorithm(), first, second, third);
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
            int[] allNumbers = new int[] { first, second }.Concat(numbers).ToArray();
            ThrowExceptionWhenMinValueOrAllZeros(allNumbers);
            return Gcd(new EuclideanAlgorithm(), allNumbers);
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
            return Gcd(new EuclideanAlgorithm(), out milliseconds, first, second);
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
            return Gcd(new EuclideanAlgorithm(), out milliseconds, first, second, third);
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
            int[] allNumbers = new int[] { first, second }.Concat(numbers).ToArray();
            ThrowExceptionWhenMinValueOrAllZeros(allNumbers);
            return Gcd(new EuclideanAlgorithm(), out milliseconds, allNumbers);
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
            return Gcd(new SteinAlgorithm(), first, second);
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
            return Gcd(new SteinAlgorithm(), first, second, third);
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
            int[] allNumbers = new int[] { first, second }.Concat(numbers).ToArray();
            ThrowExceptionWhenMinValueOrAllZeros(allNumbers);
            return Gcd(new SteinAlgorithm(), allNumbers);
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
            return Gcd(new SteinAlgorithm(), out milliseconds, first, second);
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
            return Gcd(new SteinAlgorithm(), out milliseconds, first, second, third);
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
            int[] allNumbers = new int[] { first, second }.Concat(numbers).ToArray();
            ThrowExceptionWhenMinValueOrAllZeros(allNumbers);
            return Gcd(new SteinAlgorithm(), out milliseconds, allNumbers);
        }

        private static int Gcd(IAlgorithm algorithm, params int[] numbers) => algorithm.Calculate(numbers);

        private static int Gcd(IAlgorithm algorithm, out long milliseconds, params int[] numbers) => algorithm.Calculate(out milliseconds, numbers);

        private static void ThrowExceptionWhenMinValueOrAllZeros(params int[] numbers)
        {
            int count = 0;
            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] == int.MinValue)
                {
                    throw new ArgumentOutOfRangeException($"Number cannot be {int.MinValue}.");
                }

                if (numbers[i] == 0)
                {
                    count++;
                }
            }

            if (count == numbers.Length)
            {
                throw new ArgumentException("all numbers are 0 at the same time.");
            }
        }
    }
}
