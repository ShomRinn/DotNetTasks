using FilterByPredicate;

namespace FilterByOdd
{
    /// <summary>
    /// Predcate by odd.
    /// </summary>
    public class ByOddPredicate : IPredicate
    {
        /// <inheritdoc/>
        public bool IsMatch(int number)
        {
            if (number % 2 == 0)
            {
                return false;
            }

            return true;
        }
    }
}
