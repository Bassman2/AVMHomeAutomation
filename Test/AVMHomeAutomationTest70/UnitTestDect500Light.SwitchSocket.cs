﻿using System.Net;

namespace AVMHomeAutomationTest70
{
    public partial class UnitTestDect500Light : UnitTestBase
    {
        #region Switch Socket

        [TestMethod]
        public void TestMethodSwitch()
        {
            bool? res1, state1, res2, state2, res3, state3;

            using (HomeAutomation client = new HomeAutomation(TestSettings.Login, TestSettings.Password))
            {
                res1 = client.SetSwitchOff(testDevice.Ain);
                Sleep();
                state1 = client.GetSwitchState(testDevice.Ain);
                res2 = client.SetSwitchOn(testDevice.Ain);
                Sleep();
                state2 = client.GetSwitchState(testDevice.Ain);
                res3 = client.SetSwitchToggle(testDevice.Ain);
                Sleep();
                state3 = client.GetSwitchState(testDevice.Ain);
            }

            Assert.IsFalse(res1.Value, "res1");
            Assert.IsFalse(state1.Value, "state1");
            Assert.IsTrue(res2.Value, "res2");
            Assert.IsTrue(state2.Value, "state2");
            Assert.IsFalse(res3.Value, "res3");
            Assert.IsFalse(state3.Value, "state3");
        }

        [TestMethod]
        public async Task TestMethodSwitchAsync()
        {
            bool? res1, state1, res2, state2, res3, state3;

            using (HomeAutomation client = new HomeAutomation(TestSettings.Login, TestSettings.Password))
            {
                res1 = await client.SetSwitchOffAsync(testDevice.Ain);
                Sleep();
                state1 = await client.GetSwitchStateAsync(testDevice.Ain);
                res2 = await client.SetSwitchOnAsync(testDevice.Ain);
                Sleep();
                state2 = await client.GetSwitchStateAsync(testDevice.Ain);
                res3 = await client.SetSwitchToggleAsync(testDevice.Ain);
                Sleep();
                state3 = await client.GetSwitchStateAsync(testDevice.Ain);
            }

            Assert.IsFalse(res1.Value, "res1");
            Assert.IsFalse(state1.Value, "state1");
            Assert.IsTrue(res2.Value, "res2");
            Assert.IsTrue(state2.Value, "state2");
            Assert.IsFalse(res3.Value, "res3");
            Assert.IsFalse(state3.Value, "state3");
        }

        #endregion
    }
}       
                