
namespace AVMHomeAutomationTest70
{
    [TestClass]
    public class UnitTestDect200Switch
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

        [TestMethod]
        public void TestMethodSwitchName()
        {
            string name;

            using (HomeAutomation client = new HomeAutomation(TestSettings.Login, TestSettings.Password))
            {
                name = client.GetSwitchName(TestSettings.SwitchDeviceAin);
            }

            Assert.AreEqual(TestSettings.SwitchDeviceName, name);
        }

        [TestMethod]
        public void TestMethodGetSwitch()
        {
            bool state1, state2, state3;

            using (HomeAutomation client = new HomeAutomation(TestSettings.Login, TestSettings.Password))
            {
                client.SetSwitchOff(TestSettings.SwitchDeviceAin);
                state1 = client.GetSwitchState(TestSettings.SwitchDeviceAin);
                client.SetSwitchOn(TestSettings.SwitchDeviceAin);
                state2 = client.GetSwitchState(TestSettings.SwitchDeviceAin);
                client.SetSwitchToggle(TestSettings.SwitchDeviceAin);
                state3 = client.GetSwitchState(TestSettings.SwitchDeviceAin);
            }

            Assert.IsFalse(state1);
            Assert.IsTrue(state2);
            Assert.IsFalse(state3);

        }

        [TestMethod]
        public void TestMethodEnergy()
        {
            int energy;

            using (HomeAutomation client = new HomeAutomation(TestSettings.Login, TestSettings.Password))
            {


                energy = client.GetSwitchEnergy(TestSettings.SwitchDeviceAin);
                
            }

            Assert.AreEqual(0, energy);


        }

        [TestMethod]
        public void TestMethodSwitchNameError()
        {
            using (HomeAutomation client = new HomeAutomation(TestSettings.Login, TestSettings.Password))
            {
                Assert.ThrowsException<HttpRequestException>(() => client.GetSwitchName(TestSettings.UnknownDeviceAin));
            }
        }
    }
}