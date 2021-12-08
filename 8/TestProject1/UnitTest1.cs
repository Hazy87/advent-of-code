using System.Collections.Generic;
using DayEight.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Xunit;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace TestProject1
{
    [TestClass]
    public class SegmentFinderTests
    {
        private readonly NumberFindingService _service;

        public SegmentFinderTests()
        {
            _service = new NumberFindingService();
        }

        [Fact]
        public void SplitSixNineZero()
        {
            var (zero, six, nine) = _service.SplitSixNineZero(new List<string> { "abdefg", "abcdfg", "abcefg" }, "cf", "bcdf", "acf");
            Assert.AreEqual(zero, "abcefg");
            Assert.AreEqual(six, "abdefg");
            Assert.AreEqual(nine, "abcdfg");
        }

        [Fact]
        public void SplitTwoThreeFive()
        {
            var (two, three, five) = _service.SplitTwoThreeAndFive(new List<string> { "acdeg", "acdfg", "abdfg" }, "cf","abcdfg");
            Assert.AreEqual(two, "acdeg");
            Assert.AreEqual(three, "acdfg");
            Assert.AreEqual(five, "abdfg");
        }
    }
}