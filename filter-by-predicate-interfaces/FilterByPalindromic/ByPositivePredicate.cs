using FilterByPredicate;

namespace FilterByPositive
{
    /// <summary>
    /// Predicate that determines the presence of some digit in integer.
    /// </summary>
    public class ByPositivePredicate : IPredicate
    {
        /// <inheritdoc/>
        public bool IsMatch(int number)
        {
            if (number <= 0)
            {
                return false;
            }

            return true;
        }
    }
}
