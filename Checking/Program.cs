using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;

namespace Checking
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Kata.DigPow(46288, 3));

        }
    }




    struct Str
    {
        public int x;
        public int y;
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
            for (int i = 0; i < rows; i++)
            {
                int min = numbers[i, 0];
                for (int k = 0; k < columns; k++)
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
            for (int i = 0; i < current.Length; i++)
            {
                if (current[i] == " " || current[i] == "") continue;

                result += current[i].Substring(0, 1).ToUpper() + current[i].Substring(1, current[i].Length - 1).ToLower() + " ";
            }
            return result.TrimEnd();
        }

        public static void MainRegular()
        {
            string pattern = @"^[a-zA-Z0-9{}]+$";
            while (true)
            {
                string value = Console.ReadLine();
                if (Regex.IsMatch(value, pattern, RegexOptions.IgnoreCase))
                    Console.WriteLine($"String {value} is verify");
                else
                    Console.WriteLine($"String {value} NOO");
            }
        }

        //Given two arrays a and b write a function comp(a, b) (compSame(a, b) in Clojure) that checks whether the two arrays have the "same" elements,
        //with the same multiplicities. "Same" means, here, that the elements in b are the elements in a squared, regardless of the order.
        public static bool Comp(int[] a, int[] b)
        {
            if (a == null || b == null) return false;
            List<int> b1 = new List<int>(b);
            int count = 0;
            foreach (var i in a)
            {
                foreach (var elemb in b1)
                {
                    if (i * i == elemb)
                    {
                        b1.Remove(elemb);
                        count++;
                        break;
                    }
                }
                if (count == a.Length) return true;
            }
            return false;
        }

        //Given a number, say prod (for product), we search two Fibonacci numbers F(n) and F(n+1) verifying
        //productFib(714) # should return {21, 34, true}
        public static ulong[] ProductFib(ulong prod)
        {
            ulong first = 0;
            ulong second = 1;
            ulong sec;
            while (true)
            {
                sec = second;
                second = sec + first;
                first = sec;
                if (first * second == prod) return new ulong[] { first, second, 1 };
                else if (first * second >= prod) return new ulong[] { first, second, 0 };
            }
        }

        //A child is playing with a ball on the nth floor of a tall building. The height of this floor, h, is known.
        //He drops the ball out of the window.The ball bounces(for example), to two-thirds of its height(a bounce of 0.66).
        //His mother looks out of a window 1.5 meters from the ground.
        //How many times will the mother see the ball pass in front of her window (including when it's falling and bouncing?
        public static int BouncingBall(double h, double bounce, double window)
        {
            if (bounce >= 1) return -1;
            int result = 0;
            while (true)
            {
                result++;
                h = h * bounce;
                if (h > window) result++;
                else break;
            }
            return result;
        }

        //Given a positive integer n written as abcd... (a, b, c, d... being digits) and a positive integer p
        //we want to find a positive integer k, if it exists, such as the sum of the digits of n taken to the successive powers of p is equal to k* n.
        //digPow(46288, 3) should return 51 since 4³ + 6⁴+ 2⁵ + 8⁶ + 8⁷ = 2360688 = 46288 * 51
        //digPow(92, 1) should return -1 since there is no k such as 9¹ + 2² equals 92 * k
        public static long DigPow(int n, int p)
        {
            int[] intArray = n.ToString().Select(c => (int)c - 48).ToArray();
            double par = Convert.ToDouble(p);
            double result = 0;
            foreach (var item in intArray)
            {
                double numb = Convert.ToDouble(item);
                numb = Math.Pow(numb, par++);
                result += numb;
            }
            result = result / n;
            return result % 1 == 0 ? Convert.ToInt64(result) : -1;
        }
    }
}
