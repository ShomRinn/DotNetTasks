using System;

// ReSharper disable InconsistentNaming
namespace SelectionSort
{
    public static class Sorter
    {
        /// <summary>
        /// Sorts an <paramref name="array"/> with selection sort algorithm.
        /// </summary>
        public static void SelectionSort(this int[]? array)
        {
            if (array == null)
            {
                throw new ArgumentNullException(nameof(array));
            }

            for (int i = 0; i < array.Length - 1; i++)
            {
                int minIndex = i;
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (array[j] < array[minIndex])
                    {
                        minIndex = j;
                    }
                }

                int temp = array[i];
                array[i] = array[minIndex];
                array[minIndex] = temp;
            }
        }

        /// <summary>
        /// Sorts an <paramref name="array"/> with recursive selection sort algorithm.
        /// </summary>
        public static void RecursiveSelectionSort(this int[]? array)
        {
            if (array == null)
            {
                throw new ArgumentNullException(nameof(array));
            }

            int minIndex = 0;
            for (int i = 1; i < array.Length; i++)
            {
                if (array[i] < array[minIndex])
                {
                    minIndex = i;
                }
            }

            if (array.Length == 0)
            {
                for (int i = 0; i < array.Length - 1; i++)
                {
                    int minIndex1 = i;
                    for (int j = i + 1; j < array.Length; j++)
                    {
                        if (array[j] < array[minIndex1])
                        {
                            minIndex1 = j;
                        }
                    }

                    int temp = array[i];
                    array[i] = array[minIndex1];
                    array[minIndex1] = temp;
                }
            }
            else
            {
                int temp = array[0];
                array[0] = array[minIndex];
                array[minIndex] = temp;

                int[] subArray = new int[array.Length - 1];
                Array.Copy(array, 1, subArray, 0, subArray.Length);
                RecursiveSelectionSort(subArray);

                Array.Copy(subArray, 0, array, 1, subArray.Length);
            }
        }
    }
}
