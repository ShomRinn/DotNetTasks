using System;
using System.Reflection;

namespace LookingForArrayElements
{
    public static class DecimalCounter
    {
        /// <summary>
        /// Searches an array of decimals for elements that are in a specified range, and returns the number of occurrences of the elements that matches the range criteria.
        /// </summary>
        /// <param name="arrayToSearch">One-dimensional, zero-based <see cref="Array"/> of single-precision floating-point numbers.</param>
        /// <param name="ranges">One-dimensional, zero-based <see cref="Array"/> of range arrays.</param>
        /// <returns>The number of occurrences of the <see cref="Array"/> elements that match the range criteria.</returns>
        public static int GetDecimalsCount(decimal[]? arrayToSearch, decimal[]?[]? ranges)
        {
            if (arrayToSearch == null || ranges == null)
            {
                throw new ArgumentNullException($"{arrayToSearch} or {ranges} is null");
            }

            CheckRanges(ranges!, 0);

            if (arrayToSearch.Length == 0 || ranges.Length == 0)
            {
                return 0;
            }

            int elemCount = 0;
            int j = 0, k = 0;
            do
            {
                elemCount += CheckElement(arrayToSearch[j], ranges!, k);
                k = 0;
                j++;
            }
            while (j < arrayToSearch.Length);

            return elemCount;
        }

        /// <summary>
        /// Searches an array of decimals for elements that are in a specified range, and returns the number of occurrences of the elements that matches the range criteria.
        /// </summary>
        /// <param name="arrayToSearch">One-dimensional, zero-based <see cref="Array"/> of single-precision floating-point numbers.</param>
        /// <param name="ranges">One-dimensional, zero-based <see cref="Array"/> of range arrays.</param>
        /// <param name="startIndex">The zero-based starting index of the search.</param>
        /// <param name="count">The number of elements in the section to search.</param>
        /// <returns>The number of occurrences of the <see cref="Array"/> elements that match the range criteria.</returns>
        public static int GetDecimalsCount(decimal[]? arrayToSearch, decimal[]?[]? ranges, int startIndex, int count)
        {
            if (arrayToSearch == null || ranges == null)
            {
                throw new ArgumentNullException($"{arrayToSearch} or {ranges} is null");
            }

            CheckRanges(ranges!, 0);

            if (ranges.Length == 0)
            {
                return 0;
            }

            if (count < 0)
            {
                throw new ArgumentOutOfRangeException($"{count} is less than zero");
            }

            if (startIndex < 0)
            {
                throw new ArgumentOutOfRangeException($"{startIndex} is less than zero");
            }

            if (count + startIndex > arrayToSearch.Length)
            {
                throw new ArgumentOutOfRangeException($"{count} + {startIndex} sum is more than arrayToSearch length");
            }

            int elemCount = 0;
            for (int i = startIndex; i < startIndex + count; i++)
            {
                elemCount += CheckElement(arrayToSearch[i], ranges!, 0);
            }

            return elemCount;
        }

        private static void CheckRanges(decimal[]?[]? ranges, int index)
        {
            if (ranges == null)
            {
               throw new ArgumentNullException($"one of {ranges} values is null");
            }

            if (index >= ranges.Length)
            {
                return;
            }

            var range = ranges[index];
            if (range == null)
            {
                throw new ArgumentNullException($"one of {ranges} values is null");
            }

            if (range.Length != 2 && range.Length != 0)
            {
                throw new ArgumentException($"{ranges} implemented wrong");
            }

            CheckRanges(ranges!, index + 1);
        }

        private static int CheckElement(decimal value, decimal[]?[]? ranges, int index)
        {
            if (ranges == null)
            {
                throw new ArgumentNullException($"one of {ranges} values is null");
            }

            if (index >= ranges.Length)
            {
                return 0;
            }

            var range = ranges[index];
            if (range != null)
            {
                if (range.Length == 0)
                {
                    return CheckElement(value, ranges!, index + 1);
                }

                decimal rangeStart = range[0];
                decimal rangeEnd = range[1];
                if (value >= rangeStart && value <= rangeEnd)
                {
                    return 1;
                }
            }

            return CheckElement(value, ranges!, index + 1);
        }
    }
}
