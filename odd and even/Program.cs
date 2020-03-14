using System;

namespace odd_and_even
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter start var: ");
            int startvar = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter end var: ");
            int endvar = Convert.ToInt32(Console.ReadLine());
            if (endvar <= startvar)
            {
                Console.WriteLine("Exception!! end <= start");
            }
            else
            {
                int oddadd = 0;
                int evenadd = 0;
                while (endvar >= startvar)
                {
                    if (startvar % 2 == 0)
                    {
                        evenadd = evenadd + startvar;
                    }
                    else
                    {
                        oddadd = oddadd + startvar;
                    }
                    startvar++;
                }
                Console.WriteLine("oddadd = " + oddadd);
                Console.WriteLine("evenadd = " + evenadd);
            }
        }
    }
}
