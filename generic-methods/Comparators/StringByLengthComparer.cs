using System;
using System.Collections.Generic;

namespace Comparators
{
    /// <summary>
    /// String comparator.
    /// </summary>
    public class StringByLengthComparer : IComparer<string>
    {
        /// <summary>
        /// Compares two strings and returns a value indicating whether one is less than, equal to, or greater than the other.
        /// </summary>
        /// <param name="x">The first strings to compare.</param>
        /// <param name="y">The second strings to compare.</param>
        /// <returns>A signed integer that indicates the relative values of x and y, as shown in the following table.</returns>
        public int Compare(string? x, string? y)
        {
            int xLength = x?.Length ?? -1;
            int yLength = y?.Length ?? -1;

            return xLength.CompareTo(yLength);
        }
    }
}
