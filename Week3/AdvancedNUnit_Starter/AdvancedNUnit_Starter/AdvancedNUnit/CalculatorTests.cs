using NUnit.Framework;
using System.Collections.Generic;
using System;

namespace AdvancedNUnit
{
    [TestFixture]
    public class CalculatorTests
    {
        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            //test one object in many methods
        }

        [SetUp]
        public void Setup() 
        { 

        }


        [TestCaseSource("AddCases")]
        [Category("Happy Path")]
        public void Add_Always_ReturnsExpectedResult(int x, int y, int expResult)
        {
            // Arrange
            //var expectedResult = 6;
            var subject = new Calculator { Num1 = x, Num2 = y };
            // Act
            var result = subject.Add();
            // Assert
            // Constraint model
            Assert.That(result, Is.EqualTo(expResult), "optional failure message");

            // Classical model
            //Assert.AreEqual(expectedResult, result, "optional failure message");
        }

        private static object[] AddCases =
        {
            new int[] {2, 4, 6} , new int[] {-2, 4, 2 }
        };

        //[Test]

        //public void SomeConstraints()
        //{
        //    var _sut = new Calculator { Num1 = 6 }; //subject under test
        //    Assert.That(_sut.DivisibleBy3());

        //    _sut.Num1 = 7;
        //    Assert.That(_sut.DivisibleBy3(), Is.False);
        //}

        //[Test]
        //public void StringConstraints()
        //{
        //    var subject = new Calculator { Num1 = 2, Num2 = 4 };
        //    var strResult = subject.ToString();

        //    Assert.That(strResult, Is.EqualTo("AdvancedNUnit.Calculator"));

        //    Assert.That(strResult, Does.Contain("Calculator"));

        //    Assert.That(strResult, Does.Not.Contain("Potato"));

        //    //Assert.That(strResult, Is.Not.EqualTo("AdvancedNUnit.Calculator").IgnoreCase);

        //    Assert.That(strResult, Is.Not.Empty);

        //}

        //[Test]
        //public void TestArrayOfStrings()
        //{
        //    var fruit = new List<string> { "apple", "pear", "banana", "peach" };

        //    Assert.That(fruit, Does.Contain("pear"));

        //    Assert.That(fruit, Does.Not.Contain("kiwi"));

        //    Assert.That(fruit, Has.Count.EqualTo(4));

        //    Assert.That(fruit, Has.Exactly(2).StartsWith("pea"));
        //}

        //[Test]
        //public void TestRange()
        //{
        //    Assert.That(8, Is.InRange(1, 10));

        //    var nums = new List<int> { 4, 2, 7, 9 };
        //    Assert.That(nums, Is.All.InRange(1, 10));
        //    Assert.That(nums, Has.Exactly(2).InRange(1, 4));
        //}

        [Test]
        [Category("Error Path")]
        public void Divide_Always_ThrowsException_GivenZero()
        {
            var _sut = new Calculator { Num1 = 6, Num2 = 0 };
            Assert.That(() => _sut.Divide(), Throws.TypeOf<ArgumentException>().With.Message.Contain("Can't divide by zero"));
        }

        //[TearDown]
        //public void TearDown()
        //{

        //}

        //[OneTimeTearDown]
        //public void OneTimeTearDown9()
        //{

        //}

    }

}