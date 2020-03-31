using System;
using System.Collections.Generic;

namespace Delegates
{
    public delegate void OverDelegate(string message);
    class Program
    {
        static void Main(string[] args)
        {
            User user1 = new User() { Name = "Vasy" };
            user1.Info();

            OverDelegate deluser1 = new OverDelegate(user1.InfoForDelegete);

            user1.AddDelegate(Print);
            user1.AddDelegate(RedPrint);

            deluser1("YO YO YO");

            user1.AddDelegate(RedPrint);

            user1.Info();
            user1.InfoArguments();

            user1.RemoveLastMethodFromDelegate();
            Console.WriteLine();

            user1.Info();
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

    class User
    {
        public delegate void MyDelegate(string message);
        public string Name { get; set; }
        public MyDelegate _del;
        public void AddDelegate(MyDelegate method)
        {
            _del += method;
        }

        public void RemoveLastMethodFromDelegate()
        {
            _del -= (MyDelegate)_del.GetInvocationList()[_del.GetInvocationList().Length - 1];
        }

        public void Info()
        {
            if(_del == null)
                Console.WriteLine("Pls, define delegate with method AddDelegate");
            else
                _del(String.Format($"This is {Name}"));
        }

        public void InfoArguments()
        {
            if (_del == null)
                Console.WriteLine("Pls, define delegate with method AddDelegate");
            else
                _del(String.Format($"Name: {Name}\nDelegate: {_del.ToString()}"));
        }
        
        public void InfoForDelegete(string message)
        {
            if (_del == null)
                Console.WriteLine("Pls, define delegate with method AddDelegate");
            else
                _del("I am Metgod for other delegate");
                _del(String.Format($"I am {this.Name}, my message: {message}"));
        }
    }
}
