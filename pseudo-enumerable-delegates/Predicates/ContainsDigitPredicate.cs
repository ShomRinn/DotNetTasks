using System;
using PseudoEnumerableTask.Interfaces;

namespace Predicates
{
    /// <summary>
    /// ContainsDigitPredicate.
    /// </summary>
    public class ContainsDigitPredicate : IPredicate<int>
    {
        private int digit;

        /// <summary>
        /// Gets or sets the digit.
        /// </summary>
        /// <value>
        /// The digit.
        /// </value>
        /// <exception cref="System.ArgumentOutOfRangeException">value - Digit value is out of range (0..9).</exception>
        public int Digit
        {
            get
            {
                return this.digit;
            }

            set => this.digit = value < 0 || value > 9 ? throw new ArgumentOutOfRangeException(nameof(value), "digit cannot be out of range 0..9") : value;
        }

        /// <summary>
        /// Represents the method that defines a set of criteria and determines whether the specified object meets those criteria.
        /// </summary>
        /// <param name="obj">The object to compare against the criteria.</param>
        /// <returns>
        /// true if obj meets the criteria defined within the method; otherwise, false.
        /// </returns>
        public bool Verify(int obj)
        {
            if (obj == 0)
            {
                return this.Digit == 0;
            }

            if (obj < 0)
            {
                obj = obj == int.MinValue ? int.MaxValue : Math.Abs(obj);
            }

            while (obj != 0)
            {
                if (obj % 10 == this.Digit)
                {
                    return true;
                }

                obj /= 10;
            }

            return false;
        }
    }
}
