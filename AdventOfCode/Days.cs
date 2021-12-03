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
        private static readonly string Path = System.IO.Path.GetFullPath(System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\..\\input\\"));

        public static void AdventOfCode11()
        {
            string fileName = Path + "input1";
            int increased = 0;
            var lines = File.ReadLines(fileName).ToArray();
            for (int i =0;i < lines.Length-1; i++)
            {
                if (Convert.ToInt32(lines[i]) < Convert.ToInt32(lines[i+1])) increased++;
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
                var zeroes = lines.Where(x => x[i] == '0').ToArray();
                var ones = lines.Where(x => x[i] == '1').ToArray();
                if (zeroes.Length > ones.Length)
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
            var data = File.ReadLines(fileName).ToArray();

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
                data = returnMostCommonArr(data, i, true);
                if (data.Length == 1) return data[0];
            }
            return data[0];
        }

        private static string FindCo(string[] data)
        {
            for (int i = 0; i < data[0].Length; i++)
            {
                data = returnMostCommonArr(data, i, false);
                if (data.Length == 1) return data[0];
            }
            return data[0];
        }


        private static string[] returnMostCommonArr(string[] lines, int columnIndex, bool isItOxygen)
        {
            if (lines.Length == 1) return lines ;
            var zeroes = lines.Where(x => x[columnIndex] == '0').ToArray();
            var ones = lines.Where(x => x[columnIndex] == '1').ToArray();
            if (isItOxygen)
            {
                if (zeroes.Length > ones.Length) return zeroes;
                if (ones.Length > zeroes.Length || ones.Length == zeroes.Length) return ones;
            }

            else
            {
                if (zeroes.Length > ones.Length) return ones;
                if (ones.Length > zeroes.Length || ones.Length == zeroes.Length) return zeroes;
            }
            

            return lines;
        }

    }
}
