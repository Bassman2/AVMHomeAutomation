
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
    }
}