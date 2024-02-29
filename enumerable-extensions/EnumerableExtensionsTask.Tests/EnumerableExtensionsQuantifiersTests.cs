using System;
using System.Collections.Generic;
using NUnit.Framework;
#pragma warning disable CS8604
#pragma warning disable CS8625

namespace EnumerableExtensionsTask.Tests
{
    [TestFixture]
    [Category("Quantifiers")]
    public class EnumerableExtensionsQuantifiersTests
    {
        [TestCase(new[] { 123, 321, 1235 }, 100, ExpectedResult = true)]
        [TestCase(new[] { 23, 23, 15 }, 100, ExpectedResult = false)]
        public bool All_Numbers_More_Than_Value(IEnumerable<int> numbers, int value) =>
            numbers.All(item => item > value);

        [TestCase(new[] { "believe", "relief", "receipt", "field" }, "ie", ExpectedResult = false)]
        [TestCase(new[] { "believe", "relief", "receipt", "field" }, "xyz", ExpectedResult = false)]
        [TestCase(new[] { "believe", "relief", "field" }, "ie", ExpectedResult = true)]
        public bool All_Strings_Contains_Phrase(IEnumerable<string> numbers, string phrase) =>
            numbers.All(item => item.Contains(phrase, StringComparison.InvariantCulture));

        [Test]
        public void All_With_Null_Source_Throws_ArgumentNullException()
        {
            IEnumerable<int>? source = null;
            Assert.Throws<ArgumentNullException>(() => source.All(x => x > 0));
        }

        [Test]
        public void All_With_Null_Predicate_Throws_ArgumentNullException()
        {
            IEnumerable<int> source = new List<int> { 1, 2, 3 };
            Assert.Throws<ArgumentNullException>(() => source.All(null));
        }
    }
}
