using System;
using System.Text;
using System.Text.RegularExpressions;

public class Program
{
    public static void Main()
    {
        string input;
        while ((input = Console.ReadLine()) != "Over!")
        {
            var n = int.Parse(Console.ReadLine());

            var message = string.Empty;
            var verificationCode = new StringBuilder();

            var regex = new Regex(@"^(\d+)([a-zA-Z]+)([^a-zA-Z]*)$");
            var match = regex.Match(input);
            if (match.Success)
            {
                if (match.Groups[2].Length != n)
                {
                    continue;
                }

                message = match.Groups[2].Value;

                var tempVCode = new char[50];

                var regex2 = new Regex(@"\d+");
                var match2 = regex2.Match(match.Groups[3].Value
                );
                tempVCode = match2.Success ? (match.Groups[1].Value + match2.Groups[0].Value).ToCharArray() : match.Groups[1].Value.ToCharArray();

                foreach (var digit in tempVCode)
                {
                    var code = int.Parse(digit.ToString());
                    if (code >= 0 & code < n)
                    {
                        verificationCode.Append(message[code]);
                    }
                    else
                    {
                        verificationCode.Append(" ");
                    }
                }

                Console.WriteLine($"{message} == {verificationCode}");
            }
        }
    }
}