using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode
{
    class Day6
    {
        public static void AdventOfCode61()
        {
            var data = ReadFileLogic.CreateArrayFromInputFileName("input6");
            var fishTimers = Array.ConvertAll(data[0].Split(','), int.Parse);
            CalcFishies(80, fishTimers);



        }
        public static void AdventOfCode62()
        {
            var data = ReadFileLogic.CreateArrayFromInputFileName("input6");
            var fishTimers = Array.ConvertAll(data[0].Split(','), int.Parse);
            CalcFishies(256, fishTimers);
        }

        private static void CalcFishies(int days, int[] data)
        {
            IDictionary<int, ulong> numberOfFishesForEachTimer = new Dictionary<int, ulong>();

            for (int x = 0; x <= 8; x++)
            {
                numberOfFishesForEachTimer[x] = 0;
            }

            foreach (int i in data)
            {
                numberOfFishesForEachTimer[i]++;
            }

            for (int i = 0; i < days; i++)
            {
                ulong newFishesToAddAtTheEndOfTheDay = 0;
                if (numberOfFishesForEachTimer[0] != 0)
                {
                    newFishesToAddAtTheEndOfTheDay = numberOfFishesForEachTimer[0];

                }

                for (int x = 0; x <= 7; x++)
                {
                    numberOfFishesForEachTimer[x] = numberOfFishesForEachTimer[x + 1];
                }

                numberOfFishesForEachTimer[8] = 0;
                if (newFishesToAddAtTheEndOfTheDay != 0)
                {
                    numberOfFishesForEachTimer[6] += newFishesToAddAtTheEndOfTheDay;
                    numberOfFishesForEachTimer[8] += newFishesToAddAtTheEndOfTheDay;
                }

            }
            ulong totalFishes = 0;
            foreach (var entry in numberOfFishesForEachTimer)
            {
                totalFishes += entry.Value;
            }
            Console.WriteLine(totalFishes);
        }


    }



}
