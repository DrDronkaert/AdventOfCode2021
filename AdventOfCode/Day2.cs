using System;

namespace AdventOfCode
{
    class Day2
    {
        public static void AdventOfCode21()
        {

            var data = ReadFileLogic.CreateArrayFromInputFileName("input2");

            int horizontalPos = 0;
            int depth = 0;

            for (int i = 0; i < data.Length; i++)
            {
                if (data[i].Contains("forward")) horizontalPos += Convert.ToInt32(data[i].Split(' ')[1]);
                if (data[i].Contains("down ")) depth += Convert.ToInt32(data[i].Split(' ')[1]);
                if (data[i].Contains("up")) depth -= Convert.ToInt32(data[i].Split(' ')[1]);

            }
            Console.WriteLine(horizontalPos * depth);
        }
        public static void AdventOfCode22()
        {
            var data = ReadFileLogic.CreateArrayFromInputFileName("input2");

            int horizontalPos = 0;
            int depth = 0;
            int aim = 0;

            for (int i = 0; i < data.Length; i++)
            {
                if (data[i].Contains("forward"))
                {
                    horizontalPos += Convert.ToInt32(data[i].Split(' ')[1]);
                    depth += aim * Convert.ToInt32(data[i].Split(' ')[1]);
                }
                if (data[i].Contains("down ")) aim += Convert.ToInt32(data[i].Split(' ')[1]);
                if (data[i].Contains("up")) aim -= Convert.ToInt32(data[i].Split(' ')[1]);

            }
            Console.WriteLine(horizontalPos * depth);
        }
    }
}
