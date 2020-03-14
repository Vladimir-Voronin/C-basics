using System;

namespace Class_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Nothing first = new Nothing(5);
            
        }
    }

    public class Nothing
    {
        int some;
        public Nothing(int var)
        {
            some = var * 3;
        }

        public int increase(int inc)
        {
            return some * inc;
        }
    }
        
}
