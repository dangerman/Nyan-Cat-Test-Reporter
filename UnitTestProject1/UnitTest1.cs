using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        private void WaitABit()
        {
            Thread.Sleep(1000);
        }

        [TestMethod]
        public void FailingTest()
        {
            WaitABit();
            Assert.Fail();
        }

        [TestMethod]
        public void FailingTest2ElectricBoogaloo()
        {
            WaitABit();
            Assert.Fail();
        }

        [TestMethod]
        public void PassingTest()
        {
            WaitABit();
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void PassingTest2()
        {
            WaitABit();
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void PassingTest3()
        {
            WaitABit();
            Assert.IsTrue(true);
        }
    }
}
