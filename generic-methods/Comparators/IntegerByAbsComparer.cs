using System;
using System.Collections.Generic;

namespace Comparators
{
    /// <summary>
    /// Integer comparator.
    /// </summary>
    public class IntegerByAbsComparer : IComparer<int>
    {
        /// <summary>
        /// Compares two integers and returns a value indicating whether one is less than, equal to, or greater than the other.
        /// </summary>
        /// <param name="x">The first integers to compare.</param>
        /// <param name="y">The second integers to compare.</param>
        /// <returns>A signed integer that indicates the relative values of x and y, as shown in the following table.</returns>
        public int Compare(int x, int y) => Math.Abs(x) - Math.Abs(y);
    }
}
