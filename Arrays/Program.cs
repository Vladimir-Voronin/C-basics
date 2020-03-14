using System;

namespace Arrays
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter the number of elements in your array: ");
            int number = int.Parse(Console.ReadLine());

            int[] array = new int[number];

            for (int i = 0; i < array.Length; i++)
            {
                Console.Write("Enter the value of " + i + " element: ");
                array[i] = int.Parse(Console.ReadLine());
            }

            Console.WriteLine("Your array: {0}", string.Join(", ", array));
        }
    }
}
