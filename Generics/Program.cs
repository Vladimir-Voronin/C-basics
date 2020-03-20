using System;

namespace Generics
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Client<Account> client1 = new Client<Account>("Tommi", 5000);
            client1.AccountInfo();
            Console.WriteLine(client1.Root());

            Admin<Account> admin1 = new Admin<Account>("Frank", "Franki_", 5000, true);
            admin1.AccountInfo();
            admin1.Bankacc.Info();
            Console.WriteLine(admin1.Root());
        }
    }

    abstract class User
    {
        protected string Nickname { get; set; }
        public Account Bankacc { get; protected set; }

        public override string ToString()
        {
            return Nickname;
        }

        public abstract bool Root();
        public abstract void AccountInfo();
    }

    class Client<T> : User where T : Account
    {
        public Client(string nick, double money)
        {
            Nickname = nick;
            Bankacc = new Account(money);
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

    class Admin<T> : User where T : Account
    {
        private string Name { get; set; }
        public bool Acting { get; set; }
        public Admin(string nick, string name, double money)
        {
            Nickname = nick;
            Name = name;
            Bankacc = new Account(money);
        }

        public Admin(string nick, string name, double money, bool acting) : this(nick, name, money)
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
        public double money;
        public double Money
        { 
            get { return money; }
            private set { money = value; }
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
}
