using System;
using System.Collections.Generic;

namespace lab7
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Fraction> lst = new List<Fraction>()
            {
                new Fraction(4, 5),
                new Fraction(8),
                new Fraction(1.456),
                Fraction.GetFraction("12,34"),
                Fraction.GetFraction("4"),
                Fraction.GetFraction("-12/31"),
                Fraction.GetFraction("-1(34/63)")
            };
            lst.Add(lst[0] + lst[1]);
            lst.Add(lst[1] - lst[2]);
            lst.Add(lst[0] * lst[4]);
            lst.Add(lst[1] / lst[4]);
            lst.Add(lst[7] * 12);
            lst.Add(lst[6] / (-2));
            lst.Add(lst[3].Clone() as Fraction);
            for (int i = 0; i < lst.Count; i++)
            {
                Console.WriteLine(lst[i]);
            }
            Console.WriteLine();

            Console.WriteLine(lst[3] == lst[13]);
            Console.WriteLine(lst[1] != lst[2]);
            Console.WriteLine(lst[4] >= lst[5]);
            Console.WriteLine(lst[3] < lst[1]);
            Console.WriteLine();

            Fraction frac = new Fraction(-153, 14);
            Console.WriteLine("{0:S}", frac);
            Console.WriteLine("{0:M}", frac);
            Console.WriteLine("{0:D}", frac);
            Console.WriteLine("{0:I}", frac);
            Console.WriteLine();

            Console.WriteLine((short)frac);
            Console.WriteLine((int)frac);
            Console.WriteLine((long)frac);
            Console.WriteLine(Convert.ToString(frac));
            Console.WriteLine(Convert.ToBoolean(frac));
            Console.ReadKey();
        }
    }
}
