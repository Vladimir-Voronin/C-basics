using System;

namespace Properties
{
    class Program
    {
        static void Main(string[] args)
        {
            User tom = new User
            {
                Firstname = "Tom",
                Lastname = "Jeff",
                Numofmutations = 30,
                Age = 21
            };
            tom.Age = 10000;
            Console.WriteLine(tom.Age);
            Console.WriteLine(tom.NormalAndMutation);
        }
    }

    class User
    {
        private string firstname;
        public string Lastname { get; set; }
        private int age;
        const int arms = 2;
        const int legs = 2;
        public int Numofmutations { get; set; }
        public string Firstname
        {
            get { return firstname; }
            set { firstname = value; }
        }

        public int Age
        {
            get { return age; }
            set
            {
                if (value > 0 && value < 120)
                {
                    age = value;
                }
            }
        }

        public int NormalAndMutation
        {
            get { return arms + legs + Numofmutations; }
        }

    }

}
