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
            for (int x = 0; x <= 8; x++)
            {
                numberOfFishesForEachTimer[x] = 0;
            }
      
            foreach (int i in fishTimers)
            {
                 numberOfFishesForEachTimer[i]++;
            }

            for (int i = 0; i < 256; i++)
            {
                ulong newFishesToAddAtTheEndOfTheDay = 0 ;
                if (numberOfFishesForEachTimer[0] != 0)
                {
                    newFishesToAddAtTheEndOfTheDay = numberOfFishesForEachTimer[0];

                }

                for (int x=0; x <=7; x++)
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
    public class LanternFish
    {
        public int Timer { get; set; }

        public LanternFish(int timer)
        {
            this.Timer = timer;
        
        }

      
    }
    public class School
    {
        public List<LanternFish> SchoolOfLanternFish { get; set; }
        public void SpawnNew()
        {
            SchoolOfLanternFish.Add(new LanternFish(8));

        }

        internal void ADayPasses()
        {
            int newFish = 0;
            for (int i = 0; i < SchoolOfLanternFish.Count(); i++)
            {
               
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
                SchoolOfLanternFish.Add(new LanternFish(fishTimers[i]));
            }
        }
    }
}
