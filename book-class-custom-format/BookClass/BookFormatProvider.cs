using System;

namespace BookClass
{
    public class BookFormatProvider : IFormatProvider, ICustomFormatter
    {
        public object? GetFormat(Type? formatType) => formatType == typeof(ICustomFormatter) ? this : null;

        public string Format(string? format, object? arg, IFormatProvider? formatProvider)
        {
            if (arg is Book book)
            {
                return $"Product details:" +
                    $"\nAuthor: {book.Author}" +
                    $"\nTitle: {book.Title}" +
                    $"\nPublisher: {book.Publisher}, {book.Year}" +
                    $"\nISBN-13: {book.ISBN}" +
                    $"\nPaperback: {book.Pages} pages";
            }
            throw new ArgumentException("The argument is not a Book object.");
        }
    }
}
