using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;

namespace SequencesTask
{
    /// <summary>
    /// Generator of the sequences.
    /// </summary>
    public static class SequenceGenerator
    {
        /// <summary>
        /// Generates the Fibonacci sequence.
        /// </summary>
        /// <param name="count">Sequence length.</param>
        /// <returns>The Fibonacci sequence of <paramref name="count"/> first numbers.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="count"/> is less than 1.</exception>
        public static IEnumerable<BigInteger> GetFibonacciNumbers(int count)
        {
            if (count < 1)
            {
                throw new ArgumentException("count is less than 1", nameof(count));
            }

            return GenerateFibonacciSeries();

            IEnumerable<BigInteger> GenerateFibonacciSeries()
            {
                BigInteger priorNumber = 0;
                BigInteger presentNumber = 1;

                yield return priorNumber;

                for (int i = 1; i < count; i++)
                {
                    yield return presentNumber;

                    var temp = presentNumber;
                    presentNumber += priorNumber;
                    priorNumber = temp;
                }
            }
        }

        /// <summary>
        /// Generates the sequence of prime numbers.
        /// </summary>
        /// <param name="count">Sequence length.</param>
        /// <returns>A sequence of <paramref name="count"/> first prime numbers.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="count"/> is less than 1.</exception>
        public static IEnumerable<int> GetPrimeNumbers(int count)
        {
            if (count < 1)
            {
                throw new ArgumentException("count is less than 1", nameof(count));
            }

            return EnumeratePrimes();

            IEnumerable<int> EnumeratePrimes()
            {
                int candidate = 2;
                while (count > 0)
                {
                    if (IsPrime(candidate))
                    {
                        yield return candidate;
                        count--;
                    }

                    candidate++;
                }
            }
        }

        /// <summary>
        /// Generates the sequence of prime numbers (see https://en.wikipedia.org/wiki/Sieve_of_Eratosthenes).
        /// </summary>
        /// <param name="number">Maximum number to search.</param>
        /// <returns>A sequence of all primes less or equal than <paramref name="number"/>.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="number"/> is less than 1.</exception>
        public static IEnumerable<int> GetPrimes(int number)
        {
            if (number < 1)
            {
                throw new ArgumentException("number is less than 1", nameof(number));
            }

            return EnumeratePrimes();

            IEnumerable<int> EnumeratePrimes()
            {
                int candidate = 2;
                while (candidate <= number)
                {
                    if (IsPrime(candidate))
                    {
                        yield return candidate;
                    }

                    candidate++;
                }
            }
        }

        private static bool IsPrime(int number)
        {
            if (number < 2)
            {
                return false;
            }

            for (int i = 2; i <= Math.Sqrt(number); i++)
            {
                if (number % i == 0)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
