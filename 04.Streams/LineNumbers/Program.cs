﻿using System.IO;

public class Program
{
    public static void Main()
    {
        using (var streamReader = new StreamReader("../../../text.txt"))
        {
            using (var streamWriter = new StreamWriter("../../result.txt"))
            {
                var counter = 1;
                string line;
                while ((line = streamReader.ReadLine()) != null)
                {
                    streamWriter.WriteLine($"Line {counter}: {line}");
                    counter++;
                }
            }
        }
    }
}