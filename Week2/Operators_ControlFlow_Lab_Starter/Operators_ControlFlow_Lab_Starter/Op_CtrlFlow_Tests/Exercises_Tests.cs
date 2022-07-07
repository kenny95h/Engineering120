using NUnit.Framework;
using Op_CtrlFlow;
using System;
using System.Collections.Generic;

namespace Op_CtrlFlow_Tests
{
    public class Exercises_Tests
    {
        // write unit test(s) for MyMethod here
        [TestCase(0, 0)]
        [TestCase(-1, -1)]
        [TestCase(100, 100)]
        public void WhenNumsAreTheSame_MyMethod_ReturnsFalse(int num1, int num2)
        {
            Assert.That(Exercises.MyMethod(num1, num2), Is.EqualTo(false));
        }

        [TestCase(10, 5)]
        [TestCase(900, 3)]
        [TestCase(-20, -2)]
        public void WhenNumsAreDifferentAndDivisible_MyMethod_ReturnsTrue(int num1, int num2)
        {
            Assert.That(Exercises.MyMethod(num1, num2), Is.EqualTo(true));
        }

        [TestCase(10, 3)]
        [TestCase(-16, -6)]
        [TestCase(3, 100)]
        public void WhenNumsAreDifferentAndNotDivisible_MyMethod_ReturnsFalse(int num1, int num2)
        {
            Assert.That(Exercises.MyMethod(num1, num2), Is.EqualTo(false));
        }

        [Test]
        public void Average_ReturnsCorrectAverage()
        {
            var myList = new List<int>() { 3, 8, 1, 7, 3 };
            Assert.That(Exercises.Average(myList), Is.EqualTo(4.4));
        }

        //[Test]
        //public void WhenListIsEmpty_Average_ReturnsZero()
        //{
        //    var myList = new List<int>() { };
        //    Assert.That(Exercises.Average(myList), Is.EqualTo(0));
        //}

        [Test]
        public void GivenEmptyList_Average_Throws()
        {
            var myList = new List<int>() { };
            Assert.That(() => Exercises.Average(myList), Throws.TypeOf<ArgumentOutOfRangeException>());
        }

        [TestCase(100, "OAP")]
        [TestCase(60, "OAP")]
        [TestCase(59, "Standard")]
        [TestCase(18, "Standard")]
        [TestCase(17, "Student")]
        [TestCase(13, "Student")]
        [TestCase(12, "Child")]
        [TestCase(5, "Child")]
        [TestCase(4, "Free")]
        [TestCase(0, "Free")]
        public void TicketTypeTest(int age, string expected)
        {
            var result = Exercises.TicketType(age);
            Assert.That(result, Is.EqualTo(expected));
        }

        [TestCase(-1)]
        [TestCase(-500)]
        [TestCase(201)]
        [TestCase(90837)]
        public void GivenAgeUnderZeroOrOver200_TicketType_Throws(int age)
        {
            Assert.That(() => Exercises.TicketType(age), Throws.TypeOf<ArgumentOutOfRangeException>());
        }

        [TestCase(100, "Pass with Distinction")]
        [TestCase(82, "Pass with Distinction")]
        [TestCase(75, "Pass with Distinction")]
        [TestCase(74, "Pass with Merit")]
        [TestCase(68, "Pass with Merit")]
        [TestCase(60, "Pass with Merit")]
        [TestCase(59, "Pass")]
        [TestCase(44, "Pass")]
        [TestCase(40, "Pass")]
        [TestCase(39, "Fail")]
        [TestCase(12, "Fail")]
        [TestCase(0, "Fail")]
        public void GradeResultTest(int mark, string expectedResult)
        {

            Assert.That(Exercises.Grade(mark), Is.EqualTo(expectedResult));
        }

        [TestCase(-1)]
        [TestCase(-989)]
        [TestCase(101)]
        [TestCase(726)]
        public void GivenMarkUnderZeroOrOver100_Grade_Throws(int mark)
        {
            Assert.That(() => Exercises.Grade(mark), Throws.TypeOf<ArgumentOutOfRangeException>());
        }

        [TestCase(4, 20)]
        [TestCase(3, 50)]
        [TestCase(2,50)]
        [TestCase(1, 100)]
        [TestCase(0, 200)]
        public void GetScottishMaxWeddingNumbersTest(int covidLevel, int expectedResult)
        {

            Assert.That(Exercises.GetScottishMaxWeddingNumbers(covidLevel), Is.EqualTo(expectedResult));
        }

        [TestCase(-1)]
        [TestCase(-321)]
        [TestCase(5)]
        [TestCase(91)]
        public void GivenCovidLevelUnderZeroOrOver4_GetScottishMaxWeddingNumbers_Throws(int covidLevel)
        {
            Assert.That(() => Exercises.GetScottishMaxWeddingNumbers(covidLevel), Throws.TypeOf<ArgumentOutOfRangeException>());
        }
    }
}
