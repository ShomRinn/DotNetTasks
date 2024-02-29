using System;

namespace BookStoreCatalog
{
    /// <summary>
    /// Represents an International Standard Book Number (ISBN).
    /// </summary>
    public class BookNumber
    {
        private readonly string code;

        /// <summary>
        /// Initializes a new instance of the <see cref="BookNumber"/> class with the specified 10-digit ISBN <paramref name="isbnCode"/>.
        /// </summary>
        /// <param name="isbnCode">A 10-digit ISBN code.</param>
        /// <exception cref="ArgumentNullException">Thrown when the isbnCode argument is null.</exception>
        /// <exception cref="ArgumentException">Thrown when the isbnCode argument is invalid or has the wrong checksum.</exception>
        public BookNumber(string isbnCode)
        {
            if (isbnCode == null)
            {
                throw new ArgumentNullException(nameof(isbnCode));
            }

            if (!ValidateCode(isbnCode))
            {
                throw new ArgumentException("Invalid ISBN code.", nameof(isbnCode));
            }

            if (!ValidateChecksum(isbnCode))
            {
                throw new ArgumentException("Invalid ISBN checksum.", nameof(isbnCode));
            }

            this.code = isbnCode;
        }

        /// <summary>
        /// Gets a 10-digit ISBN code.
        /// </summary>
        public string Code
        {
            get { return this.code; }
        }

        /// <summary>
        /// Gets an <see cref="Uri"/> to the publication page on the isbnsearch.org website.
        /// </summary>
        /// <returns>An <see cref="Uri"/> to the publication page on the isbnsearch.org website.</returns>
        public Uri GetSearchUri()
        {
            return new Uri($"https://isbnsearch.org/isbn/{this.code}");
        }

        /// <summary>
        /// Returns the string that represents a current object.
        /// </summary>
        /// <returns>A string that represents the current object.</returns>
        public override string ToString()
        {
            return this.code;
        }

        private static bool ValidateCode(string isbnCode)
        {
            if (isbnCode.Length != 10)
            {
                return false;
            }

            for (int i = 0; i < 10; i++)
            {
                if (!char.IsDigit(isbnCode[i]))
                {
                    return false;
                }
            }

            return true;
        }

        private static bool ValidateChecksum(string isbnCode)
        {
            int sum = 0;

            for (int i = 0; i < 9; i++)
            {
                sum += (i + 1) * (isbnCode[i] - '0');
            }

            int remainder = sum % 11;
            int checkDigit = (remainder == 10) ? 'X' : (char)(remainder + '0');

            return isbnCode[9] == checkDigit;
        }
    }
}
