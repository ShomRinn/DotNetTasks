using System.Globalization;

namespace IsbnValidator
{
    public static class Validator
    {
        /// <summary>
        /// Returns true if the specified <paramref name="isbn"/> is valid; returns false otherwise.
        /// </summary>
        /// <param name="isbn">The string representation of 10-digit ISBN.</param>
        /// <returns>true if the specified <paramref name="isbn"/> is valid; false otherwise.</returns>
        /// <exception cref="ArgumentException"><paramref name="isbn"/> is empty or has only white-space characters.</exception>
        public static bool IsIsbnValid(string isbn)
        {
            if (isbn == null || isbn == string.Empty || isbn == "    ")
            {
                throw new ArgumentException("isbn cannot be null or empty or white space");
            }

            int sum = 0, hyphens = 0, numbers = 1;
            for (int i = 0; i < isbn.Length; i++)
            {
                if ((isbn[i] < 48 && isbn[i] != 45) || (isbn[i] > 57 && isbn[i] != 88))
                {
                    return false;
                }

                if (isbn[i] == 'X' && i != (isbn.Length - 1))
                {
                    return false;
                }

                if (isbn[i] == '-' && isbn[i + 1] == '-' && i < isbn.Length - 1)
                {
                    return false;
                }

                if (isbn[i] == '-')
                {
                    hyphens++;
                    continue;
                }

                if (isbn[i] == 'X')
                {
                    sum += (11 - numbers) * 10;
                    numbers++;
                    continue;
                }

                sum += (11 - numbers) * (int)char.GetNumericValue(isbn[i]);
                numbers++;
            }

            if (numbers != 11 || hyphens > 3)
            {
                return false;
            }

            if (sum % 11 == 0)
            {
                return true;
            }

            return false;
        }
    }
}
