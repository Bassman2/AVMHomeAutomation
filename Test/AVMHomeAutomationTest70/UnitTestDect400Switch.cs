using System.Net;

namespace AVMHomeAutomationTest70
{
    [TestClass]
    public partial class UnitTestDect400Switch : UnitTestBase
    {
        [TestInitialize]
        public void Initialize()
        {
            this.testDevice = TestSettings.DeviceDect400Switch;
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

        //[TestMethod]
        //public void TestMethodGetSwitch()
        //{
        //    bool state1, state2, state3;

        //    using (HomeAutomation client = new HomeAutomation(TestSettings.Login, TestSettings.Password))
        //    {
        //        client.SetSimpleOnOff(testDevice.Ain + "-9", OnOff.Off);
        //        client.SetSimpleOnOff(testDevice.Ain + "-9", OnOff.On);
        //        client.SetSimpleOnOff(testDevice.Ain + "-9", OnOff.Toggle);
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

        [TestMethod]
        [ExpectedHttpRequestException(HttpStatusCode.InternalServerError)]
        public void TestMethodTemperatureException()
        {
            using (HomeAutomation client = new HomeAutomation(TestSettings.Login, TestSettings.Password))
            {
                client.GetTemperature(testDevice.Ain);
            }
        }

    }
}
