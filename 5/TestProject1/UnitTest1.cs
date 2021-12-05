using DayFive.Services;
using Xunit;
using System.Linq;
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
        [Fact]
        public void Correct_CoordCountBackY()
        {
            var coords = _service.GetCoordinateListFromRange(new Coordinate() { X = 3, Y = 1 }, new() { X = 3, Y = 10 });
            Assert.Equal(10, coords.Count);
        }
        [Fact]
        public void Correct_CoordCountY()
        {
            var coords = _service.GetCoordinateListFromRange(new Coordinate() { X = 3, Y = 10}, new() { X = 3, Y = 1 });
            Assert.Equal(10, coords.Count);
        }
        [Fact]
        public void Correct_CoordCountBack()
        {
            var coords = _service.GetCoordinateListFromRange(new Coordinate() { X = 3, Y = 1 }, new() { X = 1, Y = 1 });
            Assert.Equal(3, coords.Count);
        }
        [Fact]
        public void Correct_CoordCountDiagonal()
        {
            var coords = _service.GetCoordinateListFromRange(new Coordinate() { X = 9, Y = 7 }, new() { X = 7, Y = 9 });
            Assert.Equal(3, coords.Count);
            Assert.Equal(1, coords.Where(x => x.X == 9 && x.Y == 7).Count());
            Assert.Equal(1, coords.Where(x => x.X == 8 && x.Y == 8).Count());
            Assert.Equal(1, coords.Where(x => x.X == 7 && x.Y == 9).Count());
        }

        [Fact]
        public void Correct_CoordCountOtherDiagonal()
        {
            var coords = _service.GetCoordinateListFromRange(new Coordinate() { X =1, Y = 1}, new() { X = 3, Y = 3});
            Assert.Equal(3, coords.Count);
            Assert.Equal(1, coords.Where(x => x.X == 1 && x.Y == 1).Count());
            Assert.Equal(1, coords.Where(x => x.X == 2 && x.Y == 2).Count());
            Assert.Equal(1, coords.Where(x => x.X == 3 && x.Y == 3).Count());
        }
        [Fact]
        public void Correct_CoordCountOtherDiagonalBack()
        {
            var coords = _service.GetCoordinateListFromRange(new Coordinate() { X = 3, Y = 3 }, new() { X = 1, Y = 1 });
            Assert.Equal(3, coords.Count);
            Assert.Equal(1, coords.Where(x => x.X == 1 && x.Y == 1).Count());
            Assert.Equal(1, coords.Where(x => x.X == 2 && x.Y == 2).Count());
            Assert.Equal(1, coords.Where(x => x.X == 3 && x.Y == 3).Count());
        }
        [Fact]
        public void Correct_CoordCountOtherDiagonalAnoying()
        {
            var coords = _service.GetCoordinateListFromRange(new Coordinate() { X = 6, Y = 4}, new() { X = 2, Y = 0 });
            Assert.Equal(5, coords.Count);
            Assert.Equal(1, coords.Where(x => x.X == 6 && x.Y == 4).Count());
            Assert.Equal(1, coords.Where(x => x.X == 5 && x.Y == 3).Count());
            Assert.Equal(1, coords.Where(x => x.X == 4 && x.Y == 2).Count());
            Assert.Equal(1, coords.Where(x => x.X == 3 && x.Y == 1).Count());
            Assert.Equal(1, coords.Where(x => x.X == 2 && x.Y == 0).Count());
        }

        [Fact]
        public void Correct_CoordCountOtherDiagonalAnoyingback()
        {
            var coords = _service.GetCoordinateListFromRange(new Coordinate() { X = 2, Y = 0 }, new() { X = 6, Y = 4 });
            Assert.Equal(5, coords.Count);
            Assert.Equal(1, coords.Where(x => x.X == 6 && x.Y == 4).Count());
            Assert.Equal(1, coords.Where(x => x.X == 5 && x.Y == 3).Count());
            Assert.Equal(1, coords.Where(x => x.X == 4 && x.Y == 2).Count());
            Assert.Equal(1, coords.Where(x => x.X == 3 && x.Y == 1).Count());
            Assert.Equal(1, coords.Where(x => x.X == 2 && x.Y == 0).Count());
        }
    }
}