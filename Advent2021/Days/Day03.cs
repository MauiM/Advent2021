using Advent2021.Data;
using Advent2021.Extensions;

namespace Advent2021.Days
{
    internal class Day03
    {
        public Day03() { }

        public string Part1()
        {
            var lines = Data03.Puzzle.ToStringList();

            var size = lines[0].Length;
            var gamma = new int[size];
            var epsilon = new int[size];

            foreach (var line in lines)
            {
                for (int i = 0; i < size; i++)
                {
                    gamma[i] += (line[i] == '1' ? 1 : -1);
                }
            }

            for (int i = 0; i < size; i++)
            {
                gamma[i] = gamma[i] > 0 ? 1 : 0;
                epsilon[i] = gamma[i] > 0 ? 0 : 1;
            }

            int iGamma = Convert.ToInt32(string.Join("", gamma), 2);
            int iEpsilon = Convert.ToInt32(string.Join("", epsilon), 2);

            return $"{iGamma * iEpsilon}";
        }

        public string Part2()
        {
            var lines = Data03.Puzzle.ToStringList();

            var size = lines[0].Length;
            var gamma = new int[size];
            var epsilon = new int[size];

            for (int i = 0; i < size; i++)
            {
                int ones = lines.Count(x => x[i] == '1');
                int zeros = lines.Count(x => x[i] == '0');

                if (lines.Count > 1)
                {
                    gamma[i] = ones >= zeros ? 1 : 0;
                }
                else
                {
                    gamma[i] = lines[0][i] == '1' ? 1 : 0;
                }

                lines = lines.Where(x => x[i].ToString() == gamma[i].ToString()).ToList();
            }

            lines = Data03.Puzzle.ToStringList();
            for (int i = 0; i < size; i++)
            {
                int ones = lines.Count(x => x[i] == '1');
                int zeros = lines.Count(x => x[i] == '0');

                if (lines.Count > 1)
                {
                    epsilon[i] = ones >= zeros ? 0 : 1;
                }
                else
                {
                    epsilon[i] = lines[0][i] == '1' ? 1 : 0;
                }

                lines = lines.Where(x => x[i].ToString() == epsilon[i].ToString()).ToList();
            }

            int iGamma = Convert.ToInt32(string.Join("", gamma), 2);
            int iEpsilon = Convert.ToInt32(string.Join("", epsilon), 2);

            return $"{iGamma * iEpsilon}";
        }
    }
}
