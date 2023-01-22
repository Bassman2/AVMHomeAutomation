using System.Linq;
using System.Net;

namespace AVMHomeAutomationTest70
{
    public partial class UnitTestDectGlobal
    {
        

        [TestMethod]
        [ExpectedHttpRequestException(HttpStatusCode.BadRequest)]
        public void TestMethodGetTriggerListInfos()
        {
            TriggerList triggerList;

            using (HomeAutomation client = new HomeAutomation(TestSettings.Login, TestSettings.Password))
            {
                triggerList = client.GetTriggerListInfos();
            }

            Assert.IsNotNull(triggerList);
        }

        [TestMethod]
        [ExpectedHttpRequestException(HttpStatusCode.BadRequest)]
        public async Task TestMethodGetTriggerListInfosAsync()
        {
            TriggerList triggerList;

            using (HomeAutomation client = new HomeAutomation(TestSettings.Login, TestSettings.Password))
            {
                triggerList = await client.GetTriggerListInfosAsync();
            }

            Assert.IsNotNull(triggerList);
        }

        [TestMethod]
        [ExpectedHttpRequestException(HttpStatusCode.BadRequest)]
        public void TestMethodSetTriggerActive()
        {
            using (HomeAutomation client = new HomeAutomation(TestSettings.Login, TestSettings.Password))
            {
                client.SetTriggerActive(TestSettings.TriggerAin, true);
            }
        }

        [TestMethod]
        [ExpectedHttpRequestException(HttpStatusCode.BadRequest)]
        public async Task TestMethodSetTriggerActiveAsync()
        {
            using (HomeAutomation client = new HomeAutomation(TestSettings.Login, TestSettings.Password))
            {
                await client.SetTriggerActiveAsync(TestSettings.TriggerAin, true);
            }
        }
    }
}

