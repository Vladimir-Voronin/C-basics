using System;
using System.Threading.Tasks;

namespace Tasks
{
    class Program
    {
        static void Main(string[] args)
        {
            TaskCountinue();
        }
        
        static void FirstTask()
        {
            Task t = new Task(() => Console.WriteLine("FirstTaskRun"));
            t.Start();
            t.Wait();
            Task t2 = new Task(InDisplay);
            t2.Start();
            Console.ReadLine();
        }

        static void NestedTasks()
        {
            Task t = Task.Factory.StartNew(() =>
            {
                Console.WriteLine("First");
                var t2 = Task.Factory.StartNew(() =>
                {
                    Console.WriteLine("Nested 1");
                    var t3 = Task.Run(() => Console.WriteLine("Nested 2"));
                });
            }, TaskCreationOptions.AttachedToParent);
            t.Wait(); // Wait external Task (t)
            Console.WriteLine("Second");
        }

        static void ArrayTask()
        {
            Task[] tasks1 = new Task[3]
            {
                new Task(() => Console.WriteLine("First Task")),
                new Task(() => Console.WriteLine("Second Task")),
                new Task(() => Console.WriteLine("Third Task"))
            };
            foreach (var t in tasks1)
                t.Start();
            Task.WaitAll(tasks1); // ожидаем завершения задач 

            Console.WriteLine("The end");

        }

        static void ReturnResult()
        {
            Task<int> t = new Task<int>(() => Count(new int[] { 2, 6, 3, 6, 2, 4, 1, 6, 4, 3, 6, 5, 6, 7 })); //very long array
            t.Start();
            int a = t.Result; //Wait for get result!
            Task<int> t2 = new Task<int>(() => Count(new int[] { 2, a }));
            t2.Start();
        }

        static void TaskCountinue()
        {
            Task<int> t = Task<int>.Factory.StartNew(() => Count(new int[] { 2, 6, 3, 6, 2, 4, 1, 6, 4, 3, 6, 5, 6, 7 }));
            Console.WriteLine(t.Result);
            ArrayTask();
            Task t2 = t.ContinueWith(threhj=>DisplayTask(threhj));
            Console.WriteLine("Check"); //Check can realized before t2 will end
        }

        static int Count(int[] array)
        {
            int result = 0;
            foreach(int i in array)
            {
                result += i;
            }
            return result;
        }
        static void DisplayTask(Task<int> task)
        {
            Console.WriteLine(task.Result);
        }


        static void InDisplay()
        {
            Console.WriteLine("This is Display method");
            Console.WriteLine("The End of Display method");
        }
    }
}