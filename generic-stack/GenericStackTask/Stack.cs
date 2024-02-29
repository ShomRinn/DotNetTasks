using System;
using System.Collections;
using System.Collections.Generic;
#pragma warning disable CA1711

namespace GenericStackTask
{
    /// <summary>
    /// Represents extendable last-in-first-out (LIFO) collection of the specified type T.
    /// </summary>
    /// <typeparam name="T">Specifies the type of elements in the stack.</typeparam>
    public class Stack<T> : IEnumerable<T>
    {
        private T[] items;
        private int count;
        private int version;

        /// <summary>
        /// Initializes a new instance of the <see cref="Stack{T}"/> class that is empty and has the default initial capacity.
        /// </summary>
        public Stack()
            : this(0)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Stack{T}"/> class that is empty and has.
        /// the specified initial capacity.
        /// </summary>
        /// <param name="capacity">The initial number of elements of stack.</param>
        public Stack(int capacity)
            : this(new T[capacity])
        {
            if (capacity < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(capacity));
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Stack{T}"/> class that contains elements copied.
        /// from the specified collection and has sufficient capacity to accommodate the
        /// number of elements copied.
        /// </summary>
        /// <param name="collection">The collection to copy elements from.</param>
        public Stack(IEnumerable<T>? collection)
        {
            this.items = collection == null ? throw new ArgumentNullException(nameof(collection)) : collection.ToArray();
            this.count = collection.Count();
            this.version = 0;
        }

        /// <summary>
        /// Gets the number of elements contained in the stack.
        /// </summary>
        public int Count => this.count;

        /// <summary>
        /// Removes and returns the object at the top of the stack.
        /// </summary>
        /// <returns>The object removed from the top of the stack.</returns>
        public T Pop()
        {
            if (this.count == 0)
            {
                throw new InvalidOperationException(nameof(this.count));
            }

            T item = this.items[this.count - 1];
            this.items[this.count - 1] = default!;
            this.count--;
            this.version++;
            return item;
        }

        /// <summary>
        /// Returns the object at the top of the stack without removing it.
        /// </summary>
        /// <returns>The object at the top of the stack.</returns>
        public T Peek() => this.items[this.count - 1];

        /// <summary>
        /// Inserts an object at the top of the stack.
        /// </summary>
        /// <param name="item">The object to push onto the stack.
        /// The value can be null for reference types.</param>
        public void Push(T item)
        {
            if (this.count == this.items.Length)
            {
                int newCapacity = this.items.Length == 0 ? 4 : this.items.Length * 2;
                Array.Resize(ref this.items, newCapacity);
            }

            this.items[this.count] = item;
            this.count++;
            this.version++;
        }

        /// <summary>
        /// Copies the elements of stack to a new array.
        /// </summary>
        /// <returns>A new array containing copies of the elements of the stack.</returns>
        public T[] ToArray()
        {
            T[] result = new T[this.count];
            Array.Copy(this.items, result, this.count);
            Array.Reverse(result);
            return result;
        }

        /// <summary>
        /// Determines whether an element is in the stack.
        /// </summary>
        /// <param name="item">The object to locate in the stack. The value can be null for reference types.</param>
        /// <returns>Return true if item is found in the stack; otherwise, false.</returns>
        public bool Contains(T item)
        {
            EqualityComparer<T> comparer = EqualityComparer<T>.Default;
            for (int i = 0; i < this.count; i++)
            {
                if (comparer.Equals(this.items[i], item))
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Removes all objects from the stack.
        /// </summary>
        public void Clear()
        {
            this.count = 0;
            this.items = Array.Empty<T>();
            this.version++;
        }

        /// <summary>
        /// Returns an enumerator for the stack.
        /// </summary>
        /// <returns>Return Enumerator object for the stack.</returns>
        public IEnumerator<T> GetEnumerator()
        {
            int initialVersion = this.version;
            for (int i = this.count - 1; i >= 0; i--)
            {
                if (this.version != initialVersion)
                {
                    throw new InvalidOperationException("The stack was modified during enumeration.");
                }

                yield return this.items[i];
            }
        }

        /// <summary>
        /// Returns an enumerator for the stack.
        /// </summary>
        /// <returns>Return Enumerator object for the stack.</returns>
        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();
    }
}
