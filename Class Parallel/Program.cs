using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Class_Parallel
{
    class Program
    {
        static void Main(string[] args)
        {
            ParallelForEach();
        }

        static void FirstParallel()
        {
            Parallel.Invoke(Display,
                () => Console.WriteLine($"Lul is working: {Task.CurrentId}"),
                Display);

            Console.WriteLine("Countinue"); //will realized when all Tasks in Parallel.Invoke will finished

        }

        static void ParallelFor()
        {
            Parallel.For(1, 10, Factorial);
            
        }

        static void ParallelForEach()
        {
            ParallelLoopResult result = Parallel.ForEach<int>(new List<int> { 1,2,6 }, Factorial);
            Console.WriteLine(result);
        }
        static void Display()
        {
            Console.WriteLine($"Task is working: {Task.CurrentId}");
            Thread.Sleep(3000);
            Console.WriteLine($"The End: {Task.CurrentId}");
        }

        static void Factorial(int x)
        {
            int result = 1;

            for (int i = 1; i <= x; i++)
            {
                result *= i;
            }
            Console.WriteLine($"Выполняется задача {Task.CurrentId}");
            Console.WriteLine($"Факториал числа {x} равен {result}");
            Thread.Sleep(3000);
        }
    }
}
