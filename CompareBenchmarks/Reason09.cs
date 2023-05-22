using BenchmarkDotNet.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompareBenchmarks
{

    public class Reason09
    {
        private const int count = 10_000;
        private int[] values = Enumerable.Range(1, count).ToArray();

        [Benchmark]
        public Span<int> Slice()
        {
            Span<int> local = values;
            Span<int> temp = default;
            for (int i = 0; i < count - 10; i++)
                temp = local.Slice(i, 10);
            return temp;
        }
    }
}
