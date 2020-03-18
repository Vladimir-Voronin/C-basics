using System;
using System.Collections.Generic;
using System.Text;

namespace Class_1
{
    public class User
    {
        public string name;
        public int age;
        int check;

        public User()
        {
        }

        public User(string name)
        {
            this.name = name;
        }

        public User(string name, int age) : this(name)
        {
            this.age = age;
        }

        public User(string name, int age, int check) : this(name, age)
        {
            this.check = check;
        }
        public void Info()
        {
            Console.WriteLine($"{name} - {age} and {check}");
        }
    }

}

