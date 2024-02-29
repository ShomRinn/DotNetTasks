#pragma warning disable SA1600 // Elements should be documented
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace ArrayExtension
{
    public static class ArrayExtension
    {
        public static int[] FilterByDigit(this int[]? source, int digit)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source), "Array cannot be null.");
            }

            if (digit < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(digit), "Expected digit cannot be less than zero.");
            }

            if (digit > 9)
            {
                throw new ArgumentOutOfRangeException(nameof(digit), "Expected digit cannot be out of range 0..9.");
            }

            if (source.Length == 0)
            {
                throw new ArgumentException("Array cannot be empty.", nameof(source));
            }

            var resultList = (from item in source
                              where IsMatch(item)
                              select item).ToList();
            return resultList.ToArray();

            bool IsMatch(int value)
            {
                var valueAsString = value.ToString(CultureInfo.InvariantCulture);

                return valueAsString.Contains(digit.ToString(CultureInfo.InvariantCulture), StringComparison.Ordinal);
            }
        }

        public static int[] FilterByPalindromic(this int[]? source)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source), "Array cannot be null.");
            }

            if (source.Length == 0)
            {
                throw new ArgumentException("Array cannot be empty.", nameof(source));
            }

            var resultList = new List<int>();

            foreach (var item in source)
            {
                if (item >= 0 && IsPalindromic(item))
                {
                    resultList.Add(item);
                }
            }

            return resultList.ToArray();

            bool IsPalindromic(int value)
            {
                var valueAsString = value.ToString(CultureInfo.InvariantCulture);
                var reversedValue = new string(valueAsString.Reverse().ToArray());

                return valueAsString == reversedValue;
            }
        }
    }
}
