﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OperatorsApp;

namespace OperatorsControlFlowTests
{

    internal class StoneTests
    {
        [TestCase(156, 11)]
        public void GivenANumberOfPounds_Methods_ReturnExpectedStones(int pounds, int stoneResult)
        {
            Assert.That(Methods.GetStones(pounds), Is.EqualTo(stoneResult));
        }

        [TestCase(156, 2)]
        public void GivenANumberOfPounds_Methods_ReturnExpectedPounds(int pounds, int poundsResult)
        {
            Assert.That(Methods.GetPounds(pounds), Is.EqualTo(poundsResult));
        }

        [TestCase(13, 0)]
        [TestCase(14, 1)]
        public void GivenBoundaryPounds_Methods_ReturnExpectedStonesBoundaries(int pounds, int stoneResult)
        {
            Assert.That(Methods.GetStones(pounds), Is.EqualTo(stoneResult));
        }

        [TestCase(14, 0)]
        [TestCase(15, 1)]
        [TestCase(13, 13)]
        public void GivenBoundaryPounds_Methods_ReturnExpectedPoundsBoundaries(int pounds, int poundsResult)
        {
            Assert.That(Methods.GetPounds(pounds), Is.EqualTo(poundsResult));
        }
    }
}
