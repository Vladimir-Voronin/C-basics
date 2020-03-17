using System;

namespace Class_1
{
    class Program
    {
        static void Main(string[] args)
        {
            User tom = new User();
            tom.name = "Tom";
            tom.age = 14;

            User mike = new User("Mike", 34);
            User max = new User() { name = "Max", age = 24 };
            User checker = new User("Checker", 12, 5);
            tom.Info();
            mike.Info();
            max.Info();
            checker.Info();
        }
    }
}
