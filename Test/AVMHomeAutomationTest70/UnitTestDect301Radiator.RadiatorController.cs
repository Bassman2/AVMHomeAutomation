using System.Net;

namespace AVMHomeAutomationTest70
{
    public partial class UnitTestDect301Radiator : UnitTestBase
    {
        #region Radiator Controller

        [TestMethod]
        public void TestMethodGetHkrKomfort()
        {
            Device deviceInfos;
            double temperature;

            using (HomeAutomation client = new HomeAutomation(TestSettings.Login, TestSettings.Password))
            {
                deviceInfos = client.GetDeviceInfos(testDevice.Ain);
                temperature = client.GetHkrKomfort(testDevice.Ain);
            }

            Assert.IsTrue(temperature > 18.0 && temperature < 23.0);
            Assert.IsNotNull(deviceInfos);
            Assert.IsNotNull(deviceInfos.Hkr);
            Assert.AreEqual(deviceInfos.Hkr.Komfort, temperature);
        }

        [TestMethod]
        public async Task TestMethodGetHkrKomfortAsync()
        {
            Device deviceInfos;
            double temperature;

            using (HomeAutomation client = new HomeAutomation(TestSettings.Login, TestSettings.Password))
            {
                deviceInfos = await client.GetDeviceInfosAsync(testDevice.Ain);
                temperature = await client.GetHkrKomfortAsync(testDevice.Ain);
            }

            Assert.IsTrue(temperature > 18.0 && temperature < 23.0);
            Assert.IsNotNull(deviceInfos);
            Assert.IsNotNull(deviceInfos.Hkr);
            Assert.AreEqual(deviceInfos.Hkr.Komfort, temperature);
        }

        [TestMethod]
        public void TestMethodGetHkrAbsenk()
        {
            Device deviceInfos;
            double temperature;

            using (HomeAutomation client = new HomeAutomation(TestSettings.Login, TestSettings.Password))
            {
                deviceInfos = client.GetDeviceInfos(testDevice.Ain);
                temperature = client.GetHkrAbsenk(testDevice.Ain);
            }

            Assert.IsTrue(temperature > 13.0 && temperature < 17.0);
            Assert.IsNotNull(deviceInfos);
            Assert.IsNotNull(deviceInfos.Hkr);
            Assert.AreEqual(deviceInfos.Hkr.Absenk, temperature);

        }

        [TestMethod]
        public async Task TestMethodGetHkrAbsenkAsync()
        {
            Device deviceInfos;
            double temperature;

            using (HomeAutomation client = new HomeAutomation(TestSettings.Login, TestSettings.Password))
            {
                deviceInfos = await client.GetDeviceInfosAsync(testDevice.Ain);
                temperature = await client.GetHkrAbsenkAsync(testDevice.Ain);
            }

            Assert.IsTrue(temperature > 13.0 && temperature < 17.0);
            Assert.IsNotNull(deviceInfos);
            Assert.IsNotNull(deviceInfos.Hkr);
            Assert.AreEqual(deviceInfos.Hkr.Absenk, temperature);
        }

        [TestMethod]
        public void TestMethodHkrtSoll()
        {
            double tempSet = 23.5, tempOrg, tempTest1, tempTest2, tempReset1, tempReset2;

            using (HomeAutomation client = new HomeAutomation(TestSettings.Login, TestSettings.Password))
            {
                tempOrg = client.GetHkrtSoll(testDevice.Ain);
                tempTest1 = client.SetHkrtSoll(testDevice.Ain, tempSet);
                Thread.Sleep(1000);
                tempTest2 = client.GetHkrtSoll(testDevice.Ain);
                tempReset1 = client.SetHkrtSoll(testDevice.Ain, tempOrg);
                Thread.Sleep(1000);
                tempReset2 = client.GetHkrtSoll(testDevice.Ain);
            }

            Assert.AreEqual(tempSet, tempTest1);
            Assert.AreEqual(tempSet, tempTest2);
            Assert.AreNotEqual(tempOrg, tempTest1);
            Assert.AreEqual(tempOrg, tempReset1);
            Assert.AreEqual(tempOrg, tempReset2);
        }

        [TestMethod]
        public async Task TestMethodHkrtSollAsync()
        {
            double tempSet = 23.5, tempOrg, tempTest1, tempTest2, tempReset1, tempReset2;

            using (HomeAutomation client = new HomeAutomation(TestSettings.Login, TestSettings.Password))
            {
                tempOrg = await client.GetHkrtSollAsync(testDevice.Ain);
                tempTest1 = await client.SetHkrtSollAsync(testDevice.Ain, tempSet);
                Thread.Sleep(1000);
                tempTest2 = await client.GetHkrtSollAsync(testDevice.Ain);
                tempReset1 = await client.SetHkrtSollAsync(testDevice.Ain, tempOrg);
                Thread.Sleep(1000);
                tempReset2 = await client.GetHkrtSollAsync(testDevice.Ain);
            }

            Assert.AreEqual(tempSet, tempTest1);
            Assert.AreEqual(tempSet, tempTest2);
            Assert.AreNotEqual(tempOrg, tempTest1);
            Assert.AreEqual(tempOrg, tempReset1);
            Assert.AreEqual(tempOrg, tempReset2);
        }

        [TestMethod]
        public void TestMethodSetHkrBoost()
        {
            Device deviceInfos1;
            Device deviceInfos2;
            DateTime? dt1, dt2;
            DateTime now;

            using (HomeAutomation client = new HomeAutomation(TestSettings.Login, TestSettings.Password))
            {
                now = DateTime.Now;
                dt1 = client.SetHkrBoost(testDevice.Ain, now + new TimeSpan(0, 10, 0));
                deviceInfos1 = client.GetDeviceInfos(testDevice.Ain);
                dt2 = client.SetHkrBoost(testDevice.Ain, null);
                deviceInfos2 = client.GetDeviceInfos(testDevice.Ain);
            }

            Assert.IsTrue(dt1.HasValue);
            TimeSpan delta = (now.ToUniversalTime() + new TimeSpan(0, 10, 0)) - dt1.Value;
            Assert.IsTrue(delta < new TimeSpan(0, 0, 1));
            Assert.IsNull(dt2);
            Assert.IsTrue(deviceInfos1.Hkr.BoostActive);
            Assert.AreEqual(deviceInfos1.Hkr.BoostActiveEndTime, dt1);
            Assert.IsFalse(deviceInfos2.Hkr.BoostActive);
            Assert.IsFalse(deviceInfos2.Hkr.BoostActiveEndTime.HasValue);
        }

        [TestMethod]
        public async Task TestMethodSetHkrBoostAsync()
        {
            Device deviceInfos1;
            Device deviceInfos2;
            DateTime? dt1, dt2;
            DateTime now;

            using (HomeAutomation client = new HomeAutomation(TestSettings.Login, TestSettings.Password))
            {
                now = DateTime.Now;
                dt1 = await client.SetHkrBoostAsync(testDevice.Ain, DateTime.Now + new TimeSpan(0, 10, 0));
                deviceInfos1 = await client.GetDeviceInfosAsync(testDevice.Ain);
                dt2 = await client.SetHkrBoostAsync(testDevice.Ain, null);
                deviceInfos2 = await client.GetDeviceInfosAsync(testDevice.Ain);
            }

            Assert.IsTrue(dt1.HasValue);
            TimeSpan delta = (now.ToUniversalTime() + new TimeSpan(0, 10, 0)) - dt1.Value;
            Assert.IsTrue(delta < new TimeSpan(0, 0, 1));
            Assert.IsNull(dt2);
            Assert.IsTrue(deviceInfos1.Hkr.BoostActive);
            Assert.AreEqual(deviceInfos1.Hkr.BoostActiveEndTime, dt1);
            Assert.IsFalse(deviceInfos2.Hkr.BoostActive);
            Assert.IsFalse(deviceInfos2.Hkr.BoostActiveEndTime.HasValue);
        }

        [TestMethod]
        public void TestMethodSetHkrWindowOpen()
        {
            Device deviceInfos1;
            Device deviceInfos2;
            DateTime? dt1, dt2;
            DateTime now;

            using (HomeAutomation client = new HomeAutomation(TestSettings.Login, TestSettings.Password))
            {
                now = DateTime.Now;
                dt1 = client.SetHkrWindowOpen(testDevice.Ain, DateTime.Now + new TimeSpan(0, 10, 0));
                deviceInfos1 = client.GetDeviceInfos(testDevice.Ain);
                dt2 = client.SetHkrWindowOpen(testDevice.Ain, null);
                deviceInfos2 = client.GetDeviceInfos(testDevice.Ain);
            }

            Assert.IsTrue(dt1.HasValue);
            TimeSpan delta = (now.ToUniversalTime() + new TimeSpan(0, 10, 0)) - dt1.Value;
            Assert.IsTrue(delta < new TimeSpan(0, 0, 1));
            Assert.IsNull(dt2);
            Assert.IsTrue(deviceInfos1.Hkr.WindowOpenActiv);
            Assert.AreEqual(deviceInfos1.Hkr.WindowOpenActivEndTime, dt1);
            Assert.IsFalse(deviceInfos2.Hkr.WindowOpenActiv);
            Assert.IsFalse(deviceInfos2.Hkr.WindowOpenActivEndTime.HasValue);
        }

        [TestMethod]
        public async Task TestMethodSetHkrWindowOpenAsync()
        {
            Device deviceInfos1;
            Device deviceInfos2;
            DateTime? dt1, dt2;
            DateTime now;

            using (HomeAutomation client = new HomeAutomation(TestSettings.Login, TestSettings.Password))
            {
                now = DateTime.Now;
                dt1 = await client.SetHkrWindowOpenAsync(testDevice.Ain, DateTime.Now + new TimeSpan(0, 10, 0));
                deviceInfos1 = await client.GetDeviceInfosAsync(testDevice.Ain);
                dt2 = await client.SetHkrWindowOpenAsync(testDevice.Ain, null);
                deviceInfos2 = await client.GetDeviceInfosAsync(testDevice.Ain);
            }

            Assert.IsTrue(dt1.HasValue);
            TimeSpan delta = (now.ToUniversalTime() + new TimeSpan(0, 10, 0)) - dt1.Value;
            Assert.IsTrue(delta < new TimeSpan(0, 0, 1));
            Assert.IsNull(dt2);
            Assert.IsTrue(deviceInfos1.Hkr.WindowOpenActiv);
            Assert.AreEqual(deviceInfos1.Hkr.WindowOpenActivEndTime, dt1);
            Assert.IsFalse(deviceInfos2.Hkr.WindowOpenActiv);
            Assert.IsFalse(deviceInfos2.Hkr.WindowOpenActivEndTime.HasValue);
        }

        #endregion
    }
}       
                