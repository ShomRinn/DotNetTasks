#pragma warning disable SA1600 // Elements should be documented
using FilterByDigit;
using FilterByOdd;
using FilterByPalindromic;
using FilterByPositive;
using FilterByPredicate;
using NUnit.Framework;

namespace FilterByPredicates.Tests
{
    [TestFixture]
    public class ArrayExtensionsTests
    {
        public static IEnumerable<TestCaseData> FiltersTestCases()
        {
            yield return new TestCaseData(
                new ByDigitPredicate() { Digit = 7 },
                new[] { -27, 173, 371132, 7556, 7243, 10017, int.MinValue, int.MaxValue },
                new[] { -27, 173, 371132, 7556, 7243, 10017, int.MinValue, int.MaxValue });
            yield return new TestCaseData(
                new ByDigitPredicate { Digit = 1 },
                new[] { 111, 111, 111, 11111111 },
                new[] { 111, 111, 111, 11111111 });
            yield return new TestCaseData(
                new ByDigitPredicate { Digit = 8 },
                new[] { -583, -7481, -24, -81001, -32, -10805 },
                new[] { -583, -7481, -81001, -10805 });
            yield return new TestCaseData(
                new ByDigitPredicate { Digit = 0 },
                new[] { 2212332, 1405644, -1236674 },
                new[] { 1405644 });
            yield return new TestCaseData(
                new ByDigitPredicate { Digit = 2 },
                new[] { 53, 71, -24, 1001, 32, 1005 },
                new[] { -24, 32 });
            yield return new TestCaseData(
                new ByDigitPredicate { Digit = 0 },
                new[] { int.MinValue, int.MinValue, int.MinValue, int.MaxValue, int.MaxValue },
                Array.Empty<int>());
            yield return new TestCaseData(
                new ByPalindromicPredicate(),
                new[] { 717, 828, 45, 58, 881, 11711, 252 },
                new[] { 717, 828, 11711, 252 });
            yield return new TestCaseData(
                new ByPalindromicPredicate(),
                new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 },
                new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 });
            yield return new TestCaseData(
                new ByPalindromicPredicate(),
                new[] { 17, 82, 45, 58, 881, 117, 25 },
                Array.Empty<int>());
            yield return new TestCaseData(
                new ByPalindromicPredicate(),
                new[] { 2212332, 0, 1405644, 12345, 1, -1236674, 123321, 1111111 },
                new[] { 0, 1, 123321, 1111111 });
            yield return new TestCaseData(
                new ByPalindromicPredicate(),
                new[] { -27, 987656789, 7557, int.MaxValue, 7556, 7243, 7243427, int.MinValue },
                new[] { 987656789, 7557, 7243427 });
            yield return new TestCaseData(
                new ByPalindromicPredicate(),
                new[] { -1, 0, 111, -11, -1 },
                new[] { 0, 111 });
            yield return new TestCaseData(
                new ByOddPredicate(),
                new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 },
                new[] { 1, 3, 5, 7, 9 });
            yield return new TestCaseData(
                new ByOddPredicate(),
                new[] { 717, 828, 45, 58, 881, 11711, 252 },
                new[] { 717, 45, 881, 11711 });
            yield return new TestCaseData(
                new ByOddPredicate(),
                new[] { 18, 82, 46, 58, 882, 118, 26 },
                Array.Empty<int>());
            yield return new TestCaseData(
                new ByOddPredicate(),
                new[] { 111, 111, 111, 11111111, 44 },
                new[] { 111, 111, 111, 11111111 });
            yield return new TestCaseData(
                new ByOddPredicate(),
                new[] { -1, 111, -11, -1, 2 },
                new[] { -1, 111, -11, -1 });
            yield return new TestCaseData(
                new ByOddPredicate(),
                new[] { 1, 2, 3, 4 },
                new[] { 1, 3 });
            yield return new TestCaseData(
                new ByOddPredicate(),
                new[] { 11, 13, 15, 17 },
                new[] { 11, 13, 15, 17 });
            yield return new TestCaseData(
                new ByOddPredicate(),
                new[] { 44, 55, 66, 77, 88 },
                new[] { 55, 77 });
            yield return new TestCaseData(
                new ByPositivePredicate(),
                new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 },
                new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 });
            yield return new TestCaseData(
                new ByPositivePredicate(),
                new[] { -111, -134124, -545, -4652, -444, 717, 828, 45, 58, 881, 11711, 252 },
                new[] { 717, 828, 45, 58, 881, 11711, 252 });
            yield return new TestCaseData(
                new ByPositivePredicate(),
                new[] { 111, 111, -111, 11111111, 44 },
                new[] { 111, 111, 11111111, 44 });
            yield return new TestCaseData(
                new ByPositivePredicate(),
                new[] { -1, 111, -11, -1, 2 },
                new[] { 111, 2 });
            yield return new TestCaseData(
                new ByPositivePredicate(),
                new[] { 1, -12342, -45345, 2, 3, 4 },
                new[] { 1, 2, 3, 4 });
            yield return new TestCaseData(
                new ByPositivePredicate(),
                new[] { 10, 12, 14, 16 },
                new[] { 10, 12, 14, 16 });
            yield return new TestCaseData(
                new ByPositivePredicate(),
                new[] { 44, -46, 55, -57, 66, -68, 77, 88 },
                new[] { 44, 55, 66, 77, 88 });
            yield return new TestCaseData(
                new ByPositivePredicate(),
                new[] { 44, 55, 66, 77, 88 },
                new[] { 44, 55, 66, 77, 88 });
        }

        [TestCaseSource(nameof(FiltersTestCases))]
        public void SelectTests(IPredicate predicate, int[] source, int[] expected)
        {
            CollectionAssert.AreEqual(expected, source.Select(predicate));
        }
    }
}
