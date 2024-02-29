using System;
using System.Collections;
using System.Collections.Generic;
using PseudoEnumerableTask.Interfaces;
#pragma warning disable S3267

namespace PseudoEnumerableTask
{
    /// <summary>
    /// Enumerable Sequences.
    /// </summary>
    public static class EnumerableSequences
    {
        /// <summary>
        /// Filters a sequence based on a predicate.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of source sequence.</typeparam>
        /// <param name="source">The source sequence.</param>
        /// <param name="predicate">A <see cref="IPredicate{T}"/> to test each element of a sequence for a condition.</param>
        /// <returns>An sequence of elements from the source sequence that satisfy the condition.</returns>
        /// <exception cref="ArgumentNullException">Thrown when source sequence or predicate is null.</exception>
        public static IEnumerable<TSource> Filter<TSource>(this IEnumerable<TSource> source, IPredicate<TSource> predicate)
        {
            if (predicate == null)
            {
                throw new ArgumentNullException(nameof(predicate));
            }

            ThrowExceptionIfSequenceIsNullOrEmpty(source, nameof(source));

            return Filter(source, predicate);

            static IEnumerable<TValue> Filter<TValue>(IEnumerable<TValue> source, IPredicate<TValue> predicate)
            {
                foreach (var item in source)
                {
                    if (predicate.Verify(item))
                    {
                        yield return item;
                    }
                }
            }
        }

        /// <summary>
        /// Filters a sequence based on a predicate.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of source sequence.</typeparam>
        /// <param name="source">The source sequence.</param>
        /// <param name="predicate">A <see cref="Predicate{T}"/> to test each element of a sequence for a condition.</param>
        /// <returns>An sequence of elements from the source sequence that satisfy the condition.</returns>
        /// <exception cref="ArgumentNullException">Thrown when source sequence or predicate is null.</exception>
        public static IEnumerable<TSource> Filter<TSource>(this IEnumerable<TSource> source, Predicate<TSource> predicate) => source.Filter(new PredicateAdapter<TSource>(predicate));

        /// <summary>
        /// Transforms each element of source sequence from one type to another type by some rule.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of source sequence.</typeparam>
        /// <typeparam name="TResult">The type of the elements of result sequence.</typeparam>
        /// <param name="source">The source sequence.</param>
        /// <param name="transformer">A <see cref="ITransformer{TSource,TResult}"/> that defines the rule of transformation.</param>
        /// <returns>A sequence, each element of which is transformed.</returns>
        /// <exception cref="ArgumentNullException">Thrown when sequence or transformer is null.</exception>
        public static IEnumerable<TResult> Transform<TSource, TResult>(this IEnumerable<TSource> source, ITransformer<TSource, TResult> transformer) => source.Transform(item => transformer.Transform(item));

        /// <summary>
        /// Transforms each element of source sequence from one type to another type by some rule.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of source sequence.</typeparam>
        /// <typeparam name="TResult">The type of the elements of result sequence.</typeparam>
        /// <param name="source">The source sequence.</param>
        /// <param name="converter">A <see cref="Converter{TSource,TResult}"/> that defines the rule of transformation.</param>
        /// <returns>A sequence, each element of which is transformed.</returns>
        /// <exception cref="ArgumentNullException">Thrown when sequence or transformer is null.</exception>
        public static IEnumerable<TResult> Transform<TSource, TResult>(this IEnumerable<TSource> source, Converter<TSource, TResult> converter)
        {
            if (converter == null)
            {
                throw new ArgumentNullException(nameof(converter));
            }

            ThrowExceptionIfSequenceIsNullOrEmpty(source, nameof(source));

            return Transform(source, converter);

            static IEnumerable<TValue> Transform<TSequence, TValue>(IEnumerable<TSequence> source, Converter<TSequence, TValue> transformer)
            {
                foreach (var item in source)
                {
                    yield return transformer(item);
                }
            }
        }

        /// <summary>
        /// Sorts the elements of a sequence in ascending order by using a specified comparer.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of source sequence.</typeparam>
        /// <param name="source">The source sequence.</param>
        /// <param name="comparer">An <see cref="IComparer{T}"/> to compare keys.</param>
        /// <returns>An ordered by comparer sequence.</returns>
        /// <exception cref="ArgumentNullException">Thrown when sequence is null.</exception>
        /// <exception cref="ArgumentNullException">Thrown when comparer is null, and one or more elements
        /// of the sequence do not implement the <see cref="IComparable{T}"/>  interface.
        /// </exception>
        public static IEnumerable<TSource> SortBy<TSource>(this IEnumerable<TSource> source, IComparer<TSource> comparer)
        {
            if (comparer == null)
            {
                throw new ArgumentNullException(nameof(comparer));
            }

            ThrowExceptionIfSequenceIsNullOrEmpty(source, nameof(source));
            return SortBy(source, comparer);
            static IEnumerable<TValue> SortBy<TValue>(IEnumerable<TValue> source, IComparer<TValue> comparer)
            {
                var arr = BufferData.ToArray(source);
                Array.Sort(arr.buffer, comparer);
                foreach (var item in arr.buffer)
                {
                    yield return item;
                }
            }
        }

        /// <summary>
        /// Sorts the elements of a sequence in ascending order by using a specified comparer.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of source sequence.</typeparam>
        /// <param name="source">The source sequence.</param>
        /// <param name="comparer">An <see cref="Comparison{T}"/> to compare keys.</param>
        /// <returns>An ordered by comparer sequence.</returns>
        /// <exception cref="ArgumentNullException">Thrown when sequence is null.</exception>
        /// <exception cref="ArgumentNullException">Thrown when comparer is null, and one or more elements
        /// of the sequence do not implement the <see cref="IComparable{T}"/>  interface.
        /// </exception>
        public static IEnumerable<TSource> SortBy<TSource>(this IEnumerable<TSource> source, Comparison<TSource> comparer) => source.SortBy(Comparer<TSource>.Create(comparer));

        /// <summary>
        /// Filters the elements of source sequence based on a specified type.
        /// </summary>
        /// <typeparam name="TResult">Type selector to return.</typeparam>
        /// <param name="source">The source sequence.</param>
        /// <returns>A sequence that contains the elements from source sequence that have type TResult.</returns>
        /// <exception cref="ArgumentNullException">Thrown when sequence is null.</exception>
        public static IEnumerable<TResult> TypeOf<TResult>(this IEnumerable source)
        {
            ThrowExceptionIfSequenceIsNullOrEmpty(source.Cast<object>(), nameof(source));
            return TypeOf<TResult>(source);
            static IEnumerable<TValue> TypeOf<TValue>(IEnumerable source)
            {
                foreach (var item in source)
                {
                    if (item is TValue resultItem)
                    {
                        yield return resultItem;
                    }
                }
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
            ThrowExceptionIfSequenceIsNullOrEmpty(source, nameof(source));

            return Reverse(source);
            static IEnumerable<TValue> Reverse<TValue>(IEnumerable<TValue> source)
            {
                var stack = new Stack<TValue>(source);

                while (stack.Count > 0)
                {
                    yield return stack.Pop();
                }
            }
        }

        /// <summary>
        /// Swaps two objects.
        /// </summary>
        /// <typeparam name="T">The type of parameters.</typeparam>
        /// <param name="left">First object.</param>
        /// <param name="right">Second object.</param>
        internal static void Swap<T>(ref T left, ref T right) => (left, right) = (right, left);

        private static void ThrowExceptionIfSequenceIsNullOrEmpty<T>(IEnumerable<T> source, string parameterName)
        {
            if (source == null)
            {
                throw new ArgumentNullException(parameterName);
            }

            if (!source.Any())
            {
                throw new ArgumentException("sequence is empty", parameterName);
            }
        }
    }
}
