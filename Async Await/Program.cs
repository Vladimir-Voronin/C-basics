using System;
using System.Threading;
using System.Threading.Tasks;

namespace Async_Await
{
    class Program
    {
        static void Main(string[] args)
        {
            //Task t = FactotialAsyncReturn();
            //Task<int> res = FactotialAsyncReturn2();
            //Task cont = res.ContinueWith((res) => Console.WriteLine($"Result, returned with task: {res.Result}"));
            //Console.WriteLine($"Task ID: {t.Id}");
            //Console.WriteLine("Введите число: ");
            //int n = Int32.Parse(Console.ReadLine());
            //Console.WriteLine($"Квадрат числа равен {n * n}");
            //FactotialAsyncNonСonsistently();
            //Console.WriteLine("Введите число: ");
            //int n = Int32.Parse(Console.ReadLine());

            FactorialAsyncCatchingExcept();
            Console.ReadLine();
        }
        static async void FactorialAsync()
        {
            Console.WriteLine("Начало метода FactorialAsync"); // выполняется синхронно
            Thread.Sleep(3000); // выполняется синхронно
            int result = await Task.Run(() => Factorial(8));  // выполняется асинхронно
            Console.WriteLine($"Факториал равен {result}");
            Console.WriteLine("Конец метода FactorialAsync");
        }

        static async Task FactotialAsyncReturn()
        {
            await Task.Run(() => Factorial(8));
            await Task.Run(() => Factorial(3));
        }

        static async Task<int> FactotialAsyncReturn2()
        {
            int n = await Task.Run(() => Factorial(8));
            return n;
        }

        static async void FactotialAsyncСonsistently()
        {
            int n = await Task.Run(() => Factorial(3));
            await Task.Run(() => Factorial(n)); //Сonsistently, because the second expression using variable of previous Task
        }

        static async void FactotialAsyncNonСonsistently()
        {
            Task t1 = Task.Run(() => Factorial(8));
            Task t2 = Task.Run(() => Factorial(3));
            Task t3 = Task.Run(() => Factorial(4));
            Console.WriteLine("Smth");
            await Task.WhenAll(new[] { t1, t2, t3 });
            Task t4 = Task.Run(() => Console.WriteLine("AFTER"));
        }

        static async void FactorialAsyncCatchingExcept()
        {
            Task t1 = null;
            try
            {
                t1 = Task.Run(() => Factorial(-5));
                await t1;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine($"Is Faulted: {t1.IsFaulted}");
            }
        }
        static int Factorial(int x)
        {
            if (x < 1)
                throw new Exception($"{x} cant be < 1");
            int result = 1;

            for (int i = 1; i <= x; i++)
            {
                result *= i;
            }
            Thread.Sleep(3000);
            Console.WriteLine(result);
            return result;
        }
    }
}
