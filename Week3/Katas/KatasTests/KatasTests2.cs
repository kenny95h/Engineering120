using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Katas;

namespace KatasTests
{
    public class KatasTests2
    {
        [Test]
        public void GivenAListOfNumbers_SecondHighest_ReturnSecondHighestNumber()
        {
            List<int> myList = new List<int> { 10, 12, 33, 4, 46, 2 };
            Assert.That(KatasExercises2.SecondHighest(myList), Is.EqualTo(33));
        }

        [Test]
        public void GivenAListOfNegativeNumbers_SecondHighest_ReturnSecondHighestNumber()
        {
            List<int> myList = new List<int> { -83, -1, -134, -99, -120 };
            Assert.That(KatasExercises2.SecondHighest(myList), Is.EqualTo(-83));
        }

        [Test]
        public void GivenAnEmptyList_SecondHighest_ReturnZero()
        {
            List<int> myList = new List<int> { };
            Assert.That(KatasExercises2.SecondHighest(myList), Is.EqualTo(0));
        }

        [Test]
        public void GivenAListWithOneNumber_SecondHighest_ReturnTheNumberInList()
        {
            List<int> myList = new List<int> { 86 };
            Assert.That(KatasExercises2.SecondHighest(myList), Is.EqualTo(86));
        }

        [TestCase("Nishant Mandal", new char[] { 'a', 'n' })]
        [TestCase("Babccbaplpdetde", new char[] { 'a', 'b', 'c', 'p', 'd', 'e' })]
        [TestCase("1en33be1", new char[] { '1', 'e', '3' })]
        public void GivenAWord_DuplicateCharacters_ReturnArrayOfAnyDuplicateCharacters(string word, char[] expected)
        {
            Assert.That(KatasExercises2.DuplicateCharacters(word), Is.EqualTo(expected));
        }

        [Test]
        public void GivenAnEmptyString_DuplicateCharacters_ReturnEmptyArray()
        {
            Assert.That(KatasExercises2.DuplicateCharacters(""), Is.Empty);
        }

        [TestCase("abcdefghijk")]
        [TestCase("0123456789")]
        [TestCase("a")]
        public void GivenStringWithNoDuplicates_DuplicateCharacters_ReturnEmptyArray(string word)
        {
            Assert.That(KatasExercises2.DuplicateCharacters(word), Is.Empty);
        }
    }
}
