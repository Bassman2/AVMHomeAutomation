
namespace AVMHomeAutomationTest70
{
    [TestClass]
    public class UnitTestSwitch
    {
        [TestMethod]
        public void TestMethodGetSwitchList()
        {
            string[] devices;
            
            using (HomeAutomation client = new HomeAutomation(TestSettings.Login, TestSettings.Password))
            {
                devices = client.GetSwitchList();
            }

            Assert.IsNotNull(devices);
            CollectionAssert.AreEquivalent(new string[] { "087610500005", "116300323828", "116570143095", "grp280D89-3E4209CD1" }, devices);
        
        }
    }
}