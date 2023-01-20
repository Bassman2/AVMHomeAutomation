
using System.Net;

namespace AVMHomeAutomationTest70
{
    public partial class UnitTestDect210Socket : UnitTestBase
    {
        #region Switch Socket

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

        #endregion
    }
}