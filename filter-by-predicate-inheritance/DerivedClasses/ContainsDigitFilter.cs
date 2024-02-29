using System;
using FilterByPredicate;

namespace DerivedClasses
{
    /// <summary>
    /// Represents an class filter of the array on a given digit.
    /// </summary>
    public class ContainsDigitFilter : Filter
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

        protected override bool IsMatch(int item)
        {
            return item.ToString().Contains(Digit.ToString());
        }
    }
}
