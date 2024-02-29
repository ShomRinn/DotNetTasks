using System;
using System.Globalization;
using System.Text;
using static System.Net.Mime.MediaTypeNames;

namespace NumeralSystems
{
    public static class Converter
    {
        /// <summary>
        /// Gets the value of a positive integer to its equivalent string representation in the octal numeral systems.
        /// </summary>
        /// <param name="number">Source number.</param>
        /// <returns>The equivalent string representation of the number in the octal numeral systems.</returns>
        /// <exception cref="ArgumentException">Thrown if number is less than zero.</exception>
        public static string GetPositiveOctal(this int number)
        {
            if (number < 0)
            {
                throw new ArgumentException("Number must be positive.");
            }

            int radix = 8;

            return GetValue(number, radix);
        }

        /// <summary>
        /// Gets the value of a positive integer to its equivalent string representation in the decimal numeral systems.
        /// </summary>
        /// <param name="number">Source number.</param>
        /// <returns>The equivalent string representation of the number in the decimal numeral systems.</returns>
        /// <exception cref="ArgumentException">Thrown if number is less than zero.</exception>
        public static string GetPositiveDecimal(this int number)
        {
            if (number < 0)
            {
                throw new ArgumentException("Number must be positive.");
            }


            int radix = 10;

            return GetValue(number, radix);
        }

        /// <summary>
        /// Gets the value of a positive integer to its equivalent string representation in the hexadecimal numeral systems.
        /// </summary>
        /// <param name="number">Source number.</param>
        /// <returns>The equivalent string representation of the number in the hexadecimal numeral systems.</returns>
        /// <exception cref="ArgumentException">Thrown if number is less than zero.</exception>
        public static string GetPositiveHex(this int number)
        {

            if (number < 0)
            {
                throw new ArgumentException("Number must be positive.");
            }

            int radix = 16;

            return GetValue(number, radix);
        }

        /// <summary>
        /// Gets the value of a positive integer to its equivalent string representation in a specified radix.
        /// </summary>
        /// <param name="number">Source number.</param>
        /// <param name="radix">Base of the numeral systems.</param>
        /// <returns>The equivalent string representation of the number in a specified radix.</returns>
        /// <exception cref="ArgumentException">Thrown if radix is not equal 8, 10 or 16.</exception>
        /// <exception cref="ArgumentException">Thrown if number is less than zero.</exception>
        public static string GetPositiveRadix(this int number, int radix)
        {
            if (number < 0)
            {
                throw new ArgumentException("Number must be positive.");
            }

            if (radix != 8 && radix != 10 && radix != 16)
            {
                throw new ArgumentException("Radix must be between 2 and 36.");
            }

            return GetValue(number, radix);
        }

        /// <summary>
        /// Gets the value of a signed integer to its equivalent string representation in a specified radix.
        /// </summary>
        /// <param name="number">Source number.</param>
        /// <param name="radix">Base of the numeral systems.</param>
        /// <returns>The equivalent string representation of the number in a specified radix.</returns>
        /// <exception cref="ArgumentException">Thrown if radix is not equal 8, 10 or 16.</exception>
        public static string GetRadix(this int number, int radix)
        {
            if (radix != 8 && radix != 10 && radix != 16)
            {
                throw new ArgumentException("Radix must be between 2 and 36.");
            }

            return GetValue(number, radix);
        }

        private static string GetValue(int number, int radix)
        {
            long intMinValue = int.MinValue;
            intMinValue = Math.Abs(intMinValue);

            long longnumber = number;
            if (longnumber < 0)
            {
                longnumber = (intMinValue * 2) + number;
            }

            string result = string.Empty;
            while (longnumber != 0)
            {
                int count = (int)(longnumber % radix);
                if (count >= 10)
                {
                    switch (count)
                    {
                        case 10:
                            result = string.Concat(result, "A");
                            break;
                        case 11:
                            result = string.Concat(result, "B");
                            break;
                        case 12:
                            result = string.Concat(result, "C");
                            break;
                        case 13:
                            result = string.Concat(result, "D");
                            break;
                        case 14:
                            result = string.Concat(result, "E");
                            break;
                        case 15:
                            result = string.Concat(result, "F");
                            break;
                    }

                    longnumber /= radix;
                }
                else
                {
                    result = string.Concat(result, count);
                    longnumber /= radix;
                }
            }

            char[] chars = result.ToCharArray();
            Array.Reverse(chars);
            return new string(chars);
        }
    }
}
