using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AVMHomeAutomationTest70
{
    [TestClass]
    public class UnitTestDect500Light
    {
        private TestDevice testDevice = TestSettings.DeviceDect500Light;

        [TestMethod]
        public void TestMethodGetDeviceInfos()
        {
            Device device;

            using (HomeAutomation client = new HomeAutomation(TestSettings.Login, TestSettings.Password))
            {
                device = client.GetDeviceInfos(testDevice.Ain);
            }

            Assert.AreEqual(testDevice.Ain, device.Identifier);
            Assert.AreEqual(testDevice.Name, device.Name);
            Assert.AreEqual(testDevice.Product, device.ProductName);
            Assert.AreEqual(testDevice.Manufacturer, device.Manufacturer);
            Assert.AreEqual(testDevice.FirmwareVersion, device.FirmwareVersion);
        }

        [TestMethod]
        public void TestMethodGetBasicDeviceStats()
        {
            DeviceStats stats;

            using (HomeAutomation client = new HomeAutomation(TestSettings.Login, TestSettings.Password))
            {
                stats = client.GetBasicDeviceStats(testDevice.Ain);
            }

            Assert.IsNotNull(stats);
            Assert.IsTrue(stats.Temperature.Count > 0);
            Assert.IsFalse(stats.Voltage.Count > 0);
            Assert.IsFalse(stats.Power.Count > 0);
            Assert.IsFalse(stats.Energy.Count > 0);
            Assert.IsFalse(stats.Humidity.Count > 0);
        }

        [TestMethod]
        public void TestMethodTemperature()
        {
            double temperature;

            using (HomeAutomation client = new HomeAutomation(TestSettings.Login, TestSettings.Password))
            {
                temperature = client.GetTemperature(testDevice.Ain);
            }

            Assert.IsTrue(temperature > 18.0 && temperature < 23.0);
        }
    }
}
