
using System.Net;

namespace AVMHomeAutomationTest70
{
    public partial class UnitTestDect500Light : UnitTestBase
    {
        #region Energy Meter

        [TestMethod]
        [ExpectedHttpRequestException(HttpStatusCode.InternalServerError)]
        public void TestMethodEnergyError()
        {
            double? energy;

            using (HomeAutomation client = new HomeAutomation(TestSettings.Login, TestSettings.Password))
            {
                energy = client.GetSwitchEnergy(testDevice.Ain);
            }
        }

        [TestMethod]
        [ExpectedHttpRequestException(HttpStatusCode.InternalServerError)]
        public async Task TestMethodEnergyAsyncError()
        {
            double? energy;

            using (HomeAutomation client = new HomeAutomation(TestSettings.Login, TestSettings.Password))
            {
                energy = await client.GetSwitchEnergyAsync(testDevice.Ain);
            }
        }

        [TestMethod]
        [ExpectedHttpRequestException(HttpStatusCode.InternalServerError)]
        public void TestMethodPowerError()
        {
            double? power;

            using (HomeAutomation client = new HomeAutomation(TestSettings.Login, TestSettings.Password))
            {
                power = client.GetSwitchPower(testDevice.Ain);
            }
        }

        [TestMethod]
        [ExpectedHttpRequestException(HttpStatusCode.InternalServerError)]
        public async Task TestMethodPowerAsyncError()
        {
            double? power;

            using (HomeAutomation client = new HomeAutomation(TestSettings.Login, TestSettings.Password))
            {
                power = await client.GetSwitchPowerAsync(testDevice.Ain);
            }
        }

        #endregion
    }
}