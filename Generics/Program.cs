using System;

namespace Generics
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Client<Account> client1 = new Client<Account>("Tommi", new Account(5000));
            client1.AccountInfo();
            

            Console.WriteLine(client1.Root());

            Admin<FullAccount> admin1 = new Admin<FullAccount>("Frank", "Franki_", new FullAccount(5000), true);
            admin1.AccountInfo();
            admin1.Bankacc.Info();
            admin1.Bankacc.Credit(5, 2.5);
            admin1.Bankacc.Info();
            Console.WriteLine(admin1.Root());

        }
    }

    abstract class User<T> where T : Account
    {
        protected string Nickname { get; set; }

        public T Bankacc { get; protected set; }
        public override string ToString()
        {
            return Nickname;
        }

        public abstract bool Root();
        public abstract void AccountInfo();
    }

    class Client<T> : User<T> where T : Account
    {
        
        public Client(string nick, T obj)
        {
            Nickname = nick;
            Bankacc = obj;
        }
        public override bool Root()
        {
            return Bankacc > 10000 ? true : false;
        }

        public override void AccountInfo()
        {
            Console.WriteLine($"There is {(double)Bankacc} in {Nickname}");
        }

    }

    class Admin<T> : User<T> where T : Account
    {
        private string Name { get; set; }
        public bool Acting { get; set; }
        public Admin(string nick, string name, T obj)
        {
            Nickname = nick;
            Name = name;
            Bankacc = obj;
        }

        public Admin(string nick, string name, T obj, bool acting) : this(nick, name, obj)
        {
            Acting = acting;
        }
        
        public override bool Root()
        {
            return (Bankacc > 2000 && Acting) || Bankacc > 10000 ? true : false;
        }

        public override void AccountInfo()
        {
            Console.WriteLine($"Admin! There is {(double)Bankacc} in {Nickname}");
        }
    }
    
    class Account
    {
        private double money;
        public double Money
        { 
            get { return money; }
            protected set { money = value; }
        }

        public Account(double money)
        {
            Money = money;
        }

        public static implicit operator double(Account obj)
        {
            return obj.Money;
        }

        public void Info()
        {
            Console.WriteLine($"Account! There is {Money}");
        }
    }

    class FullAccount : Account
    {

        public FullAccount(double money) : base(money)
        {
        }

        public void Credit(int year, double interest)
        {
            Money += Money * interest/100 * year;
        }
    }
}