using System;

namespace BookStoreCatalog
{
    /// <summary>
    /// Represents an item in a book store.
    /// </summary>
    public class BookStoreItem
    {
        private BookPublication publication;
        private BookPrice price;
        private int amount;

        /// <summary>
        /// Initializes a new instance of the <see cref="BookStoreItem"/> class with the specified <paramref name="authorName"/>, <paramref name="isniCode"/>, <paramref name="title"/>, <paramref name="publisher"/>, <paramref name="published"/>, <paramref name="bookBinding"/>, <paramref name="isbn"/>, <paramref name="priceAmount"/>, <paramref name="priceCurrency"/> and <paramref name="amount"/>.
        /// </summary>
        public BookStoreItem(string authorName, string isniCode, string title, string publisher, DateTime published, BookBindingKind bookBinding, string isbn, decimal priceAmount, string priceCurrency, int amount)
            : this(new BookPublication(authorName, isniCode, title, publisher, published, bookBinding, isbn), new BookPrice(priceAmount, priceCurrency), amount)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BookStoreItem"/> class with the specified <paramref name="publication"/>, <paramref name="price"/> and <paramref name="amount"/>.
        /// </summary>
        public BookStoreItem(BookPublication publication, BookPrice price, int amount)
        {
            _ = publication ?? throw new ArgumentNullException(nameof(publication));
            _ = price ?? throw new ArgumentNullException(nameof(price));
            _ = amount >= 0 ? amount : throw new ArgumentOutOfRangeException(nameof(amount));

            this.publication = publication;
            this.price = price;
            this.amount = amount;
        }

        /// <summary>
        /// Gets or sets the publication of the book store item.
        /// </summary>
        public BookPublication Publication
        {
            get
            {
                return this.publication;
            }

            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException(nameof(value));
                }

                this.publication = value;
            }
        }

        /// <summary>
        /// Gets or sets the price of the book store item.
        /// </summary>
        public BookPrice Price
        {
            get
            {
                return this.price;
            }

            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException(nameof(value));
                }

                this.price = value;
            }
        }

        /// <summary>
        /// Gets or sets the amount of books in the store's stock.
        /// </summary>
        public int Amount
        {
            get
            {
                return this.amount;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(value));
                }

                this.amount = value;
            }
        }

        /// <summary>
        /// Returns the string representation of the book store item.
        /// </summary>
        public override string ToString()
        {
            string priceToString = this.Price.ToString();
            if (this.Price.ToString().Contains(',', StringComparison.InvariantCulture))
            {
                priceToString = $"\"{priceToString}\"";
            }

            return $"{this.Publication.ToString()}, {priceToString}, {this.Amount}";
        }
    }
}
