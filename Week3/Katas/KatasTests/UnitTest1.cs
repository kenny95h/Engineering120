using Katas;

namespace KatasTests
{
    public class Tests
    {
        

        [TestCase("b")]
        [TestCase("hannah")]
        [TestCase("kayak")]
        [TestCase("madam")]
        public void GivenAPallindromeString_IsPallindrome_ReturnsTrue(string pallindrome)
        {
            Assert.That(KatasExercises.IsPallindrome(pallindrome));
        }

        [TestCase("pallindrome")]
        [TestCase("word")]
        [TestCase("st")]
        public void GivenANonePallindromeString_IsPallindrome_ReturnsFalse(string word)
        {
            Assert.That(KatasExercises.IsPallindrome(word), Is.False);
        }

        [TestCase("RAdaR")]
        [TestCase("CIviC civiC")]
        [TestCase("Ar0Ra")]
        [TestCase("13e3e31")]
        public void GivenAPallindromeWithAMixOfCaseSpacesAndNumbers_IsPallindrome_ReturnsTrue(string pallindrome)
        {
            Assert.That(KatasExercises.IsPallindrome(pallindrome));
        }

        [Test]
        public void GivenAnEmptyString_IsPallindrome_ReturnsTrue()
        {
            Assert.That(KatasExercises.IsPallindrome(""));
        }

    }
}