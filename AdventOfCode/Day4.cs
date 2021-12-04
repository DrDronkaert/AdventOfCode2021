using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode
{
    class Day4
    {
        public static void AdventOfCode41()
        {
            var data = ReadFileLogic.CreateArrayFromInputFileName("input4");
            var bingo = new Bingo(data);
            bingo.StartFindingNumbersInBoards();
        }
    } 


    public class Bingo
    {
        public int[] NumbersToDrawFrom { get; set; }
        public Board[] Boards { get; set; }

        public Bingo(string[] data)
        {
            NumbersToDrawFrom = Array.ConvertAll(data[0].Split(','), int.Parse);
            Boards = FillInBoards(data);
        }

        private Board[] FillInBoards(string[] data)
        {
            int id = 1;
            List<Board> boards = new();
            for (int i=0;i <data.Length; i++)
            {
                if (data[i] == "")
                {
                    Board b = new Board();
                    Row firstR = new(Array.ConvertAll(data[i + 1].Split(new String[] { "  ", " "}, StringSplitOptions.RemoveEmptyEntries), int.Parse));
                    Row secondR = new(Array.ConvertAll(data[i + 2].Split(new String[] { "  ", " " }, StringSplitOptions.RemoveEmptyEntries), int.Parse));
                    Row thirdR = new(Array.ConvertAll(data[i + 3].Split(new String[] { "  ", " " }, StringSplitOptions.RemoveEmptyEntries), int.Parse));
                    Row fourthR = new(Array.ConvertAll(data[i + 4].Split(new String[] { "  ", " " }, StringSplitOptions.RemoveEmptyEntries), int.Parse));
                    Row fifthR = new(Array.ConvertAll(data[i + 5].Split(new String[] { "  ", " " }, StringSplitOptions.RemoveEmptyEntries), int.Parse));

                    Column firstC = new(new[] { firstR.NumbersInRow[0], secondR.NumbersInRow[0], thirdR.NumbersInRow[0], fourthR.NumbersInRow[0], fifthR.NumbersInRow[0] });
                    Column secondC = new(new[] { firstR.NumbersInRow[1], secondR.NumbersInRow[1], thirdR.NumbersInRow[1], fourthR.NumbersInRow[1], fifthR.NumbersInRow[1] });
                    Column thirdC = new(new[] { firstR.NumbersInRow[2], secondR.NumbersInRow[2], thirdR.NumbersInRow[2], fourthR.NumbersInRow[2], fifthR.NumbersInRow[2] });
                    Column fourthC = new(new[] { firstR.NumbersInRow[3], secondR.NumbersInRow[3], thirdR.NumbersInRow[3], fourthR.NumbersInRow[3], fifthR.NumbersInRow[3] });
                    Column fifthC = new(new[] { firstR.NumbersInRow[4], secondR.NumbersInRow[4], thirdR.NumbersInRow[4], fourthR.NumbersInRow[4], fifthR.NumbersInRow[4] });

                    boards.Add(new() { Id=id, Columns = new[] { firstC, secondC, thirdC, fourthC, fifthC }, Rows = new[] { firstR, secondR, thirdR, fourthR, fifthR } });
                    id++;
                }
            }
            return boards.ToArray();
        }

        internal void StartFindingNumbersInBoards()
        {

           while(Boards.Any(x => x.HasWon == false)) {
                for (int i = 0; i < NumbersToDrawFrom.Length; i++)
                {
                    foreach (Board b in Boards)
                    {
                       foreach (Column c in b.Columns)
                        {
                            if (c.NumbersInColumn.Contains(NumbersToDrawFrom[i])) c.NumbersInColumn[Array.IndexOf(c.NumbersInColumn, NumbersToDrawFrom[i])] = -1;
                        }
                       foreach (Row r in b.Rows)
                        {
                            if (r.NumbersInRow.Contains(NumbersToDrawFrom[i])) r.NumbersInRow[Array.IndexOf(r.NumbersInRow, NumbersToDrawFrom[i])] = -1;
                        }
                        if (b.Columns.Any(x => x.NumbersInColumn.SequenceEqual(new[] { -1, -1, -1, -1, -1 }))) {
                            b.HasWon = true;
                            int sumUnmarked = 0;
                            foreach (Column c in b.Columns)
                            {
                                foreach (var number1 in c.NumbersInColumn)
                                {
                                    if (number1 != -1) sumUnmarked += number1;
                                }
                            }
                         
                            Console.WriteLine(sumUnmarked * NumbersToDrawFrom[i]);


                        }
                        if (b.Rows.Any(x => x.NumbersInRow.SequenceEqual(new[] { -1, -1, -1, -1, -1 })))
                        {
                            b.HasWon = true;
                            int sumUnmarked = 0;
                            foreach (Column c in b.Columns) {
                            foreach (var number1 in c.NumbersInColumn)
                                {
                                    if (number1 != -1) sumUnmarked += number1;
                                }
                            }
                         
                            Console.WriteLine(sumUnmarked * NumbersToDrawFrom[i]);

                            return;

                        }

                    }

        }
           }
            var test = Boards.Where(x => x.HasWon == true);
            Console.WriteLine(Boards.Any(x => x.HasWon == true));

        }
    }
    }
    public class Board
    {
        public int Id { get; set; }
        public Row[] Rows { get; set; }
        public Column[] Columns { get; set; }

        public bool HasWon { get; set; }

        public Board()
        {

        }
    }

    public class Row
    {
        public int[] NumbersInRow { get; set; }

        public Row(int[] data)
        {
            NumbersInRow = data;
        }
    }
    public class Column
    {
        public int[] NumbersInColumn { get; set; }

        public Column(int[] data)
        {
            NumbersInColumn = data;
        }

    }


