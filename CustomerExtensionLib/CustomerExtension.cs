using CustomerLib;

namespace CustomerExtensionLib
{
    public static class CustomerExtension
    {
        public static string Formated(this Customer customer, string formateString)
        {
            string result = "";

            for (int i = 0; i < formateString.Length; i++)
            {
                if (formateString[i] == '{')
                {
                    switch (formateString[i + 1])
                    {
                        case '0':
                            result += "My name is " + customer.Name; break;
                        case '1':
                            result += "My revenue is " + customer.Revenue; break;
                        case '2':
                            result += "My telephone number is " + customer.TelephoneNumber; break;
                    }
                    i = i + 2;
                }
                else
                {
                    result += formateString[i];
                }
            }

            return result;
        }
    }
}
