using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode
{
    class Day7
    {
        public static void AdventOfCode71()
        {
            var data = ReadFileLogic.CreateArrayFromInputFileName("input7");
            int[] horizontalPos = Array.ConvertAll(data[0].Split(','), int.Parse);
            int[] fuelcosts = new int[horizontalPos.Max()];

            for (int i = 0; i < fuelcosts.Length; i++)
            {
                var fuel = 0;
                for (int x = 0; x < horizontalPos.Length; x++)
                {
                    fuel += Math.Abs(horizontalPos[x] - i);
                }
                fuelcosts[i] = fuel;
            }

            Console.WriteLine(fuelcosts.Min());

        }
        public static void AdventOfCode72()
        {
            var data = ReadFileLogic.CreateArrayFromInputFileName("input7");
            int[] horizontalPos = Array.ConvertAll(data[0].Split(','), int.Parse);
            int[] fuelcosts = new int[horizontalPos.Max()];


            for (int i = 0; i < fuelcosts.Length; i++)
            {
                var fuel = 0;
                for (int x = 0; x < horizontalPos.Length; x++)
                {
                    var steps = Math.Abs(horizontalPos[x] - i);

                    fuel += (steps * (steps + 1)) / 2;

                }
                fuelcosts[i] = fuel;
            }

            Console.WriteLine(fuelcosts.Min());

        }
    }
}
