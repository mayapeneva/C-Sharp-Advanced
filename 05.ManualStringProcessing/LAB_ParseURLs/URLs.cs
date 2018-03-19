using System;
using System.Linq;

namespace LAB_ParseURLs
{
    public class URLs
    {
        public static void Main()
        {
            var url = Console.ReadLine().Split(new[] {"://"}, StringSplitOptions.RemoveEmptyEntries);

            if (url.Length != 2 || !url[1].Contains('/'))
            {
                Console.WriteLine("Invalid URL");
            }
            else
            {
                var protocol = url[0];
                var index = url[1].IndexOf('/');
                var server = url[1].Substring(0, index);
                var resources = url[1].Substring(index + 1);

                Console.WriteLine($"Protocol = {protocol}");
                Console.WriteLine($"Server = {server}");
                Console.WriteLine($"Resources = {resources}");
            }
        }
    }
}
