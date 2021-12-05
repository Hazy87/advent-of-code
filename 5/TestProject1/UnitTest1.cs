using DayFive.Services;
using Xunit;

namespace TestProject1
{
    public class UnitTest1
    {
        private CoordinateService _service;

        public UnitTest1()
        {
            _service = new CoordinateService();
        }
        [Fact]
        public void Correct_CoordCount()
        {
            var coords = _service.GetCoordinateListFromRange(new Coordinate() { X = 1, Y = 1 }, new() { X = 3, Y = 1 });
            Assert.Equal(3, coords.Count);
        }
    }
}