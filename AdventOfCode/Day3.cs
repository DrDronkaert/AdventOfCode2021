using System;
using System.Linq;

namespace AdventOfCode
{
    class Day3
    {
        public static void AdventOfCode31()
        {
            var data = ReadFileLogic.CreateArrayFromInputFileName("input3");

            int length = data[0].Length;
            string gamma = "";
            string epsilon = "";

            for (int i = 0; i < length; i++)
            {
                if (Zeros(data, i).Length > Ones(data, i).Length)
                {
                    gamma += "0";
                    epsilon += "1";
                }
                else
                {
                    gamma += "1";
                    epsilon += "0";
                }

            }
            Console.WriteLine(Convert.ToInt32(gamma, 2) * Convert.ToInt32(epsilon, 2));
        }
        public static void AdventOfCode32()
        {
            var data = ReadFileLogic.CreateArrayFromInputFileName("input3");

            string ox = FindOxygen(data);
            string co = FindCo(data);

            int oxInt = Convert.ToInt32(ox, 2);
            int coInt = Convert.ToInt32(co, 2);
            Console.WriteLine(oxInt * coInt);

        }

        private static string FindOxygen(string[] data)
        {
            for (int i = 0; i < data[0].Length; i++)
            {
                data = ReturnMostCommonArr(data, i, true);
                if (data.Length == 1) return data[0];
            }
            return data[0];
        }

        private static string FindCo(string[] data)
        {
            for (int i = 0; i < data[0].Length; i++)
            {
                data = ReturnMostCommonArr(data, i, false);
                if (data.Length == 1) return data[0];
            }
            return data[0];
        }


        private static string[] ReturnMostCommonArr(string[] data, int columnIndex, bool isItOxygen)
        {
            if (data.Length == 1) return data;
            var mostRepresentedChar = CheckWhichCharIsRepresentedMost(data, columnIndex);

            if (isItOxygen)
            {
                if (mostRepresentedChar == PossibleOutcomes.Zero) return Zeros(data, columnIndex);
                if (mostRepresentedChar is PossibleOutcomes.One or PossibleOutcomes.Equal) return Ones(data, columnIndex);
            }

            else
            {
                if (mostRepresentedChar == PossibleOutcomes.Zero) return Ones(data, columnIndex);
                if (mostRepresentedChar is PossibleOutcomes.One or PossibleOutcomes.Equal) return Zeros(data, columnIndex);
            }

            return data;
        }

        private static PossibleOutcomes CheckWhichCharIsRepresentedMost(string[] data, int index)
        {
            if (Ones(data, index).Length == Zeros(data, index).Length) return PossibleOutcomes.Equal;
            return Zeros(data, index).Length > Ones(data, index).Length ? PossibleOutcomes.Zero : PossibleOutcomes.One;
        }

        private static string[] Ones(string[] data, int index)
        {
            return data.Where(x => x[index] == '1').ToArray();
        }
        private static string[] Zeros(string[] data, int index)
        {
            return data.Where(x => x[index] == '0').ToArray();
        }

        private enum PossibleOutcomes
        {
            Zero = '0',
            One = '1',
            Equal
        }
    }
}
