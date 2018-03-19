using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;

public class Program
{
    private static List<string> files = new List<string>();
    private const int bufferSize = 4096;

    public static void Main()
    {
        string source = "../../../sliceMe.mp4";
        string destination = "../../ result";
        var n = int.Parse(Console.ReadLine());

        Slice(source, destination, n);

        Assemble(files, destination);

        Zip(source, destination, n);
    }

    private static void Slice(string source, string destination, int n)
    {
        using (var sourceFile = new FileStream(source, FileMode.Open))
        {
            long fileSize = (long)Math.Ceiling((double)sourceFile.Length / n);
            var extension = source.Substring(source.LastIndexOf('.'));

            for (int i = 0; i < n; i++)
            {
                long currentFileSize = 0;
                destination = destination == string.Empty ? "./" : destination;
                var dest = $"{destination}_{i}{extension}";
                files.Add(dest);

                using (var destinationFile = new FileStream(dest, FileMode.Create))
                {
                    var buffer = new byte[bufferSize];
                    while (sourceFile.Read(buffer, 0, bufferSize) == bufferSize)
                    {
                        destinationFile.Write(buffer, 0, bufferSize);
                        currentFileSize += bufferSize;
                        if (currentFileSize >= fileSize)
                        {
                            break;
                        }
                    }
                }
            }
        }
    }

    private static void Assemble(List<string> list, string destination)
    {
        var extension = files[0].Substring(files[0].LastIndexOf('.'));
        destination = destination == string.Empty ? "./" : destination;
        var dest = $"{destination}{extension}";
        using (var destinationFile = new FileStream(dest, FileMode.Create))
        {
            var buffer = new byte[bufferSize];
            foreach (var file in files)
            {
                using (var sourceFile = new FileStream(file, FileMode.Open))
                {
                    while (sourceFile.Read(buffer, 0, bufferSize) == bufferSize)
                    {
                        destinationFile.Write(buffer, 0, bufferSize);
                    }
                }
            }
        }
    }

    private static void Zip(string source, string destination, int n
        )
    {
        using (var sourceFile = new FileStream(source, FileMode.Open))
        {
            long fileSize = (long)Math.Ceiling((double)sourceFile.Length / n);
            var extension = source.Substring(source.LastIndexOf('.'));

            for (int i = 0; i < n; i++)
            {
                long currentFileSize = 0;
                destination = destination == string.Empty ? "./" : destination;
                var dest = $"{destination}_{i}{extension}.gz";
                files.Add(dest);

                using (var destinationFile = new GZipStream(new FileStream(dest, FileMode.Create), CompressionLevel.Optimal))
                {
                    var buffer = new byte[bufferSize];
                    while (sourceFile.Read(buffer, 0, bufferSize) == bufferSize)
                    {
                        destinationFile.Write(buffer, 0, bufferSize);
                        currentFileSize += bufferSize;
                        if (currentFileSize >= fileSize)
                        {
                            break;
                        }
                    }
                }
            }
        }
    }
}