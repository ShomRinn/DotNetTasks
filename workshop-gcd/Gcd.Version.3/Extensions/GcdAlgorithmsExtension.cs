using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#pragma warning disable SA1600 // Elements should be documented

namespace Gcd.Version._3
{
    internal static class GcdAlgorithmsExtension
    {
        internal static int Calculate(IAlgorithm algorithm, params int[] numbers)
        {
            int gcd = algorithm.Calculate(numbers[0], numbers[1]);

            for (int i = 2; i < numbers.Length; i++)
            {
                gcd = algorithm.Calculate(gcd, numbers[i]);
            }

            return gcd;
        }

        internal static int Calculate(IAlgorithm algorithm, out long milliseconds, params int[] numbers)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            int gcd = Calculate(algorithm, numbers);
            stopwatch.Stop();
            milliseconds = (stopwatch.ElapsedTicks * 1000) / Stopwatch.Frequency;
            return gcd;
        }
    }
}
