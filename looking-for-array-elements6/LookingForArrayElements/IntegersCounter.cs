using System;

namespace LookingForArrayElements
{
    public static class IntegersCounter
    {
        /// <summary>
        /// Searches an array of integers for elements that are in <paramref name="elementsToSearchFor"/> <see cref="Array"/>, and returns the number of occurrences of the elements.
        /// </summary>
        /// <param name="arrayToSearch">One-dimensional, zero-based <see cref="Array"/> of integers to search.</param>
        /// <param name="elementsToSearchFor">One-dimensional, zero-based <see cref="Array"/> that contains integers to search for.</param>
        /// <returns>The number of occurrences of the elements that are in <paramref name="elementsToSearchFor"/> <see cref="Array"/>.</returns>
        public static int GetIntegersCount(int[]? arrayToSearch, int[]? elementsToSearchFor)
        {
            if (arrayToSearch == null || elementsToSearchFor == null)
            {
                throw new ArgumentNullException(nameof(arrayToSearch));
            }

            int count = 0;
            int i = 0;
            while (i < elementsToSearchFor.Length)
            {
                int j = 0;
                while (j < arrayToSearch.Length)
                {
                    if (arrayToSearch[j] == elementsToSearchFor[i])
                    {
                        count++;
                    }

                    j++;
                }

                i++;
            }

            return count;
        }

        /// <summary>
        /// Searches an array of integers for elements that are in <paramref name="elementsToSearchFor"/> <see cref="Array"/>, and returns the number of occurrences of the elements withing the range of elements in the <see cref="Array"/> that starts at the specified index and contains the specified number of elements.
        /// </summary>
        /// <param name="arrayToSearch">One-dimensional, zero-based <see cref="Array"/> of integers to search.</param>
        /// <param name="elementsToSearchFor">One-dimensional, zero-based <see cref="Array"/> that contains integers to search for.</param>
        /// <param name="startIndex">The zero-based starting index of the search.</param>
        /// <param name="count">The number of elements in the section to search.</param>
        /// <returns>The number of occurrences of the elements that are in <paramref name="elementsToSearchFor"/> <see cref="Array"/>.</returns>
        public static int GetIntegersCount(int[]? arrayToSearch, int[]? elementsToSearchFor, int startIndex, int count)
        {
            if (arrayToSearch == null || elementsToSearchFor == null)
            {
                throw new ArgumentNullException($"{arrayToSearch} or {elementsToSearchFor} are null");
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
            int i = startIndex;
            while (i < startIndex + count)
            {
                int j = 0;
                while (j < elementsToSearchFor.Length)
                {
                    if (arrayToSearch[i] == elementsToSearchFor[j])
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
