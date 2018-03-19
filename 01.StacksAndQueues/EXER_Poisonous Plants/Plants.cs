using System;
using System.Collections.Generic;
using System.Linq;

namespace EXER_Poisonous_Plants
{
    public class Plants
    {
        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());
            var input = Console.ReadLine().Split().Select(int.Parse).ToArray();

            var plants = new Stack<int>(input);
            var days = 0;
            while (true)
            {
                var tempPlants = new Stack<int>();
                var plantsCount = plants.Count;
                for (int i = 0; i < plantsCount - 1; i++)
                {
                    var rightPlant = plants.Pop();
                    if (rightPlant <= plants.Peek())
                    {
                        tempPlants.Push(rightPlant);
                    }
                }

                while (tempPlants.Count > 0)
                {
                    plants.Push(tempPlants.Pop());
                }

                if (plantsCount > plants.Count)
                {
                    days++;
                }
                else
                {
                    Console.WriteLine(days);
                    break;
                }
            }
        }
    }
}
