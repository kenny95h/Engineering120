using NUnit.Framework;
using System;
using Methods_Lib;

namespace Methods_Tests
{
    public class DiceTests
    {
        [Test]
        public void RollDice_ReturnsNumberBetween0and12Inclusive()
        {
            Assert.That(Methods.RollDice(new Random()), Is.InRange(2,12));
        }

        [TestCase(0, 10)]
        [TestCase(535, 7)]
        public void GivenANumber_RollDice_ReturnsNumberBetween0and12Inclusive(int num, int expectedResult)
        {
            Assert.That(Methods.RollDice(new Random(num)), Is.EqualTo(expectedResult));
        }
    }
}

