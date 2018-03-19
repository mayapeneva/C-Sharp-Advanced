using System;
using System.Collections.Generic;

namespace EXER_UniqueUsernames
{
    public class Usernames
    {
        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());

            var result = new HashSet<string>();
            for (int i = 0; i < n; i++)
            {
                result.Add(Console.ReadLine());
            }

            foreach (var user in result)
            {
                Console.WriteLine(user);   
            }
        }
    }
}
