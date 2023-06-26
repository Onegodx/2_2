using System;

namespace Fraction_helper
{
    internal static class FractionHelpers
    {

        private static void Reduce(ref long numerator, ref ulong
denominator)
        {
            if (numerator == 0)
            {
                denominator = 1;
                return;
            }

            bool negative = numerator < 0;
            long n = Math.Abs(numerator);
            ulong m = denominator;

           
            ulong gcd = GCD((ulong)n, m);
            n /= (long)gcd;
            m /= gcd;

            if (negative)
            {
                numerator = -n;
            }
            else
            {
                numerator = n;
            }

            denominator = m;
        }

        private static ulong GCD(ulong n, ulong m)
        {
            throw new NotImplementedException();
        }
    }
}
