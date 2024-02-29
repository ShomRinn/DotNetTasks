using System;

namespace PalindromicNumberTask
{
    /// <summary>
    /// Provides static method for working with integers.
    /// </summary>
    public static class NumbersExtension
    {
        /// <summary>
        /// Determines if a number is a palindromic number, see https://en.wikipedia.org/wiki/Palindromic_number.
        /// </summary>
        /// <param name="number">Verified number.</param>
        /// <returns>true if the verified number is palindromic number; otherwise, false.</returns>
        /// <exception cref="ArgumentException"> Thrown when source number is less than zero. </exception>
        public static bool IsPalindromicNumber(int number)
        {
            if (number < 0)
            {
                throw new ArgumentException("number cannot be less than zero");
            }

            if (number >= 0 && number < 10)
            {
                return true;
            }

            int lenth = 0;
            int last_digit = number % 10;
            int first_digit = FirstDigit(number, ref lenth);

            if (first_digit != last_digit)
            {
                return false;
            }
            else
            {
                number -= first_digit * (int)Math.Pow(10, lenth);

                return IsPalindromicNumber(number / 10);
            }
        }

        private static int FirstDigit(int num, ref int lenth)
        {
            if (num < 10)
            {
                return num;
            }

            lenth++;
            return FirstDigit(num / 10, ref lenth);
        }
    }
}
