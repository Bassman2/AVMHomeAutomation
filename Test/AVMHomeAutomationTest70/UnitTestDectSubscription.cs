namespace AVMHomeAutomationTest70
{
    [TestClass]
    public class UnitTestDectSubscription
    {
        [TestMethod]
        public void TestMethodSubscription()
        {
            State preState;
            State runState;

            using (HomeAutomation client = new HomeAutomation(TestSettings.Login, TestSettings.Password))
            {
                preState = client.GetSubscriptionState();
                client.StartUleSubscription();
                do
                {
                    Thread.Sleep(30000);
                    runState = client.GetSubscriptionState();
                } while (runState.Code == Code.SubscriptionRunning);
            }

            Assert.AreEqual(Code.NoSubscription, preState.Code);
            Assert.AreEqual(Code.NoSubscription, runState.Code);
            Assert.IsTrue(!string.IsNullOrEmpty(runState.LatestAin));

        }
    }
}

