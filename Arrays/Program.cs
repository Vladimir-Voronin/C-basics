using System;

namespace Arrays
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] ar1 = new int[4] { 1, -2, 2, -3 };
            Console.WriteLine(SecondMin(ar1));

            int[] ar2 = new int[4] { -2, -2, 2, -3 };
            Console.WriteLine(FirstCouple(ar2));
        }

        static int SecondMin(int[] arr)
        {
            if (arr.Length == 0) throw new Exception("Length of array < 1");
            int min = arr[0];
            int minsec = arr[1];
            for (int i = 0; i < arr.Length; i++)
            {
                if(arr[i] < min)
                {
                    int save = min;
                    min = arr[i];
                    minsec = save;
                }
            }
            return minsec;
        }

        static (int, int) FirstCouple(int[] arr)
        {
            for (int i = 1; i < arr.Length; i++)
            {
                if (arr[i] != arr[i - 1]) return (arr[i - 1], arr[i]);
            }
            return (0, 0);
        }


    }

    
}
