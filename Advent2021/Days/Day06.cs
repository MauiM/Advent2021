using Advent2021.Data;
using Advent2021.Extensions;
using System.Linq;

namespace Advent2021.Days
{
    internal class Day06
    {
        public Day06() { }

        private class Fish
        {
            public int DaysLeft { get; set; }
            public int Count { get; set; }
        }

        public string Part1()
        {
            var items = Data06.Puzzle.Split(",").Select(x => int.Parse(x)).ToList();
            //Console.WriteLine($"Init: {string.Join(',', items.Select(x => x.ToString()))}");

            int addCount = 0;
            for (int i = 0; i < 80; i++)
            {
                for (int x = 0; x < items.Count; x++)
                {
                    items[x] -= 1;
                    if (items[x] == -1)
                    {
                        items[x] = 6;
                        addCount++;
                    }

                }

                for (int x = 0; x < addCount; x++)
                {
                    items.Add(8);
                }
                addCount = 0;

                //Console.WriteLine($"Day {i+1}: {string.Join(',', items.Select(x => x.ToString()))}");
            }

            return $"{items.Count}";
        }

        public string Part2()
        {
            var items = Data06.Puzzle.Split(",").Select(x => int.Parse(x)).ToList();
            var buckets = new Dictionary<int, long>();

            for (int x = 0; x <= 8; x++)
            {
                buckets.Add(x, items.Count(i => i == x));
            }

            for (int i = 0; i < 256; i++)
            {
                var count = buckets[0];
                buckets[0] = buckets[1];
                buckets[1] = buckets[2];
                buckets[2] = buckets[3];
                buckets[3] = buckets[4];
                buckets[4] = buckets[5];
                buckets[5] = buckets[6];
                buckets[6] = buckets[7] + count;
                buckets[7] = buckets[8];
                buckets[8] = count;
            }

            var sum = buckets.Sum(x => x.Value);

            return $"{sum}";
        }
    }
}
