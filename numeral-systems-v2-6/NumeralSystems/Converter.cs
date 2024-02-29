#pragma warning disable SA1121

using System;
using System.Globalization;
using System.Text.RegularExpressions;

namespace NumeralSystems
{
    /// <summary>
    /// Converts a string representations of a numbers to its integer equivalent.
    /// </summary>
    public static class Converter
    {
        /// <summary>
        /// Converts the string representation of a positive number in the octal numeral system to its 32-bit signed integer equivalent.
        /// </summary>
        /// <param name="source">The string representation of a positive number in the octal numeral system.</param>
        /// <returns>A positive decimal value.</returns>
        /// <exception cref="ArgumentException">
        /// Thrown if source string presents a negative number
        /// - or
        /// contains invalid symbols (non-octal alphabetic characters).
        /// Valid octal alphabetic characters: 0,1,2,3,4,5,6,7.
        /// </exception>
        public static int ParsePositiveFromOctal(this string source)
        {
            if (string.IsNullOrEmpty(source))
            {
                throw new ArgumentException("source is null or empty.");
            }

            if (!Regex.IsMatch(source, @"^[0-7]+$"))
            {
                throw new ArgumentException("source is not a valid representation.");
            }

            int numeralSystem = 8;

            int result = ParseSomeFromSome(source, numeralSystem);

            if (result < 0)
            {
                throw new ArgumentException("source is not a positive number.");
            }

            return result;
        }

        /// <summary>
        /// Converts the string representation of a positive number in the decimal numeral system to its 32-bit signed integer equivalent.
        /// </summary>
        /// <param name="source">The string representation of a positive number in the decimal numeral system.</param>
        /// <returns>A positive decimal value.</returns>
        /// <exception cref="ArgumentException">
        /// Thrown if source string presents a negative number
        /// - or
        /// contains invalid symbols (non-decimal alphabetic characters).
        /// Valid decimal alphabetic characters: 0,1,2,3,4,5,6,7,8,9.
        /// </exception>
        public static int ParsePositiveFromDecimal(this string source)
        {
            if (string.IsNullOrEmpty(source))
            {
                throw new ArgumentException("source is null or empty.");
            }

            if (Regex.IsMatch(source, @"[a-zA-Z]+"))
            {
                throw new ArgumentException("source is not a valid representation.");
            }

            int numeralSystem = 10;

            int result = ParseSomeFromSome(source, numeralSystem);

            if (result < 0)
            {
                throw new ArgumentException("source is not a positive number.");
            }

            return result;
        }

        /// <summary>
        /// Converts the string representation of a positive number in the hex numeral system to its 32-bit signed integer equivalent.
        /// </summary>
        /// <param name="source">The string representation of a positive number in the hex numeral system.</param>
        /// <returns>A positive decimal value.</returns>
        /// <exception cref="ArgumentException">
        /// Thrown if source string presents a negative number
        /// - or
        /// contains invalid symbols (non-hex alphabetic characters).
        /// Valid hex alphabetic characters: 0,1,2,3,4,5,6,7,8,9,A(or a),B(or b),C(or c),D(or d),E(or e),F(or f).
        /// </exception>
        public static int ParsePositiveFromHex(this string source)
        {
            if (string.IsNullOrEmpty(source))
            {
                throw new ArgumentException("source is null or empty.");
            }

            if (Regex.IsMatch(source, @"[g-zG-Z]+"))
            {
                throw new ArgumentException("source is not a valid representation.");
            }

            int numeralSystem = 16;

            int result = ParseSomeFromSome(source, numeralSystem);

            if (result < 0)
            {
                throw new ArgumentException("source is not a positive number.");
            }

            return result;
        }

        /// <summary>
        /// Converts the string representation of a positive number in the octal, decimal or hex numeral system to its 32-bit signed integer equivalent.
        /// </summary>
        /// <param name="source">The string representation of a positive number in the the octal, decimal or hex numeral system.</param>
        /// <param name="radix">The radix.</param>
        /// <returns>A positive decimal value.</returns>
        /// <exception cref="ArgumentException">
        /// Thrown if source string presents a negative number
        /// - or
        /// contains invalid for given numeral system symbols
        /// -or-
        /// the radix is not equal 8, 10 or 16.
        /// </exception>
        public static int ParsePositiveByRadix(this string source, int radix)
        {
            if (string.IsNullOrEmpty(source))
            {
                throw new ArgumentException("source is null or empty.");
            }

            if (radix == 16 && Regex.IsMatch(source, @"[g-zG-Z]+"))
            {
                throw new ArgumentException("source is not a valid representation.");
            }

            if (radix == 10 && Regex.IsMatch(source, @"[a-zA-Z]+"))
            {
                throw new ArgumentException("source is not a valid representation.");
            }

            if (radix == 8 && Regex.IsMatch(source, @"[9a-zA-Z]+"))
            {
                    throw new ArgumentException("source is not a valid representation.");
            }

            if (radix != 8 && radix != 10 && radix != 16)
            {
                throw new ArgumentException("Radix must be between 2 and 36.");
            }

            int result = ParseSomeFromSome(source, radix);

            if (result < 0)
            {
                throw new ArgumentException("source is not a positive number.");
            }

            return result;
        }

        /// <summary>
        /// Converts the string representation of a signed number in the octal, decimal or hex numeral system to its 32-bit signed integer equivalent.
        /// </summary>
        /// <param name="source">The string representation of a signed number in the the octal, decimal or hex numeral system.</param>
        /// <param name="radix">The radix.</param>
        /// <returns>A signed decimal value.</returns>
        /// <exception cref="ArgumentException">
        /// Thrown if source contains invalid for given numeral system symbols
        /// -or-
        /// the radix is not equal 8, 10 or 16.
        /// </exception>
        public static int ParseByRadix(this string source, int radix)
        {
            if (string.IsNullOrEmpty(source))
            {
                throw new ArgumentException("source is null or empty.");
            }

            if (radix == 16 && Regex.IsMatch(source, @"[g-zG-Z]+"))
            {
                throw new ArgumentException("source is not a valid representation.");
            }

            if (radix == 10 && Regex.IsMatch(source, @"[a-zA-Z]+"))
            {
                throw new ArgumentException("source is not a valid representation.");
            }

            if (radix == 8 && Regex.IsMatch(source, @"[9a-zA-Z]+"))
            {
                throw new ArgumentException("source is not a valid representation.");
            }

            if (radix != 8 && radix != 10 && radix != 16)
            {
                throw new ArgumentException("Radix must be between 2 and 36.");
            }

            return ParseSomeFromSome(source, radix);
        }

        /// <summary>
        /// Converts the string representation of a positive number in the octal numeral system to its 32-bit signed integer equivalent.
        /// A return value indicates whether the conversion succeeded.
        /// </summary>
        /// <param name="source">The string representation of a positive number in the octal numeral system.</param>
        /// <param name="value">A positive decimal value.</param>
        /// <returns>true if s was converted successfully; otherwise, false.</returns>
        public static bool TryParsePositiveFromOctal(this string source, out int value)
        {
            int radix = 8;
            bool answ = TryParseSomeFromSome(source, radix, out value);

            if (value < 0)
            {
                value = 0;
                return false;
            }

            return answ;
        }

        /// <summary>
        /// Converts the string representation of a positive number in the decimal numeral system to its 32-bit signed integer equivalent.
        /// A return value indicates whether the conversion succeeded.
        /// </summary>
        /// <param name="source">The string representation of a positive number in the decimal numeral system.</param>
        /// <returns>A positive decimal value.</returns>
        /// <param name="value">A positive decimal value.</param>
        /// <returns>true if s was converted successfully; otherwise, false.</returns>
        public static bool TryParsePositiveFromDecimal(this string source, out int value)
        {
            int radix = 10;
            bool answ = TryParseSomeFromSome(source, radix, out value);

            if (value < 0)
            {
                value = 0;
                return false;
            }

            return answ;
        }

        /// <summary>
        /// Converts the string representation of a positive number in the hex numeral system to its 32-bit signed integer equivalent.
        /// A return value indicates whether the conversion succeeded.
        /// </summary>
        /// <param name="source">The string representation of a positive number in the hex numeral system.</param>
        /// <returns>A positive decimal value.</returns>
        /// <param name="value">A positive decimal value.</param>
        /// <returns>true if s was converted successfully; otherwise, false.</returns>
        public static bool TryParsePositiveFromHex(this string source, out int value)
        {
            int radix = 16;
            bool answ = TryParseSomeFromSome(source, radix, out value);

            if (value < 0)
            {
                value = 0;
                return false;
            }

            return answ;
        }

        /// <summary>
        /// Converts the string representation of a positive number in the octal, decimal or hex numeral system to its 32-bit signed integer equivalent.
        /// A return value indicates whether the conversion succeeded.
        /// </summary>
        /// <param name="source">The string representation of a positive number in the the octal, decimal or hex numeral system.</param>
        /// <param name="radix">The radix.</param>
        /// <returns>A positive decimal value.</returns>
        /// <param name="value">A positive decimal value.</param>
        /// <returns>true if s was converted successfully; otherwise, false.</returns>
        /// <exception cref="ArgumentException">Thrown the radix is not equal 8, 10 or 16.</exception>
        public static bool TryParsePositiveByRadix(this string source, int radix, out int value)
        {
            if (radix != 8 && radix != 10 && radix != 16)
            {
                throw new ArgumentException("Radix must be between 8, 10 or 16.");
            }

            bool answ = TryParseSomeFromSome(source, radix, out value);

            if (value < 0)
            {
                value = 0;
                return false;
            }

            return answ;
        }

        /// <summary>
        /// Converts the string representation of a signed number in the octal, decimal or hex numeral system to its 32-bit signed integer equivalent.
        /// A return value indicates whether the conversion succeeded.
        /// </summary>
        /// <param name="source">The string representation of a signed number in the the octal, decimal or hex numeral system.</param>
        /// <param name="radix">The radix.</param>
        /// <returns>A positive decimal value.</returns>
        /// <param name="value">A positive decimal value.</param>
        /// <returns>true if s was converted successfully; otherwise, false.</returns>
        /// <exception cref="ArgumentException">Thrown the radix is not equal 8, 10 or 16.</exception>
        public static bool TryParseByRadix(this string source, int radix, out int value)
        {
            return TryParseSomeFromSome(source, radix, out value);
        }

        private static bool TryParseSomeFromSome(this string source, int radix, out int value)
        {
            value = 0;
            if (string.IsNullOrEmpty(source))
            {
                return false;
            }

            int power = 1;
            bool isNegative = false;
            if (source[0] == '-')
            {
                isNegative = true;
                source = source.Substring(1);
            }

            for (int i = source.Length - 1; i >= 0; i--)
            {
                int digit;
                if (radix == 10)
                {
                    if (!char.IsDigit(source[i]))
                    {
                        return false;
                    }

                    digit = source[i] - '0';
                }
                else if (radix == 16)
                {
                    if (char.IsDigit(source[i]))
                    {
                        digit = source[i] - '0';
                    }
                    else if (char.IsLetter(source[i]) && char.ToUpper(source[i], CultureInfo.CurrentCulture) >= 'A' && char.ToUpper(source[i], CultureInfo.CurrentCulture) <= 'F')
                    {
                        digit = char.ToUpper(source[i], CultureInfo.CurrentCulture) - 'A' + 10;
                    }
                    else
                    {
                        return false;
                    }
                }
                else if (radix == 8)
                {
                    if (source[i] < '0' || source[i] > '7')
                    {
                        return false;
                    }

                    digit = source[i] - '0';
                }
                else
                {
                    return false;
                }

                value += digit * power;
                power *= radix;
            }

            if (isNegative)
            {
                value = -value;
            }

            return true;
        }

        private static int ParseSomeFromSome(string source, int radix)
        {
            bool isNegative = false;
            if (source[0] == '-')
            {
                isNegative = true;
                source = source.Substring(1);
            }

            long result = 0;
            int length = source.Length;
            for (int i = 0; i < length; i++)
            {
                int digit = 0;
                if (Char.IsDigit(source[i]))
                {
                    digit = source[i] - '0';
                }
                else if (Char.IsLetter(source[i]))
                {
                    digit = Char.ToUpper(source[i], CultureInfo.CurrentCulture) - 'A' + 10;
                }
                else
                {
                    throw new ArgumentException("Input string is not in a correct format");
                }

                if (digit >= radix)
                {
                    throw new ArgumentException("Input string is not in a correct format");
                }

                result += digit * (int)Math.Pow(radix, length - i - 1);
            }

            if (result < -0x7FFFFFFF)
            {
                throw new ArgumentException("source is not a positive number.");
            }

            if (result > 0x7FFFFFFF)
            {
                throw new ArgumentException("source is not a positive number.");
            }

            int finalResult = (int)result;

            return isNegative ? -finalResult : finalResult;
        }
    }
}
