using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using CustomerExtensionLib;
using CustomerLib;

namespace CustomerExtension.NUnit.Tests
{
    [TestFixture]
    public class CustomerExtensionTests
    {
        [TestCase("{1}", Result = "My revenue is 1000000")]
        [TestCase("{0}", Result = "My name is Maxim")]
        [TestCase("{2}", Result = "My telephone number is 1895647")]
        [TestCase("What is your name? {0}", Result = "What is your name? My name is Maxim")]
        [TestCase("{0} and {2} and {1}", Result = "My name is Maxim and My telephone number is 1895647 and My revenue is 1000000")]
        [TestCase("", Result = "")]
        [TestCase("{0}{0}{0}", Result = "My name is MaximMy name is MaximMy name is Maxim")]
        public string TestCustomerToStringFormate(string formate)
        {
            Customer customer = new Customer();
            customer.Name = "Maxim";
            customer.Revenue = "1000000";
            customer.TelephoneNumber = "1895647";
            return customer.Formated(formate);
        }
    }
}
