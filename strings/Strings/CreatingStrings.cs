using System;

namespace Strings
{
    public static class CreatingStrings
    {
        /// <summary>
        /// Returns a new string that contains a specified string.
        /// </summary>
        public static string ReturnNewString(string str)
        {
            return new string(str);
        }

        /// <summary>
        /// Returns a new string that contains a specified character repeated a specified number of times.
        /// </summary>
        public static string ReturnStringWithRepeatedChars(char c, int count)
        {
            return new string(c, count);
        }

        /// <summary>
        /// Returns a new string that contains a specified character array.
        /// </summary>
        public static string ReturnStringFromCharArray(char[] c)
        {
            string str = string.Empty;
            for (int i = 0; i < c.Length; i++)
            {
                str = string.Concat(str, c[i]);
            }

            return str;
        }

        /// <summary>
        /// Returns a new string that contains a part of a specified character array.
        /// </summary>
        public static string ReturnStringFromCharArray(char[] c, int startIndex, int length)
        {
            string str = string.Empty;
            for (int i = 0; i < length; i++, startIndex++)
            {
                str = string.Concat(str, c[startIndex]);
            }

            return str;
        }
    }
}
