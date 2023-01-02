using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AVMHomeAutomationTest70
{
    [TestClass]
    public class UnitTestDect500Light : UnitTestBase
    {
        [TestInitialize]
        public void Initialize()
        {
            this.testDevice = TestSettings.DeviceDect500Light;
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
        public async Task TestMethodGetBasicDeviceStatsAsync()
        {
            DeviceStats stats;

            using (HomeAutomation client = new HomeAutomation(TestSettings.Login, TestSettings.Password))
            {
                stats = await client.GetBasicDeviceStatsAsync(testDevice.Ain);
            }

            Assert.IsNotNull(stats);
            Assert.IsFalse(stats.Temperature.Count > 0);
            Assert.IsFalse(stats.Voltage.Count > 0);
            Assert.IsFalse(stats.Power.Count > 0);
            Assert.IsFalse(stats.Energy.Count > 0);
            Assert.IsFalse(stats.Humidity.Count > 0);
        }

        [TestMethod]
        public void TestMethodGetColorDefaults()
        {
            ColorDefaults colorDefaults;

            using (HomeAutomation client = new HomeAutomation(TestSettings.Login, TestSettings.Password))
            {
                colorDefaults = client.GetColorDefaults();
            }

            Assert.IsNotNull(colorDefaults);
            CollectionAssert.AreEquivalent(new int[] { 2700, 3000, 3400, 3800, 4200, 4700, 5300, 5900, 6500 }, colorDefaults.TemperatureDefaults.Select((t) => t.Value).ToList());
        }

        [TestMethod]
        public async Task TestMethodGetColorDefaultsAsync()
        {
            ColorDefaults colorDefaults;

            using (HomeAutomation client = new HomeAutomation(TestSettings.Login, TestSettings.Password))
            {
                colorDefaults = await client.GetColorDefaultsAsync();
            }

            Assert.IsNotNull(colorDefaults);
            CollectionAssert.AreEquivalent(new int[] { 2700, 3000, 3400, 3800, 4200, 4700, 5300, 5900, 6500 }, colorDefaults.TemperatureDefaults.Select((t) => t.Value).ToList());
        }

        [TestMethod]
        public void TestMethodSetSimpleOnOff()
        {
            Device device;

            using (HomeAutomation client = new HomeAutomation(TestSettings.Login, TestSettings.Password))
            {
                client.SetSimpleOnOff(testDevice.Ain, OnOff.On);
                Thread.Sleep(2000);
                device = client.GetDeviceInfos(testDevice.Ain);
                client.SetSimpleOnOff(testDevice.Ain, OnOff.Off);
                Thread.Sleep(2000);
                client.SetSimpleOnOff(testDevice.Ain, OnOff.Toggle);
            }
        }

        [TestMethod]
        public async Task TestMethodSetSimpleOnOffAsync()
        {
            Device device;

            using (HomeAutomation client = new HomeAutomation(TestSettings.Login, TestSettings.Password))
            {
                await client.SetSimpleOnOffAsync(testDevice.Ain, OnOff.On);
                Thread.Sleep(2000);
                device = await client.GetDeviceInfosAsync(testDevice.Ain);
                await client.SetSimpleOnOffAsync(testDevice.Ain, OnOff.Off);
                Thread.Sleep(2000);
                await client.SetSimpleOnOffAsync(testDevice.Ain, OnOff.Toggle);
            }
        }

        [TestMethod]
        public void TestMethodSetLevel()
        {
            Device device;

            using (HomeAutomation client = new HomeAutomation(TestSettings.Login, TestSettings.Password))
            {
                client.SetLevel(testDevice.Ain, 50);
                Thread.Sleep(2000);
                client.SetLevel(testDevice.Ain, 255);
                device = client.GetDeviceInfos(testDevice.Ain);
            }
        }

        [TestMethod]
        public async Task TestMethodSetLevelAsync()
        {
            Device device;

            using (HomeAutomation client = new HomeAutomation(TestSettings.Login, TestSettings.Password))
            {
                await client.SetLevelAsync(testDevice.Ain, 50);
                Thread.Sleep(2000);
                await client.SetLevelAsync(testDevice.Ain, 255);
                device = await client.GetDeviceInfosAsync(testDevice.Ain);
            }
        }

        [TestMethod]
        public void TestMethodSetLevelPercentage()
        {
            Device device;

            using (HomeAutomation client = new HomeAutomation(TestSettings.Login, TestSettings.Password))
            {
                client.SetLevelPercentage(testDevice.Ain, 20);
                Thread.Sleep(2000);
                client.SetLevelPercentage(testDevice.Ain, 100);
                device = client.GetDeviceInfos(testDevice.Ain);
            }
        }

        [TestMethod]
        public async Task TestMethodSetLevelPercentageAsync()
        {
            Device device;

            using (HomeAutomation client = new HomeAutomation(TestSettings.Login, TestSettings.Password))
            {
                await client.SetLevelPercentageAsync(testDevice.Ain, 20);
                Thread.Sleep(2000);
                await client.SetLevelPercentageAsync(testDevice.Ain, 100);
                device = await client.GetDeviceInfosAsync(testDevice.Ain);
            }
        }

        [TestMethod]
        public void TestMethodSetColor()
        {
            Device device;

            using (HomeAutomation client = new HomeAutomation(TestSettings.Login, TestSettings.Password))
            {
                client.SetColor(testDevice.Ain, 212, 169, 0);
                Thread.Sleep(2000);
                client.SetLevel(testDevice.Ain, 255);
                device = client.GetDeviceInfos(testDevice.Ain);

                client.SetColor(testDevice.Ain, 358, 180, 0);

            }
        }

        [TestMethod]
        public async Task TestMethodSetColorAsync()
        {
            Device device;

            using (HomeAutomation client = new HomeAutomation(TestSettings.Login, TestSettings.Password))
            {
                await client.SetColorAsync(testDevice.Ain, 212, 169, 0);
                Thread.Sleep(2000);
                await client.SetLevelAsync(testDevice.Ain, 255);
                device = await client.GetDeviceInfosAsync(testDevice.Ain);

                await client.SetColorAsync(testDevice.Ain, 358, 180, 0);

            }
        }

        [TestMethod]
        public void TestMethodSetColorTemperature()
        {
        }

    }
}