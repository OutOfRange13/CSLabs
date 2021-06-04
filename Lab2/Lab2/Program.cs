using System;
using System.Text;
using System.Linq;

namespace Lab2
{
    class Lab2
    {
        static void ChangeOrder()
        {
            Console.WriteLine("Enter the string");
            string str = Console.ReadLine();
            StringBuilder sb = new StringBuilder();
            foreach (string word in str.Split(' '))
            {                                                                       //Task 1
                sb.Insert(0, word);
                sb.Insert(0, " ");
            }
            sb.Remove(0, 1);
            Console.WriteLine($"Reversed string: {sb}");
            Console.WriteLine();
        }



        static void CreateRandom()
        {
            Console.WriteLine("Random string:");
            Random Rand = new Random();
            Random Rnd = new Random();
            int value = Rand.Next(1, 5);
            char[] Str = new char[value];
            char[] Str1 = "qwertyuiopasdfghjklzxcvbnm".ToCharArray();  
            for (int i = 0; i < value; i++)                                         //Task 2
            {
                Str[i] = Str1[Rnd.Next(0, 25)];
            }
            Console.WriteLine(Str);
            Console.WriteLine();
        }

        

        static void Calculate(string str)
        {
            int[] amount = new int[10];
            for (int i = 0; i < 10; i++)
            {
                amount[i] = 0;
            }
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] >= '0' && str[i] <= '9')                                  //Task 3
                {
                    amount[str[i] - 48] += 1;
                }
            }
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"Number {i}:" + amount[i]);
            }
        }
        static void CountDate()
        {
            string FirstDate = DateTime.Now();
            Console.WriteLine(FirstDate);
            Calculate(FirstDate);
            string SecondDate = DateTime.Now();
            Console.WriteLine(SecondDate);
            Calculate(SecondDate);
            Console.ReadKey();
        }



        static void Main(string[] args)
        {
            ChangeOrder();
            CreateRandom();
            CountDate();
        }
    }
}
