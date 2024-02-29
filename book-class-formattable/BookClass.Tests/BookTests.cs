#pragma warning disable CS8602

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookClass;
using NUnit.Framework;

namespace BookClass.Tests
{
    [TestFixture]
    public class BookTests
    {
        private Book? somebook;

        [SetUp]
        public void Setup()
        {
            this.somebook = new Book("John Smith", "My Book", "Best Publishers", "1234567890");
        }

        [Test]
        public void Constructor_ValidInput_SuccessfulInitialization()
        {
            Assert.AreEqual("John Smith", this.somebook.Author);
            Assert.AreEqual("My Book", this.somebook.Title);
            Assert.AreEqual("Best Publishers", this.somebook.Publisher);
            Assert.AreEqual("1234567890", this.somebook.ISBN);
        }

        [Test]
        public void Pages_SetNegative_ThrowsArgumentOutOfRangeException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => this.somebook.Pages = -5);
        }

        [Test]
        public void Publish_Call_SetsPublicationDate()
        {
            var date = new DateTime(2023, 6, 15);
            this.somebook.Publish(date);

            Assert.AreEqual("6/15/2023", this.somebook.GetPublicationDate());
        }

        [Test]
        public void ToString_DefaultFormat_ReturnsTitleAndAuthor()
        {
            Assert.AreEqual("My Book by John Smith", this.somebook.ToString());
        }

        [Test]
        public void Equals_SameISBN_ReturnsTrue()
        {
            var otherBook = new Book("Author", "Title", "Publisher", "1234567890");

            Assert.IsTrue(this.somebook.Equals(otherBook));
        }

        [Test]
        public void CompareTo_SameTitle_ReturnsZero()
        {
            var otherBook = new Book("Author", "My Book", "Publisher", "0987654321");

            Assert.AreEqual(0, this.somebook.CompareTo(otherBook));
        }

        [Test]
        public void GetPublicationDate_NotPublished_ReturnsNotPublishedMessage()
        {
            Assert.AreEqual("Not published yet.", this.somebook.GetPublicationDate());
        }

        [Test]
        public void ToString_FormatF_ReturnsFullDetails()
        {
            this.somebook.Pages = 100;
            this.somebook.Publish(new DateTime(2023, 6, 15));
            this.somebook.SetPrice(19.99m, "en-US");
            Assert.AreEqual("My Book by John Smith. 2023. Best Publishers. ISBN: 1234567890. 100 pages. $19.99.", this.somebook.ToString("F", CultureInfo.InvariantCulture));
        }

        [Test]
        public void Equals_DifferentISBN_ReturnsFalse()
        {
            var otherBook = new Book("Author", "Title", "Publisher", "0987654321");
            Assert.IsFalse(this.somebook.Equals(otherBook));
        }

        [Test]
        public void CompareTo_DifferentTitle_ReturnsNonZero()
        {
            var otherBook = new Book("Author", "Different Book", "Publisher", "0987654321");
            Assert.AreNotEqual(0, this.somebook.CompareTo(otherBook));
        }
    }
}
