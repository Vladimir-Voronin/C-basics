using System;

namespace Work_with_strings
{
    class Program
    {
        static void Main(string[] args)
        {
            // Initializing strings
            string s1 = "London";
            string s2 = new String("is capital");
            string s3 = new String('a', 5);
            string s4 = new String(new char[] { 'a', 'b', 'c' });
            char c1 = s1[0];

            // Concatanating strings
            string s5 = s1 + " " + s2;
            string s6 = String.Concat(s1, " ", s2);
            Console.WriteLine(s5.Equals(s6));   // s5 == s6

            //Concatanating with array
            string[] sArr1 = { "London", "is capital" };
            string s7 = String.Join(" ", sArr1);
            Console.WriteLine(s5.Equals(s7));  // s5 == s7

            // Comparing 2 strokes
            string s8 = "I will never";
            string s9 = "I will try";

            int result = String.Compare(s8, s9);
            Console.WriteLine(result);
            if (result < 0)
            {
                Console.WriteLine("Строка s1 перед строкой s2");
            }
            else if (result > 0)
            {
                Console.WriteLine("Строка s1 стоит после строки s2");
            }
            else
            {
                Console.WriteLine("Строки s1 и s2 идентичны");
            }

            // Get index of first sunstring and last substring
            string s10 = "hello world hello   world";
            char ch = 'o';
            int indexOfChar = s10.IndexOf(ch); // равно 4
            Console.WriteLine(indexOfChar);

            string subString = "wor";
            int indexOfSubstring = s10.LastIndexOf(subString); // равно 6
            Console.WriteLine(indexOfSubstring);

            // StartWith and GetWith (return bool)
            Console.WriteLine(s10.StartsWith("gfgr"));
            Console.WriteLine(s10.StartsWith("hello"));
            Console.WriteLine(s10.EndsWith(".exe"));

            // Spliting strings, ***StringSplitOptions.RemoveEmptyEntries false in default
            string[] sArr2 = s10.Split(new string[] { " h", " " }, StringSplitOptions.RemoveEmptyEntries);
            Console.WriteLine("///////");
            foreach (string s in sArr2) Console.WriteLine(s);

            //Cut Backspace from string in start and end (or only in start/end)
            string s11 = "   YO, My name is Tom       ";
            Console.WriteLine(s11.Trim());
            Console.WriteLine(s11.TrimStart() + "End");
            Console.WriteLine(s11.TrimEnd());

            //Get Substring
            string s12 = s10.Substring(6, 5); // 5 - Lenght
            Console.WriteLine(s12);  //world

            //Insert string
            string text = "Hello Glad to see you";
            string subString1 = "Tom! ";

            text = text.Insert(6, subString1);
            Console.WriteLine(text);

            //Remove
            s10 = s10.Remove(10, s10.Length - 11);
            Console.WriteLine(s10);

            //Replace (easy to delete any certain strings)
            s10 = s10.Replace("world", "Tom");
            Console.WriteLine(s10);
            s10 = s10 + "Tom Tom";
            s10 = s10.Replace("Tom", "");  //Remove all "Tom"
            Console.WriteLine(s10);

            //change letter case
            Console.WriteLine(s10.ToUpper());
            Console.WriteLine(s10.ToLower());
        }
    }
}
