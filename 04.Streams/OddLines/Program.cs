using System;
using System.IO;

public class Program
{
    public static void Main()
    {
        using (var streamReader = new StreamReader("../../../text.txt"))
        {
            var counter = 0;
            string line;
            while ((line = streamReader.ReadLine()) != null)
            {
                if (counter % 2 != 0)
                {
                    Console.WriteLine(line);
                }

                counter++;
            }
        }
    }
}