using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public class Program
{
    public static void Main()
    {
        using (var streamWriter = new StreamWriter("../../result.txt"))
        {
            string line;
            var text = new List<string>();
            var result = new Dictionary<int, List<string>>();
            using (var wordsReader = new StreamReader("../../../words.txt"))
            {
                using (var textReader = new StreamReader("../../../text.txt"))
                {
                    while ((line = textReader.ReadLine()) != null)
                    {
                        text.Add(line);
                    }
                }

                string word;
                while ((word = wordsReader.ReadLine()) != null)
                {
                    var counter = 0;
                    foreach (var li in text)
                    {
                        counter += li.Split(new[] { '-', ',', '.', '?', '!', ' ' }, StringSplitOptions.RemoveEmptyEntries).Count(w => w.Equals(word, StringComparison.OrdinalIgnoreCase));
                    }

                    if (!result.ContainsKey(counter))
                    {
                        result[counter] = new List<string>();
                    }

                    result[counter].Add(word);
                }
            }

            foreach (var item in result.OrderByDescending(a => a.Key))
            {
                foreach (var w in item.Value)
                {
                    streamWriter.WriteLine($"{w} - {item.Key}");
                }
            }
        }
    }
}