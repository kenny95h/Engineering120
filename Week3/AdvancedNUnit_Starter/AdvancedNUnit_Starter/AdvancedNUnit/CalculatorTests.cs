using NUnit.Framework;
using System.Collections.Generic;

namespace AdvancedNUnit
{
    public class CalculatorTests
    {
        [SetUp]
        public void Setup() { }


        [Test]
        public void Add_Always_ReturnsExpectedResult()
        {
            // Arrange
            var expectedResult = 6;
            var subject = new Calculator { Num1 = 2, Num2 = 4 };
            // Act
            var result = subject.Add();
            // Assert
            // Constraint model
            Assert.That(result, Is.EqualTo(expectedResult), "optional failure message");

            // Classical model
            Assert.AreEqual(expectedResult, result, "optional failure message");
        }

        [Test]

        public void SomeConstraints()
        {
            var _sut = new Calculator { Num1 = 6 }; //subject under test
            Assert.That(_sut.DivisibleBy3());

            _sut.Num1 = 7;
            Assert.That(_sut.DivisibleBy3(), Is.False);
        }

        [Test]
        public void StringConstraints()
        {
            var subject = new Calculator { Num1 = 2, Num2 = 4 };
            var strResult = subject.ToString();

            Assert.That(strResult, Is.EqualTo("AdvancedNUnit.Calculator"));

            Assert.That(strResult, Does.Contain("Calculator"));

            Assert.That(strResult, Does.Not.Contain("Potato"));

            Assert.That(strResult, Is.Not.EqualTo("AdvancedNUnit.Calculator").IgnoreCase);

            Assert.That(strResult, Is.Not.Empty);

        }

        [Test]
        public void TestArrayOfStrings()
        {
            var fruit = new List<string> { "apple", "pear", "banana", "peach" };

            Assert.That(fruit, Does.Contain("pear"));

            Assert.That(fruit, Does.Not.Contain("kiwi"));

            Assert.That(fruit, Has.Count.EqualTo(4));

            Assert.That(fruit, Has.Exactly(2).StartsWith("pea"));
        }

        [Test]
        public void TestRange()
        {
            Assert.That(8, Is.InRange(1, 10));

            var nums = new List<int> { 4, 2, 7, 9 };
            Assert.That(nums, Is.All.InRange(1, 10));
            Assert.That(nums, Has.Exactly(2).InRange(1, 4));
        }
    }
    
}