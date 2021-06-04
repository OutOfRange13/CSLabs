using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;

namespace Lab1
{
    class Lab1
    {
        static void AddElString(ref string[] output, string value)
        {
            Array.Resize(ref output, output.Length + 1);
            output[output.Length - 1] = value;
        }
        static int Prior(char symbol)
        {
            switch (symbol)
            {
                case '*':
                case '/':
                    return 2;
                case '+':
                case '-':
                    return 1;
            }
            return 0;
        }
        static int Prior(string symbol)
        {
            switch (symbol[0])
            {
                case '*':
                case '/':
                    return 2;
                case '+':
                case '-':
                    return 1;
            }
            return 0;
        }
        static int OutputLength(ref string[] output)
        {
            int length = 0;
            for (int i = 0; i < output.Length; i++)
            {
                length += output[i].ToString().Length;
            }
            return length;
        }
        static string EnterExp()
        {
            string str = Console.ReadLine();
            for (int i = 0; i < str.Length; i++)
            {
                switch (str[i])
                {
                    case '0':
                    case '1':
                    case '2':
                    case '3':
                    case '4':
                    case '5':
                    case '6':
                    case '7':
                    case '8':
                    case '9':
                        break;
                    case '+':
                    case '-':
                    case '/':
                    case '*':
                        if ((i == 0) || (i == (str.Length - 1)) || (str[i + 1] == '+') || (str[i + 1] == '-') || (str[i + 1] == '*') || (str[i + 1] == '/'))
                        {
                            Console.WriteLine("Введите ПРАВИЛЬНОЕ арифмеическое выражение");
                            EnterExp();
                        }
                        break;
                    default:
                        Console.WriteLine("Введите ПРАВИЛЬНОЕ арифмеическое выражение");
                        EnterExp();
                        break;
                }
            }
            return str;
        }
        static void GenPolStr(ref string[] output, string str, ref Stack<string> operations)
        {
            int prior, priorOp;
            string number = "";
            for (int i = 0; i < str.Length; i++)
            {
                prior = Prior(str[i]);
                if (prior == 0)
                {
                    number += str[i].ToString();
                    if ((i + 1 == str.Length) && (str.Length != OutputLength(ref output)) && (operations.Count() != 0))
                    {
                        AddElString(ref output, number);
                        while (operations.Count() != 0)
                        {
                            AddElString(ref output, operations.Pop());
                        }

                    }
                }
                else
                {
                    AddElString(ref output, number);
                    number = "";
                    if (operations.Count() != 0)
                    {
                        priorOp = Prior(operations.Peek());
                        if (prior > priorOp)
                        {
                            operations.Push(str[i].ToString());
                        }
                        else
                        {
                            while (operations.Count() != 0)
                            {
                                AddElString(ref output, operations.Pop());
                            }
                            operations.Push(str[i].ToString());
                        }
                    }
                    else
                    {
                        operations.Push(str[i].ToString());
                    }
                }
            }
        }
        static bool CountPolStr(ref string[] output, Stack<double> count)
        {
            bool error = false;
            int prior;
            for (int i = 0; i < output.Length; i++)
            {
                prior = Prior(output[i]);
                if (prior == 0)
                {
                    count.Push(double.Parse(output[i].ToString()));
                }
                else
                {
                    if (output[i] == "+")
                    {
                        count.Push(count.Pop() + count.Pop());
                    }
                    else if (output[i] == "-")
                    {
                        double countDouble = count.Pop();
                        count.Push(count.Pop() - countDouble);
                    }
                    else if (output[i] == "*")
                    {
                        count.Push(count.Pop() * count.Pop());
                    }
                    else if (output[i] == "/")
                    {
                        double countDouble = count.Pop();
                        if (countDouble == 0)
                        {
                            Console.WriteLine("Деление на ноль");
                            error = true;
                            break;
                        }
                        count.Push(count.Pop() / countDouble);
                    }
                }
            }
            return error;
        }
        static int DoParse(string str)
        {

            return 0;
        }
        static void Main(string[] args)
        {
            Stack<string> operations = new Stack<string>();
            Stack<double> count = new Stack<double>();
            string[] output = new string[0];
            Console.WriteLine("Введите арифметическое выражение");
            string str = EnterExp();
            GenPolStr(ref output, str, ref operations);
            operations.Clear();
            string outputStr = "";
            for (int i = 0; i < output.Length; i++)
            {
                outputStr += output[i] + ", ";
            }
            Console.WriteLine("Вид обратной польской записи: " + outputStr);
            if (CountPolStr(ref output, count) == false)
            {
                double result = count.Pop();
                Console.WriteLine("Ответ: " + result);
            }

        }
    }
}