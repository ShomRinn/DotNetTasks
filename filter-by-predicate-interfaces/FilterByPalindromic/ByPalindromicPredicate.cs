#pragma warning disable CA1305
using FilterByPredicate;

namespace FilterByPalindromic
{
    /// <summary>
    /// Palindrome predicate.
    /// </summary>
    public class ByPalindromicPredicate : IPredicate
    {
        /// <inheritdoc/>
        public bool IsMatch(int number)
        {
            if (number < 0)
            {
                return false;
            }

            string itemAsString = number.ToString();
            string reversedItem = new string(itemAsString.Reverse().ToArray());

            return itemAsString == reversedItem;
        }
    }
}
