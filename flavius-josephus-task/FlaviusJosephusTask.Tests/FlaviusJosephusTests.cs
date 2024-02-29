using System.Numerics;
using NUnit.Framework;

namespace FlaviusJosephusTask.Tests
{
    [TestFixture]
    public class FlaviusJosephusTests
    {
        private static IEnumerable<TestCaseData> FlaviusJosephusTestsCases
        {
            get
            {
                yield return new TestCaseData(1, 1, 1);
                yield return new TestCaseData(4, 4, 2);
                yield return new TestCaseData(5, 2, 3);
                yield return new TestCaseData(6, 5, 1);
                yield return new TestCaseData(7, 3, 4);
                yield return new TestCaseData(8, 2, 1);
                yield return new TestCaseData(9, 5, 8);
                yield return new TestCaseData(10, 3, 4);
                yield return new TestCaseData(15, 7, 5);
                yield return new TestCaseData(20, 4, 17);
                yield return new TestCaseData(25, 1, 25);
                yield return new TestCaseData(25, 4, 15);
                yield return new TestCaseData(26, 1, 26);
                yield return new TestCaseData(27, 5, 18);
                yield return new TestCaseData(33, 7, 12);
                yield return new TestCaseData(33, 10, 27);
                yield return new TestCaseData(34, 9, 25);
                yield return new TestCaseData(35, 8, 6);
                yield return new TestCaseData(41, 10, 35);
                yield return new TestCaseData(1000, 1000, 609);
                yield return new TestCaseData(2005, 204, 2004);
                yield return new TestCaseData(6666, 666, 6459);
                yield return new TestCaseData(6667, 3, 1796);
                yield return new TestCaseData(7777, 555, 7266);
                yield return new TestCaseData(12345, 4321, 3502);
            }
        }

        [TestCaseSource(nameof(FlaviusJosephusTestsCases))]
        public void GetLastPersonTests(int n, int k, int expectedLastPerson)
        {
            Assert.AreEqual(expectedLastPerson, FlaviusJosephus.GetLastPerson(n, k));
        }

        [TestCase(0, 0)]
        [TestCase(-1, 12)]
        [TestCase(-90, 14)]
        public void FlaviusJosephus_NumberOfPeopleLessThanOne_ThrowArgumentException(int n, int k)
           => Assert.Throws<ArgumentException>(() => FlaviusJosephus.GetLastPerson(n, k), message: "Method throws ArgumentException in case n is invalid.");

        [TestCase(145, 0)]
        [TestCase(10, -1)]
        [TestCase(123, -14)]
        public void FlaviusJosephus_NumberOfPersonCrossedOutLessThanOne_ThrowArgumentException(int n, int k)
           => Assert.Throws<ArgumentException>(() => FlaviusJosephus.GetLastPerson(n, k), message: "Method throws ArgumentException in case k is invalid.");

        [TestCase(1, 1)]
        public void FlaviusJosephus_ValidBoundaryInputs_NotThrowingArgumentException(int n, int k)
           => Assert.DoesNotThrow(() => FlaviusJosephus.GetLastPerson(n, k), message: "Method should not throw any exception for valid inputs.");
    }
}
