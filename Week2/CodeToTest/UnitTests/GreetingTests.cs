using CodeToTest;

namespace UnitTests
{
    public class Tests
    {

        [Test]
        public void GivenATimeOf21_Greeting_ReturnsGoodEvening()
        {
            var time = 21;
            var expectedGreeting = "Good evening!";
            var result = Program.Greeting(time);
            Assert.That(result, Is.EqualTo(expectedGreeting));

        }
    }
}