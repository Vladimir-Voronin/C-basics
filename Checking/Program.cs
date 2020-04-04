using System;

namespace Checking
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] nums3 = new int[3,3] { { 0, 1, 2 }, { 3, 4, 5 }, { 1, 4, 5 } };
            Kata.PrintMultiArray(nums3);
            Console.WriteLine(nums3.GetUpperBound(0));
            int[,] array = { { 1, 2 }, { 2, 5 }, { 2, 7 } };
            int a = Kata.SumOfMinimums(array);
            Console.WriteLine(a);

            string s1 = "   LA LA LA, My name is samalamadumalama    ";
            s1 = Kata.UpperFirstChar(s1);
            Console.WriteLine(s1.GetType().ToString());
        }
    }

    class Kata
    {
        public static void PrintMultiArray(int[,] numbers)
        {
            int rows = numbers.GetUpperBound(0) + 1;
            int columns = numbers.Length / rows;
            for (int i = 0; i < rows; i++)
            {
                for (int k = 0; k < columns; k++)
                {
                    Console.Write("{0} ", String.Join(" ", numbers[i, k]));
                }
                Console.Write("\n");
            }
        }
        public static int SumOfMinimums(int[,] numbers)
        {
            int result = 0;
            int rows = numbers.GetUpperBound(0) + 1;
            int columns = numbers.Length / rows;
            for(int i = 0; i < rows; i++)
            {
                int min = numbers[i, 0];
                for(int k = 0; k < columns; k++)
                {
                    if (numbers[i, k] < min)
                        min = numbers[i, k];
                }
                result += min;
            }
            return result;
        }

        public static string UpperFirstChar(string s)
        {
            string[] current = s.Split(" ");
            string result = "";
            for(int i=0;i < current.Length; i++)
            {
                if (current[i] == " " || current[i] == "") continue;
                if (i == 0) result = current[i].Substring(0,1).ToUpper() + current[i].Substring(1, current[i].Length - 1).ToLower() + " ";
                else
                {
                    result += current[i].Substring(0, 1).ToUpper() + current[i].Substring(1, current[i].Length - 1).ToLower()+ " ";
                }
                    
            }
            return result.TrimEnd();
        }
    }
}
