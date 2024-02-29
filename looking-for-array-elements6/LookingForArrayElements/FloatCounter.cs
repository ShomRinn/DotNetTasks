using System;

namespace LookingForArrayElements
{
    public static class FloatCounter
    {
        /// <summary>
        /// Searches an array of floats for elements that are in a specified range, and returns the number of occurrences of the elements that matches the range criteria.
        /// </summary>
        /// <param name="arrayToSearch">One-dimensional, zero-based <see cref="Array"/> of single-precision floating-point numbers.</param>
        /// <param name="rangeStart">One-dimensional, zero-based <see cref="Array"/> of the range starts.</param>
        /// <param name="rangeEnd">One-dimensional, zero-based <see cref="Array"/> of the range ends.</param>
        /// <returns>The number of occurrences of the <see cref="Array"/> elements that match the range criteria.</returns>
        public static int GetFloatsCount(float[]? arrayToSearch, float[]? rangeStart, float[]? rangeEnd)
        {
            if (arrayToSearch == null || rangeStart == null || rangeEnd == null)
            {
                throw new ArgumentNullException($"{arrayToSearch} or {rangeStart} or {rangeEnd} is null");
            }

            if (rangeStart.Length != rangeEnd.Length)
            {
                throw new ArgumentException($"{rangeStart} or {rangeEnd} implemented wrong");
            }

            if (rangeStart.Length == 0 || rangeEnd.Length == 0)
            {
                return 0;
            }

            if (rangeStart[0] > rangeEnd[0])
            {
                throw new ArgumentException($"the range start value ({rangeStart[0]}) is greater than the range end value ({rangeEnd[0]})");
            }

            int count = 0;
            for (int i = 0; i < arrayToSearch.Length; i++)
            {
                for (int j = 0; j < rangeStart.Length; j++)
                {
                    if (arrayToSearch[i] >= rangeStart[j] && arrayToSearch[i] <= rangeEnd[j])
                    {
                        count++;
                    }
                }
            }

            return count;
        }

        /// <summary>
        /// Searches an array of floats for elements that are in a specified range, and returns the number of occurrences of the elements that matches the range criteria.
        /// </summary>
        /// <param name="arrayToSearch">One-dimensional, zero-based <see cref="Array"/> of single-precision floating-point numbers.</param>
        /// <param name="rangeStart">One-dimensional, zero-based <see cref="Array"/> of the range starts.</param>
        /// <param name="rangeEnd">One-dimensional, zero-based <see cref="Array"/> of the range ends.</param>
        /// <param name="startIndex">The zero-based starting index of the search.</param>
        /// <param name="count">The number of elements in the section to search.</param>
        /// <returns>The number of occurrences of the <see cref="Array"/> elements that match the range criteria.</returns>
        public static int GetFloatsCount(float[]? arrayToSearch, float[]? rangeStart, float[]? rangeEnd, int startIndex, int count)
        {
            if (arrayToSearch == null || rangeStart == null || rangeEnd == null)
            {
                throw new ArgumentNullException($"{arrayToSearch} or {rangeStart} or {rangeEnd} is null");
            }

            if (rangeStart.Length != rangeEnd.Length)
            {
                throw new ArgumentException($"{rangeStart} or {rangeEnd} implemented wrong");
            }

            if (count < 0)
            {
                throw new ArgumentOutOfRangeException($"{count} is less than zero");
            }

            if (startIndex < 0)
            {
                throw new ArgumentOutOfRangeException($"{startIndex} is less than zero");
            }

            if (rangeStart.Length == 0 || rangeEnd.Length == 0)
            {
                return 0;
            }

            if (rangeStart[0] > rangeEnd[0])
            {
                throw new ArgumentException($"the range start value ({rangeStart[0]}) is greater than the range end value ({rangeEnd[0]})");
            }

            if (count + startIndex > arrayToSearch.Length)
            {
                throw new ArgumentOutOfRangeException($"{count} + {startIndex} sum is more than arrayToSearch length");
            }

            int elemCount = 0, i = startIndex;
            while (i < startIndex + count)
            {
                int j = 0;
                while (j < rangeStart.Length)
                {
                    if (arrayToSearch[i] >= rangeStart[j] && arrayToSearch[i] <= rangeEnd[j])
                    {
                        elemCount++;
                    }

                    j++;
                }

                i++;
            }

            return elemCount;
        }
    }
}
