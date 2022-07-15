using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SafariParkTest
{
    public class VehicleTests
    {
        [Test]
        public void WhenADefaultVehicleMovesTwiceItsPositionIs20()
        {
            Vehicle v = new Vehicle();
            var result = v.Move(2);
            Assert.AreEqual(20, v.Position);
            Assert.AreEqual("Moving along 2 times", result);
        }

        [Test]
        public void WhenADefaultVehicleMovesThreeTimesSeparatelyItsPositionIs30()
        {
            Vehicle v = new Vehicle();
            v.Move();
            v.Move();
            v.Move();
            Assert.AreEqual(30, v.Position);
        }

        [Test]
        public void WhenAVehicleWithSpeed40IsMovedOnceItsPositionIs40()
        {
            Vehicle v = new Vehicle(5, 40);
            var result = v.Move();
            Assert.AreEqual(40, v.Position);
            Assert.AreEqual("Moving along", result);
        }

        [Test]
        public void WhenADefaultVehicleWithASpeedOfNegative10MovesThreeTimesPositionIsNegative30()
        {
            Vehicle v = new Vehicle { Speed = -10 };
            var result = v.Move(3);
            Assert.AreEqual(-30, v.Position);
            Assert.AreEqual("Moving along 3 times", result);
        }


        [Test]
        public void WhenAVehicleWithOnlyCapacitySetMovesOncePositionIs10()
        {
            Vehicle v = new Vehicle(2);
            var result = v.Move();
            Assert.AreEqual(10, v.Position);
            Assert.AreEqual("Moving along", result);
        }

        [Test]
        public void WhenAVehicleSetsMorePassengersThanCapacity_Throws()
        {
            Vehicle v = new Vehicle(2);
            Assert.That(() => v.NumPassengers = 3, Throws.TypeOf<ArgumentOutOfRangeException>().With.Message.Contain("Not enough space in the vehicle"));
        }

        [Test]
        public void WhenAVehicleSetsNumPassengersAsANegativeNumber_Throws()
        {
            Vehicle v = new Vehicle();
            Assert.That(() => v.NumPassengers = -1, Throws.TypeOf<ArgumentOutOfRangeException>().With.Message.Contain("Must be a non-negative integer"));
        }

        [Test]
        public void WhenMoveIsPassedANegativeNumber_Throws()
        {
            Vehicle v = new Vehicle();
            Assert.That(() => v.Move(-1), Throws.TypeOf<ArgumentOutOfRangeException>().With.Message.Contain("Times must be a non-negative integer"));
        }

        [Test]
        public void WhenAVehiclePositionIsOverMaxValue_Throws()
        {
            Vehicle v = new Vehicle { Speed = int.MaxValue };
            Assert.That(() => v.Move(2), Throws.TypeOf<OverflowException>());
        }
    }
}
