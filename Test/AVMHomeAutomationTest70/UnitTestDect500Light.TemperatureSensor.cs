﻿using System.Net;

namespace AVMHomeAutomationTest70
{
    public partial class UnitTestDect500Light : UnitTestBase
    {
        #region Temperature Sensor

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

        #endregion
    }
}       
                