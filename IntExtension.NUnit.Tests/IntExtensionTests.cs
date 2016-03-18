using System;
using System.Globalization;
using NUnit.Framework;
using System.Threading;

namespace IntExtension.NUnit.Tests
{
    [TestFixture]
    public class IntExtensionTests
    {
        [TestCase(0, Result = "00000000")]
        [TestCase(1, Result = "00000001")]
        [TestCase(20, Result = "00000014")]
        [TestCase(234, Result = "000000EA")]
        [TestCase(1025, Result = "00000401")]
        [TestCase(-234, Result = "FFFFFF16")]
        [TestCase(-1025, Result = "FFFFFBFF")]

        public string TestConvertToHex(int number)
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            IFormatProvider formatProvider = new IntExtensionLib.IntExtension();
            return string.Format(formatProvider, "{0:h}", number);
        }
    }
}
