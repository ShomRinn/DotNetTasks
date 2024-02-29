using System;

namespace BookStoreCatalog
{
    /// <summary>
    /// Represents a book author.
    /// </summary>
    public class BookAuthor
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BookAuthor"/> class with the specified author name and no ISNI.
        /// </summary>
        /// <param name="authorName">A book author's name.</param>
        /// <exception cref="ArgumentNullException">Thrown when authorName is null.</exception>
        /// <exception cref="ArgumentException">Thrown when authorName is empty or consists of white-space only characters.</exception>
        public BookAuthor(string authorName)
        {
            this.AuthorName = authorName ??
                throw new ArgumentNullException(nameof(authorName));

            _ = string.IsNullOrWhiteSpace(authorName) ?
                throw new ArgumentException("Author name cannot be empty or consist of white-space characters.", nameof(authorName)) :
                this.AuthorName;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BookAuthor"/> class with the specified author name and 16-digit ISNI code.
        /// </summary>
        /// <param name="authorName">A book author's name.</param>
        /// <param name="isniCode">A 16-digit ISNI code that uniquely identifies a book author.</param>
        /// <exception cref="ArgumentNullException">Thrown when authorName or isniCode is null.</exception>
        /// <exception cref="ArgumentException">Thrown when authorName is empty or consists of white-space only characters.</exception>
        public BookAuthor(string authorName, string isniCode)
            : this(authorName)
        {
            this.Isni = isniCode != null ? new NameIdentifier(isniCode) : throw new ArgumentNullException(nameof(isniCode));
            this.HasIsni = true;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BookAuthor"/> class with the specified author name and ISNI.
        /// </summary>
        /// <param name="authorName">A book author's name.</param>
        /// <param name="isni">An International Standard Name Identifier that uniquely identifies a book author.</param>
        /// <exception cref="ArgumentNullException">Thrown when authorName or isni is null.</exception>
        /// <exception cref="ArgumentException">Thrown when authorName is empty or consists of white-space only characters.</exception>
        public BookAuthor(string authorName, NameIdentifier nameIdentifier)
     : this(authorName)
        {
            _ = nameIdentifier ?? throw new ArgumentNullException(nameof(nameIdentifier));
            this.Isni = nameIdentifier;
            this.HasIsni = true;
        }

        /// <summary>
        /// Gets a book author's name.
        /// </summary>
        public string AuthorName { get; private set; }

        /// <summary>
        /// Gets a value indicating whether an author has an International Standard Name Identifier (ISNI).
        /// </summary>
        public bool HasIsni { get; private set; }

        /// <summary>
        /// Gets an International Standard Name Identifier (ISNI) that uniquely identifies a book author.
        /// </summary>
        public NameIdentifier Isni { get; private set; }

        /// <summary>
        /// Returns the string that represents the current object.
        /// </summary>
        /// <returns>A string that represents the current object.</returns>
        public override string ToString() =>
    this.HasIsni ? $"{this.AuthorName} (ISNI:{this.Isni})" : this.AuthorName;
    }
}
