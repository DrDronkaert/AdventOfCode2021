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
            LinesCalculator l = new(data);
        }
    }

    public class LinesCalculator
    {
        public LineSegment[] HorizontalLines { get; set; }
        public LineSegment[] VerticalLines { get; set; }

        public LineSegment[] Alllines { get; set; }

        public Vector[] AllPointsCoveredByAllLines { get; set; }

        public Vector[] IntersectingPoints { get; set; }

        public LinesCalculator(string[] data)
        {
            List<LineSegment> Lines = new();


            for (int i = 0; i < data.Length; i++)
            {
                var points = data[i].Split(new String[] { " -> " }, StringSplitOptions.RemoveEmptyEntries);
                var firstXCo = Convert.ToDouble(points[0].Split(',')[0]);
                var firstYCo = Convert.ToDouble(points[0].Split(',')[1]);

                var secondXCo = Convert.ToDouble(points[1].Split(',')[0]);
                var secondYCo = Convert.ToDouble(points[1].Split(',')[1]);

                if (firstXCo == secondXCo || firstYCo == secondYCo) Lines.Add(new LineSegment { First = new Vector(firstXCo, firstYCo), Second = new Vector(secondXCo, secondYCo) });

            }


            Alllines = Lines.ToArray();
            this.FillAllPointsCoveredByAllLines();
            this.FillOccurenceOfAllPoints();
        }

        private void FillOccurenceOfAllPoints()
        {
            var distinctPoints = AllPointsCoveredByAllLines.Distinct().ToArray();

           foreach (Vector point in distinctPoints)
            {
                point.Occurence = AllPointsCoveredByAllLines.Where(x => x.Equals(point)).Count();
            }

          
            Console.WriteLine(distinctPoints.Where(x => x.Occurence >= 2).Count());
        }

        private void FillAllPointsCoveredByAllLines()
        {
            List<Vector> points = new List<Vector>();
            for (int i =0; i< Alllines.Length; i++)
            {
               points = points.Concat(CalculatePointsCoveredByLine(Alllines[i])).ToList();
            }
            this.AllPointsCoveredByAllLines = points.ToArray();
        }

        private Vector[] CalculatePointsCoveredByLine(LineSegment lineSegment)
        {
            List<Vector> points = new List<Vector>();
            if (lineSegment.First.X == lineSegment.Second.X)
            {
                if (lineSegment.First.Y > lineSegment.Second.Y)
                {
                    for (int i = Convert.ToInt32( lineSegment.Second.Y); i <= lineSegment.First.Y; i++)
                    {
                        points.Add(new Vector(lineSegment.First.X, i));
                    }
                }
                else
                {
                    for (int i = Convert.ToInt32(lineSegment.First.Y); i <= lineSegment.Second.Y; i++)
                    {
                        points.Add(new Vector(lineSegment.First.X, i));
                    }
                }
            }
            if (lineSegment.First.Y == lineSegment.Second.Y)
            {
                if (lineSegment.First.X > lineSegment.Second.X)
                {
                    for (int i = Convert.ToInt32(lineSegment.Second.X); i <= lineSegment.First.X; i++)
                    {
                        points.Add(new Vector( i, lineSegment.First.Y));
                    }
                }
                else
                {
                    for (int i = Convert.ToInt32(lineSegment.First.X); i <= lineSegment.Second.X; i++)
                    {
                        points.Add(new Vector(i, lineSegment.Second.Y));
                    }
                }
            }
            return points.ToArray();
        }

        

    }

    public class LineSegment
    {
        public Vector First { get; set; }
        public Vector Second { get; set; }

    }



    public class Vector : IEquatable<Vector>
    {
        public double X;
        public double Y;
        public int Occurence;

        public Vector(double x, double y, int occurence) { X = x; Y = y; Occurence = occurence; }
        public Vector(double x, double y) { X = x; Y = y; }

        public override int GetHashCode()
        {
            return (X + Y).GetHashCode();
        }

        public bool Equals(Vector other)
        {
            var v = (Vector)other;
            return (X - v.X).IsZero() && (Y - v.Y).IsZero();
        }
    }
    public static class Extensions
    {
        private const double Epsilon = 1e-10;

        public static bool IsZero(this double d)
        {
            return Math.Abs(d) < Epsilon;
        }
    }
}


