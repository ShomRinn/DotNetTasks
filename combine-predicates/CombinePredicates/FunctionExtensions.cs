using System;

namespace CombinePredicates
{
    public static class FunctionExtensions
    {
        /// <summary>
        ///   Combines several predicates using logical AND operator 
        /// </summary>
        /// <param name="predicates">array of predicates</param>
        /// <returns>
        ///   Returns a new predicate that combine the specified predicated using AND operator
        /// </returns>
        /// <example>
        ///   var result = CombinePredicatesWithAnd(
        ///            x => !string.IsNullOrEmpty(x),
        ///            x => x.StartsWith("START"),
        ///            x => x.EndsWith("END"),
        ///            x => x.Contains("#"));
        ///   should return the predicate that identical to 
        ///   x=> (!string.IsNullOrEmpty(x)) && x.StartsWith("START") && x.EndsWith("END") && x.Contains("#")
        ///
        ///   The following example should create predicate that returns true if int value between -10 and 10:
        ///   var result = CombinePredicatesWithAnd(x => x > -10, x => x < 10);
        /// </example>
        /// <exception cref="ArgumentNullException">Throw when predicates is null.</exception>
        public static Predicate<T> CombinePredicatesWithAnd<T>(params Predicate<T>[] predicates)
        {
            if (predicates == null)
            {
                throw new ArgumentNullException(nameof(predicates));
            }

            return value =>
            {
                foreach (var predicate in predicates)
                {
                    if (!predicate(value))
                    {
                        return false;
                    }
                }

                return true;
            };
        }
    }
}
