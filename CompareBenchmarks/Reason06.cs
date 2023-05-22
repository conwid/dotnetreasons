using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;

namespace CompareBenchmarks
{
    public class Reason06
    {
        [Benchmark]
        public int ParseInt() => int.Parse("123456789");

    }
}