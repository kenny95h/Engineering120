using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FizzBuzzApp;

namespace StringCalcTests
{
    public class StringCalcTests
    {
        [Test]
        [Category("Question 1")]
        public void GivenEmptyString_Add_ReturnZero()
        {
            Assert.That(Program.Add(""), Is.EqualTo(0));
        }

        [TestCase("1", 1)]
        [TestCase("9", 9)]
        [TestCase("0", 0)]
        [Category("Question 1")]
        public void GivenStringWithOneNumber_Add_ReturnOneNumber(string oneNum, int expResult)
        {
            Assert.That(Program.Add(oneNum), Is.EqualTo(expResult));
        }

        [TestCase("1,2", 3)]
        [TestCase("15,20", 35)]
        [TestCase("5,9", 14)]
        [Category("Question 1")]
        public void GivenStringTwoNumbersSeparatedByCommas_Add_ReturnSumOfTwoNumbers(string numbers, int expResult)
        {
            Assert.That(Program.Add(numbers), Is.EqualTo(expResult));
        }

        [TestCase("1,2,3,4", 10)]
        [TestCase("15,20,3,1,2,10", 51)]
        [TestCase("12,101,2", 115)]
        [Category("Question 2")]
        public void GivenStringMultipleNumbersSeparatedByCommas_Add_ReturnSumOfAllNumbers(string numbers, int expResult)
        {
            Assert.That(Program.Add(numbers), Is.EqualTo(expResult));
        }

        [TestCase("1\n2,3\n4", 10)]
        [TestCase("20\n,2,15,1", 38)]
        [TestCase("12\n101\n2", 115)]
        [Category("Question 3")]
        public void GivenStringMultipleNumbersSeparatedByCommasAndNewLines_Add_ReturnSumOfAllNumbers(string numbers, int expResult)
        {
            Assert.That(Program.Add(numbers), Is.EqualTo(expResult));
        }

        [TestCase("//;\n1;2;3;4", 10)]
        [TestCase("//?\n20?50,15?10", 95)]
        [TestCase("//#\n6#9\n2", 17)]
        [Category("Question 4")]
        public void GivenSpecifiedDelimitirInStringWithMultipleNumbersSeparatedBySpecifiedDelimiter_Add_ReturnSumOfAllNumbers(string numbers, int expResult)
        {
            Assert.That(Program.Add(numbers), Is.EqualTo(expResult));
        }

        [TestCase("-1,-5,-30")]
        [TestCase("54,--10-,-30")]
        [TestCase("-1")]
        [Category("Question 5")]
        public void GivenStringWithNegativeNumbers_Add_Throws(string numbers)
        {
            Assert.That(() => Program.Add(numbers), Throws.TypeOf<ArgumentException>().With.Message.Contain("negatives not allowed"));
        }

        [TestCase("5,1001,1", 6)]
        [TestCase("1000,1", 1001)]
        [TestCase("1001,2000, 3040", 0)]
        [Category("Question 6")]
        public void GivenAStringWithSomeNumbersBiggerThan1000_Add_ReturnsSumOfNumbersUnder1000(string numbers, int expResult)
        {
            Assert.That(Program.Add(numbers), Is.EqualTo(expResult));
        }
    }
}
