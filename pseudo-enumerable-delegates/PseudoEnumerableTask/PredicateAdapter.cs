using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PseudoEnumerableTask.Interfaces;

namespace PseudoEnumerableTask
{
    /// <summary>
    /// Predicate Adapter.
    /// </summary>
    /// <typeparam name="TSource">Tsource.</typeparam>
    public class PredicateAdapter<TSource> : IPredicate<TSource>
    {
        private readonly Predicate<TSource> predicate;

        /// <summary>
        /// Initializes a new instance of the <see cref="PredicateAdapter{TSource}"/> class.
        /// Predicat eAdapter.
        /// </summary>
        /// <param name="predicate">predicate.</param>
        public PredicateAdapter(Predicate<TSource> predicate)
        {
            this.predicate = predicate;
        }

        /// <summary>
        /// Represents the method that defines a set of criteria and determines whether the specified object meets those criteria.
        /// </summary>
        /// <param name="obj">The object to compare against the criteria.</param>
        /// <returns>true if obj meets the criteria defined within the method; otherwise, false.</returns>
        public bool Verify(TSource obj) => this.predicate(obj);
    }
}
