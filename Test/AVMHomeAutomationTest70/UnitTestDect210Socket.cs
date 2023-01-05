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
        public async Task TestMethodGetBasicDeviceStatsAsync()
        {
            DeviceStats stats;

            using (HomeAutomation client = new HomeAutomation(TestSettings.Login, TestSettings.Password))
            {
                stats = await client.GetBasicDeviceStatsAsync(testDevice.Ain);
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
        public async Task TestMethodTemperatureAsync()
        {
            double temperature;

            using (HomeAutomation client = new HomeAutomation(TestSettings.Login, TestSettings.Password))
            {
                temperature = await client.GetTemperatureAsync(testDevice.Ain);
            }

            Assert.IsTrue(temperature > 18.0 && temperature < 24.0);
        }
        
        [TestMethod]
        public void TestMethodGetSwitch()
        {
            bool? state1, state2, state3;

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

            Assert.IsFalse(state1.Value);
            Assert.IsTrue(state2.Value);
            Assert.IsFalse(state3.Value);

        }

        [TestMethod]
        public async Task TestMethodGetSwitchAsync()
        {
            bool? state1, state2, state3;

            using (HomeAutomation client = new HomeAutomation(TestSettings.Login, TestSettings.Password))
            {
                await client.SetSwitchOffAsync(testDevice.Ain);
                Thread.Sleep(500);
                state1 = await client.GetSwitchStateAsync(testDevice.Ain);
                await client.SetSwitchOnAsync(testDevice.Ain);
                Thread.Sleep(500);
                state2 = await client.GetSwitchStateAsync(testDevice.Ain);
                await client.SetSwitchToggleAsync(testDevice.Ain);
                Thread.Sleep(500);
                state3 = await client.GetSwitchStateAsync(testDevice.Ain);
            }

            Assert.IsFalse(state1.Value);
            Assert.IsTrue(state2.Value);
            Assert.IsFalse(state3.Value);
        }

        [TestMethod]
        public void TestMethodEnergy()
        {
            int? energy;

            using (HomeAutomation client = new HomeAutomation(TestSettings.Login, TestSettings.Password))
            {
                energy = client.GetSwitchEnergy(testDevice.Ain);
            }

            Assert.IsTrue(energy >= 651090);
        }

        [TestMethod]
        public async Task TestMethodEnergyAsync()
        {
            int? energy;

            using (HomeAutomation client = new HomeAutomation(TestSettings.Login, TestSettings.Password))
            {
                energy = await client.GetSwitchEnergyAsync(testDevice.Ain);
            }

            Assert.IsTrue(energy >= 651090);
        }

        [TestMethod]
        public void TestMethodPower()
        {
            int? power;

            using (HomeAutomation client = new HomeAutomation(TestSettings.Login, TestSettings.Password))
            {
                power = client.GetSwitchPower(testDevice.Ain);
            }

            Assert.IsTrue(power >= 651090);
        }

        [TestMethod]
        public async Task TestMethodPowerAsync()
        {
            int? power;

            using (HomeAutomation client = new HomeAutomation(TestSettings.Login, TestSettings.Password))
            {
                power = await client.GetSwitchPowerAsync(testDevice.Ain);
            }

            Assert.IsTrue(power >= 651090);
        }
    }
}
