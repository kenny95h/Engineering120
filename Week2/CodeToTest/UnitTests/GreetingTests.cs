using CodeToTest;

namespace UnitTests
{
    public class Tests
    {

        [Test]
        public void GivenATimeOf21_Greeting_ReturnsGoodEvening()
        {
            //Arrange
            //var time = 21;
            //var expectedGreeting = "Good evening!";
            //Act
            //var result = Program.Greeting(time);
            //Assert
            //Assert.That(result, Is.EqualTo(expectedGreeting));

            Assert.That(Program.Greeting(21), Is.EqualTo("Good evening!"));

        }

        [TestCase(11, "Good morning!")]
        [TestCase(5, "Good morning!")]
        [TestCase(18, "Good afternoon!")]
        [TestCase(12, "Good afternoon!")]
        [TestCase(4, "Good evening!")]
        [TestCase(19, "Good evening!")]
        [TestCase(-1, "Invalid time")]
        [TestCase(24, "Invalid time")]
        public void GivenATimeOfBoundaries_Greeting_ReturnsExpectedGreeting(int time, string Greet)
        {

            Assert.That(Program.Greeting(time), Is.EqualTo(Greet));

        }

        [TestCase(19)]
        [TestCase(4)]
        public void GivenATimeOfBetween19and4Inclusive_Greeting_ReturnsGoodEvening(int time)
        {

            Assert.That(Program.Greeting(time), Is.EqualTo("Good evening!"));

        }
        [TestCase(5)]
        [TestCase(8)]
        [TestCase(11)]
        public void GivenATimeOfBetween5and11Inclusive_Greeting_ReturnsGoodMorning(int time)
        {

            Assert.That(Program.Greeting(time), Is.EqualTo("Good morning!"));

        }
    }

    public class Classification_Tests
    {
        [TestCase(0, "U & PG films are available.")]
        [TestCase(11, "U & PG films are available.")]
        public void GivenAgeOfBoundaries0to11_AvailableClassifications_ReturnsExpectedCert(int age, string result)
        {
            Assert.That(Program.AvailableClassifications(age), Is.EqualTo(result));
        }

        [TestCase(12, "U, PG & 12 films are available.")]
        [TestCase(14, "U, PG & 12 films are available.")]
        public void GivenAgeOfBoundaries12to14_AvailableClassifications_ReturnsExpectedCert(int age, string result)
        {
            Assert.That(Program.AvailableClassifications(age), Is.EqualTo(result));
        }

        [TestCase(15, "U, PG, 12 & 15 films are available.")]
        [TestCase(17, "U, PG, 12 & 15 films are available.")]
        public void GivenAgeOfBoundaries15to17_AvailableClassifications_ReturnsExpectedCert(int age, string result)
        {
            Assert.That(Program.AvailableClassifications(age), Is.EqualTo(result));
        }

        [TestCase(18, "All films are available.")]
        [TestCase(100, "All films are available.")]
        public void GivenAgeOfBoundariesOver17_AvailableClassifications_ReturnsExpectedCert(int age, string result)
        {
            Assert.That(Program.AvailableClassifications(age), Is.EqualTo(result));
        }

        [TestCase(6)]
        public void GivenAgeBetween0and11Inclusive_AvailableClassifications_ReturnsUandPG(int age)
        {
            Assert.That(Program.AvailableClassifications(age), Is.EqualTo("U & PG films are available."));
        }
        [TestCase(13)]
        public void GivenAgeBetween12and14Inclusive_AvailableClassifications_ReturnsUPGand12(int age)
        {
            Assert.That(Program.AvailableClassifications(age), Is.EqualTo("U, PG & 12 films are available."));
        }
        [TestCase(16)]
        public void GivenAgeBetween15and17Inclusive_AvailableClassifications_ReturnsUPG12and15(int age)
        {
            Assert.That(Program.AvailableClassifications(age), Is.EqualTo("U, PG, 12 & 15 films are available."));
        }
        [TestCase(40)]
        public void GivenAgeOver18_AvailableClassifications_ReturnsAll(int age)
        {
            Assert.That(Program.AvailableClassifications(age), Is.EqualTo("All films are available."));
        }

        [TestCase(-1)]
        [TestCase(-100)]
        public void GivenNegativeAge_AvailableClassifications_Throws(int age)
        {
            Assert.That(() => Program.AvailableClassifications(age), Throws.TypeOf<ArgumentOutOfRangeException>());
        }
    }
}