using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace FizzBuzzApp
{
    public class FizzBuzzTests
    {
        [Test]
        public void GivenOne_Return_OneString()
        {
            Assert.That(Program.FizzBuzz(1), Is.EqualTo("1"));
        }

        [Test]
        public void GivenTwo_Return_OneTwoString()
        {
            Assert.That(Program.FizzBuzz(2), Is.EqualTo("1 2"));
        }

        [Test]
        public void GivenThree_Return_OneTwoFizzString()
        {
            Assert.That(Program.FizzBuzz(3), Is.EqualTo("1 2 Fizz"));
        }

        [Test]
        public void GivenFour_Return_OneTwoFizzFourString()
        {
            Assert.That(Program.FizzBuzz(4), Is.EqualTo("1 2 Fizz 4"));
        }

        [Test]
        public void GivenFive_Return_OneTwoFizzFourBuzzString()
        {
            Assert.That(Program.FizzBuzz(5), Is.EqualTo("1 2 Fizz 4 Buzz"));
        }

        [Test]
        public void GivenFifteen_Return_FizzBuzzString()
        {
            Assert.That(Program.FizzBuzz(15), Is.EqualTo("1 2 Fizz 4 Buzz Fizz 7 8 Fizz Buzz 11 Fizz 13 14 FizzBuzz"));
        }

        [Test]
        public void GivenLessThanOne_Throws()
        {
            Assert.That(() => Program.FizzBuzz(0), Throws.TypeOf<ArgumentOutOfRangeException>().With.Message.Contain("Input must be over 0"));
        }
    }
}
