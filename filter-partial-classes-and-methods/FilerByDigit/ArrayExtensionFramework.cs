﻿using System;
using System.Linq;

namespace FilterByDigit
{
    /// <summary>
    /// Class that contains filter operations of arrays.
    /// </summary>
    public static partial class ArrayExtension
    {
        /// <summary>
        /// Returns new array of elements that satisfy some predicate.
        /// </summary>
        /// <param name="source">Source array.</param>
        /// <returns>New array of elements that satisfy some predicate.</returns>
        /// <exception cref="ArgumentNullException">Thrown when array is null.</exception>
        /// <exception cref="ArgumentException">Thrown when array is empty.</exception>
        public static int[] FilterByPredicate(this int[]? source)
        {
            _ = source ?? throw new ArgumentNullException(nameof(source));
            _ = source.Length == 0 ? throw new ArgumentException("Source array cannot be empty.", nameof(source)) : source;

            List<int> filteredList = (from int item in source
                                      where Verify(item)
                                      select item).ToList();
            return filteredList.ToArray();
        }

        private static partial bool Verify(int item);
    }
}
