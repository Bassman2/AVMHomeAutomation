namespace AVMHomeAutomationTest70
{
    [TestClass]
    public class UnitTestDect301Radiator : UnitTestBase
    {
        [TestInitialize]
        public void Initialize()
        {
            this.testDevice = TestSettings.DeviceDect301Radiator;
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
            Assert.IsFalse(stats.Voltage.Count > 0);
            Assert.IsFalse(stats.Power.Count > 0);
            Assert.IsFalse(stats.Energy.Count > 0);
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
            Assert.IsFalse(stats.Voltage.Count > 0);
            Assert.IsFalse(stats.Power.Count > 0);
            Assert.IsFalse(stats.Energy.Count > 0);
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

            Assert.IsTrue(temperature > 18.0 && temperature < 23.0);
        }

        [TestMethod]
        public async Task TestMethodTemperatureAsync()
        {
            double temperature;

            using (HomeAutomation client = new HomeAutomation(TestSettings.Login, TestSettings.Password))
            {
                temperature = await client.GetTemperatureAsync(testDevice.Ain);
            }

            Assert.IsTrue(temperature > 18.0 && temperature < 23.0);
        }

        [TestMethod]
        public void TestMethodGetHkrtSoll()
        {
            double temperature;

            using (HomeAutomation client = new HomeAutomation(TestSettings.Login, TestSettings.Password))
            {
                temperature = client.GetHkrtSoll(testDevice.Ain);
            }

            Assert.IsTrue(temperature > 18.0 && temperature < 23.0);
        }

        [TestMethod]
        public async Task TestMethodGetHkrtSollAsync()
        {
            double temperature;

            using (HomeAutomation client = new HomeAutomation(TestSettings.Login, TestSettings.Password))
            {
                temperature = await client.GetHkrtSollAsync(testDevice.Ain);
            }

            Assert.IsTrue(temperature > 18.0 && temperature < 23.0);
        }

        [TestMethod]
        public void TestMethodGetHkrKomfort()
        {
            double temperature;

            using (HomeAutomation client = new HomeAutomation(TestSettings.Login, TestSettings.Password))
            {
                temperature = client.GetHkrKomfort(testDevice.Ain);
            }

            Assert.IsTrue(temperature > 18.0 && temperature < 23.0);
        }

        [TestMethod]
        public async Task TestMethodGetHkrKomfortAsync()
        {
            double temperature;

            using (HomeAutomation client = new HomeAutomation(TestSettings.Login, TestSettings.Password))
            {
                temperature = await client.GetHkrKomfortAsync(testDevice.Ain);
            }

            Assert.IsTrue(temperature > 18.0 && temperature < 23.0);
        }

        [TestMethod]
        public void TestMethodGetHkrAbsenk()
        {
            double temperature;

            using (HomeAutomation client = new HomeAutomation(TestSettings.Login, TestSettings.Password))
            {
                temperature = client.GetHkrAbsenk(testDevice.Ain);
            }

            Assert.IsTrue(temperature > 18.0 && temperature < 23.0);
        }

        [TestMethod]
        public async Task TestMethodGetHkrAbsenkAsync()
        {
            double temperature;

            using (HomeAutomation client = new HomeAutomation(TestSettings.Login, TestSettings.Password))
            {
                temperature = await client.GetHkrAbsenkAsync(testDevice.Ain);
            }

            Assert.IsTrue(temperature > 18.0 && temperature < 23.0);
        }

        [TestMethod]
        public void TestMethodSetHkrtSoll()
        {
            //double temperature;

            using (HomeAutomation client = new HomeAutomation(TestSettings.Login, TestSettings.Password))
            {
                client.SetHkrtSoll(testDevice.Ain, 23.5);
            }

            //Assert.IsTrue(temperature > 18.0 && temperature < 23.0);
        }

        [TestMethod]
        public async Task TestMethodSetHkrtSollAsync()
        {
            //double temperature;

            using (HomeAutomation client = new HomeAutomation(TestSettings.Login, TestSettings.Password))
            {
                await client.SetHkrtSollAsync(testDevice.Ain, 23.5);
            }

            //Assert.IsTrue(temperature > 18.0 && temperature < 23.0);
        }

        [TestMethod]
        public void TestMethodSetHkrBoost()
        {
            //double temperature;

            using (HomeAutomation client = new HomeAutomation(TestSettings.Login, TestSettings.Password))
            {
                client.SetHkrBoost(testDevice.Ain, DateTime.Now + new TimeSpan(0, 10, 0));

                client.SetHkrBoost(testDevice.Ain, null);
            }

            //Assert.IsTrue(temperature > 18.0 && temperature < 23.0);
        }

        [TestMethod]
        public async Task TestMethodSetHkrBoostAsync()
        {
            //double temperature;

            using (HomeAutomation client = new HomeAutomation(TestSettings.Login, TestSettings.Password))
            {
                await client.SetHkrBoostAsync(testDevice.Ain, DateTime.Now + new TimeSpan(0, 10, 0));

                await client.SetHkrBoostAsync(testDevice.Ain, null);
            }

            //Assert.IsTrue(temperature > 18.0 && temperature < 23.0);
        }

        [TestMethod]
        public void TestMethodSetHkrWindowOpen()
        {
            //double temperature;

            using (HomeAutomation client = new HomeAutomation(TestSettings.Login, TestSettings.Password))
            {
                client.SetHkrWindowOpen(testDevice.Ain, DateTime.Now + new TimeSpan(0, 10, 0));

                client.SetHkrWindowOpen(testDevice.Ain, null);
            }

            //Assert.IsTrue(temperature > 18.0 && temperature < 23.0);
        }

        [TestMethod]
        public async Task TestMethodSetHkrWindowOpenAsync()
        {
            //double temperature;

            using (HomeAutomation client = new HomeAutomation(TestSettings.Login, TestSettings.Password))
            {
                await client.SetHkrWindowOpenAsync(testDevice.Ain, DateTime.Now + new TimeSpan(0, 10, 0));

                await client.SetHkrWindowOpenAsync(testDevice.Ain, null);
            }

            //Assert.IsTrue(temperature > 18.0 && temperature < 23.0);
        }

    }
}

