using BenchmarkDotNet.Attributes;
using System.Buffers;

namespace NewFeatureBenchmarks;

[MemoryDiagnoser, HtmlExporter]
public class Reason11
{
    private const int size = 10_000;
    private ArrayPool<int> pool = ArrayPool<int>.Shared;
    private int[] source = Enumerable.Repeat(0, size).ToArray();

    [Benchmark(Baseline = true)]
    public async Task UseArrays()
    {
        var target = new int[size];
        source.CopyTo(target, 0);
    }

    [Benchmark]
    public async Task UseArrayPool()
    {
        var target = pool.Rent(size);
        source.CopyTo(target, 0);
        pool.Return(target);
    }
}
