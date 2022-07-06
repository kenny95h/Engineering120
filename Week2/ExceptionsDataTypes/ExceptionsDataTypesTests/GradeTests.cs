namespace ExceptionsDataTypesTests
{
    public class GradeTests
    {

        [TestCase(-1)]
        [TestCase(-100)]
        public void WhenMarkIsLessThanZero_Grade_ThrowsAnArgumentOutOfRangeException(int mark)
        {
            Assert.That(() => Program.Grade(mark), Throws.TypeOf<ArgumentOutOfRangeException>().With.Message.Contain("Mark needs to be between 0 and 100 inclusive."));
            Assert.That(() => Program.Grade(mark), Throws.InstanceOf<Exception>().With.Message.Contain("Mark needs to be between 0 and 100 inclusive."));
        }

        [TestCase(200)]
        [TestCase(101)]
        public void WhenMarkIsOver100_Grade_ThrowsAnArgumentOutOfRangeException(int mark)
        {
            Assert.That(() => Program.Grade(mark), Throws.TypeOf<ArgumentOutOfRangeException>().With.Message.Contain("Mark needs to be between 0 and 100 inclusive."));
            Assert.That(() => Program.Grade(mark), Throws.InstanceOf<Exception>().With.Message.Contain("Mark needs to be between 0 and 100 inclusive."));
        }
    }
}