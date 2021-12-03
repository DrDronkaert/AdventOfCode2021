using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AdventOfCode
{
    class Days

    {
        private const string Path = @"C:\sandbox\AdventOfCode\AdventOfCode\bin\";

        public static void AdventOfCode11()
        {
            string fileName = Path + "input1";
            int increased = 0;
            var lines = File.ReadLines(fileName).ToArray();
            for (int i =1;i < lines.Length; i++)
            {
                if (Convert.ToInt32(lines[i]) > Convert.ToInt32(lines[i-1])) increased++;
            }
            Console.WriteLine(increased);
        }
        public static void AdventOfCode12()
        {
            string fileName = Path + "input1";
            int increased = 0;
            var lines = File.ReadLines(fileName).ToArray();
            for (int i = 0; i < lines.Length - 3; i++)
            {
                if (Convert.ToInt32(lines[i]) + Convert.ToInt32(lines[i+1]) + Convert.ToInt32(lines[i+2])
                   < Convert.ToInt32(lines[i+1]) + Convert.ToInt32(lines[i+2]) + Convert.ToInt32(lines[i+3])) increased++;
            }
            Console.WriteLine(increased);
        }
        public static void AdventOfCode21()
        {
            string fileName = Path + "input2";
            int horizontalPos = 0;
            int depth = 0;

            var lines = File.ReadLines(fileName).ToArray();
            for (int i = 0; i < lines.Length; i++)
            {
                if (lines[i].Contains("forward")) horizontalPos += Convert.ToInt32(Regex.Match(lines[i], @"\d+").Value);
                if (lines[i].Contains("down ")) depth += Convert.ToInt32(Regex.Match(lines[i], @"\d+").Value);
                if (lines[i].Contains("up")) depth -= Convert.ToInt32(Regex.Match(lines[i], @"\d+").Value);

            }
            Console.WriteLine(horizontalPos * depth);
        }
        public static void AdventOfCode22()
        {
            string fileName = Path + "input2";
            int horizontalPos = 0;
            int depth = 0;
            int aim = 0;

            var lines = File.ReadLines(fileName).ToArray();
            for (int i = 0; i < lines.Length; i++)
            {
                if (lines[i].Contains("forward")) 
                { 
                    horizontalPos += Convert.ToInt32(Regex.Match(lines[i], @"\d+").Value);
                    depth += aim * Convert.ToInt32(Regex.Match(lines[i], @"\d+").Value); 
                }
                if (lines[i].Contains("down ")) aim += Convert.ToInt32(Regex.Match(lines[i], @"\d+").Value);
                if (lines[i].Contains("up")) aim -= Convert.ToInt32(Regex.Match(lines[i], @"\d+").Value);

            }
            Console.WriteLine(horizontalPos * depth);
        }
        public static void AdventOfCode31()
        {
            string fileName = Path + "input3";
            var lines = File.ReadLines(fileName).ToArray();

            int length =lines[0].Length;
            string gamma = "";
            string epsilon = "";

            for (int i = 0; i < length; i++)
            {
                List<int> zeroes = new();
                List<int> ones = new();

                foreach (var line in lines)
                {
                    if (line[i] == '0') zeroes.Add(0);
                    if (line[i] == '1') ones.Add(1);

                }
                if (zeroes.Count > ones.Count)
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
            string fileName = Path + "input3";
            var oxArr = File.ReadLines(fileName).ToArray();
            var coArr = File.ReadLines(fileName).ToArray();

            string ox = "";
            string co = "";

            for (int i = 0; i < oxArr[0].Length; i++)
            {
             oxArr = returnMostCommonArr(oxArr, i,true);
             coArr = returnMostCommonArr(coArr, i, false);
             if (coArr.Length == 1) co = coArr[0];
             if (oxArr.Length == 1) ox = oxArr[0];
            }


            int oxInt = Convert.ToInt32(ox, 2);
            int coInt = Convert.ToInt32(co, 2);
            Console.WriteLine(oxInt * coInt);

        }

        private static string[] returnMostCommonArr(string[] lines, int i, bool isItOxygen)
        {
            if (lines.Length == 1) return lines ;
            var zeroes = lines.Where(x => x[i] == '0').ToArray();
            var ones = lines.Where(x => x[i] == '1').ToArray();
            if (isItOxygen)
            {
                if (zeroes.Length > ones.Length) lines = zeroes;
                if (ones.Length > zeroes.Length || ones.Length == zeroes.Length) lines = ones;
            }

            else
            {
                if (zeroes.Length > ones.Length) lines = ones;
                if (ones.Length > zeroes.Length || ones.Length == zeroes.Length) lines = zeroes;
            }
            

            return lines;

        }
    }
}
