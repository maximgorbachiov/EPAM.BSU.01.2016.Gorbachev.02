using System;

namespace NewtonMethodLib
{
    public static class NewtonMethod
    {
        public static double FindRoot(double number, double degree, double epsilon)
        {
            double x1, x0 = 1.0;

            if ((degree == 0.0) || (degree == 1.0))
            {
                throw new ArgumentNullException();
            }

            if ((number < 0) && (degree % 2 == 0))
            {
                throw new ArgumentException();
            }

            x1 = (1 / degree) * ((degree - 1) * x0 + (number / Math.Pow(x0, degree - 1)));
            while (Math.Abs(x1 - x0) > epsilon)
            {
                x0 = x1;
                x1 = (1 / degree) * ((degree - 1) * x0 + (number / Math.Pow(x0, degree - 1)));
            }
           
            return x1;
        }
    }
}
