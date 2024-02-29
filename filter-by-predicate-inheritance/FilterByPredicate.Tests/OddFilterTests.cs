using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArrayExtension;
using DerivedClasses;

namespace FilterByPredicate.Tests
{
    public class OddFilterTests
    {
        [TestCase(new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 }, ExpectedResult = new[] { 1, 3, 5, 7, 9 })]
        [TestCase(new[] { 659, 934, 37, 66, 905, 12021, 246 }, ExpectedResult = new[] { 659, 37, 905, 12021 })]
        [TestCase(new[] { 2200316, 0, 1412344, 12753, 1, -1256874, 125431, 1111129 }, ExpectedResult = new[] { 12753, 1, 125431, 1111129 })]
        [TestCase(new[] { 1111111108, 987654, -22, 1234654333, 32, 1025 }, ExpectedResult = new int[] { 1234654333, 1025 })]
        [TestCase(new[] { -29, 987656787, 7559, 7556, 7245, 7243429, int.MinValue }, ExpectedResult = new[] { -29, 987656787, 7559, 7245, 7243429 })]
        [TestCase(new[] { 113, 113, 113, 11111113 }, ExpectedResult = new[] { 113, 113, 113, 11111113 })]
        [TestCase(new[] { -1, 0, 113, -13, -1 }, ExpectedResult = new[] { -1, 113, -13, -1 })]
        [TestCase(new[] { 0, 1, 2, 5, 6 }, ExpectedResult = new[] { 1, 5 })]
        [TestCase(new[] { 13579, 24680, 98765 }, ExpectedResult = new[] { 13579, 98765 })]
        [TestCase(new[] { -9, -8, -7, -6, -5, -4, -3, -2, -1, 0 }, ExpectedResult = new[] { -9, -7, -5, -3, -1 })]
        [TestCase(new[] { int.MaxValue, int.MinValue }, ExpectedResult = new[] { int.MaxValue })]
        public int[] FilterByOdd(int[] item) => new OddFilter().Select(item);

        [Test]
        public void Select_ArrayIsEmpty_ThrowArgumentException() => Assert.Throws<ArgumentException>(
            () => new OddFilter().Select(Array.Empty<int>()), "Array cannot be empty.");

        [Test]
        public void Select_ArrayIsNull_ThrowArgumentNullException() => Assert.Throws<ArgumentNullException>(
            () => new OddFilter().Select(null), "Array cannot be null.");
    }
}
