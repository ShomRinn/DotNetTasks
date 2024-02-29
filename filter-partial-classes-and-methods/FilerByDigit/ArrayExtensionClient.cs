using System;
using System.Globalization;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
#pragma warning disable SA1600 // Partial elements should be documented

namespace FilterByDigit
{/// <summary>
/// Class that contains filter operations of arrays.
/// </summary>
    public static partial class ArrayExtension
    {
        /// <summary>
        /// Gets or sets returns new array of elements that satisfy some predicate.
        /// </summary>
        /// <param name="source">Source array.</param>
        /// <returns>New array of elements that satisfy some predicate.</returns>
        /// <exception cref="ArgumentNullException">Thrown when array is null.</exception>
        /// <exception cref="ArgumentException">Thrown when array is empty.</exception>
        private static int digit;

        public static int Digit
        {
            get
            {
                return digit;
            }

            set
            {
                _ = value < 0 || value > 9 ? throw new ArgumentOutOfRangeException(nameof(value)) : value;

                digit = value;
            }
        }

        private static partial bool Verify(int item)
        {
            string itemStr = item.ToString(CultureInfo.InvariantCulture);
            char digitChar = Digit.ToString(CultureInfo.InvariantCulture)[0];
            foreach (char c in itemStr)
            {
                if (c == digitChar)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
