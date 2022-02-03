using System;

namespace Work_with_bits
{
    class Program
    {
        static void Main(string[] args)
        {
            uint a = 0b_1111_1000;
            uint b = 0b_0001_1100;
            Console.WriteLine($"a: {Convert.ToString(a, 2)}");
            Console.WriteLine($"b: {Convert.ToString(b, 2)}");

            uint result = a + 1;
            Console.WriteLine($"result: {Convert.ToString(result, 2)}");
        }
    }
}
