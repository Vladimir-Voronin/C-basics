using System;

namespace functions
{
    class Program
    {
        static void Main(string[] args)
        {
            int x, y, z, b, j;
            x = 0;
            y = 0;
            b = 0;
            

            typical(x);
            withref(ref y);
            b = with_out(x, y, out j);
            writing(x, y, b, j);

            static void writing(int x, int y, int b, int j)
            {
                int[] numbers = { x, y, b, j };
                int i = 0;
                foreach (int element in numbers)
                {
                    if (element == 0)
                    {
                        Console.WriteLine($"element {i} == 0");
                    }

                    else
                    {
                        Console.WriteLine($"element {i} changed to {element}");
                    }

                    i++;
                }
            }
            static void typical(int x)
            {
                x++;
            }

            static void withref(ref int some)
            {
                some++;
            }

            static int with_out(int x, int y, out int some)
            {
                some = x + y;
                x = 2;
                return x;
            }
        }
    }
}
