using System;
using System.Text.RegularExpressions;

namespace LAB_ValidTime
{
    public class ValidTime
    {
        public static void Main()
        {
            var input = Console.ReadLine();

            var regex = new Regex(@"^(?:0[\d])|(?:1[01]):[0-5][\d]:[0-5][\d] [AP][M]$");
            while (input != "END")
            {
                if (regex.IsMatch(input))
                {
                    Console.WriteLine("valid");
                }
                else
                {
                    Console.WriteLine("invalid");
                }

                input = Console.ReadLine();
            }
        }
    }
}
