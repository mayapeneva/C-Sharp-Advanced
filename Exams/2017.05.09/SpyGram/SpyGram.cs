namespace SpyGram
{
    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;
    using System.Text;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var key = Console.ReadLine();
            var command = Console.ReadLine();

            var result = new List<string>();
            while (command != "END")
            {
                var regex = new Regex(@"TO:\s[A-Z]+;\sMESSAGE:\s.*;");
                var match = regex.Match(command);

                if (match.Success)
                {
                    var encryptedMessage = new StringBuilder();
                    var index = 0;
                    for (int i = 0; i < command.Length; i++)
                    {
                        encryptedMessage.Append((char)(command[i] + int.Parse(key[index].ToString())));
                        index++;

                        if (index == key.Length)
                        {
                            index = 0;
                        }
                    }

                    result.Add(encryptedMessage.ToString());
                }

                command = Console.ReadLine();
            }

            foreach (var message in result.OrderBy(m => m, StringComparer.Ordinal))
            {
                Console.WriteLine(message);
            }
        }
    }
}
