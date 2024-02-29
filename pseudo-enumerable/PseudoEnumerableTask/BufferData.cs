using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("PseudoEnumerableTask.Tests")]

namespace PseudoEnumerableTask
{
    /// <summary>
    /// Implements array helper methods.
    /// </summary>
    internal static class BufferData
    {
        /// <summary>
        /// Creates array on base of enumerable sequence.
        /// </summary>
        /// <param name="source">The enumerable sequence.</param>
        /// <typeparam name="T">Type of the elements of the sequence.</typeparam>
        /// <returns>Single dimension zero based array.</returns>
        internal static (T[] buffer, int count) ToArray<T>(IEnumerable<T> source)
        {
            if (source is T[] arr)
            {
                return (arr, source.Count());
            }
            else if (source is ICollection<T> collection)
            {
                var count = collection.Count;
                var buffer = new T[count];
                collection.CopyTo(buffer, 0);
                return (buffer, count);
            }
            else
            {
                var array = new T[(int)Math.Pow(2, Math.Ceiling(Math.Log(source.Count(), 2)))];
                int i = 0;
                foreach (var item in source)
                {
                    array[i] = item;
                    i++;
                }

                return (array, source.Count());
            }
        }
    }
}
