using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Events
{
    class Mail
    {
        public void GetGood(Object sender, GoodEventArgs e)
        {
            Console.WriteLine("New Mail: {1} from {0}", e.Country, e.Title);
        }
    }

    class Delivery
    {
        public void GetGood(Object sender, GoodEventArgs e)
        {
            Console.WriteLine("New delivery: {1} from {0}", e.Country, e.Title);
        }
    }

    class GoodEventArgs : EventArgs
    {
        private readonly String country, title;

        public GoodEventArgs(String country, String title)
        {
            this.country = country;
            this.title = title;
        }

        public String Country { get { return country; } }
        public String Title { get { return title; } }
    }

    class Bascet
    {
        public event EventHandler<GoodEventArgs> NewGood;

        protected virtual void OnNewGood(GoodEventArgs e)
        {
            EventHandler<GoodEventArgs> temp = Volatile.Read(ref NewGood);
            if (temp != null) temp(this, e);
        }

        public void CreateGood(String country, String title)
        {
            var e = new GoodEventArgs(country, title);
            OnNewGood(e);
        }
    }
}
