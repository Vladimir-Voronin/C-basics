using System;

namespace _0.Hello_World
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!!");
            string x = "Hello world!";
            Console.WriteLine(x);

            int e = variab(1, 2);
            Console.WriteLine(e);

            double a = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("a = " + a);
            double b = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("b = " + b);
            string oper = Console.ReadLine();
            double result = calc(a, b, oper);
            Console.WriteLine("Your result = " + result);

            Console.ReadLine();
        }
        static int variab(int a, int b)
        {
            int c = a + b;
            return c;
        }

        static double calc(double a, double b, string oper)
        {
            switch (oper)
            {
                case "+":
                    return a + b;
                case "-":
                    return a - b;
                case "*":
                    return a * b;
                case "/":
                    return a / b;
                default:
                    Console.WriteLine("unknown operator");
                    return 0;
                    
            }
        }
    }
}
