using System;

namespace Events
{
    class Program
    {
        static void Main(string[] args)
        {
            Test t = new Test();

            t.MyEvent += new EventHandler(t.DoNothing);
            t.MyEvent -= null;

            MyUser u = new MyUser() { Name = "Clown"};
            u.Event += Print;
            u.Info();
            

        }

        public static void Print(string message)
        {
            Console.WriteLine(message);
        }

        public static void RedPrint(string message)
        {
            Console.BackgroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ResetColor();
        }
    }
    class MyUser
    {
        public delegate void MyDelegate(string message);
        public event MyDelegate Event;
        public string Name { get; set; }
        public MyDelegate del;

        public void Info()
        {
            if (Event == null)
                Console.WriteLine("Pls, define delegate with method AddDelegate");
            else
                Event(String.Format($"This is {Name}"));
        }

        public void InfoArguments()
        {
            if (Event == null)
                Console.WriteLine("Pls, define delegate with method AddDelegate");
            else
                Event(String.Format($"Name: {Name}\nDelegate: {del.ToString()}"));
        }

        public void InfoForDelegete(string message)
        {
            if (Event == null)
                Console.WriteLine("Pls, define delegate with method AddDelegate");
            else
                Event("I am Metgod for other delegate");
            Event(String.Format($"I am {this.Name}, my message: {message}"));
        }
    }
    class Test
    {
        public event EventHandler MyEvent //публичное событие MyEvent с типом EventHandler
        {
            add
            {
                Console.WriteLine("add operation");
            }

            remove
            {
                Console.WriteLine("remove operation");
            }
        }
        public void DoNothing(object sender, EventArgs e)
        {
        }

    }
    
}
