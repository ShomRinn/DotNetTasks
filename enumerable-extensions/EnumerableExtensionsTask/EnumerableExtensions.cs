#pragma warning disable SA1202
#pragma warning disable SA1201
#pragma warning disable S4136
#pragma warning disable S3267
#pragma warning disable S3260
using System;
using System.Collections;
using System.Collections.Generic;

namespace EnumerableExtensionsTask
{
    /// <summary>
    /// Enumerable Sequences.
    /// </summary>
    public static class EnumerableExtensions
    {
        /// <summary>
        /// Filters a sequence based on a predicate.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of source sequence.</typeparam>
        /// <param name="source">The source sequence.</param>
        /// <param name="predicate">A
        ///     <see>
        ///         <cref>Func{T, bool}</cref>
        ///     </see>
        ///     to test each element of a sequence for a condition.</param>
        /// <returns>An sequence of elements from the source sequence that satisfy the condition.</returns>
        /// <exception cref="ArgumentNullException">Thrown when source sequence or predicate is null.</exception>
        public static IEnumerable<TSource> Where<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            if (predicate == null)
            {
                throw new ArgumentNullException(nameof(predicate));
            }

            return WherePredicate(source, predicate);
        }

        private static IEnumerable<TSource> WherePredicate<TSource>(IEnumerable<TSource> source, Func<TSource, bool> predicate)
        {
            foreach (TSource item in source)
            {
                if (predicate(item))
                {
                    yield return item;
                }
            }
        }

        /// <summary>
        /// Transforms each element of source sequence from one type to another type by some rule.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of source sequence.</typeparam>
        /// <typeparam name="TResult">The type of the elements of result sequence.</typeparam>
        /// <param name="source">The source sequence.</param>
        /// <param name="selector">A <see cref="Func{TSource,TResult}"/> that defines the rule of transformation.</param>
        /// <returns>A sequence, each element of which is transformed.</returns>
        /// <exception cref="ArgumentNullException">Thrown when sequence or transformer is null.</exception>
        public static IEnumerable<TResult> Select<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, TResult> selector)
        {
            if (source == null || selector is null)
            {
                throw new ArgumentNullException($"{source}, {selector}");
            }

            return SelectIterator(source, selector);
        }

        private static IEnumerable<TResult> SelectIterator<TSource, TResult>(IEnumerable<TSource> source, Func<TSource, TResult> selector)
        {
            foreach (var item in source)
            {
                yield return selector(item);
            }
        }

        /// <summary>
        /// Creates an array from a IEnumerable.
        /// </summary>
        /// <typeparam name="TSource">The type of the source.</typeparam>
        /// <param name="source">The source.</param>
        /// <returns>An array that contains the elements from the input sequence.</returns>
        /// <exception cref="ArgumentNullException">Thrown when sequence or transformer is null.</exception>
        public static TSource[] ToArray<TSource>(this IEnumerable<TSource> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            var list = new List<TSource>();
            foreach (TSource item in source)
            {
                list.Add(item);
            }

            return list.ToArray();
        }

        /// <summary>
        /// Determines whether all elements of a sequence satisfy a condition.
        /// </summary>
        /// /// <typeparam name="T">Type.</typeparam>
        /// <param name="source">The source.</param>
        /// <param name="predicate">The predicate.</param>
        /// <returns>true if every element of the source sequence passes the test in the specified predicate,
        /// or if the sequence is empty; otherwise, false.</returns>
        /// <exception cref="System.ArgumentNullException">
        /// source - Source can not be null.
        /// or
        /// predicate - Predicate can not be null.
        /// </exception>
        public static bool All<T>(this IEnumerable<T> source, Func<T, bool> predicate)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source), $"Source can not be null.");
            }

            if (predicate == null)
            {
                throw new ArgumentNullException(nameof(predicate));
            }

            foreach (var element in source)
            {
                if (!predicate(element))
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Generates a sequence of integral numbers within a specified range.
        /// </summary>
        /// <param name="start">The start.</param>
        /// <param name="count">The count.</param>
        /// <returns>An IEnumerable that contains a range of sequential integral numbers.</returns>
        /// <exception cref="System.ArgumentOutOfRangeException">count - Count can not be less than zero.</exception>
        public static IEnumerable<int> Range(int start, int count)
        {
            if (count < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(count), "Count can not be less than zero.");
            }

            return RangeIterator(start, count);
        }

        private static IEnumerable<int> RangeIterator(int start, int count)
        {
            for (int i = start; i < start + count; i++)
            {
                yield return i;
            }
        }

        /// <summary>
        /// Returns the number of elements in a sequence.
        /// </summary>
        /// <typeparam name="TSource">The type of the source.</typeparam>
        /// <param name="source">The source.</param>
        /// <returns>The number of elements in the input sequence.</returns>
        /// <exception cref="ArgumentNullException">Thrown when sequence is null.</exception>
        public static int Count<TSource>(this IEnumerable<TSource> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source), $"Source can not be null.");
            }

            return CountItems(source);
        }

        private static int CountItems<TSource>(IEnumerable<TSource> source)
        {
            int count = 0;
            foreach (var item in source)
            {
                count++;
            }

            return count;
        }

        /// <summary>
        /// Returns the number of elements in a sequence.
        /// </summary>
        /// <typeparam name="TSource">The type of the source.</typeparam>
        /// <param name="source">The source.</param>
        /// <param name="predicate">The predicate.</param>
        /// <returns>The number of elements in the input sequence.</returns>
        /// <exception cref="System.ArgumentNullException">
        /// source - Source can not be null.
        /// or
        /// predicate - Predicate can not be null.
        /// </exception>
        public static int Count<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            if (predicate == null)
            {
                throw new ArgumentNullException(nameof(predicate));
            }

            return CountItems(source, predicate);
        }

        private static int CountItems<TSource>(IEnumerable<TSource> source, Func<TSource, bool> predicate)
        {
            int count = 0;
            foreach (var item in source)
            {
                if (predicate(item))
                {
                    count++;
                }
            }

            return count;
        }

        /// <summary>
        /// Sorts the elements of a sequence in ascending order.
        /// </summary>
        /// <typeparam name="TSource">The type of the source.</typeparam>
        /// <typeparam name="TKey">The type of the key.</typeparam>
        /// <param name="source">The source.</param>
        /// <param name="key">A function to extract a key from an element.</param>
        /// <returns>An IOrderedEnumerable whose elements are sorted according to a key.</returns>
        public static IEnumerable<TSource> OrderBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> key)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source), $"Source can not be null.");
            }

            return new DeferredOrderEnumerable<TSource, TKey>(source, key);
        }

        private class DeferredOrderEnumerable<TSource, TKey> : IEnumerable<TSource>
        {
            private readonly IEnumerable<TSource> source;
            private readonly Func<TSource, TKey> keySelector;
            private readonly IComparer<TKey> comparer;

            public DeferredOrderEnumerable(IEnumerable<TSource> source, Func<TSource, TKey> keySelector)
            {
                this.source = source;
                this.keySelector = keySelector;
                this.comparer = this.comparer ?? Comparer<TKey>.Default;
            }

            public IEnumerator<TSource> GetEnumerator()
            {
                return this.source.OrderBy(this.keySelector, this.comparer).GetEnumerator();
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return this.GetEnumerator();
            }
        }

        /// <summary>
        /// Sorts the elements of a sequence in ascending order according to a key.
        /// </summary>
        /// <typeparam name="TSource">The type of the source.</typeparam>
        /// <typeparam name="TKey">The type of the key.</typeparam>
        /// <param name="source">The source.</param>
        /// <param name="key">A function to extract a key from an element.</param>
        /// <param name="comparer">The comparer.</param>
        /// <returns>An IOrderedEnumerable whose elements are sorted according to a key.</returns>
        /// <exception cref="System.ArgumentNullException">
        /// source - Source can not be null.
        /// or
        /// getKey - Get Key can not be null.
        /// </exception>
        public static IEnumerable<TSource> OrderBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> key, IComparer<TKey> comparer)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source), $"Source can not be null.");
            }

            if (key == null)
            {
                throw new ArgumentNullException(nameof(key));
            }

            var list = new List<TSource>(source);
            list.Sort((x, y) => comparer.Compare(key(x), key(y)));

            return list;
        }

        /// <summary>
        /// Filters the elements of source sequence based on a specified type.
        /// </summary>
        /// <typeparam name="TResult">Type selector to return.</typeparam>
        /// <param name="source">The source sequence.</param>
        /// <returns>A sequence that contains the elements from source sequence that have type TResult.</returns>
        /// <exception cref="ArgumentNullException">Thrown when sequence is null.</exception>
        public static IEnumerable<TResult> OfType<TResult>(this IEnumerable source)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source), $"Source can not be null.");
            }

            return FilterByType<TResult>(source);
        }

        private static IEnumerable<TResult> FilterByType<TResult>(IEnumerable source)
        {
            foreach (var item in source)
            {
                if (item is TResult)
                {
                    yield return (TResult)item;
                }
            }
        }

        /// <summary>
        /// Filters the elements of source sequence based on a specified type.
        /// </summary>
        /// <typeparam name="TResult">Type selector to return.</typeparam>
        /// <param name="source">The source sequence.</param>
        /// <returns>A sequence that contains the elements from source sequence that have type TResult.</returns>
        /// <exception cref="ArgumentNullException">Thrown when sequence is null.</exception>
        public static IEnumerable<TResult> Cast<TResult>(this IEnumerable source)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source), $"Source can not be null.");
            }

            return CastToType<TResult>(source);
        }

        private static IEnumerable<TResult> CastToType<TResult>(IEnumerable source)
        {
            foreach (var item in source)
            {
                yield return (TResult)item;
            }
        }

        /// <summary>
        /// Inverts the order of the elements in a sequence.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of sequence.</typeparam>
        /// <param name="source">A sequence of elements to reverse.</param>
        /// <exception cref="ArgumentNullException">Thrown when sequence is null.</exception>
        /// <returns>Reversed source.</returns>
        public static IEnumerable<TSource> Reverse<TSource>(this IEnumerable<TSource> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source), $"Source can not be null.");
            }

            return ReverseIterator(source);
        }

        private static IEnumerable<TSource> ReverseIterator<TSource>(IEnumerable<TSource> source)
        {
            List<TSource> list = source.ToList();
            for (int i = list.Count - 1; i >= 0; i--)
            {
                yield return list[i];
            }
        }

        /// <summary>
        /// Swaps two objects.
        /// </summary>
        /// <typeparam name="T">The type of parameters.</typeparam>
        /// <param name="left">First object.</param>
        /// <param name="right">Second object.</param>
        internal static void Swap<T>(ref T left, ref T right)
        {
            T temp = left;
            left = right;
            right = temp;
        }
    }
}
