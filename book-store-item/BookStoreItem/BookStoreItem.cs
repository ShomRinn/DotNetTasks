#pragma warning disable IDE0055

using System.Globalization;

[assembly: CLSCompliant(true)]

namespace BookStoreItem
{
    /// <summary>
    /// Represents an item in a book store.
    /// </summary>
    public class BookStoreItem
    {
        private readonly string authorName;
        private readonly string? isni;
        private readonly bool hasIsni;
        private decimal price;
        private string? currency;
        private int amount;
        private string? bookBinding;

        /// <summary>
        /// Initializes a new instance of the <see cref="BookStoreItem"/> class with the specified <paramref name="authorName"/>, <paramref name="title"/>, <paramref name="publisher"/> and <paramref name="isbn"/>.
        /// </summary>
        /// <param name="authorName">A book author's name.</param>
        /// <param name="title">A book title.</param>
        /// <param name="publisher">A book publisher.</param>
        /// <param name="isbn">A book ISBN.</param>
        public BookStoreItem(
            string authorName,
            string title,
            string publisher,
            string isbn)
            : this(authorName, title, publisher, isbn, null, string.Empty, 0, "USD", 0)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BookStoreItem"/> class with the specified <paramref name="authorName"/>, <paramref name="isni"/>, <paramref name="title"/>, <paramref name="publisher"/> and <paramref name="isbn"/>.
        /// </summary>
        /// <param name="authorName">A book author's name.</param>
        /// <param name="isni">A book author's ISNI.</param>
        /// <param name="title">A book title.</param>
        /// <param name="publisher">A book publisher.</param>
        /// <param name="isbn">A book ISBN.</param>
        public BookStoreItem(
            string authorName,
            string isni,
            string title,
            string publisher,
            string isbn)
            : this(authorName, isni, title, publisher, isbn, null, string.Empty, 0, "USD", 0)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BookStoreItem"/> class with the specified <paramref name="authorName"/>, <paramref name="title"/>, <paramref name="publisher"/> and <paramref name="isbn"/>, <paramref name="published"/>, <paramref name="bookBinding"/>, <paramref name="price"/>, <paramref name="currency"/> and <paramref name="amount"/>.
        /// </summary>
        /// <param name="authorName">A book author's name.</param>
        /// <param name="title">A book title.</param>
        /// <param name="publisher">A book publisher.</param>
        /// <param name="isbn">A book ISBN.</param>
        /// <param name="published">A book publishing date.</param>
        /// <param name="bookBinding">A book binding type.</param>
        /// <param name="price">An amount of money that a book costs.</param>
        /// <param name="currency">A price currency.</param>
        /// <param name="amount">An amount of books in the store's stock.</param>
        public BookStoreItem(
            string authorName,
            string title,
            string publisher,
            string isbn,
            DateTime? published,
            string bookBinding,
            decimal price,
            string currency,
            int amount)
        {
            ThrowExceptionIfCurrencyIsNotValid(currency);
            this.authorName = !string.IsNullOrWhiteSpace(authorName) ? authorName : throw new ArgumentException("authorName is null or whitespace.", nameof(authorName));
            this.Title = !string.IsNullOrWhiteSpace(title) ? title : throw new ArgumentException("title is not valid.", nameof(title));
            this.Publisher = !string.IsNullOrWhiteSpace(publisher) ? publisher : throw new ArgumentException("publisher is not valid.", nameof(publisher));
            this.Isbn = (ValidateIsbnFormat(isbn) || ValidateIsbnChecksum(isbn)) ? isbn : throw new ArgumentException("isbn is not valid.", nameof(isbn));
            this.Published = published;
            this.bookBinding = bookBinding;
            this.price = price;
            this.currency = currency;
            this.amount = amount;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BookStoreItem"/> class with the specified <paramref name="authorName"/>, <paramref name="isni"/>, <paramref name="title"/>, <paramref name="publisher"/> and <paramref name="isbn"/>, <paramref name="published"/>, <paramref name="bookBinding"/>, <paramref name="price"/>, <paramref name="currency"/> and <paramref name="amount"/>.
        /// </summary>
        /// <param name="authorName">A book author's name.</param>
        /// <param name="isni">A book author's ISNI.</param>
        /// <param name="title">A book title.</param>
        /// <param name="publisher">A book publisher.</param>
        /// <param name="isbn">A book ISBN.</param>
        /// <param name="published">A book publishing date.</param>
        /// <param name="bookBinding">A book binding type.</param>
        /// <param name="price">An amount of money that a book costs.</param>
        /// <param name="currency">A price currency.</param>
        /// <param name="amount">An amount of books in the store's stock.</param>
        public BookStoreItem(
            string authorName,
            string isni,
            string title,
            string publisher,
            string isbn,
            DateTime? published,
            string bookBinding,
            decimal price,
            string currency,
            int amount)
            : this(authorName, title, publisher, isbn, published, bookBinding, price, currency, amount)
        {
            this.isni = ValidateIsni(isni) ? isni : throw new ArgumentException("isni is not valid.", nameof(isni));
            this.hasIsni = true;
        }

        /// <summary>
        /// Gets a book author's name.
        /// </summary>
        public string AuthorName
        {
            get { return this.authorName; }
        }

        /// <summary>
        /// Gets an International Standard Name Identifier (ISNI) that uniquely identifies a book author.
        /// </summary>
        public string? Isni
        {
            get { return this.isni; }
        }

        /// <summary>
        /// Gets a value indicating whether an author has an International Standard Name Identifier (ISNI).
        /// </summary>
        public bool HasIsni
        {
            get { return this.hasIsni; }
        }

        /// <summary>
        /// Gets a book title.
        /// </summary>
        public string Title { get; private set; }

        /// <summary>
        /// Gets a book publisher.
        /// </summary>
        public string Publisher { get; private set; }

        /// <summary>
        /// Gets a book International Standard Book Number (ISBN).
        /// </summary>
        public string Isbn { get; private set; }

        /// <summary>
        /// Gets or sets a book publishing date.
        /// </summary>
        public DateTime? Published { get; set; }

        /// <summary>
        /// Gets or sets a book binding type.
        /// </summary>
        public string BookBinding
        {
            get
            {
                return this.bookBinding == null ? string.Empty : this.bookBinding;
            }

            set
            {
                this.bookBinding = value;
            }
        }

        /// <summary>
        /// Gets or sets an amount of money that a book costs.
        /// </summary>
        public decimal Price
        {
            get
            {
                return this.price;
            }

            set
            {
                this.price = value < 0 ? throw new ArgumentOutOfRangeException(nameof(value)) : value;
            }
        }

        /// <summary>
        /// Gets or sets a price currency.
        /// </summary>
        public string Currency
        {
            get
            {
                return this.currency == null ? "USD" : this.currency;
            }

            set
            {
                ThrowExceptionIfCurrencyIsNotValid(this.Currency);
                this.currency = value;
            }
        }

        /// <summary>
        /// Gets or sets an amount of books in the store's stock.
        /// </summary>
        public int Amount
        {
            get
            {
                return this.amount;
            }

            set
            {
                this.amount = value < 0 ? throw new ArgumentOutOfRangeException(nameof(value)) : value;
            }
        }

        /// <summary>
        /// Gets a <see cref="Uri"/> to the contributor's page at the isni.org website.
        /// </summary>
        /// <returns>A <see cref="Uri"/> to the contributor's page at the isni.org website.</returns>
        public Uri GetIsniUri()
        {
            return this.Isni is not null ? new Uri($"https://isni.org/isni/{this.Isni}") : throw new InvalidOperationException();
        }

        /// <summary>
        /// Gets an <see cref="Uri"/> to the publication page on the isbnsearch.org website.
        /// </summary>
        /// <returns>an <see cref="Uri"/> to the publication page on the isbnsearch.org website.</returns>
        public Uri GetIsbnSearchUri()
        {
            return this.Isbn is not null ? new Uri($"https://isbnsearch.org/isbn/{this.Isbn}") : throw new InvalidOperationException();
        }

        /// <summary>
        /// Returns the string that represents a current object.
        /// </summary>
        /// <returns>A string that represents the current object.</returns>
        public new string ToString()
        {
            string priceStr = this.price.ToString("N2", CultureInfo.InvariantCulture);
            string fullPrice = priceStr + " " + this.Currency;
            if (this.price >= 1000)
            {
                fullPrice = $"\"{fullPrice}\"";
            }

            return !this.HasIsni ? string.Join(", ", this.Title, this.AuthorName, "ISNI IS NOT SET", fullPrice, this.Amount) :
                string.Join(", ", this.Title, this.AuthorName, this.Isni, fullPrice, this.Amount);
        }

        private static bool ValidateIsni(string isni)
        {
            if (isni.Length != 16)
            {
                return false;
            }

            for (int i = 0; i < 16; i++)
            {
                if (!char.IsDigit(isni[i]) && isni[i] != 'X')
                {
                    return false;
                }
            }

            return true;
        }

        private static bool ValidateIsbnFormat(string isbn)
        {
            if (isbn.Length != 10)
            {
                return false;
            }

            for (int i = 0; i < 10; i++)
            {
                if (!char.IsDigit(isbn[i]) && isbn[i] != 'X')
                {
                    return false;
                }
            }

            return true;
        }

        private static bool ValidateIsbnChecksum(string isbn)
        {
            if (ValidateIsbnFormat(isbn) is false)
            {
                return false;
            }

            int num, checksum = 0, position = 10;
            for (int i = 0; i < 10; i++)
            {
                if (int.TryParse(isbn[i.. (i + 1)], out num))
                {
                    checksum += num * position;
                    position--;
                    continue;
                }

                if (isbn[i] == 'X')
                {
                    checksum += 10 * position;
                    position--;
                    continue;
                }

                return false;
            }

            return checksum % 11 == 0 && position == 0;
        }

        private static void ThrowExceptionIfCurrencyIsNotValid(string currency)
        {
            if (currency.Length != 3)
            {
                throw new ArgumentException("currency length is not 3", nameof(currency));
            }

            for (int i = 0; i < 3; i++)
            {
                if (!(currency[i] >= 'A' && currency[i] <= 'Z'))
                {
                    throw new ArgumentException("currency characters must be english capital letters.", nameof(currency));
                }
            }
        }
    }
}
