using System;

namespace Nested_loops
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Write("Enter the height of the triangle: ");
                int height = int.Parse(Console.ReadLine());

                Console.WriteLine();


                for (int i = 0; i < height; i++)
                {
                    for (int j = 0; j < i + 1; j++)
                    {
                        Console.Write('@');
                    }
                    Console.WriteLine();
                }

                Console.WriteLine();

                for (int i = height; i > 0; i--)
                {
                    for (int j = i; j > 0; j--)
                    {
                        Console.Write('@');
                    }
                    Console.WriteLine();
                }
            }
        }
    }
}
