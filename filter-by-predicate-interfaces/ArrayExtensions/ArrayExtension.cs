using System;
using System.Globalization;


namespace ArrayExtensions
{
    /// <summary>
    /// Class of the additional operations with array.
    /// </summary>
    public static class ArrayExtension
    {
        /// <summary>
        /// Returns new array of elements that contain expected digit from source array.
        /// </summary>
        /// <param name="source">Source array.</param>
        /// <param name="digit">Expected digit.</param>
        /// <returns>Array of elements that contain expected digit.</returns>
        /// <exception cref="ArgumentNullException">Thrown when array is null.</exception>
        /// <exception cref="ArgumentException">Thrown when array is empty.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when digit value is out of range (0..9).</exception>
        /// <example>
        /// {1, 2, 3, 4, 5, 6, 7, 68, 69, 70, 15, 17}  => { 7, 70, 17 } for digit = 7
        /// </example>
        public static int[] FilterByDigit(this int[]? source, int digit)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            if (digit < 0 || digit > 9)
            {
                throw new ArgumentOutOfRangeException(nameof(digit), "Expected digit cannot be out of range 0..9.");
            }

            if (source.Length == 0)
            {
                throw new ArgumentException("array is empty", nameof(source));
            }

            List<int> result = new List<int>();

            for (int i = 0; i < source.Length; i++)
            {
                if (IsMatch(source[i]))
                {
                    result.Add(source[i]);
                }
            }

            return result.ToArray();

            bool IsMatch(int value)
            {
                char charDigit = (char)(digit + '0');
                string itemString = value.ToString(CultureInfo.InvariantCulture);
                int length = itemString.Length;

                for (int i = 0; i < length; i++)
                {
                    if (itemString[i] == charDigit)
                    {
                        return true;
                    }
                }

                return false;
            }
        }

        /// <summary>
        /// Returns new array that contains only palindromic numbers from source array.
        /// </summary>
        /// <param name="source">Source array.</param>
        /// <returns>Array of elements that are palindromic numbers.</returns>
        /// <exception cref="ArgumentNullException">Throw when array is null.</exception>
        /// <exception cref="ArgumentException">Throw when array is empty.</exception>
        /// <example>
        /// {12345, 1111111112, 987654, 56, 1111111, -1111, 1, 1233321, 70, 15, 123454321}  => { 1111111, 123321, 123454321 }
        /// {56, -1111111112, 987654, 56, 890, -1111, 543, 1233}  => {  }
        /// </example>
        public static int[] FilterByPalindromic(this int[]? source)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            if (source.Length == 0)
            {
                throw new ArgumentException("array is empty", nameof(source));
            }

            List<int> result = new List<int>();

            for (int i = 0; i < source.Length; i++)
            {
                if (IsMatch(source[i]))
                {
                    result.Add(source[i]);
                }
            }

            return result.ToArray();

            static bool IsMatch(int value)
            {
                if (value < 0)
                {
                    return false;
                }

                string itemString = value.ToString(CultureInfo.InvariantCulture);

                for (int first = 0, last = itemString.Length - 1; first <= last; first++, last--)
                {
                    if (itemString[first] == itemString[last])
                    {
                        if (last == itemString.Length / 2)
                        {
                            return true;
                        }

                        continue;
                    }

                    return false;
                }

                return false;
            }
        }
    }
}
