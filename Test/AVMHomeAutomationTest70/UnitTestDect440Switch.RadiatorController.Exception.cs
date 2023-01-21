﻿using System.Net;

namespace AVMHomeAutomationTest70
{
    public partial class UnitTestDect440Switch : UnitTestBase
    {
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
    }
}       
                