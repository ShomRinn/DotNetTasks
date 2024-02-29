using System;

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

            for (int i = 0; i < ranges.Length; i++)
            {
                var range = ranges[i];
                if (range == null)
                {
                    throw new ArgumentNullException($"one of {ranges} values is null");
                }

                if (range.Length != 2 && range.Length != 0)
                {
                    throw new ArgumentException($"{ranges} inmplemented wrong");
                }
            }

            if (arrayToSearch.Length == 0 || ranges.Length == 0)
            {
                return 0;
            }

            int elemCount = 0;
            decimal rangeStart, rangeEnd;
            int j = 0, k = 0;
            do
            {
                do
                {
                    var range = ranges[k];
                    if (range != null)
                    {
                        if (range.Length == 0)
                        {
                            k++;
                            continue;
                        }

                        rangeStart = range[0];
                        rangeEnd = range[1];
                        if (arrayToSearch[j] >= rangeStart && arrayToSearch[j] <= rangeEnd)
                        {
                            elemCount++;
                            break;
                        }
                    }

                    k++;
                }
                while (k < ranges.Length);
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

            for (int i = 0; i < ranges.Length; i++)
            {
                var range = ranges[i];
                if (range == null)
                {
                    throw new ArgumentNullException($"one of {ranges} values is null");
                }

                if (range.Length != 2 && range.Length != 0)
                {
                    throw new ArgumentException($"{ranges} inmplemented wrong");
                }
            }

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
            decimal rangeStart, rangeEnd;
            for (int i = startIndex; i < startIndex + count; i++)
            {
                for (int j = 0; j < ranges.Length; j++)
                {
                    var range = ranges[j];
                    if (range != null)
                    {
                        if (range.Length == 0)
                        {
                            continue;
                        }

                        rangeStart = range[0];
                        rangeEnd = range[1];
                        if (arrayToSearch[i] >= rangeStart && arrayToSearch[i] <= rangeEnd)
                        {
                            elemCount++;
                            break;
                        }
                    }
                }
            }

            return elemCount;
        }
    }
}
