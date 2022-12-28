namespace AVMHomeAutomationTest70
{
    [TestClass]
    public class UnitTestHanFunDoorWindowContact
    {
        private TestDevice testDevice = TestSettings.DeviceHanFunDoorWindowContact;

        [TestMethod]
        public void TestMethodGetDeviceInfos()
        {
            Device device;

            using (HomeAutomation client = new HomeAutomation(TestSettings.Login, TestSettings.Password))
            {
                device = client.GetDeviceInfos(testDevice.Ain);
            }

            Assert.AreEqual(testDevice.Ain, device.Identifier);
            Assert.AreEqual(testDevice.Name, device.Name);
            Assert.AreEqual(testDevice.Product, device.ProductName);
            Assert.AreEqual(testDevice.Manufacturer, device.Manufacturer);
            Assert.AreEqual(testDevice.FirmwareVersion, device.FirmwareVersion);
        }
    }
}
