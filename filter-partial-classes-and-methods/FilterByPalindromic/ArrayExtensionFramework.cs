using System;
#pragma warning disable SA1601 // Partial elements should be documented

namespace FilterByPalindromic
{
    public static partial class ArrayExtension
    {
        /// <summary>
        /// Creates new array of elements that satisfy some predicate.
        /// </summary>
        /// <param name="source">Source array.</param>
        /// <returns>New array of elements that satisfy some predicate.</returns>
        /// <exception cref="ArgumentNullException">Thrown when array is null.</exception>
        /// <exception cref="ArgumentException">Thrown when array is empty.</exception>
        public static int[] FilterByPredicate(this int[]? source)
        {
            _ = source == null ? throw new ArgumentNullException(nameof(source)) : source;
            _ = source.Length == 0 ? throw new ArgumentException("array is empty.", nameof(source)) : source;

            List<int> verifiedNumbers = new List<int>();
            for (var i = 0; i < source.Length; i++)
            {
                var num = source[i];
                if (Verify(num))
                {
                    verifiedNumbers.Add(num);
                }
            }

            return verifiedNumbers.ToArray();
        }

        private static partial bool Verify(int item);
    }
}
