using Advent2021.Data;
using Advent2021.Extensions;
using System.Linq;

namespace Advent2021.Days
{
    internal class Day04
    {
        private class BoardPiece
        {
            public int Value { get; set; }
            public bool Found { get; set; }
        }

        private class Board
        {
            public BoardPiece[,] Grid { get; set; } = new BoardPiece[5, 5];
            public bool Won { get; set; }

            public void NumberCalled(int number)
            {
                for (int x = 0; x < 5; x++)
                {
                    for (int y = 0; y < 5; y++)
                    {
                        if (Grid[x, y].Value == number)
                        {
                            Grid[x, y].Found = true;
                            return;
                        }
                    }
                }
            }

            public bool Win()
            {
                for (int x = 0; x < 5; x++)
                {
                    if (Grid[x, 0].Found
                        && Grid[x, 1].Found
                        && Grid[x, 2].Found
                        && Grid[x, 3].Found
                        && Grid[x, 4].Found)
                    {
                        return true;
                    }
                }

                for (int y = 0; y < 5; y++)
                {
                    if (Grid[0, y].Found
                        && Grid[1, y].Found
                        && Grid[2, y].Found
                        && Grid[3, y].Found
                        && Grid[4, y].Found)
                    {
                        return true;
                    }
                }

                //if (Grid[0, 0].Found
                //        && Grid[1, 1].Found
                //        && Grid[2, 2].Found
                //        && Grid[3, 3].Found
                //        && Grid[4, 4].Found)
                //{
                //    return true;
                //}

                //if (Grid[4, 0].Found
                //        && Grid[3, 1].Found
                //        && Grid[2, 2].Found
                //        && Grid[1, 3].Found
                //        && Grid[0, 4].Found)
                //{
                //    return true;
                //}

                return false;
            }

            public int UnmarkedNumbers()
            {
                int value = 0;
                for (int x = 0; x < 5; x++)
                {
                    for (int y = 0; y < 5; y++)
                    {
                        if (!Grid[x, y].Found)
                        {
                            value += Grid[x, y].Value;
                        }
                    }
                }
                return value;
            }
        }

    public Day04() { }

        public string Part1()
        {
            var numbers = new List<int>(Data04.Puzzle.Split(',').Select(s => int.Parse(s)));
            var boardsData = Data04.PuzzleBoards.ToStringList(multiLineGrouping: true);
            var boards = new List<Board>(); 

            // Initialize boards
            foreach (var boardData in boardsData)
            {
                int i = 0;
                var boardNumbers = boardData.Trim().Replace("  ", " ").Split(" ").Select(s => int.Parse(s)).ToArray();
                var board = new Board();
                for (int x = 0; x < 5; x++)
                {
                    for (int y = 0; y < 5; y++)
                    {
                        board.Grid[x,y] = new BoardPiece() {
                            Value = boardNumbers[i],
                            Found = false
                        };
                        i++;
                    }
                }
                boards.Add(board);
            }

            bool part2 = true;
            int wins = 0;
            foreach (var number in numbers)
            {
                foreach (var board in boards)
                {
                    if (board.Won)
                    {
                        continue;
                    }

                    board.NumberCalled(number);
                    if (board.Win())
                    {
                        if (part2)
                        {
                            wins++;
                            board.Won = true;
                            if (wins == boards.Count)
                            {
                                return $"{number * board.UnmarkedNumbers()}";
                            }
                        }
                        else
                        {
                            return $"{number * board.UnmarkedNumbers()}";
                        }
                    }
                }
            }

            return $"";
        }
    }
}
