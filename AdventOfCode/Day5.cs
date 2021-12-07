using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode
{
    class Day5
    {
        public static void AdventOfCode51()
        {
            var data = ReadFileLogic.CreateArrayFromInputFileName("input5");
            LinesCalculator l = new(data, false);
            l.PrintOverlappingPoints();

        }
        public static void AdventOfCode52()
        {
            var data = ReadFileLogic.CreateArrayFromInputFileName("input5");
            LinesCalculator l = new(data, true);
            l.PrintOverlappingPoints();

        }
    }

    public class LinesCalculator
    {
        public LineSegment[] HorizontalLines { get; set; }
        public LineSegment[] VerticalLines { get; set; }

        public LineSegment[] Alllines { get; set; }

        public List<Vector> AllPointsCoveredByAllLinesUnique { get; set; } = new List<Vector>();

        public int[,] Grid { get; set; } = new int[1000, 1000];

        public Vector[] IntersectingPoints { get; set; }

        public LinesCalculator(string[] data, bool diagonal)
        {
            List<LineSegment> Lines = new();

            if (diagonal)
            {
                for (int i = 0; i < data.Length; i++)
                {
                    var points = data[i].Split(new String[] { " -> " }, StringSplitOptions.RemoveEmptyEntries);
                    var firstXCo = Convert.ToInt32(points[0].Split(',')[0]);
                    var firstYCo = Convert.ToInt32(points[0].Split(',')[1]);

                    var secondXCo = Convert.ToInt32(points[1].Split(',')[0]);
                    var secondYCo = Convert.ToInt32(points[1].Split(',')[1]);

                    Lines.Add(new LineSegment { First = new Vector(firstXCo, firstYCo), Second = new Vector(secondXCo, secondYCo) });

                }


                Alllines = Lines.ToArray();
                return;
            }
            else { 
                    for (int i = 0; i < data.Length; i++)
                    {
                        var points = data[i].Split(new String[] { " -> " }, StringSplitOptions.RemoveEmptyEntries);
                        var firstXCo = Convert.ToInt32(points[0].Split(',')[0]);
                        var firstYCo = Convert.ToInt32(points[0].Split(',')[1]);

                        var secondXCo = Convert.ToInt32(points[1].Split(',')[0]);
                        var secondYCo = Convert.ToInt32(points[1].Split(',')[1]);

                        if (firstXCo == secondXCo || firstYCo == secondYCo) Lines.Add(new LineSegment { First = new Vector(firstXCo, firstYCo), Second = new Vector(secondXCo, secondYCo) });

                    }
            Alllines = Lines.ToArray();
            }

        }
        public void PrintOverlappingPoints()
        {
            FillGridWithOverLappingPoints();
            var counter = 0;
            foreach (var i in Grid)
            {
                if (i > 1) counter++;
            }


            Console.WriteLine(counter);
        }
        private void FillGridWithOverLappingPoints()
        {
            for (int i = 0; i < Alllines.Length; i++)
            {
                AddPointsCoveredByLineSegmentToGrid(Alllines[i]);
            }
        }

        private void AddPointsCoveredByLineSegmentToGrid(LineSegment lineSegment)
        {
            bool vertical = lineSegment.First.X == lineSegment.Second.X;
            bool horizontal = lineSegment.First.Y == lineSegment.Second.Y;

            if (horizontal || vertical)
            {
                if (vertical)
                {
                    if (lineSegment.First.Y > lineSegment.Second.Y)
                    {
                        for (int i = Convert.ToInt32(lineSegment.Second.Y); i <= lineSegment.First.Y; i++)
                        {
                            var v = new Vector(lineSegment.First.X, i);
                            Grid[Convert.ToInt32(v.X), Convert.ToInt32(v.Y)]++;

                        }
                    }
                    else
                    {
                        for (int i = Convert.ToInt32(lineSegment.First.Y); i <= lineSegment.Second.Y; i++)
                        {
                            var v = new Vector(lineSegment.First.X, i);
                            Grid[Convert.ToInt32(v.X), Convert.ToInt32(v.Y)]++;

                        }
                    }
                }
                if (horizontal)
                {
                    if (lineSegment.First.X > lineSegment.Second.X)
                    {
                        for (int i = Convert.ToInt32(lineSegment.Second.X); i <= lineSegment.First.X; i++)
                        {

                            var v = new Vector(i, lineSegment.First.Y);
                            Grid[Convert.ToInt32(v.X), Convert.ToInt32(v.Y)]++;

                        }
                    }
                    else
                    {
                        for (int i = Convert.ToInt32(lineSegment.First.X); i <= lineSegment.Second.X; i++)
                        {
                            var v = new Vector(i, lineSegment.Second.Y);
                            Grid[Convert.ToInt32(v.X), Convert.ToInt32(v.Y)]++;

                        }
                    }
                }
            }
           else {
                int length = Math.Abs(Convert.ToInt32(lineSegment.First.X) - Convert.ToInt32(lineSegment.Second.X)) + 1;
                int xDirection = lineSegment.First.X < lineSegment.Second.X ? 1 : -1;
                int yDirection = lineSegment.First.Y < lineSegment.Second.Y ? 1 : -1;

                for (int i = 0; i < length; i++)
                {
                    var v = new Vector(lineSegment.First.X + i * xDirection, lineSegment.First.Y + i * yDirection);
                    Grid[Convert.ToInt32(v.X), Convert.ToInt32(v.Y)]++;

                }

            }
        }

       

    }

    public class LineSegment
    {
        public Vector First { get; set; }
        public Vector Second { get; set; }

    }



    public class Vector 
    {
        public int X;
        public int Y;

        public Vector(int x, int y) { X = x; Y = y; }

       
    }
  
}


