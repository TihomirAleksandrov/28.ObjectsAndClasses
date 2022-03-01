using System;
using System.Numerics;

namespace BigFactorial
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            BigInteger factorialNum = new BigInteger(number);

            for (int i = number - 1; i > 0; i--)
            {
                factorialNum *= i;
            }

            Console.WriteLine(factorialNum);
        }
    }
}
