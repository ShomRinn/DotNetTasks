using NUnit.Framework;

namespace Loop1Tasks.Tests
{
    [TestFixture]
    public class TasksTests
    {
        [TestCase(1, 9, 25)]
        [TestCase(9, 25, 153)]
        [TestCase(15, 30, 176)]
        public void Task_ReturnsCorrectValue(int n, int m, int expected)
        {
            var actual = Tasks.Task(n, m);
            Assert.AreEqual(expected, actual, "Task returns incorrect value.");
        }
    }
}
