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

            int i = 0, j = 0;
            return CountRecursive(arrayToSearch, elementsToSearchFor, i, j);
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

            if (count == 0)
            {
                return 0;
            }

            int occurrences = 0;
            for (int i = 0; i < elementsToSearchFor.Length; i++)
            {
                if (arrayToSearch[startIndex] == elementsToSearchFor[i])
                {
                    occurrences++;
                }
            }

            return occurrences + GetIntegersCount(arrayToSearch, elementsToSearchFor, startIndex + 1, count - 1);
        }

        private static int CountRecursive(int[] arrayToSearch, int[] elementsToSearchFor, int i, int j)
        {
            if (i == elementsToSearchFor.Length)
            {
                return 0;
            }
            else if (j == arrayToSearch.Length)
            {
                return CountRecursive(arrayToSearch, elementsToSearchFor, i + 1, 0);
            }
            else
            {
                return (arrayToSearch[j] == elementsToSearchFor[i] ? 1 : 0) +
                       CountRecursive(arrayToSearch, elementsToSearchFor, i, j + 1);
            }
        }
    }
}
