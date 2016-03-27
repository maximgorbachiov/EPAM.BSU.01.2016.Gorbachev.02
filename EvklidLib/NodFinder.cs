using System;
using System.Diagnostics;

namespace EvklidLib
{
    public class NodFinder
    {
        private readonly Stopwatch timer;
        private delegate int GetNodForTwoNumbers(int number1, int number2);

        public static NodFinder Evklid { get; } = new NodFinder();

        public TimeSpan Time => timer.Elapsed;

        private NodFinder()
        {
            timer = new Stopwatch();
        }

        public int GetNodByEvklidMethod(int number1, int number2)
        {
            timer.Start();
            int result = EvklidMethod(number1, number2);
            timer.Stop();

            return result;
        }

        public int GetNodByEvklidMethod(int number1, int number2, int number3)
        {
            int[] numbers = new int[] { number1, number2, number3 };
            return GetNodAndTime(numbers, EvklidMethod);
        }

        public int GetNodByEvklidMethod(int[] numbers)
        {
            return GetNodAndTime(numbers, EvklidMethod);
        }

        public int GetNodByStainsMethod(int number1, int number2)
        {
            timer.Start();
            int result = StainsMethod(number1, number2);
            timer.Stop();

            return result;
        }

        public int GetNodByStainsMethod(int number1, int number2, int number3)
        {
            int[] numbers = new int[] { number1, number2, number3 };
            return GetNodAndTime(numbers, StainsMethod);
        }

        public int GetNodByStainsMethod(int[] numbers)
        {
            return GetNodAndTime(numbers, StainsMethod);
        }

        private int GetNodAndTime(int[] numbers, GetNodForTwoNumbers getNod)
        {
            timer.Start();
            int result = GetNod(numbers, getNod);
            timer.Stop();

            return result;
        }

        private int GetNod(int[] numbers, GetNodForTwoNumbers getNod)
        {
            int result = 0;
            bool isFirstNod = true;

            if (numbers == null)
            {
                throw new Exception("Input data are null");
            }

            for (int i = 0; i < numbers.Length - 1; i++)
            {
                if (isFirstNod)
                {
                    result = numbers[i];
                    isFirstNod = false;
                }

                if ((result == 0) && (numbers[i + 1] == 0))
                {
                    throw new ArgumentNullException();
                }

                result = getNod(result, numbers[i + 1]);
            }

            return result;
        }

        private int EvklidMethod(int number1, int number2)
        {
            int residue;

            if (number1 == 0)
            {
                return number2;
            }

            if (number2 == 0)
            {
                return number1;
            }

            int value1 = CheckValueOnNegativeAndAbs(number1);
            int value2 = CheckValueOnNegativeAndAbs(number2);

            CompareAndSwap(ref value1, ref value2);

            while (value2 != 0)
            {
                residue = value2;
                value2 = value1 % value2;
                value1 = residue;
            }

            return value1;
        }

        private int StainsMethod(int number1, int number2)
        {
            int value1 = CheckValueOnNegativeAndAbs(number1);
            int value2 = CheckValueOnNegativeAndAbs(number2);

            return GetNodSM(value1, value2);
        }

        private int GetNodSM(int number1, int number2)
        {
            if ((number1 == 0) || (number2 == 0))
            {
                return (number1 > number2) ? number1 : number2;
            }

            if (number1 == number2)
            {
                return number1;
            }

            if ((number1 == 1) || (number2 == 1))
            {
                return 1;
            }

            if ((number1 % 2 == 0) && (number2 % 2 == 0))
            {
                return 2 * GetNodSM(number1 / 2, number2 / 2);
            }

            if ((number1 % 2 == 0) && (number2 % 2 == 1))
            {
                return GetNodSM(number1 / 2, number2);
            }

            if ((number1 % 2 == 1) && (number2 % 2 == 0))
            {
                return GetNodSM(number1, number2 / 2);
            }

            if ((number1 % 2 == 1) && (number2 % 2 == 1))
            {
                int temp = Math.Abs(number1 - number2) / 2;
                return (number1 > number2) ? GetNodSM(temp, number2) : GetNodSM(temp, number1);
            }

            return 0;
        }

        private int CheckValueOnNegativeAndAbs(int value)
        {
            if (value < 0)
            {
                value *= -1;
            }

            return value;
        }

        private void CompareAndSwap(ref int number1, ref int number2)
        {
            if (number1 < number2)
            {
                int temp = number1;
                number1 = number2;
                number2 = temp;
            }
        }
    }
}
