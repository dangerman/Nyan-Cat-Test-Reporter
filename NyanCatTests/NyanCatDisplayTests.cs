using System;
using System.Windows;
using NyanCatDisplay;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;

namespace NyanCatTests
{
    [TestClass]
    public class NyanCatDisplayTests
    {
        private NyanCatWindow _window;

        [TestInitialize]
        public void SetUp()
        {
            var speedInNyanoMetersPerSecond = 100;
            _window = new NyanCatWindow(speedInNyanoMetersPerSecond);
        }

        [TestMethod]
        public void DistanceTravelledIsUpdatedWhenThereIsAPass()
        {
            _window.PassedCount = 1;
            var expectedDistance = 100;

            Assert.AreEqual(expectedDistance, _window.Distance);
        }

        [TestMethod]
        public void DistanceTravelledIsUpdatedWhenThereIsAFail()
        {
            _window.FailedCount = 2;
            var expectedDistance = 200;

            Assert.AreEqual(expectedDistance, _window.Distance);
        }

        [TestMethod]
        public void DistanceTravelledIsUpdatedWhenThereInAnOther()
        {
            _window.OtherCount = 3;
            var expectedDistance = 300;

            Assert.AreEqual(expectedDistance, _window.Distance);
        }

        [TestMethod]
        public void DistanceTravelledIsUpdatedWhenThereIsAPassThenAFail()
        {
            _window.PassedCount = 1;
            _window.FailedCount = 1;
            var expectedDistance = 200;

            Assert.AreEqual(expectedDistance, _window.Distance);
        }

        [TestMethod]
        public void CannotTravelTooFarOffTheScreen()
        {
            _window.PassedCount = 9000;
            var totalWidthOfTheScreen = SystemParameters.PrimaryScreenWidth;
            var distance = _window.Distance;

            Assert.IsTrue(distance <= totalWidthOfTheScreen, "Travels too far beyond the screen");
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
