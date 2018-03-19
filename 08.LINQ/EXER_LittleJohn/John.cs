using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace EXER_LittleJohn
{
    public class John
    {
        public static void Main()
        {
            var regex = new Regex(@">>>----->>|>>----->|>----->");
            var counters = new int[]{0, 0, 0};
            for (int i = 0; i < 4; i++)
            {
                var matches = regex.Matches(Console.ReadLine());

                foreach (Match match in matches)
                {
                    if (match.Value == ">>>----->>")
                    {
                        counters[2] ++;
                    }
                    else if (match.Value == ">>----->")
                    {
                        counters[1] ++;
                    }
                    else
                    {
                        counters[0] ++;
                    }
                }
            }

            var number = counters[0] * 100 + counters[1] * 10 + counters[2];
            var temp = Convert.ToString(number, 2).ToArray();
            var result = temp.Concat(temp.Reverse().ToArray()).ToArray();
            Console.WriteLine(Convert.ToInt32(string.Join("", result), 2).ToString());
        }
    }
}
