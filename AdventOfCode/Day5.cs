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
            l.PrintOccurenceOfHorizontalAndVerticalPoints();

        }
        public static void AdventOfCode52()
        {
            var data = ReadFileLogic.CreateArrayFromInputFileName("input5");
            LinesCalculator l = new(data, true);
            l.PrintOccurenceOfHorizontalAndVerticalAndDiagonalPoints();

        }
    }

    public class LinesCalculator
    {
        public LineSegment[] HorizontalLines { get; set; }
        public LineSegment[] VerticalLines { get; set; }

        public LineSegment[] Alllines { get; set; }

        public List<Vector> AllPointsCoveredByAllLinesUnique { get; set; } = new List<Vector>();

        public Vector[] IntersectingPoints { get; set; }

        public LinesCalculator(string[] data, bool diagonal)
        {
            List<LineSegment> Lines = new();

            if (diagonal)
            {
                for (int i = 0; i < data.Length; i++)
                {
                    var points = data[i].Split(new String[] { " -> " }, StringSplitOptions.RemoveEmptyEntries);
                    var firstXCo = Convert.ToDouble(points[0].Split(',')[0]);
                    var firstYCo = Convert.ToDouble(points[0].Split(',')[1]);

                    var secondXCo = Convert.ToDouble(points[1].Split(',')[0]);
                    var secondYCo = Convert.ToDouble(points[1].Split(',')[1]);

                    Lines.Add(new LineSegment { First = new Vector(firstXCo, firstYCo), Second = new Vector(secondXCo, secondYCo) });

                }


                Alllines = Lines.ToArray();
                return;
            }
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

        }

        private void FillAllPointsCoveredByHorizontalAndVerticalAndDiagonalLines()
        {
            List<Vector> points = new List<Vector>();
            for (int i = 0; i < Alllines.Length; i++)
            {
                CalculatePointsCoveredByHorizontalAndVerticalAndDiagonalLine(Alllines[i]);
            }
        }

        private void CalculatePointsCoveredByHorizontalAndVerticalAndDiagonalLine(LineSegment lineSegment)
        {
            if (lineSegment.First.X == lineSegment.Second.X || lineSegment.First.Y == lineSegment.Second.Y)
            {
                if (lineSegment.First.X == lineSegment.Second.X)
                {
                    if (lineSegment.First.Y > lineSegment.Second.Y)
                    {
                        for (int i = Convert.ToInt32(lineSegment.Second.Y); i <= lineSegment.First.Y; i++)
                        {
                            var v = new Vector(lineSegment.First.X, i, 1);
                            if (AllPointsCoveredByAllLinesUnique.Contains(v))
                            {
                                AllPointsCoveredByAllLinesUnique.Find(x => x.Equals(v)).Occurence++;
                            }
                            else
                            {

                                AllPointsCoveredByAllLinesUnique.Add(v);
                            }
                        }
                    }
                    else
                    {
                        for (int i = Convert.ToInt32(lineSegment.First.Y); i <= lineSegment.Second.Y; i++)
                        {
                            var v = new Vector(lineSegment.First.X, i, 1);
                            if (AllPointsCoveredByAllLinesUnique.Contains(v))
                            {
                                AllPointsCoveredByAllLinesUnique.Find(x => x.Equals(v)).Occurence++;
                            }
                            else
                            {

                                AllPointsCoveredByAllLinesUnique.Add(v);
                            }
                        }
                    }
                }
                if (lineSegment.First.Y == lineSegment.Second.Y)
                {
                    if (lineSegment.First.X > lineSegment.Second.X)
                    {
                        for (int i = Convert.ToInt32(lineSegment.Second.X); i <= lineSegment.First.X; i++)
                        {

                            var v = new Vector(i, lineSegment.First.Y, 1);
                            if (AllPointsCoveredByAllLinesUnique.Contains(v))
                            {
                                AllPointsCoveredByAllLinesUnique.Find(x => x.Equals(v)).Occurence++;
                            }
                            else
                            {
                                AllPointsCoveredByAllLinesUnique.Add(v);
                            }
                        }
                    }
                    else
                    {
                        for (int i = Convert.ToInt32(lineSegment.First.X); i <= lineSegment.Second.X; i++)
                        {
                            var v = new Vector(i, lineSegment.Second.Y, 1);
                            if (AllPointsCoveredByAllLinesUnique.Contains(v))
                            {
                                AllPointsCoveredByAllLinesUnique.Find(x => x.Equals(v)).Occurence++;
                            }
                            else
                            {
                                AllPointsCoveredByAllLinesUnique.Add(v);
                            }
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
                    var v = new Vector(lineSegment.First.X + i * xDirection, lineSegment.First.Y + i * yDirection, 1);
                    if (AllPointsCoveredByAllLinesUnique.Contains(v))
                    {
                        AllPointsCoveredByAllLinesUnique.Find(x => x.Equals(v)).Occurence++;
                    }
                    else
                    {
                        AllPointsCoveredByAllLinesUnique.Add(v);
                    }
                }

            }
        }

        public void PrintOccurenceOfHorizontalAndVerticalPoints()
        {
            FillAllPointsCoveredByHorizontalAndVerticalLines();
            var distinctPoints = AllPointsCoveredByAllLinesUnique.ToArray();

          
            Console.WriteLine(distinctPoints.Where(x => x.Occurence >= 2).Count());
        }

        private void FillAllPointsCoveredByHorizontalAndVerticalLines()
        {
            List<Vector> points = new List<Vector>();
            for (int i =0; i< Alllines.Length; i++)
            {
               CalculatePointsCoveredByHorizontalAndVerticalLine(Alllines[i]);
            }
        }

        private void CalculatePointsCoveredByHorizontalAndVerticalLine(LineSegment lineSegment)
        {
            List<Vector> points = new List<Vector>();
            if (lineSegment.First.X == lineSegment.Second.X)
            {
                if (lineSegment.First.Y > lineSegment.Second.Y)
                {
                    for (int i = Convert.ToInt32( lineSegment.Second.Y); i <= lineSegment.First.Y; i++)
                    {
                        var v = new Vector(lineSegment.First.X, i,1) ;
                        if (AllPointsCoveredByAllLinesUnique.Contains(v))
                        {
                            AllPointsCoveredByAllLinesUnique.Find(x => x.Equals(v)).Occurence++;
                        }
                        else
                        {

                            AllPointsCoveredByAllLinesUnique.Add(v);
                        }
                    }
                }
                else
                {
                    for (int i = Convert.ToInt32(lineSegment.First.Y); i <= lineSegment.Second.Y; i++)
                    {
                      var v = new Vector(lineSegment.First.X, i,1);
                        if (AllPointsCoveredByAllLinesUnique.Contains(v))
                        {
                            AllPointsCoveredByAllLinesUnique.Find(x => x.Equals(v)).Occurence++;
                        }
                        else
                        {

                            AllPointsCoveredByAllLinesUnique.Add(v);
                        }
                    }
                }
            }
            if (lineSegment.First.Y == lineSegment.Second.Y)
            {
                if (lineSegment.First.X > lineSegment.Second.X)
                {
                    for (int i = Convert.ToInt32(lineSegment.Second.X); i <= lineSegment.First.X; i++)
                    {
                       
                        var v = new Vector( i, lineSegment.First.Y,1);
                        if (AllPointsCoveredByAllLinesUnique.Contains(v))
                        {
                            AllPointsCoveredByAllLinesUnique.Find(x => x.Equals(v)).Occurence++;
                        }
                        else
                        {

                            AllPointsCoveredByAllLinesUnique.Add(v);
                        }
                    }
                }
                else
                {
                    for (int i = Convert.ToInt32(lineSegment.First.X); i <= lineSegment.Second.X; i++)
                    {
                        var v = new Vector(i, lineSegment.Second.Y,1);
                        if (AllPointsCoveredByAllLinesUnique.Contains(v))
                        {
                            AllPointsCoveredByAllLinesUnique.Find(x => x.Equals(v)).Occurence++;
                        }
                        else
                        {
                            AllPointsCoveredByAllLinesUnique.Add(v);
                        }
                    }
                }
            }
        }

        internal void PrintOccurenceOfHorizontalAndVerticalAndDiagonalPoints()
        {
            FillAllPointsCoveredByHorizontalAndVerticalAndDiagonalLines();
            var distinctPoints = AllPointsCoveredByAllLinesUnique.ToArray();



            Console.WriteLine(distinctPoints.Where(x => x.Occurence >= 2).Count());

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
            unchecked
            {
                int result = 37; // prime

                result *= 397; // also prime (see note)
                if (X != null)
                    result += X.GetHashCode();

                result *= 397;
                if (Y != null)
                    result += Y.GetHashCode();

                result *= 397;
                if (Y != null)
                    result += Y.GetHashCode();

                return result;
            }
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


