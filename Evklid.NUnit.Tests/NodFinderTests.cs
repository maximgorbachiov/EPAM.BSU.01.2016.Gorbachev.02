using System;
using NUnit.Framework;
using EvklidLib;

namespace Evklid.NUnit.Tests
{
    [TestFixture]
    public class NodFinderTests
    {
        [TestCase(0, 7, Result = 7)]
        [TestCase(1, 7, Result = 1)]
        [TestCase(7, 0, Result = 7)]
        [TestCase(7, 7, Result = 7)]
        [TestCase(125, 25, Result = 25)]
        public int TestTwoValuesByEvklidMethod(int a, int b)
        {
            return NodFinder.Evklid.GetNodByEvklidMethod(a, b);
        }

        [TestCase(ExpectedException = typeof(ArgumentNullException))]
        public int TestNullValuesByEvklidMethod()
        {
            return NodFinder.Evklid.GetNodByEvklidMethod(0, 0);
        }

        [TestCase(0, 7, Result = 7)]
        [TestCase(1, 7, Result = 1)]
        [TestCase(7, 0, Result = 7)]
        [TestCase(7, 7, Result = 7)]
        [TestCase(125, 25, Result = 25)]
        public int TestTwoValueByStainsMethod(int a, int b)
        {
            return NodFinder.Evklid.GetNodByStainsMethod(a, b);
        }

        [TestCase(ExpectedException = typeof(ArgumentNullException))]
        public int TestNullValues()
        {
            return NodFinder.Evklid.GetNodByStainsMethod(0, 0);
        }

        [TestCase(-12, -10, 10, 50, 450, Result = 2)]
        [TestCase(-5, -5, 100, 55, 25, Result = 5)]
        [TestCase(80, 248, 24, 48, 80, 256, Result = 8)]
        public int TestManyValueByEvklidMethod(params int[] numbers)
        {
            return NodFinder.Evklid.GetNodByEvklidMethod(numbers);
        }

        [TestCase(-12, -10, 10, 50, 450, Result = 2)]
        [TestCase(-5, -5, 100, 55, 25, Result = 5)]
        [TestCase(80, 248, 24, 48, 80, 256, Result = 8)]
        public int TestManyValueByStainsMethod(params int[] numbers)
        {
            return NodFinder.Evklid.GetNodByStainsMethod(numbers);
        }
    }
}
