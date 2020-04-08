using System;
using System.Threading;

namespace Thread_lock
{
    class Program
    {
        static int x = 0;
        static object locker = new object();
        static void Main(string[] args)
        {
            for (int i = 0; i < 5; i++)
            {
                Thread t = new Thread(CountLock);
                t.Name = "Thread" + i.ToString();
                t.Start();
            }
        }

        static void Count()
        {
            for (int i = 0; i < 6; i++)
            {
                Console.WriteLine("{0}: {1}", Thread.CurrentThread.Name, x);
                x++;
                Thread.Sleep(100);
            }
        }

        static void CountLock()
        {
            lock(locker)
            {
                for (int i = 0; i < 6; i++)
                {
                    Console.WriteLine("{0}: {1}", Thread.CurrentThread.Name, x);
                    x++;
                    Thread.Sleep(100);
                }
            }
        }
    }
}
