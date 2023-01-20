using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AVMHomeAutomationTest70
{
    [TestClass]
    public class UnitTestDect440Switch : UnitTestBase
    {
        [TestInitialize]
        public void Initialize()
        {
            this.testDevice = TestSettings.DeviceDect440Switch;
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
            Assert.IsTrue(stats.Humidity.Count > 0);
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
            Assert.IsTrue(stats.Temperature.Count > 0);
            Assert.IsFalse(stats.Voltage.Count > 0);
            Assert.IsFalse(stats.Power.Count > 0);
            Assert.IsFalse(stats.Energy.Count > 0);
            Assert.IsTrue(stats.Humidity.Count > 0);
        }
        
        [TestMethod]
        public void TestMethodTemperature()
        {
            Device deviceInfos;
            double temperature;

            using (HomeAutomation client = new HomeAutomation(TestSettings.Login, TestSettings.Password))
            {
                deviceInfos = client.GetDeviceInfos(testDevice.Ain);
                temperature = client.GetTemperature(testDevice.Ain);
            }

            Assert.IsTrue(temperature > 14.0 && temperature < 25.0, "Range");
            Assert.IsNotNull(deviceInfos, "deviceInfo");
            Assert.IsNotNull(deviceInfos.Temperature, "Temperature");
            Assert.AreEqual(deviceInfos.Temperature.Celsius, temperature, "Compare");
        }

        [TestMethod]
        public async Task TestMethodTemperatureAsync()
        {
            Device deviceInfos;
            double temperature;

            using (HomeAutomation client = new HomeAutomation(TestSettings.Login, TestSettings.Password))
            {
                deviceInfos = await client.GetDeviceInfosAsync(testDevice.Ain);
                temperature = await client.GetTemperatureAsync(testDevice.Ain);
            }

            Assert.IsTrue(temperature > 14.0 && temperature < 25.0, "Range");
            Assert.IsNotNull(deviceInfos, "deviceInfo");
            Assert.IsNotNull(deviceInfos.Temperature, "Temperature");
            Assert.AreEqual(deviceInfos.Temperature.Celsius, temperature, "Compare");
        }

        //[TestMethod]
        //public void TestMethodGetSwitch()
        //{
        //    bool state1, state2, state3;

        //    using (HomeAutomation client = new HomeAutomation(TestSettings.Login, TestSettings.Password))
        //    {
        //        //client.SetSwitchOff(testDevice.Ain);
        //        state1 = client.GetSwitchState(testDevice.Ain);
        //        //client.SetSwitchOn(testDevice.Ain);
        //        state2 = client.GetSwitchState(testDevice.Ain);
        //        //client.SetSwitchToggle(testDevice.Ain);
        //        state3 = client.GetSwitchState(testDevice.Ain);
        //    }

        //    Assert.IsFalse(state1);
        //    Assert.IsTrue(state2);
        //    Assert.IsFalse(state3);

        //}


    }
}
