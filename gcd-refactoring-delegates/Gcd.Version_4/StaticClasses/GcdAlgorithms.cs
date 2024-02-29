using System;
using Gcd.Version_4.GcdImplementations;

namespace Gcd.Version_4.StaticClasses
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
            return new EuclideanAlgorithm().Calculate(first, second);
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
            return new Func<int, int, int>(new EuclideanAlgorithm().Calculate).FindGcdWithThreeParameters(first, second, third);
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
            return new Func<int, int, int>(new EuclideanAlgorithm().Calculate).FindGcdAlgorithm(first, second, numbers);
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
            return new Func<int, int, int>(new EuclideanAlgorithm().Calculate).FindGcdWithTimeWorkingAlgorithm(first, second, out milliseconds);
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
            return new Func<int, int, int>(new EuclideanAlgorithm().Calculate).FindGcdWithThreeParametersTimeWorkingAlgorithm(first, second, third, out milliseconds);
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
            return new Func<int, int, int>(new EuclideanAlgorithm().Calculate).FindGcdWithParamsAndTimeWorkingAlgorithm(first, second, out milliseconds, numbers);
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
            return new SteinAlgorithm().CalculateGcd(first, second);
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
            return new Func<int, int, int>(new SteinAlgorithm().CalculateGcd).FindGcdWithThreeParameters(first, second, third);
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
            return new Func<int, int, int>(new SteinAlgorithm().CalculateGcd).FindGcdAlgorithm(first, second, numbers);
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
            return new Func<int, int, int>(new SteinAlgorithm().CalculateGcd).FindGcdWithTimeWorkingAlgorithm(first, second, out milliseconds);
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
            return new Func<int, int, int>(new SteinAlgorithm().CalculateGcd).FindGcdWithThreeParametersTimeWorkingAlgorithm(first, second, third, out milliseconds);
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
            return new Func<int, int, int>(new SteinAlgorithm().CalculateGcd).FindGcdWithParamsAndTimeWorkingAlgorithm(first, second, out milliseconds, numbers);
        }

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
