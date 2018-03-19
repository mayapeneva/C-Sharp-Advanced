using System;
using System.Collections.Generic;

namespace EXER_FixEmails
{
    public class FixEmails
    {
        public static void Main()
        {
            var name = Console.ReadLine();
            
            var result = new Dictionary<string, string>();
            while (name != "stop")
            {
                var mail = Console.ReadLine();
                if (!mail.EndsWith("us") && !mail.EndsWith("uk"))
                {
                    result[name] = mail;
                }

                name = Console.ReadLine();
            }

            foreach (var resource in result)
            {
                Console.WriteLine($"{resource.Key} -> {resource.Value}");
            }
        }
    }
}
