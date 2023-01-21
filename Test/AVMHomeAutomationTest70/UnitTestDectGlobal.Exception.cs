using System.Net;

namespace AVMHomeAutomationTest70
{
    public partial class UnitTestDectGlobal
    {
        [TestMethod]
        [ExpectedHttpRequestException(HttpStatusCode.BadRequest)]
        public void TestMethodSwitchNameError()
        {
            using (HomeAutomation client = new HomeAutomation(TestSettings.Login, TestSettings.Password))
            {
                client.GetSwitchName(TestSettings.UnknownDeviceAin);
            }
        }

        [TestMethod]
        [ExpectedHttpRequestException(HttpStatusCode.BadRequest)]
        public async Task TestMethodSwitchNameErrorAsync()
        {
            using (HomeAutomation client = new HomeAutomation(TestSettings.Login, TestSettings.Password))
            {
                await client.GetSwitchNameAsync(TestSettings.UnknownDeviceAin);
            }
        }
    }
}

