namespace AVMHomeAutomationTest70
{
    [TestClass]
    public class UnitTestDect210Socket : UnitTestBase
    {
        [TestInitialize]
        public void Initialize()
        {
            this.testDevice = TestSettings.DeviceDect210Socket;
        }
    
        [TestMethod]
        public void TestMethodGetBasicDeviceStats()
        {
            DeviceStats stats;

            using (HomeAutomation client = new HomeAutomation(TestSettings.Login, TestSettings.Password))
            {
                stats = client.GetBasicDeviceStats(testDevice.Ain);
            }

            Assert.IsNotNull(stats);
            Assert.IsTrue(stats.Temperature.Count > 0);
            Assert.IsTrue(stats.Voltage.Count > 0);
            Assert.IsTrue(stats.Power.Count > 0);
            Assert.IsTrue(stats.Energy.Count > 0);
            Assert.IsFalse(stats.Humidity.Count > 0);
        }

        [TestMethod]
        public void TestMethodTemperature()
        {
            double temperature;

            using (HomeAutomation client = new HomeAutomation(TestSettings.Login, TestSettings.Password))
            {
                temperature = client.GetTemperature(testDevice.Ain);
            }

            Assert.IsTrue(temperature > 18.0 && temperature < 24.0);
        }

       

        [TestMethod]
        public void TestMethodGetSwitch()
        {
            bool state1, state2, state3;

            using (HomeAutomation client = new HomeAutomation(TestSettings.Login, TestSettings.Password))
            {
                client.SetSwitchOff(testDevice.Ain);
                Thread.Sleep(500);
                state1 = client.GetSwitchState(testDevice.Ain);
                client.SetSwitchOn(testDevice.Ain);
                Thread.Sleep(500);
                state2 = client.GetSwitchState(testDevice.Ain);
                client.SetSwitchToggle(testDevice.Ain);
                Thread.Sleep(500);
                state3 = client.GetSwitchState(testDevice.Ain);
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
                energy = client.GetSwitchEnergy(testDevice.Ain);
            }

            Assert.IsTrue(energy >= 651090);
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
