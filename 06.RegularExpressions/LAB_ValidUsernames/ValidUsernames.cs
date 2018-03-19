using System;
using System.Text.RegularExpressions;

namespace LAB_ValidUsernames
{
    public class ValidUsernames
    {
        public static void Main()
        {
            var input = Console.ReadLine();

            var regex = new Regex(@"^[\w-]{3,16}$");
            while (input != "END")
            {
                Console.WriteLine(regex.IsMatch(input) ? "valid" : "invalid");

                input = Console.ReadLine();
            }
        }
    }
}