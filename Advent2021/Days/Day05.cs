using Advent2021.Data;
using Advent2021.Extensions;
using System.Linq;

namespace Advent2021.Days
{
    internal class Day05
    {
        const int gridSize = 1000;

        private class BoardPiece
        {
            public int Value { get; set; }
        }

        private class Board
        {
            public Board()
            {
                for (int x = 0; x < gridSize; x++)
                {
                    for (int y = 0; y < gridSize; y++)
                    {
                        Grid[x, y] = new BoardPiece();
                    }
                }
            }

            public BoardPiece[,] Grid { get; set; } = new BoardPiece[gridSize, gridSize];

            public void FillLine(int x1, int y1, int x2, int y2)
            {
                if (x1 == x2)
                {
                    if (x1 > x2)
                    {
                        var temp = x2;
                        x2 = x1;
                        x1 = temp;
                    }

                    if (y1 > y2)
                    {
                        var temp = y2;
                        y2 = y1;
                        y1 = temp;
                    }

                    for (int y = y1; y <= y2; y++)
                    {
                        Grid[x1, y].Value++;
                    }
                }
                else if (y1 == y2)
                {
                    if (x1 > x2)
                    {
                        var temp = x2;
                        x2 = x1;
                        x1 = temp;
                    }

                    if (y1 > y2)
                    {
                        var temp = y2;
                        y2 = y1;
                        y1 = temp;
                    }

                    for (int x = x1; x <= x2; x++)
                    {
                        Grid[x, y1].Value++;
                    }
                }
                else
                {
                    int xIncrement = x2 > x1 ? 1 : -1;
                    int x = x1;
                    if (y2 > y1)
                    {
                        for (int y = y1; y <= y2; y++)
                        {
                            Grid[x, y].Value++;
                            x += xIncrement;
                        }
                    }
                    else
                    {

                        for (int y = y1; y > y2-1; y--)
                        {
                            Grid[x, y].Value++;
                            x += xIncrement;
                        }
                    }
                }

            }

            public int Count()
            {
                int value = 0;
                for (int x = 0; x < gridSize; x++)
                {
                    for (int y = 0; y < gridSize; y++)
                    {
                        if (Grid[x, y].Value >= 2)
                        {
                            value++;
                        }
                    }
                }
                return value;
            }

            public void Display()
            {
                for (int x = 0; x < gridSize; x++)
                {
                    for (int y = 0; y < gridSize; y++)
                    {
                        Console.Write($"{Grid[y, x].Value}");

                    }
                    Console.WriteLine("");
                }
            }
        }

        public Day05() { }

        public string Part1()
        {
            var board = new Board();
            var lines = Data05.Puzzle.Replace(" -> ",",").ToStringList();
            foreach (var line in lines)
            {
                // Console.WriteLine(line);
                var points = line.Split(',');
                board.FillLine(int.Parse(points[0]), 
                    int.Parse(points[1]), 
                    int.Parse(points[2]), 
                    int.Parse(points[3]));
            }

            return $"{board.Count()}";
        }

        public string Part2()
        {
            var board = new Board();
            var lines = Data05.Puzzle.Replace(" -> ", ",").ToStringList();
            foreach (var line in lines)
            {
                //Console.WriteLine(line);
                var points = line.Split(',');
                board.FillLine(int.Parse(points[0]),
                    int.Parse(points[1]),
                    int.Parse(points[2]),
                    int.Parse(points[3]));
            }

            //board.Display();

            return $"{board.Count()}";
        }
    }
}
