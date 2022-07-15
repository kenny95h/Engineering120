
namespace SafariParkTest
{
    public class PersonTests
    {
        [Test]
        public void Point3dTest()
        {
            //Arrange //Act
            var subject = new Point3d( 3, 6, 2 );
            //Assert
            Assert.That(subject.x, Is.EqualTo(3));
            Assert.That(subject.y, Is.EqualTo(6));
            Assert.That(subject.z, Is.EqualTo(2));

        }

        [Test]
        public void Point3dSumOfPointsTest()
        {
            //Arrange
            var subject = new Point3d(3, 6, 2);
            //Act
            var result = subject.SumOfPoints();
            //Assert
            Assert.That(result, Is.EqualTo(11));

        }

        [TestCase("Cathy", "French", "Cathy French")]
        [TestCase("", "", " ")]
        public void GetFullNameTest(string firstName, string lastName, string expectedResult)
        {
            Person subject = new Person(firstName, lastName);
            var result = subject.FullName;
            Assert.AreEqual(expectedResult, result);
        }

        [Test]
        public void AgeTest()
        {
            var subject = new Person("A", "B") { Age = 33 };
            Assert.That(subject.Age, Is.EqualTo(33));
        }
    }
}