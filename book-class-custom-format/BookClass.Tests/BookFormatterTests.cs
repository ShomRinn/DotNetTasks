using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookClass;
using NUnit.Framework;

namespace BookClass.Tests
{
    [TestFixture]
    public class BookFormatterTests
    {
        private Book? book;
        private BookFormatProvider? bookFormat;

        [SetUp]
        public void Setup()
        {
            this.book = new Book
            {
                Title = "C# in Depth",
                Author = "Jon Skeet",
                Year = 2019,
                Publisher = "Manning Publications",
                ISBN = "9781617294532",
                Pages = 528,
                Price = 39.99m,
            };

            this.bookFormat = new BookFormatProvider();
        }

        [Test]
        public void ShouldFormatBookDetailsCorrectly()
        {
            string expectedFormat = "Product details:" +
                "\nAuthor: Jon Skeet" +
                "\nTitle: C# in Depth" +
                "\nPublisher: Manning Publications, 2019" +
                "\nISBN-13: 9781617294532" +
                "\nPaperback: 528 pages";
            string actualFormat = string.Format(this.bookFormat, "{0}", this.book);

            Assert.AreEqual(expectedFormat, actualFormat);
        }

        [Test]
        public void ShouldThrowArgumentExceptionForNonBookObject()
        {
            Assert.Throws<ArgumentException>(() => string.Format(this.bookFormat, "{0}", new object()));
        }

        [Test]
        public void ShouldIncludeAuthorInFormattedString()
        {
            string formattedString = string.Format(this.bookFormat, "{0}", this.book);
            StringAssert.Contains("Author: Jon Skeet", formattedString);
        }

        [Test]
        public void ShouldIncludeTitleInFormattedString()
        {
            string formattedString = string.Format(this.bookFormat, "{0}", this.book);
            StringAssert.Contains("Title: C# in Depth", formattedString);
        }
    }
}
