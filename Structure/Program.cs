using System;

namespace Structure
{
    struct User
    {
        public string name;
        public bool isliving;
        public int age;

        public User(string n, bool i, int a)
        {
            name = n;
            isliving = i;
            age = a;
        }

        public void Writing()
        {
            if (isliving)
            {
                Console.WriteLine($"This is User {name} and he is {age} years old");
            }  
            else
            {
                Console.WriteLine($"This is User {name} and he died at the age of {age}");
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            User mike = new User("mike", true, 29);
            mike.Writing();
            User[] list = new User[2];
            list[0].name = "Tommi";
            list[0].isliving = false;
            list[0].age = 53;
            list[1].name = "Asher";
            list[1].isliving = false;
            list[1].age = 42;

            foreach (User user in list)
            {
                user.Writing();
            }

        }
    }
}
