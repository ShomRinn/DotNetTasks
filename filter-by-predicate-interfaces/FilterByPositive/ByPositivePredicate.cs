using FilterByPredicate;

namespace FilterByPositive
{
    public class ByPositivePredicate : IPredicate
    {
        /// <inheritdoc/>
        public bool IsMatch(int number)
        {
            return number > 0;
        }
    }
}
