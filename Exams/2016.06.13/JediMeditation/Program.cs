using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Program
{
    public static void Main()
    {
        var masters = new Queue<string>();
        var knights = new Queue<string>();
        var padawans = new Queue<string>();
        var tAndS = new Queue<string>();
        var isThereAYoda = false;

        var n = int.Parse(Console.ReadLine());
        for (int i = 0; i < n; i++)
        {
            var jedis = Console.ReadLine().Split().ToList();
            foreach (var jeda in jedis)
            {
                switch (jeda[0])
                {
                    case 'm':
                        masters.Enqueue(jeda + ' ');
                        break;

                    case 'k':
                        knights.Enqueue(jeda + ' ');
                        break;

                    case 'p':
                        padawans.Enqueue(jeda + ' ');
                        break;

                    case 't':
                        tAndS.Enqueue(jeda + ' ');
                        break;

                    case 's':
                        tAndS.Enqueue(jeda + ' ');
                        break;

                    case 'y':
                        isThereAYoda = true;
                        break;
                }
            }
        }

        var result = new StringBuilder();
        if (isThereAYoda)
        {
            result.Append(string.Join("", masters));
            result.Append(string.Join("", knights));
            result.Append(string.Join("", tAndS));
            result.Append(string.Join("", padawans));
        }
        else
        {
            result.Append(string.Join("", tAndS));
            result.Append(string.Join("", masters));
            result.Append(string.Join("", knights));
            result.Append(string.Join("", padawans));
        }

        Console.WriteLine(result.ToString().Trim());
    }
}