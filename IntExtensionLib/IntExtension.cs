using System;
using System.Globalization;

namespace IntExtensionLib
{
    public class IntExtension : IFormatProvider, ICustomFormatter
    {
        public object GetFormat(Type formatType)
        {
            return (formatType == typeof (ICustomFormatter)) ? this : null;
        } 
    
        public string Format(string format, object arg, IFormatProvider formatProvider)
        { 
            if (format == null) 
            { 
                throw new Exception("Format is null"); 
            }

            int valueToConvert = 0;

            if ((arg != null) && (arg is int) || (format == "h"))
            {
                valueToConvert = (int)arg;
            }
            else
            {
                throw new ArgumentException("Some params are invalid");
            }
     
            return ConvertToHex(valueToConvert); 
        } 

        private string ConvertToHex(int number)
        {
            int digit;
            string result = "";

            if (number == 0)
            {
                return "00000000";
            }

            int[] binaryFormatOfNumber = ConvertNumberToBinaryFormat(number);

            for (int i = 0; i < 8; i++)
            {
                digit = 0;

                for (int j = 0; j < 4; j++)
                {
                    digit = digit * 2 + binaryFormatOfNumber[i * 4 + j];
                }

                result += SwitchDigitChar(digit);
            }

            return result;
        }

        private int[] ConvertNumberToBinaryFormat(int number)
        {
            int intSize = 32;
            int[] binaryFormatOfNumber = new int[intSize];

            binaryFormatOfNumber[0] = (number > 0) ? 0 : 1;
            number = Math.Abs(number);
            ConvertToBinary(number, binaryFormatOfNumber);

            return binaryFormatOfNumber;
        }

        private void ConvertToBinary(int number, int[] binaryFormatOfNumber)
        {
            int i = 1;

            while (number > 0)
            {
                binaryFormatOfNumber[i] = number % 2;
                number /= 2;
                i++;
            }

            Reverse(binaryFormatOfNumber);

            if (binaryFormatOfNumber[0] == 1)
            {
                Invert(binaryFormatOfNumber);
            }
        }

        private static void Reverse(int[] binaryFormatOfNumber)
        {
            int temp;

            for (int i = 1; i < binaryFormatOfNumber.Length - binaryFormatOfNumber.Length / 2; i++)
            {
                temp = binaryFormatOfNumber[i];
                binaryFormatOfNumber[i] = binaryFormatOfNumber[binaryFormatOfNumber.Length - i];
                binaryFormatOfNumber[binaryFormatOfNumber.Length - i] = temp;
            }
        }

        private static void Invert(int[] binaryFormatOfNumber)
        {
            int i;
            bool isDischargeTransfer = true;

            for (i = 1; i < binaryFormatOfNumber.Length; i++)
            {
                binaryFormatOfNumber[i] = (binaryFormatOfNumber[i] == 0) ? 1 : 0;
            }

            i = binaryFormatOfNumber.Length - 1;

            while (isDischargeTransfer)
            {
                if (binaryFormatOfNumber[i] == 1)
                {
                    binaryFormatOfNumber[i] = 0;
                }
                else
                {
                    binaryFormatOfNumber[i] = 1;
                    isDischargeTransfer = false;
                }
                i--;
            }
        }

        private static string SwitchDigitChar(int number)
        {
            string digit;

            switch (number)
            {
                case 10:
                    digit = "A"; break;
                case 11:
                    digit = "B"; break;
                case 12:
                    digit = "C"; break;
                case 13:
                    digit = "D"; break;
                case 14:
                    digit = "E"; break;
                case 15:
                    digit = "F"; break;
                default:
                    digit = number.ToString(); break;
            }

            return digit;
        }
    }
}
