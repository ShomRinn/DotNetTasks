using System;
using System.Numerics;

namespace FibonacciTask
{
    /// <summary>
    /// Generator for Fibonacci sequence.
    /// </summary>
    /// <seealso cref="https://en.wikipedia.org/wiki/Fibonacci_number"/>
    public class FibonacciSequenceGenerator
    {
        private readonly int count;
        private BigInteger previous;
        private BigInteger current;
        private int currentIndex;

        /// <summary>
        /// Initializes a new instance of the <see cref="FibonacciSequenceGenerator"/> class.
        /// </summary>
        /// <param name="count">Count of elements in Fibonacci sequence.</param>
        /// <exception cref="ArgumentException">Thrown if count of elements less than one.</exception>
        public FibonacciSequenceGenerator(int count)
        {
            if (count < 1)
            {
                throw new ArgumentException("Count of elements cannot be less than one.");
            }

            this.count = count;
            this.Reset();
        }

        /// <summary>
        /// Gets current element in Fibonacci sequence.
        /// </summary>
        /// <value>
        /// Value of current element in Fibonacci sequence.
        /// </value>
        public BigInteger Current
        {
            get => this.current;
            private set => this.current = value;
        }

        /// <summary>
        /// Moves to the next element in the sequence.
        /// </summary>
        /// <returns>
        /// True if there are elements in the sequence, false otherwise.
        /// </returns>
        public bool MoveNext()
        {
            if (this.currentIndex >= this.count)
            {
                return false;
            }

            if (this.currentIndex <= 1)
            {
                this.Current = this.currentIndex;
            }
            else
            {
                var next = this.current + this.previous;
                this.previous = this.current;
                this.Current = next;
            }

            this.currentIndex++;
            return true;
        }

        /// <summary>
        /// Resets the sequence to the beginning.
        /// </summary>
        public void Reset()
        {
            this.previous = 0;
            this.Current = 0;
            this.currentIndex = 0;
        }
    }
}
