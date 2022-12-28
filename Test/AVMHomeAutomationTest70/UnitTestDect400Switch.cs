using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AVMHomeAutomationTest70
{
    [TestClass]
    public class UnitTestDect400Switch
    {
        private TestDevice testDevice = TestSettings.DeviceDect400Switch;

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
            Assert.IsFalse(stats.Temperature.Count > 0);
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

        [TestMethod]
        public void TestMethodGetSwitchList()
        {
            string[] devices;

            using (HomeAutomation client = new HomeAutomation(TestSettings.Login, TestSettings.Password))
            {
                devices = client.GetSwitchList();
            }

            Assert.IsNotNull(devices);
            CollectionAssert.AreEquivalent(new string[] { "087610500005", "116300323828", "116570143095", "grp280D89-3E4209CD1" }, devices);

        }

        [TestMethod]
        public void TestMethodSwitchName()
        {
            string name;

            using (HomeAutomation client = new HomeAutomation(TestSettings.Login, TestSettings.Password))
            {
                name = client.GetSwitchName(testDevice.Ain);
            }

            Assert.AreEqual(TestSettings.DeviceDect400Switch.Name, name);
        }

        [TestMethod]
        public void TestMethodGetSwitch()
        {
            bool state1, state2, state3;

            using (HomeAutomation client = new HomeAutomation(TestSettings.Login, TestSettings.Password))
            {
                client.SetSwitchOff(testDevice.Ain);
                state1 = client.GetSwitchState(testDevice.Ain);
                client.SetSwitchOn(testDevice.Ain);
                state2 = client.GetSwitchState(testDevice.Ain);
                client.SetSwitchToggle(testDevice.Ain);
                state3 = client.GetSwitchState(testDevice.Ain);
            }

            Assert.IsFalse(state1);
            Assert.IsTrue(state2);
            Assert.IsFalse(state3);

        }

        [TestMethod]
        public void TestMethodEnergy()
        {
            int energy;

            using (HomeAutomation client = new HomeAutomation(TestSettings.Login, TestSettings.Password))
            {


                energy = client.GetSwitchEnergy(testDevice.Ain);

            }

            Assert.AreEqual(0, energy);


        }

        [TestMethod]
        public void TestMethodSwitchNameError()
        {
            using (HomeAutomation client = new HomeAutomation(TestSettings.Login, TestSettings.Password))
            {
                Assert.ThrowsException<HttpRequestException>(() => client.GetSwitchName(TestSettings.UnknownDeviceAin));
            }
        }
    }
}
