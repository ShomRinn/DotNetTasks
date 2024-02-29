using System;
using System.Diagnostics;

namespace Gcd.Version._1
{
    /// <summary>
    /// Provide methods to calculates GCD.
    /// </summary>
    internal abstract class Algorithm
    {
        /// <summary>
        /// Calculates GCD of two integers from [-int.MaxValue;int.MaxValue].
        /// </summary>
        /// <param name="first">First integer.</param>
        /// <param name="second">Second integer.</param>
        /// <returns>The GCD value.</returns>
        /// <exception cref="ArgumentException">Thrown when all numbers are 0 at the same time.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when one or two numbers are int.MinValue.</exception>
        public int Calculate(int first, int second)
        {
            return this.Func(first, second);
        }

        /// <summary>
        /// Calculates GCD of two integers from [-int.MaxValue;int.MaxValue].
        /// </summary>
        /// <param name="first">First integer.</param>
        /// <param name="second">Second integer.</param>
        /// <param name="milliseconds">Method execution time in milliseconds.</param
        /// <returns>The GCD value.</returns>
        /// <exception cref="ArgumentException">Thrown when all numbers are 0 at the same time.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when one or two numbers are int.MinValue.</exception>
        public int Calculate(int first, int second, out long milliseconds)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            int answer = this.Func(first, second);
            stopwatch.Stop();
            milliseconds = stopwatch.ElapsedMilliseconds;
            return answer;
        }

        /// <summary>
        /// Calculates the GCD of integers.
        /// </summary>
        /// <param name="first">First integer.</param>
        /// <param name="second">Second integer.</param>
        /// <returns>The GCD value.</returns>
        protected abstract int Func(int first, int second);
    }
}
