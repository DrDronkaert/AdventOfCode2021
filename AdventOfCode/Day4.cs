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
            bingo.PrintFirst();

        }
        public static void AdventOfCode42()
        {
            var data = ReadFileLogic.CreateArrayFromInputFileName("input4");
            var bingo = new Bingo(data);
            bingo.PrintLast();
        }
    }


    public class Bingo
    {
        public int[] NumbersToDrawFrom { get; set; }
        public Board[] AllBoards { get; set; }
        public List<Board> SolvedBoards { get; set; } = new();

        public Bingo(string[] data)
        {
            NumbersToDrawFrom = Array.ConvertAll(data[0].Split(','), int.Parse);
            AllBoards = FillInBoards(data);
            this.CompleteBingoForAllBoards();
        }

        private Board[] FillInBoards(string[] data)
        {
            int id = 1;
            List<Board> boards = new();
            for (int i = 0; i < data.Length; i++)
            {
                if (data[i] == "")
                {
                    Row firstR = new(Array.ConvertAll(data[i + 1].Split(new String[] { "  ", " " }, StringSplitOptions.RemoveEmptyEntries), int.Parse));
                    Row secondR = new(Array.ConvertAll(data[i + 2].Split(new String[] { "  ", " " }, StringSplitOptions.RemoveEmptyEntries), int.Parse));
                    Row thirdR = new(Array.ConvertAll(data[i + 3].Split(new String[] { "  ", " " }, StringSplitOptions.RemoveEmptyEntries), int.Parse));
                    Row fourthR = new(Array.ConvertAll(data[i + 4].Split(new String[] { "  ", " " }, StringSplitOptions.RemoveEmptyEntries), int.Parse));
                    Row fifthR = new(Array.ConvertAll(data[i + 5].Split(new String[] { "  ", " " }, StringSplitOptions.RemoveEmptyEntries), int.Parse));


                    boards.Add(new(id, new[] { firstR, secondR, thirdR, fourthR, fifthR }));
                    id++;
                }
            }
            return boards.ToArray();
        }

        internal void CompleteBingoForAllBoards()
        {
            for (int i = 0; i < NumbersToDrawFrom.Length; i++)
            {
                for (int a =0; a < AllBoards.Length; a++) {

                    if (SolvedBoards.Any(x => x.Id == AllBoards[a].Id)) continue;
                   for (int x = 0; x < 5; x++)
                    {
                        var rowValid = true;
                        var columnValid = true;
                        for (int y = 0; y < 5; y++)
                        {
                            if (AllBoards[a].Rows[x].NumbersInRow[y] == NumbersToDrawFrom[i]) AllBoards[a].Rows[x].NumbersInRow[y] = -1;
                            if (AllBoards[a].Rows[y].NumbersInRow[x] == NumbersToDrawFrom[i]) AllBoards[a].Rows[y].NumbersInRow[x] = -1;
                            if (AllBoards[a].Rows[x].NumbersInRow[y] != -1) rowValid = false;
                            if (AllBoards[a].Rows[y].NumbersInRow[x] != -1) columnValid = false;

                        }
                        if (rowValid || columnValid)
                        {
                            Board b = AllBoards[a];
                            b.NumberToComplete = NumbersToDrawFrom[i];
                            if (!SolvedBoards.Any(x => x.Id == b.Id)) SolvedBoards.Add(b);
                            
                        }

                    }


                }
            
        }

        }

        public void PrintLast()
        {
      
                int sumUnmarked = 0;
                 var b = SolvedBoards.Last();
                    foreach (Row r in b.Rows)
                    {
                        foreach (var number1 in r.NumbersInRow)
                        {
                            if (number1 != -1) sumUnmarked += number1;
                        }
                    }
                    Console.WriteLine(sumUnmarked * b.NumberToComplete );
          
        }

        public void PrintFirst()
        {
            int sumUnmarked = 0;
            var b = SolvedBoards.First();
            foreach (Row r in b.Rows)
            {
                foreach (var number1 in r.NumbersInRow)
                {
                    if (number1 != -1) sumUnmarked += number1;
                }
            }
            Console.WriteLine(sumUnmarked * b.NumberToComplete);
        }
    }


    public class Board
    {
        public int Id { get; set; }
        public Row[] Rows { get; set; }


        public int NumberToComplete { get; set; }

        public Board(int id, Row[] rows)
        {
            Id = id;
            Rows = rows;
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

}




