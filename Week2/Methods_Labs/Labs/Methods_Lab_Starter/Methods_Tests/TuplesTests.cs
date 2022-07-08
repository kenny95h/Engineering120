using NUnit.Framework;
using Methods_Lib;
using System;

namespace Methods_Tests
{
    public class TuplesTests
    {
        [TestCase(25, 3, 4)]
        [TestCase(0, 0, 0)]
        [TestCase(33, 4, 5)]
        public void GivenANumber_DaysAndWeeks_ReturnsCorrectTuple(
            int totalDays, int expectedWeeks, int expectedDays)
        {
            var answer = Methods.DaysAndWeeks(totalDays);
            Assert.That(answer.weeks, Is.EqualTo(expectedWeeks), "Weeks");
            Assert.That(answer.days, Is.EqualTo(expectedDays), "Days");
        }
        [Test]
        public void GivenANegativeNumber_DaysAndWeeks_ThrowsAnException()
        {
            Assert.That(() => Methods.DaysAndWeeks(-1), Throws.TypeOf<ArgumentOutOfRangeException>()
        .With.Message.Contain("totalDays must not be negative"));
        }

        [TestCase(16, 256, 4096, 4)]
        [TestCase(8, 64, 512, 2.83)]
        [TestCase(1, 1, 1, 1)]
        [TestCase(0, 0, 0, 0)]
        public void GivenANumber_PowersRoot_ReturnsSquaredCubedandSquareRoot(
            int nums, int expectedSquare, int expectedCube, double expectedRoot)
        {
            Assert.That(Methods.PowersRoot(nums).square, Is.EqualTo(expectedSquare), "Square");
            Assert.That(Methods.PowersRoot(nums).cube, Is.EqualTo(expectedCube), "Cube");
            Assert.That(Methods.PowersRoot(nums).root, Is.EqualTo(expectedRoot) , "Square Root");
        }


        [Test]
        public void GivenALargeInt_PowersRoot_Throws()
        {
            Assert.That(() => Methods.PowersRoot(int.MaxValue), Throws.TypeOf<OverflowException>());
        }
    }
       
}