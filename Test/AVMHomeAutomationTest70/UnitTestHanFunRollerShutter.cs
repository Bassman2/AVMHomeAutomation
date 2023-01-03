namespace AVMHomeAutomationTest70
{
    [TestClass]
    public class UnitTestHanFunRollerShutter : UnitTestBase
    {
        [TestInitialize]
        public void Initialize()
        {
            this.testDevice = TestSettings.DeviceHanFunRollerShutter;
        }

        [TestMethod]
        public void TestMethodSetBlind()
        {
            //ColorDefaults colorDefaults;

            using (HomeAutomation client = new HomeAutomation(TestSettings.Login, TestSettings.Password))
            {
                client.SetBlind(this.testDevice.Ain, Target.Close);
                Thread.Sleep(10000);                
                client.SetBlind(this.testDevice.Ain, Target.Open);
            }

            //Assert.IsNotNull(colorDefaults);
            //CollectionAssert.AreEquivalent(new int[] { 2700, 3000, 3400, 3800, 4200, 4700, 5300, 5900, 6500 }, colorDefaults.TemperatureDefaults.Select((t) => t.Value).ToList());
        }

        [TestMethod]
        public async Task TestMethodSetBlindAsync()
        {
            //ColorDefaults colorDefaults;

            using (HomeAutomation client = new HomeAutomation(TestSettings.Login, TestSettings.Password))
            {
                await client.SetBlindAsync(this.testDevice.Ain, Target.Close);
                Thread.Sleep(10000);
                await client.SetBlindAsync(this.testDevice.Ain, Target.Open);
            }

            //Assert.IsNotNull(colorDefaults);
            //CollectionAssert.AreEquivalent(new int[] { 2700, 3000, 3400, 3800, 4200, 4700, 5300, 5900, 6500 }, colorDefaults.TemperatureDefaults.Select((t) => t.Value).ToList());
        }
    }
}
