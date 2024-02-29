#pragma warning disable SA1649
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace EnumerableExtensionsTask.Tests
{
    [TestFixture]
    [Category("Swap")]
    public class SwapTests
    {
        [Test]
        public void SwapIntegers_ChangesPositions()
        {
            int first = 1;
            int second = 2;
            EnumerableExtensions.Swap(ref first, ref second);

            Assert.AreEqual(2, first);
            Assert.AreEqual(1, second);
        }

        [Test]
        public void SwapStrings_ChangesPositions()
        {
            string first = "Hello";
            string second = "World";
            EnumerableExtensions.Swap(ref first, ref second);

            Assert.AreEqual("World", first);
            Assert.AreEqual("Hello", second);
        }

        [Test]
        public void SwapBooleans_ChangesPositions()
        {
            bool first = true;
            bool second = false;
            EnumerableExtensions.Swap(ref first, ref second);

            Assert.AreEqual(false, first);
            Assert.AreEqual(true, second);
        }
    }
}
