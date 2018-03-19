using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public class Program
{
    public static void Main()
    {
        var directory = Console.ReadLine();
        var filesPerExt = new Dictionary<string, List<FileInfo>>();

        var files = Directory.GetFiles(directory);
        foreach (var file in files)
        {
            var fileInfo = new FileInfo(file);
            var extension = fileInfo.Extension;
            if (!filesPerExt.ContainsKey(extension))
            {
                filesPerExt[extension] = new List<FileInfo>();
            }

            filesPerExt[extension].Add(fileInfo);
        }

        var path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        using (var destinationFile = new StreamWriter($"{path}/report.txt"))
        {
            foreach (var kvp in filesPerExt.OrderByDescending(a => a.Value.Count).ThenBy(a => a.Key))
            {
                destinationFile.WriteLine(kvp.Key);
                foreach (var fileInfo in kvp.Value.OrderByDescending(a => a.Length))
                {
                    var fileSize = (double)fileInfo.Length / 1024;
                    destinationFile.WriteLine($"--{fileInfo.Name} - {fileSize:f3}kb");
                }
            }
        }
    }
}