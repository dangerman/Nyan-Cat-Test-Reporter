using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;
using System.Threading;

namespace ExampleTestProject
{
    [TestClass]
    public class ExampleTests
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

        [AssemblyCleanup]
        public static void CloseTestDiscoveryEngine()
        {
            var processes = Process.GetProcessesByName("vstest.discoveryengine.x86");
            foreach (var process in processes)
            {
                process.Kill();
            }
        }
    }
}
