using Fraction_1;
using System;
namespace Fraction_program
{    
class Fraction_1
    {
        static void Main(string[] args)
        {
            Fraction a = new Fraction(1, 2);
            Fraction b = new Fraction(-3, 4);

            Console.WriteLine("a + b = {0}", a + b);
            Console.WriteLine("a - b = {0}", a - b);
            Console.WriteLine("a * b = {0}", a * b);
            Console.WriteLine("a == b: {0}", a == b);
            Console.WriteLine("a != b: {0}", a != b);
            Console.WriteLine("a < b: {0}", a < b);
            Console.WriteLine("a > b: {0}", a > b);
            Console.WriteLine("a <= b: {0}", a <= b);
            Console.WriteLine("a >= b: {0}", a >= b);

            Console.ReadKey();
        }
    }

}
