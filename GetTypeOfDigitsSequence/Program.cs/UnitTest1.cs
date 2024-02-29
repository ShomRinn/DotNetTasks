using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading.Tasks;
using static Program.GetTypeOfTheSequence;


namespace Program.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void GetTypeOfDigitSequence(long number, double expectedResult)
        {
            double actualResult = Program.GetTypeOfDigitSequence(number);
        }
    }
}
