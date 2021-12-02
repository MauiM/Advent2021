using Advent2021.Data;
using Advent2021.Extensions;

namespace Advent2021.Days
{
    internal class Day02
    {
        private class Data
        {
            public int forward { get; set; }
            public int up { get; set; }
            public int down { get; set; }
        }

        public Day02() { }

        public string Part1()
        {
            int horizontal = 0;
            int depth = 0;

            var lines = Data02.Puzzle.ToObjectList<Data>(seperator: "", keyValueSeperator: " ");
            foreach (var line in lines)
            {
                horizontal += line.forward;
                depth -= line.up;
                depth += line.down;
            }

            return $"{horizontal * depth}";
        }

        public string Part2()
        {
            int horizontal = 0;
            int depth = 0;
            int aim = 0;

            var lines = Data02.Puzzle.ToObjectList<Data>(seperator: "", keyValueSeperator: " ");
            foreach (var line in lines)
            {
                horizontal += line.forward;
                aim -= line.up;
                aim += line.down;

                depth += (aim * line.forward);
            }

            return $"{horizontal * depth}";
        }
    }
}
