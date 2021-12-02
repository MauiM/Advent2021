using Advent2021.Data;
using Advent2021.Extensions;

namespace Advent2021.Days
{
    internal class Day03
    {
        private class Data
        {
            public int id { get; set; }
        }

        public Day03() { }

        public string Part1()
        {
            int valid = 0;

            var lines = Data02.Puzzle.ToObjectList<Data>(seperator: "", keyValueSeperator: " ");
            foreach (var line in lines)
            {
                
            }

            return $"{valid}";
        }

        public string Part2()
        {
            int valid = 0;

            return $"{valid}";
        }
    }
}
