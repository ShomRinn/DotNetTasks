using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DerivedClasses;

namespace FilterByPredicate.Tests
{
    public class PositiveFilterTests
    {
        [TestCase(new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 }, ExpectedResult = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 })]
        [TestCase(new[] { -121, -13444, -575, -4658, -484, 719, 838, 49, 62, 883, 11719, 254 }, ExpectedResult = new[] { 719, 838, 49, 62, 883, 11719, 254 })]
        [TestCase(new[] { 19, 83, 47, -36, -352567, 61, 883, 119, 27 }, ExpectedResult = new int[] { 19, 83, 47, 61, 883, 119, 27 })]
        [TestCase(new[] { 113, 113, -113, 11111113, 46 }, ExpectedResult = new[] { 113, 113, 11111113, 46 })]
        [TestCase(new[] { -1, 113, -13, -1, 4 }, ExpectedResult = new[] { 113, 4 })]
        [TestCase(new[] { 3, -12344, -45347, 6, 7, 8 }, ExpectedResult = new[] { 3, 6, 7, 8 })]
        [TestCase(new[] { 14, 16, 18, 20 }, ExpectedResult = new[] { 14, 16, 18, 20 })]
        [TestCase(new[] { 48, -50, 59, -61, 70, -72, 79, 90 }, ExpectedResult = new[] { 48, 59, 70, 79, 90 })]
        [TestCase(new[] { -1, -2, -3, -4, -5 }, ExpectedResult = new int[] { })]
        [TestCase(new[] { 0, 0, 0, 2 }, ExpectedResult = new int[] { 2 })]
        [TestCase(new[] { 2, 4, 6, 8, 10, -2, -4, -6, -8, -10 }, ExpectedResult = new[] { 2, 4, 6, 8, 10 })]
        public int[] Select_PositiveVerifyTests(int[] source) => new PositiveFilter().Select(source);

        [Test]
        public void Select_ArrayIsEmpty_ThrowArgumentException() => Assert.Throws<ArgumentException>(
            () => new PositiveFilter().Select(Array.Empty<int>()), "Array cannot be empty.");

        [Test]
        public void Select_ArrayIsNull_ThrowArgumentNullException() => Assert.Throws<ArgumentNullException>(
            () => new PositiveFilter().Select(null), "Array cannot be null.");
    }
}
