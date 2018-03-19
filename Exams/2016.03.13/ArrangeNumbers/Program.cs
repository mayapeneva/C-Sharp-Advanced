using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Program
{
    public static void Main()
    {
        var input = Console.ReadLine().Split(new[] { ", " }, StringSplitOptions.RemoveEmptyEntries).ToList();

        var tempList = new List<string>();
        foreach (var number in input)
        {
            if (number.Length == 1)
            {
                tempList.Add(Convert(number));
            }
            else
            {
                var res = new StringBuilder();
                foreach (var item in number)
                {
                    res.Append(Convert(item.ToString()) + '-');
                }

                tempList.Add(res.ToString().Trim('-'));
            }
        }

        tempList.Sort();
        var result = new List<string>();
        for (int j = 0; j < input.Count; j++)
        {
            var number = tempList[j];
            if (!number.Contains('-'))
            {
                result.Add(ConvertBack(number));
            }
            else
            {
                var res = new StringBuilder();
                var tempNumber = number.Split('-');
                foreach (var item in tempNumber)
                {
                    res.Append(ConvertBack(item));
                }

                result.Add(res.ToString());
            }
        }

        Console.WriteLine(string.Join(", ", result));
    }

    private static string ConvertBack(string number)
    {
        switch (number)
        {
            case "zero":
                return "0";

            case "one":
                return "1";

            case "two":
                return "2";

            case "three":
                return "3";

            case "four":
                return "4";

            case "five":
                return "5";

            case "six":
                return "6";

            case "seven":
                return "7";

            case "eight":
                return "8";

            case "nine":
                return "9";
        }

        return null;
    }

    public static string Convert(string number)
    {
        switch (number)
        {
            case "0":
                return "zero";

            case "1":
                return "one";

            case "2":
                return "two";

            case "3":
                return "three";

            case "4":
                return "four";

            case "5":
                return "five";

            case "6":
                return "six";

            case "7":
                return "seven";

            case "8":
                return "eight";

            case "9":
                return "nine";
        }

        return null;
    }
}