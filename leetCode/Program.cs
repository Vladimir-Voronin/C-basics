using System;

namespace leetCode
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(MaxProfit(new int[] { 7, 1, 5, 3, 6, 4 }));
        }

        //Given a sorted array nums, remove the duplicates in-place such that each element appear only once and return the new length.
        //Do not allocate extra space for another array, you must do this by modifying the input array in-place with O(1) extra memory.
        public static int RemoveDuplic(int[] arr)
        {
            if (arr.Length == 0) return 0;
            int result = 1;
            for (int i = 1; i < arr.Length; i++)
            {
                if (arr[i] != arr[i - 1])
                {
                    arr[result] = arr[i];
                    result++;
                }
            }
            return result;
        }

        //Say you have an array prices for which the ith element is the price of a given stock on day i.
        //Design an algorithm to find the maximum profit.You may complete as many transactions as you like (i.e., buy one and sell one share of the stock multiple times).
        public static int MaxProfit(int[] prices)
        {
            int result = 0;
            for (int i = 0; i < prices.Length; i++)
            {
                if (i + 1 >= prices.Length)
                {
                    break;
                }

                while (prices[i] >= prices[i + 1])
                {
                    i++;
                    if (i + 1 >= prices.Length) 
                    {
                        i--;
                        break;
                    }
                    
                }
                if (prices[i] < prices[i + 1]) result -= prices[i];

                while (prices[i] <= prices[i + 1])
                {
                    i++;
                    if (i + 1 >= prices.Length)
                    {
                        i--;
                        break;
                    }

                }
                if (prices[i] > prices[i + 1]) result += prices[i];

            }
            return result;
        }

    }
}
