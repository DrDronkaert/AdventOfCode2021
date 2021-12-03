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
        public static void AdventOfCode11()
        {
            string fileName = @"C:\speeltuin\Speeltuin\Speeltuin\bin\input1";
            int increased = 0;
            IEnumerable<string> lines = File.ReadLines(fileName);
            for (int i =1;i <lines.Count(); i++)
            {
                if (Convert.ToInt32(lines.ElementAt(i)) > Convert.ToInt32(lines.ElementAt(i-1))) increased++;
            }
            Console.WriteLine(increased);
        }
        public static void AdventOfCode12()
        {
            string fileName = @"C:\speeltuin\Speeltuin\Speeltuin\bin\input1";
            int increased = 0;
            IEnumerable<string> lines = File.ReadLines(fileName);
            for (int i = 0; i < lines.Count()-3; i++)
            {
                if (Convert.ToInt32(lines.ElementAt(i)) + Convert.ToInt32(lines.ElementAt(i+1)) + Convert.ToInt32(lines.ElementAt(i + 2))
                   < Convert.ToInt32(lines.ElementAt(i + 1)) + Convert.ToInt32(lines.ElementAt(i + 2)) + Convert.ToInt32(lines.ElementAt(i + 3))) increased++;
            }
            Console.WriteLine(increased);
        }
        public static void AdventOfCode21()
        {
            string fileName = @"C:\speeltuin\Speeltuin\Speeltuin\bin\input2";
            int horizontalPos = 0;
            int depth = 0;

            IEnumerable<string> lines = File.ReadLines(fileName);
            for (int i = 0; i < lines.Count(); i++)
            {
                var test = Convert.ToInt32(Regex.Match(lines.ElementAt(i), @"\d+").Value);
                if (lines.ElementAt(i).Contains("forward")) horizontalPos += Convert.ToInt32(Regex.Match(lines.ElementAt(i), @"\d+").Value);
                if (lines.ElementAt(i).Contains("down ")) depth += Convert.ToInt32(Regex.Match(lines.ElementAt(i), @"\d+").Value);
                if (lines.ElementAt(i).Contains("up")) depth -= Convert.ToInt32(Regex.Match(lines.ElementAt(i), @"\d+").Value);

            }
            Console.WriteLine(horizontalPos * depth);
        }
        public static void AdventOfCode22()
        {
            string fileName = @"C:\speeltuin\Speeltuin\Speeltuin\bin\input2";
            int horizontalPos = 0;
            int depth = 0;
            int aim = 0;

            IEnumerable<string> lines = File.ReadLines(fileName);
            for (int i = 0; i < lines.Count(); i++)
            {
                var test = Convert.ToInt32(Regex.Match(lines.ElementAt(i), @"\d+").Value);
                if (lines.ElementAt(i).Contains("forward")) 
                { 
                    horizontalPos += Convert.ToInt32(Regex.Match(lines.ElementAt(i), @"\d+").Value);
                    depth += aim * Convert.ToInt32(Regex.Match(lines.ElementAt(i), @"\d+").Value); 
                }
                if (lines.ElementAt(i).Contains("down ")) aim += Convert.ToInt32(Regex.Match(lines.ElementAt(i), @"\d+").Value);
                if (lines.ElementAt(i).Contains("up")) aim -= Convert.ToInt32(Regex.Match(lines.ElementAt(i), @"\d+").Value);

            }
            Console.WriteLine(horizontalPos * depth);
        }
        public static void AdventOfCode31()
        {
            string fileName = @"C:\speeltuin\Speeltuin\Speeltuin\bin\input3";
            IEnumerable<string> lines = File.ReadLines(fileName);

            int length = lines.ElementAt(1).Length;
            string gamma = "";
            string epsilon = "";

            for (int i = 0; i < length; i++)
            {
                List<int> zeroes = new List<int>();
                List<int> ones = new List<int>();

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
            string fileName = @"C:\speeltuin\Speeltuin\Speeltuin\bin\input3";
            var oxArr = File.ReadLines(fileName).ToArray();
            var coArr = File.ReadLines(fileName).ToArray();

            int length = oxArr[1].Length;

            string ox = "";
            string co = "";

            for (int i = 0; i < length; i++)
            {
                List<string> zeroes = new();
                List<string> ones = new();

                for (int x= 0; x < oxArr.Length; x++)
                {
                    if (oxArr[x][i] == '0') zeroes.Add(oxArr[x]);
                    if (oxArr[x][i] == '1') ones.Add(oxArr[x]);
                }

                if (zeroes.Count > ones.Count) oxArr = zeroes.ToArray();
                if (ones.Count > zeroes.Count) oxArr = ones.ToArray();
                if (ones.Count == zeroes.Count) oxArr = ones.ToArray();
                if (oxArr.Length == 1) ox = oxArr[0];


            }

            for (int i = 0; i < length; i++)
            {
                List<string> zeroes = new();
                List<string> ones = new();

                for (int x = 0; x < coArr.Length; x++)
                {
                    if (coArr[x][i] == '0') zeroes.Add(coArr[x]);
                    if (coArr[x][i] == '1') ones.Add(coArr[x]);
                }

                if (zeroes.Count > ones.Count) coArr = ones.ToArray();
                if (ones.Count > zeroes.Count) coArr = zeroes.ToArray();
                if (ones.Count == zeroes.Count && zeroes.Count!=0) coArr = zeroes.ToArray();
                if (coArr.Length == 1) co = coArr[0];


            }

            int oxInt = Convert.ToInt32(ox, 2);
            int coInt = Convert.ToInt32(co, 2);
            Console.WriteLine(oxInt * coInt);

        }
    }
}
