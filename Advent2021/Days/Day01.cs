using Advent2021.Data;
using Advent2021.Extensions;

namespace Advent2021.Days
{
    internal class Day01
    {
        public Day01() { }

        public string Part1()
        {
            int valid = 0;

            var inputs = Data01.Puzzle.ToStringList();
            int previousDepth = 0;
            foreach (var input in inputs)
            {
                int depth = int.Parse(input);

                if (previousDepth != 0 && depth > previousDepth)
                {
                    valid++;
                }

                previousDepth = depth;
            }

            return valid.ToString();
        }

        public string Part2()
        {
            int valid = 0;

            var inputs = Data01.Puzzle.ToStringList();
            int previousDepth = 0;
            for(int i = 0; i < inputs.Count - 2; i++)
            {
                int depth = int.Parse(inputs[i]) + int.Parse(inputs[i + 1]) + int.Parse(inputs[i + 2]);

                if (previousDepth != 0 && depth > previousDepth)
                {
                    valid++;
                }

                previousDepth = depth;
            }

            return valid.ToString();
        }
    }
}
