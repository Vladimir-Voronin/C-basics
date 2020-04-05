using System;
using System.Threading;

namespace Threads
{
    class Program
    {
        static void Main(string[] args)
        {
            FirstThread();
            TwoWorkingThreads();
            ThreadWithParam();
            ThreadWithParam2();
            ThreadWithoutUnboxing();
            ThreadWithLymbda();
        }

        /// <summary>
        /// Thread and his properties
        /// </summary>
        static void FirstThread()
        {
            //Get link to current thread
            Thread t = Thread.CurrentThread;

            Console.WriteLine($"Name: { t.Name }");
            t.Name = "method First";
            Console.WriteLine($"Name: { t.Name }");
            Console.WriteLine($"Запущен ли поток: {t.IsAlive}");
            Console.WriteLine($"Приоритет потока: {t.Priority}");
            Console.WriteLine($"Статус потока: {t.ThreadState}");

            // получаем домен приложения
            Console.WriteLine($"Домен приложения: {Thread.GetDomain().FriendlyName}");
        }

        /// <summary>
        /// Two Threads: main and Count
        /// </summary>
        static void TwoWorkingThreads()
        {
            Thread myThread = new Thread(new ThreadStart(Count)); //Создали поток и передали ему метод
            myThread.Start(); //Запуск потока

            for (int i = 0; i < 9; i++)
            {
                Console.WriteLine("First Thread: ");
                Console.WriteLine(i);
                Thread.Sleep(100);
            }
        }

        static void ThreadWithParam()
        {
            Thread thr = new Thread(new ParameterizedThreadStart(CountParam));
            thr.Start(4); //Запускаем поток, и передаем ему параметр
        }

        /// <summary>
        /// using class to give 2 or more arguments
        /// </summary>
        static void ThreadWithParam2()
        {
            Counter c = new Counter() { x = 3, y = 6 };
            Thread thr = new Thread(new ParameterizedThreadStart(MethodWithTwoParam));
            thr.Start(c); //Запускаем поток, и передаем ему параметр
        }

        static void ThreadWithoutUnboxing()
        {
            Counter c = new Counter() { x = 2, y = 5 };
            Thread t = new Thread(new ThreadStart(() => c.Loop()));
            t.Start();
        }

        static void ThreadWithLymbda()
        {
            Thread t = new Thread(() => CountParamInt(6));
            t.Start();
        }
        static void Count()
        {
            for(int i=0; i < 9; i++)
            {
                Console.WriteLine("Second Thread: ");
                Console.WriteLine(i);
                Thread.Sleep(400);
            }
        }

        static void CountParam(object n)
        {
            int num = (int)n;
            for (int i = 0; i < num; i++)
            {
                Console.WriteLine("WIth param: ");
                Console.WriteLine(i);
                Thread.Sleep(400);
            }
        }
        static void CountParamInt(int n)
        {
            int num = (int)n;
            for (int i = 0; i < num; i++)
            {
                Console.WriteLine("WIth param: ");
                Console.WriteLine(i);
                Thread.Sleep(400);
            }
        }
        static void MethodWithTwoParam(object obj)
        {
            Counter myobj = (Counter)obj;
            Console.WriteLine("////Two Argumetnts////");
            Console.WriteLine(myobj.x * myobj.y);
            Console.WriteLine("////////");
        }
        
    }
    class Counter
    {
        public int x;
        public int y;

        public void Loop()
        {
            for (int i = 0; i < 9; i++)
            {
                Console.WriteLine("Internal Thread: ");
                Console.WriteLine(i*x*y);
                Thread.Sleep(400);
            }
            
        }
    }
}
