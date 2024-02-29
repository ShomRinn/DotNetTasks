using System.Globalization;

namespace ContainsDigitPredicate
{
    /// <summary>
    /// Predicate that determines the presence of some digit in integer.
    /// </summary>
    public class ContainsDigitValidator
    {
        private int digit;

        /// <summary>
        /// Gets or sets a digit.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when Digit more than 9 or less than 0.</exception>
        public int Digit
        {
            get
            {
                return this.digit;
            }

            set => this.digit = value < 0 || value > 9 ? throw new ArgumentOutOfRangeException(nameof(value), "digit cannot be out of range 0..9") : value;
        }

        /// <summary>
        /// Represents a method which finds digit.
        /// </summary>
        /// <param name="value">Given value.</param>
        /// <returns>Result of matching.</returns>
        public bool Verify(int value)
        {
            if (value == 0)
            {
                return this.Digit == 0;
            }

            if (value < 0)
            {
                value = value == int.MinValue ? int.MaxValue : Math.Abs(value);
            }

            while (value != 0)
            {
                if (value % 10 == this.Digit)
                {
                    return true;
                }

                value /= 10;
            }

            return false;
        }
    }
}
