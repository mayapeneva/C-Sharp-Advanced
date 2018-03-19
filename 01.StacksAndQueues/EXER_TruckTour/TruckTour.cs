using System;
using System.Collections.Generic;
using System.Linq;

namespace EXER_TruckTour
{
    public class TruckTour
    {
        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());

            var pumpsQueue = new Queue<string>();
            for (int i = 0; i < n; i++)
            {
                pumpsQueue.Enqueue(Console.ReadLine());
            }

            long tank = 0;
            var index = 0;
            for (int j = 0; j < n; j++)
            {
                var pump = pumpsQueue.Dequeue().Split().Select(int.Parse).ToArray();
                var petrol = pump[0];
                var distance = pump[1];

                tank += petrol;
                if (tank < distance)
                {
                    tank = 0;
                    index = j + 1;
                }
                else
                {
                    tank -= distance;
                }
            }

            Console.WriteLine(index);
        }
    }
}
