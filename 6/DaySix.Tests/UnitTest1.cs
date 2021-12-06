using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DaySix.Tests
{
    [TestClass]
    public class UnitTest1
    {
        private readonly FishProcessService _service;

        public UnitTest1()
        {
            _service = new FishProcessService();
        }

        [TestMethod]
        public void TestMethod1()
        {
            var children = _service.CountFishChildren(new LanternFish() { SpawnTimer = 3 }, 18);
            Assert.AreEqual(4, children);
        }
    }
}