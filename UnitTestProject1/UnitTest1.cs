using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void FailingTest()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void PassingTest()
        {
            Assert.IsTrue(true);
        }
    }
}
