using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AVMHomeAutomationTest70
{
    public class UnitTestBase
    {
        protected TestDevice testDevice;

        [TestMethod]
        public void TestMethodGetDeviceInfos()
        {
            // Arrange
            Device device;

            // Act
            using (HomeAutomation client = new HomeAutomation(TestSettings.Login, TestSettings.Password))
            {
                device = client.GetDeviceInfos(testDevice.Ain);
            }

            // Assert
            Assert.AreEqual(testDevice.Ain, device.Identifier);
            Assert.AreEqual(testDevice.Name, device.Name);
            Assert.AreEqual(testDevice.Product, device.ProductName);
            Assert.AreEqual(testDevice.Manufacturer, device.Manufacturer);
            Assert.AreEqual(testDevice.FirmwareVersion, device.FirmwareVersion);
        }

        [TestMethod]
        public async Task TestMethodGetDeviceInfosAsync()
        {
            // Arrange
            Device device;

            // Act
            using (HomeAutomation client = new HomeAutomation(TestSettings.Login, TestSettings.Password))
            {
                device = await client.GetDeviceInfosAsync(testDevice.Ain);
            }

            // Assert
            Assert.AreEqual(testDevice.Ain, device.Identifier);
            Assert.AreEqual(testDevice.Name, device.Name);
            Assert.AreEqual(testDevice.Product, device.ProductName);
            Assert.AreEqual(testDevice.Manufacturer, device.Manufacturer);
            Assert.AreEqual(testDevice.FirmwareVersion, device.FirmwareVersion);
        }

        [TestMethod]
        public void TestMethodGetName()
        {
            // Arrange
            string name;

            // Act
            using (HomeAutomation client = new HomeAutomation(TestSettings.Login, TestSettings.Password))
            {
                name = client.GetSwitchName(testDevice.Ain);
            }

            // Assert
            Assert.AreEqual(testDevice.Name, name);
        }

        [TestMethod]
        public async Task TestMethodGetNameAsync()
        {
            // Arrange
            string name;

            // Act
            using (HomeAutomation client = new HomeAutomation(TestSettings.Login, TestSettings.Password))
            {
                name = await client.GetSwitchNameAsync(testDevice.Ain);
            }

            // Assert
            Assert.AreEqual(testDevice.Name, name);
        }

        [TestMethod]
        public void TestMethodPresent()
        {
            // Arrange
            bool isPresent;

            // Act
            using (HomeAutomation client = new HomeAutomation(TestSettings.Login, TestSettings.Password))
            {
                isPresent = client.GetSwitchPresent(testDevice.Ain);
            }

            // Assert
            Assert.IsTrue(isPresent);
        }

        [TestMethod]
        public async Task TestMethodPresentAsync()
        {
            // Arrange
            bool isPresent;

            // Act
            using (HomeAutomation client = new HomeAutomation(TestSettings.Login, TestSettings.Password))
            {
                isPresent = await client.GetSwitchPresentAsync(testDevice.Ain);
            }

            // Assert
            Assert.IsTrue(isPresent);
        }
    }
}
