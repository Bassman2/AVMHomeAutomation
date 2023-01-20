using System.Net;

namespace AVMHomeAutomationTest70
{
    [TestClass]
    public class UnitTestDect100Repeater : UnitTestBase
    {
        [TestInitialize]
        public void Initialize()
        {
            this.testDevice = TestSettings.DeviceDect100Repeater;
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

        #region Temperature Sensor

        [TestMethod]
        public void TestMethodTemperature()
        {
            Device deviceInfos;
            double temperature;

            using (HomeAutomation client = new HomeAutomation(TestSettings.Login, TestSettings.Password))
            {
                deviceInfos = client.GetDeviceInfos(testDevice.Ain);
                temperature = client.GetTemperature(testDevice.Ain);
            }

            Assert.IsTrue(temperature > 14.0 && temperature < 25.0, "Range");
            Assert.IsNotNull(deviceInfos, "deviceInfo");
            Assert.IsNotNull(deviceInfos.Temperature, "Temperature");
            Assert.AreEqual(deviceInfos.Temperature.Celsius, temperature, "Compare");
        }

        [TestMethod]
        public async Task TestMethodTemperatureAsync()
        {
            Device deviceInfos;
            double temperature;

            using (HomeAutomation client = new HomeAutomation(TestSettings.Login, TestSettings.Password))
            {
                deviceInfos = await client.GetDeviceInfosAsync(testDevice.Ain);
                temperature = await client.GetTemperatureAsync(testDevice.Ain);
            }

            Assert.IsTrue(temperature > 14.0 && temperature < 25.0, "Range");
            Assert.IsNotNull(deviceInfos, "deviceInfo");
            Assert.IsNotNull(deviceInfos.Temperature, "Temperature");
            Assert.AreEqual(deviceInfos.Temperature.Celsius, temperature, "Compare");
        }

        #endregion

        #region Switch Socket

        [TestMethod]
        [ExpectedHttpRequestException(HttpStatusCode.InternalServerError)]
        public void TestMethodSetSwitchOnError()
        {
            using (HomeAutomation client = new HomeAutomation(TestSettings.Login, TestSettings.Password))
            {
                client.SetSwitchOn(testDevice.Ain);
            }
        }

        [TestMethod]
        [ExpectedHttpRequestException(HttpStatusCode.InternalServerError)]
        public async Task TestMethodSetSwitchOnAsyncError()
        {
            using (HomeAutomation client = new HomeAutomation(TestSettings.Login, TestSettings.Password))
            {
                await client.SetSwitchOnAsync(testDevice.Ain);
            }
        }

        [TestMethod]
        [ExpectedHttpRequestException(HttpStatusCode.InternalServerError)]
        public void TestMethodSetSwitchOffError()
        {
            using (HomeAutomation client = new HomeAutomation(TestSettings.Login, TestSettings.Password))
            {
                client.SetSwitchOff(testDevice.Ain);
            }
        }

        [TestMethod]
        [ExpectedHttpRequestException(HttpStatusCode.InternalServerError)]
        public async Task TestMethodSetSwitchOffAsyncError()
        {
            using (HomeAutomation client = new HomeAutomation(TestSettings.Login, TestSettings.Password))
            {
                await client.SetSwitchOffAsync(testDevice.Ain);
            }
        }

        [TestMethod]
        [ExpectedHttpRequestException(HttpStatusCode.InternalServerError)]
        public void TestMethodSetSwitchToggleError()
        {
            using (HomeAutomation client = new HomeAutomation(TestSettings.Login, TestSettings.Password))
            {
                client.SetSwitchToggle(testDevice.Ain);
            }
        }

        [TestMethod]
        [ExpectedHttpRequestException(HttpStatusCode.InternalServerError)]
        public async Task TestMethodSetSwitchToggleAsyncError()
        {
            using (HomeAutomation client = new HomeAutomation(TestSettings.Login, TestSettings.Password))
            {
                await client.SetSwitchToggleAsync(testDevice.Ain);
            }
        }

        [TestMethod]
        [ExpectedHttpRequestException(HttpStatusCode.InternalServerError)]
        public void TestMethodGetSwitchStateError()
        {
            bool? val;
            using (HomeAutomation client = new HomeAutomation(TestSettings.Login, TestSettings.Password))
            {
                val = client.GetSwitchState(testDevice.Ain);
            }
        }

        [TestMethod]
        [ExpectedHttpRequestException(HttpStatusCode.InternalServerError)]
        public async Task TestMethodGetSwitchStateAsyncError()
        {
            bool? val;
            using (HomeAutomation client = new HomeAutomation(TestSettings.Login, TestSettings.Password))
            {
                val = await client.GetSwitchStateAsync(testDevice.Ain);
            }

            Assert.IsTrue(val);
        }

        #endregion

        #region Radiator Controller

        [TestMethod]
        [ExpectedHttpRequestException(HttpStatusCode.InternalServerError)]
        public void TestMethodGetHkrtSollError()
        {
            double temp;
            using (HomeAutomation client = new HomeAutomation(TestSettings.Login, TestSettings.Password))
            {
                temp = client.GetHkrtSoll(testDevice.Ain);
            }
        }

        [TestMethod]
        [ExpectedHttpRequestException(HttpStatusCode.InternalServerError)]
        public async Task TestMethodGetHkrtSollAsyncError()
        {
            double temp;
            using (HomeAutomation client = new HomeAutomation(TestSettings.Login, TestSettings.Password))
            {
                temp = await client.GetHkrtSollAsync(testDevice.Ain);
            }
        }

        [TestMethod]
        [ExpectedHttpRequestException(HttpStatusCode.InternalServerError)]
        public void TestMethodGetHkrKomfortError()
        {
            double temp;
            using (HomeAutomation client = new HomeAutomation(TestSettings.Login, TestSettings.Password))
            {
                temp = client.GetHkrKomfort(testDevice.Ain);
            }
        }

        [TestMethod]
        [ExpectedHttpRequestException(HttpStatusCode.InternalServerError)]
        public async Task TestMethodGetHkrKomfortAsyncError()
        {
            double temp;
            using (HomeAutomation client = new HomeAutomation(TestSettings.Login, TestSettings.Password))
            {
                temp = await client.GetHkrKomfortAsync(testDevice.Ain);
            }
        }

        [TestMethod]
        [ExpectedHttpRequestException(HttpStatusCode.InternalServerError)]
        public void TestMethodGetHkrAbsenkError()
        {
            double temp;
            using (HomeAutomation client = new HomeAutomation(TestSettings.Login, TestSettings.Password))
            {
                temp = client.GetHkrAbsenk(testDevice.Ain);
            }
        }

        [TestMethod]
        [ExpectedHttpRequestException(HttpStatusCode.InternalServerError)]
        public async Task TestMethodGetHkrAbsenkAsyncError()
        {
            double temp;
            using (HomeAutomation client = new HomeAutomation(TestSettings.Login, TestSettings.Password))
            {
                temp = await client.GetHkrAbsenkAsync(testDevice.Ain);
            }
        }

        [TestMethod]
        [ExpectedHttpRequestException(HttpStatusCode.InternalServerError)]
        public void TestMethodSetHkrtSollError()
        {
            double temp;
            using (HomeAutomation client = new HomeAutomation(TestSettings.Login, TestSettings.Password))
            {
                temp = client.SetHkrtSoll(testDevice.Ain, 17.5);
            }
        }

        [TestMethod]
        [ExpectedHttpRequestException(HttpStatusCode.InternalServerError)]
        public async Task TestMethodSetHkrtSollAsyncError()
        {
            double temp;
            using (HomeAutomation client = new HomeAutomation(TestSettings.Login, TestSettings.Password))
            {
                temp = await client.SetHkrtSollAsync(testDevice.Ain, 17.5);
            }
        }

        [TestMethod]
        [ExpectedHttpRequestException(HttpStatusCode.InternalServerError)]
        public void TestMethodSetHkrBoostError()
        {
            DateTime? res;
            using (HomeAutomation client = new HomeAutomation(TestSettings.Login, TestSettings.Password))
            {
                res = client.SetHkrBoost(testDevice.Ain, DateTime.Now + new TimeSpan(0, 10,0));
            }
        }

        [TestMethod]
        [ExpectedHttpRequestException(HttpStatusCode.InternalServerError)]
        public async Task TestMethodSetHkrBoostAsyncError()
        {
            DateTime? res;
            using (HomeAutomation client = new HomeAutomation(TestSettings.Login, TestSettings.Password))
            {
                res = await client.SetHkrBoostAsync(testDevice.Ain, DateTime.Now + new TimeSpan(0, 10, 0));
            }
        }

        [TestMethod]
        [ExpectedHttpRequestException(HttpStatusCode.InternalServerError)]
        public void TestMethodSetHkrWindowOpenError()
        {
            DateTime? res;
            using (HomeAutomation client = new HomeAutomation(TestSettings.Login, TestSettings.Password))
            {
                res = client.SetHkrWindowOpen(testDevice.Ain, DateTime.Now + new TimeSpan(0, 10, 0));
            }
        }

        [TestMethod]
        [ExpectedHttpRequestException(HttpStatusCode.InternalServerError)]
        public async Task TestMethodSetHkrWindowOpenAsyncError()
        {
            DateTime? res;
            using (HomeAutomation client = new HomeAutomation(TestSettings.Login, TestSettings.Password))
            {
                res = await client.SetHkrWindowOpenAsync(testDevice.Ain, DateTime.Now + new TimeSpan(0, 10, 0));
            }
        }

        #endregion

        #region Blind

        [TestMethod]
        [ExpectedHttpRequestException(HttpStatusCode.InternalServerError)]
        public void TestMethodSetBlindError()
        {
            using (HomeAutomation client = new HomeAutomation(TestSettings.Login, TestSettings.Password))
            {
                client.SetBlind(testDevice.Ain, Target.Stop);
            }
        }

        [TestMethod]
        [ExpectedHttpRequestException(HttpStatusCode.InternalServerError)]
        public async Task TestMethodSetBlindAsyncError()
        {
            using (HomeAutomation client = new HomeAutomation(TestSettings.Login, TestSettings.Password))
            {
                await client.SetBlindAsync(testDevice.Ain, Target.Stop);
            }
        }

        #endregion

        #region Simple

        //[TestMethod]
        //[ExpectedHttpRequestException(HttpStatusCode.InternalServerError)]
        //public void TestMethodSetSimpleOnOffError()
        //{
        //    using (HomeAutomation client = new HomeAutomation(TestSettings.Login, TestSettings.Password))
        //    {
        //        client.SetSimpleOnOff(testDevice.Ain, OnOff.Off);
        //    }
        //}

        //[TestMethod]
        //[ExpectedHttpRequestException(HttpStatusCode.InternalServerError)]
        //public async Task TestMethodSetSimpleOnOffAsyncError()
        //{
        //    using (HomeAutomation client = new HomeAutomation(TestSettings.Login, TestSettings.Password))
        //    {
        //        await client.SetSimpleOnOffAsync(testDevice.Ain, OnOff.Toggle);
        //    }
        //}

        //[TestMethod]
        //[ExpectedHttpRequestException(HttpStatusCode.InternalServerError)]
        //public void TestMethodSetLevelError()
        //{
        //    using (HomeAutomation client = new HomeAutomation(TestSettings.Login, TestSettings.Password))
        //    {
        //        client.SetLevel(testDevice.Ain, 50);
        //    }
        //}

        //[TestMethod]
        //[ExpectedHttpRequestException(HttpStatusCode.InternalServerError)]
        //public async Task TestMethodSetLevelAsyncError()
        //{
        //    using (HomeAutomation client = new HomeAutomation(TestSettings.Login, TestSettings.Password))
        //    {
        //        await client.SetLevelAsync(testDevice.Ain, 50);
        //    }
        //}

        //[TestMethod]
        //[ExpectedHttpRequestException(HttpStatusCode.InternalServerError)]
        //public void TestMethodSetLevelPercentageError()
        //{
        //    using (HomeAutomation client = new HomeAutomation(TestSettings.Login, TestSettings.Password))
        //    {
        //        client.SetLevelPercentage(testDevice.Ain, 50);
        //    }
        //}

        //[TestMethod]
        //[ExpectedHttpRequestException(HttpStatusCode.InternalServerError)]
        //public async Task TestMethodSetLevelPercentageAsyncError()
        //{
        //    using (HomeAutomation client = new HomeAutomation(TestSettings.Login, TestSettings.Password))
        //    {
        //        await client.SetLevelPercentageAsync(testDevice.Ain, 50);
        //    }
        //}

        //[TestMethod]
        //[ExpectedHttpRequestException(HttpStatusCode.InternalServerError)]
        //public void TestMethodSetColorError()
        //{
        //    using (HomeAutomation client = new HomeAutomation(TestSettings.Login, TestSettings.Password))
        //    {
        //        client.SetColor(testDevice.Ain, 50, 200);
        //    }
        //}

        //[TestMethod]
        //[ExpectedHttpRequestException(HttpStatusCode.InternalServerError)]
        //public async Task TestMethodSetColorAsyncError()
        //{
        //    using (HomeAutomation client = new HomeAutomation(TestSettings.Login, TestSettings.Password))
        //    {
        //        await client.SetColorAsync(testDevice.Ain, 50, 200);
        //    }
        //}

        //[TestMethod]
        //[ExpectedHttpRequestException(HttpStatusCode.InternalServerError)]
        //public void TestMethodSetUnmappedColorError()
        //{
        //    using (HomeAutomation client = new HomeAutomation(TestSettings.Login, TestSettings.Password))
        //    {
        //        client.SetUnmappedColor(testDevice.Ain, 50, 200);
        //    }
        //}

        //[TestMethod]
        //[ExpectedHttpRequestException(HttpStatusCode.InternalServerError)]
        //public async Task TestMethodSetUnmappedColorAsyncError()
        //{
        //    using (HomeAutomation client = new HomeAutomation(TestSettings.Login, TestSettings.Password))
        //    {
        //        await client.SetUnmappedColorAsync(testDevice.Ain, 50, 200);
        //    }
        //}

        //[TestMethod]
        //[ExpectedHttpRequestException(HttpStatusCode.InternalServerError)]
        //public void TestMethodSetColorTemperatureError()
        //{
        //    using (HomeAutomation client = new HomeAutomation(TestSettings.Login, TestSettings.Password))
        //    {
        //        client.SetColorTemperature(testDevice.Ain, 5000);
        //    }
        //}

        //[TestMethod]
        //[ExpectedHttpRequestException(HttpStatusCode.InternalServerError)]
        //public async Task TestMethodSetColorTemperatureAsyncError()
        //{
        //    using (HomeAutomation client = new HomeAutomation(TestSettings.Login, TestSettings.Password))
        //    {
        //        await client.SetColorTemperatureAsync(testDevice.Ain, 5000);
        //    }
        //}
        
        #endregion
    }
}       
                