
using System.Net;

namespace AVMHomeAutomationTest70
{
    public partial class UnitTestDect100Repeater : UnitTestBase
    {
        #region Energy Meter

        [TestMethod]
        public void TestMethodEnergy()
        {
            Device device;
            double? energy;

            using (HomeAutomation client = new HomeAutomation(TestSettings.Login, TestSettings.Password))
            {
                device = client.GetDeviceInfos(testDevice.Ain);
                energy = client.GetSwitchEnergy(testDevice.Ain);
            }

            Assert.IsTrue(energy.HasValue);
            Assert.AreEqual(device.PowerMeter.Energy, energy.Value);
        }

        [TestMethod]
        public async Task TestMethodEnergyAsync()
        {
            Device device;
            double? energy;

            using (HomeAutomation client = new HomeAutomation(TestSettings.Login, TestSettings.Password))
            {
                device = await client.GetDeviceInfosAsync(testDevice.Ain);
                energy = await client.GetSwitchEnergyAsync(testDevice.Ain);
            }

            Assert.IsTrue(energy.HasValue);
            Assert.AreEqual(device.PowerMeter.Energy, energy.Value);
        }

        [TestMethod]
        public void TestMethodPower()
        {
            Device device;
            double? power;

            using (HomeAutomation client = new HomeAutomation(TestSettings.Login, TestSettings.Password))
            {
                device = client.GetDeviceInfos(testDevice.Ain);
                power = client.GetSwitchPower(testDevice.Ain);
            }

            Assert.IsTrue(power.HasValue);
            Assert.AreEqual(device.PowerMeter.Power, power.Value);
        }

        [TestMethod]
        public async Task TestMethodPowerAsync()
        {
            Device device;
            double? power;

            using (HomeAutomation client = new HomeAutomation(TestSettings.Login, TestSettings.Password))
            {
                device = await client.GetDeviceInfosAsync(testDevice.Ain);
                power = await client.GetSwitchPowerAsync(testDevice.Ain);
            }

            Assert.IsTrue(power.HasValue);
            Assert.AreEqual(device.PowerMeter.Power, power.Value);
        }

        #endregion
    }
}