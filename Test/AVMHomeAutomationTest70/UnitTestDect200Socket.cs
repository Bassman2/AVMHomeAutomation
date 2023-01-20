
using System.Net;

namespace AVMHomeAutomationTest70
{
    [TestClass]
    public partial class UnitTestDect200Socket : UnitTestBase
    {
        [TestInitialize]
        public void Initialize()
        {
            this.testDevice = TestSettings.DeviceDect200Socket;
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
            Assert.IsTrue(stats.Voltage.Count > 0);
            Assert.IsTrue(stats.Power.Count > 0);
            Assert.IsTrue(stats.Energy.Count > 0);
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
            Assert.IsTrue(stats.Temperature.Count > 0);
            Assert.IsTrue(stats.Voltage.Count > 0);
            Assert.IsTrue(stats.Power.Count > 0);
            Assert.IsTrue(stats.Energy.Count > 0);
            Assert.IsFalse(stats.Humidity.Count > 0);
        }
    }
}