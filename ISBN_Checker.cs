using System;
using System.Linq;

namespace BIO2003_Q1
{
    class ISBN_Checker
    {

        // Check a given ISBN string s for validity;
        static bool CheckISBN(string s)
        {
            int tot = 0;

            // iterate digits 0 to 8; digit 9 can be special case of 'X'
            for (int i=0; i < 9; i++)
            {
                tot += Convert.ToInt32(s.Substring(i, 1)) * (10-i);
            }
            // check last digit for x; compare mod 11 divisor to 0
            return (tot = s.Substring(9, 1) == "X" ? tot += 10 : tot += Convert.ToInt32(s.Substring(9, 1))) % 11 == 0;
        }

        // Given a strin s ISBN number with one ? missing digit, return the require digit
        static string ISBN(string s)
        {
            string checkString = "";
            string result = "";
            string[] digits = {"0","1","2","3","4","5","6","7","8","9","X"};

            // Create eachof the strings with 0..X replacing ?
            foreach (string digit in digits)
            {
                checkString = s.Replace("?", digit);
                if (CheckISBN(checkString))
                {
                    result = digit;
                    break;
                }
            }
            return result;
        }

        // Swaps characters in a string.
        static string SwapCharacters(string value, int position1, int position2)
        {
            // Swaps characters in a string.
            char[] array = value.ToCharArray(); // Get characters
            char temp = array[position1]; // Get temporary copy of character
            array[position1] = array[position2]; // Assign element
            array[position2] = temp; // Assign element
            return new string(array); // Return string
        }

        // Given an ISBN string s that has two positions transposed, find the potential solutions
        static void MixedString(string s)
        {
            string checkString = "";

            for(int i=0; i<10; i++)
            {
                for(int j=i+1; j<10; j++)
                {
                    checkString = SwapCharacters(s, i, j);
                    if (CheckISBN(checkString))
                    {
                        Console.WriteLine(checkString);
                    }
                }
            }
        }
        static void Main()
        {
            Console.WriteLine("BIO 2003 Q1 ISBN\n");
            Console.WriteLine("Q1a\n");
            Console.WriteLine("15688?111X "+ISBN("15688?111X"));
            Console.WriteLine("812071988? "+ISBN("812071988?"));
            Console.WriteLine("020161586? "+ISBN("020161586?"));
            Console.WriteLine("?131103628 "+ISBN("?131103628"));
            Console.WriteLine("?86046324X "+ISBN("?86046324X"));
            Console.WriteLine("1?68811306 "+ISBN("1?68811306"));
            Console.WriteLine("951?451570 "+ISBN("951?451570"));
            Console.WriteLine("0393020?31 "+ISBN("0393020?31"));
            Console.WriteLine("01367440?5 "+ISBN("01367440?5"));
            Console.WriteLine("\nQ1b\n");
            Console.WriteLine("Valid: 0972311900 " + CheckISBN("0972311900"));
            Console.WriteLine("Valid: 3540678654 " + CheckISBN("3540678654"));
            Console.WriteLine("Valid: 9514451570 " + CheckISBN("9514451570"));
            Console.WriteLine("Valid: 013674409X " + CheckISBN("013674409X"));
            Console.WriteLine("\n1c\n");
            MixedString("3201014525");
        }
    }
}
