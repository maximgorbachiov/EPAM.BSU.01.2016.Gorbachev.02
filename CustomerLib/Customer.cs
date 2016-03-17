using System;
using System.Globalization;

namespace CustomerLib
{
    public class Customer : IFormatProvider, ICustomFormatter
    {
        public string Name { get; set; }

        public string TelephoneNumber { get; set; }

        public string Revenue { get; set; }

        public object GetFormat(Type formatType)
        {
            return (formatType == typeof (ICustomFormatter)) ? this : null;
        }

        public string Format(string format, object arg, IFormatProvider formatProvider)
        {
            
        }
    }
}
