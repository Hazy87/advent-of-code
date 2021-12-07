using System.Linq;
using System.Reflection.Metadata;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Xunit;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace TestProject1
{
    [TestClass]
    public class UnitTest1
    {
        private readonly FuelCalculatorService _service;

        public UnitTest1()
        {
            _service = new FuelCalculatorService();
        }
        [Theory]
        [InlineData("16,1,2,0,4,2,7,1,2,14")]
        public void TestMethod1(string positions)
        {
            var crabPositions = positions.Split(",").Select(x => int.Parse(x));
            var minNumber = _service.GetMinimumFuelRequired(crabPositions.ToArray());
            Assert.AreEqual(37, minNumber);
        }

        [Theory]
        [InlineData("16,1,2,0,4,2,7,1,2,14")]
        public void GetMinimumFuelRequiredFuelRates(string positions)
        {
            var crabPositions = positions.Split(",").Select(x => int.Parse(x));
            var minNumber = _service.GetMinimumFuelRequiredFuelRates(crabPositions.ToArray());
            Assert.AreEqual(168, minNumber);
        }

        [Theory]
        [InlineData(1,2,1)]
        [InlineData(1,3,3)]
        [InlineData(1,4,6)]
        [InlineData(4,1,6)]
        public void GetFuelRate(int oldPosition, int newPosition, int expectedValue)
        {
            var minNumber = _service.GetFuelRate(oldPosition, newPosition);
            Assert.AreEqual(expectedValue, minNumber);
        }
    }
}