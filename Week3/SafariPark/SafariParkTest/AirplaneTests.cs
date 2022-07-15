using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SafariParkTest
{
    public class AirplaneTests
    {
        [Test]
        public void GivenAnAirplaneWithCapacity200Speed100NameNumPassengers150_WhenMove3AndAscend500_ToStringReturnExpected()
        {
            Airplane a = new Airplane(200, 100, "JetsRUs") { NumPassengers = 150 };
            a.Move(3);
            a.Ascend(500);
            var result = a.ToString();
            Assert.AreEqual("Thank you for flying JetsRUs: SafariParkApp.Airplane capacity: 200 passengers: 150 speed: 100 position: 300 altitude: 500.", result);
        }

        [TestCase(0, 0)]
        [TestCase(10, 2000)]
        [TestCase(1, 200)]
        public void GivenAnAirplaneWithCapacityAndSpeed200_MoveTimes_ReturnsExpectedPosition(int times, int expectedPosition)
        {
            Airplane a = new Airplane(200) { Speed = 200 };
            a.Move(times);
            Assert.AreEqual(expectedPosition, a.Position);

        }

        [Test]
        public void GivenAnAirplaneWithAnAltitude200ThatMovesOnce_PositionIs10()
        {
            Airplane a = new Airplane(0);
            a.Ascend(200);
            var result = a.Move();
            Assert.AreEqual(10, a.Position);
            Assert.AreEqual("Moving along at an altitude of 200 metres.", result);
        }

        [Test]
        public void GivenAnAirplaneThatMovesFiveTimesPositionIs50()
        {
            Airplane a = new Airplane(0);
            var result = a.Move(5);
            Assert.AreEqual(50, a.Position);
            Assert.AreEqual("Moving along 5 times at an altitude of 0 metres.", result);
        }


        [TestCase(0, 0)]
        [TestCase(150, 150)]
        [TestCase(100, 100)]
        [TestCase(1, 1)]
        public void AirplaneCapacityTests(int numPassengers, int expectedPassengers)
        {
            Airplane a = new Airplane(150) { NumPassengers = numPassengers};
            Assert.AreEqual(expectedPassengers, a.NumPassengers);
        }

        //Exceptions
        [Test]
        public void WhenAscendIsPassedANegativeNumber_Throws()
        {
            Airplane a = new Airplane(0);
            Assert.That(() => a.Ascend(-1), Throws.TypeOf<ArgumentOutOfRangeException>());
        }

        [Test]
        public void WhenDescendIsPassedANegativeNumber_Throws()
        {
            Airplane a = new Airplane(0);
            Assert.That(() => a.Descend(-1), Throws.TypeOf<ArgumentOutOfRangeException>());
        }

        [Test]
        public void GivenADistanceThatIsLargerThanPosition_Descend_Throws()
        {
            Airplane a = new Airplane(0);
            Assert.That(() => a.Descend(100), Throws.TypeOf<ArgumentOutOfRangeException>());
        }

        [Test]
        public void GivenADistanceThatCausesAnOverflow_Ascend_Throws()
        {
            Airplane a = new Airplane(0);
            a.Ascend(int.MaxValue);
            Assert.That(() => a.Ascend(10), Throws.TypeOf<OverflowException>());
        }
    }
}
