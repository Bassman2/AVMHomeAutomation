using System.Net;

namespace AVMHomeAutomationTest70
{
    public partial class UnitTestDect301Radiator : UnitTestBase
    {
        [TestMethod]
        public void TestMethodGetBasicDeviceStats()
        {
            DeviceStats stats;

            using (HomeAutomation client = new HomeAutomation(TestSettings.Login, TestSettings.Password))
            {
                stats = client.GetBasicDeviceStats(testDevice.Ain);
            }

            Assert.IsNotNull(stats, "stats");
            Assert.IsTrue(stats.Temperature.Count > 0, "Temperature");
            Assert.IsFalse(stats.Voltage.Count > 0, "Voltage");
            Assert.IsFalse(stats.Power.Count > 0, "Power");
            Assert.IsFalse(stats.Energy.Count > 0, "Energy");
            Assert.IsFalse(stats.Humidity.Count > 0, "Humidity");
        }

        [TestMethod]
        public async Task TestMethodGetBasicDeviceStatsAsync()
        {
            DeviceStats stats;

            using (HomeAutomation client = new HomeAutomation(TestSettings.Login, TestSettings.Password))
            {
                stats = await client.GetBasicDeviceStatsAsync(testDevice.Ain);
            }

            Assert.IsNotNull(stats, "stats");
            Assert.IsTrue(stats.Temperature.Count > 0, "Temperature");
            Assert.IsFalse(stats.Voltage.Count > 0, "Voltage");
            Assert.IsFalse(stats.Power.Count > 0, "Power");
            Assert.IsFalse(stats.Energy.Count > 0, "Energy");
            Assert.IsFalse(stats.Humidity.Count > 0, "Humidity");
        }
    }
}       
                