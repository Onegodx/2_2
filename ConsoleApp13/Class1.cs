using System;


namespace Fraction
{
    class Fraction
    {
        private long numerator; // числитель
        private ulong denominator; // знаменатель

        public Fraction(long numerator, ulong denominator)
        {
            this.numerator = numerator;
            this.denominator = denominator;
        }

        public long Numerator
        {
            get { return numerator; }
        }

        public ulong Denominator
        {
            get { return denominator; }
        }

        public static Fraction operator +(Fraction a, Fraction b)
        {
            ulong lcm = LCM(a.denominator, b.denominator);

            // приводим знаменатели к общему знаменателю
            long numerator = a.numerator * (long)(lcm / a.denominator) +
                b.numerator * (long)(lcm / b.denominator);

            // сокращаем дробь
            Reduce(ref numerator, ref lcm);

            return new Fraction(numerator, lcm);
        }

        public static Fraction operator -(Fraction a, Fraction b)
        {
            ulong lcm = LCM(a.denominator, b.denominator);

            // приводим знаменатели к общему знаменателю
            long numerator = a.numerator * (long)(lcm / a.denominator) -
                b.numerator * (long)(lcm / b.denominator);

            // сокращаем дробь
            Reduce(ref numerator, ref lcm);

            return new Fraction(numerator, lcm);
        }

        public static Fraction operator *(Fraction a, Fraction b)
        {
            // перемножаем числитель и знаменатель
            long numerator = a.numerator * b.numerator;
            ulong denominator = a.denominator * b.denominator;

            // сокращаем дробь
            Reduce(ref numerator, ref denominator);

            return new Fraction(numerator, denominator);
        }

        public static bool operator ==(Fraction a, Fraction b)
        {
            ulong lcm = LCM(a.denominator, b.denominator);

            // приводим знаменатели к общему знаменателю
            long numeratorA = a.numerator * (long)(lcm / a.denominator);
            long numeratorB = b.numerator * (long)(lcm / b.denominator);

            // сравниваем числители
            return numeratorA == numeratorB;
        }

        public static bool operator !=(Fraction a, Fraction b)
        {
            return !(a == b);
        }

        public static bool operator <(Fraction a, Fraction b)
        {
            ulong lcm = LCM(a.denominator, b.denominator);

            // приводим знаменатели к общему знаменателю
            long numeratorA = a.numerator * (long)(lcm / a.denominator);
            long numeratorB = b.numerator * (long)(lcm / b.denominator);

            // сравниваем числители
            return numeratorA < numeratorB;
        }

        public static bool operator >(Fraction a, Fraction b)
        {
            return b < a;
        }

        public static bool operator <=(Fraction a, Fraction b)
        {
            return !(a > b);
        }

        public static bool operator >=(Fraction a, Fraction b)
        {
            return !(a < b);
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            Fraction fraction = (Fraction)obj;
            return this == fraction;
        }

        public override int GetHashCode()
        {
            return numerator.GetHashCode() ^ denominator.GetHashCode();
        }

        public override string ToString()
        {
            return string.Format("{0}/{1}", numerator, denominator);
        }

        private static ulong GCD(ulong a, ulong b)
        {
            while (b != 0)
            {
                ulong temp = b;
                b = a % b;
                a = temp;
            }

            return a;
        }

        private static ulong LCM(ulong a, ulong b)
        {
            return a / GCD(a, b) * b;
        }

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

            // сокращаем дробь на НОД
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
    }

}




