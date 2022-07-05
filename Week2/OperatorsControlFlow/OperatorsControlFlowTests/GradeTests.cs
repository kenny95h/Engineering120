using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ControlFlowApp;

namespace OperatorsControlFlowTests
{
    internal class GradeTests
    {

        [TestCase(12)]
        [TestCase(19)]
        [TestCase(0)]
        public void GivenGradeBetween0and19Inclusive_Grade_ReturnFailNoRetake(int grade)
        {
            Assert.That(Program.Grade(grade), Is.EqualTo("Failed no retake"));
        }

        [TestCase(20)]
        [TestCase(64)]
        [TestCase(42)]
        public void GivenGradeBetween20and64Inclusive_Grade_ReturnFailWithRetake(int grade)
        {
            Assert.That(Program.Grade(grade), Is.EqualTo("Failed with retake"));
        }

        [TestCase(84)]
        [TestCase(65)]
        [TestCase(73)]
        public void GivenGradeBetween65and84Inclusive_Grade_ReturnPass(int grade)
        {
            Assert.That(Program.Grade(grade), Is.EqualTo("Pass"));
        }

        [TestCase(85)]
        [TestCase(100)]
        [TestCase(90)]
        public void GivenGradeBetween85and100Inclusive_Grade_ReturnDistinction(int grade)
        {
            Assert.That(Program.Grade(grade), Is.EqualTo("Distinction"));
        }

        [TestCase(-1)]
        [TestCase(101)]
        public void GivenNegativeGradeOrOver100_Grade_Throws(int grade)
        {
            Assert.That(() => Program.Grade(grade), Throws.TypeOf<ArgumentOutOfRangeException>().With.Message);
        }
    }
}
