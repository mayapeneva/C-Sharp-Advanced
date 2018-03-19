using System;
using System.Text;
using System.Text.RegularExpressions;

public class Program
{
    public static void Main()
    {
        var n = int.Parse(Console.ReadLine());
        var cryptoBlockchain = new StringBuilder();
        for (int i = 0; i < n; i++)
        {
            cryptoBlockchain.Append(Console.ReadLine());
        }

        var result = new StringBuilder();

        var regex = new Regex(@"[{][^{}\[\]]*?(\d+)[^{}\[\]]*[}]|[\[][^{}\[\]]*?(\d+)[^{}\[\]]*[\]]");
        var matches = regex.Matches(cryptoBlockchain.ToString());
        foreach (Match match in matches)
        {
            var cryptoBlockTotalLength = match.Length;

            var cryptoBlock = match.Groups[1].Value.Length > 0 ? match.Groups[1].Value : match.Groups[2].Value;
            if (cryptoBlock.Length % 3 != 0)
            {
                continue;
            }

            for (int j = 0; j < cryptoBlock.Length - 2; j += 3)
            {
                var number = int.Parse($"{cryptoBlock[j]}{cryptoBlock[j + 1]}{cryptoBlock[j + 2]}");
                var letter = (char)(number - cryptoBlockTotalLength);
                result.Append(letter);
            }
        }

        Console.WriteLine(result);
    }
}