using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ControlFlowApp;

namespace OperatorsControlFlowTests
{
    internal class LoopTests
    {

        [Test]
        public void GivenList_HighestForEachLoop_ReturnHighestInt()
        {
            Assert.That(LoopTypes.HighestForEachLoop(new List<int> { -8, -2, -30 }), Is.EqualTo(-2));
        }

        [TestCaseSource(nameof(LoopList))]
        public void GivenList_HighestForEachLoop_ReturnHighestInt(List<int> nums)
        {
            Assert.That(LoopTypes.HighestForEachLoop(nums), Is.EqualTo(24));
        }

        public static IEnumerable<List<int>> LoopList()
        {
            yield return new List<int> { 12, 24 };
            yield return new List<int> { 23, 6, 24 };
            yield return new List<int> { 6, 24, 0, -5 };
        }

        [TestCase(new[] { 10, 6, 3, -17, 22 }, 22)]
        [TestCase(new[] { 0, -1, -5}, 0)]
        [TestCase(new[] { 50, 21, 900, 6, 1}, 900)]
        [TestCase(new[] { -1, -12, -100}, -1)]
        public void GivenList_HighestForEachLoop_ReturnHighestInt(int[] nums, int expectedResult)
        {
            Assert.That(LoopTypes.HighestForEachLoop(nums.ToList()), Is.EqualTo(expectedResult));
        }

        [TestCase(new[] { 10, 6, 22, -17, 3 }, 22)]
        [TestCase(new[] { 0, -1, -5 }, 0)]
        [TestCase(new[] { 50, 21, 900, 6, 1 }, 900)]
        [TestCase(new[] { -1, -12, -100 }, -1)]
        public void GivenList_HighestForLoop_ReturnHighestInt(int[] nums, int expectedResult)
        {
            Assert.That(LoopTypes.HighestForLoop(nums.ToList()), Is.EqualTo(expectedResult));
        }

        [TestCase(new[] { 10, 6, 22, -17, 3 }, 22)]
        [TestCase(new[] { 0, -1, -5 }, 0)]
        [TestCase(new[] { 50, 21, 900, 6, 1 }, 900)]
        [TestCase(new[] { -1, -12, -100 }, -1)]
        public void GivenList_HighestWhileLoop_ReturnHighestInt(int[] nums, int expectedResult)
        {
            Assert.That(LoopTypes.HighestWhileLoop(nums.ToList()), Is.EqualTo(expectedResult));
        }

        [TestCase(new[] { 10, 6, 22, -17, 3 }, 22)]
        [TestCase(new[] { 0, -1, -5 }, 0)]
        [TestCase(new[] { 50, 21, 900, 6, 1 }, 900)]
        [TestCase(new[] { -1, -12, -100 }, -1)]
        public void GivenList_HighestDoWhileLoop_ReturnHighestInt(int[] nums, int expectedResult)
        {
            Assert.That(LoopTypes.HighestDoWhileLoop(nums.ToList()), Is.EqualTo(expectedResult));
        }
    }
}
