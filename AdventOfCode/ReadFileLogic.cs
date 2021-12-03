using System;
using System.IO;
using System.Linq;

namespace AdventOfCode
{
    class ReadFileLogic
    {
        private static readonly string Path = System.IO.Path.GetFullPath(System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\..\\input\\"));
       
        public static string[] CreateArrayFromInputFileName(string inputFileName)
        {
            return File.ReadLines(Path + inputFileName).ToArray();
        }
    }
}
