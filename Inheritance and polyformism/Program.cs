using System;

namespace Inheritance_and_polyformism
{
    class Program
    {
        static void Main(string[] args)
        {
            User user = new User("Tom", "Taromov", 32);
            user.Info();
            User user2 = new Admin("Mike", "Vazovskiy", 47, "MIKIO");
            user2.Info();
            Admin admin = new Admin("Frodo", "Beggins", 46, "FRODOHERE");
            admin.Info();
            MainAdmin main = new MainAdmin("Ludvig", "One-Bethivin", 32, "DeafButCool", 25000);
            main.Info();

            user.Check();
            user2.Check();
            admin.Check();
            main.Check();
        }
    }



    class User
    {
        protected string Name { get; set; }
        protected string Surname { get; set; }
        private int age;

        protected int Age
        {
            get { return age;  }
            set 
            {
                if(value > 0 && value < 120)
                {
                    age = value;
                }
            }
        }

        public User()
        {

        }
        
        public User(string name, string surname, int age)
        {
            Name = name;
            Surname = surname;
            Age = age;
        }

        public virtual void Info()
        {
            Console.WriteLine($"User: {Name} {Surname}, {Age} years old");
        }

        public void Check()
        {
            Console.WriteLine("I AM NOTHING");
        }

    }

    class Admin : User
    {
        protected string Nickname { get; set; }

        public Admin(string name, string surname, int age, string nickname) : base(name, surname, age)
        {
            Nickname = nickname;
        }

        public override void Info()
        {
            Console.WriteLine($"Admin: {Name} {Surname}, {Age} years old. Nick: {Nickname}");
        }

        public new void Check()
        {
            Console.WriteLine("I AM ADMIN");
        }
    }

    class MainAdmin : Admin
    {
        protected int Salary { get; set; }

        public MainAdmin(string name, string surname, int age, string nickname, int salary) : base(name, surname, age, nickname)
        {
            Salary = salary;
        }

        public override sealed void Info()
        {
            base.Info();
            Console.WriteLine($"Salary: {Salary}");
        }

        public new void Check()
        {
            Console.WriteLine($"I AM THE MAIN ADMIN, MY SALARY: {Salary}");
        }
    }
}
