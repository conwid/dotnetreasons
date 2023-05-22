using BenchmarkDotNet.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompareBenchmarks
{
    public class Reason08
    {
        private int[] numbers;

        [GlobalSetup]
        public void Setup()
        {
            Random r = new Random();
            numbers = Enumerable.Range(0, 10_000).Select(_ => r.Next()).ToArray();
        }

        [Benchmark]
        public int Min() => numbers.Min();

        [Benchmark]
        public int Max() => numbers.Max();

        [Benchmark]
        public void OrderBy()
        {
            foreach (var n in numbers.OrderBy(i => i)) { }
        }
    }
}
