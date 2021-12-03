using System;

namespace AdventOfCode
{
    class Day1
    {
        public static void AdventOfCode11()
        {
            var data = ReadFileLogic.CreateArrayFromInputFileName("input1");
            int increased = 0;
            for (int i = 0; i < data.Length - 1; i++)
            {
                if (Convert.ToInt32(data[i]) < Convert.ToInt32(data[i + 1])) increased++;
            }
            Console.WriteLine(increased);
        }
        public static void AdventOfCode12()
        {
            int increased = 0;
            var data = ReadFileLogic.CreateArrayFromInputFileName("input1");
            for (int i = 0; i < data.Length - 3; i++)
            {
                if (Convert.ToInt32(data[i]) + Convert.ToInt32(data[i + 1]) + Convert.ToInt32(data[i + 2])
                   < Convert.ToInt32(data[i + 1]) + Convert.ToInt32(data[i + 2]) + Convert.ToInt32(data[i + 3])) increased++;
            }
            Console.WriteLine(increased);
        }
    }
}
