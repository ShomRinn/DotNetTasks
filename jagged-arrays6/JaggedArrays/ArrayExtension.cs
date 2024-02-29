using System;

namespace JaggedArrays
{
    public static class ArrayExtension
    {
        /// <summary>
        /// Orders the rows in a jagged-array by ascending of the sum of the elements in them.
        /// </summary>
        /// <param name="source">The jagged-array to sort.</param>
        /// <exception cref="ArgumentNullException">Thrown when source in null.</exception>
        public static void OrderByAscendingBySum(this int[][]? source)
        {
            if (source == null)
            {
                throw new ArgumentNullException($"{source} is null");
            }

            int[] sums = new int[source.Length];
            for (int i = 0; i < source.Length; i++)
            {
                switch (source[i])
                {
                    case null:
                        sums[i] = int.MinValue;
                        break;
                    default:
                        sums[i] = source[i].Sum();
                        break;
                }
            }

            BubbleSort(sums, source);
        }

        /// <summary>
        /// Orders the rows in a jagged-array by descending of the sum of the elements in them.
        /// </summary>
        /// <param name="source">The jagged-array to sort.</param>
        /// <exception cref="ArgumentNullException">Thrown when source in null.</exception>
        public static void OrderByDescendingBySum(this int[][]? source)
        {
            if (source == null)
            {
                throw new ArgumentNullException($"{source} is null");
            }

            int[] sums = new int[source.Length];
            for (int i = 0; i < source.Length; i++)
            {
                switch (source[i])
                {
                    case null:
                        sums[i] = int.MaxValue;
                        break;
                    default:
                        sums[i] = -source[i].Sum();
                        break;
                }
            }

            BubbleSort(sums, source);
        }

        /// <summary>
        /// Orders the rows in a jagged-array by ascending of the max of the elements in them.
        /// </summary>
        /// <param name="source">The jagged-array to sort.</param>
        /// <exception cref="ArgumentNullException">Thrown when source in null.</exception>
        public static void OrderByAscendingByMax(this int[][]? source)
        {
            if (source == null)
            {
                throw new ArgumentNullException($"{source} is null");
            }

            int[] maxValues = new int[source.Length];
            for (int i = 0; i < source.Length; i++)
            {
                switch (source[i])
                {
                    case null:
                        maxValues[i] = int.MinValue;
                        break;
                    default:
                        maxValues[i] = source[i].Max();
                        break;
                }
            }

            BubbleSort(maxValues, source);
        }

        /// <summary>
        /// Orders the rows in a jagged-array by descending of the max of the elements in them.
        /// </summary>
        /// <param name="source">The jagged-array to sort.</param>
        /// <exception cref="ArgumentNullException">Thrown when source in null.</exception>
        public static void OrderByDescendingByMax(this int[][]? source)
        {
            if (source == null)
            {
                throw new ArgumentNullException($"{source} is null");
            }

            int[] maxValues = new int[source.Length];
            for (int i = 0; i < source.Length; i++)
            {
                switch (source[i])
                {
                    case null:
                        maxValues[i] = int.MaxValue;
                        break;
                    default:
                        maxValues[i] = -source[i].Max();
                        break;
                }
            }

            BubbleSort(maxValues, source);
        }

        private static void BubbleSort(this int[]? array, int[][]? source)
        {
            for (int i = 0; i < array!.Length - 1; i++)
            {
                for (int j = 0; j < array.Length - 1 - i; j++)
                {
                    if (array[j] > array[j + 1])
                    {
                        (array[j], array[j + 1]) = (array[j + 1], array[j]);
                        (source![j], source[j + 1]) = (source[j + 1], source[j]);
                    }
                }
            }
        }
    }
}
