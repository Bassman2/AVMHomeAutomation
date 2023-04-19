using System.Net;

namespace AVMHomeAutomationTest70
{
    public partial class UnitTestHanFunMotionDetector : UnitTestBase
    {
        #region Blind

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