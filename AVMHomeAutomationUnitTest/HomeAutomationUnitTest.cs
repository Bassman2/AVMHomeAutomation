using System;
using AVMHomeAutomation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AVMHomeAutomationUnitTest
{
    [TestClass]
    public class HomeAutomationUnitTest
    {
        [TestMethod]
        public void SwitchActuatorTest()
        {
            string[] list = null;

            using (HomeAutomation client = new HomeAutomation("", ""))
            {
                list = client.GetSwitchListAsync().Result;
            }

            Assert.IsNotNull(list, "list");
        }
    }
}
