using System.Net;

namespace AVMHomeAutomationTest70
{
    public partial class UnitTestHanFunMotionDetector : UnitTestBase
    {
        #region Blind

        [TestMethod]
        [ExpectedHttpRequestException(HttpStatusCode.InternalServerError)]
        public void TestMethodSetBlindError()
        {
            using (HomeAutomation client = new HomeAutomation(TestSettings.Login, TestSettings.Password))
            {
                client.SetBlind(testDevice.Ain, Target.Stop);
            }
        }

        [TestMethod]
        [ExpectedHttpRequestException(HttpStatusCode.InternalServerError)]
        public async Task TestMethodSetBlindErrorAsync()
        {
            using (HomeAutomation client = new HomeAutomation(TestSettings.Login, TestSettings.Password))
            {
                await client.SetBlindAsync(testDevice.Ain, Target.Stop);
            }
        }

        #endregion
    }
}