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
        /// Transforms each element of source sequence from one type to another type by some rule.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of source sequence.</typeparam>
        /// <typeparam name="TResult">The type of the elements of result sequence.</typeparam>
        /// <param name="source">The source sequence.</param>
        /// <param name="transformer">A <see cref="ITransformer{TSource,TResult}"/> that defines the rule of transformation.</param>
        /// <returns>A sequence, each element of which is transformed.</returns>
        /// <exception cref="ArgumentNullException">Thrown when sequence or transformer is null.</exception>
        public static IEnumerable<TResult> Transform<TSource, TResult>(this IEnumerable<TSource> source, ITransformer<TSource, TResult> transformer)
        {
            if (transformer == null)
            {
                throw new ArgumentNullException(nameof(transformer));
            }

            ThrowExceptionIfSequenceIsNullOrEmpty(source, nameof(source));

            return Transform(source, transformer);

            static IEnumerable<TValue> Transform<TSequence, TValue>(IEnumerable<TSequence> source, ITransformer<TSequence, TValue> transformer)
            {
                foreach (var item in source)
                {
                    yield return transformer.Transform(item);
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
                var arr = BufferData.ToArray(source);

                for (int left = 0, right = arr.buffer.Length - 1; left < right; left++, right--)
                {
                    Swap(ref arr.buffer[left], ref arr.buffer[right]);
                }

                foreach (var item in arr.buffer)
                {
                    yield return item;
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
