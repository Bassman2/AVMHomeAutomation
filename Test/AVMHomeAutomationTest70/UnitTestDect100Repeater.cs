using System.Net;

namespace AVMHomeAutomationTest70
{
    [TestClass]
    public partial class UnitTestDect100Repeater : UnitTestBase
    {
        [TestInitialize]
        public void Initialize()
        {
            this.testDevice = TestSettings.DeviceDect100Repeater;
        }
    }
}       
                