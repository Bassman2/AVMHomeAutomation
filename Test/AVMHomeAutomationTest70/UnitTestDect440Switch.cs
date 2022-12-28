using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AVMHomeAutomationTest70
{
    [TestClass]
    public class UnitTestDect440Switch : UnitTestBase
    {
        [TestInitialize]
        public void Initialize()
        {
            this.testDevice = TestSettings.DeviceDect440Switch;
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
            Assert.IsTrue(stats.Humidity.Count > 0);
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

        //[TestMethod]
        //public void TestMethodGetSwitch()
        //{
        //    bool state1, state2, state3;

        //    using (HomeAutomation client = new HomeAutomation(TestSettings.Login, TestSettings.Password))
        //    {
        //        //client.SetSwitchOff(testDevice.Ain);
        //        state1 = client.GetSwitchState(testDevice.Ain);
        //        //client.SetSwitchOn(testDevice.Ain);
        //        state2 = client.GetSwitchState(testDevice.Ain);
        //        //client.SetSwitchToggle(testDevice.Ain);
        //        state3 = client.GetSwitchState(testDevice.Ain);
        //    }

        //    Assert.IsFalse(state1);
        //    Assert.IsTrue(state2);
        //    Assert.IsFalse(state3);

        //}

       
    }
}
