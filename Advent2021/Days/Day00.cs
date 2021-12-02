using Advent2021.Data;
using Advent2021.Extensions;

namespace Advent2021.Days
{
    // https://adventofcode.com/2020/day/4
    internal class Day00
    {
        private class Data
        {
            public string byr { get; set; }
            public string iyr { get; set; }
            public string eyr { get; set; }
            public string hgt { get; set; }
            public string hcl { get; set; }
            public string ecl { get; set; }
            public string pid { get; set; }
            public string cid { get; set; }
        }

        public Day00() { }

        public string Part1()
        {
            int valid = 0;

            var passports = Data00.Puzzle.ToObjectList<Data>(multiLineGrouping: true);
            foreach (var passport in passports)
            {
                if (!string.IsNullOrWhiteSpace(passport.byr)
                    && !string.IsNullOrWhiteSpace(passport.iyr)
                    && !string.IsNullOrWhiteSpace(passport.eyr)
                    && !string.IsNullOrWhiteSpace(passport.hgt)
                    && !string.IsNullOrWhiteSpace(passport.hcl)
                    && !string.IsNullOrWhiteSpace(passport.ecl)
                    && !string.IsNullOrWhiteSpace(passport.pid))
                {
                    valid++;
                }
            }

            return valid.ToString();
        }

        public string Part2()
        {
            int valid = 0;

            var passports = Data00.Puzzle.ToObjectList<Data>(multiLineGrouping: true);
            foreach (var passport in passports)
            {
                if (!string.IsNullOrWhiteSpace(passport.byr)
                    && !string.IsNullOrWhiteSpace(passport.iyr)
                    && !string.IsNullOrWhiteSpace(passport.eyr)
                    && !string.IsNullOrWhiteSpace(passport.hgt)
                    && !string.IsNullOrWhiteSpace(passport.hcl)
                    && !string.IsNullOrWhiteSpace(passport.ecl)
                    && !string.IsNullOrWhiteSpace(passport.pid))
                {
                    valid++;
                }
            }

            return valid.ToString();
        }
    }
}
