using System;
using System.Collections.Generic;
using System.Globalization;
using NUnit.Framework;
#pragma warning disable SA1028
#pragma warning disable CS8604

namespace PseudoEnumerableTask.Tests.NUnitTests
{
    [TestFixture]
    public class EnumerableSequencesMethodsWithDelegateTestFixture
    {
        private static IEnumerable<TestCaseData> FilterTestCases
        {
            get
            {
                yield return new TestCaseData(
                    new[] { "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten" },
                    new[] { "one", "two", "six", "ten" },
                    new Predicate<string>(x => x.Length == 3));
                yield return new TestCaseData(
                    new[] { "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten", },
                    new[] { "one", "two", "four", },
                    new Predicate<string>(x => x.Contains('o', StringComparison.InvariantCulture)));
                yield return new TestCaseData(
                    new[]
                    {
                        "one", "two", "Two", "Three", "three", "four", "five", "six", "seven", "eight", "nine", "ten",
                    },
                    arg2: new[] { "two", "Two", "Three", "three", "ten", },
                    arg3: new Predicate<string>(x => x.ToUpper(CultureInfo.InvariantCulture).StartsWith('T')));
            }
        }

        [TestCase(
            new[] { -9.56, 67.908, 45.34, 0.123, -100.453, },
            new[] { 0.123, -9.56, 45.34, 67.908, -100.453, })]
        public void SortByTests(double[] source, double[] expected) =>
            Assert.AreEqual(expected, source.SortBy((x, y) => Math.Abs(x).CompareTo(Math.Abs(y))));

        [TestCase(
            new[] { "one", "two", "three", "four", null, "five", "six", "seven", "eight", null, "nine", "ten", },
            new[] { null, null, "one", "two", "six", "ten", "four", "five", "nine", "three", "seven", "eight", })]
        public void SortByTests(string[] source, string[] expected) =>
            Assert.AreEqual(expected, source.SortBy((x, y) => (x?.Length ?? 0).CompareTo(y?.Length ?? 0)));

        [TestCase(
            new[] { 12, 56, -907, 567, 234, -576, -43253, 1234, },
            new[] { 12, 56, 567, 234, 1234, })]
        public void FilterTests(int[] source, int[] expected) =>
            Assert.AreEqual(expected, source.Filter(x => x > 0));
        
        [TestCaseSource(nameof(FilterTestCases))]
        public void FilterTests(string[] source, string[] expected, Predicate<string> predicate) =>
            CollectionAssert.AreEqual(expected, source.Filter(predicate));

        [TestCase(
        new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 },
        new[] { 1, 3, 5, 7, 9 })]
        public void Filter_WithDelegateParameter(int[] source, int[] expected)
        {
            Predicate<int> isOdd = number => number % 2 != 0;
            Assert.AreEqual(expected, source.Filter(isOdd));
        }

        [TestCase(
            new[] { "apple", "banana", "cherry", "date", "elderberry" },
            new[] { "elderberry", "banana", "cherry", "date", "apple" })]
        public void SortBy_WithDelegateParameter(string[] source, string[] expected)
        {
            Comparison<string> byLengthDescending = (x, y) => y.Length.CompareTo(x.Length);
            var actual = source.SortBy(byLengthDescending).ToArray();

            Array.Sort(expected, byLengthDescending);
            Array.Sort(actual, byLengthDescending);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(
            new[] { 1, 2, 3, 4, 5 }, 
            new[] { 2, 4, 6, 8, 10 })]
        public void Transform_WithDelegateParameter(int[] source, int[] expected)
        {
            Converter<int, int> doubleNumber = number => number * 2;
            Assert.AreEqual(expected, source.Transform(doubleNumber));
        }

        [TestCase(
            new[] { 1, 2, 3, 4, 5 }, 
            new[] { 5, 4, 3, 2, 1 })]
        [TestCase(
            new[] { "a", "b", "c", "d" }, 
            new[] { "d", "c", "b", "a" })]
        public void Reverse_WithNonEmptySource_ReturnsReversed<TSource>(TSource[] source, TSource[] expected)
        {
            Assert.AreEqual(expected, source.Reverse());
        }

        [Test]
        public void Reverse_EmptySource_ThrowsArgumentException()
        {
            var emptySource = Array.Empty<string>();
            Assert.Throws<ArgumentException>(() => emptySource.Reverse(), "sequence is empty");
        }

        [Test]
        public void Reverse_SourceIsNull_ThrowsArgumentNullException()
        {
            IEnumerable<int>? nullSource = null;
            Assert.Throws<ArgumentNullException>(() => nullSource.Reverse());
        }
    }
}
