using System;
using System.Threading;
using System.Collections.Generic;

namespace Semaphores_and_Threads
{
    class Program
    {
        static void Main(string[] args)
        {
            Client us1 = new Client("1");
            Client us2 = new Client("2");
            Client us3 = new Client("3");
            Client us4 = new Client("4");
            Client us5 = new Client("5");
            Client us6 = new Client("6");
            Client us7 = new Client("7");
            Client us8 = new Client("8");
            Client us9 = new Client("9");
            Client us10 = new Client("10");
            Client us11 = new Client("11");
            Client us12 = new Client("12");
            Client us13 = new Client("13");
            Client us14= new Client("14");
            Client us15= new Client("15");
            Client us16= new Client("16");
            Client us17 = new Client("17");
            Client us18 = new Client("18");
            Client us19 = new Client("19");
            //foreach(Client client in Client.ClientsList)
            //{
            //    Console.WriteLine(client.Name);
            //}
            Call call1 = new Call(Client.ClientsList);
        }
    }

    class Call
    {
        static Semaphore sem = new Semaphore(5, 10);   // max clietns in server
        private List<Client> clientsoncall = new List<Client>();  //clients on call
        public List<Client> ClientsOnCall { get { return clientsoncall; } set { clientsoncall = value; } }
        private int Count { get; set; }
        public delegate void DoubleStr(string name, string mess);  // private delegate for Write debug info
        public event DoubleStr Info;    //Event, which given info about join, remove and other actions
        public object locker = new object();
        Random rnd = new Random();

        TimerCallback tm = new TimerCallback((object obj) =>
        {
            List<Client> a = (List<Client>)obj;
            int len = a.Count;
            Console.WriteLine($"Clients on call: {len}");
        });

        //private Queue<Client> queue = new Queue<Client>();  //clients, waiting in queue to join to Call
        //public Queue<Client> Q { get; }


        public Call()
        {

        }

        public Call(Client client)
        {
            this.Add(client);
        }
        public Call(List<Client> clients)
        {
            this.Info += (string name, string mess) => Console.WriteLine($"User {name} {mess}"); 
            foreach (Client client in clients)
            {
                this.Add(client);
            }
        }

        public void Calling(Client client)
        {
            
            sem.WaitOne();

            //Сокращенная проверка на null
            Info?.Invoke(client.Name, "Join to Call");
            client.OnCall = true;
            lock (locker)
            {
                ClientsOnCall.Add(client);
                
            }
            Thread.Sleep(rnd.Next(1000, 7000));
            Timer timer = new Timer(tm, ClientsOnCall, 0, 2000);
            lock (locker)
            {
                ClientsOnCall.Remove(client);
            }


            Info?.Invoke(client.Name, "Leave from Call");
            client.OnCall = false;
            sem.Release();
        }
        public void Add(Client client)
        {
            Thread t = new Thread(() => Calling(client));

            t.Start();
        }

        public void Remove(Client client)
        {

        }
        
        //public bool Check(Client client)
        //{
        //    if(ClientsOnCall.Length==10)
        //    {
        //        Q.Enqueue(client);
        //        return false;   //Call server is full
        //    }
        //    else
        //    {
        //        ClientsOnCall[Count + 1] = client;
        //        Count++;
        //        return true;
        //    }
        //}
    }

    class Client
    {
        public string Name { get; set; }
        public bool OnCall { get; set; }
        private static List<Client> clients = new List<Client>();
        public static List<Client> ClientsList { get { return clients; } set { value = clients; } }
        public Client(string name = "guest")
        {
            Name = name;
            ClientsList.Add(this);
        }
    }
}