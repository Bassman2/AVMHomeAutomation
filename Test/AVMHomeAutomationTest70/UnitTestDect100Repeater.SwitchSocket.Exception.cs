using System.Net;

namespace AVMHomeAutomationTest70
{
    public partial class UnitTestDect100Repeater : UnitTestBase
    {
        #region Switch Socket

        [TestMethod]
        [ExpectedHttpRequestException(HttpStatusCode.InternalServerError)]
        public void TestMethodSetSwitchOnError()
        {
            using (HomeAutomation client = new HomeAutomation(TestSettings.Login, TestSettings.Password))
            {
                client.SetSwitchOn(testDevice.Ain);
            }
        }

        [TestMethod]
        [ExpectedHttpRequestException(HttpStatusCode.InternalServerError)]
        public async Task TestMethodSetSwitchOnAsyncError()
        {
            using (HomeAutomation client = new HomeAutomation(TestSettings.Login, TestSettings.Password))
            {
                await client.SetSwitchOnAsync(testDevice.Ain);
            }
        }

        [TestMethod]
        [ExpectedHttpRequestException(HttpStatusCode.InternalServerError)]
        public void TestMethodSetSwitchOffError()
        {
            using (HomeAutomation client = new HomeAutomation(TestSettings.Login, TestSettings.Password))
            {
                client.SetSwitchOff(testDevice.Ain);
            }
        }

        [TestMethod]
        [ExpectedHttpRequestException(HttpStatusCode.InternalServerError)]
        public async Task TestMethodSetSwitchOffAsyncError()
        {
            using (HomeAutomation client = new HomeAutomation(TestSettings.Login, TestSettings.Password))
            {
                await client.SetSwitchOffAsync(testDevice.Ain);
            }
        }

        [TestMethod]
        [ExpectedHttpRequestException(HttpStatusCode.InternalServerError)]
        public void TestMethodSetSwitchToggleError()
        {
            using (HomeAutomation client = new HomeAutomation(TestSettings.Login, TestSettings.Password))
            {
                client.SetSwitchToggle(testDevice.Ain);
            }
        }

        [TestMethod]
        [ExpectedHttpRequestException(HttpStatusCode.InternalServerError)]
        public async Task TestMethodSetSwitchToggleAsyncError()
        {
            using (HomeAutomation client = new HomeAutomation(TestSettings.Login, TestSettings.Password))
            {
                await client.SetSwitchToggleAsync(testDevice.Ain);
            }
        }

        [TestMethod]
        [ExpectedHttpRequestException(HttpStatusCode.InternalServerError)]
        public void TestMethodGetSwitchStateError()
        {
            bool? val;
            using (HomeAutomation client = new HomeAutomation(TestSettings.Login, TestSettings.Password))
            {
                val = client.GetSwitchState(testDevice.Ain);
            }
        }

        [TestMethod]
        [ExpectedHttpRequestException(HttpStatusCode.InternalServerError)]
        public async Task TestMethodGetSwitchStateAsyncError()
        {
            bool? val;
            using (HomeAutomation client = new HomeAutomation(TestSettings.Login, TestSettings.Password))
            {
                val = await client.GetSwitchStateAsync(testDevice.Ain);
            }

            Assert.IsTrue(val);
        }

        #endregion
    }
}       
                