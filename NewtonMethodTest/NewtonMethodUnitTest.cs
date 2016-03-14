using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NewtonMethodLib;

namespace NewtonMethodTest
{
    [TestClass]
    public class NewtonMethodUnitTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void FindRootWithAllParamsNulls()
        {
            NewtonMethod.FindRoot(0, 0, 0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void FindRootDegreeHasValueOne()
        {
            double realResult = NewtonMethod.FindRoot(0, 1, 0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void FindRootNumberIsNegativeAndDegreeIsEven()
        {
            NewtonMethod.FindRoot(-23, 2, 0);
        }

        [TestMethod]
        public void FindRoot()
        {
            double realResult = NewtonMethod.FindRoot(100, 2, 0.00001);
            double expectedResult = 10;

            Assert.AreEqual(expectedResult, realResult);
        }
    }
}
