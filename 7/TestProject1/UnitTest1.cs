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
    }
}