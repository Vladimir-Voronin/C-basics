using System;

namespace Overload
{
    class Program
    {
        static void Main(string[] args)
        {          
            Counter var = new Counter(291);
            Timer tim = var;
            Console.WriteLine(var.Info());
            Console.WriteLine(tim.Info());
        }
    }

    class Counter
    {
        public int Seconds { get; set; }

        public Counter()
        {
        }

        public Counter(int seconds)
        {
            this.Seconds = seconds;
        }

        public static Counter operator +(Counter obj1, Counter obj2)
            {
            return new Counter { Seconds = obj1.Seconds + obj2.Seconds };
            }

        public static implicit operator Counter(Timer obj)
        {
            int seconds = obj.Houres*3600 + obj.Minutes*60 + obj.Seconds;
            return new Counter { Seconds = seconds };
        }

        public string Info()
        {
            return $"{this.Seconds}";
        }
    }

    class Timer
    {
        public int Houres { get; set; }
        public int Minutes { get; set; }
        public int Seconds { get; set; }

        public Timer()
        {
        }

        public Timer(int seconds)
        {
            this.Seconds = seconds;
        }

        public Timer(int seconds, int minutes, int hours) : this(seconds)
        {
            this.Minutes = minutes;
            this.Houres = hours;
        }

        public static implicit operator Timer(Counter obj)
        {
            int h = obj.Seconds / 3600;
            int m = (obj.Seconds - h * 3600) / 60;
            int s = obj.Seconds - h * 3600 - m * 60;
            return new Timer { Houres = h, Minutes = m, Seconds = s };
        }

        public string Info()
        {
            return $"{this.Houres} - {this.Minutes} - {this.Seconds}";
        }

    }
}