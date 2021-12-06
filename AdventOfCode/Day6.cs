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
            var school = new School(data[0]);
            for (int i = 0; i < 80; i++)
            {
                school.ADayPasses();
            }
            Console.WriteLine(school.SchoolOfLanternFish.Count());
           
            
        }
        public static void AdventOfCode62()
        {
            var data = ReadFileLogic.CreateArrayFromInputFileName("input6");
            var fishTimers = Array.ConvertAll(data[0].Split(','), int.Parse);
            IDictionary<int, ulong> numberOfFishesForEachTimer = new Dictionary<int, ulong>();
            numberOfFishesForEachTimer[0] = 0;
            numberOfFishesForEachTimer[1] = 0;
            numberOfFishesForEachTimer[2] = 0;
            numberOfFishesForEachTimer[3] = 0;
            numberOfFishesForEachTimer[4] = 0;
            numberOfFishesForEachTimer[5] = 0;
            numberOfFishesForEachTimer[6] = 0;
            numberOfFishesForEachTimer[7] = 0;
            numberOfFishesForEachTimer[8] = 0;
            foreach (int i in fishTimers)
            {
                if (numberOfFishesForEachTimer.ContainsKey(i))
                {
                    numberOfFishesForEachTimer[i]++;
                }
                else
                {
                    numberOfFishesForEachTimer.Add(i, 1);
                }
            }

            for (int i = 0; i < 256; i++)
            {
                ulong temp = 0 ;
                if (numberOfFishesForEachTimer[0] != 0)
                {
                    temp = numberOfFishesForEachTimer[0];

                }

                numberOfFishesForEachTimer[0] = numberOfFishesForEachTimer[1];
                numberOfFishesForEachTimer[1] = numberOfFishesForEachTimer[2];
                numberOfFishesForEachTimer[2] = numberOfFishesForEachTimer[3];
                numberOfFishesForEachTimer[3] = numberOfFishesForEachTimer[4];
                numberOfFishesForEachTimer[4] = numberOfFishesForEachTimer[5];
                numberOfFishesForEachTimer[5] = numberOfFishesForEachTimer[6];
                numberOfFishesForEachTimer[6] = numberOfFishesForEachTimer[7];
                numberOfFishesForEachTimer[7] = numberOfFishesForEachTimer[8];
                numberOfFishesForEachTimer[8] = 0;
                if (temp == 0)
                {
                    continue;
                }
                else
                {
                    numberOfFishesForEachTimer[6] += temp;
                    numberOfFishesForEachTimer[8] += temp;
                }
              


            }
            var test = numberOfFishesForEachTimer;
            ulong t = 0;
            foreach(var entry in numberOfFishesForEachTimer)
            {
                t += entry.Value;
            }
            Console.WriteLine(t);
        }
    }
    public class LanternFish
    {
        public int Timer { get; set; }
        public bool JustBorn { get; set; }

        public LanternFish(int timer, bool justBorn)
        {
            this.Timer = timer;
            this.JustBorn = JustBorn;
        }

      
    }
    public class School
    {
        public List<LanternFish> SchoolOfLanternFish { get; set; }
        public void SpawnNew()
        {
            SchoolOfLanternFish.Add(new LanternFish(8,true));

        }

        internal void ADayPasses()
        {
            int newFish = 0;
            for (int i = 0; i < SchoolOfLanternFish.Count(); i++)
            {
                if (SchoolOfLanternFish[i].Timer == 8 && SchoolOfLanternFish[i].JustBorn == true )
                {
                    SchoolOfLanternFish[i].JustBorn = false;
                    continue;
                }
                if (SchoolOfLanternFish[i].Timer > 0)
                {
                    SchoolOfLanternFish[i].Timer--;
                }
                else
                {
                    SchoolOfLanternFish[i].Timer = 6;
                    newFish++;
                }
            }
            for (int x = 0; x < newFish; x++)
            {
                SpawnNew();
            }
            
        }

        public School(string data)
        {
            SchoolOfLanternFish = new List<LanternFish>();
            var fishTimers = Array.ConvertAll( data.Split(','), int.Parse);
            for (int i = 0; i < fishTimers.Length; i++)
            {
                SchoolOfLanternFish.Add(new LanternFish(fishTimers[i], false));
            }
        }
    }
}
