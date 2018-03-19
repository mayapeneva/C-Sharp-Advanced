using System;
using System.Linq;

namespace LAB_AddVAT
{
    public class VAT
    {
        public static void Main()
        {
            Func<string, double> numberParse = n => double.Parse(n);
            Func<double, double> addVAT = n => n*1.2;
            Action<double> printWord = d => Console.WriteLine($"{d:f2}");

            Console.ReadLine().Split(new[] { ", " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(numberParse)
                .Select(addVAT)
                .ToList()
                .ForEach(printWord);
        }
    }
}
