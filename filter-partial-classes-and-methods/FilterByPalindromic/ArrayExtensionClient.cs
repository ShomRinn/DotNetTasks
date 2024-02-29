using System;
using System.Globalization;
#pragma warning disable SA1601 // Partial elements should be documented

namespace FilterByPalindromic
{
    public static partial class ArrayExtension
    {
        private static partial bool Verify(int item)
        {
            string str = item.ToString(CultureInfo.InvariantCulture);
            int start = 0;
            int end = str.Length - 1;
            while (start < end)
            {
                if (str[start] != str[end])
                {
                    return false;
                }

                start++;
                end--;
            }

            return true;
        }
    }
}
