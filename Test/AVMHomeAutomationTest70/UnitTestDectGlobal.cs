using System.Linq;

namespace AVMHomeAutomationTest70
{
    [TestClass]
    public class UnitTestDectGlobal
    {
        [TestMethod]
        public void TestMethodGetDeviceListInfos()
        {
            DeviceList deviceList;

            using (HomeAutomation client = new HomeAutomation(TestSettings.Login, TestSettings.Password))
            {
                deviceList = client.GetDeviceListInfos();
            }

            Assert.IsNotNull(deviceList);

            
            AssertDevice(TestSettings.DeviceDect100Repeater, deviceList.Devices.Single((d) => d.Identifier == TestSettings.DeviceDect100Repeater.Ain));
        }

        private void AssertDevice(TestDevice expected, Device actual)
        {
            Assert.AreEqual(expected.Ain, actual.Identifier);
            Assert.AreEqual(expected.Name, actual.Name);
            Assert.AreEqual(expected.Product, actual.ProductName);
            Assert.AreEqual(expected.Manufacturer, actual.Manufacturer);
            Assert.AreEqual(expected.FirmwareVersion, actual.FirmwareVersion);
        }

        [TestMethod]
        public void TestMethodSubscription()
        {
            State preState;
            State runState;

            using (HomeAutomation client = new HomeAutomation(TestSettings.Login, TestSettings.Password))
            {
                preState = client.GetSubscriptionState();
                client.StartUleSubscription();
                do
                {
                    Thread.Sleep(30000);
                    runState = client.GetSubscriptionState();
                } while (runState.Code == Code.SubscriptionRunning);
            }

            Assert.AreEqual(Code.NoSubscription, preState.Code);
            Assert.AreEqual(Code.NoSubscription, runState.Code);
            Assert.IsTrue(!string.IsNullOrEmpty(runState.LatestAin));

        }

        [TestMethod]
        public void TestMethodChangeName()
        {
            TestDevice testDevice = TestSettings.DeviceDect400Switch;
            string orgName, testName, resName;

            using (HomeAutomation client = new HomeAutomation(TestSettings.Login, TestSettings.Password))
            {
                orgName = client.GetSwitchName(testDevice.Ain);
                client.SetName(testDevice.Ain, "Dummy");
                testName = client.GetSwitchName(testDevice.Ain);
                client.SetName(testDevice.Ain, orgName);
                resName = client.GetSwitchName(testDevice.Ain);
            }

            Assert.AreEqual(testDevice.Name, orgName);
            Assert.AreEqual("Dummy", testName);
            Assert.AreEqual(testDevice.Name, resName);
        }

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
        public void TestMethodSwitchNameError()
        {
            using (HomeAutomation client = new HomeAutomation(TestSettings.Login, TestSettings.Password))
            {
                Assert.ThrowsException<HttpRequestException>(() => client.GetSwitchName(TestSettings.UnknownDeviceAin));
            }
        }
    }
}

