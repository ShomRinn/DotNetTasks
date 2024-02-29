using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("BufferArray.Tests")]

namespace BufferArray
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
        public static (T[]? buffer, int count) ToArray<T>(IEnumerable<T>? source)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

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
                var length = source.Count();

                if (length == 0)
                {
                    return (Array.Empty<T>(), length);
                }

                int size = 1;
                while (size < length)
                {
                    size <<= 1;
                }

                T[] array = new T[size];
                Array.Copy(source.ToArray(), array, length);
                return (array, length);
            }
        }
    }
}
