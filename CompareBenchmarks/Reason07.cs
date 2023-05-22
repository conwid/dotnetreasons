using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;

namespace CompareBenchmarks
{
    [MemoryDiagnoser]
    public class Reason07
    {
        [Benchmark]
        public string FormatInt() => 123456789.ToString();
    }
}