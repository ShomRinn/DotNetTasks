using ContainsDigitPredicate;
using GenericMethodsTask.Interfaces;

namespace Adapters
{
    /// <summary>
    /// Predicate that determines the presence of some digit in integer.
    /// </summary>
    public class ContainsDigitPredicateAdapter : IPredicate<int>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ContainsDigitPredicateAdapter"/> class.
        /// </summary>
        /// <param name="validator">ContainsDigitValidator object.</param>
        /// <exception cref="ArgumentNullException">Thrown when validator is null.</exception>
        public ContainsDigitPredicateAdapter(ContainsDigitValidator? validator)
        {
            this.Validator = validator ?? throw new ArgumentNullException(nameof(validator));
        }

        /// <summary>
        /// Gets the validator.
        /// </summary>
        private ContainsDigitValidator Validator { get; }

        /// <summary>
        /// Represents the method that finds digit.
        /// </summary>
        /// <param name="obj">Given value.</param>
        /// <returns>Result of matching.</returns>
        public bool Verify(int obj)
        {
            return this.Validator.Verify(obj);
        }
    }
}
