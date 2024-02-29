#pragma warning disable S1210
#pragma warning disable CA1036
using System;

namespace BookClass
{
    /// <summary>
    /// Class that represents book.
    /// </summary>
    public class Book : IComparable
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Book"/> class.
        /// </summary>
        /// <param name="author">Author of the book.</param>
        /// <param name="title">Title of the book.</param>
        /// <param name="publisher">Publisher of the book.</param>
        /// <exception cref="ArgumentNullException">Throw when author or title or publisher is null.</exception>
        public Book(string author, string title, string publisher)
        {
            this.Author = author ?? throw new ArgumentNullException(nameof(author), "Author cannot be null or empty.");
            this.Title = title ?? throw new ArgumentNullException(nameof(title), "Author cannot be null or empty.");
            this.Publisher = publisher ?? throw new ArgumentNullException(nameof(publisher), "Author cannot be null or empty.");
        }

        /// <summary>
        /// Gets author name.
        /// </summary>
        public string Author { get; private set; }

        /// <summary>
        /// Gets title.
        /// </summary>
        public string Title { get; private set; }

        /// <summary>
        /// Gets publisher name.
        /// </summary>
        public string Publisher { get; private set; }

        /// <summary>
        /// Compares book to object.
        /// </summary>
        /// <param name="obj">other object.</param>
        /// <returns>1, 0 or -1.</returns>
        /// <exception cref="ArgumentException">Thrown if object is not a book.</exception>
        public int CompareTo(object? obj)
        {
            if (obj == null)
            {
                return 1;
            }

            var otherBook = obj as Book;
            if (otherBook == null)
            {
                throw new ArgumentException("Object is not a Book");
            }

            return string.Compare(this.Title, otherBook.Title, StringComparison.Ordinal);
        }
    }
}
