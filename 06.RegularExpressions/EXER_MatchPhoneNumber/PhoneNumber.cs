using System;
using System.Text.RegularExpressions;

namespace EXER_MatchPhoneNumber
{
    public class PhoneNumber
    {
        public static void Main()
        {
            var input = Console.ReadLine();

            var regex = new Regex(@"^\+359([ |-])2\1[\d]{3}\1[\d]{4}$");
            while (input != "end")
            {
                var match = regex.Match(input);

                Console.WriteLine(match);

                input = Console.ReadLine();
            }
        }
    }
}
