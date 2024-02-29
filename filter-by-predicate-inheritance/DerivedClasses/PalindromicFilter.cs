using System;
using FilterByPredicate;

namespace DerivedClasses
{
    /// <summary>
    /// Represents a class filter of the array on palindromic numbers.
    /// </summary> 
    public class PalindromicFilter : Filter
    {
        protected override bool IsMatch(int item)
        {
            if (item < 0)
            {
                return false;
            }

            string itemAsString = item.ToString();
            string reversedItem = new string(itemAsString.Reverse().ToArray());

            return itemAsString == reversedItem;
        }
    }
}
