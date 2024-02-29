using System;
using System.Globalization;

namespace BookClass
{
    public sealed class Book : IEquatable<Book>, IComparable<Book>, IComparable, IFormattable
    {
        private bool published = false;
        private DateTime datePublished;
        private int totalPages;
        private string? priceCurrency;
        private decimal priceAmount;

        public Book(string author, string title, string publisher) : this(author, title, publisher, string.Empty)
        {
        }

        public Book(string author, string title, string publisher, string isbn)
        {
            Author = author;
            Title = title;
            Publisher = publisher;
            ISBN = isbn;
        }

        public string Title { get; }

        public int Pages
        {
            get => totalPages;
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(value));
                }
                totalPages = value;
            }
        }

        public string Publisher { get; }

        public string ISBN { get; }

        public string Author { get; }

        public string Price
        {
            get
            {
                var cultureInfo = new CultureInfo(priceCurrency ?? "USD");
                return priceAmount.ToString("C", cultureInfo);
            }
        }

        public string? Currency => priceCurrency;

        public void Publish(DateTime date)
        {
            published = true;
            datePublished = date;
        }

        public void SetPrice(decimal price, string currency)
        {
            priceAmount = price;
            priceCurrency = currency;
        }

        public override string ToString() => $"{Title} by {Author}";

        public string ToString(string? format, IFormatProvider? formatProvider)
        {
            switch (format)
            {
                case "F":
                    return $"{Title} by {Author}. {datePublished.Year}. {Publisher}. ISBN: {ISBN}. {Pages} pages. {Price}.";
                case "P":
                    return $"{Title} by {Author}. {datePublished.Year}. {Publisher}. ISBN: {ISBN}. {Pages} pages.";
                case "S":
                    return $"{Title} by {Author}. {datePublished.Year}. {Publisher}. {Pages} pages.";
                case "T":
                    return $"{Title} by {Author}. {datePublished.Year}. {Pages} pages.";
                case "C":
                    return $"{Title} by {Author} {Price}.";
                default:
                    return ToString();
            }
        }

        public string GetPublicationDate()
        {
            return published ? datePublished.ToString("d") : "Not published yet.";
        }

        public override bool Equals(object? obj) => obj is Book book && Equals(book);

        public bool Equals(Book? other)
        {
            return other is not null && ISBN == other.ISBN;
        }

        public override int GetHashCode() => ISBN.GetHashCode();

        public int CompareTo(Book? other)
        {
            if (other is null)
            {
                return 1;
            }

            return Title.CompareTo(other.Title);
        }

        public int CompareTo(object? obj)
        {
            if (obj == null)
            {
                return 1;
            }

            if (obj is Book otherBook)
            {
                return CompareTo(otherBook);
            }

            throw new ArgumentException("Object is not a Book");
        }

        public static bool operator ==(Book left, Book right)
        {
            return ReferenceEquals(left, null) ? ReferenceEquals(right, null) : left.Equals(right);
        }

        public static bool operator !=(Book left, Book right)
        {
            return !(left == right);
        }

        public static bool operator <(Book left, Book right)
        {
            return ReferenceEquals(left, null) ? !ReferenceEquals(right, null) : left.CompareTo(right) < 0;
        }

        public static bool operator <=(Book left, Book right)
        {
            return ReferenceEquals(left, null) || left.CompareTo(right) <= 0;
        }

        public static bool operator >(Book left, Book right)
        {
            return !ReferenceEquals(left, null) && left.CompareTo(right) > 0;
        }

        public static bool operator >=(Book left, Book right)
        {
            return ReferenceEquals(left, null) ? ReferenceEquals(right, null) : left.CompareTo(right) >= 0;
        }
    }
}
